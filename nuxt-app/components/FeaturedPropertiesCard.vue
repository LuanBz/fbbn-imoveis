<script setup lang="ts">
defineProps({
  item: {
    type: Object,
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
      v-if="item.image"
      :src="item.image"
      alt="Foto da propriedade"
      format="webp"
      class="w-full h-1/3 object-cover"
    />

    <div class="flex flex-col grow p-4 w-full h-2/3 gap-y-4">
      <div class="flex flex-row gap-1 justify-start h-fit">
        <UBadge label="Venda" variant="solid" color="tertiary" class="w-fit" />
        <UBadge
          label="Aluguel"
          variant="solid"
          color="tertiary"
          class="w-fit"
        />
      </div>
      <div>
        <p class="text-2xl text-left font-bold text-white">{{ item.price }}</p>
        <div class="flex flex-row items-center gap-2 text-muted">
          <UIcon name="mdi-map-marker" />
          <p>Barra da Tijuca</p>
        </div>
      </div>
      <NuxtLink to="/properties/{{ item.id }}">
        <UButton
          color="secondary"
          icon="mdi:eye"
          label="Mais detalhes"
          class="rounded-2xl w-full justify-center"
      /></NuxtLink>
    </div>
  </UCard>
</template>
