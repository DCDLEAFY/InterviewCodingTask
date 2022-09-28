

<script setup>
  import CustomerTable from "./CustomerTable.vue"
  import Modal from "./Modal.vue"


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
          <a class="nav-link" @click="ShowAddModal">Add</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="ShowDeleteModal">Delete</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="GetData">Retrieve</a>
        </li>
      </ul>
    </div>
  </nav>

  

  <CustomerTable v-if="forcerenderbool" :clientsInfo="this.clients" />
  
  <Modal dynamicSubmit="AddCustomer" v-show="isAddModalVisible" @Close="CloseAddModal" @AddCustomer="PostData">
    <template v-slot:header>
      Add Customer information to Database
    </template>
    <template v-slot:body>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addName">Name</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addName" v-model="this.postCustomer.name">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addAddress">Address</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addAddress" v-model="this.postCustomer.address">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPolicy">PolicyType</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPolicy" v-model="this.postCustomer.policytype">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addInsurer">InsurerName</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addInsurer" v-model="this.postCustomer.insurername">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPremium">Premium</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPremium" v-model="this.postCustomer.premium">
        </div>
      </div>
    </template>
    <template v-slot:footer>
      Footer
    </template>
  </Modal>


  <Modal dynamicSubmit="DeleteCustomer" v-show="isDeleteModalVisible" @Close="CloseDeleteModal" @DeleteCustomer="DeleteData">
    <template v-slot:header>
      Enter Customer ID to delete
    </template>
    <template v-slot:body>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="deleteCustomerID">Customer ID</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="deleteCustomerID" v-model="this.deleteId">
        </div>
      </div>
    </template>
  </Modal>

</template>



<script>
import {AddCustomer, GetAllCustomers, DeleteCustomer} from "../api/endpoints.js"

export default {
  name: "database-response",
  data() {
    return {
      forcerenderbool: true,

      clients: [],
      isAddModalVisible: false,
      isDeleteModalVisible: false,
      deleteId: -1,
      postCustomer: {
        name:null,
        address:null,
        policytype:null,
        insurername:null,
        premium:null
      },
    }
  },

  created(){
    GetAllCustomers()
        .then(response => this.clients = response.data)
        .then(console.log(this.clients))
        .catch(error => alert(error))
  },

  methods: {
    forceRender(){
      this.forcerenderbool = false;

      this.$nextTick(() => {
        this.forcerenderbool = true;
      })
    },
    ShowAddModal(){
      this.isAddModalVisible = true
    },
    CloseAddModal(){
      this.isAddModalVisible = false
    },
    ShowDeleteModal(){
      this.isDeleteModalVisible = true
    },
    CloseDeleteModal(){
      this.isDeleteModalVisible = false
    },
    GetData(){
      GetAllCustomers()
      .then(response => this.clients = response.data)
      .then(response => console.log(response.status))
      .catch(error => alert(error))
      
    },
    PostData(){
      this.CloseAddModal()
      AddCustomer(this.postCustomer)
      .then(response => console.log(response.status))
      .then(this.GetData())
      .catch(error => console.log(error))
      window.location.reload();
    },
    DeleteData(){
      this.CloseDeleteModal()
      DeleteCustomer(this.deleteId)
      .then(response => console.log(response))
      .then(this.GetData())
      .catch(error => console.log(error))
      window.location.reload();
    },
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
