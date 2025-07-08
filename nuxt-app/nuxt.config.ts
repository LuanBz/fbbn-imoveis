// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2025-05-15",
  devtools: { enabled: true },
  modules: ["@nuxtjs/color-mode", "@nuxtjs/tailwindcss"],
  runtimeConfig: {
    public: {
      googleMapsApiKey: process.env.NUXT_PUBLIC_Maps_API_KEY,
    },
  },
});
