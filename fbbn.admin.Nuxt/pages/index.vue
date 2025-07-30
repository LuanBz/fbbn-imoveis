<script setup lang="ts">
import * as v from "valibot";
import type { FormSubmitEvent } from "@nuxt/ui";

const schema = v.object({
  password: v.pipe(v.string(), v.minLength(8, "Deve ter 8 ou mais caracteres")),
});

type Schema = v.InferOutput<typeof schema>;

const state = reactive({
  password: "",
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
  <div
    class="bg-[url('/img/fundo.svg')] bg-center h-dvh px-8 flex items-center"
  >
    <div class="bg-white p-8 rounded-2xl w-full">
      <UForm
        :schema="schema"
        :state="state"
        class="space-y-4 items-center flex flex-col"
        @submit="onSubmit"
      >
        <UFormField label="Chave de acesso" name="password" class="w-full">
          <UInput
            v-model="state.password"
            type="password"
            class="w-full h-12"
            :ui="{ base: 'h-full' }"
          />
        </UFormField>

        <UButton
          type="submit"
          class="w-full h-15 mt-4 justify-center"
          label="Entrar"
        />
      </UForm>
    </div>
  </div>
</template>
