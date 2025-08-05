<script lang="ts" setup>
import type { Imovel } from "~/models/imovel";

const props = defineProps<{
  imovel: Imovel;
}>();

const showDetails = ref(false);
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
    }, 3000);
  }
});
</script>
<template>
  <div class="relative h-[50dvh] w-full overflow-hidden">
    <transition name="fade">
      <NuxtImg
        v-if="currentImage"
        :key="currentImage"
        :src="currentImage"
        alt="Imagem do imóvel"
        class="absolute w-full h-full object-cover transition-opacity duration-1000"
      />
    </transition>
    <div class="absolute inset-0 flex items-end justify-end z-0">
      <div
        class="absolute z-0 -rotate-45 top-22 -left-22 bg-secondary dark:bg-tertiary text-white font-bold py-2 px-30 shadow-lg text-lg"
      >
        LANÇAMENTO
      </div>
      <div class="flex flex-row gap-4 p-8 items-end">
        <div
          v-if="showDetails && imovel"
          class="grow grid grid-cols-3 p-4 bg-clean dark:bg-primary rounded-xl"
        >
          <div class="col-span-2 gap-2 flex flex-col">
            <div class="flex flex-row items-center gap-1">
              <UIcon name="mdi:map-marker" class="size-5" />
              <p class="text-md truncate">
                {{ imovel.bairro }}, {{ imovel.cidade }}
              </p>
            </div>
            <div class="flex flex-col gap-1">
              <h2 class="text-2xl font-bold truncate">{{ imovel.nome }}</h2>
              <h3 class="text-xl font-normal">
                ~R$ {{ formatPrice(imovel.precom2) }} /m²
              </h3>
            </div>
          </div>
          <div class="grow items-end justify-end flex flex-col gap-3">
            <div class="flex flex-row gap-1 items-center">
              <p class="text-sm font-bold">{{ imovel.quartos }}</p>
              <UIcon name="mdi:bed" class="size-6" />
            </div>

            <div class="flex flex-row gap-2 items-center">
              <p class="text-sm text-right font-medium">
                {{ imovel.metragem }}m²
              </p>
            </div>
          </div>
          <div class="flex flex-row col-span-3 gap-2 mt-4">
            <NuxtLink :to="`/properties/${imovel.imovelId}`" class="w-full">
              <UButton
                trailing-icon="i-lucide-arrow-right"
                color="secondary"
                variant="solid"
                class="w-full h-full justify-center"
              >
                Mais detalhes
              </UButton>
            </NuxtLink>
          </div>
        </div>

        <UButton
          class="rounded-full bg-clean dark:bg-secondary"
          size="xl"
          :icon="showDetails ? 'mdi:eye-off' : 'mdi:eye'"
          :ui="{ leadingIcon: 'text-secondary dark:text-inverted' }"
          @click="showDetails = !showDetails"
        />
      </div>
    </div>
  </div>
</template>
