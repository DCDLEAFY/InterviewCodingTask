<template>
    <div class="container">
        <h2 class="text-center mt-5">Insurance Broker Customers</h2>

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
                <tr v-for="(client, index) in clientsInfo" :key="index">
                    <th scope="row">{{client.id}}</th>
                    <td>{{client.name}}</td>
                    <td>{{client.address}}</td>
                    <td>{{client.policyType}}</td>
                    <td>{{client.insurerName}}</td>
                    <td>{{client.premium}}</td>
                    <td><img width="50" height="50" src="src\assets\ink.png" alt="inkimage" @click="EditClient(client)"></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        props: ['clientsInfo'],
        watch: {
            clientsInfo: function () {
                console.log(this.clientsInfo)
            },
        },
        methods:{
            EditClient(rowClient){
                this.$emit('EditCustomer', rowClient);
            }
        }
    }   
</script>

<style scoped>
     div.container { padding-top: 70px; }

</style>