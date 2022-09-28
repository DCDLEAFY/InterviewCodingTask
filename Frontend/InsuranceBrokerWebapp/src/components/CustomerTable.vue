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
    }   
</script>

<style scoped>
     div.container { padding-top: 70px; }
</style>