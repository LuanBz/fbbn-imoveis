<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

const props = defineProps<{
  imoveisFiltrados: Imovel[];
}>();

const page = ref(1);
const itemsPerPage = ref(4);
const imoveisPaginados = computed(() => {
  const start = (page.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return props.imoveisFiltrados.slice(start, end);
});
</script>
<template>
  <div v-if="imoveisFiltrados.length > 0" class="flex flex-col gap-4 px-4 mt-8">
    <div
      v-for="imovel in imoveisPaginados"
      :key="imovel.imovelId"
      class="overflow-hidden flex flex-col gap-5 shadow-lg rounded-2xl w-full h-fit bg-accented border-1 border-clean dark:border-primary"
    >
      <NuxtLink :href="`/properties/${imovel.imovelId}`">
        <div class="relative">
          <UCarousel
            v-slot="{ item }"
            :items="imovel.imagens"
            :ui="{
              container: 'm-0 w-full',
              item: 'p-0 w-full',
            }"
            class="w-full"
          >
            <img :src="item" class="w-full h-80 object-cover" />
          </UCarousel>
          <div class="absolute top-4 right-4 flex gap-2 items-end">
            <UBadge
              v-for="tag in imovel.tags"
              :key="tag"
              class="bg-secondary text-white"
            >
              {{ tag }}
            </UBadge>
          </div>
        </div>

        <div class="flex flex-col justify-between px-8 pb-8 gap-2 mt-4">
          <div>
            <div class="flex items-center gap-2 text-muted">
              <UIcon name="mdi-map-marker" />
              <p class="truncate text-md">
                {{ imovel.bairro }}, {{ imovel.cidade }}
              </p>
            </div>

            <p
              class="font-extrabold text-primary dark:text-inverted text-xl uppercase overflow-hidden text-ellipsis w-4/5"
            >
              {{ imovel.nome }}
            </p>
          </div>
          <div>
            <p class="text-3xl text-secondary dark:text-warning-600 font-bold">
              R${{ formatPrice(imovel.preco) }}
            </p>
            <div class="flex flex-row gap-2 mt-2 justify-end">
              <div
                class="grow items-end flex flex-row text-tertiary dark:text-inverted gap-3"
              >
                <div class="flex flex-row gap-1">
                  <p class="text-md font-bold">{{ imovel.quartos }}</p>
                  <UIcon name="mdi:bed" class="size-6" />
                </div>
                <div class="flex flex-row gap-1">
                  <p class="text-md font-bold">
                    {{ imovel.vagasGaragem }}
                  </p>
                  <UIcon name="mdi:car" class="size-6" />
                </div>
                <div class="flex flex-row gap-1">
                  <p class="text-md font-bold">{{ imovel.metragem }}m²</p>
                  <UIcon name="mdi:ruler-square" class="size-6" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </NuxtLink>
    </div>
  </div>
  <div
    v-else
    class="text-center py-10 px-6 m-8 bg-white dark:bg-accented rounded-lg shadow-md"
  >
    <h4 class="text-xl font-semibold">Nenhum imóvel encontrado</h4>
    <p class="mt-2">Tente selecionar outro bairro ou ajustar sua busca.</p>
  </div>
  <UPagination
    v-model:page="page"
    :items-per-page="itemsPerPage"
    :total="imoveisFiltrados.length"
    active-color="secondary"
    variant="outline"
    size="xl"
    class="place-self-center mt-8"
  />
</template>
