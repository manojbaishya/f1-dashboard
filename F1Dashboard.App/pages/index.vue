<template>
  <div class="space-y-6">
    <h1 class="text-3xl font-bold">Welcome to F1 Dashboard</h1>
    <p class="text-muted-foreground">
      Explore comprehensive Formula 1 data including drivers, constructors, races, and circuits.
    </p>
    <div class="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
      <div class="rounded-lg border bg-card p-4">
        <h3 class="text-lg font-semibold">Drivers</h3>
        <p class="text-2xl font-bold" v-if="driversCount !== null">{{ driversCount }}</p>
        <p class="text-2xl font-bold" v-else>Loading...</p>
      </div>
      <div class="rounded-lg border bg-card p-4">
        <h3 class="text-lg font-semibold">Constructors</h3>
        <p class="text-2xl font-bold" v-if="constructorsCount !== null">{{ constructorsCount }}</p>
        <p class="text-2xl font-bold" v-else>Loading...</p>
      </div>
      <div class="rounded-lg border bg-card p-4">
        <h3 class="text-lg font-semibold">Races</h3>
        <p class="text-2xl font-bold" v-if="racesCount !== null">{{ racesCount }}</p>
        <p class="text-2xl font-bold" v-else>Loading...</p>
      </div>
      <div class="rounded-lg border bg-card p-4">
        <h3 class="text-lg font-semibold">Circuits</h3>
        <p class="text-2xl font-bold" v-if="circuitsCount !== null">{{ circuitsCount }}</p>
        <p class="text-2xl font-bold" v-else>Loading...</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
const driversCount = ref<number | null>(null)
const constructorsCount = ref<number | null>(null)
const racesCount = ref<number | null>(null)
const circuitsCount = ref<number | null>(null)

const fetchCounts = async () => {
  try {
    const [drivers, constructors, races, circuits] = await Promise.all([
      fetch('http://localhost:5248/api/drivers').then(res => res.json()),
      fetch('http://localhost:5248/api/constructors').then(res => res.json()),
      fetch('http://localhost:5248/api/races').then(res => res.json()),
      fetch('http://localhost:5248/api/circuits').then(res => res.json())
    ])

    driversCount.value = drivers.length
    constructorsCount.value = constructors.length
    racesCount.value = races.length
    circuitsCount.value = circuits.length
  } catch (error) {
    console.error('Error fetching counts:', error)
  }
}

onMounted(() => {
  fetchCounts()
})
</script> 