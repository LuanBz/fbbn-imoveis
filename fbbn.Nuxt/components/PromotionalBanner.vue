<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

defineProps({
  imovel: {
    type: Object as () => Imovel,
    required: true,
  },
});
</script>

<template>
  <NuxtLink
    :to="`/properties/${imovel.imovelId}`"
    class="bg-[#142F3F] w-full h-20 flex flex-row"
  >
    <div class="w-2/3 flex flex-col text-center justify-center p-4">
      <h5 class="text-white font-extrabold truncate">
        NOVIDADE EM {{ imovel.bairro.toLocaleUpperCase() }}
      </h5>
      <h2 class="text-[#C0730F] font-extrabold text-2xl truncate">
        {{ imovel.nome.toLocaleUpperCase() }}
      </h2>
    </div>
    <div class="w-1/3 overflow-hidden">
      <nuxt-img
        :src="imovel.imagens?.[0]"
        class="w-full h-full object-cover"
        alt="Imagem do Empreendimento"
      />
    </div>
  </NuxtLink>
</template>
