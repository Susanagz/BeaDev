<template>
  <v-card
    darkclass="pa-2"
    shaped
    :elevation="5"
    :max-width="$vuetify.breakpoint.smAndDown ? 290 : 260"
    :style="'border: 2px solid' + color"
  >
    <v-card-text>
      {{ language.position }}
    </v-card-text>
    <v-img
      src="https://1.bp.blogspot.com/-G_oYeB6RQwc/YV992v5A7bI/AAAAAAAAAg8/jBWfbcWNNqMI1RmQr02qVsoBZtzty-viwCNcBGAsYHQ/s1600/Lenguaje_programacion.png"
      height="180px"
    ></v-img>
    <v-card-title>
      {{ language.name }}
    </v-card-title>
    <v-card-subtitle> Total positions: {{ language.counter }} </v-card-subtitle>
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
          Salary Rate: {{ language.salaryRate.toFixed(2) }}
        </v-card-text>
        <v-card-text>
          Common job desc: {{ language.topThreeStackDescList }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  name: "CardTopThree",
  props: ["color", "language"],

  data: () => ({
    show: false,
    topPosition: 2,
  }),
};
</script>