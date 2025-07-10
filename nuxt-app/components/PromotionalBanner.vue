<script setup lang="ts">
</script>
<template>
  <button class="bg-[#142F3F] w-full h-20 flex flex-row">
    <div class="w-2/3 flex flex-col text-center justify-center p-4">
        <h5 class="text-white font-extrabold">NOVIDADE EM IPANEMA</h5>
        <h2 class="text-[#C0730F] font-extrabold text-2xl">ALMA IPANEMA</h2>
    </div>
    <div class="w-1/3 overflow-hidden"> 
      <nuxt-img 
          src="/img/exemploG.jpg" 
          class="w-full h-full object-cover"
          alt="Imagem do Empreendimento"
      />
    </div>
  </button>
</template>