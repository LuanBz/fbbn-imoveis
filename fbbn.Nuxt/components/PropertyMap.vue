<script lang="ts" setup>
import type { Imovel } from "~/models/imovel";

const props = defineProps<{
  imovel: Imovel;
}>();

const mapSrc = computed(() => {
  if (!props.imovel?.endereco) return "";
  const query = encodeURIComponent(props.imovel.endereco);
  return `https://www.google.com/maps/embed/v1/place?key=AIzaSyAj4WoCauiEdeCiihMBHl8rYFLjYmI7CMk&q=${query}`;
});
</script>
<template>
  <iframe
    height="250"
    loading="lazy"
    :src="mapSrc"
    style="width: 100%; border: 0"
    allowfullscreen
    referrerpolicy="no-referrer-when-downgrade"
  ></iframe>
</template>
