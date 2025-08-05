<script setup lang="ts">
import { ref, computed } from "vue";
import { GetAllItems } from "~/api/GetAPI";
import type { Filtros } from "~/models/filtros";
import type { Imovel } from "~/models/imovel";
import { parseInterval } from "~/utils/parseIntervals";

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());
const { data: novidade } = await useNovidade();

const imoveisFiltrados = computed(() => {
  if (!imoveis.value) return [];

  let filtrados = imoveis.value;

  if (local.value && local.value.length > 0) {
    filtrados = filtrados.filter((imovel) =>
      local.value.includes(imovel.bairro)
    );
  }

  // Filtro por termo de busca (nome, bairro, cidade, estado)
  if (termoBusca.value.trim().length > 0) {
    const termo = termoBusca.value.toLowerCase();
    filtrados = filtrados.filter((imovel) =>
      [
        imovel.nome,
        imovel.bairro,
        imovel.cidade,
        imovel.estado,
        imovel.metragem,
        imovel.tipo,
      ].some((campo) => campo.toLowerCase().includes(termo))
    );
  }

  // Filtro por tags rápidas
  if (filtros.value.filtrosRapidos?.tagsSelecionadas.length > 0) {
    filtrados = filtrados.filter((imovel) =>
      filtros.value.filtrosRapidos.tagsSelecionadas.some((tag) =>
        imovel.tags.includes(tag)
      )
    );
  }

  filtrados = filtrados.filter((imovel) =>
    aplicarFiltros(imovel, filtros.value)
  );

  if (filtros.value.filtrosRapidos?.ordenacao === "recentes") {
    filtrados.sort(
      (a, b) =>
        new Date(b.dataCadastro).getTime() - new Date(a.dataCadastro).getTime()
    );
  }

  return filtrados.filter((imovel) => aplicarFiltros(imovel, filtros.value));
});
function aplicarFiltros(imovel: Imovel, filtros: Filtros) {
  if (
    filtros.tipo.length > 0 &&
    !filtros.tipo.some((t) =>
      imovel.tipo.toLowerCase().includes(t.toLowerCase())
    )
  )
    return false;

  if (filtros.precoMin !== null && imovel.preco < filtros.precoMin)
    return false;
  if (filtros.precoMax !== null && imovel.preco > filtros.precoMax)
    return false;

  const [minMetragem, maxMetragem] = parseMeters(imovel.metragem);
  const areaMin = filtros.areaMin;
  const areaMax = filtros.areaMax;

  if (
    (areaMin !== null && maxMetragem < areaMin) ||
    (areaMax !== null && minMetragem > areaMax)
  )
    return false;

  if (
    filtros.quartos.length > 0 &&
    !filtros.quartos.some((q) => parseInterval(q, imovel.quartos))
  )
    return false;

  if (
    filtros.banheiros.length > 0 &&
    !filtros.banheiros.some((b) => parseInterval(b, imovel.banheiros))
  )
    return false;

  if (
    filtros.vagas.length > 0 &&
    !filtros.vagas.some((v) => parseInterval(v, imovel.vagasGaragem))
  )
    return false;

  if (
    filtros.sol.length > 0 &&
    !filtros.sol.includes(String(imovel.posicaoSol))
  )
    return false;

  return true;
}

const local = localState();

// Texto de bairros selecionados
const textoFiltro = computed(() => {
  if (!local.value || local.value.length === 0) return "todos os bairros";

  if (local.value.length === 1) return local.value[0];

  return `${local.value[0]} e mais ${local.value.length - 1}`;
});

// Filtros do Slideover
const filtros = ref<
  Filtros & {
    filtrosRapidos: {
      ordenacao: "recentes" | null;
      tagsSelecionadas: string[];
    };
  }
>({
  tipo: [],
  precoMin: null,
  precoMax: null,
  precoM2Min: null,
  precoM2Max: null,
  areaMin: null,
  areaMax: null,
  quartos: [],
  banheiros: [],
  vagas: [],
  sol: [],
  filtrosRapidos: {
    ordenacao: null,
    tagsSelecionadas: [],
  },
});
function atualizarFiltros(novosFiltros: Filtros) {
  filtros.value = { ...novosFiltros };
}

// Filtros de busca
const route = useRoute();
const termoBusca = ref("");
function searchFilter(termo: string) {
  termoBusca.value = termo;
}

// Filtro de busca pela URL
watchEffect(() => {
  const query = route.query.q;
  if (typeof query === "string") {
    termoBusca.value = query;
  }
});
// Filtro de locais pela URL
watchEffect(() => {
  const queryLocal = route.query.local;

  if (Array.isArray(queryLocal)) {
    local.value = queryLocal.filter((b): b is string => typeof b === "string");
  } else if (typeof queryLocal === "string") {
    local.value = [queryLocal];
  } else {
    local.value = [];
  }
});
</script>

<template class="relative">
  <PromotionalBanner v-if="novidade" :imovel="novidade" />
  <div class="sticky p-5 top-0 z-10 bg-tertiary shadow-xl/20 shadow-tertiary">
    <SearchBarFilter @search="searchFilter" />
    <Filters
      v-if="imoveis"
      :imoveis="imoveis"
      :filtros="filtros"
      @update:filtros="atualizarFiltros"
      @reset:filtros="atualizarFiltros"
    />
  </div>

  <h3 class="text-xl font-bold text-gray-800 dark:text-inverted px-8 mt-8">
    Foram encontrado(s) {{ imoveisFiltrados.length }} imóvel(is) em
    {{ textoFiltro }}.
  </h3>
  <div class="px-8 py-3">
    <SelectRegionModal />
  </div>
  <PropertiesCardList :imoveisFiltrados="imoveisFiltrados" />
  <div class="flex justify-center mt-8 space-x-2"></div>
</template>
