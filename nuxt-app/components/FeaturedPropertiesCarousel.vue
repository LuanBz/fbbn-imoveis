<script setup lang="ts">
import FeaturedPropertiesCard from "~/components/FeaturedPropertiesCard.vue";

const items = [
  {
    id: 1,
    image: "/img/exemploG.jpg",
    price: "R$1.500.000",
    locale: "Barra da Tijuca",
  },
  {
    id: 2,

    image: "/img/exemploG.jpg",
    price: "R$2.500.000",
    locale: "Copacabana",
  },
  {
    id: 3,

    image: "/img/exemploG.jpg",
    price: "R$1.200.000",
    locale: "Ipanema",
  },
  {
    id: 5,

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
