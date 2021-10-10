<template>
<v-sheet outlined color="blue-grey lighten-3" rounded>

  <v-card shaped :elevation=4 loading dark max-width="260">
    <v-img
      src="https://1.bp.blogspot.com/-G_oYeB6RQwc/YV992v5A7bI/AAAAAAAAAg8/jBWfbcWNNqMI1RmQr02qVsoBZtzty-viwCNcBGAsYHQ/s1600/Lenguaje_programacion.png"
      height="180px"
    ></v-img>

    <v-card-title> ¿Que es BeaDev? </v-card-title>

    <v-card-subtitle>------</v-card-subtitle>

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
         hgfhfhgs
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
  </v-sheet>
</template>

<script>
export default {
  name: "CardTopThree",
  data: () => ({
    show: false,
  }),
};
</script>