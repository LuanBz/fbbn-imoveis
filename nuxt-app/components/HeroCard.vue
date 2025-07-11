<script setup lang="ts">
import { UIcon } from "#components";

defineProps({
  item: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <div
    class="relative text-white rounded-3xl h-[400px] flex flex-col overflow-hidden w-full"
  >
    <nuxt-img
      v-if="item.image"
      :src="item.image"
      :alt="item.title"
      class="w-full h-56 object-cover"
      format="webp"
      quality="80"
    />
    <span
      class="bg-orange-500 text-white text-xs font-bold px-4 py-2 rounded-3xl absolute top-4 right-4"
    >
      {{ item.tag }}
    </span>
    <div class="grow grid grid-cols-3 bg-[#142F3F] p-6">
      <div class="col-span-2 gap-3 flex flex-col">
        <div class="flex flex-row items-center gap-1">
          <UIcon name="mdi:map-marker" class="size-5" />
          <p class="text-md truncate">{{ item.subtitle }}</p>
        </div>
        <div class="flex flex-col gap-1">
          <h2 class="text-xl font-bold">{{ item.title }}</h2>
          <h3 class="text-2xl font-normal">{{ item.price }}</h3>
        </div>
      </div>
      <div class="grow items-end flex flex-col gap-3">
        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ item.bedrooms }}</p>
          <UIcon name="mdi:bed" class="size-6" />
        </div>

        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ item.bathrooms }}</p>
          <UIcon name="mdi:shower-head" class="size-6" />
        </div>
        <div class="flex flex-row gap-1">
          <p class="text-md font-bold">{{ item.square }}</p>
          <UIcon name="mdi:ruler-square" class="size-6" />
        </div>
      </div>
      <div class="flex flex-row col-span-3 gap-2 mt-4">
        <UButton color="neutral" variant="soft" class="w-50 justify-center"
          >Agende sua visita</UButton
        >
        <UButton
          trailing-icon="i-lucide-arrow-right"
          color="primary"
          variant="solid"
          class="w-50 justify-center"
          >Ver Mais</UButton
        >
      </div>
    </div>
  </div>
</template>
