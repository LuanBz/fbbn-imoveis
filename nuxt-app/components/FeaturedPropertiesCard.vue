<script setup lang="ts">
defineProps({
  item: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <div class="bg-[#142F3F] text-white rounded-2xl w-52 h-52 flex flex-col">
    <nuxt-img
      v-if="item.image"
      :src="item.image"
      alt="Foto da propriedade"
      format="webp"
      class="h-[50%] object-cover rounded-t-2xl"
    />
    <div class="flex flex-col justify-center items-center p-2">
      <p class="text-xl font-bold">{{ item.price }}</p>
      <p class="text-md font-light">{{ item.locale }}</p>
    </div>
    <UButton
      trailing-icon="i-lucide-arrow-right"
      color="info"
      variant="soft"
      class="w-full grow rounded-t-none justify-center text-white"
      >Ver Mais</UButton
    >
  </div>
</template>
