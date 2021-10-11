<template>
  <v-container>
    <GChart
      type="ColumnChart"
      :data="chartData"
      :options="chartOptions"
      @ready="onChartReady"
      ref="gChart"
    />
    <v-row align="center" justify="end" class="mt-5">
      <v-btn tile color="white" class="mx-3">
        <v-icon left> date_range </v-icon>
        6 Months
      </v-btn>
      <v-btn tile color="white">
        <v-icon left> date_range </v-icon>
        1 Year
      </v-btn>
    </v-row>
  </v-container>
</template>

<script>
import { GChart } from "vue-google-charts";
export default {
  name: "App",
  components: {
    GChart,
  },
  data() {
    return {
      chartData: null, // the chartData will be created once Chart is ready (needs google charts lib for this)
      chartOptions: {
        title: "Top 3 Programming Languages!",
      },
    };
  },

  methods: {
    onChartReady(chart, google) {
      // now we have google lib loaded. Let's create data table based using it.
      this.createDataTable(chart, google);
      //console.log(this.chartData);
    },
    createDataTable(chart, google) {
      var data = google.visualization.arrayToDataTable([
        ["Language", "Job Offers"],
        ["C#", 8],
        ["Python", 10],
        ["Php", 19],
      ]);

      var view = new google.visualization.DataView(data);
      view.setColumns([
        0,
        1,
        {
          calc: "stringify",
          sourceColumn: 1,
          type: "string",
          role: "annotation",
        },
      ]);

      //this.chartData = data;
      chart.draw(view, this.chartOptions);
      //this.chartData = data;
    },
  },
};
</script>
