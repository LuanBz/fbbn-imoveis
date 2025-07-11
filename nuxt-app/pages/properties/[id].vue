<script setup>
import { ref } from 'vue'
const route = useRoute()
const id = route.params.id

// Simulando a propriedade (você pode substituir por fetch ou useAsyncData)
const property = ref({
  id,
  title: 'Almar Ipanema',
  district: 'Barra da Tijuca',
  price: 1214111.20,
  location: { lat: -23.55052, lng: -46.633308 },
  features: {
    bedrooms: 2,
    bathrooms: 2,
    area: 85,
    garage: 1
  },
  type: 'Residencial',
  status: 'Em construção',
  delivery: '2024',
  description: 'Apartamento com vista para o mar, área de lazer completa e acabamento de alto padrão.'
})

const mapSrc = computed(() =>
  `https://www.google.com/maps/embed/v1/view?key=AIzaSyAj4WoCauiEdeCiihMBHl8rYFLjYmI7CMk&center=${property.value.location.lat},${property.value.location.lng}&zoom=18&maptype=roadmap`
)
</script>

<template>
  <main class="p-4 space-y-8 flex flex-col">
    <SearchBar />
    <PromotionalBanner />
    <PropertiesImageCarousel />

    <div class="flex-col">
      <p class="font-bold">{{ property.district }}</p>
      <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">{{ property.title }}</h2>

      <div class="flex flex-row gap-2 mt-4">
        <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-2 rounded-lg flex justify-center gap-2">
          <UIcon name="mdi:bed" class="size-6" />
          <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0]">{{ property.features.bedrooms }}</p>
        </div>
        <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-2 rounded-lg flex justify-center gap-2">
          <UIcon name="mdi:shower-head" class="size-6" />
          <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0]">{{ property.features.bathrooms }}</p>
        </div>
        <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-2 rounded-lg flex justify-center gap-2">
          <UIcon name="mdi:ruler-square" class="size-6" />
          <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0]">{{ property.features.area }} m²</p>
        </div>
        <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-2 rounded-lg flex justify-center gap-2">
          <UIcon name="mdi:garage" class="size-6" />
          <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0]">{{ property.features.garage }}</p>
        </div>
      </div>

      <h2 class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0] text-3xl uppercase">
        R$ {{ property.price.toLocaleString('pt-BR', { minimumFractionDigits: 2 }) }}
      </h2>
    </div>

    <UButton variant="soft" class="justify-center bg-[#C0730F] text-white w-full h-10 rounded-lg">
      Marque uma visita!
    </UButton>

    <iframe
      height="250"
      loading="lazy"
      :src="mapSrc"
      style="width: 100%; border: 0"
      allowfullscreen
      referrerpolicy="no-referrer-when-downgrade"
    ></iframe>

    <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Ficha Técnica</h2>
    <div class="flex flex-col gap-2">
      <div class="flex flex-row gap-2">
        <p class="font-bold">Tipo:</p>
        <p>{{ property.type }}</p>
      </div>
      <div class="flex flex-row gap-2">
        <p class="font-bold">Status:</p>
        <p>{{ property.status }}</p>
      </div>
      <div class="flex flex-row gap-2">
        <p class="font-bold">Entrega:</p>
        <p>{{ property.delivery }}</p>
      </div>
    </div>

    <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Descrição</h2>
    <p>{{ property.description }}</p>
  </main>

  <PropertiesMap />
</template>
