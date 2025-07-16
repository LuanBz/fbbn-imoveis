<script setup lang="ts">
import type { StepperItem } from "@nuxt/ui";

const items = ref<StepperItem[]>([
  {
    title: "Pré-lançamento",
    description: "Antecipe seu interesse",
    icon: "mdi:rocket-launch",
  },
  {
    title: "Lançamento",
    description: "Hora de escolher seu imóvel",
    icon: "mdi:play",
  },
  {
    title: "Em Obras",
    description: "Entrega prevista para 2024",
    icon: "mdi:tools",
  },
  {
    title: "Pronto",
    description: "Seu novo lar está pronto",
    icon: "i-lucide-home",
  },
]);
</script>

<template>
  <UStepper :items="items" size="lg" orientation="vertical" class="w-full" />
</template>
