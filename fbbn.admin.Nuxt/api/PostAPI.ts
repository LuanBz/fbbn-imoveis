import axios from "axios";
import type { Imovel } from "~/models/imovel";

const API_BASE_URL = useRuntimeConfig().public.apiBaseUrl;

export async function createItem(imovel: Imovel) {
    try {
        const response = await axios.post(`${API_BASE_URL}/admin/imoveis`, imovel);
        return response.data;
    } catch (error) {
        console.error("Failed to create item:", error);
        throw error;
    }
}

export async function uploadImages(itemId: string, images: File[]) {
    try {
        const response = await axios.post(`${API_BASE_URL}/admin/imoveis/${itemId}/imagens`, { itemId, images });
        return response.data;
    } catch (error) {
        console.error("Failed to upload images:", error);
        throw error;
    }
}