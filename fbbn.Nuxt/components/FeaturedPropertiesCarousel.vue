<script setup lang="ts">
import FeaturedPropertiesCard from "~/components/FeaturedPropertiesCard.vue";
import type { Imovel } from "~/models/imovel";

const props = defineProps({
  imoveis: {
    type: Array as () => Imovel[],
    required: true,
  },
  title: {
    type: String,
    default: "Alguns imóveis em destaque",
  },
  zona: {
    type: String,
    default: "",
  },
});

const FilterByZone = (imovel: Imovel) => {
  if (!props.zona) return;

  const ZoneBairros = regioesMapeadas[props.zona] || [];
  return ZoneBairros.includes(imovel.bairro);
};

const imoveisByZone = computed(() => props.imoveis.filter(FilterByZone));
</script>

<template>
  <h3 class="text-2xl font-bold">{{ title }}</h3>
  <div>
    <UCarousel
      autoplay
      v-slot="{ item }"
      :items="zona ? imoveisByZone : props.imoveis"
      class="w-full"
      :ui="{ item: 'basis-auto' }"
    >
      <FeaturedPropertiesCard :imovel="item" />
    </UCarousel>
  </div>
</template>
