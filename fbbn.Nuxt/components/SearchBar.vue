<script setup lang="ts">
const router = useRouter();
const searchQuery = ref("");

const buscarImovel = () => {
  if (!searchQuery.value.trim()) return;
  router.push({ path: "/search", query: { q: searchQuery.value.trim() } });
};
</script>
<template>
  <div class="mx-4 my-6 p-2 bg-white dark:bg-primary rounded-full">
    <div class="flex items-center gap-2">
      <UInput
        v-model="searchQuery"
        icon="i-lucide-search"
        size="xl"
        class="w-full"
        variant="ghost"
        placeholder="Pesquise um local ou característica de um imóvel"
        @keydown.enter="buscarImovel"
      />
      <UButton
        @click="buscarImovel"
        class="h-14"
        variant="ghost"
        icon="i-lucide-search"
        :ui="{ label: `dark:text-white` }"
      />
    </div>
  </div>
</template>
