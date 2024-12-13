<script setup>
import { ref } from 'vue'
import { RouterView, useRouter } from 'vue-router'
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'
import Card from 'primevue/card'
import MultiSelect from 'primevue/multiselect'
import VirtualScroller from 'primevue/virtualscroller';


const selectedsoftskills = ref([]);
const softskills = ref([
    { name: 'Коммуникационные навыки'},
    { name: 'Командная работа'},
    { name: 'Эмоциональный интеллект'},
    { name: 'Управление временем'},
    { name: 'Критическое мышление'},
    { name: 'Адаптивность'},
    { name: 'Лидерские качества'},
    { name: 'Творческое мышление'},
    { name: 'Навыки разрешения конфликтов'},
    { name: 'Эмпатия'}
]);

const selectedhardskills = ref([]);
const hardskills = ref([
    { name: 'Программирование (Python, Java, C++, etc.)'},
    { name: 'Веб-разработка (HTML, CSS, JavaScript)'},
    { name: 'Базы данных (SQL, MongoDB)'},
    { name: 'Анализ данных (Excel, R, SQL)'},
    { name: 'Машинное обучение и искусственный интеллект (TensorFlow, Keras)'},
    { name: 'Кибербезопасность'},
    { name: 'Администрирование сетей (TCP/IP, DNS)'},
    { name: 'Разработка мобильных приложений (Android, iOS)'},
    { name: 'Работа с облачными технологиями (AWS, Azure, Google Cloud)'},
    { name: 'UI/UX дизайн'}
]);

const selectedcourses = ref([]);
const courses = ref([
    { name: '1 курс'},
    { name: '2 курс'},
    { name: '3 курс'},
    { name: '4 курс'},
    { name: '5 курс'},
    { name: 'Магистратура'},
    { name: 'Аспирантура'}
]);

const selectedworkexperiences = ref([]);
const workexperiences = ref([
    { name: 'Frontend разработчик'},
    { name: 'Backend разработчик'},
    { name: 'Full-stack разработчик'},
    { name: 'Разработчик мобильных приложений'},
    { name: 'Разработчик игр'},
    { name: 'DevOps инженер'},
    { name: 'UI/UX дизайнер'},
    { name: 'Менеджер проектов'},
    { name: 'Системный администратор'},
    { name: 'Специалист по кибербезопасности'}
]);

const people = ref([
    { name: "Иван Иванов", position: "Разработчик", photo: "https://via.placeholder.com/150" },
    { name: "Ольга Петрова", position: "Дизайнер", photo: "https://via.placeholder.com/150" },
    { name: "Сергей Сидоров", position: "Менеджер", photo: "https://via.placeholder.com/150" },
    { name: "Екатерина Смирнова", position: "Аналитик", photo: "https://via.placeholder.com/150" },
    { name: "Антон Козлов", position: "Тестировщик", photo: "https://via.placeholder.com/150" }
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

      <!-- Контейнер для поиска и фильтров -->
      <div class="content-container">
          <div class="search-container">
              <h1 class="title">Поиск</h1>
              <div class="search-bar">
                  <input
                      type="text"
                      class="search-input"
                      placeholder="Введите текст для поиска" />
                  <Button
                      icon="pi pi-search"
                      severity="secondary"
                      aria-label="Искать"></Button>
              </div>
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
                                <div class="flex flex-column md:align-items-end gap-3">
                                    <div class="flex flex-row-reverse md:flex-row gap-2">
                                        <Button icon="pi pi-heart" outlined></Button>
                                        <Button icon="pi pi-envelope"></Button>
                                        <Button icon="pi pi-user"></Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </template>
                </VirtualScroller>
              </div>
          </div>
          <!-- Карточка с фильтрами -->
          <main class="main-content">
              <Card class="filter-card">
                  <template #title>Фильтры</template>
                  <template #content>
                      <div class="card-content">
                          <MultiSelect v-model="selectedsoftskills" display="chip" :options="softskills" optionLabel="name" placeholder="Soft skills"
                              :maxSelectedLabels="3" class="w-full md:w-24rem" />
                          <MultiSelect v-model="selectedhardskills" display="chip" :options="hardskills" optionLabel="name" placeholder="Hard skills"
                              :maxSelectedLabels="3" class="w-full md:w-24rem" />
                          <MultiSelect v-model="selectedcourses" display="chip" :options="courses" optionLabel="name" placeholder="Курс"
                              :maxSelectedLabels="3" class="w-full md:w-24rem" />
                          <MultiSelect v-model="selectedworkexperiences" display="chip" :options="workexperiences" optionLabel="name" placeholder="Опыт работы"
                              :maxSelectedLabels="3" class="w-full md:w-24rem" />
                          <Button label="Выбрать" class="center-button" />
                      </div>
                  </template>
              </Card>
          </main>
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
  padding-top: 1rem; /* Отступ сверху после шапки */
}

.search-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-left: 7%;
  flex-grow: 1; /* Заставить блок поиска занимать доступное пространство */
}

.title {
  font-size: 1.5rem; /* Размер шрифта заголовка */
  margin-bottom: 0;
  color: black;
}

.search-bar {
  display: flex;
  align-items: center;
  border: 0.1875rem solid black; /* Толщина рамки */
  border-radius: 3.125rem; /* Радиус скругления */
  padding: 0.625rem 1.25rem; /* Внутренние отступы */
  width: 45rem; /* Ширина блока поиска */
  margin-top: 0.625rem; /* Отступ сверху */
}

.search-input {
  border: none;
  outline: none;
  flex: 1;
  padding: 0.3125rem; /* Внутренний отступ */
  font-size: 1rem; /* Размер шрифта */
}

.dataview-container {
    margin-top: 1rem;
    padding: 1rem; /* Внутренние отступы */
    background-color: #fff;
    border-radius: 0.5rem;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    width: 45rem;
    max-height: 450px;
}

.main-content {
  display: flex;
  justify-content: center; /* Центрирование по горизонтали */
  align-items: stretch; /* Выравнивание по верхнему краю */
  flex-grow: 1; /* Заполнение оставшегося пространства */
  margin-top: 3rem; /* Отступ сверху, чтобы избежать наложения на поиск */
}

.filter-card {
  margin-right: 18%;
  width: 30rem; /* Ширина карточки */
}

.card-content {
  display: flex;
  flex-direction: column; /* Вертикальное расположение элементов */
  justify-content: center; /* Центрирование по вертикали */
  align-items: center; /* Центрирование по горизонтали */
  gap: 2rem; /* Отступы между элементами */
  padding: 1rem;
}

.card-content .p-multiselect {
  margin-bottom: 1rem; /* Отступ снизу */
}


</style>