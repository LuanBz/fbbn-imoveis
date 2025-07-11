<script setup lang="ts">
defineProps({
  item: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <UButton
    color="info"
    variant="soft"
    class="bg-[#142F3F] text-white rounded-2xl w-52 h-52 p-0 gap-0 flex flex-col"
  >
    <nuxt-img
      v-if="item.image"
      :src="item.image"
      alt="Foto da propriedade"
      format="webp"
      class="w-full h-[60%] object-cover rounded-t-2xl"
    />

    <div
      class="grid grid-flow-col grid-rows-2 p-4 w-full grow items-center gap-x-4"
    >
      <p class="text-xl text-left font-light">{{ item.locale }}</p>
      <p class="text-lg text-left font-bold">{{ item.price }}</p>
      <UIcon name="mdi:arrow-right" class="row-span-2 size-7 place-self-end" />
    </div>
  </UButton>
</template>
