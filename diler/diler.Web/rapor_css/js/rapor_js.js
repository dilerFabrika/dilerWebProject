$(function () {

    /** Durus ayrintilari icin */

  

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