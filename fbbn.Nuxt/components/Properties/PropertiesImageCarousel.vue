<script setup lang="ts">
const props = defineProps<{ images: string[] }>();

const carouselRef = ref();
const fullscreenCarouselRef = ref();

const activeIndexMain = ref(0);
const activeIndexModal = ref(0);

const showFullscreen = ref(false);

function onClickPrevMain() {
  activeIndexMain.value--;
}
function onClickNextMain() {
  activeIndexMain.value++;
}
function onSelectMain(index: number) {
  activeIndexMain.value = index;
}
function selectMain(index: number) {
  activeIndexMain.value = index;
  carouselRef.value?.emblaApi?.scrollTo(index);
}

function onClickPrevModal() {
  activeIndexModal.value--;
}
function onClickNextModal() {
  activeIndexModal.value++;
}
function onSelectModal(index: number) {
  activeIndexModal.value = index;
}
function selectModal(index: number) {
  activeIndexModal.value = index;
  fullscreenCarouselRef.value?.emblaApi?.scrollTo(index);
}

function openFullscreen(image: string) {
  const index = props.images.indexOf(image);
  activeIndexModal.value = index;
  showFullscreen.value = true;

  nextTick(() => {
    fullscreenCarouselRef.value?.emblaApi?.scrollTo(index);
  });
}
</script>

<template>
  <div class="flex-1 w-full">
    <UCarousel
      ref="carouselRef"
      v-slot="{ item }"
      arrows
      :items="props.images"
      :prev="{ onClick: onClickPrevMain }"
      :next="{ onClick: onClickNextMain }"
      class="w-full mx-auto"
      @select="onSelectMain"
      as="div"
    >
      <img
        :src="item"
        alt="Imagens do empreendimento"
        class="w-full h-90 object-cover rounded-lg cursor-pointer"
        @click.prevent.stop="openFullscreen(item)"
      />
    </UCarousel>

    <div class="flex gap-3 justify-center pt-4 max-w-xs mx-auto">
      <div
        v-for="(thumb, index) in props.images"
        :key="index"
        class="size-11 opacity-25 hover:opacity-100 transition-opacity"
        :class="{ 'opacity-100': activeIndexMain === index }"
        @click="() => selectMain(index)"
      >
        <img :src="thumb" class="rounded-lg h-10 object-cover" />
      </div>
    </div>
  </div>

  <UModal v-model:open="showFullscreen">
    <template #content>
      <div class="flex justify-end">
        <UButton
          icon="i-lucide-x"
          variant="outline"
          class="text-secondary hover:text-primary"
          @click="showFullscreen = false"
        />
      </div>

      <div class="w-full h-[70vh] flex flex-col justify-center items-center">
        <UCarousel
          ref="fullscreenCarouselRef"
          v-slot="{ item }"
          arrows
          :items="props.images"
          :prev="{ onClick: onClickPrevModal }"
          :next="{ onClick: onClickNextModal }"
          class="w-full mx-auto bg-accented"
          @select="onSelectModal"
        >
          <div class="flex justify-center items-center h-[40vh]">
            <img
              :src="item"
              class="max-w-full max-h-full object-contain touch-pan-y"
              style="touch-action: pinch-zoom; user-select: none"
            />
          </div>
        </UCarousel>

        <div class="flex gap-3 justify-center pt-4 max-w-xs mx-auto">
          <div
            v-for="(thumb, index) in props.images"
            :key="'modal-thumb-' + index"
            class="size-11 opacity-25 hover:opacity-100 transition-opacity"
            :class="{ 'opacity-100': activeIndexModal === index }"
            @click="() => selectModal(index)"
          >
            <img :src="thumb" class="rounded-lg h-10 object-cover" />
          </div>
        </div>
      </div>
    </template>
  </UModal>
</template>
