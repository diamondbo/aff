<template>
  <div class="min-h-screen bg-gray-50 text-gray-800 animate-pulse">
    <Header />
    <Hero />
    <Features />
    <CTA />
    <Footer />
  </div>
</template>

<script setup>
import Header from './components/Header.vue'
import Hero from './components/Hero.vue'
import Features from './components/Features.vue'
import CTA from './components/CTA.vue'
import Footer from './components/Footer.vue'
</script>

<style scoped>
html {
  scroll-behavior: smooth;
}
</style>