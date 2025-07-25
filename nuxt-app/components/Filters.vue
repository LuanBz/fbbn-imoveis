<script setup lang="ts">
const valueArea = ref([1, 20000]);
</script>

<template>
  <div class="flex flex-row gap-3 mt-2">
    <USlideover
      title="Selecione os filtros"
      :close="{
        color: 'primary',
        variant: 'outline',
        class: 'rounded-full',
      }"
    >
      <UButton
        trailing-icon="mdi:filter-multiple"
        label="Filtros"
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
                label="Apartamento"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="Casa"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="Cobertura"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
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
                size="xl"
                label="1"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="2"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="3"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="4"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
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
                size="xl"
                label="1"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="2"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="3"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
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
                size="xl"
                label="1"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
                size="xl"
                label="2"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
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
                size="xl"
                label="Sol da manhã"
                variant="outline"
                class="dark:text-muted"
              />
              <UBadge
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
              color="secondary"
              size="xl"
              block
              class="rounded-full"
            />
          </div>
        </div>
      </template>
    </USlideover>
    <div class="overflow-x-auto flex flex-row gap-2">
      <UButton
        label="Mais recentes"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
      <UButton
        label="Venda"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
      <UButton
        label="Aluguel"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
      <UButton
        label="Apartamento"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
      <UButton
        label="Lançamento"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
      <UButton
        label="Sol da manhã"
        color="neutral"
        variant="soft"
        size="xl"
        class="border-1 border-primary inline-block rounded-full"
      />
    </div>
  </div>
</template>
