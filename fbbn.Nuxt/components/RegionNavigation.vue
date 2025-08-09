<script setup lang="ts">
const emit = defineEmits<{
  (e: "filtrarPorRegiao", bairros: string[]): void;
}>();

function filtrarRegiao(region: string) {
  const bairros = regioesMapeadas[region] || [];
  emit("filtrarPorRegiao", bairros);
}

const regions = ["Zona Sul", "Zona Norte", "Zona Oeste", "Centro"];
</script>

<template>
  <div>
    <h3 class="text-2xl font-bold text-eerie-black mb-4">Navegue por região</h3>
    <div class="grid grid-cols-2 md:grid-cols-4 gap-3">
      <UButton
        v-for="region in regions"
        :key="region"
        class="rounded-2xl py-4 text-sm flex justify-center bg-primary text-white h-24"
        @click="filtrarRegiao(region)"
      >
        {{ region }}
      </UButton>
    </div>
  </div>
</template>
