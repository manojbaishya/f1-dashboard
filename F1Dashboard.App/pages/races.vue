<template>
  <div class="space-y-6">
    <div class="flex items-center justify-between">
      <h1 class="text-3xl font-bold">F1 Races</h1>
      <div class="flex items-center gap-4">
        <select
          v-model="selectedYear"
          class="rounded-md border border-input bg-background px-3 py-2 text-sm ring-offset-background focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring"
          @change="fetchRaces"
        >
          <option v-for="year in years" :key="year" :value="year">{{ year }}</option>
        </select>
      </div>
    </div>

    <div class="rounded-md border">
      <div class="relative w-full overflow-auto">
        <table class="w-full caption-bottom text-sm">
          <thead class="[&_tr]:border-b">
            <tr class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted">
              <th class="h-12 px-4 text-left align-middle font-medium">Round</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Name</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Circuit</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Date</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Time</th>
            </tr>
          </thead>
          <tbody class="[&_tr:last-child]:border-0">
            <tr
              v-for="race in races"
              :key="race.id"
              class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
            >
              <td class="p-4 align-middle">{{ race.round }}</td>
              <td class="p-4 align-middle">{{ race.name }}</td>
              <td class="p-4 align-middle">{{ race.circuit?.name }} ({{ race.circuit?.country }})</td>
              <td class="p-4 align-middle">{{ formatDate(race.date) }}</td>
              <td class="p-4 align-middle">{{ formatTime(race.time) }}</td>
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
  country: string
}

interface Race {
  id: number
  round: number
  name: string
  date: string
  time: string | null
  circuit: Circuit | null
}

const races = ref<Race[]>([])
const selectedYear = ref(new Date().getFullYear())
const years = computed(() => {
  const currentYear = new Date().getFullYear()
  return Array.from({ length: currentYear - 1950 + 1 }, (_, i) => currentYear - i)
})

const fetchRaces = async () => {
  try {
    const response = await fetch(`http://localhost:5248/api/races/year/${selectedYear.value}`)
    races.value = await response.json()
  } catch (error) {
    console.error('Error fetching races:', error)
  }
}

const formatDate = (date: string) => {
  return new Date(date).toLocaleDateString()
}

const formatTime = (time: string | null) => {
  if (!time) return '-'
  return time.substring(0, 5) // Display only HH:mm
}

onMounted(() => {
  fetchRaces()
})
</script> 