<script setup lang="ts">
import { watch } from "vue";
import ColorModeButton from "./ColorModeButton.vue";
import MenuSlide from "./MenuSlide.vue";
const items = ref([
  {
    type: "label",
    label: "Estado",
  },
  "Rio de Janeiro",
  {
    type: "separator",
  },
  {
    type: "label",
    label: "Zona Sul",
  },
  "Copacabana",
  "Ipanema",
  "Leblon",
  "Laranjeiras",
  "Flamengo",
  "Botafogo",
  "Glória",
  {
    type: "separator",
  },
  {
    type: "label",
    label: "Zona Centro",
  },
  "Centro",
  "Tijuca",
  "Porto Maravilha",
  {
    type: "separator",
  },
  {
    type: "label",
    label: "Zona Oeste",
  },
  "Recreio dos Bandeirantes",
  "Barra da Tijuca",
  "Jacarepaguá",
  "Freguesia",
  "Tanque",
]);

const value = localState();
watch(value, (newValue) => {
  console.log("Valor selecionado:", newValue);
});
</script>

<template>
  <header class="flex justify-between items-center p-4 bg-primary">
    <div class="flex items-start max-w-2/3">
      <USelectMenu
        v-model="value"
        selected-icon="mdi:check"
        icon="mdi:map-marker"
        multiple
        :ui="{ content: 'min-w-fit' }"
        :search-input="{
          placeholder: 'Busque aqui...',
        }"
        color="neutral"
        variant="none"
        :items="items"
        class="text-2xl font-bold truncate items-center text-inverted"
      />
    </div>

    <div class="gap-3 flex justify-end w-1/3">
      <ColorModeButton /> <MenuSlide />
    </div>
  </header>
</template>
