<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

defineProps({
  imovel: {
    type: Object as () => Imovel,
    required: true,
  },
  details: {
    type: Boolean,
    default: false,
  },
});
</script>

<template>
  <NuxtLink
    :to="`/properties/${imovel.imovelId}`"
    class="bg-[#142F3F] w-full h-20 flex flex-row md:rounded-4xl md:h-30 hover:scale-101 transition-all"
  >
    <div class="w-2/3 flex text-center justify-between p-4 items-center">
      <div class="flex flex-col gap-1 w-full">
        <h5 class="text-white font-extrabold truncate">
          NOVIDADE EM {{ imovel.bairro.toLocaleUpperCase() }}
        </h5>
        <h2 class="text-[#C0730F] font-extrabold text-2xl truncate">
          {{ imovel.nome.toLocaleUpperCase() }}
        </h2>
      </div>
      <div
        v-if="details"
        class="w-1/2 justify-end flex flex-col items-end px-20"
      >
        <h5 class="text-white font-extrabold flex items-center gap-2">
          {{ imovel.metragem }}m²
          <UIcon name="mdi:ruler-square" size="25" />
        </h5>
        <p class="text-white font-extrabold text-xl flex items-center gap-2">
          ~R${{ formatPrice(imovel.precom2) }}/m²
          <UIcon name="mdi:cash" size="25" />
        </p>
      </div>
    </div>

    <div class="w-1/3 overflow-hidden">
      <nuxt-img
        :src="imovel.imagens?.[0]"
        class="w-full h-full object-cover md:rounded-r-4xl"
        alt="Imagem do Empreendimento"
      />
    </div>
  </NuxtLink>
</template>
