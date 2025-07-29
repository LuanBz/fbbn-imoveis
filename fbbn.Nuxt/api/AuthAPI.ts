import axios from "axios";

export const API_BASE_URL = "https://fbbn.bzra.bzra/api";
export const API_ADMIN_URL = `https://fbbn.bzra.bzra/admin`;

export async function login(password: string) {
    try {
        const response = await axios.post(`${API_ADMIN_URL}/login`, {
            password
        });
        console.log("Login successful:", response.data);
        return response.data;
    } catch (error) {
        console.error("Login failed:", error);
        throw error;
    }
}