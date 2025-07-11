<script setup>
const regions = [
  "Todos os empreendimentos",
  "Zona Sul",
  "Barra e Recreio",
  "Zona Norte",
  "Jacarepaguá",
  "Zona Oeste",
];
</script>

<template>
  <div>
    <h3 class="text-2xl font-bold text-eerie-black mb-4">Navegue por região</h3>
    <div class="grid grid-cols-2 gap-3">
      <UButton
        v-for="region in regions"
        :key="region"
        class="rounded-2xl py-4 text-sm flex justify-center bg-gray-200 dark:bg-gray-800 text-gray-800 dark:text-white"
      >
        {{ region }}
      </UButton>
    </div>
  </div>
</template>
