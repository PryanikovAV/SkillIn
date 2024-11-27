import { createRouter, createWebHistory } from "vue-router";
import Login from "./components/Login.vue";
import HomePage from "./components/HomePage.vue";
import Register from "./components/Register.vue";
import SearchPage from "./components/SearchPage.vue";

const routes = [
    { path: "/", component: HomePage },
    { path: "/login", component: Login },
    { path: "/register", component: Register },
    { path: "/search", component: SearchPage },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
