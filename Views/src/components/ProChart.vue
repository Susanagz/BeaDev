<template>
  <div id="chart">
    <apexchart
      width="100%"
      height="350"
      :options="chartOptions"
      :series="series"
      dropShadow="true"
    ></apexchart>

    <v-row
      align="center"
      :justify="$vuetify.breakpoint.smAndDown ? 'center' : 'end'"
      class="mt-7"
    >
      <v-btn tile color="white" class="mx-3">
        <v-icon left> date_range </v-icon>
        6 Months
      </v-btn>
      <v-btn tile color="white">
        <v-icon left> date_range </v-icon>
        1 Year
      </v-btn>
    </v-row>
  </div>
</template>

<script>
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
          categories: ["January", "February", "March", "April", "May", "June"],
        },
        yaxis: {
          title: {
            text: "Job Vacancies",
          },
        },
      },
      series: [
        {
          name: "C#",
          data: [30, 40, 35, 50, 49, 90],
        },
        {
          name: "Python",
          data: [20, 10, 25, 40, 69, 30],
        },
        {
          name: "JavaScript",
          data: [15, 19, 65, 20, 39, 70],
        },
      ],
    };
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