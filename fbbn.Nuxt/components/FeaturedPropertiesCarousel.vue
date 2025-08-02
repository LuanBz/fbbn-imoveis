<script setup lang="ts">
import FeaturedPropertiesCard from "~/components/FeaturedPropertiesCard.vue";
import type { Imovel } from "~/models/imovel";

defineProps({
  imoveis: {
    type: Array as () => Imovel[],
    required: true,
  },
});
</script>

<template>
  <h3 class="text-2xl font-bold text-eerie-black mb-4">
    Alguns imóveis em destaque
  </h3>
  <div>
    <UCarousel
      v-slot="{ item }"
      :items="imoveis"
      class="w-full"
      :ui="{ item: 'basis-auto' }"
    >
      <FeaturedPropertiesCard :imovel="item" />
    </UCarousel>
  </div>
</template>
