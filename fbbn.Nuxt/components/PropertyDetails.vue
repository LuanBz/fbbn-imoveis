<script setup lang="ts">
import type { Imovel } from "~/models/imovel";

defineProps<{
  imovel: Imovel;
}>();
</script>
<template>
  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase px-8 mt-8">
    Ficha Técnica
  </h2>
  <div class="flex flex-col gap-2 px-8 mt-4">
    <div class="flex flex-row gap-2">
      <UCard variant="solid" class="bg-[#F0F0F0] dark:bg-primary w-1/3">
        <div class="flex flex-col items-center justify-center gap-2">
          <UIcon
            name="mdi-home"
            class="text-primary dark:text-[#F0F0F0] size-12"
          />
          <p class="font-bold text-primary dark:text-[#F0F0F0]">
            {{ imovel?.tipo }}
          </p>
        </div>
      </UCard>
      <UCard variant="solid" class="bg-[#F0F0F0] dark:bg-primary w-1/3">
        <div class="flex flex-col items-center justify-center gap-2">
          <UIcon
            name="mdi-calendar"
            class="text-primary dark:text-[#F0F0F0] size-12"
          />
          <p class="font-bold text-primary dark:text-[#F0F0F0]">
            {{ imovel?.dataLancamento }}
          </p>
        </div>
      </UCard>
      <UCard variant="solid" class="bg-[#F0F0F0] dark:bg-primary w-1/3">
        <div class="flex flex-col items-center justify-center gap-2">
          <UIcon
            name="mdi:ruler-square"
            class="text-primary dark:text-[#F0F0F0] size-12"
          />
          <p class="font-bold text-primary dark:text-[#F0F0F0]">
            {{ imovel?.metragem }}m²
          </p>
        </div>
      </UCard>
    </div>
    <div
      class="bg-[#F0F0F0] dark:bg-primary p-4 rounded-lg flex gap-y-4 flex-wrap justify-center items-center"
    >
      <div class="flex flex-col justify-center items-center w-1/3">
        <div class="flex items-center gap-1">
          <UIcon name="mdi:bed" class="text-[#c0730f] size-6" />
          <p class="font-medium text-primary dark:text-[#F0F0F0]">Quartos</p>
        </div>
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ imovel?.quartos }}
        </p>
      </div>
      <div class="flex flex-col justify-center items-center w-1/3">
        <div class="flex items-center gap-1">
          <UIcon name="mdi:shower-head" class="text-[#c0730f] size-6" />
          <p class="font-medium text-primary dark:text-[#F0F0F0]">Banheiros</p>
        </div>
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ imovel?.vagasGaragem }}
        </p>
      </div>
      <div class="flex flex-col justify-center items-center w-1/3">
        <div class="flex items-center gap-1">
          <UIcon name="mdi:garage" class="text-[#c0730f] size-6" />
          <p class="font-medium text-primary dark:text-[#F0F0F0]">Vagas</p>
        </div>
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ imovel?.vagasGaragem }}
        </p>
      </div>
    </div>
    <h3 class="font-extrabold text-[#C0730F] text-lg uppercase mt-4">
      Características
    </h3>
    <div class="dark:bg-primary rounded-lg">
      <ul class="list-disc list-inside p-4 gap-2 flex flex-col">
        <li class="font-medium text-primary dark:text-[#F0F0F0]">
          Vista para o mar
        </li>
        <li class="font-medium text-primary dark:text-[#F0F0F0]">
          Área de lazer completa
        </li>
        <li class="font-medium text-primary dark:text-[#F0F0F0]">
          Acabamento de alto padrão
        </li>
        <li class="font-medium text-primary dark:text-[#F0F0F0]">
          Próximo a escolas e comércio
        </li>
        <li class="font-medium text-primary dark:text-[#F0F0F0]">
          Segurança 24h
        </li>
      </ul>
    </div>
  </div>
</template>
