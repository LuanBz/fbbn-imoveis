<script setup>
const route = useRoute()
const id = route.params.id

</script>

<template>
    <AppHeader />
    <main class="p-4 space-y-8 flex flex-col">
      <SearchBar/>
      <PromotionalBanner />
      <PropertiesImageCarousel/>
      <div class="flex-col">
        <p class="font-bold">Barra da Tijuca</p>
        <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Almar Ipanema</h2>
        <div class="flex flex-row gap-2 mt-4">
            <div class="bg-[#F0F0F0] p-2 rounded-lg flex justify-center gap-2"><UIcon name="mdi:bed" class="size-6" /><p class="font-extrabold text-[#141F3F]">0</p></div>
            <div class="bg-[#F0F0F0] p-2 rounded-lg flex justify-center gap-2"><UIcon name="mdi:shower-head" class="size-6" /><p class="font-extrabold text-[#141F3F]">0</p></div>
            <div class="bg-[#F0F0F0] p-2 rounded-lg flex justify-center gap-2"><UIcon name="mdi:ruler-square" class="size-6" /><p class="font-extrabold text-[#141F3F]">0</p></div>
            <div class="bg-[#F0F0F0] p-2 rounded-lg flex justify-center gap-2"><UIcon name="mdi:garage" class="size-6" /><p class="font-extrabold text-[#141F3F]">0</p></div>
        </div>
        <h2 class="font-extrabold text-[#141F3F] text-3xl uppercase">R$1.214.111,20</h2>
      </div>
      <UButton
        variant="soft"
        class="justify-center bg-[#C0730F] text-white w-full h-10 rounded-lg">Marque uma visita!</UButton>
    </main>
    <PropertiesMap />
</template>
