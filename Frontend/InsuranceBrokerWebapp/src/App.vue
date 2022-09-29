<script setup >
import BrokerNav from './components/BrokerNavbar.vue'
import CustomerTable from "./components//CustomerTable.vue"
import Modal from "./components//Modal.vue"
</script>


<template>
  <header></header>

  <main>
    <BrokerNav 
    @navadd="{showAddModal = !showAddModal;}" 
    @navdelete="{showDeleteModal = !showDeleteModal;}" 
    @navrefresh="GetClientsData" 
    @filterstring="GetFilterSearch"/>

    <CustomerTable :clientsInfo="(filterSearch === '')? clientTableData : FilterTable" @EditCustomer="GetEditableRow"/>

  
  
  <Modal dynamicSubmit="AddNewCustomer" v-show="showAddModal" @Close="{showAddModal = !showAddModal;}" @AddNewCustomer="AddClientData">
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
          <input type="number" class="form-control" id="addPremium" v-model="this.customer.premium">
        </div>
      </div>
    </template>
    <template v-slot:footer>
    </template>
  </Modal>


  <Modal dynamicSubmit="DeleteCustomer" v-show="showDeleteModal" @Close="{showDeleteModal = !showDeleteModal;}" @DeleteCustomer="DeleteClientData">
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

  <Modal dynamicSubmit="EditCustomer" v-show="showEditModal" @Close="{showEditModal = !showEditModal;}" @EditCustomer="">
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
    </template>
  </Modal>
  </main>
</template>

<script>
  import { AddCustomer, DeleteCustomer, GetAllCustomers, UpdateCustomer } from "./api/endpoints.js";

  export default {
    data(){
      return{
        clientTableData: [],
        filterSearch: "",
        showAddModal: false,
        showDeleteModal: false,
        showEditModal: false,
        customer: {
          id: 0,
          name:null,
          address:null,
          policyType:null,
          insurerName:null,
          premium:null
        },
        deleteId: 0,
      }
    },
    watch:{

    },

    created(){
      this.GetClientsData();
    },

    computed:{
      FilterTable(){
        return this.clientTableData.filter(row => {
          const name = row.name.toString().toLowerCase();
          const address = row.address.toString().toLowerCase();
          const policyType = row.policyType.toString().toLowerCase();
          const insurerName = row.insurerName.toString().toLowerCase();
          const premium = row.premium.toString();
          const searchTerm = this.filterSearch.toLowerCase();

          return name.includes(searchTerm) ||
            address.includes(searchTerm) ||
            policyType.includes(searchTerm) ||
            insurerName.includes(searchTerm) ||
            premium.includes(searchTerm);
        });
    },
    },

    methods:{
      GetEditableRow(val){
        this.customer = val;
        this.showEditModal = !this.showEditModal;
      },
      GetFilterSearch(val){
        this.filterSearch = val;
      },
      GetClientsData(){
        GetAllCustomers()
        .then((response) => {
          if(response.status !== 200){
            throw new Error("HTTP Status: " + response.status)
          }
          this.clientTableData = response.data;
        })
        .catch(err => alert(err))
      },

      AddClientData(){
        this.showAddModal = !this.showAddModal
        AddCustomer(this.customer)
        .then((response) => {
          if(response.status !== 200){
            throw new Error("HTTP Status: " + response.status)
          }
        })
        .catch(err => alert(err))
      },

      DeleteClientData(){
        this.showDeleteModal = !this.showDeleteModal
        DeleteCustomer(this.deleteId)
        .then((response) => {
          if(response.status !== 200){
            throw new Error("HTTP Status: " + response.status)
          }
        })
        .catch(err => alert(err))
      },

      UpdateClientData(){
        
      }
    }
  }  
  
  
</script>

<style scoped>
  header {
    line-height: 1.5;
  }

  main{
    background: linear-gradient(410deg, #d8cdcd 50%, #ff2525 100%);
    padding-bottom: 300px;
  }


</style>
