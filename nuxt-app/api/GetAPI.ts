import axios from "axios";
import { API_BASE_URL } from "./AuthAPI";

export async function GetAllItems() {
    try {
        const response = await axios.get(`${API_BASE_URL}/imoveis`);
        return response.data;
    } catch (error) {
        console.error("Failed to fetch data:", error);
        throw error;
    }
}

export async function GetItemById(id: string) {
    try {
        const response = await axios.get(`${API_BASE_URL}/imoveis/${id}`);
        return response.data;
    } catch (error) {
        console.error(`Failed to fetch item with ID ${id}:`, error);
        throw error;
    }
}

export async function GetItemByBairro(bairro: string) {
    try {
        const response = await axios.get(`${API_BASE_URL}/imoveis/bairro/${bairro}`);
        return response.data;
    } catch (error) {
        console.error(`Failed to fetch items in category ${bairro}:`, error);
        throw error;
    }
}