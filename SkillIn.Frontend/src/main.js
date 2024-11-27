import { createApp } from 'vue';
import App from './App.vue';
import router from './router.js';
//import ".src/assets/base.css";
//import ".src/assets/main.css";

const app = createApp(App);
app.use(router);
app.mount('#app');
