<script setup>
import { ref } from "vue";
import StepperDetails from "~/components/Properties/StepperDetails.vue";
const route = useRoute();
const id = route.params.id;

// Simulando a propriedade (você pode substituir por fetch ou useAsyncData)
const property = ref({
  id,
  title: "Alma Ipanema Exclusive Studios",
  district: "Ipanema",
  price: 1214111.0,
  m2: 14200,
  location: { lat: -23.55052, lng: -46.633308 },
  features: {
    bedrooms: 2,
    bathrooms: 2,
    area: 85,
    garage: 1,
    rooms: 1,
    suites: 1,
    floor: 5,
  },
  type: "Residencial",
  status: "Em construção",
  delivery: "2024",
  description:
    "Apartamento com vista para o mar, área de lazer completa e acabamento de alto padrão.",
});

const mapSrc = computed(
  () =>
    `https://www.google.com/maps/embed/v1/view?key=AIzaSyAj4WoCauiEdeCiihMBHl8rYFLjYmI7CMk&center=${property.value.location.lat},${property.value.location.lng}&zoom=18&maptype=roadmap`
);
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
    <PromotionalBanner />
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

  <PropertiesImageCarousel class="px-8" />
  <div class="flex gap-2 mt-8 px-11">
    <UBadge color="tertiary">Abaixo do mercado</UBadge
    ><UBadge>Oportunidade</UBadge>
  </div>
  <div class="flex flex-row gap-4 px-11 mt-4 mb-8">
    <div class="flex-col flex gap-4">
      <div>
        <div class="flex items-center gap-1">
          <UIcon name="mdi:map-marker" class="size-5" />
          <p class="font-bold">{{ property.district }}</p>
        </div>

        <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">
          {{ property.title }}
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
              property.price.toLocaleString("pt-BR", {
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
              property.m2.toLocaleString("pt-BR", { minimumFractionDigits: 2 })
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
            {{ property.type }}
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
            {{ property.delivery }}
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
            {{ property.features.area }}m²
          </p>
        </div>
      </UCard>
    </div>
    <div
      class="bg-[#F0F0F0] dark:bg-primary p-4 rounded-lg flex gap-y-4 flex-wrap justify-center items-center"
    >
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:bed-empty" class="size-6 text-[#c0730f]" />
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ property.features.bedrooms }} Quartos
        </p>
      </div>
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:shower-head" class="text-[#c0730f] size-6" />
        <p class="font-medium text-primary truncate dark:text-[#F0F0F0]">
          {{ property.features.bathrooms }} Banheiros
        </p>
      </div>
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:garage" class="text-[#c0730f] size-6" />
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ property.features.garage }} Vagas
        </p>
      </div>
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:bed" class="size-6 text-[#c0730f]" />
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ property.features.suites }} Suítes
        </p>
      </div>
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:tv" class="size-6 text-[#c0730f]" />
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ property.features.rooms }} Sala
        </p>
      </div>
      <div class="flex justify-center gap-2 w-1/3">
        <UIcon name="mdi:office-building" class="size-6 text-[#c0730f]" />
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
          {{ property.features.floor }}º Andar
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
    <StepperDetails />
  </div>

  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase px-8 mt-8">
    Descrição
  </h2>
  <p class="px-8 mt-4">{{ property.description }}</p>
</template>
