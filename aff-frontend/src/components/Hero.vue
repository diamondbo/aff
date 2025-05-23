<template>
    <section class="bg-blue-600 text-white text-center py-20">
      <h2 class="text-4xl md:text-5xl font-bold mb-4 animate-pulse">Build Smarter with MyApp</h2>
      <p class="text-lg mb-8">A powerful tool for seamless productivity and growth.</p>
      <p class="text-lg mb-8">Buying Power: {{ buyingpower }}</p>
      <p class="text-lg mb-8">Trading Cash: {{ tradingcash }}</p>
      <a href="#cta" class="bg-white text-blue-600 px-6 py-3 font-semibold rounded shadow hover:bg-gray-100 transition">
        Get Started
      </a>
    </section>
  </template>
 <script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const buyingpower = ref('')
const tradingcash = ref('')

onMounted(async () => {
  try {
    const response = await axios.get('/api/buyingpower')
    buyingpower.value = response.data.buyingPower 
    tradingcash.value = response.data.cash
  } catch (error) {
    buyingpower.value = 'Error fetching data'
    console.error('API Error', error)
  }
})
</script>

  