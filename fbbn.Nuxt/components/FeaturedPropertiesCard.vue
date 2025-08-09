<script setup lang="ts">
import type { Imovel } from "~/models/imovel";
import { ref } from "vue";

const props = defineProps({
  imovel: {
    type: Object as () => Imovel,
    required: true,
  },
});

const currentIndex = ref(0);
const currentImage = ref<string | null>(null);
let intervalId: number | undefined;

watchEffect(() => {
  if (!props.imovel) return;
  currentImage.value = props.imovel.imagens?.[0] || null;
  if (!intervalId && props.imovel.imagens?.length > 1) {
    intervalId = window.setInterval(() => {
      if (!props.imovel?.imagens) return;
      currentIndex.value =
        (currentIndex.value + 1) % props.imovel.imagens.length;
      currentImage.value = props.imovel.imagens[currentIndex.value];
    }, 5000);
  }
});
</script>

<template>
  <UCard
    :ui="{
      body: 'p-0 sm:p-0',
    }"
    class="w-50 hauto bg-primary lg:w-100 rounded-3xl select-none"
  >
    <div class="relative w-full h-[200px] lg:h-[250px]">
      <transition name="fade" appear mode="out-in">
        <NuxtImg
          v-if="currentImage"
          :key="currentImage"
          :src="currentImage"
          alt="Foto da propriedade"
          class="object-cover w-full h-full rounded-t-xl"
        />
      </transition>
    </div>

    <div class="flex flex-col grow p-4 w-full h-2/3 gap-y-4">
      <div class="flex justify-between">
        <div class="flex flex-col gap-2">
          <div class="flex flex-row gap-1 justify-start h-fit">
            <UBadge variant="solid" color="tertiary" class="w-fit">{{
              imovel.tags[0]
            }}</UBadge>
          </div>
          <div>
            <p class="text-2xl text-left font-bold text-white">
              R${{ formatPrice(imovel.preco) }}
            </p>
            <div class="flex flex-row items-center gap-2 text-muted">
              <UIcon name="mdi-map-marker" />
              <p>{{ imovel.bairro }}</p>
            </div>
          </div>
        </div>
        <div v-if="isDesktop" class="flex flex-col justify-end items-end">
          <div class="flex flex-row items-center gap-2 font-bold text-white">
            <p>{{ imovel.quartos }}</p>
            <UIcon name="mdi-bed" />
          </div>
          <div class="flex flex-row items-center gap-2 font-bold text-white">
            <p>{{ imovel.vagasGaragem }}</p>
            <UIcon name="mdi-garage" />
          </div>
          <div class="flex flex-row items-center gap-2 font-bold text-white">
            <p>{{ imovel.metragem }}m²</p>
            <UIcon name="mdi-ruler-square" />
          </div>
        </div>
      </div>
      <NuxtLink :to="`/properties/${imovel.imovelId}`" class="w-full">
        <UButton
          color="secondary"
          icon="mdi:eye"
          label="Mais detalhes"
          class="rounded-2xl w-full justify-center cursor-pointer"
      /></NuxtLink>
    </div>
  </UCard>
</template>
