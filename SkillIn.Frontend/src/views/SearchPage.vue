<script setup>
import { ref } from 'vue';
import { RouterView, useRouter } from 'vue-router'
import Toolbar from 'primevue/toolbar';
import Button from 'primevue/button';
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

    <!-- Основной блок -->
    <main class="search-container">
      <h1 class="title">Поиск</h1>
      <div class="search-bar">
        <input 
          type="text"
          class="search-input"
          placeholder="Введите текст для поиска" />
        <Button 
          icon="pi pi-search" 
          severity="secondary" 
          aria-label="Искать"
          @click="filter"></Button>
      </div>
      <router-view />
    </main>
  </div>
</template>

<style scoped>
.search-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 100px;
}

.title {
  font-size: 28px;
  margin-bottom: 0px;
  color: black;
}

.search-bar {
  display: flex;
  align-items: center;
  border: 3px solid black;
  border-radius: 50px;
  padding: 10px 20px;
  width: 50%;
  margin-top: 50px;
}

.search-input {
  border: none;
  outline: none;
  flex: 1;
  padding: 5px;
  font-size: 16px;
}
</style>
