<template>
  <v-app id="inspire">
    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="dark accent-1"
      dark
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down">BeaDev</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-tooltip top>
        <template v-slot:activator="{ on, attrs }">
          <v-btn v-bind="attrs" v-on="on" @click="LogOut()">
            <v-icon color="white"> logout </v-icon>
          </v-btn>
        </template>
        <span>Log Out</span>
      </v-tooltip>
    </v-app-bar>
    <v-main>
      <v-container fluid>
        <v-card>
          <Carousel />
        </v-card>
      </v-container>
      <v-container fluid>
        <v-card>
          <v-container>
            <v-row justify="center" class="mb-6">
              <v-col md="3">
                <CardTopThree />
              </v-col>
              <v-col md="3">
                <CardTopThree />
              </v-col>
              <v-col md="3  ">
                <CardTopThree />
              </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-container>

      <v-container fluid>
        <v-card>
          <v-container>
            <Chart />
          </v-container>
        </v-card>
      </v-container>
    </v-main>
    <v-footer
      padless
      color="dark accent-1"
      height="auto"
      class="font-weight-medium"
      dark
    >
      <v-col class="text-center" cols="12">
        {{ new Date().getFullYear() }} —
        <strong> © BeaDev</strong>
      </v-col>
    </v-footer>
  </v-app>
</template>

<script>
import Carousel from "@/components/Carousel";
import CardTopThree from "@/components/CardTopThree.vue";
import Chart from "@/components/Chart.vue";

export default {
  name: "Home",
  components: { Carousel, CardTopThree, Chart },
  data: () => ({}),

  methods: {
    LogOut: function () {
      localStorage.removeItem("jwt");
      localStorage.removeItem("user");
      this.$router.push({ name: "Login" });
    },
  },
};
</script>
