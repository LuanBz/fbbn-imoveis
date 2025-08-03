<script setup lang="ts">
definePageMeta({
  layout: "map",
});

import { ref, computed } from "vue";
import { useColorMode } from "#imports";
import { GetAllItems } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";

const center = { lat: -22.9843, lng: -43.2048 };

const { data: imoveis } = await useAsyncData<Imovel[]>(() => GetAllItems());

const activeMarkerId = ref();
function onMarkerClick(id: string) {
  activeMarkerId.value = id;
}

const activeImovel = computed(() => {
  if (!imoveis.value) return null;

  return imoveis.value.find(
    (imovel) => imovel.imovelId === activeMarkerId.value
  );
});

const defaultIcon = computed(() =>
  colorMode.value === "dark"
    ? "/img/inactiveMarkerLight.png"
    : "/img/inactiveMarkerDark.png"
);
const activeIcon = "/img/activeMarker.png";

const colorMode = useColorMode();

const lightMapStyle = [
  {
    featureType: "road",
    elementType: "geometry",
    stylers: [{ lightness: 100 }],
  },
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [{ color: "#a2daf2" }],
  },
  {
    featureType: "landscape",
    elementType: "geometry",
    stylers: [{ color: "#efefef" }],
  },
];
const darkMapStyle = [
  { elementType: "geometry", stylers: [{ color: "#242f3e" }] },
  { elementType: "labels.text.fill", stylers: [{ color: "#746855" }] },
  { elementType: "labels.text.stroke", stylers: [{ color: "#242f3e" }] },
  {
    featureType: "administrative.locality",
    elementType: "labels.text.fill",
    stylers: [{ color: "#d59563" }],
  },
  {
    featureType: "poi",
    elementType: "labels.text.fill",
    stylers: [{ color: "#d59563" }],
  },
  {
    featureType: "poi.park",
    elementType: "geometry",
    stylers: [{ color: "#263c3f" }],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.fill",
    stylers: [{ color: "#6b9a76" }],
  },
  {
    featureType: "road",
    elementType: "geometry",
    stylers: [{ color: "#38414e" }],
  },
  {
    featureType: "road",
    elementType: "geometry.stroke",
    stylers: [{ color: "#212a37" }],
  },
  {
    featureType: "road",
    elementType: "labels.text.fill",
    stylers: [{ color: "#9ca5b3" }],
  },
  {
    featureType: "road.highway",
    elementType: "geometry",
    stylers: [{ color: "#746855" }],
  },
  {
    featureType: "road.highway",
    elementType: "geometry.stroke",
    stylers: [{ color: "#1f2835" }],
  },
  {
    featureType: "road.highway",
    elementType: "labels.text.fill",
    stylers: [{ color: "#f3d19c" }],
  },
  {
    featureType: "transit",
    elementType: "geometry",
    stylers: [{ color: "#2f3948" }],
  },
  {
    featureType: "transit.station",
    elementType: "labels.text.fill",
    stylers: [{ color: "#d59563" }],
  },
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [{ color: "#17263c" }],
  },
  {
    featureType: "water",
    elementType: "labels.text.fill",
    stylers: [{ color: "#515c6d" }],
  },
  {
    featureType: "water",
    elementType: "labels.text.stroke",
    stylers: [{ color: "#17263c" }],
  },
];
const mapStyle = computed(() =>
  colorMode.value === "dark" ? darkMapStyle : lightMapStyle
);
</script>
<template>
  <div class="relative w-full">
    <ClientOnly>
      <GMapMap
        :center="center"
        :zoom="15"
        :options="{
          styles: mapStyle,
          disableDefaultUI: true,
        }"
        class="w-full h-[calc(100vh-92px)]"
      >
        <GMapMarker
          v-for="imovel in imoveis"
          :key="imovel.imovelId"
          :position="{ lat: imovel.latitude, lng: imovel.longitude }"
          :title="imovel.nome"
          :icon="{
            url: activeMarkerId === imovel.imovelId ? activeIcon : defaultIcon,
            scaledSize: { width: 40, height: 40 },
          }"
          @click="onMarkerClick(imovel.imovelId)"
        />
      </GMapMap>
    </ClientOnly>
    <div
      v-if="activeImovel"
      class="absolute bottom-[100px] left-1/2 -translate-x-1/2 w-[95%] max-w-md z-10 flex flex-col"
    >
      <div
        class="h-7 rounded-full bg-gray-800 self-end p-2 m-2 flex flex-row justify-center items-center gap-2"
        @click="activeMarkerId = null"
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
    <div class="absolute bottom-5 left-1/2 -translate-x-1/2 z-10">
      <button
        class="bg-[#c7863d] hover:bg-[#b5752d] text-white font-bold py-3 px-6 rounded-full shadow-lg transition-colors duration-200 whitespace-nowrap"
      >
        VER MAIS IMÓVEIS EM RIO DE JANEIRO
      </button>
    </div>
  </div>
</template>
