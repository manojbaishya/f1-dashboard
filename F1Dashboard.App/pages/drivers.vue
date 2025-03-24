<template>
  <div class="space-y-6">
    <div class="flex items-center justify-between">
      <h1 class="text-3xl font-bold">F1 Drivers</h1>
      <div class="relative w-64">
        <input
          v-model="searchQuery"
          type="text"
          placeholder="Search drivers..."
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
              <th class="h-12 px-4 text-left align-middle font-medium">Number</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Code</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Nationality</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Date of Birth</th>
            </tr>
          </thead>
          <tbody class="[&_tr:last-child]:border-0">
            <tr
              v-for="driver in drivers"
              :key="driver.id"
              class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
            >
              <td class="p-4 align-middle">{{ driver.forename }} {{ driver.surname }}</td>
              <td class="p-4 align-middle">{{ driver.number || '-' }}</td>
              <td class="p-4 align-middle">{{ driver.code || '-' }}</td>
              <td class="p-4 align-middle">{{ driver.nationality }}</td>
              <td class="p-4 align-middle">{{ formatDate(driver.dateOfBirth) }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Driver {
  id: number
  forename: string
  surname: string
  number: number | null
  code: string | null
  nationality: string
  dateOfBirth: string
}

const drivers = ref<Driver[]>([])
const searchQuery = ref('')

const fetchDrivers = async (query?: string) => {
  try {
    const url = query
      ? `http://localhost:5248/api/drivers/search?name=${encodeURIComponent(query)}`
      : 'http://localhost:5248/api/drivers'
    const response = await fetch(url)
    drivers.value = await response.json()
  } catch (error) {
    console.error('Error fetching drivers:', error)
  }
}

const handleSearch = useDebounceFn(() => {
  fetchDrivers(searchQuery.value)
}, 300)

const formatDate = (date: string | null) => {
  if (!date) return '-'
  return new Date(date).toLocaleDateString()
}

onMounted(() => {
  fetchDrivers()
})
</script> 