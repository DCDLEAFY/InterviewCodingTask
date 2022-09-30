<template>
    <div class="container">

        <div class="header-wrapper">
            <h2 class="header-title">BROKER-CUSTOMER</h2>
        </div>

        <table class="table mt-5 table-rounded">
            <thead>
                <tr class="row-bg-one">
                    <th scope="col">Id</th>
                    <th scope="col">Name</th>
                    <th scope="col">Address</th>
                    <th scope="col">PolicyType</th>
                    <th scope="col">InsurerName</th>
                    <th class scope="col">Premium</th>
                    <th class="col-md-1" scope="col">Editable</th>
                </tr>
            </thead>
            <tbody>
                <tr :class="{'hoverable row-bg-two' : index % 2 === 0, 'hoverable row-bg-three' : index % 2 !== 0}" v-for="(client, index) in clientsInfo" :key="index">
                    <th scope="row">{{client.id}}</th>
                    <td>{{client.name}}</td>
                    <td>{{client.address}}</td>
                    <td>{{client.policyType}}</td>
                    <td>{{client.insurerName}}</td>
                    <td>{{client.premium}}</td>
                    <td><img class="rounded-circle border" width="50" height="50" src="/ink.png" alt="inkimage" @click="EditClient(client)"></td>
                </tr>

            </tbody>
        </table>

        <!-- Table view -->
        
    </div>
</template>

<script>
    export default {
        data(){
            return{
                isHover : false,
            }
        },
        props: ['clientsInfo'],
        watch: {

        },
        methods:{
            EditClient(rowClient){
                this.$emit('EditCustomer', rowClient);
            },
        }
    }   
</script>

<style scoped>
    
    img{
        cursor: pointer;
        filter: blur(0.5px);
    }

    img:hover{

        filter: blur(0px);
    }
    .header-wrapper{
        padding-top: 20px;
        display: block;
        text-align: center;
        
    }

    .header-title{
        display: inline-block;
        width: auto;
        border: 20px solid black;
        background-color: black;
        color: rgb(255, 133, 133);
        box-shadow: 4px 4px 5px rgb(37, 34, 34);
        font-family: 'Roboto', sans-serif;
        font-weight: bold;
    }
    div.container { 
        padding-top: 100px; 
        padding-bottom: 70px;
    }

    th{
        height: 70px;
    }
    .table-rounded tr td{
        border-bottom: 1px solid #dddddd;
    }

    tr.hoverable:hover{
        /* font-weight: bold; */
        color: #01987a;
        scale: 1.005;
    }

    tr.hoverable:hover > td> img{
        animation: 1s fadeIn;
        animation-fill-mode: forwards;
    }

    tr > td > img{
        visibility: hidden;
    }


    td, th{
        vertical-align: middle;
    }

    

    @keyframes fadeIn{
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
            visibility: visible;
        }
    }

    .table-rounded{
        border-radius: 6px;
        overflow: hidden;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
        font-size: 0.9em;
        animation: 1.5s fadeIn;
        animation-fill-mode: forwards;
    }

    .row-bg-one{
        background-color: #01987a;
        color: white;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: 1.4em;
    }

    .row-bg-two{
        background-color: #ffffff;
        color: black;
        font-family: 'Raleway', sans-serif;
        font-size: 1.1em;
    }
    
    .row-bg-three{
        background-color: #f3f3f3;
        color: black;
        font-family: 'Raleway', sans-serif;
        font-size: 1.1em;
    }

    
</style>