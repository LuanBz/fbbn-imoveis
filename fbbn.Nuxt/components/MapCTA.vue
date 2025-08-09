<script setup lang="ts">
import { NuxtImg } from "#components";
</script>

<template>
  <NuxtLink to="/map" class="hover:scale-101 transition-all grow select-none">
    <div class="relative flex rounded-4xl shadow-md overflow-hidden h-full">
      <div
        class="bg-[#c0730f] w-[40%] text-white p-4 flex-shrink-0 flex items-center"
      >
        <p class="font-bold text-md text-white dark:text-inverted md:text-2xl">
          Utilize o mapa interativo para encontrar o imóvel ideal!
        </p>
      </div>
      <NuxtImg
        src="/img/mapCTA.png"
        alt="Mapa de localização dos imóveis"
        class="w-[60%] object-cover"
        format="webp"
        quality="80"
      />
      <UButton
        color="secondary"
        icon="mdi:arrow-right"
        class="w-12 h-12 justify-center rounded-full place-self-end row-span-2 absolute right-5 bottom-5"
      />
    </div>
  </NuxtLink>
</template>
