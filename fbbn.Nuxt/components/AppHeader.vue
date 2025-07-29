<script setup lang="ts">
import { watch } from "vue";
import ColorModeButton from "./ColorModeButton.vue";
import MenuSlide from "./MenuSlide.vue";
</script>

<template>
  <header
    class="flex justify-between items-center p-4 bg-clean dark:bg-primary top-0 sticky z-5"
  >
    <div class="gap-3 flex w-full justify-between items-center">
      <div><NuxtImg src="/img/logoFBBN.png" width="32px" height="39px" /></div>
      <div class="flex gap-4"><ColorModeButton /> <MenuSlide /></div>
    </div>
  </header>
</template>
