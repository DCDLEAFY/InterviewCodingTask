<template>
  <nav class="navbar navbar-expand fixed-top py-3 shadow">
    <a class="navbar-brand" href="#">BRO<span class="span-brand">KER</span></a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#brokerNavbar" aria-controls="brokerNavbar" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="brokerNavbar">
      <ul class="navbar-nav me-auto">
        <li class="nav-item">
          <a class="nav-link" @click="NavEmitHandler('navadd')">Add<span class="span-brand">+</span></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="NavEmitHandler('navdelete')">Delete<span class="span-brand">+</span></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" @click="NavEmitHandler('navrefresh')">Refresh Table<span class="span-brand">+</span></a>
        </li>
      </ul>
      <div class="form-outline input-group mb-3 w-25 pt-3 pe-5">
        <input type="text" class="form-control rounded-5" placeholder="Insert Filter" aria-describedby="button-addon2" v-model="filterString">
        <button class="btn btn-danger rounded-5" type="button" id="button-addon2">Clear</button>
      </div>
    </div>
  </nav>

</template>



<script>
  
  export default {
    data(){
      return{
        filterString: ""
      }
    },
    methods:{
      NavEmitHandler(value){
        switch(value) {
          case "navadd":
            this.$emit('navadd')
            break;
          case "navdelete":
            this.$emit('navdelete')
            break;
          case "navrefresh":
            this.$emit('navrefresh')
            break;
          default:
            console.log("Default switch emit from Navbar vue component")
        }
      }
    },

    computed:{
      
    },

    watch:{
      filterString: function(){
        this.$emit('filterstring', this.filterString)
      }
    }
  }
</script>

<style scoped>  

  .form-control:focus {
    border-color: #c78282;
    box-shadow: 0 0 0 0.2rem rgba(245, 91, 91, 0.25);
  }
  .btn {
    font-family: 'Roboto', sans-serif;
  }
  .nav-link{
    font-family: 'Roboto', sans-serif;
    color: white;
    cursor: pointer;
  }
  .navbar .navbar-nav .nav-link:hover {
    color: #ee4545;
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
    font-family: 'Roboto', sans-serif;
    color: white;
  }

  .span-brand{
    font-weight: bold;
    font-family: 'Roboto', sans-serif;
    color: rgb(255, 133, 133);
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

  nav{
      background-color: #222222;
      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }
</style>
