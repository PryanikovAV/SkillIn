import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
    plugins: [vue()],
    server: {
        port: 5173,
        scriptPort: true,  // Завершить работу, если 5173 недоступен
    },
});