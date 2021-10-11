<template>
  <v-card class="pa-2" shaped :elevation="4" max-width="260">
    <v-img
      src="https://1.bp.blogspot.com/-G_oYeB6RQwc/YV992v5A7bI/AAAAAAAAAg8/jBWfbcWNNqMI1RmQr02qVsoBZtzty-viwCNcBGAsYHQ/s1600/Lenguaje_programacion.png"
      height="180px"
    ></v-img>
    <v-card-title> C# </v-card-title>
    <v-card-subtitle>Net 5</v-card-subtitle>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn icon @click="show = !show">
        <v-icon>{{ show ? "expand_less" : "expand_more" }}</v-icon>
      </v-btn>
    </v-card-actions>
    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>
        <v-card-text> hgfhfhgs </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  name: "CardTopThree",
  data: () => ({
    show: false,
  }),
};
</script>