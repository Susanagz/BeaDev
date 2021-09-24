<template>
  <v-app id="inspire">
    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="dark accent-1"
      dark
    >
      <!-- <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon> -->
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down">BeaDoc</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-tooltip right color="white">
        <template v-slot:activator="{ on }">
          <div v-on="on">
            <v-switch
              class="mt-6"
              v-model="$vuetify.theme.dark"
              v-on="on"
              color="white"
              @click="ChangeColors"
            ></v-switch>
          </div>
        </template>
        <span class="black--text">Dark mode</span>
      </v-tooltip>
      <!-- <v-btn icon>
                <v-icon>apps</v-icon>
            </v-btn> -->
      <v-btn icon color="white" @click="LogOut()">
        <v-tooltip left color="white darken-3">
          <template v-slot:activator="{ on }">
            <v-btn v-on="on" icon>
              <v-icon>logout</v-icon>
            </v-btn>
          </template>
          <span class="black--text">Log Out</span>
        </v-tooltip>
      </v-btn>
    </v-app-bar>
    <v-main>
      <v-card class="mx-auto" tile outlined>
        <v-container fluid>
          <v-row dense>
            <v-col v-for="card in cards" :key="card.title" :cols="card.flex">
              <v-card>
                <v-carousel
                  :continuous="true"
                  :cycle="cycle"
                  delimiter-icon="help"
                  height="300"
                  hide-delimiter-background
                >
                  <v-carousel-item v-for="(slide, i) in slides" :key="i">
                    <v-sheet :color="colors[i]" height="100%" tile>
                      <v-row dense class="fill-height">
                        <v-container fluid>
                          <v-row dense>
                            <v-col
                              v-for="card in cardsInCaroussel"
                              :key="card.title"
                              :cols="card.flex"
                            >
                              <v-card>
                                <v-img
                                  :src="card.src"
                                  class="white--text align-end"
                                  gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                                  height="200px"
                                >
                                  <v-card-title
                                    v-text="card.title"
                                  ></v-card-title>
                                </v-img>

                                <v-card-actions> </v-card-actions>
                              </v-card>
                            </v-col>
                          </v-row>
                        </v-container>
                        <!-- <div class="text-h2">{{ slide }} Slide</div> -->
                      </v-row>
                    </v-sheet>
                  </v-carousel-item>
                </v-carousel>
              </v-card>
            </v-col>
          </v-row>
        </v-container>
      </v-card>
    </v-main>
    <v-footer
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
//import Users from "@/components/Users";

export default {
  name: "Home",
  // components: { Users },
  data: () => ({
    activeColor: "#01579B",
    flag: false,
    drawer: null,
    colors: ["brown lighten-3", "grey lighten-1", "light-green lighten-3"],
    cycle: false,
    slides: ["First", "Second", "Third"],
    cards: [
      {
        title: "Pre-fab homes",
        src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
        flex: 12,
      },
      
    ],
    cardsInCaroussel: [
      {
        title: "Pre-fab homes",
        src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
        flex: 7,
      },
      {
        title: "Favorite road trips",
        src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
        flex: 5,
      },
    ],

    // items: [
    //   {
    //     action: "contacts",
    //     title: "Costumers",
    //     active: false,
    //     items: [{ title: "Registry", action: "recent_actors", route: "Home" }],
    //   },
    // ],
  }),
  methods: {
    LogOut: function () {
      localStorage.removeItem("jwt");
      localStorage.removeItem("user");
      this.$router.push({ name: "Login" });
    },
    ChangeColors: function () {
      this.flag = !this.flag;
      if (this.flag) {
        this.activeColor = "white";
      } else {
        this.activeColor = "#01579B";
      }
    },
  },
};
</script>
