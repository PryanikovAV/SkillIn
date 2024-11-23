<template>
    <div>
        <h1>Авторизация</h1>
        <form @submit.prevent="login">
            <label for="login">Логин:</label>
            <input type="text" id="login" v-model="loginInput" />

            <label for="password">Пароль:</label>
            <input type="password" id="password" v-model="passwordInput" />

            <button type="submit">Войти</button>
        </form>
        <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                loginInput: '',
                passwordInput: '',
                errorMessage: '',
            };
        },
        methods: {
            async login() {
                try {
                    const response = await axios.post(
                        `http://localhost:5010/login/${this.loginInput}`,
                        this.passwordInput,
                        { headers: { 'Content-Type': 'application/json' } }
                    );

                    console.log('Успешный логин:', response.data);
                    localStorage.setItem('jwtToken', response.data);
                    this.errorMessage = '';
                    alert('Добро пожаловать в SkillIn!');
                } catch (error) {
                    console.error('Ошибка запроса:', error); // <-- Логирование ошибки
                    if (error.response && error.response.status === 401) {
                        this.errorMessage = 'Неверный логин или пароль';
                    } else {
                        this.errorMessage = 'Ошибка сервера. Попробуйте позже.';
                    }
                }
            }
        },
    };
</script>
