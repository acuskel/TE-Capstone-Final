<template>
  <div id="app">
    <navbar />
    <router-view />
    <foot />
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue';
import issueService from "./services/IssueService.js";
import Foot from './components/Foot.vue';
import collectionService from "./services/CollectionService.js";

export default {
  components: { Navbar, Foot },
  created() {
    issueService
      .getAllIssues()
      .then((response) => {
        this.$store.commit("POPULATE_ALL_ISSUES", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "error: HTTP Response Code: " + error.response.data.status;
          this.message = +" Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
      
    collectionService
      .getCollections(this.$store.state.user.userId)
      .then((response) => {
        this.$store.commit("REPLACE_COLLECTIONS", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message = 
          "error: HTTP Response Code: " + error.response.data.status;
          this.message =+ " Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
  
};
</script>


<style>
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Montserrat+Alternates&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Montserrat&family=Montserrat+Alternates&display=swap');


body, html, #app {   
  font-family: 'montserrat';
  font-weight: 100;
  font-size: 1.2em;
  margin: auto;
  max-width: 1200px;
  min-height: 100%;
  text-align: center;
  color: #2c3e50;
  display: auto; 
  background: #7493bb;
  background-image: url("https://www.onlygfx.com/wp-content/uploads/2016/08/halftone-simple.png"), linear-gradient(#a64ac9, #fccd04);
  }

#app {
min-height: 1000px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #1476a7;
}

ul {
  list-style-type: none;
}

#buttons li a {
  text-decoration: none;
  color: #ffffff;
  display: block;
}

li a:hover {
  text-decoration: none;
}
</style>