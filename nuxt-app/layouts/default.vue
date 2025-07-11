<template>
  <div class="min-h-screen">
    <AppHeader />

    <main class="p-4 space-y-8 flex flex-col">
      <slot />
    </main>

    <AppFooter />
  </div>
</template>
