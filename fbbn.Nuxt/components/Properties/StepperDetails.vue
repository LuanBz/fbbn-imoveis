<script setup lang="ts">
import type { StepperItem } from "@nuxt/ui";

const props = defineProps<{
  currentStatus: string;
  datalancamento?: Date | null;
}>();
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
    description: `Entrega prevista para ${props.datalancamento}`,
    icon: "mdi:tools",
  },
  {
    title: "Pronto",
    description: "Seu novo lar está pronto",
    icon: "i-lucide-home",
  },
]);

const activeIndex = computed(() => {
  return items.value.findIndex(
    (item) =>
      typeof item.title === "string" && item.title === props.currentStatus
  );
});
</script>

<template>
  <UStepper
    disabled
    :items="items"
    size="lg"
    orientation="vertical"
    class="w-full"
    color="secondary"
    v-model="activeIndex"
  />
</template>
