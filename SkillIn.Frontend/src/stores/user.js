import { defineStore } from "pinia";
import axios from "axios";

export const useUserStore = defineStore("user", {
    state: () => ({
        user: null, // Данные о текущем пользователе
    }),
    actions: {
        async registerUser(login, email, password) {
            const response = await axios.post("http://localhost:5010/register", {
                login,
                email,
                password,
            });
            return response.data;
        },
    },
});
