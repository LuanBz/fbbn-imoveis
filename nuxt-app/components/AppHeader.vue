<script setup lang="ts">
import { watch } from "vue";
import ColorModeButton from "./ColorModeButton.vue";
import MenuSlide from "./MenuSlide.vue";
</script>

<template>
  <header
    class="flex justify-between items-center p-4 bg-accented dark:bg-primary relative z-50"
  >
    <div class="gap-3 flex w-full justify-end">
      <ColorModeButton /> <MenuSlide />
    </div>
  </header>
</template>
