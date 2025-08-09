<template>
  <div class="min-h-screen">
    <AppHeader />

    <main
      class="flex flex-col md:w-11/12 lg:w-10/12 xl:w-5/6 2xl:w-4/6 mx-auto"
    >
      <slot />
    </main>

    <AppFooter />
  </div>
</template>
