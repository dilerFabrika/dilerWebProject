/** Uretim Grafikleri icin */
$(function () {
    var tonajlar;
    var ajax_istegi = 0;

    $.aylik_grafikler = function () {
        if (ajax_istegi == 0) {
            ajax_istegi = 1;/** ayni anda 1'den fazla ajax istegi almamak icin */
            var liste = [];
            var toplam = 0.0;
            $.ajax({
                type: 'POST',
                url: 'Default.aspx/tonaj_verileri_getir',
                data: '{}',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    var data = result.d;
                    tonajlar = $.parseJSON(data);
                    $.each(tonajlar, function (key, value) {
                        value.tonaj = parseFloat(value.tonaj.replace(',', '.'));
                        //alert(value.ay + "->" + value.tonaj);
                    });
                },
                error: function () {
                    alert("Oops!");
                }, complete: function () {
                    ajax_istegi = 0;
                    var i = 0;
                    var date = new Date();
                    var yil = date.getFullYear();
                    var chart = new CanvasJS.Chart("chartContainer",
                    {
                        title: {
                            text: ""
                        },
                        animationEnabled: true,
                        axisY: {
                            title: "",
                            includeZero: false
                        },
                        axisX: {
                            title: yil + "",
                            interval: 1
                        },
                        toolTip: {
                            shared: true,
                            content: function (e) {
                                var body = new String;
                                var head;
                                for (var i = 0; i < e.entries.length; i++) {
                                    var str = "<span style= 'color:" + e.entries[i].dataSeries.color + "'> " + e.entries[i].dataSeries.name + "</span>: <strong>" + e.entries[i].dataPoint.y + "</strong> <br/>";
                                    body = body.concat(str);
                                }
                                head = "<span style = 'color:DodgerBlue; '><strong>" + (e.entries[0].dataPoint.label) + "</strong></span><br/>";

                                return (head.concat(body));
                            }
                        },
                        legend: {
                            horizontalAlign: "center"
                        },
                        data: [
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Diler",
                            dataPoints: [
                            { label: "Oca", y: tonajlar[i++].tonaj },
                            { label: "Şub", y: tonajlar[i++].tonaj },
                            { label: "Mar", y: tonajlar[i++].tonaj },
                            { label: "Nis", y: tonajlar[i++].tonaj },
                            { label: "May", y: tonajlar[i++].tonaj },
                            { label: "Haz", y: tonajlar[i++].tonaj },
                            { label: "Tem", y: tonajlar[i++].tonaj },
                            { label: "Ağu", y: tonajlar[i++].tonaj },
                            { label: "Eyl", y: tonajlar[i++].tonaj },
                            { label: "Eki", y: tonajlar[i++].tonaj },
                            { label: "Kas", y: tonajlar[i++].tonaj },
                            { label: "Ara", y: tonajlar[i++].tonaj }
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Yazıcı",
                            dataPoints: [
                            { label: "Oca", y: tonajlar[i++].tonaj },
                            { label: "Şub", y: tonajlar[i++].tonaj },
                            { label: "Mar", y: tonajlar[i++].tonaj },
                            { label: "Nis", y: tonajlar[i++].tonaj },
                            { label: "May", y: tonajlar[i++].tonaj },
                            { label: "Haz", y: tonajlar[i++].tonaj },
                            { label: "Tem", y: tonajlar[i++].tonaj },
                            { label: "Ağu", y: tonajlar[i++].tonaj },
                            { label: "Eyl", y: tonajlar[i++].tonaj },
                            { label: "Eki", y: tonajlar[i++].tonaj },
                            { label: "Kas", y: tonajlar[i++].tonaj },
                            { label: "Ara", y: tonajlar[i++].tonaj }
                            ]
                        }
                        ],
                        legend: {
                            cursor: "pointer",
                            itemclick: function (e) {
                                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                    e.dataSeries.visible = false;
                                }
                                else {
                                    e.dataSeries.visible = true;
                                }
                                chart.render();
                            }
                        }

                    });
                    chart.render();
                    $("a.canvasjs-chart-credit").remove();

                    /** Haddehane */
                    var chart2 = new CanvasJS.Chart("chartContainer-2",
                    {
                        title: {
                            text: ""
                        },
                        animationEnabled: true,
                        axisY: {
                            title: "",
                            includeZero: false
                        },
                        axisX: {
                            title: yil + "",
                            interval: 1
                        },
                        toolTip: {
                            shared: true,
                            content: function (e) {
                                var body = new String;
                                var head;
                                for (var i = 0; i < e.entries.length; i++) {
                                    var str = "<span style= 'color:" + e.entries[i].dataSeries.color + "'> " + e.entries[i].dataSeries.name + "</span>: <strong>" + e.entries[i].dataPoint.y + "</strong> <br/>";
                                    body = body.concat(str);
                                }
                                head = "<span style = 'color:DodgerBlue; '><strong>" + (e.entries[0].dataPoint.label) + "</strong></span><br/>";

                                return (head.concat(body));
                            }
                        },
                        legend: {
                            horizontalAlign: "center"
                        },
                        data: [
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Diler",
                            dataPoints: [
                            { label: "Oca", y: tonajlar[i++].tonaj },
                            { label: "Şub", y: tonajlar[i++].tonaj },
                            { label: "Mar", y: tonajlar[i++].tonaj },
                            { label: "Nis", y: tonajlar[i++].tonaj },
                            { label: "May", y: tonajlar[i++].tonaj },
                            { label: "Haz", y: tonajlar[i++].tonaj },
                            { label: "Tem", y: tonajlar[i++].tonaj },
                            { label: "Ağu", y: tonajlar[i++].tonaj },
                            { label: "Eyl", y: tonajlar[i++].tonaj },
                            { label: "Eki", y: tonajlar[i++].tonaj },
                            { label: "Kas", y: tonajlar[i++].tonaj },
                            { label: "Ara", y: tonajlar[i++].tonaj }
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Yazıcı",
                            dataPoints: [
                            { label: "Oca", y: tonajlar[i++].tonaj },
                            { label: "Şub", y: tonajlar[i++].tonaj },
                            { label: "Mar", y: tonajlar[i++].tonaj },
                            { label: "Nis", y: tonajlar[i++].tonaj },
                            { label: "May", y: tonajlar[i++].tonaj },
                            { label: "Haz", y: tonajlar[i++].tonaj },
                            { label: "Tem", y: tonajlar[i++].tonaj },
                            { label: "Ağu", y: tonajlar[i++].tonaj },
                            { label: "Eyl", y: tonajlar[i++].tonaj },
                            { label: "Eki", y: tonajlar[i++].tonaj },
                            { label: "Kas", y: tonajlar[i++].tonaj },
                            { label: "Ara", y: tonajlar[i++].tonaj }
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Filmaşin",
                            dataPoints: [
                            { label: "Oca", y: tonajlar[i++].tonaj },
                            { label: "Şub", y: tonajlar[i++].tonaj },
                            { label: "Mar", y: tonajlar[i++].tonaj },
                            { label: "Nis", y: tonajlar[i++].tonaj },
                            { label: "May", y: tonajlar[i++].tonaj },
                            { label: "Haz", y: tonajlar[i++].tonaj },
                            { label: "Tem", y: tonajlar[i++].tonaj },
                            { label: "Ağu", y: tonajlar[i++].tonaj },
                            { label: "Eyl", y: tonajlar[i++].tonaj },
                            { label: "Eki", y: tonajlar[i++].tonaj },
                            { label: "Kas", y: tonajlar[i++].tonaj },
                            { label: "Ara", y: tonajlar[i++].tonaj }
                            ]
                        }
                        ],
                        legend: {
                            cursor: "pointer",
                            itemclick: function (e) {
                                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                    e.dataSeries.visible = false;
                                }
                                else {
                                    e.dataSeries.visible = true;
                                }
                                chart.render();
                            }
                        }

                    });
                    chart2.render();
                    $("a.canvasjs-chart-credit").remove();

                }
            });

        } else {
            alert("Şu an çalışan bir istek var.");
        }
    }

    $.yillik_grafikler = function () {
        if (ajax_istegi == 0) {
            ajax_istegi = 1;/** ayni anda 1'den fazla ajax istegi almamak icin */
            var liste = [];
            var toplam = 0.0;
            $.ajax({
                type: 'POST',
                url: 'Default.aspx/yillik_tonaj_verileri_getir',
                data: '{}',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    var data = result.d;
                    tonajlar = $.parseJSON(data);
                    $.each(tonajlar, function (key, value) {
                        value.tonaj = parseFloat(value.tonaj.replace(',', '.'));
                        //alert(value.ay + "->" + value.tonaj);
                    });
                },
                error: function () {
                    alert("Oops!");
                }, complete: function () {
                    ajax_istegi = 0;
                    var i = 0;
                    var date = new Date();
                    var yil = date.getFullYear();
                    var chart = new CanvasJS.Chart("chartContainer",
                    {
                        title: {
                            text: ""
                        },
                        animationEnabled: true,
                        axisY: {
                            title: "",
                            includeZero: false
                        },
                        axisX: {
                            title: "",
                            interval: 1
                        },
                        toolTip: {
                            shared: true,
                            content: function (e) {
                                var body = new String;
                                var head;
                                for (var i = 0; i < e.entries.length; i++) {
                                    var str = "<span style= 'color:" + e.entries[i].dataSeries.color + "'> " + e.entries[i].dataSeries.name + "</span>: <strong>" + e.entries[i].dataPoint.y + "</strong> <br/>";
                                    body = body.concat(str);
                                }
                                head = "<span style = 'color:DodgerBlue; '><strong>" + (e.entries[0].dataPoint.label) + "</strong></span><br/>";

                                return (head.concat(body));
                            }
                        },
                        legend: {
                            horizontalAlign: "center"
                        },
                        data: [
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Diler",
                            dataPoints: [
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj }
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Yazıcı",
                            dataPoints: [
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj }

                            ]
                        }
                        ],
                        legend: {
                            cursor: "pointer",
                            itemclick: function (e) {
                                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                    e.dataSeries.visible = false;
                                }
                                else {
                                    e.dataSeries.visible = true;
                                }
                                chart.render();
                            }
                        }

                    });
                    chart.render();
                    $("a.canvasjs-chart-credit").remove();

                    /** Haddehane */
                    var chart2 = new CanvasJS.Chart("chartContainer-2",
                    {
                        title: {
                            text: ""
                        },
                        animationEnabled: true,
                        axisY: {
                            title: "",
                            includeZero: false
                        },
                        axisX: {
                            title: yil + "",
                            interval: 1
                        },
                        toolTip: {
                            shared: true,
                            content: function (e) {
                                var body = new String;
                                var head;
                                for (var i = 0; i < e.entries.length; i++) {
                                    var str = "<span style= 'color:" + e.entries[i].dataSeries.color + "'> " + e.entries[i].dataSeries.name + "</span>: <strong>" + e.entries[i].dataPoint.y + "</strong> <br/>";
                                    body = body.concat(str);
                                }
                                head = "<span style = 'color:DodgerBlue; '><strong>" + (e.entries[0].dataPoint.label) + "</strong></span><br/>";

                                return (head.concat(body));
                            }
                        },
                        legend: {
                            horizontalAlign: "center"
                        },
                        data: [
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Diler",
                            dataPoints: [
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Yazıcı",
                            dataPoints: [
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            ]
                        },
                        {
                            type: "spline",
                            showInLegend: true,
                            name: "Filmaşin",
                            dataPoints: [
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            { label: tonajlar[i].yil, y: tonajlar[i++].tonaj },
                            ]
                        }
                        ],
                        legend: {
                            cursor: "pointer",
                            itemclick: function (e) {
                                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                    e.dataSeries.visible = false;
                                }
                                else {
                                    e.dataSeries.visible = true;
                                }
                                chart.render();
                            }
                        }

                    });
                    chart2.render();
                    $("a.canvasjs-chart-credit").remove();

                }
            });

        } else {
            alert("Şu an çalışan bir istek var.");
        }
    }

    $.aylik_grafikler();// ilk acilista aylik grafikler acilsin.

    $("a.grafik_degis").click(function () {
        var title = $(this).attr("title");

        if (title == "Yıllık") {
            $("a.grafik_degis").attr("title", "Aylık");
            $.yillik_grafikler();

        } else if (title == "Aylık") {
            $("a.grafik_degis").attr("title", "Yıllık");
            $.aylik_grafikler();
        }

    });

    $(window).resize(function () {
        setTimeout(function () {
            $("a.canvasjs-chart-credit").remove();
        }, 10)

    });

});