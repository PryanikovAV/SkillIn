import { createRouter, createWebHistory } from "vue-router";
import Login from "@/views/Login.vue";
import HomePage from "@/views/HomePage.vue";
import Register from "@/views/Register.vue";
import SearchPage from "@/views/SearchPage.vue";
import FilterPage from "@/views/FilterPage.vue";
import LikeStudentPage from "@/views/LikeStudentPage.vue";
import LikeEmployerPage from "@/views/LikeEmployerPage.vue";
import ChatPage from "@/views/ChatPage.vue";
import ProfileStudent from "@/views/ProfileStudent.vue";


const routes = [
    { path: "/", component: HomePage },
    { path: "/login", component: Login },
    { path: "/register", component: Register },
    { path: "/search", component: SearchPage },
    { path: "/filter", component: FilterPage },
    { path: "/likestudent", component: LikeStudentPage },
    { path: "/likeemployer", component: LikeEmployerPage },
    { path: "/chat", component: ChatPage },
    { path: "/profilestudent", component: ProfileStudent }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
