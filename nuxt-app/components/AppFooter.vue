<template>
  <footer
    class="bg-gray-100 dark:bg-slate-900 border-t border-gray-200 dark:border-slate-800 mt-10"
  >
    <div
      class="container mx-auto px-4 py-8 text-center text-gray-600 dark:text-gray-400"
    >
      <nav class="flex justify-center gap-6 mb-6">
        <a href="/" class="text-sm hover:text-gray-900 dark:hover:text-white"
          >Home</a
        >
        <a
          href="/sobre"
          class="text-sm hover:text-gray-900 dark:hover:text-white"
          >Sobre Nós</a
        >
        <a
          href="/contato"
          class="text-sm hover:text-gray-900 dark:hover:text-white"
          >Contato</a
        >
      </nav>

      <div class="text-xs text-gray-500 dark:text-gray-500">
        <p>© {{ currentYear }} Sua Empresa. Todos os direitos reservados.</p>
        <a
          href="/politica-de-privacidade"
          class="underline hover:text-gray-900 dark:hover:text-white"
          >Política de Privacidade</a
        >
      </div>
    </div>
  </footer>
</template>

<script setup>
import { ref } from "vue";

const currentYear = ref(new Date().getFullYear());
</script>
