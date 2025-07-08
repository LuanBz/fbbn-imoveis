<template>
  <div
    class="relative bg-gunmetal text-white rounded-3xl p-6 h-64 flex flex-col justify-end bg-cover bg-center"
    style="
      background-image: url('https://via.placeholder.com/600x400.png?text=Apto+2+Quartos');
    "
  >
    <div
      class="absolute top-0 left-0 right-0 bottom-0 bg-black opacity-30 rounded-3xl"
    ></div>
    <div class="relative z-10">
      <span
        class="bg-orange-web text-white text-xs font-bold px-3 py-1 rounded-full"
        >EM ALTA</span
      >
      <h2 class="text-2xl font-bold mt-2">APARTAMENTO 2 QUARTOS</h2>
      <p class="text-sm">na Barra da Tijuca, Rio de Janeiro</p>
    </div>
    <div class="relative z-10 flex justify-center space-x-2 mt-4">
      <button class="w-2.5 h-2.5 bg-white rounded-full"></button>
      <button class="w-2.5 h-2.5 bg-white/50 rounded-full"></button>
      <button class="w-2.5 h-2.5 bg-white/50 rounded-full"></button>
    </div>
  </div>
</template>
