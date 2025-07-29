import axios from "axios";
import { API_BASE_URL } from "./AuthAPI";
import type { Imovel } from "~/models/imovel";

export async function createItem(imovel: Imovel) {
    try {
        const response = await axios.post(`${API_BASE_URL}/admin/imoveis`, imovel);
        return response.data;
    } catch (error) {
        console.error("Failed to create item:", error);
        throw error;
    }
}

// CREATE PRIMEIRO E DEPOIS O UPLOAD DE IMAGENS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

export async function uploadImages(itemId: string, images: File[]) {
    try {
        const response = await axios.post(`${API_BASE_URL}/admin/imoveis/${itemId}/imagens`, { itemId, images });
        return response.data;
    } catch (error) {
        console.error("Failed to upload images:", error);
        throw error;
    }
}