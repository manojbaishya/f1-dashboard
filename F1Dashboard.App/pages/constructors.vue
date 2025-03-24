<template>
  <div class="space-y-6">
    <div class="flex items-center justify-between">
      <h1 class="text-3xl font-bold">F1 Constructors</h1>
      <div class="relative w-64">
        <input
          v-model="searchQuery"
          type="text"
          placeholder="Search constructors..."
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
              <th class="h-12 px-4 text-left align-middle font-medium">Nationality</th>
              <th class="h-12 px-4 text-left align-middle font-medium">Reference</th>
              <th class="h-12 px-4 text-left align-middle font-medium">More Info</th>
            </tr>
          </thead>
          <tbody class="[&_tr:last-child]:border-0">
            <tr
              v-for="constructor in constructors"
              :key="constructor.id"
              class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
            >
              <td class="p-4 align-middle">{{ constructor.name }}</td>
              <td class="p-4 align-middle">{{ constructor.nationality }}</td>
              <td class="p-4 align-middle">{{ constructor.reference }}</td>
              <td class="p-4 align-middle">
                <a
                  v-if="constructor.url"
                  :href="constructor.url"
                  target="_blank"
                  rel="noopener noreferrer"
                  class="text-blue-600 hover:underline"
                >
                  View Details
                </a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Constructor {
  id: number
  name: string
  nationality: string
  reference: string
  url: string | null
}

const constructors = ref<Constructor[]>([])
const searchQuery = ref('')

const fetchConstructors = async (query?: string) => {
  try {
    const url = query
      ? `http://localhost:5248/api/constructors/search?name=${encodeURIComponent(query)}`
      : 'http://localhost:5248/api/constructors'
    const response = await fetch(url)
    constructors.value = await response.json()
  } catch (error) {
    console.error('Error fetching constructors:', error)
  }
}

const handleSearch = useDebounceFn(() => {
  fetchConstructors(searchQuery.value)
}, 300)

onMounted(() => {
  fetchConstructors()
})
</script> 