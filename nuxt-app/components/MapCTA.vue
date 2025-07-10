<script setup lang="ts">
import { NuxtImg } from "#components";
</script>

<template>
  <div class="flex bg-white rounded-2xl shadow-md overflow-hidden h-full">
    <div
      class="bg-[#c0730F] w-[40%] text-white p-4 flex-shrink-0 flex items-center"
    >
      <p class="font-bold text-md">
        Navegue pelo mapa e encontre seu próximo imóvel!
      </p>
    </div>
    <NuxtImg
      src="/img/exemploM.png"
      alt="Mapa de localização dos imóveis"
      class="w-[60%] h-48 object-cover"
      format="webp"
      quality="80"
    />
  </div>
</template>
