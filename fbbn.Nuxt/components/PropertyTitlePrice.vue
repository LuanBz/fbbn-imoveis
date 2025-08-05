<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

defineProps<{
  imovel: Imovel;
}>();
</script>
<template>
  <div class="flex flex-row gap-4 px-11 mt-4 mb-8">
    <div class="flex-col flex gap-4">
      <div>
        <div class="flex items-center gap-1">
          <UIcon name="mdi:map-marker" class="size-5" />
          <p class="font-bold">{{ imovel?.bairro }}</p>
        </div>

        <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">
          {{ imovel?.nome }}
        </h2>
      </div>
      <USeparator />

      <div class="flex flex-col gap-2">
        <div class="flex items-baseline justify-between p-2">
          <h1 class="font-medium">A partir de</h1>
          <h2
            class="font-extrabold text-primary dark:text-[#F0F0F0] text-3xl uppercase"
          >
            R$
            {{
              imovel?.preco.toLocaleString("pt-BR", {
                minimumFractionDigits: 2,
              })
            }}
          </h2>
        </div>
        <div
          class="flex items-baseline justify-between p-2 gap-1 rounded-lg bg-white dark:bg-primary"
        >
          <h1 class="font-medium dark:text-inverted">Preço por m²</h1>
          <h3 class="font-bold dark:text-inverted">
            ~R${{
              imovel?.precom2.toLocaleString("pt-BR", {
                minimumFractionDigits: 2,
              })
            }}
          </h3>
        </div>
      </div>
    </div>
  </div>
</template>
