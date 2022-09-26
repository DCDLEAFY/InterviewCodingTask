<template>
  <div class="container">
    <h2 class="text-center mt-5">Insurance Broker Customers</h2>

    <!-- Temporary Search -->
    <div class="d-flex">
      <input type="text" placeholder="Search By ID" class="form-control">
      <button class="btn btn-warning rounded-0" @click="GetData">Search</button>
    </div>

    <!-- Table view -->
    <table class="table table-hover mt-5">
      <thead>
        <tr>
          <th scope="col">Id</th>
          <th scope="col">Name</th>
          <th scope="col">Address</th>
          <th scope="col">PolicyType</th>
          <th scope="col">InsurerName</th>
          <th scope="col">Premium</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(client, index) in clients" :key = "index">
          <th scope="row">{{client.id}}</th>
          <td>{{client.name}}</td>
          <td>{{client.address}}</td>
          <td>{{client.policyType}}</td>
          <td>{{client.insurerName}}</td>
          <td>{{client.premium}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import {GetAllCustomers} from "../api/endpoints.js"

export default {
  name: "database-response",
  data() {
    return {
      clients:
        []
    }
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

</style>
