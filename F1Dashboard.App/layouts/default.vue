<template>
  <div class="min-h-screen bg-background">
    <header class="sticky top-0 z-50 w-full border-b bg-background/95 backdrop-blur supports-[backdrop-filter]:bg-background/60">
      <div class="container flex h-14 items-center">
        <NuxtLink to="/" class="mr-6 flex items-center space-x-2">
          <span class="font-bold">F1 Dashboard</span>
        </NuxtLink>
        <nav class="flex items-center space-x-6 text-sm font-medium">
          <NuxtLink to="/drivers" class="transition-colors hover:text-foreground/80">Drivers</NuxtLink>
          <NuxtLink to="/constructors" class="transition-colors hover:text-foreground/80">Constructors</NuxtLink>
          <NuxtLink to="/races" class="transition-colors hover:text-foreground/80">Races</NuxtLink>
          <NuxtLink to="/circuits" class="transition-colors hover:text-foreground/80">Circuits</NuxtLink>
        </nav>
      </div>
    </header>
    <main class="container py-6">
      <slot />
    </main>
  </div>
</template>

<script setup lang="ts">
// No additional script needed for now
</script> 