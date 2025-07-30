<template>
  <div class="bg-tertiary w-full flex flex-col">
    <div class="relative h-[50dvh] w-full overflow-hidden">
      <transition name="fade">
        <img
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
            v-if="showDetails && novidade"
            class="grow grid grid-cols-3 p-4 bg-clean dark:bg-primary rounded-xl"
          >
            <div class="col-span-2 gap-2 flex flex-col">
              <div class="flex flex-row items-center gap-1">
                <UIcon name="mdi:map-marker" class="size-5" />
                <p class="text-md truncate">
                  {{ novidade.bairro }}, {{ novidade.cidade }}
                </p>
              </div>
              <div class="flex flex-col gap-1">
                <h2 class="text-2xl font-bold truncate">{{ novidade.nome }}</h2>
                <h3 class="text-xl font-normal">
                  ~R$ {{ formatPrice(novidade.precom2) }} /m²
                </h3>
              </div>
            </div>
            <div class="grow items-end justify-end flex flex-col gap-3">
              <div class="flex flex-row gap-1 items-center">
                <p class="text-sm font-bold">{{ novidade.quartos }}</p>
                <UIcon name="mdi:bed" class="size-6" />
              </div>

              <div class="flex flex-row gap-2 items-center">
                <p class="text-sm text-right font-medium">
                  {{ novidade.metragem }}m²
                </p>
              </div>
            </div>
            <div class="flex flex-row col-span-3 gap-2 mt-4">
              <NuxtLink :to="`/properties/${novidade.imovelId}`" class="w-full">
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
    <div class="min-h-[50dvh] mb-8 bg-tertiary">
      <div class="mx-4 mt-8 p-4 bg-clean dark:bg-primary rounded-full">
        <UInput
          icon="i-lucide-search"
          size="xl"
          class="w-full"
          variant="ghost"
          placeholder="Pesquise um local ou característica do imóvel..."
        />
      </div>
      <div class="w-full justify-between">
        <h1 class="text-white px-11 mt-4 font-light text-xl">
          No momento você está buscando imóveis em
        </h1>
        <div class="px-11 flex flex-col justify-between gap-2">
          <h2 class="text-white font-bold text-4xl">{{ local.toString() }}</h2>
          <UModal title="Selecione uma região" description="Escolha uma opção">
            <UButton
              icon="mdi:map-marker"
              label="Selecione uma região do seu interesse"
              color="secondary"
              variant="solid"
              size="lg"
              class="w-fit"
            />

            <template #body>
              <div class="flex flex-wrap gap-2 mt-4">
                <UBadge
                  v-for="bairro in bairros"
                  :key="bairro"
                  color="secondary"
                  variant="outline"
                  :class="{
                    'bg-secondary text-white': local === bairro,
                  }"
                  class="cursor-pointer"
                  @click="local = bairro"
                >
                  {{ bairro }}
                </UBadge>
              </div>
            </template>
          </UModal>
        </div>
        <div class="px-11 mt-8"><MapCTA /></div>
      </div>
    </div>
  </div>
  <div class="p-4 flex flex-col space-y-8">
    <HeroCarousel
      v-if="imoveisFiltrados"
      :imoveis="imoveisFiltrados.slice(0, 5)"
    />

    <PromotionalBanner />
    <FeaturedPropertiesCarousel />
    <RegionNavigation />
  </div>
</template>

<script lang="ts" setup>
import { ref } from "vue";
import { GetAllItems } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";
const showDetails = ref(false);
const local = localState();

const { data: imoveis, pending } = await useAsyncData<Imovel[]>(() =>
  GetAllItems()
);

const currentIndex = ref(0);
const currentImage = ref<string | null>(null);
const novidade = ref<Imovel | null>(null);
let intervalId: number | undefined;

watchEffect(() => {
  if (imoveis.value && imoveis.value.length > 0) {
    const destaque = imoveis.value.find((imovel) =>
      imovel.tags?.includes("Novidade")
    );
    if (destaque) {
      novidade.value = destaque;
      currentImage.value = destaque.imagens?.[0] || null;

      if (!intervalId && destaque.imagens?.length > 1) {
        intervalId = window.setInterval(() => {
          currentIndex.value =
            (currentIndex.value + 1) % destaque.imagens.length;
          currentImage.value = destaque.imagens[currentIndex.value];
        }, 3000);
      }
    } else {
      console.warn("Nenhum imóvel com tag 'Novidade' foi encontrado.");
    }
  }
});

const imoveisFiltrados = computed(() => {
  if (!imoveis.value) return [];

  return local.value === "Rio de Janeiro"
    ? imoveis.value
    : imoveis.value.filter((imovel) => imovel.bairro === local.value);
});
const bairros = [
  "Copacabana",
  "Ipanema",
  "Barra da Tijuca",
  "Botafogo",
  "Leblon",
  "Tijuca",
  "Alto do Impossível",
];
</script>
