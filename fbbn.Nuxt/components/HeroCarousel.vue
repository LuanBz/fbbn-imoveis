<script setup lang="ts">
import HeroCard from "~/components/HeroCard.vue";
import type { Imovel } from "~/models/imovel";

defineProps({
  imoveis: {
    type: Array as () => Imovel[],
    required: true,
  },
});
</script>

<template>
  <div>
    <UCarousel
      :items="imoveis"
      loop
      dots
      :ui="{
        dot: 'data-[state=active]:bg-secondary bg-inverted',
      }"
      :autoplay="{ delay: 5000 }"
      class="w-full max-w-dvw select-none"
    >
      <template #default="{ item }">
        <HeroCard v-if="item" :imovel="item" />
      </template>
    </UCarousel>
  </div>
</template>
