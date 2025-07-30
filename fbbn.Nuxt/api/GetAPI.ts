import axios from "axios";
import type { Imovel } from "~/models/imovel";

function getApiUrl(): string {
    return useRuntimeConfig().public.apiBaseUrl;
}

export async function GetAllItems(): Promise<Imovel[]> {
    try {
        const response = await axios.get(`${getApiUrl()}/imoveis`);
        console.log("Imóveis carregados:", response.data)
        return response.data;
    } catch (error) {
        console.error("Erro ao buscar todos os imóveis:", error);
        throw error;
    }
}

export async function GetItemById(id: string): Promise<Imovel> {
    try {
        const response = await axios.get(`${getApiUrl()}/imoveis/${id}`);
        return response.data;
    } catch (error) {
        console.error(`Erro ao buscar imóvel com ID ${id}:`, error);
        throw error;
    }
}

export async function GetItemByBairro(bairro: string): Promise<Imovel[]> {
    try {
        const response = await axios.get(`${getApiUrl()}/imoveis/bairro/${bairro}`);
        return response.data;
    } catch (error) {
        console.error(`Erro ao buscar imóveis no bairro ${bairro}:`, error);
        throw error;
    }
}
