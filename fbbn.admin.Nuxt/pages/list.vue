<script setup lang="ts">
import { ref } from "vue";
import { useToast } from "#imports";

const toast = useToast();

const imoveis = ref([
  {
    id: 1,
    nome: "Apartamento Copacabana",
    cidade: "Rio de Janeiro",
    tipo: "Apartamento",
    preco: "R$ 1.200.000",
    imagem: "https://picsum.photos/640/640?random=1",
  },
  {
    id: 2,
    nome: "Casa em Floripa",
    cidade: "Florianópolis",
    tipo: "Casa",
    preco: "R$ 950.000",
    imagem: "https://picsum.photos/640/640?random=2",
  },
  {
    id: 3,
    nome: "Studio São Paulo",
    cidade: "São Paulo",
    tipo: "Studio",
    preco: "R$ 620.000",
    imagem: "https://picsum.photos/640/640?random=3",
  },
]);
const page = ref(1);
const search = ref("");
const deletar = (id: number) => {
  if (confirm("Tem certeza que deseja excluir este imóvel?")) {
    imoveis.value = imoveis.value.filter((i) => i.id !== id);
    toast.add({ title: "Imóvel excluído com sucesso", color: "neutral" });
  }
};
</script>

<template>
  <div class="p-4 space-y-6">
    <!-- Header -->
    <div class="flex flex-col justify-between">
      <h1 class="text-3xl font-bold mb-4">Seus imóveis</h1>
      <div class="flex w-full gap-2">
        <UButton color="primary" icon="i-heroicons-plus" class="w-full h-12">
          Adicionar Imóvel
        </UButton>
        <USlideover
          title="Selecione os filtros"
          :close="{
            color: 'neutral',
            variant: 'ghost',
            class: 'rounded-full',
          }"
        >
          <UButton color="neutral" icon="i-heroicons-funnel" class="h-12">
            Filtros
          </UButton>
          <template #body>
            <div class="flex flex-col gap-6 p-4">
              <div>
                <p class="text-sm font-semibold mb-2">Tipo de imóvel</p>
                <div class="flex flex-wrap gap-2">
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Apartamento"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Casa"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Cobertura"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Studio"
                    variant="outline"
                    class="dark:text-muted"
                  />
                </div>
              </div>
              <div>
                <p class="text-sm font-semibold mb-2">Faixa de preço (R$)</p>
                <div class="flex items-center gap-4">
                  <UInput
                    type="number"
                    placeholder="Mín."
                    icon="i-heroicons-currency-dollar"
                  />
                  <UInput
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
                    type="number"
                    placeholder="Mín."
                    icon="i-heroicons-currency-dollar"
                  />
                  <UInput
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
                  <UInput type="number" placeholder="Mín." />
                  <UInput type="number" placeholder="Máx." />
                </div>
              </div>
              <div>
                <p class="text-sm font-semibold mb-2">Quartos</p>
                <div class="flex gap-2 flex-wrap">
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="1"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="2"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="3"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="4"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="5+"
                    variant="outline"
                    class="dark:text-muted"
                  />
                </div>
              </div>
              <div>
                <p class="text-sm font-semibold mb-2">Banheiros</p>
                <div class="flex gap-2 flex-wrap">
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="1"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="2"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="3"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="4+"
                    variant="outline"
                    class="dark:text-muted"
                  />
                </div>
              </div>
              <div>
                <p class="text-sm font-semibold mb-2">Vagas</p>
                <div class="flex gap-2 flex-wrap">
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="1"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="2"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="3+"
                    variant="outline"
                    class="dark:text-muted"
                  />
                </div>
              </div>
              <div>
                <p class="text-sm font-semibold mb-2">Posição do Sol</p>
                <div class="flex gap-2 flex-wrap">
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Sol da manhã"
                    variant="outline"
                    class="dark:text-muted"
                  />
                  <UBadge
                    color="neutral"
                    size="xl"
                    label="Sol da tarde"
                    variant="outline"
                    class="dark:text-muted"
                  />
                </div>
              </div>

              <!-- Botão aplicar filtros -->
              <div class="pt-4">
                <UButton
                  label="Aplicar filtros"
                  color="primary"
                  size="xl"
                  block
                  class="rounded-full"
                />
              </div>
            </div>
          </template>
        </USlideover>
      </div>
      <!-- Pesquisa -->
      <UInput
        v-model="search"
        placeholder="Buscar por nome ou cidade..."
        icon="i-heroicons-magnifying-glass"
        class="w-full h-12 mt-2"
        :ui="{ base: 'h-full' }"
      />
    </div>

    <!-- Cards -->
    <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
      <UCard
        v-for="imovel in imoveis.filter(
          (i) =>
            i.nome.toLowerCase().includes(search.toLowerCase()) ||
            i.cidade.toLowerCase().includes(search.toLowerCase())
        )"
        :key="imovel.id"
        class="flex flex-col"
        :ui="{ body: 'p-0' }"
      >
        <div class="flex-row flex items-center gap-4 relative">
          <!-- Imagem -->
          <img
            :src="imovel.imagem"
            alt="Foto do imóvel"
            class="w-full h-24 object-cover rounded-md"
          />
          <!-- Botões de ação -->
          <div class="absolute top-2 right-4 mt-2 flex gap-2">
            <UButton
              size="sm"
              color="neutral"
              icon="mdi:fountain-pen-tip"
              variant="outline"
            />

            <UButton
              size="sm"
              color="error"
              icon="mdi:trash-can"
              variant="solid"
              @click="deletar(imovel.id)"
            />
          </div>
        </div>

        <h2 class="w-full mt-4 px-4 text-xl font-semibold truncate">
          {{ imovel.nome }}
        </h2>

        <!-- Infos finais -->
        <div
          class="text-sm text-gray-500 flex justify-between flex-wrap gap-1 p-4"
        >
          <!-- Nome -->

          <span><strong>Cidade:</strong> {{ imovel.cidade }}</span>
          <span><strong>Tipo:</strong> {{ imovel.tipo }}</span>
          <span><strong>Preço:</strong> {{ imovel.preco }}</span>
        </div>
      </UCard>
    </div>

    <!-- Pagination-->
    <UPagination
      v-model:page="page"
      active-color="secondary"
      variant="outline"
      size="xl"
      class="place-self-center mt-8"
    />
  </div>
</template>
