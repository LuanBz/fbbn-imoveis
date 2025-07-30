import tailwindcss from "@tailwindcss/vite";
export default defineNuxtConfig({
  ssr: false,
  nitro: {
    preset: "static",
  },
  compatibilityDate: "2025-05-15",
  devtools: { enabled: true },
  modules: ["@nuxt/image", "@nuxt/ui"],
  css: ["~/assets/css/main.css"],
  vite: {
    plugins: [tailwindcss()],
    server: {
      proxy: {
        '/api': {
          target: 'https://fbbn.bzra.dev',
          changeOrigin: true,
          rewrite: (path) => path.replace(/^\/api/, '/api')
        },
      },
    },
  },
  ui: {
    theme: {
      colors: [
        "primary",
        "secondary",
        "tertiary",
        "clean",
        "info",
        "success",
        "warning",
        "error",
      ],
    },
  },
  runtimeConfig: {
    public: {
      googleMapsApiKey: process.env.GOOGLE_MAPS_API_KEY,
      apiBaseUrl: '/api',
    },
  },
});
