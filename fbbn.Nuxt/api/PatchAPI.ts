import axios from "axios";
import { API_BASE_URL } from "./AuthAPI";
import type { Imovel } from "~/models/imovel";

export async function patchItem(itemId: string, imovel: Imovel) {
    try {
        const response = await axios.patch(`${API_BASE_URL}/admin/imoveis/${itemId}`, { itemId, imovel });
        return response.data;
    } catch (error) {
        console.error("Patch failed:", error);
        throw error;
    }
}