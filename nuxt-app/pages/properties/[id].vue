<script setup>
import { ref } from "vue";
import StepperDetails from "~/components/Properties/StepperDetails.vue";
const route = useRoute();
const id = route.params.id;

// Simulando a propriedade (você pode substituir por fetch ou useAsyncData)
const property = ref({
  id,
  title: "Almar Ipanema",
  district: "Barra da Tijuca",
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
  <SearchBar />
  <PromotionalBanner />
  <PropertiesImageCarousel />

  <div class="flex flex-row gap-4">
    <div class="flex-col flex gap-4">
      <div>
        <p class="font-bold">{{ property.district }}</p>
        <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">
          {{ property.title }}
        </h2>
      </div>

      <div class="flex flex-col gap-2">
        <div class="flex gap-2">
          <UBadge color="tertiary">Abaixo do mercado</UBadge
          ><UBadge>Oportunidade</UBadge>
        </div>
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
        <h3>
          Preço por m² :
          {{
            property.m2.toLocaleString("pt-BR", { minimumFractionDigits: 2 })
          }}
        </h3>
      </div>
    </div>
  </div>
  <div class="flex flex-col gap-2">
    <UButton
      variant="soft"
      class="justify-center bg-[#C0730F] text-white w-full h-15 rounded-lg"
    >
      Marque uma visita!
    </UButton>
    <UButton
      variant="soft"
      class="justify-center bg-primary text-white w-full h-15 rounded-lg"
    >
      Peça mais informações
    </UButton>
  </div>

  <iframe
    height="250"
    loading="lazy"
    :src="mapSrc"
    style="width: 100%; border: 0"
    allowfullscreen
    referrerpolicy="no-referrer-when-downgrade"
  ></iframe>

  <div class="flex flex-col gap-4">
    <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Status</h2>
    <StepperDetails />
  </div>

  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">
    Ficha Técnica
  </h2>
  <div class="flex flex-col gap-2">
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
        <p class="font-medium text-primary dark:text-[#F0F0F0]">
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

  <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Descrição</h2>
  <p>{{ property.description }}</p>
  <PropertiesMap />
  <div class="flex flex-col gap-2">
    <UButton
      variant="soft"
      class="justify-center bg-[#C0730F] text-white w-full h-15 rounded-lg"
    >
      Marque uma visita!
    </UButton>
    <UButton
      variant="soft"
      class="justify-center bg-primary text-white w-full h-15 rounded-lg"
    >
      Peça mais informações
    </UButton>
  </div>
</template>
