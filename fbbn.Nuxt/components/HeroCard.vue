<script setup lang="ts">
import { UIcon } from "#components";
import type { Imovel } from "~/models/imovel";

defineProps({
  imovel: {
    type: Object as () => Imovel,
    required: true,
  },
});
</script>

<template>
  <div
    class="relative text-white rounded-3xl h-[400px] flex flex-col overflow-hidden w-full"
  >
    <nuxt-img
      v-if="imovel.imagens && imovel.imagens.length > 0"
      :src="imovel.imagens[0]"
      :alt="imovel.nome"
      class="w-full h-56 object-cover"
      format="webp"
      quality="80"
    />
    <span
      class="bg-primary text-white text-xs font-bold px-4 py-2 rounded-3xl absolute top-4 right-4"
    >
      {{ imovel.tags[0] }}
    </span>
    <div class="grow grid grid-cols-3 bg-primary p-6">
      <div class="col-span-2 gap-3 flex flex-col">
        <div class="flex flex-row items-center gap-1">
          <UIcon name="mdi:map-marker" class="size-5" />
          <p class="text-md truncate">{{ imovel.bairro }}</p>
        </div>
        <div class="flex flex-col gap-1">
          <h2 class="text-xl font-bold truncate">{{ imovel.nome }}</h2>
          <h3 class="text-2xl font-normal">
            R${{ formatPrice(imovel.preco) }}
          </h3>
        </div>
      </div>
      <div class="grow items-end flex flex-col gap-3">
        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ imovel.quartos }}</p>
          <UIcon name="mdi:bed" class="size-6" />
        </div>

        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ imovel.banheiros }}</p>
          <UIcon name="mdi:shower-head" class="size-6" />
        </div>
        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ imovel.metragem }}m²</p>
          <UIcon name="mdi:ruler-square" class="size-6" />
        </div>
      </div>
      <div class="flex flex-row col-span-3 gap-2 mt-2">
        <UButton color="tertiary" variant="solid" class="w-50 justify-center"
          >Agende sua visita</UButton
        >
        <NuxtLink :to="`/properties/${imovel.imovelId}`" class="w-50">
          <UButton
            trailing-icon="i-lucide-arrow-right"
            color="secondary"
            variant="solid"
            class="w-full h-full justify-center"
            >Ver Mais</UButton
          ></NuxtLink
        >
      </div>
    </div>
  </div>
</template>
