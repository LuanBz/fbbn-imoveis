<script setup lang="ts">
import { ref, computed } from 'vue';

// --- Estado Reativo ---

// Bairro selecionado para o filtro. O valor inicial pode ser qualquer um.
const bairroSelecionado = ref('Ipanema');

const imoveis = ref([
  {
    id: 1,
    nome: 'ALMAR IPANEMA',
    bairro: 'Ipanema',
    cidade: 'Rio de Janeiro',
    preco: 1120000,
    quartos: 1,
    banheiros: 2,
    vagas: 3,
    imagem: 'https://i.imgur.com/yv9Gv9E.jpeg'
  },
  {
    id: 2,
    nome: 'IPANEMA BEACH RESIDENCE',
    bairro: 'Ipanema',
    cidade: 'Rio de Janeiro',
    preco: 1350000,
    quartos: 2,
    banheiros: 2,
    vagas: 1,
    imagem: 'https://i.imgur.com/yv9Gv9E.jpeg'
  },
  {
    id: 3,
    nome: 'OCEANFRONT BARRA',
    bairro: 'Barra da Tijuca',
    cidade: 'Rio de Janeiro',
    preco: 1800000,
    quartos: 3,
    banheiros: 3,
    vagas: 2,
    imagem: 'https://i.imgur.com/yv9Gv9E.jpeg'
  },
  {
    id: 4,
    nome: 'ATLÂNTICO SUL',
    bairro: 'Barra da Tijuca',
    cidade: 'Rio de Janeiro',
    preco: 980000,
    quartos: 2,
    banheiros: 1,
    vagas: 1,
    imagem: 'https://i.imgur.com/yv9Gv9E.jpeg'
  },
  {
    id: 5,
    nome: 'VISTA MAR IPANEMA',
    bairro: 'Ipanema',
    cidade: 'Rio de Janeiro',
    preco: 2500000,
    quartos: 3,
    banheiros: 4,
    vagas: 3,
    imagem: 'https://i.imgur.com/yv9Gv9E.jpeg'
  }
]);

const imoveisFiltrados = computed(() => {
  if (!bairroSelecionado.value) {
    return imoveis.value;
  }
  return imoveis.value.filter(imovel => imovel.bairro === bairroSelecionado.value);
});

const formatarPreco = (valor: number): string => {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
    minimumFractionDigits: 2,
  }).format(valor);
};
</script>
<template>
    <SearchBar />
    <PromotionalBanner />
        <h3 class="text-2xl font-bold text-gray-800 mb-3">Buscando em {{ bairroSelecionado }}..</h3>
        <div v-if="imoveisFiltrados.length > 0" class="flex flex-col gap-4">
        <div 
          v-for="imovel in imoveisFiltrados" 
          :key="imovel.id" 
          class="overflow-hidden flex flex-row gap-5 shadow-lg rounded-2xl"
        >
          <nuxt-img 
            src="/img/exemploG.jpg" 
            class="w-1/3 h-28 object-cover"
            alt="Imagem do imóvel"
          />
            <div class="flex flex-col p-2 w-2/3">
                <p class="text-gray-600 truncate text-xs">{{ imovel.bairro }}, {{ imovel.cidade }}</p>
                <h4 class="font-extrabold text-[#C0730F] text-lg uppercase truncate">{{ imovel.nome }}</h4>
                <p class="text-lg font-bold">{{ formatarPreco(imovel.preco) }}</p>
                <div class="flex flex-row gap-2 mt-2">
                    <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-1 rounded-lg flex justify-center gap-2">
                        <UIcon name="mdi:ruler-square" class="size-2" />
                        <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0] text-xs">{{ imovel.banheiros }} m²</p>
                    </div>
                    <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-1 rounded-lg flex justify-center gap-2">
                        <UIcon name="mdi:bed" class="size-2" />
                        <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0] text-xs">{{ imovel.quartos }}</p>
                    </div>
                    <div class="bg-[#F0F0F0] dark:bg-[#141F3F] p-1 rounded-lg flex justify-center gap-2">
                        <UIcon name="mdi:garage" class="size-2" />
                        <p class="font-extrabold text-[#141F3F] dark:text-[#F0F0F0] text-xs">{{ imovel.vagas }}</p>
                    </div>
                </div>
            </div>
        </div>
      </div>
       <div v-else class="text-center py-10 px-6 bg-white rounded-lg shadow-md">
        <h4 class="text-xl font-semibold text-gray-700">Nenhum imóvel encontrado</h4>
        <p class="text-gray-500 mt-2">Tente selecionar outro bairro ou ajustar sua busca.</p>
      </div>

      <div class="flex justify-center mt-8 space-x-2">
        
      </div>

</template>