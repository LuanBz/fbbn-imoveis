import { API_BASE_URL } from "./AuthAPI";
import axios from "axios";

export async function deleteItem(itemId: string) {
    try {
        const response = await axios.delete(`${API_BASE_URL}/admin/imoveis/${itemId}`);
        return response.data;
    } catch (error) {
        console.error("Delete failed:", error);
        throw error;
    }
}