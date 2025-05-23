import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

export default defineConfig({
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5151',
        changeOrigin: true,
        secure: false,
        rewrite: path => path.replace(/^\/api/, '/alpaca') // ✅ rewrite /api → /alpaca
      }
    }
  },
  plugins: [vue()]
})
