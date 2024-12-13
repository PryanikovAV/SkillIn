<script setup>
import { ref } from 'vue'
import { RouterView, useRouter } from 'vue-router'
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'
import VirtualScroller from 'primevue/virtualscroller';


const people = ref([
    { name: "Иван Иванов", position: "TechNova Solutions", secondaryPosition: "Вакансия: Разработчик", photo: "https://via.placeholder.com/150" },
    { name: "Ольга Петрова", position: "EcoSphere Dynamics", secondaryPosition: "Вакансия: Дизайнер", photo: "https://via.placeholder.com/150" },
    { name: "Сергей Сидоров", position: "AeroLift Technologies", secondaryPosition: "Вакансия: Менеджер", photo: "https://via.placeholder.com/150" },
    { name: "Екатерина Смирнова", position: "GastroLab Innovations", secondaryPosition: "Вакансия: Аналитик", photo: "https://via.placeholder.com/150" },
    { name: "Антон Козлов", position: "LumiWear", secondaryPosition: "Вакансия: Тестировщик", photo: "https://via.placeholder.com/150" }
]);

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
                          <Button icon="pi pi-home" severity="secondary" aria-label="Главная" @click="logout"></Button>
                          <Button icon="pi pi-envelope" severity="secondary" aria-label="Сообщения" @click="logout"></Button>
                          <Button icon="pi pi-heart" severity="secondary" aria-label="Избранное" @click="logout"></Button>
                          <Button icon="pi pi-user" severity="secondary" aria-label="Профиль" @click="logout"></Button>
                      </div>
                  </template>
              </Toolbar>
          </div>
      </header>

      <!-- Контейнер для скролла людей -->
      <div class="content-container">
          <div class="search-container">
              <h1 class="title">Вас добавили в избранное:</h1>
              <div class="dataview-container">
                <VirtualScroller :items="people" :itemSize="80" class="border-1 surface-border border-round" style="width: 100%; height: 400px">
                    <template #item="{ item }">
                        <div class="flex flex-column sm:flex-row sm:align-items-center p-4 gap-3 border-bottom-1 surface-border">
                            <div class="md:w-10rem relative">
                                <img class="block xl:block mx-auto border-round w-full" :src="item.photo" :alt="item.name" />
                            </div>
                            <div class="flex flex-column md:flex-row justify-content-between md:align-items-center flex-1 gap-4">
                                <div class="flex flex-column gap-2">
                                    <div class="text-lg font-medium text-900">{{ item.name }}</div>
                                    <div class="text-sm text-secondary">{{ item.position }}</div>
                                </div>
                                <div class="flex flex-column gap-2">
                                    <div class="text-md text-primary">{{ item.secondaryPosition }}</div>
                                </div>
                                <div class="flex flex-column md:align-items-end gap-3">
                                    <div class="flex flex-row-reverse md:flex-row gap-2">
                                        <Button icon="pi pi-envelope"></Button>
                                        <Button icon="pi pi-user" label="Посмотреть профиль"></Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </template>
                </VirtualScroller>
              </div>
          </div>
      </div>
  </div>
</template>


<style scoped>
.page-container {
  display: flex;
  flex-direction: column;
  height: 100%;
}

.content-container {
  display: flex;
  justify-content: space-between; /* Размещение элементов по горизонтали */
  align-items: stretch; /* Выровнять по высоте */
  padding-top: 3rem; /* Отступ сверху после шапки */
}

.search-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  flex-grow: 1; /* Заставить блок поиска занимать доступное пространство */
}

.title {
  font-size: 2rem; /* Размер шрифта заголовка */
  margin-bottom: 0;
  color: black;
  text-align: left; /* Убедимся, что текст внутри выравнен по левому краю */
  width: 80%; /* Заголовок займет всю ширину контейнера */
}

.dataview-container {
    margin-top: 1rem;
    padding: 1rem; /* Внутренние отступы */
    background-color: #fff;
    border-radius: 0.5rem;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    width: 80rem;
    max-height: 450px;
}
</style>