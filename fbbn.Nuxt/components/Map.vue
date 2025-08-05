<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

const props = defineProps({
  imoveis: {
    type: Array as () => Imovel[],
    required: true,
  },
});
const emit = defineEmits(["markerClick"]);

const activeMarkerId = ref();
const center = { lat: -22.9843, lng: -43.2048 };

function onMarkerClick(id: string) {
  activeMarkerId.value = id;
  emit("markerClick", id);
}

const colorMode = useColorMode();
const defaultIcon = computed(() =>
  colorMode.value === "dark"
    ? "/img/inactiveMarkerLight.png"
    : "/img/inactiveMarkerDark.png"
);

const activeIcon = "/img/activeMarker.png";

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
</template>
