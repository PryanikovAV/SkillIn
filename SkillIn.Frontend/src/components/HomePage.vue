<template>
  <div class="main-container">
    <header>
      <img src="@/assets/logo.png" alt="Логотип" class="logo" />
    </header>
    <div class="main-content">
      <div class="image-placeholder"></div>
      <div class="auth-box">
        <h2>Присоединяйтесь к нам!</h2>
        <button class="login" @click="login">Войти</button>
        <button class="register" @click="register">Зарегистрироваться</button>
      </div>
      <router-view />
    </div>
  </div>
</template>

<script>
  export default {
    name: "HomePage",
    methods: {
      login() {
        this.$router.push("/login");
      },
      register() {
        this.$router.push("/register");
      },
    },
  };
</script>

<style scoped>

  .main-container {
    position: relative;
    background-color: white;
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
    box-sizing: border-box;
  }

  /* Шапка */
  header {
    display: flex;
    align-items: center; /* Центрирование логотипа по вертикали */
    width: 100%; /* Ширина шапки на всю страницу */
    height: 80px; /* Фиксированная высота шапки */
    padding: 10px 20px; /* Отступы внутри шапки */
    box-sizing: border-box; /* Учитываем padding в общей ширине */
    background-color: white; /* Цвет фона шапки */
    /*border-bottom: 1px solid black; /* Линия снизу шапки */
  }

    header .logo {
      width: auto; /* Поддержка пропорций */
      max-height: 60px; /* Логотип адаптируется по высоте */
      margin-left: 150px; /* Отступ справа от логотипа */
    }

  /* Основной блок (контент + авторизация) */
  .main-container .main-content {
    display: flex;
    flex: 1; /* Растягивается, занимая оставшуюся высоту */
    padding: 20px;
    box-sizing: border-box;
    justify-content: space-between; /* Контент слева, авторизация справа */
    align-items: flex-start; /* Выравнивание по верхнему краю */
  }

    /* Место для изображения */
    .main-container .main-content .image-placeholder {
      height: 550px;
      width: 550px;
      border: 1px solid black;
      box-shadow: 0 10px 20px rgb(128, 128, 128);
      margin: 30px 0px 0px 150px;
    }

    /* Блок авторизации */
    .main-container .main-content .auth-box {
      background-color: white;
      border-radius: 50px;
      padding: 30px;
      font-size: 16px;
      text-align: center;
      width: 400px;
      height: 400px;
      margin: 100px 150px 0px 0px;
      box-shadow: 0 10px 20px rgb(128, 128, 128);
      color: black;
      border: 1px solid black;
    }

  .auth-box h2 {
    margin-bottom: 60px;
  }

  /* Кнопки */
  .auth-box button {
    display: block;
    width: 100%;
    height: 20%;
    padding: 10px;
    margin: 10px 0;
    border-radius: 15px;
    border: 3px solid black;
    font-size: 16px;
    cursor: pointer;
  }

  .auth-box .login {
    background-color: white;
    color: black;
  }

  .login:hover {
    background-color: darkviolet;
    color: white;
  }

  .auth-box .register {
    background-color: black;
    color: white;
  }

  .register:hover {
    background-color: darkviolet;
  }
</style>
