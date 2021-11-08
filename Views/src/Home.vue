<template>
  <v-app id="inspire">
    <v-app-bar app color="dark accent-1" dark>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        <span>BeaDev</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
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
            <p>Today Top 3</p>
            <v-row justify="center" class="mb-6">
              <div v-if="$vuetify.breakpoint.smAndDown">
                <v-col md="3">
                  <CardTopThree v-bind:color="topThreeColors[2]" v-bind:language="topThreePL[0]" />
                </v-col>
                <v-col md="3">
                  <CardTopThree class="mt-2" v-bind:color="topThreeColors[1]" v-bind:language="topThreePL[1]"/>
                </v-col>
                <v-col md="3">
                  <CardTopThree class="mt-2" v-bind:color="topThreeColors[0]" v-bind:language="topThreePL[2]"/>
                </v-col>
              </div>
              <template v-else>
                <v-col order="first" md="3">
                  <CardTopThree class="mt-9" v-bind:color="topThreeColors[1]" v-bind:language="topThreePL[1]"/>
                </v-col>
                <v-col md="3">
                  <CardTopThree v-bind:color="topThreeColors[2]" v-bind:language="topThreePL[0]"/>
                </v-col>
                <v-col order="last" md="3">
                  <CardTopThree
                    class="mt-14"
                    v-bind:color="topThreeColors[0]"
                    v-bind:language="topThreePL[2]"
                  />
                </v-col>
              </template>
            </v-row>
          </v-container>
        </v-card>
      </v-container>

      <v-container fluid>
        <v-card>
          <v-container>
            Top 3 Programming Languages according to projections
            <v-row justify="center">
              <v-col md=""> <ProChart /> </v-col>
            </v-row>
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
import ProChart from "@/components/ProChart.vue";
import { HubConnectionBuilder } from "@aspnet/signalr";
import axios from "axios";

export default {
  name: "Home",
  components: { Carousel, CardTopThree, ProChart },
  data: () => ({
    topThreeColors: ["#b87333", "#c0c0c0", "#ffd700"],
    connection: null,
    topThreePL: [],
  }),

  created() {
    this.connection = new HubConnectionBuilder()
      .withUrl(`${axios.defaults.baseURL}ProgrammingLanguages`)
      .build();

    this.connection
      .start()
      .then(() => console.log("connected"))
      .catch((err) => console.error("Failed to connect with hub", err));
    // Forward hub events through the event, so we can listen for them in the Vue components
    this.connection.on("Receive", (programmingLanguage) => {
      this.topThreePL = programmingLanguage;
    });
  },

  methods: {},
};
</script>
