<template>
  <div class="space-y-6">
    <div class="flex items-center justify-between">
      <h1 class="text-3xl font-bold">F1 Circuits</h1>
      <div class="relative w-64">
        <input
          v-model="searchQuery"
          type="text"
          placeholder="Search circuits..."
          class="w-full rounded-md border border-input bg-background px-3 py-2 text-sm ring-offset-background placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring"
          @input="handleSearch"
        />
      </div>
    </div>

    <div class="rounded-md border">
      <div class="relative w-full overflow-auto">
        <table class="w-full caption-bottom text-sm">
          <thead class="[&_tr]:border-b">
            <tr class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted">
              <th class="h-12 px-4 text-left align-middle font-medium">Name</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Location</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Country</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Coordinates</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Altitude</th>
            </tr>
          </thead>
          <tbody class="[&_tr:last-child]:border-0">
            <tr
              v-for="circuit in circuits"
              :key="circuit.id"
              class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
            >
              <td class="p-4 align-middle">{{ circuit.name }}</td>
              <td class="p-4 align-middle">{{ circuit.location }}</td>
              <td class="p-4 align-middle">{{ circuit.country }}</td>
              <td class="p-4 align-middle">
                <a
                  v-if="circuit.latitude && circuit.longitude"
                  :href="getGoogleMapsUrl(circuit)"
                  target="_blank"
                  rel="noopener noreferrer"
                  class="text-blue-600 hover:underline"
                >
                  {{ formatCoordinates(circuit) }}
                </a>
                <span v-else>-</span>
              </td>
              <td class="p-4 align-middle">{{ circuit.altitude ? `${circuit.altitude}m` : '-' }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Circuit {
  id: number
  name: string
  location: string
  country: string
  latitude: number | null
  longitude: number | null
  altitude: number | null
}

const circuits = ref<Circuit[]>([])
const searchQuery = ref('')

const fetchCircuits = async (query?: string) => {
  try {
    const url = query
      ? `http://localhost:5248/api/circuits/search?name=${encodeURIComponent(query)}`
      : 'http://localhost:5248/api/circuits'
    const response = await fetch(url)
    circuits.value = await response.json()
  } catch (error) {
    console.error('Error fetching circuits:', error)
  }
}

const handleSearch = useDebounceFn(() => {
  fetchCircuits(searchQuery.value)
}, 300)

const formatCoordinates = (circuit: Circuit) => {
  if (!circuit.latitude || !circuit.longitude) return '-'
  return `${circuit.latitude.toFixed(4)}, ${circuit.longitude.toFixed(4)}`
}

const getGoogleMapsUrl = (circuit: Circuit) => {
  if (!circuit.latitude || !circuit.longitude) return '#'
  return `https://www.google.com/maps?q=${circuit.latitude},${circuit.longitude}`
}

onMounted(() => {
  fetchCircuits()
})
</script> 