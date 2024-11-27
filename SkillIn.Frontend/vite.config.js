import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import path from 'path'; // ����������� ������ path

export default defineConfig({
    plugins: [vue()],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'), // ����������� ����� '@' ��� ����� src
        },
    },
    server: {
        port: 5173, // ��������� �������� ����
        strictPort: true, // ��������� �������, ���� ���� 5173 ����������
    },
});
