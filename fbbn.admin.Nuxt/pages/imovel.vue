div
<script setup lang="ts">
import * as v from "valibot";
import type { FormSubmitEvent } from "@nuxt/ui";
import { vMaska } from "maska/vue";
import type { MaskInputOptions } from "maska";

const optionsMaska = reactive<MaskInputOptions>({
  number: { fraction: 2, unsigned: true },
});
const addressFilled = ref(false);

const tipoImovel = ref([
  "Empreendimento",
  "Apartamento",
  "Cobertura",
  "Casa",
  "Terreno",
  "Comercial",
]);

const status = ref(["Pré-Lançamento", "Lançamento", "Em obras", "Pronto"]);

type Schema = v.InferOutput<typeof schema>;
const schema = v.object({
  nome: v.pipe(
    v.string(),
    v.minLength(3, "Mínimo 3 caracteres"),
    v.maxLength(25, "Máximo 25 caracteres")
  ),
  descricao: v.pipe(v.string(), v.maxLength(500, "Máximo 1000 caracteres")),
  rua: v.pipe(v.string(), v.maxLength(100, "Máximo 100 caracteres")),
  cep: v.pipe(v.string(), v.regex(/^\d{5}-?\d{3}$/, "CEP inválido")),
  caracteristicas: v.pipe(
    v.array(v.string()),
    v.minLength(1, "Adicione pelo menos uma característica"),
    v.minLength(2, "Característica muito curta"),
    v.maxLength(10, "Máximo de 10 características")
  ),
});

const state = reactive({
  nome: "",
  descricao: "",
  rua: "",
  numero: "",
  bairro: "",
  cidade: "",
  estado: "",
  cep: "",
  status: "",
  tags: [],
  caracteristicas: [],
  tipo: "",
  areaTotal: "",
  areaConstruida: "",
  areaMin: "",
  areaMax: "",
  quartos: "",
  quartosMin: "",
  quartosMax: "",
  suites: "",
  suitesMin: "",
  suitesMax: "",
  banheiros: "",
  banheirosMin: "",
  banheirosMax: "",
  vagas: "",
  vagasMin: "",
  vagasMax: "",
  posicaoSol: "",
  dataLancamento: "",

  preco: "",
  precoM2: "",
});

const toast = useToast();
async function onSubmit(event: FormSubmitEvent<Schema>) {
  toast.add({
    title: "Success",
    description: "The form has been submitted.",
    color: "success",
  });
  console.log(event.data);
}
</script>

<template>
  <div class="p-8 flex flex-col gap-8">
    <h1 class="text-3xl font-bold">Cadastrar novo imóvel</h1>
    <div>
      <UForm
        :schema="schema"
        :state="state"
        @submit="onSubmit"
        class="space-y-4"
      >
        <UFormField label="Nome do imóvel" name="nome" required>
          <UInput
            v-model="state.nome"
            placeholder="Ex: Apartamento na Viera Souto Vista Mar"
            type="string"
            class="w-full h-12"
            :ui="{ base: 'h-full' }"
          />
        </UFormField>
        <div class="gap-2 grid grid-cols-2 gap-y-4">
          <UFormField label="Tipo de imóvel" name="tipo" required>
            <USelect
              v-model="state.tipo"
              :items="tipoImovel"
              placeholder="Selecione o tipo"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField label="Status do imóvel" name="status" required>
            <USelect
              v-model="state.status"
              :items="status"
              placeholder="Selecione o status"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField
            label="Tags"
            name="tags"
            hint="Adicione novas tags"
            help="As tags ajudam a filtrar e destacar alguma característica muito importante do imóvel."
            class="col-span-2"
          >
            <!-- create-item @create="onCreate" -->
            <UInputMenu
              v-model="state.tags"
              multiple
              delete-icon="i-lucide-trash"
              class="h-12 w-full"
              :ui="{
                root: 'h-full',
                tagsItem: 'p-2 gap-2 ',
                tagsItemDeleteIcon: 'text-error',
              }"
            />
          </UFormField>
        </div>

        <!--Espaço para o mapa-->
        <AdressMap
          @update-address="
            (dados) => {
              state.rua = dados.rua;
              state.numero = dados.numero;
              state.bairro = dados.bairro;
              state.cidade = dados.cidade;
              state.estado = dados.estado;
              state.cep = dados.cep;
              addressFilled = true;
            }
          "
        />
        <!--Endereço-->
        <div v-if="addressFilled" class="grid grid-cols-4 gap-2">
          <UFormField class="col-span-2" label="CEP" name="cep" required>
            <UInput
              v-model="state.cep"
              placeholder="Ex: 22772-330"
              type="string"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField class="col-span-2" label="Estado" name="estado" required>
            <UInput
              v-model="state.estado"
              placeholder="Ex: Rio de Janeiro"
              type="string"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField class="col-span-3" label="Rua" name="rua" required>
            <UInput
              v-model="state.rua"
              placeholder="Ex: Lúcio Costa"
              type="string"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField label="Número" name="numero" required>
            <UInput
              v-model="state.numero"
              placeholder="Ex: 9876"
              type="number"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField class="col-span-2" label="Cidade" name="cidade" required>
            <UInput
              v-model="state.cidade"
              placeholder="Ex: Rio de Janeiro"
              type="string"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField class="col-span-2" label="Bairro" name="bairro" required>
            <UInput
              v-model="state.bairro"
              placeholder="Ex: Freguesia"
              type="string"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
          /></UFormField>
        </div>
        <USeparator label="Metragens" />
        <!-- Metragem-->
        <div class="grid grid-cols-2 gap-2">
          <UFormField
            v-if="!['Empreendimento'].includes(state.tipo)"
            label="Área Total"
            name="areaTotal"
            hint="m²"
            class="col-span-2"
            required
          >
            <UInput
              v-model="state.areaTotal"
              icon="mdi:vector-square"
              placeholder="123"
              type="number"
              class="h-12"
              :ui="{ base: 'h-full', root: 'flex flex-row' }"
            />
          </UFormField>
          <UFormField
            v-if="['Casa', 'Terreno', 'Comercial'].includes(state.tipo)"
            label="Área Construída"
            name="areaConstruida"
            hint="m²"
          >
            <UInput
              v-model="state.areaConstruida"
              icon="mdi:vector-square"
              placeholder="123"
              type="number"
              class="h-12"
              :ui="{ base: 'h-full', root: 'flex flex-row' }"
            />
          </UFormField>
          <UFormField
            v-if="['Empreendimento'].includes(state.tipo)"
            label="Área mínima"
            name="areaMin"
            hint="m²"
          >
            <UInput
              v-model="state.areaMin"
              icon="mdi:vector-square"
              placeholder="123"
              type="number"
              class="h-12"
              :ui="{ base: 'h-full', root: 'flex flex-row' }"
            />
          </UFormField>

          <UFormField
            v-if="['Empreendimento'].includes(state.tipo)"
            label="Área máxima"
            name="areaMax"
            hint="m²"
          >
            <UInput
              v-model="state.areaMax"
              icon="mdi:vector-square"
              placeholder="123"
              type="number"
              class="h-12"
              :ui="{ base: 'h-full', root: 'flex flex-row' }"
            />
          </UFormField>
        </div>
        <USeparator label="Valores" />

        <!-- Preço-->
        <div class="flex gap-2">
          <UFormField
            label="Preço"
            name="preco"
            :hint="
              ['Empreendimento'].includes(state.tipo) ? 'A partir de:' : ''
            "
            required
          >
            <UInput
              v-model="state.preco"
              v-maska="optionsMaska"
              icon="mdi:currency-brl"
              placeholder="2.000.000,00"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField
            label="Preço por m²"
            name="precoM2"
            :hint="
              ['Empreendimento'].includes(state.tipo) ? 'A partir de:' : ''
            "
            required
          >
            <UInput
              v-model="state.precoM2"
              v-maska="optionsMaska"
              icon="mdi:currency-brl"
              placeholder="20.000,00"
              class="w-full h-12"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
        </div>
        <USeparator label="Características" />

        <!-- caracteristicas-->
        <div
          v-if="['Empreendimento'].includes(state.tipo)"
          class="grid grid-cols-2 gap-4"
        >
          <!-- Quartos -->
          <UFormField label="Quartos (mín - máx)">
            <div class="flex gap-2">
              <USelect
                v-model="state.quartosMin"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Mín"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
              <USelect
                v-model="state.quartosMax"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Máx"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
            </div>
          </UFormField>

          <!-- Suítes -->
          <UFormField label="Suítes (mín - máx)">
            <div class="flex gap-2">
              <USelect
                v-model="state.suitesMin"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Mín"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
              <USelect
                v-model="state.suitesMax"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Máx"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
            </div>
          </UFormField>

          <!-- Banheiros -->
          <UFormField label="Banheiros (mín - máx)">
            <div class="flex gap-2">
              <USelect
                v-model="state.banheirosMin"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Mín"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
              <USelect
                v-model="state.banheirosMax"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Máx"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
            </div>
          </UFormField>

          <!-- Vagas de garagem -->
          <UFormField label="Vagas (mín - máx)">
            <div class="flex gap-2">
              <USelect
                v-model="state.vagasMin"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Mín"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
              <USelect
                v-model="state.vagasMax"
                :items="[...Array(11).keys()].map((n) => n.toString())"
                placeholder="Máx"
                class="h-12 w-full"
                :ui="{ base: 'h-full' }"
              />
            </div>
          </UFormField>
        </div>

        <div
          v-if="!['Empreendimento'].includes(state.tipo)"
          class="grid grid-cols-2 gap-4"
        >
          <UFormField label="Quartos">
            <USelect
              v-model="state.quartos"
              :items="[...Array(11).keys()].map((n) => n.toString())"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField label="Suítes">
            <USelect
              v-model="state.suites"
              :items="[...Array(11).keys()].map((n) => n.toString())"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField label="Banheiros">
            <USelect
              v-model="state.banheiros"
              :items="[...Array(11).keys()].map((n) => n.toString())"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
          <UFormField label="Vagas">
            <USelect
              v-model="state.vagas"
              :items="[...Array(11).keys()].map((n) => n.toString())"
              class="h-12 w-full"
              :ui="{ base: 'h-full' }"
            />
          </UFormField>
        </div>

        <UFormField
          label="Características"
          name="caracteríticqas"
          hint="Adicione mais características"
          help="Use as características para descrever outros detalhes sobre o imóvel."
          class="col-span-2"
        >
          <UInputMenu
            v-model="state.caracteristicas"
            multiple
            placeholder="Ex: Lazer completo, segurança 24h..."
            delete-icon="i-lucide-trash"
            class="h-12 w-full"
            :ui="{
              root: 'h-full',
              tagsItem: 'p-2 gap-2 ',
              tagsItemDeleteIcon: 'text-error',
            }"
          />
        </UFormField>

        <USeparator label="Adicione uma breve descrição" />

        <UFormField name="descricao" required>
          <UTextarea
            v-model="state.descricao"
            placeholder="O texto deve ter no máximo 1000 caracteres."
            :maxrows="8"
            autoresize
            class="w-full h-50"
            :ui="{ base: 'h-full' }"
          />
        </UFormField>

        <UButton
          type="submit"
          class="h-12 w-full"
          :ui="{ base: 'h-full flex justify-center' }"
        >
          Cadastrar novo imóvel
        </UButton>
      </UForm>
    </div>
  </div>
</template>
