import axios from "axios";
import type { Imovel } from "~/models/imovel";

const API_BASE_URL = useRuntimeConfig().public.apiBaseUrl;

export async function patchItem(itemId: string, imovel: Imovel) {
    try {
        const response = await axios.patch(`${API_BASE_URL}/admin/imoveis/${itemId}`, { itemId, imovel });
        return response.data;
    } catch (error) {
        console.error("Patch failed:", error);
        throw error;
    }
}