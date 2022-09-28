

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
          <a class="nav-link" @click="ShowAddModal">Add</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" >Update Customer</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="ShowDeleteModal">Delete</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="GetData">Refresh Table</a>
        </li>
      </ul>

      <div class="input-group mb-3 w-25 pt-3">
        <input type="text" class="form-control" placeholder="Filter" aria-label="Recipient's username" aria-describedby="button-addon2" v-model="clientsFilter">
        <button class="btn btn-outline-secondary" type="button" id="button-addon2" @click="clearFilter">Clear</button>
      </div>
    </div>
  </nav>

  <CustomerTable :clientsInfo="TableData" @EditCustomer="ShowEditModal"/>

  
  
  <Modal dynamicSubmit="AddCustomer" v-show="isAddModalVisible" @Close="CloseAddModal" @AddCustomer="PostData">
    <template v-slot:header>
      Add Customer information to Database
    </template>
    <template v-slot:body>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addName">Name</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addName" v-model="this.customer.name">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addAddress">Address</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addAddress" v-model="this.customer.address">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPolicy">PolicyType</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPolicy" v-model="this.customer.policytype">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addInsurer">InsurerName</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addInsurer" v-model="this.customer.insurername">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPremium">Premium</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPremium" v-model="this.customer.premium">
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

  <Modal dynamicSubmit="EditCustomer" v-show="isEditModalVisible" @Close="CloseEditModal" @EditCustomer="PutData">
    <template v-slot:header>
      Edit Customer information
    </template>
    <template v-slot:body>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="editId">ID</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="editId" v-model="this.customer.id" readonly>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addName">Name</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addName" v-model="this.customer.name">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addAddress">Address</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addAddress" v-model="this.customer.address">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPolicy">PolicyType</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPolicy" v-model="this.customer.policyType">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addInsurer">InsurerName</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addInsurer" v-model="this.customer.insurerName">
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label" for="addPremium">Premium</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="addPremium" v-model="this.customer.premium">
        </div>
      </div>
    </template>
    <template v-slot:footer>
      Footer
    </template>
  </Modal>

</template>



<script>
import {AddCustomer, GetAllCustomers, DeleteCustomer, UpdateCustomer} from "../api/endpoints.js"

export default {
  name: "database-response",
  data() {
    return {
      clients: [],
      isAddModalVisible: false,
      isDeleteModalVisible: false,
      isEditModalVisible: false,
      deleteId: -1,
      customer: {
        name:null,
        address:null,
        policytype:null,
        insurername:null,
        premium:null
      },

      clientsFilter: "",
    }
  },

  created(){
    GetAllCustomers()
        .then(response => this.clients = response.data)
        .then(console.log(this.clients))
        .catch(error => alert(error))
  },

  methods: {
    ShowEditModal(value){
      this.isEditModalVisible = true;
      this.customer = value;
    },
    CloseEditModal(){
      this.isEditModalVisible = false;
      window.location.reload();
    },
    clearFilter(){
      this.clientsFilter = "";
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
      window.location.reload()
    },
    GetData(){
      GetAllCustomers()
      .then(response => this.clients = response.data)
      .then(response => console.log("GetData status: " + response.status))
      .catch(error => alert(error))
    },
    PostData(){
      this.CloseAddModal()
      AddCustomer(this.customer)
      .then(response => console.log("Post status: " + response.status))
      .then(window.location.reload())
      .catch(error => console.log(error))
      
    },
    DeleteData(){
      this.CloseDeleteModal()
      DeleteCustomer(this.deleteId)
      .then(response => console.log("Delete status: "+ response.status))
      .then(window.location.reload())
      .catch(error => console.log(error))
    },
    PutData(){
      this.CloseEditModal()
      console.log("Put data here please: " + this.customer.id)
      UpdateCustomer(this.customer)
      .then(response => console.log("Put status: " + response.status))
      .catch(error => console.log(error))
    },
  },

  computed: {
    FilterTable(){
      return this.clients.filter(row => {
        const name = row.name.toString().toLowerCase();
        const address = row.address.toString().toLowerCase();
        const policyType = row.policyType.toString().toLowerCase();
        const insurerName = row.insurerName.toString().toLowerCase();
        const premium = row.premium.toString();
        const searchTerm = this.clientsFilter.toLowerCase();

        return name.includes(searchTerm) ||
          address.includes(searchTerm) ||
          policyType.includes(searchTerm) ||
          insurerName.includes(searchTerm) ||
          premium.includes(searchTerm);
      });
    },
    TableData(){
      if(this.clientsFilter === ""){
        return this.clients;
      }
      return this.FilterTable;
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
