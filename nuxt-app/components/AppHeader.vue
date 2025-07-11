<script setup lang="ts">
import ColorModeButton from "./ColorModeButton.vue";
import MenuSlide from "./MenuSlide.vue";
const items = ref([
  "Botafogo",
  "Copacabana",
  "Flamengo",
  "Glória",
  "Ipanema",
  "Jacarepaguá",
  "Laranjeiras",
  "Leblon",
  "Recreio dos Bandeirantes",
  "Rio de Janeiro",
  "Tijuca",
  "Freguesia",
]);
const value = ref("Rio de Janeiro");
</script>

<template>
  <header class="flex justify-between items-center p-4">
    <div class="flex items-center">
      <UIcon name="mdi:map-marker" class="size-8" />
      <USelectMenu
        v-model="value"
        selected-icon="mdi:check"
        :search-input="{
          placeholder: 'Busque aqui...',
        }"
        color="neutral"
        variant="none"
        :items="items"
        class="text-2xl font-bold justify-start"
      />
    </div>

    <div class="gap-3 flex"><ColorModeButton /> <MenuSlide /></div>
  </header>
</template>
