<script setup lang="ts">
import FeaturedPropertiesCard from "~/components/FeaturedPropertiesCard.vue";

const items = [
  {
    image: "/img/exemploG.jpg",
    price: "R$1.500.000,00",
    locale: "Barra da Tijuca",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$2.500.000,00",
    locale: "Copacabana",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$1.200.000,00",
    locale: "Ipanema",
  },
  {
    image: "/img/exemploG.jpg",
    price: "R$3.000.000,00",
    locale: "Leblon",
  },
];
</script>

<template>
  <h3 class="text-2xl font-bold text-eerie-black m-0">
    Alguns imóveis em destaque
  </h3>
  <div>
    <UCarousel
      :items="items"
      dots
      class="w-full max-w-dvw flex mb-8"
      :ui="{ item: 'basis-auto' }"
    >
      <template #default="{ item }">
        <FeaturedPropertiesCard :item="item" />
      </template>
    </UCarousel>
  </div>
</template>
