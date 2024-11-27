import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import path from 'path'; // Импортируем модуль path

export default defineConfig({
    plugins: [vue()],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'), // Настраиваем алиас '@' для папки src
        },
    },
    server: {
        port: 5173, // Указываем основной порт
        strictPort: true, // Завершаем процесс, если порт 5173 недоступен
    },
});
