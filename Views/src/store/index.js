import Vue from 'vue';
import Vuex from 'vuex';
import { HubConnectionBuilder } from "@aspnet/signalr";
import axios from "axios";

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    connection: {},
    topThreePL: [
      {
        position: 0,
        counter: 0,
        name: "",
        salaryRate: 0,
        topThreeStackDescList: "",
      },
      {
        position: 0,
        counter: 0,
        name: "",
        salaryRate: 0,
        topThreeStackDescList: "",
      },
      {
        position: 0,
        counter: 0,
        name: "",
        salaryRate: 0,
        topThreeStackDescList: "",
      }
    ],
  },
  mutations: {
    ConnectSignalR() {
      this.state.connection = new HubConnectionBuilder()
        .withUrl(`${axios.defaults.baseURL}/Hubs/ProgrammingLanguages`)
        .build();

      this.state.connection
        .start()
        .then(() => console.log("connected"))
        .catch((err) => console.error("Failed to connect with hub", err));

      this.state.connection.on("Receive", (programmingLanguage) => {
        this.state.topThreePL = programmingLanguage;
      });
    },
  },

  actions: {

  },
  modules: {
  }
  
})
