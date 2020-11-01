<template>
  <!-- <HelloWorld msg="Welcome to Your Vue.js App"/> -->
  <div>
    <section>
      <img alt="Vue logo" src="../../../wwwroot/images/logo.82b9c7a5.png" />
    </section>
    <hello-world></hello-world>
    <section>
      Hello welcome to your Vue project
    </section>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: "App",
  components: {
    HelloWorld,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
