<script setup>
const colorMode = useColorMode();

const isDark = computed({
  get() {
    return colorMode.value === "dark";
  },
  set(_isDark) {
    colorMode.preference = _isDark ? "dark" : "light";
  },
});
</script>

<template>
  <ClientOnly v-if="!colorMode?.forced">
    <UButton
      :icon="isDark ? 'mdi:moon-waxing-crescent' : 'mdi:white-balance-sunny'"
      color="secondary"
      variant="ghost"
      @click="isDark = !isDark"
    />
  </ClientOnly>
</template>
