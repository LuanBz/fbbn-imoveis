<script setup lang="ts">
import type { DropdownMenuItem } from "@nuxt/ui";
import { ColorModeButton } from "#components";

const items = ref<DropdownMenuItem[][]>([
  [
    {
      label: "FBBN Imóveis",
      avatar: {
        src: "https://github.com/benjamincanac.png",
      },
      type: "label",
    },
  ],
  [
    {
      label: "Página inicial",
      icon: "mdi:home",
    },
    {
      label: "Mapa interativo",
      icon: "mdi:map-search",
    },
  ],
  [
    {
      label: "Contate-nos",
      icon: "mdi:email",
    },
    {
      label: "Sobre nós",
      icon: "mdi:information",
    },
    {
      label: "Instagram",
      icon: "mdi:instagram",
    },
  ],
]);
</script>

<template>
  <UDropdownMenu
    :items="items"
    size="xl"
    :ui="{
      content: 'w-48',
    }"
  >
    <UButton icon="i-lucide-menu" color="neutral" variant="outline" size="xl" />
  </UDropdownMenu>
</template>
