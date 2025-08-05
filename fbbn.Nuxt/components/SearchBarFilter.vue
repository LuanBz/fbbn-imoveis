<script setup lang="ts">
const emit = defineEmits(["search"]);

const termoBusca = ref("");
function emitSearch() {
  emit("search", termoBusca.value);
}
</script>
<template>
  <div class="flex justify-between gap-2">
    <UInput
      v-model="termoBusca"
      icon="i-lucide-search"
      :ui="{ leadingIcon: 'text-secondary', base: 'py-4' }"
      size="xl"
      color="secondary"
      class="w-full grow flex"
      variant="outline"
      placeholder="Pesquise um local ou característica do imóvel..."
      ><template v-if="termoBusca?.length" #trailing>
        <UButton
          color="neutral"
          variant="link"
          size="sm"
          icon="i-lucide-circle-x"
          aria-label="Clear input"
          @click="
            () => {
              termoBusca = '';
              emitSearch();
            }
          "
        /> </template
    ></UInput>
    <UButton
      @click="emitSearch"
      variant="solid"
      color="secondary"
      icon="material-symbols:send"
      :ui="{ label: `dark:text-white` }"
    />
  </div>
</template>
