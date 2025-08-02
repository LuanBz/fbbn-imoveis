<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

const props = defineProps<{
  imoveis: Imovel[];
  filtros: any;
}>();

const emit = defineEmits<{
  (e: "update:filtros", novosFiltros: typeof props.filtros): void;
  (e: "reset:filtros", novosFiltros: typeof props.filtros): void;
}>();

function toggleFiltro(categoria: keyof typeof props.filtros, valor: any) {
  const novoFiltro = { ...props.filtros };

  const lista = [...(novoFiltro[categoria] ?? [])];
  const index = lista.indexOf(valor);
  if (index === -1) lista.push(valor);
  else lista.splice(index, 1);

  novoFiltro[categoria] = lista;
  emit("update:filtros", novoFiltro);
}
function resetFiltros() {
  emit("reset:filtros", {
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
  });
}
function emitirFiltrosComRapidos() {
  emit("update:filtros", {
    ...props.filtros,
    filtrosRapidos: { ...filtrosRapidos.value },
  });
}

const isFiltroAberto = ref(false);

const precoMin = computed({
  get: () => props.filtros.precoMin,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, precoMin: val });
  },
});
const precoMax = computed({
  get: () => props.filtros.precoMax,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, precoMax: val });
  },
});
const precoM2Min = computed({
  get: () => props.filtros.precoM2Min,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, precoM2Min: val });
  },
});
const precoM2Max = computed({
  get: () => props.filtros.precoM2Max,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, precoM2Max: val });
  },
});
const areaMin = computed({
  get: () => props.filtros.areaMin,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, areaMin: val });
  },
});
const areaMax = computed({
  get: () => props.filtros.areaMax,
  set: (val) => {
    emit("update:filtros", { ...props.filtros, areaMax: val });
  },
});

const filtrosRapidos = ref({
  ordenacao: null as "recentes" | null,
  tagsSelecionadas: [] as string[],
});
</script>

<template>
  <div class="flex flex-row gap-3 mt-2">
    <USlideover title="Selecione os filtros" v-model:open="isFiltroAberto">
      <UButton
        trailing-icon="mdi:filter-multiple"
        color="secondary"
        variant="solid"
        size="xl"
      />

      <template #body>
        <div class="flex flex-col gap-6 p-4">
          <div>
            <p class="text-sm font-semibold mb-2">Tipo de imóvel</p>
            <div class="flex flex-wrap gap-2">
              <UBadge
                size="xl"
                :label="'Apartamento'"
                :variant="
                  props.filtros.tipo.includes('Apartamento')
                    ? 'solid'
                    : 'outline'
                "
                class="dark:text-muted cursor-pointer"
                @click="toggleFiltro('tipo', 'Apartamento')"
              />
              <UBadge
                size="xl"
                :label="'Casa'"
                :variant="
                  props.filtros.tipo.includes('Casa') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('tipo', 'Casa')"
              />
              <UBadge
                size="xl"
                :label="'Cobertura'"
                :variant="
                  props.filtros.tipo.includes('Cobertura') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('tipo', 'Cobertura')"
              />
              <UBadge
                size="xl"
                :label="'Studio'"
                :variant="
                  props.filtros.tipo.includes('Studio') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('tipo', 'Studio')"
              />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Faixa de preço (R$)</p>
            <div class="flex items-center gap-4">
              <UInput
                v-model="precoMin"
                type="number"
                placeholder="Mín."
                icon="i-heroicons-currency-dollar"
              />
              <UInput
                v-model="precoMax"
                type="number"
                placeholder="Máx."
                icon="i-heroicons-currency-dollar"
              />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Faixa de preço m² (R$)</p>
            <div class="flex items-center gap-4">
              <UInput
                v-model="precoM2Min"
                type="number"
                placeholder="Mín."
                icon="i-heroicons-currency-dollar"
              />
              <UInput
                v-model="precoM2Max"
                type="number"
                placeholder="Máx."
                icon="i-heroicons-currency-dollar"
              />
            </div>
          </div>
          <div class="">
            <p class="text-sm font-semibold text-gray-600 mb-2">
              Área total (m²)
            </p>
            <div class="flex items-center gap-4">
              <UInput v-model="areaMin" type="number" placeholder="Mín." />
              <UInput v-model="areaMax" type="number" placeholder="Máx." />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Quartos</p>
            <div class="flex gap-2 flex-wrap">
              <UBadge
                size="xl"
                label="1"
                :variant="
                  props.filtros.quartos.includes('1') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('quartos', '1')"
              />
              <UBadge
                size="xl"
                label="2"
                :variant="
                  props.filtros.quartos.includes('2') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('quartos', '2')"
              />
              <UBadge
                size="xl"
                label="3"
                :variant="
                  props.filtros.quartos.includes('3') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('quartos', '3')"
              />
              <UBadge
                size="xl"
                label="4"
                :variant="
                  props.filtros.quartos.includes('4') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('quartos', '4')"
              />
              <UBadge
                size="xl"
                label="5"
                :variant="
                  props.filtros.quartos.includes('5') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('quartos', '5')"
              />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Banheiros</p>
            <div class="flex gap-2 flex-wrap">
              <UBadge
                size="xl"
                label="1"
                :variant="
                  props.filtros.banheiros.includes('1') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('banheiros', '1')"
              />
              <UBadge
                size="xl"
                label="2"
                :variant="
                  props.filtros.banheiros.includes('2') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('banheiros', '2')"
              />
              <UBadge
                size="xl"
                label="3"
                :variant="
                  props.filtros.banheiros.includes('3') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('banheiros', '3')"
              />
              <UBadge
                size="xl"
                label="4"
                :variant="
                  props.filtros.banheiros.includes('4') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('banheiros', '4')"
              />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Vagas</p>
            <div class="flex gap-2 flex-wrap">
              <UBadge
                size="xl"
                label="1"
                :variant="
                  props.filtros.vagas.includes('1') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('vagas', '1')"
              />
              <UBadge
                size="xl"
                label="2"
                :variant="
                  props.filtros.vagas.includes('2') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('vagas', '2')"
              />
              <UBadge
                size="xl"
                label="3"
                :variant="
                  props.filtros.vagas.includes('3') ? 'solid' : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('vagas', '3')"
              />
            </div>
          </div>
          <div>
            <p class="text-sm font-semibold mb-2">Posição do Sol</p>
            <div class="flex gap-2 flex-wrap">
              <UBadge
                size="xl"
                label="Sol da manhã"
                :variant="
                  props.filtros.sol.includes('Sol da manhã')
                    ? 'solid'
                    : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('sol', 'Sol da manhã')"
              />
              <UBadge
                size="xl"
                label="Sol da tarde"
                :variant="
                  props.filtros.sol.includes('Sol da tarde')
                    ? 'solid'
                    : 'outline'
                "
                class="dark:text-muted"
                @click="toggleFiltro('sol', 'Sol da tarde')"
              />
            </div>
          </div>

          <!-- Botão aplicar filtros -->
          <div class="pt-4">
            <UButton
              label="Aplicar filtros"
              color="secondary"
              size="xl"
              block
              class="rounded-full"
              @click="isFiltroAberto = false"
            />
          </div>
          <UButton
            label="Resetar filtros"
            color="primary"
            size="xl"
            variant="outline"
            block
            class="rounded-full mt-2"
            @click="resetFiltros"
          />
        </div>
      </template>
    </USlideover>
    <div class="overflow-x-auto scrollbar-hide flex flex-row gap-2">
      <UButton
        label="Mais recentes"
        :color="
          filtrosRapidos.ordenacao === 'recentes' ? 'secondary' : 'neutral'
        "
        size="xl"
        class="inline-block rounded-xl"
        :variant="filtrosRapidos.ordenacao === 'recentes' ? 'solid' : 'outline'"
        @click="
          () => {
            filtrosRapidos.ordenacao = filtrosRapidos.ordenacao
              ? null
              : 'recentes';
            emitirFiltrosComRapidos();
          }
        "
      />
      <UButton
        v-for="tag in imoveis
          .map((i) => i.tags)
          .flat()
          .filter((t) => t)
          .sort()
          .filter((v, i, a) => a.indexOf(v) === i)"
        :key="tag"
        :label="tag"
        :color="
          filtrosRapidos.tagsSelecionadas.includes(tag)
            ? 'secondary'
            : 'neutral'
        "
        size="xl"
        class="inline-block rounded-xl"
        :variant="
          filtrosRapidos.tagsSelecionadas.includes(tag) ? 'solid' : 'outline'
        "
        @click="
          () => {
            const index = filtrosRapidos.tagsSelecionadas.indexOf(tag);
            if (index === -1) filtrosRapidos.tagsSelecionadas.push(tag);
            else filtrosRapidos.tagsSelecionadas.splice(index, 1);
            emitirFiltrosComRapidos();
          }
        "
      />
    </div>
  </div>
</template>
