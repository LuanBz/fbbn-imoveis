<script lang="ts" setup>
import type { Imovel } from "~/models/imovel";
defineProps<{
  imovel: Imovel;
}>();
</script>
<template>
  <div class="flex flex-col gap-4 px-8 mt-8">
    <h2 class="font-extrabold text-[#C0730F] text-3xl uppercase">Status</h2>
    <StepperDetails
      :current-status="imovel.status"
      :datalancamento="imovel.dataLancamento"
    />
  </div>
</template>
