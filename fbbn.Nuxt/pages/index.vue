<script lang="ts" setup>
import { GetAllItems } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";

const local = localState();

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());
const { data: novidade } = await useNovidade();

const imoveisFiltrados = computed(() => {
  if (!imoveis.value) return [];

  if (local.value.length === 0) return imoveis.value;

  return imoveis.value.filter((imovel) => local.value.includes(imovel.bairro));
});

const router = useRouter();

function navegarParaBusca(bairros: string[]) {
  const query: any = {};
  if (bairros.length > 0) {
    query.local = bairros;
  }
  router.push({ path: "/search", query });
}
</script>
<template>
  <template v-if="isDesktop">
    <div class="flex gap-6 my-10 select-none">
      <HeroCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 5)"
        class="w-2/5"
      />
      <div class="flex w-3/5 flex-col gap-6">
        <PromotionalBanner v-if="novidade" :imovel="novidade" />
        <MapCTA />
      </div>
    </div>
    <div class="flex flex-col gap-6 mt-10 select-none">
      <FeaturedPropertiesCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 20)"
      />
      <PromotionalBanner v-if="novidade" :imovel="novidade" :details="true" />
      <RegionNavigation @filtrarPorRegiao="navegarParaBusca" />
      <FeaturedPropertiesCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 20)"
        title="Imóveis em alta na Zona Sul"
        zona="Zona Sul"
      />
      <FeaturedPropertiesCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 20)"
        title="Imóveis em alta na Zona Norte"
        zona="Zona Norte"
      />
      <FeaturedPropertiesCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 20)"
        title="Imóveis em alta na Zona Oeste"
        zona="Zona Oeste"
      />
    </div>
  </template>
  <template v-if="isMobile">
    <div class="bg-tertiary w-full flex flex-col">
      <NewestProperty v-if="novidade" :imovel="novidade" />
      <div class="min-h-[50dvh] mb-8 bg-tertiary">
        <SearchBar />
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
            <SelectRegionModal />
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
      <PromotionalBanner v-if="novidade" :imovel="novidade" class="mt-10" />
      <FeaturedPropertiesCarousel
        v-if="imoveisFiltrados"
        :imoveis="imoveisFiltrados.slice(0, 10)"
      />
      <RegionNavigation @filtrarPorRegiao="navegarParaBusca" /></div
  ></template>
</template>
