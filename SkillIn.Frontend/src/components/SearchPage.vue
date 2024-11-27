<template>
  <div class="search-page">
    <header>
      <router-link to="/search" class="nav-item">
        <img src="@/assets/logo.png" alt="Логотип" class="logo" />
      </router-link>
      <nav class="nav-bar">
        <router-link to="/search" class="nav-item">
          <img src="@/assets/home.png" alt="Главная" class="icon-home"/>
          <span>Главная</span>
        </router-link>
        <router-link to="/messages" class="nav-item">
          <img src="@/assets/message.png" alt="Сообщения" class="icon-messages"/>
          <span>Сообщения</span>
          <span class="notification">+1</span>
        </router-link>
        <router-link to="/favorites" class="nav-item">
          <img src="@/assets/like.png" alt="Избранное" class="icon-favorites"/>
          <span>Избранное</span>
        </router-link>
        <router-link to="/profile" class="nav-item">
          <img src="@/assets/foto_profile.png" alt="Профиль" class="icon-profile"/>
          <span>Профиль</span>
        </router-link>
      </nav>
    </header>

    <main class="search-container">
      <h1 class="title">Поиск</h1>
      <div class="search-bar">
        <input type="text"
               class="search-input"
               placeholder="Введите текст для поиска" />
        <button class="search-button">
          <img src="@/assets/search_icon.png" alt="Поиск" />
        </button>
      </div>
    </main>
  </div>
</template>

<script>
  export default {
    name: "SearchPage",
  };
</script>

<style>
  .search-page {
    position: relative;
    background-color: white;
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
    box-sizing: border-box;
  }

  /* Header */
  header {
    display: flex;
    justify-content: space-between;
    align-items: center; /* Центрирование логотипа по вертикали */
    width: 100%; /* Ширина шапки на всю страницу */
    height: 80px; /* Фиксированная высота шапки */
    padding: 0px 50px; /* Отступы внутри шапки */
    box-sizing: border-box; /* Учитываем padding в общей ширине */
    background-color: white; /* Цвет фона шапки */
    /*border-bottom: 1px solid black; /* Линия снизу шапки */
  }

    header .logo {
      width: auto; /* Поддержка пропорций */
      max-height: 60px; /* Логотип адаптируется по высоте */
      margin-left: 150px; /* Отступ справа от логотипа */
      cursor: pointer;
    }

    header .nav-bar {
      display: flex;
      align-items: flex-start; /* Центрирует иконки и текст */
      justify-content: space-around;
      gap: 20px; /* Расстояние между элементами */
    }

  /* Иконка для "Главная" */
  .icon-home {
    width: 45px;
    height: 45px;
  }

  /* Иконка для "Сообщения" */
  .icon-messages {
    width: 45px;
    height: 35px;
  }

  /* Иконка для "Избранное" */
  .icon-favorites {
    width: 45px;
    height: 45px;
  }

  /* Иконка для "Профиль" */
  .icon-profile {
    width: 70px;
    height: 70px;
  }

  .nav-bar .nav-item {
    display: flex;
    flex-direction: column; /* Размещает текст под иконкой */
    align-items: center; /* Центрирует иконку и текст */
    text-decoration: none;
    color: black;
    font-size: 14px;
    gap: 0; /* Расстояние между иконкой и текстом */
    position: relative;
    outline: none;
  }

  .nav-item:hover {
    text-decoration: underline;
    outline: none;
    box-shadow: none;
  }

  .nav-bar .nav-item img {
    outline: none; /* Убирает подсветку при клике */
  }

    .nav-bar .nav-item img:hover,
    .nav-bar .nav-item img:focus {
      outline: none; /* Убирает фокус */
      box-shadow: none; /* Убирает тень */
      border: none; /* Убирает границу */
    }

  .nav-bar .nav-item span {
    font-size: 12px; /* Размер текста под иконкой */
    text-align: center; /* Центрирует текст */
  }

  .notification {
    position: absolute;
    top: 2px;
    right: 0px;
    background-color: #9de19d;
    color: white;
    border-radius: 50%;
    font-size: 12px;
    padding: 2px 6px;
  }

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

  .search-button {
    border: none;
    background: none;
    cursor: pointer;
  }

    .search-button img {
      width: 20px;
      height: 20px;
    }
</style>

