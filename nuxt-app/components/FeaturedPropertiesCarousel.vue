<script setup lang="ts">
import FeaturedPropertiesCard from "~/components/FeaturedPropertiesCard.vue";

const items = [
  {
    image: "/img/exemploG.jpg",
    price: "R$1.500.000",
    locale: "Barra da Tijuca",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$2.500.000",
    locale: "Copacabana",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$1.200.000",
    locale: "Ipanema",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$3.000.000",
    locale: "Leblon",
  },
];
</script>

<template>
  <h3 class="text-2xl font-bold text-eerie-black mb-4">
    Alguns imóveis em destaque
  </h3>
  <div>
    <UCarousel
      v-slot="{ item }"
      :items="items"
      class="w-full"
      :ui="{ item: 'basis-auto' }"
    >
      <FeaturedPropertiesCard :item="item" />
    </UCarousel>
  </div>
</template>
