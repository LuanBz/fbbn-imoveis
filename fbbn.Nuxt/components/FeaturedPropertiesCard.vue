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
  <UCard
    :ui="{
      body: 'p-0 sm:p-0',
    }"
    class="w-50 hauto bg-primary"
  >
    <nuxt-img
      v-if="imovel.imagens"
      :src="imovel.imagens[0]"
      alt="Foto da propriedade"
      format="webp"
      class="w-full h-[200px] object-cover rounded-t-xl"
    />

    <div class="flex flex-col grow p-4 w-full h-2/3 gap-y-4">
      <div class="flex flex-row gap-1 justify-start h-fit">
        <UBadge variant="solid" color="tertiary" class="w-fit">{{
          imovel.tags[0]
        }}</UBadge>
      </div>
      <div>
        <p class="text-2xl text-left font-bold text-white">
          R${{ formatPrice(imovel.preco) }}
        </p>
        <div class="flex flex-row items-center gap-2 text-muted">
          <UIcon name="mdi-map-marker" />
          <p>{{ imovel.bairro }}</p>
        </div>
      </div>
      <NuxtLink :to="`/properties/${imovel.imovelId}`" class="w-full">
        <UButton
          color="secondary"
          icon="mdi:eye"
          label="Mais detalhes"
          class="rounded-2xl w-full justify-center"
      /></NuxtLink>
    </div>
  </UCard>
</template>
