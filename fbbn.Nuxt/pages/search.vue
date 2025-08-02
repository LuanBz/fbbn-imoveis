<script setup lang="ts">
import { ref, computed } from "vue";
import { GetAllItems } from "~/api/GetAPI";
import type { Filtros } from "~/models/filtros";
import type { Imovel } from "~/models/imovel";
import { parseInterval } from "~/utils/parseIntervals";

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());

const local = localState();

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

  // Aplica os filtros existentes
  filtrados = filtrados.filter((imovel) =>
    aplicarFiltros(imovel, filtros.value)
  );

  // Ordenar por data se necessário
  if (filtros.value.filtrosRapidos?.ordenacao === "recentes") {
    filtrados.sort(
      (a, b) =>
        new Date(b.dataCadastro).getTime() - new Date(a.dataCadastro).getTime()
    );
  }

  return filtrados.filter((imovel) => aplicarFiltros(imovel, filtros.value));
});

function aplicarFiltros(imovel: Imovel, filtros: Filtros) {
  // Filtro por tipo
  if (
    filtros.tipo.length > 0 &&
    !filtros.tipo.some((t) =>
      imovel.tipo.toLowerCase().includes(t.toLowerCase())
    )
  )
    return false;

  // Filtro por preço
  if (filtros.precoMin !== null && imovel.preco < filtros.precoMin)
    return false;
  if (filtros.precoMax !== null && imovel.preco > filtros.precoMax)
    return false;

  // Filtro por metragem (área)
  const [minMetragem, maxMetragem] = parseMeters(imovel.metragem);
  const areaMin = filtros.areaMin;
  const areaMax = filtros.areaMax;

  if (
    (areaMin !== null && maxMetragem < areaMin) ||
    (areaMax !== null && minMetragem > areaMax)
  )
    return false;

  // Filtro por quartos, banheiros, vagas (com "2 a 4", etc)
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

  // Filtro por posição do sol
  if (
    filtros.sol.length > 0 &&
    !filtros.sol.includes(String(imovel.posicaoSol))
  )
    return false;

  return true;
}

const page = ref(1);
const itemsPerPage = ref(4);
const imoveisPaginados = computed(() => {
  const start = (page.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return imoveisFiltrados.value.slice(start, end);
});

const { data: novidade } = await useNovidade();

const textoFiltro = computed(() => {
  if (!local.value || local.value.length === 0) return "todos os bairros";

  if (local.value.length === 1) return local.value[0];

  return `${local.value[0]} e mais ${local.value.length - 1}`;
});

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
const termoBusca = ref("");

const route = useRoute();

watchEffect(() => {
  const query = route.query.q;
  if (typeof query === "string") {
    termoBusca.value = query;
  }
});

const searchTerm = ref("");

function toggleBairro(bairro: string) {
  if (local.value.includes(bairro)) {
    local.value = local.value.filter((b) => b !== bairro);
  } else {
    local.value.push(bairro);
  }
}
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
</script>

<template class="relative">
  <PromotionalBanner v-if="novidade" :imovel="novidade" />
  <div class="sticky p-5 top-0 z-10 bg-tertiary shadow-xl/20 shadow-tertiary">
    <div class="flex justify-between gap-2">
      <UInput
        v-model="termoBusca"
        icon="i-lucide-search"
        :ui="{ leadingIcon: 'text-secondary', base: 'py-4' }"
        size="xl"
        color="secondary"
        class="w-full grow flex"
        variant="outline"
        placeholder="Pesquise um local ou característica do imóvel..."
      />
    </div>
    <Filters
      class="h-full"
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

          <div class="mt-10 flex flex-col gap-5 justify-between items-center">
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
                  <p class="text-md font-bold">{{ imovel.banheiros }}</p>
                  <UIcon name="mdi:shower-head" class="size-6" />
                </div>
                <div class="flex flex-row gap-1">
                  <p class="text-md font-bold">{{ imovel.vagasGaragem }}</p>
                  <UIcon name="mdi:car" class="size-6" />
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

  <div class="flex justify-center mt-8 space-x-2"></div>
</template>
