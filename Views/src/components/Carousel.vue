<template>
  <v-carousel
    :continuous="true"
    :cycle="cycle"
    :hide-delimiters = "true"
    height="300"
    hide-delimiter-background
  >
    <v-carousel-item v-for="(slide, i) in slides" :key="i">
      <v-sheet color="white" height="100%" tile>
        <v-row dense class="fill-height">
          <v-container fluid>
            <v-row dense>
              <v-col
                v-for="(card, i) in slide[0].CardData"
                :key="i"
                :cols="card.flex"
              >
                <v-card>
                  <v-img
                    :src="card.src"
                    class="white--text align-end"
                    gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                    height="250px"
                  >
                    <v-card-title v-text="card.title"></v-card-title>
                  </v-img>
                  <v-card-actions> </v-card-actions>
                </v-card>
              </v-col>
            </v-row>
          </v-container>
        </v-row>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>
</template>

<script>
export default {
  name: "Carousel",
  data: () => ({
    cycle: false,
    slides: [
      [
        {
          Color: "white",
          CardData: [
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-Z3PW6kIL1TU/YWHneoDu3TI/AAAAAAAAAjo/_eNdNJ1hlR0Ooibv0cLMLy81xEMR98ffgCNcBGAsYHQ/s1600/6.png",
              flex: 7,
            },
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-HTDrUAN2FLo/YWHnlLRFeNI/AAAAAAAAAjs/nh3FIl1y2YYPA0XXefJQKf2XS7dLgaDLgCNcBGAsYHQ/s1600/1.png",
              flex: 5,
            },
          ],
        },
      ],
      [
        {
          Color: "white",
          CardData: [
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-zM0ldMwS3ts/YWHnqwIj3sI/AAAAAAAAAjw/Ui_8fDLAWzwP8daHCqpYkQYNDvKBiatkQCNcBGAsYHQ/s1600/2.png",
              flex: 7,
            },
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-VPzXO6fh7Xk/YWHnwL0N99I/AAAAAAAAAj4/6gTwe40xjgwv9EZrVihH31J06YGSESKoACNcBGAsYHQ/s1600/3.png",
              flex: 5,
            },
          ],
        },
      ],
      [
        {
          Color: "white",
          CardData: [
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-9E0P29rMSCk/YWHn29c-wVI/AAAAAAAAAkA/TW667nsKCBM8vTqohHqaLK4keT0tTWhEACNcBGAsYHQ/s1600/4.png",
              flex: 7,
            },
            {
              title: " ",
              src: "https://1.bp.blogspot.com/-VR0KbTP6wOw/YWHn9CCy1YI/AAAAAAAAAkE/Xz3TYriaSFQ1tp9EpnfMvcQu5MM3yuLTACNcBGAsYHQ/s1600/5.png",
              flex: 5,
            },
          ],
        },
      ],
    ],
  }),
};
</script>
