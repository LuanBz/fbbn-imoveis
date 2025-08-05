<template>
  <UFormField label="Endereço">
    <div class="">
      <GMapAutocomplete
        placeholder="Buscar endereço..."
        :options="{
          componentRestrictions: { country: 'br' },
          fields: ['address_components', 'geometry'],
        }"
        @place_changed="onPlaceChanged"
        class="w-full border border-accented h-12 px-3 py-2 rounded-md"
      />
      <GMapMap
        :center="pos"
        :zoom="15"
        style="
          width: 100%;
          height: 200px;
          margin-top: 12px;
          border-radius: calc(var(--ui-radius) * 3);
        "
        :options="{
          disableDefaultUI: true,
        }"
      >
        <GMapMarker :position="pos" :draggable="true" @dragend="onDragEnd" />
      </GMapMap>
    </div>
  </UFormField>
</template>

<script setup lang="ts">
/// <reference types="google.maps" />

import { ref } from "vue";

interface Resolved {
  rua: string;
  numero: string;
  bairro: string;
  cidade: string;
  estado: string;
  cep: string;
  latitude: number;
  longitude: number;
}

const addressFilled = ref(false);

const emit = defineEmits<{
  (e: "update-address", data: Resolved): void;
}>();

const pos = ref<google.maps.LatLngLiteral>({
  lat: -22.9843,
  lng: -43.2048,
});
function onPlaceChanged(place: google.maps.places.PlaceResult) {
  if (!place.geometry?.location) return;

  pos.value = {
    lat: place.geometry.location.lat(),
    lng: place.geometry.location.lng(),
  };

  const get = (type: string) =>
    place.address_components?.find((c) => c.types.includes(type))?.long_name ||
    "";

  addressFilled.value = true;

  emit("update-address", {
    rua: get("route"),
    numero: get("street_number"),
    bairro: get("sublocality") || get("political"),
    cidade: get("administrative_area_level_2"),
    estado: get("administrative_area_level_1"),
    cep: get("postal_code"),
    latitude: pos.value.lat,
    longitude: pos.value.lng,
  });
}

function onDragEnd(event: google.maps.MapMouseEvent) {
  const loc = event.latLng;
  if (!loc) return;
  pos.value = { lat: loc.lat(), lng: loc.lng() };

  const geocoder = new google.maps.Geocoder();
  geocoder.geocode({ location: loc }, (results, status) => {
    if (status === "OK" && results && results[0]) {
      const place = results[0];
      const get = (type: string) =>
        place.address_components?.find((c) => c.types.includes(type))
          ?.long_name || "";

      addressFilled.value = true;

      emit("update-address", {
        rua: get("route"),
        numero: get("street_number"),
        bairro: get("sublocality") || get("political"),
        cidade: get("administrative_area_level_2"),
        estado: get("administrative_area_level_1"),
        cep: get("postal_code"),
        latitude: pos.value!.lat,
        longitude: pos.value!.lng,
      });
    }
  });
}
</script>

<style scoped>
/* seu estilo aqui */
</style>
