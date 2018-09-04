
/**
* Theme: Moltran Admin Template
* Author: Coderthemes
* Morris Chart
*/

!function($) {
    "use strict";

    var MorrisCharts = function() {};

    //creates line chart
    MorrisCharts.prototype.createLineChart = function(element, data, xkey, ykeys, labels, lineColors) {
        Morris.Line({
          element: element,
          data: data,
          xkey: xkey,
          ykeys: ykeys,
          labels: labels,
          resize: true, //defaulted to true
          lineColors: lineColors
        });
    },
    MorrisCharts.prototype.init = function() {

        /**
        //create line chart
        var $data  = [
            { y: '2009', a: 100, b: 90 },
            { y: '2010', a: 75,  b: 65 },
            { y: '2011', a: 50,  b: 40 },
            { y: '2012', a: 75,  b: 65 },
            { y: '2013', a: 50,  b: 40 },
            { y: '2014', a: 75,  b: 65 },
            { y: '2015', a: 100, b: 90 }
          ];
          */
        var $data = [
            { y: '1', a: 100, b: 90 },
            { y: '2', a: 75, b: 65 },
            { y: '3', a: 50, b: 40 },
            { y: '4', a: 75, b: 65 },
            { y: '5', a: 50, b: 40 },
            { y: '6', a: 75, b: 65 },
            { y: '7', a: 100, b: 90 },
            { y: '8', a: 75, b: 65 },
            { y: '9', a: 50, b: 40 },
            { y: '10', a: 75, b: 65 },
            { y: '11', a: 20, b: 60 },
            { y: '12', a: 75, b: 65 }
        ];
        this.createLineChart('morris-line-example', $data, 'y', ['a', 'b'], ['Series A', 'Series B'], ['#317eeb', '#999999']);
        var $data2 = [
            { y: '1', a: 90, b: 100 },
            { y: '2', a: 45, b: 10 },
            { y: '3', a: 50, b: 40 },
            { y: '4', a: 75, b: 65 },
            { y: '5', a: 50, b: 40 },
            { y: '6', a: 75, b: 65 },
            { y: '7', a: 10, b: 10 },
            { y: '8', a: 75, b: 65 },
            { y: '9', a: 50, b: 40 },
            { y: '10', a: 75, b: 65 },
            { y: '11', a: 20, b: 60 },
            { y: '12', a: 75, b: 65 }
        ];
        this.createLineChart('morris-line-example-2', $data2, 'y', ['a', 'b'], ['Series A', 'Series B'], ['#317eeb', '#999999']);
    },
    //init
    $.MorrisCharts = new MorrisCharts, $.MorrisCharts.Constructor = MorrisCharts
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.MorrisCharts.init();
}(window.jQuery);