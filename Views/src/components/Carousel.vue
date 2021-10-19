<template>
  <v-carousel
    :continuous="true"
    :cycle="cycle"
    :hide-delimiters="true"
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
                <v-card :color="slide[0].Color" height="270px">
                  <template v-if="!card.src">
                    <v-row>
                      <v-col align-self="center">
                        <v-card class="pa-2" outlined tile>
                          What is BeaDev?
                        </v-card>
                        <v-card-subtitle
                          :class="
                            !$vuetify.breakpoint.smAndDown
                              ? 'subtitle-1 black--text'
                              : 'black--text'
                          "
                          v-text="
                            $vuetify.breakpoint.smAndDown
                              ? card.minTitle
                              : card.title
                          "
                        ></v-card-subtitle>
                      </v-col>
                    </v-row>
                  </template>
                  <template v-else>
                    <v-img :src="card.src" class="align-end" height="270px" />
                  </template>
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
              title:
                "Is a website that will encourage you to take the next step by learning the trendiest programming language based in job offers statistics.",
              minTitle:
                "Is a website that will encourage you to learn the trendiest programming language.",
              src: "",
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
              title:
                "You can check the top 3 of the programming languages ​​with the greatest demand in the Jalisco labor market.",
              minTitle:
                " dsadsad",
              src: "",
              flex: 7,
            },
            {
              title: "also You can find the 3 most demanded frameworks along with the average salary that represents learning or mastering these languages",
              src: "",
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
              title: "Likewise, you will find estimated projections of 6 months and 1 year about the demand of this languages ​​and frameworks.",
              src: "",
              flex: 7,
            },
            {
              title: " ",
              src: "",
              flex: 5,
            },
          ],
        },
      ],
    ],
  }),
};
</script>
