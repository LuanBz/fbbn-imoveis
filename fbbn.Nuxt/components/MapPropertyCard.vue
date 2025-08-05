<script setup lang="ts">
import type { Imovel } from "~/models/imovel";
defineProps<{
  activeImovel: Imovel | null;
}>();

const emit = defineEmits<{
  (e: "marker-click", id: string): void;
}>();

function closeMarker() {
  emit("marker-click", "");
}
</script>
<template>
  <div
    v-if="activeImovel"
    class="absolute bottom-[100px] left-1/2 -translate-x-1/2 w-[95%] max-w-md z-10 flex flex-col"
  >
    <div
      class="h-7 rounded-full bg-gray-800 self-end p-2 m-2 flex flex-row justify-center items-center gap-2"
      @click="closeMarker"
    >
      <UIcon name="mdi:close" class="size-5 bg-white" />
    </div>
    <div
      class="bg-white dark:bg-[#141F3F] rounded-2xl shadow-lg flex items-center gap-3 overflow-hidden flex-col"
    >
      <nuxt-img
        :src="activeImovel.imagens[0]"
        alt="Foto do imóvel"
        class="w-full h-[200px] object-cover rounded-t-xl flex-shrink-0"
      />
      <div
        class="px-5 pb-5 flex flex-row overflow-hidden w-full justify-center items-center"
      >
        <div class="flex-grow overflow-hidden">
          <p class="text-xs text-gray-500 dark:text-gray-200 truncate">
            {{ activeImovel.endereco }}
          </p>
          <h3 class="text-xl font-bold text-[#C0730F] truncate">
            {{ activeImovel.nome }}
          </h3>
          <p class="text-xl font-bold text-gray-800 dark:text-gray-200">
            R${{ formatPrice(activeImovel.preco) }}
          </p>
          <div class="flex gap-4 items-center">
            <span
              class="flex items-center gap-1.5 text-sm text-gray-700 dark:text-gray-200"
            >
              <UIcon name="mdi:bed" class="size-6" />
              {{ activeImovel.quartos }}
            </span>
            <span
              class="flex items-center gap-1.5 text-sm text-gray-700 dark:text-gray-200"
            >
              <UIcon name="mdi:ruler-square" class="size-6" />
              {{ activeImovel.metragem }} m²
            </span>
            <span
              class="flex items-center gap-1.5 text-sm text-gray-700 dark:text-gray-200"
            >
              <UIcon name="mdi:garage" class="size-6" />
              {{ activeImovel.vagasGaragem }}
            </span>
          </div>
        </div>
        <NuxtLink
          :to="`/properties/${activeImovel.imovelId}`"
          class="bg-gray-800 hover:bg-gray-900 rounded-full mr-3 w-10 h-10 flex items-center justify-center flex-shrink-0 transition-colors duration-200"
        >
          <svg
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              d="M9 18L15 12L9 6"
              stroke="white"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
            />
          </svg>
        </NuxtLink>
      </div>
    </div>
  </div>
</template>
