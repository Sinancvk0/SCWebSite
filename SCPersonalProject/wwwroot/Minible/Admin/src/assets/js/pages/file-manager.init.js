/*
Template Name: Minible - Admin & Dashboard Template
Author: Themesbrand
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: file manager init js
*/

//  line chart datalabel

function getChartColorsArray(chartId) {
    if (document.getElementById(chartId) !== null) {
        var colors = document.getElementById(chartId).getAttribute("data-colors");
        if (colors) {
            colors = JSON.parse(colors);
            return colors.map(function (value) {
                var newValue = value.replace(" ", "");
                if (newValue.indexOf(",") === -1) {
                    var color = getComputedStyle(document.documentElement).getPropertyValue(newValue);
                    if (color) return color;
                    else return newValue;;
                } else {
                    var val = value.split(',');
                    if (val.length == 2) {
                        var rgbaColor = getComputedStyle(document.documentElement).getPropertyValue(val[0]);
                        rgbaColor = "rgba(" + rgbaColor + "," + val[1] + ")";
                        return rgbaColor;
                    } else {
                        return newValue;
                    }
                }
            });
        }
    }
}

 
//  Sales Statistics
var BarchartOverviewColors = getChartColorsArray("overview");
if (BarchartOverviewColors) {
var options = {
    series: [{
        data: [30, 14, 26, 32, 24]
    }],
    chart: {
        toolbar: {
            show: false,
        },
        offsetX: -14,
        offsetY: 14,
        height: 250,
        type: 'bar',
        events: {
            click: function (chart, w, e) {
            }
        }
    },

   
    plotOptions: {
        bar: {
            columnWidth: '55%',
            distributed: true,
            endingShape: 'rounded',
           
        }
    },

    fill: {
      opacity: 1,
    },

    stroke: {
      show: false, 
    },
    dataLabels: {
        enabled: false,
    },
    legend: {
        show: false
    },
    colors: BarchartOverviewColors,
    xaxis: {
        categories: ['Images', 'Video','Music','Document','Others'],
    }
};

var chart = new ApexCharts(document.querySelector("#overview"), options);
chart.render();
}