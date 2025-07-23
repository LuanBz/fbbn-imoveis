<script setup lang="ts">
import type { DropdownMenuItem } from "@nuxt/ui";
import { ColorModeButton } from "#components";
const route = useRouter();

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
      onSelect: () => {
        route.push("/");
      },
    },
    {
      label: "Mapa interativo",
      icon: "mdi:map-search",
      onSelect: () => {
        route.push("/map");
      },
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
      href: "https://www.instagram.com/fbbn_lancamentosrj/",
      target: "_blank",
    },
    {
      label: "Instagram IPANEMA",
      icon: "mdi:instagram",
      href: "https://www.instagram.com/ipanema_fbbn/",
      target: "_blank",
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
