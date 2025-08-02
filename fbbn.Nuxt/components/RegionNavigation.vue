<script setup lang="ts">
const emit = defineEmits<{
  (e: "filtrarPorRegiao", bairros: string[]): void;
}>();

function filtrarRegiao(region: string) {
  if (region === "Todos os empreendimentos") {
    emit("filtrarPorRegiao", []);
  } else {
    const bairros = regioesMapeadas[region] || [];
    emit("filtrarPorRegiao", bairros);
  }
}

const regions = [
  "Todos os empreendimentos",
  "Zona Sul",
  "Barra e Recreio",
  "Zona Norte",
  "Jacarepaguá",
  "Zona Oeste",
];

// pode colocar no <script setup> do RegionNavigation.vue
const regioesMapeadas: Record<string, string[]> = {
  "Zona Sul": [
    "Copacabana",
    "Ipanema",
    "Leblon",
    "Leme",
    "Botafogo",
    "Urca",
    "Lagoa",
    "Flamengo",
    "Jardim Botânico",
    "Gávea",
    "São Conrado",
  ],
  "Barra e Recreio": ["Barra da Tijuca", "Recreio dos Bandeirantes", "Joá"],
  "Zona Norte": ["Tijuca", "Grajaú", "Maracanã", "Méier"],
  Jacarepaguá: ["Jacarepaguá"],
  "Zona Oeste": ["Campo Grande", "Bangu", "Realengo"],
};
</script>

<template>
  <div>
    <h3 class="text-2xl font-bold text-eerie-black mb-4">Navegue por região</h3>
    <div class="grid grid-cols-3 gap-3">
      <UButton
        v-for="region in regions"
        :key="region"
        class="rounded-2xl py-4 text-sm flex justify-center bg-tertiary text-white h-24"
        @click="filtrarRegiao(region)"
      >
        {{ region }}
      </UButton>
    </div>
  </div>
</template>
