<script setup lang="ts">
const router = useRouter();
const searchQuery = ref("");

const buscarImovel = () => {
  if (!searchQuery.value.trim()) return;
  router.push({ path: "/search", query: { q: searchQuery.value.trim() } });
};
</script>
<template>
  <div class="bg-white dark:bg-primary rounded-2xl md:my-1 md:w-122">
    <div class="flex items-center">
      <UInput
        v-model="searchQuery"
        icon="i-lucide-search"
        size="xl"
        variant="none"
        class="w-full"
        placeholder="Pesquise um local ou característica de um imóvel"
        @keydown.enter="buscarImovel"
      />
      <UButton
        @click="buscarImovel"
        class="mx-2 rounded-xl"
        icon="i-lucide-arrow-right"
        :ui="{ label: `dark:text-white` }"
      />
    </div>
  </div>
</template>
