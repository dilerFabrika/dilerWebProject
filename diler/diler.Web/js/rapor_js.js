$(function () {

    /** Durus ayrintilari icin */
    var ajax_istegi = 0;
    $("a.durus_ayrintisi_getir").click(function () {
        if (ajax_istegi == 0) {
            ajax_istegi = 1;/** ayni anda 1'den fazla ajax istegi almamak icin */

            var tarih = $("input[name=tx_rapor_tarihi]").val().replace(/\-/g, '');
            var bilgi = $(this).data("bilgi").split(';');

            $.ajax({
                type: 'POST',
                url: 'Default.aspx/durus_ayrinti_getir',
                data: '{"tarih":"' + tarih + '","durus_tipi":"' + bilgi[0] + '","firma":"' + bilgi[1] + '","unite":"' + bilgi[2] + '"}',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    $('table.tbl_durus_ayrintisi>tbody').html("").html(result.d);
                },
                error: function () {
                    alert("Oops!");
                }, complete: function () {
                    ajax_istegi = 0;
                }
            });
        } else {
            alert("Şu an çalışan bir istek var.");
        }
    });

    /** $('#masonry-content').masonry({
         // set itemSelector so .grid-sizer is not used in layout
         itemSelector: '.masonry-content',
         // use element for option
         columnWidth: '.masonry-content',
         percentPosition: true
     });*/

    $("div.table-responsive .table tbody tr").filter(":even").css("background-color", "#e5f4f9");

    /*var tarih = new Date();
     var ay = tarih.getMonth() + 1;
     var gun = tarih.getDate();
     var yil = tarih.getFullYear();
     var bu_gun = yil + '-' + (ay < 10 ? '0' : '') + ay + '-' + (gun < 10 ? '0' : '') + gun;

     document.getElementById("tx_rapor_tarihi").value = bu_gun;*/

    $(".tarih_onceki").click(function () {
        document.getElementById("tx_rapor_tarihi").stepDown(1);
        $("#tx_rapor_tarihi").trigger("change");
    });
    $(".tarih_sonraki").click(function () {
        document.getElementById("tx_rapor_tarihi").stepUp(1);
        $("#tx_rapor_tarihi").trigger("change");
    });

    /** var c_url = window.location.pathname;
     $("select[name=ddl_menu]>option").each(function (key, value) {
         var t = $(this);
         if (t.val() == c_url.split("/").join("")) {
             t.prop("selected", true);
         }
     });

     $("select[name=ddl_menu]").change(function () {
         var url = $(this).val();
         window.location.href = url;
     });*/

    /**$(document).one("mouseover", "body", function () {
        var tx = $(".focus-btn-group .btn").html().split("Focus");
        $(".focus-btn-group .btn").html(tx[0]);

        $(".btn").each(function (index) {
            if ($(this).text() == "Display all") {
                $(this).remove();
            }
        });

    });*/


});