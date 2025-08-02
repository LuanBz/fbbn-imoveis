<template>
  <div class="bg-tertiary w-full flex flex-col">
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
        <div class="flex items-center gap-2">
          <UInput
            v-model="searchQuery"
            icon="i-lucide-search"
            size="xl"
            class="w-full"
            variant="ghost"
            placeholder="Pesquise um local ou característica de um imóvel"
            @keydown.enter="buscarImovel"
          />
          <UButton
            @click="buscarImovel"
            class="h-14"
            variant="ghost"
            label="Buscar"
            :ui="{ label: `dark:text-white` }"
          />
        </div>
      </div>
      <div class="w-full justify-between">
        <h1 class="text-white px-11 mt-4 font-light text-xl">
          No momento você está buscando imóveis em
        </h1>
        <div class="px-11 flex flex-col justify-between gap-2">
          <h2 class="text-white font-bold text-4xl">
            {{
              local.length === 0
                ? "Rio de Janeiro"
                : local.length === 1
                  ? local[0]
                  : `${local[0]} e mais ${local.length - 1}`
            }}
          </h2>

          <UModal title="Selecione uma região" description="Escolha uma opção">
            <UButton
              icon="mdi:map-marker"
              label="Selecione uma região do seu interesse"
              color="secondary"
              variant="solid"
              size="lg"
              class="w-fit"
            />

            <template #body="{ close }">
              <div class="flex flex-col gap-4 mt-4">
                <UInput
                  icon="i-lucide-search"
                  placeholder="Buscar bairro..."
                  v-model="searchTerm"
                  variant="outline"
                />
                <div class="flex flex-wrap gap-2">
                  <UBadge
                    v-for="bairro in bairrosFiltrados"
                    :key="bairro"
                    color="secondary"
                    variant="outline"
                    :class="{
                      'bg-secondary text-white': local.includes(bairro),
                    }"
                    class="cursor-pointer"
                    @click="toggleBairro(bairro)"
                  >
                    {{ bairro }}
                  </UBadge>
                </div>

                <div
                  class="mt-10 flex flex-col gap-5 justify-between items-center"
                >
                  <UButton
                    icon="mdi:home"
                    label="Ver todos os imóveis em Rio de Janeiro"
                    @click="
                      () => {
                        local = [];
                        close();
                      }
                    "
                  />

                  <UButton
                    icon="i-lucide-check"
                    label="Aplicar filtros"
                    @click="close"
                    color="secondary"
                    variant="solid"
                  />
                </div>
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

    <PromotionalBanner v-if="novidade" :imovel="novidade" />
    <FeaturedPropertiesCarousel
      v-if="imoveisFiltrados"
      :imoveis="imoveisFiltrados.slice(0, 10)"
    />
    <RegionNavigation @filtrarPorRegiao="navegarParaBusca" />
  </div>
</template>

<script lang="ts" setup>
import { ref } from "vue";
import { GetAllItems } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";

const showDetails = ref(false);
const local = localState();

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());
const { data: novidade } = await useNovidade();

const currentIndex = ref(0);
const currentImage = ref<string | null>(null);
let intervalId: number | undefined;

watchEffect(() => {
  if (!novidade.value) return;
  currentImage.value = novidade.value.imagens?.[0] || null;
  if (!intervalId && novidade.value.imagens?.length > 1) {
    intervalId = window.setInterval(() => {
      if (!novidade.value?.imagens) return;
      currentIndex.value =
        (currentIndex.value + 1) % novidade.value.imagens.length;
      currentImage.value = novidade.value.imagens[currentIndex.value];
    }, 3000);
  }
});

const imoveisFiltrados = computed(() => {
  if (!imoveis.value) return [];

  if (local.value.length === 0) return imoveis.value;

  return imoveis.value.filter((imovel) => local.value.includes(imovel.bairro));
});

function toggleBairro(bairro: string) {
  if (local.value.includes(bairro)) {
    local.value = local.value.filter((b) => b !== bairro);
  } else {
    local.value.push(bairro);
  }
}

const searchTerm = ref("");
const bairrosFiltrados = computed(() =>
  bairros.filter((bairro) =>
    bairro.toLowerCase().includes(searchTerm.value.toLowerCase())
  )
);

const bairros = [
  "Leblon",
  "Ipanema",
  "Copacabana",
  "Lagoa",
  "Jardim Botânico",
  "Gávea",
  "São Conrado",
  "Barra da Tijuca",
  "Joá",
  "Recreio dos Bandeirantes",
  "Urca",
  "Botafogo",
  "Leme",
  "Flamengo",
  "Laranjeiras",
];

const router = useRouter();
const searchQuery = ref("");
const buscarImovel = () => {
  if (!searchQuery.value.trim()) return;
  router.push({ path: "/search", query: { q: searchQuery.value.trim() } });
};
function navegarParaBusca(bairros: string[]) {
  const query: any = {};
  if (bairros.length > 0) {
    query.local = bairros;
  }
  router.push({ path: "/search", query });
}
</script>
