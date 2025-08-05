<script setup lang="ts">
definePageMeta({
  layout: "map",
});
import { GetAllItems } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());

const activeMarkerId = ref();
const activeImovel = computed(() => {
  if (!imoveis.value || !activeMarkerId.value) return null;
  return imoveis.value.find(
    (imovel) => imovel.imovelId === activeMarkerId.value
  );
});
</script>
<template>
  <div class="relative w-full">
    <Map
      :imoveis="imoveis"
      @marker-click="(id: string) => (activeMarkerId = id)"
    />
    <MapPropertyCard
      v-if="activeImovel"
      @marker-click="(id: string) => (activeMarkerId = id)"
      :activeImovel="activeImovel"
    />
    <div class="absolute bottom-5 left-1/2 -translate-x-1/2 z-10">
      <NuxtLink
        class="bg-[#c7863d] hover:bg-[#b5752d] text-white font-bold py-3 px-6 rounded-full shadow-lg transition-colors duration-200 whitespace-nowrap"
        to="/search"
        >VER MAIS IMÓVEIS EM RIO DE JANEIRO
      </NuxtLink>
    </div>
  </div>
</template>
