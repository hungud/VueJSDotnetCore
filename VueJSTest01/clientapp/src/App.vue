<template>
  <div id="app">    
    <DataGridFilter/>
  </div>
</template>

<script>
    import DataGridFilter from './components/DataGridFilter.vue'


export default {
  name: 'app',
  components: {
      DataGridFilter
  }
}
</script>

<style>

@import url('https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Material+Icons');

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
