<script lang="ts" setup>
import { useRoute } from "vue-router";
import { GetItemById } from "~/api/GetAPI";
import type { Imovel } from "~/models/imovel";
import CTAMobile from "~/components/CTAMobile.vue";

const route = useRoute();
const id = route.params.id as string;

const { data: imovel, pending } = await useAsyncData<Imovel>(() =>
  GetItemById(id)
);
const { data: novidade } = await useNovidade();
</script>

<template>
  <CTAMobile />
  <PromotionalBanner v-if="novidade" :imovel="novidade" />
  <SearchBar />

  <LoadingProperty v-if="pending" />

  <template v-else>
    <PropertiesImageCarousel v-if="imovel?.imagens" :images="imovel?.imagens" />

    <div class="flex gap-2 mt-8 px-11">
      <div v-for="tags in imovel?.tags" :key="tags">
        <UBadge color="tertiary">{{ tags }}</UBadge>
      </div>
    </div>

    <PropertyTitlePrice v-if="imovel" :imovel="imovel" />
    <PropertyMap v-if="imovel" :imovel="imovel" />
    <PropertyDetails v-if="imovel" :imovel="imovel" />
    <PropertyStatus v-if="imovel" :imovel="imovel" />
    <PropertyDescription v-if="imovel" :imovel="imovel" />
  </template>
</template>
