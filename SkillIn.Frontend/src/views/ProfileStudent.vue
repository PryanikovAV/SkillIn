<script setup>
import { ref } from 'vue';
import Card from 'primevue/card';
import Avatar from 'primevue/avatar';
import Toolbar from 'primevue/toolbar';
import Button from 'primevue/button';

const studentProfile = ref({
    fullName: "Фамилия Имя Отчество",
    age: 20,
    email: "student@example.com",
    university: "Место учёбы",
    course: "3 курс",
    phone: "+7 999 999 99 99",
    softSkills: ["Командная работа", "Коммуникация", "Креативность"],
    hardSkills: ["JavaScript", "Python", "SQL"],
    workExperience: ["Стажировка в компании X", "Проект в компании Y"],
    projects: ["Проект A", "Проект B"],
    courses: ["Курс по Vue.js", "Курс по PrimeVue"],
});
</script>

<template>
    <div class="page-container">
        <!-- Шапка -->
        <header>
            <div class="layout-topbar">
                <Toolbar>
                    <template #start>
                        <div class="flex align-items-center gap-2">
                            <img src="@/assets/logo.png" alt="Логотип" class="logo" />
                        </div>
                    </template>
                    <template #end>
                        <div class="flex align-items-center gap-3 mr-8">
                            <Button icon="pi pi-home" severity="secondary" aria-label="Главная"></Button>
                            <Button icon="pi pi-envelope" severity="secondary" aria-label="Сообщения"></Button>
                            <Button icon="pi pi-heart" severity="secondary" aria-label="Избранное"></Button>
                            <Button icon="pi pi-user" severity="secondary" aria-label="Профиль"></Button>
                        </div>
                    </template>
                </Toolbar>
            </div>
        </header>

        <!-- Профиль -->
        <main class="profile-container">
            <!-- Карточка профиля -->
            <Card class="mb-3">
                <div class="profile-header flex align-items-center">
                    <Avatar icon="pi pi-user" size="xlarge" shape="circle" class="mr-3" />
                    <div>
                        <h2>{{ studentProfile.fullName }}</h2>
                        <p>{{ studentProfile.age }} лет • {{ studentProfile.email }}</p>
                        <p>Место учёбы: {{ studentProfile.university }}</p>
                        <p>Курс: {{ studentProfile.course }}</p>
                        <p>Телефон: {{ studentProfile.phone }}</p>
                    </div>
                </div>
            </Card>

            <!-- Карточка навыков -->
            <Card class="mb-3">
                <h3>Навыки</h3>
                <p><b>Soft Skills:</b> {{ studentProfile.softSkills.join(", ") }}</p>
                <p><b>Hard Skills:</b> {{ studentProfile.hardSkills.join(", ") }}</p>
            </Card>

            <!-- Карточка опыта работы -->
            <Card class="mb-3">
                <h3>Опыт работы</h3>
                <ul>
                    <li v-for="(experience, index) in studentProfile.workExperience" :key="index">
                        {{ experience }}
                    </li>
                </ul>
            </Card>

            <!-- Карточка проектов -->
            <Card class="mb-3">
                <h3>Проекты и достижения</h3>
                <ul>
                    <li v-for="(project, index) in studentProfile.projects" :key="index">
                        {{ project }}
                    </li>
                </ul>
            </Card>

            <!-- Карточка курсов -->
            <Card>
                <h3>Курсы</h3>
                <ul>
                    <li v-for="(course, index) in studentProfile.courses" :key="index">
                        {{ course }}
                    </li>
                </ul>
            </Card>
        </main>
    </div>
</template>

<style scoped>
.page-container {
    display: flex;
    flex-direction: column;
    height: 100%;
}

.profile-container {
    padding: 20px;
}

.profile-header {
    margin-bottom: 20px;
}

.mb-3 {
    margin-bottom: 20px;
}

.profile-content h3 {
    margin-top: 20px;
}

.logo {
    height: 40px;
}
</style>
