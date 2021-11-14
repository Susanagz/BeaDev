<template>
  <div id="chart">
    <apexchart
      width="100%"
      height="350"
      :options="chartOptions"
      :series="series"
      dropShadow="true"
      load
    ></apexchart>

    <v-row
      align="center"
      :justify="$vuetify.breakpoint.smAndDown ? 'center' : 'end'"
      class="mt-7"
    >
      <v-btn tile color="white" class="mx-3" @click="UpdateChart(0)">
        <v-icon left> date_range </v-icon>
        6 Months
      </v-btn>
      <v-btn tile color="white" @click="UpdateChart(1)">
        <v-icon left> date_range </v-icon>
        1 Year
      </v-btn>
    </v-row>
  </div>
</template>

<script>
import agent from "@/api/agent";

export default {
  name: "ProChart",
  data: function () {
    return {
      chartOptions: {
        responsive: [
          {
            breakpoint: 1000,
            options: {
              legend: {
                position: "bottom",
              },
            },
          },
        ],

        chart: {
          type: "area",
          stacked: false,
          animations: {
            enabled: true,
            easing: "easein",
            speed: 2400,
            animateGradually: {
              enabled: true,
              delay: 150,
            },
            dynamicAnimation: {
              enabled: true,
              speed: 1350,
            },
          },
          zoom: {
            type: "x",
            enabled: true,
            autoScaleYaxis: true,
          },
          toolbar: {
            autoSelected: "zoom",
          },
          dropShadow: {
            enabled: true,
            color: "#000",
            top: 18,
            left: 7,
            blur: 6,
            opacity: 0.1,
          },
        },

        dataLabels: {
          enabled: false,
        },
        markers: {
          size: 6,
          hover: {
            size: 9,
          },
        },
        // colors:['purple', 'blue', 'yellow'],
        fill: {
          type: "gradient",
          gradient: {
            shadeIntensity: 1,
            inverseColors: false,
            opacityFrom: 0.5,
            opacityTo: 0,
            stops: [0, 90, 100],
          },
        },
        stroke: {
          curve: "straight",
        },
        tooltip: {
          shared: false,
        },
        xaxis: {
          categories: [],
        },
        yaxis: {
          title: {
            text: "Job Vacancies",
          },
        },
        noData: {
          text: "Loading...",
        },
      },
      series: [
        {
          name: "C#",
          data: [],
        },
        {
          name: "Python",
          data: [],
        },
        {
          name: "JavaScript",
          data: [],
        },
      ],
      Months: [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "Octuber",
        "Nomvember",
        "Dicember",
      ],
    };
  },

  methods: {
    UpdateChart(flag) {
      agent.ProgrammingLanguageChart.list()
        .then((response) => {
          this.chartOptions = {
            ...this.chartOptions,
            ...{
              xaxis: {
                categories: !flag
                  ? (this.chartOptions.xaxis.categories = this.Months.slice(
                      0,
                      this.Months / 2
                    ))
                  : (this.chartOptions.xaxis.categories = this.Months),
              },
            },
          };

          this.series[0].data = !flag
            ? response.data.a01
                .map((a) => a.totalOffers)
                .splice(0, this.Months.length / 2)
            : response.data.a01.map((a) => a.totalOffers);

          this.series[1].data = !flag
            ? response.data.a02
                .map((a) => a.totalOffers)
                .splice(0, this.Months.length / 2)
            : response.data.a02.map((a) => a.totalOffers);

          this.series[2].data = !flag
            ? response.data.a03
                .map((a) => a.totalOffers)
                .splice(0, this.Months.length / 2)
            : response.data.a03.map((a) => a.totalOffers);
        })
        .catch(() => console.error())
        .finally(() => (this.requestStatus = false));
    },
  },

  created() {
    this.UpdateChart(0);
  },
};
</script>

<style>
#chart {
  max-width: 950px;
  width: auto;
  margin: 35px auto;
  opacity: 0.9;
}
</style>