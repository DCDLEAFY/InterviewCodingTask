

<script setup>
  import CustomerTable from "./CustomerTable.vue"
</script>

<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top py-3">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#brokerNavbar" aria-controls="brokerNavbar" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="brokerNavbar">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" >Filter</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" >Add</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" >Delete</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="GetData">Retrieve</a>
        </li>
      </ul>
    </div>
  </nav>

  

  <CustomerTable :clientsInfo="this.clients" />
  


</template>



<script>
import {GetAllCustomers} from "../api/endpoints.js"


export default {
  name: "database-response",
  data() {
    return {
      clients: [],
    }
  },

  created(){
    GetAllCustomers()
        .then(response => this.clients = response.data)
        .then(console.log(this.clients))
        .catch(error => alert(error))
  },

  methods: {
    GetData(){
        GetAllCustomers()
        .then(response => this.clients = response.data)
        .then(console.log(this.clients))
        .catch(error => alert(error))
    }
  }
};
</script>

<style scoped>
  .navbar .navbar-nav .nav-link:hover {
    background-color: #fff;
    color: #ffacb7;
    transform: scale(1.01);
  }  
  .navbar .navbar-nav .nav-link {
    padding: 0.6em;
    font-size: 1.2em;
    transition: all 0.5s;
  }
  .navbar .navbar-brand {
    padding: 0 0.6em;
    font-size: 1.5em;
    font-weight: bold;
  }
  @media only screen and (min-width: 992px) {
    .navbar {
      padding: 0;
    }
    .navbar .navbar-nav .nav-link {
      padding: 1em 2em;
    }
    .navbar .navbar-brand {
      padding: 0 0.8em;
    }
}
</style>
