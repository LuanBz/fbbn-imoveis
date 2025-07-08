/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./components/**/*.{js,vue,ts}",
    "./layouts/**/*.vue",
    "./pages/**/*.vue",
    "./plugins/**/*.{js,ts}",
    "./app.vue",
    "./error.vue",
  ],
  theme: {
    extend: {
      colors: {
        "eerie-black": "#1B1B1B",
        gunmetal: "#2E353F",
        "orange-web": "#FCA311",
        seasalt: "#FAFAFA", // Cor de fundo principal
      },
    },
  },
  plugins: [],
};
