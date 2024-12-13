<template>
    <div class="register-container">
        <header>
            <img src="@/assets/logo.png"
                 alt="Логотип"
                 class="logo clickable"
                 @click="goToHome" />
        </header>
        <div class="register-content">
            <div class="auth-box">
                <h2>Регистрация</h2>
                <form @submit.prevent="handleRegister">
                    <div class="input-group">
                        <label for="username">Логин<span class="required">*</span></label>
                        <input id="username" type="text" v-model="login" placeholder="Введите ваш логин" required />
                    </div>
                    <div class="input-group">
                        <label for="email">Email<span class="required">*</span></label>
                        <input id="email" type="email" v-model="email" placeholder="Введите ваш email" required />
                    </div>
                    <div class="input-group">
                        <label for="password">Пароль<span class="required">*</span></label>
                        <input id="password" type="password" v-model="password" placeholder="Введите ваш пароль" required />
                    </div>
                    <button class="register-button" type="submit">Зарегистрироваться</button>
                </form>
            </div>
            <p class="login-text">
                Уже зарегистрировались? <a href="/login" class="login-link">Войти</a>
            </p>
        </div>
    </div>
</template>

<script>
    import { useUserStore } from "@/stores/user"; // Подключение Pinia Store

    export default {
        setup() {
            const userStore = useUserStore();

            return {
                userStore,
            };
        },
        data() {
            return {
                login: "",
                email: "",
                password: "",
            };
        },
        methods: {
            async handleRegister() {
                try {
                    await this.userStore.registerUser(this.login, this.email, this.password);
                    this.$router.push("/login"); // Перенаправление на страницу входа
                } catch (error) {
                    alert("Ошибка регистрации: " + (error.response?.data || error.message));
                }
            },
            goToHome() {
                this.$router.push("/"); // Переход на главную страницу
            },
        },
    };
</script>

<style>
    .register-container {
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


    .register-button {
        width: 300px;
        height: 50px;
        padding: 10px;
        margin-left: 120px;
        margin-top: 30px;
        background-color: black;
        color: white;
        border-radius: 10px;
        font-size: 16px;
        cursor: pointer;
        border: 3px solid black;
    }

        .register-button:hover {
            background-color: darkviolet;
        }

    .login-text {
        margin-top: 20px;
        font-size: 14px;
    }

    .login-link {
        color: blueviolet;
        text-decoration: none;
        font-weight: bold;
    }

        .login-link:hover {
            text-decoration: underline;
        }
</style>
