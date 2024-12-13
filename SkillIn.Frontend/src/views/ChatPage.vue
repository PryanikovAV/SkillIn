<script setup>
import { ref } from 'vue';
import Toolbar from 'primevue/toolbar';
import Button from 'primevue/button';
import Listbox from 'primevue/listbox';
import Card from 'primevue/card';
import InputText from 'primevue/inputtext';

const selectedChat = ref(null);
const newMessage = ref('');

const people = ref([
    { 
        name: 'Джон Доу', 
        lastMessage: 'Привет! Как дела?', 
        lastSeen: "11 минут назад",
        icon: 'pi pi-user',
        messages: [
            { text: 'Привет! Как дела?', sender: 'Джон Доу', time: '10:00' },
            { text: 'Все хорошо, спасибо!', sender: 'Я', time: '10:05' }
        ]
    },
    { 
        name: 'Джейн Смит', 
        lastMessage: 'Ты придешь завтра?', 
        lastSeen: '1 час назад', 
        icon: 'pi pi-user',
        messages: [
            { text: 'Ты придешь завтра?', sender: 'Джейн Смит', time: '15:30' }
        ]
    },
    { 
        name: 'Майкл Браун', 
        lastMessage: 'Встретимся в 17:00.', 
        lastSeen: 'Вчера', 
        icon: 'pi pi-user',
        messages: [
            { text: 'Встретимся в 17:00.', sender: 'Майкл Браун', time: '14:00' }
        ]
    },
    { 
        name: 'Эмили Дэвис', 
        lastMessage: 'До встречи!', 
        lastSeen: '2 дня назад', 
        icon: 'pi pi-user',
        messages: [
            { text: 'До встречи!', sender: 'Эмили Дэвис', time: '12:30' }
        ]
    },
    { 
        name: 'Крис Уилсон', 
        lastMessage: 'Можем перенести?', 
        lastSeen: 'На прошлой неделе', 
        icon: 'pi pi-user',
        messages: [
            { text: 'Можем перенести?', sender: 'Крис Уилсон', time: '16:45' }
        ]
    }
]);

const sendMessage = () => {
    if (newMessage.value.trim() && selectedChat.value) {
        const now = new Date();
        const time = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
        const message = {
            text: newMessage.value,
            sender: 'Я',
            time: time
        };

        // Добавляем сообщение в чат
        selectedChat.value.messages.push(message);

        // Обновляем последнее сообщение и время
        selectedChat.value.lastMessage = `Я: ${newMessage.value}`;

        newMessage.value = '';
    }
};
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

        <div class="content-container">
            <aside class="sidebar">
                <h2>Контакты</h2>
                <Listbox 
                    v-model="selectedChat" 
                    :options="people" 
                    filter 
                    optionLabel="name" 
                    class="w-full"> 

                    <template #option="{ option }">
                        <div class="contact-item">
                            <i :class="option.icon" class="contact-icon"></i>
                            <div class="contact-info">
                                <div class="contact-name">{{ option.name }}</div>
                                <div class="contact-message">{{ option.lastMessage }}</div>
                                <small class="contact-lastseen">Был(а) онлайн: {{ option.lastSeen }}</small>
                            </div>
                        </div>
                    </template>
                </Listbox>
            </aside>
            <main class="message-box">
                <h1 class="title">Сообщения</h1>
                <Card>
                    <template #content>
                        <div v-if="selectedChat" class="chat-content">
                            <div v-for="message in selectedChat.messages" :key="message.time" class="message">
                                <div class="message-sender">{{ message.sender }}</div>
                                <div class="message-text">{{ message.text }}</div>
                                <small class="message-time">{{ message.time }}</small>
                            </div>
                        </div>
                        <div v-else class="card-content flex justify-content-center">
                            <p>Выберите контакт, чтобы увидеть сообщения.</p>
                        </div>
                    </template>
                </Card>
                <div class="chat-input">
                    <InputText v-model="newMessage" placeholder="Напишите сообщение" class="message-input" />
                    <Button icon="pi pi-send" @click="sendMessage" aria-label="Отправить"></Button>
                </div>
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
    height: 100%;
}

.sidebar {
    margin-left: 5%;
    width: 30%;
    background-color: #f7f7f7;
    padding: 2rem;
    border-right: 1px solid #ddd;
}

.contact-item {
    display: flex;
    align-items: center;
    gap: 1rem;
    padding: 0.5rem 0;
    border-bottom: 1px solid #ddd;
}

.contact-icon {
    font-size: 1.5rem;
    color: #888;
}

.contact-info {
    display: flex;
    flex-direction: column;
}

.contact-name {
    font-weight: bold;
    margin-bottom: 0.2rem;
}

.contact-message {
    color: #555;
    font-size: 0.9rem;
    margin-bottom: 0.2rem;
}

.contact-lastseen {
    color: #aaa;
    font-size: 0.8rem;
}

.message-box {
    flex: 1;
    padding: 1.5rem;
    display: flex;
    flex-direction: column;
    background-color: lch(lightness chroma hue);
    color: currentColor;
}

.card {
    flex: 1;
    overflow-y: auto;
}

.chat-input {
    display: flex;
    align-items: center;
    gap: 1rem;
    padding: 1rem;
    border-top: 1px solid #ddd;
}

.message-input {
    flex: 1;
}

.message {
    padding: 0.5rem;
    border-radius: 5px;
    background-color: #f1f1f1;
}

.message-sender {
    font-weight: bold;
}

.message-text {
    margin-top: 0.2rem;
}

.message-time {
    font-size: 0.8rem;
    color: #aaa;
    margin-top: 0.2rem;
}
</style>
