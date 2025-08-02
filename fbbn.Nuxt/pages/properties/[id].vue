<script lang="ts" setup>
import { ref, computed } from "vue";
import { useRoute } from "vue-router";
import { GetItemById } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";
import StepperDetails from "~/components/Properties/StepperDetails.vue";

const route = useRoute();
const id = route.params.id as string;

const { data: imovel } = await useAsyncData<Imovel>(() => GetItemById(id));
const { data: novidade } = await useNovidade();

const mapSrc = computed(() => {
  if (!imovel.value?.endereco) return "";
  const query = encodeURIComponent(imovel.value.endereco);
  return `https://www.google.com/maps/embed/v1/place?key=AIzaSyAj4WoCauiEdeCiihMBHl8rYFLjYmI7CMk&q=${query}`;
});
</script>

<template>
  <div class="static">
    <div class="w-full flex flex-row gap-2 p-2 z-50 fixed bottom-0 bg-tertiary">
      <UButton
        variant="soft"
        class="justify-center bg-primary text-white w-full h-14 rounded-lg"
      >
        Peça mais informações
      </UButton>
      <UButton
        variant="soft"
        class="justify-center bg-[#C0730F] text-white w-full h-14 rounded-lg"
      >
        Marque uma visita!
      </UButton>
    </div>
    <PromotionalBanner v-if="novidade" :imovel="novidade" />
    <div class="p-4">
      <UInput
        icon="i-lucide-search"
        :ui="{ leadingIcon: 'text-secondary', base: 'py-4' }"
        size="xl"
        color="secondary"
        class="w-full grow flex"
        variant="outline"
        placeholder="Pesquise outro imóvel do seu interesse
        "
      />
    </div>
  </div>

  <PropertiesImageCarousel
    class="px-8"
    v-if="imovel?.imagens"
    :images="imovel?.imagens"
  />
  <div class="flex gap-2 mt-8 px-11">
    <div v-for="tags in imovel?.tags">
      <UBadge color="tertiary">{{ tags }}</UBadge>
    </div>
  </div>
  <div class="flex flex-row gap-4 px-11 mt-4 mb-8">
    <div class="flex-col flex gap-4">
      <div>
        <div class="flex items-center gap-1">
          <UIcon name="mdi:map-marker" class="size-5" />
          <p class="font-bold">{{ imovel?.bairro }}</p>
        </div>

        <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">
          {{ imovel?.nome }}
        </h2>
      </div>
      <USeparator />

      <div class="flex flex-col gap-2">
        <div class="flex items-baseline justify-between p-2">
          <h1 class="font-medium">A partir de</h1>
          <h2
            class="font-extrabold text-primary dark:text-[#F0F0F0] text-3xl uppercase"
          >
            R$
            {{
              imovel?.preco.toLocaleString("pt-BR", {
                minimumFractionDigits: 2,
              })
            }}
          </h2>
        </div>
        <div
          class="flex items-baseline justify-between p-2 gap-1 rounded-lg bg-white dark:bg-primary"
        >
          <h1 class="font-medium dark:text-inverted">Preço por m²</h1>
          <h3 class="font-bold dark:text-inverted">
            ~R${{
              imovel?.precom2.toLocaleString("pt-BR", {
                minimumFractionDigits: 2,
              })
            }}
          </h3>
        </div>
      </div>
    </div>
  </div>

  <iframe
    height="250"
    loading="lazy"
    :src="mapSrc"
    style="width: 100%; border: 0"
    allowfullscreen
    referrerpolicy="no-referrer-when-downgrade"
  ></iframe>

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

  <div class="flex flex-col gap-4 px-8 mt-8">
    <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Status</h2>
    <StepperDetails
      v-if="imovel?.status"
      :current-status="imovel.status"
      :datalancamento="imovel.dataLancamento"
    />
  </div>

  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase px-8 mt-8">
    Descrição
  </h2>
  <p class="px-8 mt-4">{{ imovel?.descricao }}</p>
</template>
