<template>
    <div class="login-container">
        <header>
            <img src="@/assets/logo.png"
                 alt="Логотип"
                 class="logo clickable"
                 @click="goToHome" />
        </header>
        <div class="login-content">
            <div class="auth-box">
                <h2>Вход</h2>
                <form @submit.prevent="handleLogin">
                    <div class="input-group">
                        <label for="username">Логин<span class="required">*</span></label>
                        <input id="username"
                               type="text"
                               v-model="username"
                               placeholder="Введите ваш логин"
                               required />
                    </div>
                    <div class="input-group">
                        <label for="password">Пароль<span class="required">*</span></label>
                        <input id="password"
                               type="password"
                               v-model="password"
                               placeholder="Введите ваш пароль"
                               required />
                    </div>
                    <button class="login-button" type="submit">Войти</button>
                </form>
            </div>
            <p class="register-text">
                Ещё не зарегистрировались?
                <router-link to="/register" class="register-link">Регистрация</router-link>
            </p>
        </div>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                username: "",
                password: "",
            };
        },
        methods: {
            async handleLogin() {
                try {
                    const response = await axios.post(
                        `http://localhost:5010/login/${this.username}`,
                        this.password,
                        { headers: { "Content-Type": "application/json" } }
                    );
                    alert("Добро пожаловать!");
                    this.$router.push("/search");
                } catch (error) {
                    if (error.response && error.response.status === 401) {
                        alert("Неверный логин или пароль");
                    } else {
                        alert("Ошибка сервера. Попробуйте позже.");
                    }
                }
            },
            goToHome() {
                this.$router.push("/");
            },
        },
    };
</script>

<style>
    .login-container {
        background-color: white;
        width: 100vw;
        height: 100vh;
        display: flex;
        flex-direction: column;
        box-sizing: border-box;
        text-align: center;
        color: black;
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
            cursor: pointer;
        }

    .auth-box {
        background-color: white;
        border-radius: 50px;
        padding: 30px;
        text-align: left;
        font-size: 22px;
        width: 600px;
        height: 600px;
        box-shadow: 0 10px 20px rgb(128, 128, 128);
        color: black;
        border: 1px solid black;
        margin-left: 470px;
    }

        .auth-box h2 {
            margin-bottom: 100px;
        }

    .input-group label {
        display: block;
        font-size: 14px;
        margin-bottom: 5px;
    }

    .input-group .required {
        color: red;
    }

    .input-group input {
        width: 100%;
        padding: 10px;
        border-radius: 5px;
        border: 1px solid black;
        box-sizing: border-box;
    }

    .password-wrapper {
        display: flex;
        align-items: center;
        gap: 10px;
    }


    .login-button {
        width: 300px;
        height: 50px;
        padding: 10px;
        margin-top: 87px;
        margin-left: 120px;
        background-color: black;
        color: white;
        border-radius: 10px;
        font-size: 16px;
        cursor: pointer;
        border: 3px solid black;
    }

        .login-button:hover {
            background-color: darkviolet;
        }

    .register-text {
        margin-top: 20px;
        font-size: 14px;
    }

    .register-link {
        color: blueviolet;
        text-decoration: none;
        font-weight: bold;
    }

        .register-link:hover {
            text-decoration: underline;
        }
</style>