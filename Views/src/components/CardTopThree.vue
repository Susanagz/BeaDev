<template>
  <v-card
    darkclass="pa-2"
    shaped
    :elevation="5"
    :max-width="$vuetify.breakpoint.smAndDown ? 290 : 260"
    :style="'border: 2px solid' + color"
  >
    <v-card-text>
      <div v-if="language"># {{ language.position }}</div>
    </v-card-text>
    <v-img
      src="https://1.bp.blogspot.com/-G_oYeB6RQwc/YV992v5A7bI/AAAAAAAAAg8/jBWfbcWNNqMI1RmQr02qVsoBZtzty-viwCNcBGAsYHQ/s1600/Lenguaje_programacion.png"
      height="180px"
    ></v-img>
    <v-card-title>
      <div v-if="language">
        {{ language.name }}
      </div>
    </v-card-title>
    <v-card-subtitle>
      <div v-if="language">Total positions: {{ language.counter }}</div>
    </v-card-subtitle>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn icon @click="show = !show">
        <v-icon>{{ show ? "expand_less" : "expand_more" }}</v-icon>
      </v-btn>
    </v-card-actions>
    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>
        <v-card-text>
          <div v-if="language">
            Salary Rate: {{ language.salaryRate.toFixed(2) }}
          </div>
        </v-card-text>
        <v-card-text>
          <div v-if="language">
            Common job desc: {{ language.topThreeStackDescList }}
          </div>
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "CardTopThree",
  props: ["color", "language"],

  computed: mapState(["topThreePL"]),

  data: () => ({
    show: false,
    topPosition: 2,
  }),

  methods: {
    ConnectSignalR() {
      //this.$store.commit("ConnectSignalR");
      //console.log(this.$store.state.topThreePL);
    },
  },

  created() {
    this.ConnectSignalR();
  },
};
</script>