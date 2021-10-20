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
                          {{card.header}}
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
              src: "https://1.bp.blogspot.com/-D9q1THjJLIE/YXBa4n4wjOI/AAAAAAAAAmU/KDdoensgP7IF2jZMoVa-TTwg0PxBh6KFACNcBGAsYHQ/s1600/p.png",
              flex: 5,
            },
            {
              header: "what is beadev?",
              title: "Is a website that will encourage you to take the next step by learning the trendiest programming language based in job offers statistics.",
              minTitle:"Is a website that will encourage you to learn the trendiest programming language.",
              src: "",
              flex: 7,
            },
          ],
        },
      ],
      [
        {
          Color: "white",
          CardData: [
            {
              header: "Programming languages",
              title:"You can check the top 3 of the programming languages ​​with the greatest demand in the Jalisco labor market.",
              minTitle:"Top 3 of the programming languages",
              src: "",
              flex: 4,
            },
            {
              title: "",
              src: "https://1.bp.blogspot.com/-AE13UPPPmcs/YXBbpZqKc-I/AAAAAAAAAmc/qnM6qDR4Om8kQeOJ9XvKnG0rkSM__XcoACNcBGAsYHQ/s1600/o.png",
              flex: 4,
            },
            {
              header: "Most in-demand frameworks",
              title:"You can find the 3 most demanded frameworks along with the average salary that represents learning or mastering these languages.",
              minTitle:"find the 3 most demanded frameworks",
              src: "",
              flex: 4,
            },
          ],
        },
      ],
      [
        {
          Color: "white",
          CardData: [
            {
              title: "",
              src: "https://1.bp.blogspot.com/-QEM7IUp5h_g/YXBgMRoLpZI/AAAAAAAAAm0/kudWpp4cDc4pConlHqj0WlJcXR5zL3s2QCNcBGAsYHQ/s1600/k.png",
              flex: 3,
            },
            {
              header: "Projections",
              title: "Likewise, you will find estimated projections of 6 months and 1 year about the demand of this languages ​​and frameworks.",
              minTitle: "Projections of 6 months and 1 year about the demand of this languages ​​and frameworks",
              src:"",
              flex: 6,
            },
            {
              title: "",
              src: "https://1.bp.blogspot.com/-CeXZg_2lQcY/YXBekhEGo0I/AAAAAAAAAms/Ut_5zIeAOps_d2q269uKVyFaAIv55LPUACNcBGAsYHQ/s1600/g.png",
              flex: 3,
            },
          ],
        },
      ],
    ],
  }),
};
</script>
