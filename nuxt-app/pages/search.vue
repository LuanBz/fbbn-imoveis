<script setup lang="ts">
import { ref, computed } from "vue";

const bairroSelecionado = ref("Ipanema");

const imoveis = ref([
  {
    id: 1,
    nome: "ALMAR IPANEMA RESIDENCE FULL SERVICE",
    bairro: "Ipanema",
    cidade: "Rio de Janeiro",
    preco: 1120000,
    quartos: 1,
    banheiros: 2,
    vagas: 3,
    imagem: "https://i.imgur.com/yv9Gv9E.jpeg",
  },
  {
    id: 2,
    nome: "IPANEMA BEACH RESIDENCE SERVICEBAR",
    bairro: "Ipanema",
    cidade: "Rio de Janeiro",
    preco: 1350000,
    quartos: 2,
    banheiros: 2,
    vagas: 1,
    imagem: "https://i.imgur.com/yv9Gv9E.jpeg",
  },
  {
    id: 3,
    nome: "OCEANFRONT BARRA",
    bairro: "Barra da Tijuca",
    cidade: "Rio de Janeiro",
    preco: 1800000,
    quartos: 3,
    banheiros: 3,
    vagas: 2,
    imagem: "https://i.imgur.com/yv9Gv9E.jpeg",
  },
  {
    id: 4,
    nome: "ATLÂNTICO SUL",
    bairro: "Barra da Tijuca",
    cidade: "Rio de Janeiro",
    preco: 980000,
    quartos: 2,
    banheiros: 1,
    vagas: 1,
    imagem: "https://i.imgur.com/yv9Gv9E.jpeg",
  },
  {
    id: 5,
    nome: "VISTA MAR IPANEMA",
    bairro: "Ipanema",
    cidade: "Rio de Janeiro",
    preco: 2500000,
    quartos: 3,
    banheiros: 4,
    vagas: 3,
    imagem: "https://i.imgur.com/yv9Gv9E.jpeg",
  },
]);

const imoveisFiltrados = computed(() => {
  if (!bairroSelecionado.value) {
    return imoveis.value;
  }
  return imoveis.value.filter(
    (imovel) => imovel.bairro === bairroSelecionado.value
  );
});

const formatarPreco = (valor: number): string => {
  return new Intl.NumberFormat("pt-BR", {
    style: "currency",
    currency: "BRL",
    minimumFractionDigits: 2,
  }).format(valor);
};

const page = ref(1);
const itemsPerPage = ref(2);
const imoveisPaginados = computed(() => {
  const start = (page.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return imoveisFiltrados.value.slice(start, end);
});
</script>
<template>
  <div class="flex w-full flex-col"><SearchBar /> <Filters /></div>
  <h3 class="text-xl font-bold text-gray-800 dark:text-inverted">
    Foram encontrado(s) 3 em {{ bairroSelecionado }}..
  </h3>
  <div v-if="imoveisFiltrados.length > 0" class="flex flex-col gap-4">
    <div
      v-for="imovel in imoveisPaginados"
      :key="imovel.id"
      class="overflow-hidden flex flex-row gap-5 shadow-lg rounded-2xl w-full h-60 bg-primary"
    >
      <nuxt-img
        src="/img/exemploG.jpg"
        class="w-1/3 h-full object-cover"
        alt="Imagem do imóvel"
      />
      <div class="flex flex-col justify-between py-8 w-2/3 gap-2">
        <div>
          <div class="flex items-center gap-2 text-muted">
            <UIcon name="mdi-map-marker" />
            <p class="truncate text-md">
              {{ imovel.bairro }}, {{ imovel.cidade }}
            </p>
          </div>

          <p
            class="font-extrabold text-white text-xl uppercase overflow-hidden text-ellipsis h-14 w-4/5"
          >
            {{ imovel.nome }}
          </p>
        </div>
        <div>
          <p class="text-3xl text-inverted">
            {{ formatarPreco(imovel.preco) }}
          </p>
          <div class="flex flex-row gap-2 mt-2 justify-end">
            <div class="grow items-end flex flex-row text-white gap-3">
              <div class="flex flex-row gap-1">
                <p class="text-md font-bold">{{ imovel.quartos }}</p>
                <UIcon name="mdi:bed" class="size-6" />
              </div>

              <div class="flex flex-row gap-1">
                <p class="text-md font-bold">{{ imovel.banheiros }}</p>
                <UIcon name="mdi:shower-head" class="size-6" />
              </div>
              <div class="flex flex-row gap-1">
                <p class="text-md font-bold">{{ imovel.vagas }}</p>
                <UIcon name="mdi:car" class="size-6" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="text-center py-10 px-6 bg-white rounded-lg shadow-md">
    <h4 class="text-xl font-semibold text-gray-700">
      Nenhum imóvel encontrado
    </h4>
    <p class="text-gray-500 mt-2">
      Tente selecionar outro bairro ou ajustar sua busca.
    </p>
  </div>
  <PromotionalBanner />
  <UPagination
    v-model:page="page"
    :items-per-page="itemsPerPage"
    :total="imoveisFiltrados.length"
    active-color="secondary"
    variant="outline"
    size="xl"
    class="place-self-center"
  />

  <div class="flex justify-center mt-8 space-x-2"></div>
</template>
