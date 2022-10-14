<template>
  <div id="app">
    <t-navbar></t-navbar>
    <div class="main">
      <t-header></t-header>
      <t-content></t-content>
    </div>
  </div>
</template>

<script>
import TheContent from "./components/layout/TheContent.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheNavbar from "./components/layout/TheNavBar.vue";
export default {
  name: "App",
  components: {
    "t-content": TheContent,
    "t-header": TheHeader,
    "t-navbar": TheNavbar,
  },
};
</script>

<style>
@import url(./assets/css/main.css);
@import url(./assets/css/layout/layout.css);
</style>
