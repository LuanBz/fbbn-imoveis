<template>
  <div>
    <h3 class="text-2xl font-bold text-eerie-black mb-4">
      Alguns imóveis em destaque
    </h3>
    <div class="bg-[#142F3F] text-white rounded-2xl w-52 h-52 flex flex-col">
      <NuxtImg
        src="/img/exemploG.jpg"
        alt="Foto da propriedade"
        format="webp"
        class="h-[50%] object-cover rounded-t-2xl"
      />
      <div class="flex flex-col justify-center items-center p-2">
        <p class="text-xl font-bold">R$1.500.000,00</p>
        <p class="text-md font-light">Barra da Tijuca</p>
      </div>
      <UButton
        trailing-icon="i-lucide-arrow-right"
        color="info"
        variant="soft"
        class="w-full grow rounded-t-none justify-center"
        >Ver Mais</UButton
      >
    </div>
  </div>
</template>
