import axios from "axios";

const API_ADMIN_URL = useRuntimeConfig().public.apiBaseUrl;

export async function login(password: string) {
  try {
    const response = await axios.post(`${API_ADMIN_URL}/login`, {
      password,
    });
    console.log("Login successful:", response.data);
    return response.data;
  } catch (error) {
    console.error("Login failed:", error);
    throw error;
  }
}
