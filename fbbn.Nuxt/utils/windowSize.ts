import { useWindowSize } from "@vueuse/core";

const { width } = useWindowSize();
export const isMobile = computed(() => width.value < 768);
export const isXLDesktop = computed(() => width.value >= 768 && width.value < 1280);
export const isDesktop = computed(() => width.value >= 768);
