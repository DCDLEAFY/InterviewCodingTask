<template>
    <div class="container">

        <div class="header-wrapper">
            <h2 class="header-title">BROKER-CUSTOMER</h2>
        </div>

        <table class="table mt-5 table-rounded">
            <thead>
                <tr class="row-bg-one">
                    <th scope="col">ID</th>
                    <th scope="col">NAME</th>
                    <th scope="col">ADDRESS</th>
                    <th scope="col">POLICY-TYPE</th>
                    <th scope="col">INSURER-NAME</th>
                    <th class scope="col">PREMIUM</th>
                    <th class="col-md-1" scope="col">EDIT</th>
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
    @import url('https://fonts.googleapis.com/css2?family=Raleway:wght@300;500&family=Roboto:wght@100&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap');
    
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
        color: rgb(255, 133, 133);
        box-shadow: 15px 20px 20px rgb(0, 0, 0, 50%);
        font-family: 'Roboto', sans-serif;
        font-weight: bold;
        padding: 20px;
        background-color: #161414;
        /* background-color: #222222; */
    }
    div.container { 
        padding-top: 100px; 
        padding-bottom: 70px;
    }

    th{
        height: 70px;
    }
    .table-rounded tr td{
        /* border-bottom: 1px solid #000000; */
    }

    tr.hoverable:hover{
        /* font-weight: bold; */
        color: #cc3a3a;
        scale: 1.005;
    }

    tr{
        border: hidden;
        box-shadow: 2px 8px 10px rgb(0, 0, 0, 20%);
        font-family: 'Raleway', sans-serif;
        font-weight: 500;
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

        border: hidden;
    }

    .row-bg-one{
        /* background-color: #01987a; */
        background-color: #da7171;
        color: white;
        font-family: 'Roboto', sans-serif;
        font-size: 1.4em;
    }

    .row-bg-two{
        background-color: #222222;
        color: rgb(155, 139, 139);
        font-family: 'Raleway', sans-serif;
        font-size: 1.1em;
    }
    
    .row-bg-three{
        background-color: #222222;
        color: rgb(153, 131, 131);
        font-family: 'Raleway', sans-serif;
        font-size: 1.1em;
    }

    
</style>