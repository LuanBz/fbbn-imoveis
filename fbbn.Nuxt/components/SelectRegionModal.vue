<script setup lang="ts">
const local = localState();
const searchTerm = ref("");

const regioesFiltradas = computed(() => {
  const termo = searchTerm.value.toLowerCase();
  const resultado: Record<string, string[]> = {};

  for (const [regiao, bairros] of Object.entries(regioesMapeadas)) {
    const filtrados = bairros.filter((bairro) =>
      bairro.toLowerCase().includes(termo)
    );
    if (filtrados.length > 0) {
      resultado[regiao] = filtrados;
    }
  }

  return resultado;
});

function toggleBairro(bairro: string) {
  if (local.value.includes(bairro)) {
    local.value = local.value.filter((b) => b !== bairro);
  } else {
    local.value.push(bairro);
  }
}
function formatLabel(bairros: string[]) {
  if (bairros.length === 0) return "Buscando imóveis em Rio de Janeiro";
  if (bairros.length <= 2) return bairros.join(", ");

  const firstBairro = bairros.slice(0, 2).join(", ");
  const othersBairro = bairros.length - 2;
  return `${firstBairro} e mais ${othersBairro}`;
}
</script>
<template>
  <UModal title="Selecione uma região" description="Escolha uma opção">
    <UButton
      icon="mdi:map-marker"
      :label="formatLabel(local)"
      size="xl"
      class="w-full rounded-2xl md:w-[350px] bg-secondary my-1 truncate"
    />

    <template #body="{ close }">
      <div class="flex flex-col gap-4 mt-4">
        <UInput
          icon="i-lucide-search"
          placeholder="Buscar bairro..."
          v-model="searchTerm"
          variant="outline"
        />
        <div class="flex flex-col gap-4">
          <div
            v-for="(bairros, regiao) in regioesFiltradas"
            :key="regiao"
            class="flex flex-col gap-2"
          >
            <h3 class="text-lg font-semibold text-secondary">
              {{ regiao }}
            </h3>
            <div class="flex flex-wrap gap-2">
              <UBadge
                v-for="bairro in bairros"
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
          </div>
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
</template>
