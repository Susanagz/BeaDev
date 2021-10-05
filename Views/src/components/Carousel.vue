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
                v-for="card in slide[0].CardData"
                :key="card.title"
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
              title: "Test",
              src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
              flex: 7,
            },
            {
              title: "Test 1",
              src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
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
              title: "Test 2",
              src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
              flex: 7,
            },
            {
              title: "Test 3",
              src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
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
              title: "Test 4",
              src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
              flex: 7,
            },
            {
              title: "Test 5",
              src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
              flex: 5,
            },
          ],
        },
      ],
    ],
  }),
};
</script>
