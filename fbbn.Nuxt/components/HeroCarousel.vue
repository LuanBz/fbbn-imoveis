<script setup lang="ts">
import HeroCard from "~/components/HeroCard.vue";

// Seus dados, prontos para serem usados
const items = [
  {
    image: "/img/exemploG.jpg",
    tag: "EM ALTA",
    title: "APARTAMENTO",
    subtitle: "Barra da Tijuca, Rio de Janeiro",
    price: "R$ 1.900.000",
    bedrooms: 3,
    bathrooms: 4,
    square: "128 m²",
  },
  {
    image: "/img/exemploG.jpg",
    tag: "LANÇAMENTO",
    title: "COBERTURA VISTA MAR",
    subtitle: "Copacabana, Rio de Janeiro",
    price: "R$ 4.500.000",
    bedrooms: 4,
    bathrooms: 6,
    square: "250 m²",
  },
  {
    image: "/img/exemploG.jpg",
    tag: "OPORTUNIDADE",
    title: "STUDIOS NO CENTRO",
    subtitle: "Centro, Rio de Janeiro",
    price: "R$ 800.000",
    bedrooms: 1,
    square: "50 m²",
    bathrooms: 1,
  },
];
</script>

<template>
  <div>
    <UCarousel
      :items="items"
      loop
      dots
      :ui="{
        dot: 'data-[state=active]:bg-secondary bg-inverted',
      }"
      :autoplay="{ delay: 10000 }"
      class="w-full max-w-dvw mx-auto mb-8"
    >
      <template #default="{ item }">
        <HeroCard :item="item" />
      </template>
    </UCarousel>
  </div>
</template>
