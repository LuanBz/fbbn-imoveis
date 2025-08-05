<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

defineProps<{
  imovel: Imovel;
}>();
</script>

<template>
  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase px-8 mt-8">
    Descrição
  </h2>
  <p class="px-8 mt-4">{{ imovel?.descricao }}</p>
</template>
