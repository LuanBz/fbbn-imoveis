import axios from "axios";

const API_BASE_URL = useRuntimeConfig().public.apiBaseUrl;

export async function deleteItem(itemId: string) {
    try {
        const response = await axios.delete(`${API_BASE_URL}/admin/imoveis/${itemId}`);
        return response.data;
    } catch (error) {
        console.error("Delete failed:", error);
        throw error;
    }
}