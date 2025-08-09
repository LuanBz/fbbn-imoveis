<script setup lang="ts">
import ColorModeButton from "./ColorModeButton.vue";
import MenuSlide from "./MenuSlide.vue";
</script>

<template>
  <header>
    <div
      class="flex justify-between items-center p-4 bg-primary top-0 sticky z-5"
    >
      <div class="gap-3 flex w-full justify-between items-center">
        <div class="flex items-center gap-10">
          <NuxtLink to="/">
            <NuxtImg
              src="/img/logoFBBN.png"
              width="32px"
              height="39px"
              class="cursor-pointer"
            />
          </NuxtLink>
          <div v-if="isDesktop" class="flex gap-6">
            <NuxtLink
              href="https://www.instagram.com/fbbn_lancamentosrj/"
              target="_blank"
              class="hover:scale-102 transition-all flex gap-2"
            >
              <NuxtImg
                alt="Instagram"
                src="/img/instagram.png"
                sizes="25"
                class="invert"
              />
              <p
                v-if="!isXLDesktop"
                class="text-white font-bold hover:text-secondary transition-all"
              >
                Instagram
              </p>
            </NuxtLink>
            <NuxtLink
              href="https://www.instagram.com/ipanema_fbbn/"
              target="_blank"
              class="hover:scale-102 transition-all flex gap-2"
            >
              <NuxtImg
                alt="Instagram"
                src="/img/instagram.png"
                sizes="25"
                class="invert"
              />
              <p
                v-if="!isXLDesktop"
                class="text-white font-bold hover:text-secondary transition-all"
              >
                Instagram IPANEMA
              </p>
            </NuxtLink>
            <NuxtLink
              href="https://www.instagram.com/fbbn_lancamentosrj/"
              target="_blank"
              class="hover:scale-102 transition-all flex gap-2"
            >
              <NuxtImg
                alt="Whatsapp"
                src="/img/whatsapp.png"
                sizes="25"
                class="invert"
              />
              <p
                v-if="!isXLDesktop"
                class="text-white font-bold hover:text-secondary transition-all"
              >
                Whatsapp (21)96545-7088
              </p>
            </NuxtLink>
          </div>
        </div>
        <div class="flex gap-4">
          <NuxtLink
            v-if="isDesktop"
            to="/"
            class="text-white font-bold hover:text-secondary transition-colors p-2"
            >Página inicial</NuxtLink
          >
          <NuxtLink
            v-if="isDesktop"
            to="/map"
            class="text-white font-bold hover:text-secondary transition-colors p-2"
            >Mapa interativo</NuxtLink
          >
          <NuxtLink
            v-if="isDesktop"
            to="/search"
            class="text-white font-bold hover:text-secondary transition-colors p-2"
            >Buscar imóveis</NuxtLink
          >
          <ColorModeButton />
          <MenuSlide v-if="isMobile" />
        </div>
      </div>
    </div>
    <div
      v-if="isDesktop"
      class="bg-secondary w-full h-12 mx-auto flex justify-center gap-10"
    >
      <div
        class="md:w-11/12 lg:w-10/12 xl:w-5/6 2xl:w-4/6 flex justify-between items-center"
      >
        <SearchBar /> <SelectRegionModal />
      </div>
    </div>
  </header>
</template>
