﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformansRapor.aspx.cs" Inherits="diler.Web.Forms.IK.PerformansRapor" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Diler Demir Çelik Mesai Programı</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <!-- Base Css Files -->
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Icons -->
    <link href="../../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />
    <!-- animate css -->
    <link href="../../css/animate.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="../../css/waves-effect.css" rel="stylesheet" />
    <!-- Responsive-table -->
    <link href="../../assets/responsive-table/rwd-table.min.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- Custom Files -->
    <link href="../../.css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/rapor_style.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->

    <script src="../../js/modernizr.min.js"></script>
    <style type="text/css">
        .auto-style18 {
            width: 473px;
        }
        .auto-style19 {
            text-align: left;
            width: 468px;
            height: 39px;
        }
        .auto-style20 {
            margin-top: 0;
            margin-bottom: 0;
            font-size: 21px;
            color: inherit;
        }
    </style>
</head>
<body>
    <!-- Start content -->
    <div class="content">
        <!-- Start container -->
        <div class="container">
            <form id="form_rapor" method="post" runat="server">
                <!-- Page-Title -->
                <div class="row icon-list" style="padding: 5px 0; padding-bottom: 0;">
                    <div class="col-sm-4">
                        <div class="col-md-3 ">
                            <!--
                            <ul class="nav navbar-nav">
                                <li class="dropdown">
                                    <a href="javascript:void(0)" data-toggle="dropdown" class="dropdown-toggle">Menu <b class="caret"></b></a>
                                    <ul class="dropdown-menu dropdown-menu-left">
                                        <li><a href="Default.aspx">Ana Sayfa</a></li>
                                        <li><a href="DilerCelikhaneRapor.aspx">Çelikhaneler</a></li>
                                        <li><a href="HaddehaneRapor.aspx">Haddehaneler</a></li>
                                        <li><a href="FilmasinRapor.aspx">Filmaşin</a></li>
                                        <li><a href="OrtakRapor.aspx">Ortak Rapor</a></li>
                                        <li><a href="KarsilastirmalarRaporu.aspx">Karşılaştırmalar Raporu</a></li>
                                        <li><a href="CHTonajlari.aspx">CH Tonajları</a></li>
                                        <li><a href="HHTonajlari.aspx">HH Tonajları</a></li>
                                    </ul>
                                </li>
                            </ul>
                            -->
                        </div>
                    </div>
                    <div class="col-sm-4">
                    </div>
                    <div class="col-sm-4">
                        <div class="col-sm-12 text-right">
                            <asp:LinkButton ID="lb_cikis" runat="server" OnClick="lb_cikis_Click" CssClass="btn btn-danger">Sistemden Çıkış</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="tablolar panel panel-border panel-primary">
                    <div class="panel-heading" style="margin-bottom: 10px;">
                        <h3 class="auto-style20" style="text-align: center; ">PERFORMANS GENEL RAPORU</h3>
                        <asp:Label ID="lbl_giris_yapan" runat="server" Text="">
                        Programa Giriş Yapan <font color="red">...</font> Sicil Numaralı ... <font color="3752F9">...</font> ...
                        </asp:Label>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                    </div>
                </div>

                <div class="col-sm-12">
                    <table id="t" class=" table table-responsive" style="height: 27px">
                        <tbody>
                            <tr>
                                <td style="border-style: none; border-color: inherit; border-width: medium;" class="auto-style18">
                        <div class="auto-style19">
                            Yılı ve
                            Bağlı biriminizi Seçin ...<asp:DropDownList ID="YILx" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bagli_birim_SelectedIndexChanged">
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                            </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="ddl_bagli_birim0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bagli_birim_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="all">Tümü</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                                </td>
                                <td style="width: 65px; border: none">
                                    &nbsp;</td>
                                <td style="vertical-align: middle; text-align: left;">
                                    &nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="col-sm-12">
                    <div class="col-sm-8">
                        <div class="panel">
                            <div class="col-md-12" style="margin-right: 0; padding: 0;">
                                <div class="panel-body table-rep-plugin table-rapor">
                                    <p class="tbl_baslik" style="background-color: #1e88e5; color: #FFF;">
                                        Mesaisi Girilen Personel Listesi
                                        <asp:LinkButton ID="btn_personel_ayrinti_getir" runat="server" AutoPostBack="false"  Style="display: none">Getir</asp:LinkButton>
                                        <asp:LinkButton ID="lb_aylik_mesaileri_getir" runat="server"  Style="display: none;">aylik</asp:LinkButton>
                                    </p>
                                    <div class="table-responsive" data-pattern="priority-columns">
                                        <table id="example" class="table table-small-font table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>&nbsp;</th>
                                                    <th>S. No</th>
                                                    <th>Adı Soyadı</th>
                                                    <th>Bölümü</th>

                                                    <th></th>
                                                    <%

                                                        for (int i = 1; i <= 12; i++)
                                                        {
                                                            Response.Write("<th><a href=\"javascript:__doPostBack('lb_aylik_mesaileri_getir','" + i + "')\" title=\"Aylık Mesaileri Getir\">" + i + "</a></th>");
                                                        }

                                                    %>

                                                    <th>Yıl</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder ID="ph_personel_listesi" runat="server"></asp:PlaceHolder>
                                            </tbody>

                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                    </div>
                    <div class="clear"></div>
                </div>
                <!-- end row -->
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
    <script>
        var resizefunc = [];
    </script>
    <!-- jQuery  -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../js/waves.js" type="text/javascript"></script>
    <script src="../../js/wow.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src=../../"js/jquery.scrollTo.min.js" type="text/javascript"></script>
    <script src=../../"assets/jquery-detectmobile/detect.js" type="text/javascript"></script>
    <script src="../../assets/fastclick/fastclick.js" type="text/javascript"></script>
    <script src="../../assets/jquery-slimscroll/jquery.slimscroll.js" type="text/javascript"></script>
    <script src="../../assets/jquery-blockui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../js/masonry.js" type="text/javascript"></script>
    <!-- CUSTOM JS -->
    <script src="../../js/jquery.app.js" type="text/javascript"></script>

    <!-- responsive-table 
    <script src="assets/responsive-table/rwd-table.min.js" type="text/javascript"></script>-->
    <script src="../../js/rapor_js.js" type="text/javascript"></script>

    <!-- BURASI TABLE TOOLS BUTONLARININ GIYDIRMESI-->
	<link rel="shortcut icon" type="image/png" href="/media/images/favicon.png">
	<link rel="alternate" type="application/rss+xml" title="RSS 2.0" href="http://www.datatables.net/rss.xml">
	<link rel="stylesheet" type="text/css" href="/media/css/site-examples.css?_=758e23b3f1a4c34d6c055f5cc10bae7e">
	<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css">
	<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.4.2/css/buttons.dataTables.min.css">
	
    <!-- BURASI TABLE TOOLS BUTONLARI-->
     <script type="text/javascript" src="/media/js/site.js?_=d78b222e2531b63c1f8683e47301add9">	</script>
	<script type="text/javascript" src="/media/js/dynamic.php?comments-page=extensions%2Fbuttons%2Fexamples%2Fhtml5%2Fcolumns.html" async>	</script>
	<script type="text/javascript" language="javascript" src="//code.jquery.com/jquery-1.12.4.js">	</script>
	<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js">	</script>
	<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js">	</script>
	<script type="text/javascript" language="javascript" src="//cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js">	</script>
	<script type="text/javascript" language="javascript" src="//cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/pdfmake.min.js">	</script>
	<script type="text/javascript" language="javascript" src="//cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/vfs_fonts.js">	</script>
	<script type="text/javascript" language="javascript" src="//cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js">	</script>
	<script type="text/javascript" language="javascript" src="//cdn.datatables.net/buttons/1.4.2/js/buttons.colVis.min.js">	</script>
	<script type="text/javascript" language="javascript" src="../../../../examples/resources/demo.js">	</script>

     <script type="text/javascript">
         
        

         //function fnName(){
         
         //    }
         
         $(window).bind("load", function () {
             //var GirenKim = document.getElementById('lbl_giris_yapan').innerText;
             //var VARMI = GirenKim.indexOf("MÜDÜRÜ");

             //if (VARMI > 0) {
             //    document.getElementById('yenikayitekleme_divi').style.visibility = 'hidden';
             //    //  $("#yenikayitekleme_divi").find("*").prop("disabled", true);
             //    //alert("MUDUR GIRDI");
             //    //$('#yenikayitekleme_divi').hide();
             //    //    //document.getElementById('yenikayitekleme_divi').style.visibility = 'visible';
             //    //document.getElementById('#yenikayitekleme_divi').style.visibility= 'hidden';

             //}
         });

         
         //$(window).load(function () {



         //});


        

         $(document).ready(function () {
         
             $('#example').DataTable({
                 dom: 'Bfrtip',
                 lengthMenu: [
                     [-1],
                     ['Hepsi']
                     ],
                buttons: [
                    {
                        extend: 'copyHtml5',
                        exportOptions: {
                            columns: [0, ':visible']
                               }
                    },
                    {
                        extend: 'excelHtml5',
                        exportOptions: {
                            columns: ':visible'
                        }
                    },
                    {
                        extend: 'pdfHtml5',
                        exportOptions: {
                            //columns: [0, 1, 2, 5]
                        }
                    }
                ]
            });
        });


         //$('#example').DataTable({
         //    dom: 'Bfrtip',
         //    lengthMenu: [
         //    [-1, 10, 25, 50],
         //    ['Hepsi', '10 satır', '25 satır', '50 satır']
         //    ],
         //    buttons: [

         //        'pageLength',
         //         'colvis',
         //        {
         //            extend: 'copyHtml5',
         //            exportOptions: {
         //                columns: [0, ':visible']
         //            }
         //        },
         //        {
         //            extend: 'excelHtml5',
         //            exportOptions: {
         //                columns: ':visible'
         //            }
         //        },
         //        {
         //            extend: 'pdfHtml5',
         //            exportOptions: {
         //                columns: [0, 1, 2, 5]
         //            }
         //        }
         //    ]
         //});

        $(".mesainedeni").click(function () {
            var GirenKim = document.getElementById('lbl_giris_yapan').innerText;
            var row = $(this).closest("tr");
            var PersonelId = row.find('td:eq(0)').text();
            var mesainedeni = row.find('option:selected').text();
            var hesaplanan_mesai = row.find('td:eq(4)').text();
            //var aciklama = row.find('td:eq(8)').val()
            var mesai_tarihi = row.find('td:eq(3)').text();
            var aciklama = $(this).closest('tr').find('input').val();

            if (row.find('option:selected').val() == "0") {

                alert("Mesai nedenini Seçiniz !!")
            }
            else
                if (row.find('option:selected').val() == "6" && aciklama == "") {

                    alert("Mesai için açıklama yazınız !!")
                }
                else {
                    {
                        $.ajax({
                            type: "POST",
                            url: "Mesailer.aspx/Mesai_onay",
                            data: "{'kullanici':'" + PersonelId + "','mesaineden':'" + mesainedeni + "', 'hesaplanan_mesai': '" + hesaplanan_mesai + "','aciklama': '" + aciklama + "','mesai_tarihi': '" + mesai_tarihi + "','GirenKim': '" + GirenKim +"'}",
                            contentType: "application/json",
                            dataType: "json",
                            success: function (result) {
                                // $("#Result").text(msg.d);
                                // alert(result.d);                   
                                if (result.d == 1) {
                                    alert("Personelin mesai bilgileri başarıyla kaydedildi.");


                                } else {
                                    alert("Onay verilecek mesai saati bulunmamaktadır !!");

                                }
                            },
                            error: function () {
                                alert('Bağlantı sırasında bir sorun oluştu. Yeniden deneyin');
                            }
                        });


                        $("#btn_tarihe_gore_mesai").trigger("click");
                    }
                }

        });

        $(function () {
            var ajax_istegi = 0;
            $("a.aylik_mesailer_to_excel").click(function () {
                //if (ajax_istegi == 0) {
                //    ajax_istegi = 1;/** ayni anda 1'den fazla ajax istegi almamak icin */

                //    var bilgi = $("span#lbl_ay").attr("title");
                //    if (bilgi != "") {
                //        bilgi = bilgi.split(',');

                //        $.ajax({
                //            type: 'POST',
                //            url: 'Mesailer.aspx/aylik_mesailer_to_excel',
                //            data: '{"ay":"' + bilgi[0] + '","bolum":"' + bilgi[1] + '","personel_alt_grup":"' + bilgi[2] + '","personel_alt_grup_text":"' + bilgi[3] + '"}',
                //            contentType: 'application/json; charset=utf-8',
                //            dataType: 'json',
                //            success: function (result) {
                //                //alert(result.d);
                //            },
                //            error: function () {
                //                alert("Oops!");
                //            }, complete: function () {
                //                ajax_istegi = 0;
                //            }
                //        });
                //    } else {
                //        alert("Lütfen Bir Ay Seçin!");
                //    }
                //} else {
                //    alert("Şu an çalışan bir ajax istegi var.");
                //}
                var bilgi = $("span#lbl_ay").attr("title");
                bilgi = bilgi.split(',');
                var bagli_birim = bilgi[3];
                var giris_yapan_ad = bilgi[4];
                var ay = bilgi[5];
                var tab_text = "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta charset=\"UTF-8\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table><tbody><tr><td>" + giris_yapan_ad + " - " + bagli_birim + " - " + ay + " Ayındaki Mesailer</td></tr><tr bgcolor='#87AFC6'>";
                var textRange; var j = 0;
                tab = document.getElementById('tbl_aylik_mesailer'); // id of table
                for (j = 0 ; j < tab.rows.length ; j++) {
                    tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
                    tab_text = tab_text + "</tr>";
                }

                tab_text = tab_text + "</tbody></table></body></html>";
                tab_text = tab_text.replace(/<a[^>]*>|<\/a>/g, "");//remove if u want links in your table
                tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
                tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params
                //alert(tab_text);

                var ua = window.navigator.userAgent;
                var msie = ua.indexOf("MSIE ");
                if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
                {
                    txtArea1.document.open("txt/html", "replace");
                    txtArea1.document.write(tab_text);
                    txtArea1.document.close();
                    txtArea1.focus();
                    sa = txtArea1.document.execCommand("SaveAs", true, "Global View Task.xls");
                }
                else //other browser not tested on IE 11
                    sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));
            });

            $("a.aylik_mesai_bilgileri_to_excel").click(function () {
                //if (ajax_istegi == 0) {
                //    ajax_istegi = 1;/** ayni anda 1'den fazla ajax istegi almamak icin */

                //    var bilgi = $("span#lbl_ay").attr("title");
                //    if (bilgi != "") {
                //        bilgi = bilgi.split(',');

                //        $.ajax({
                //            type: 'POST',
                //            url: 'Mesailer.aspx/aylik_mesai_bilgileri_to_excel',
                //            data: '{"ay":"' + bilgi[0] + '","bolum":"' + bilgi[1] + '","personel_alt_grup":"' + bilgi[2] + '","personel_alt_grup_text":"' + bilgi[3] + '"}',
                //            contentType: 'application/json; charset=utf-8',
                //            dataType: 'json',
                //            success: function (result) {
                //                //alert(result.d);
                //            },
                //            error: function () {
                //                alert("Oops!");
                //            }, complete: function () {
                //                ajax_istegi = 0;
                //            }
                //        });
                //    } else {
                //        alert("Lütfen Bir Ay Seçin!");
                //    }
                //} else {
                //    alert("Şu an çalışan bir ajax istegi var.");
                //}

                var bilgi = $("span#lbl_ay").attr("title");
                bilgi = bilgi.split(',');
                var bagli_birim = bilgi[3];
                var giris_yapan_ad = bilgi[4];
                var ay = bilgi[5];
                var tab_text = "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta charset=\"UTF-8\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table><tbody><tr><td>" + giris_yapan_ad + " - " + bagli_birim + " - " + ay + " Ayı Mesai Bilgileri</td></tr><tr bgcolor='#87AFC6'>";
                var textRange; var j = 0;
                tab = document.getElementById('tbl_aylik_mesai_bilgileri'); // id of table
                for (j = 0 ; j < tab.rows.length ; j++) {
                    tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
                    tab_text = tab_text + "</tr>";
                }

                tab_text = tab_text + "</tbody></table></body></html>";
                tab_text = tab_text.replace(/<a[^>]*>|<\/a>/g, "");//remove if u want links in your table
                tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
                tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params
                //alert(tab_text);

                var ua = window.navigator.userAgent;
                var msie = ua.indexOf("MSIE ");
                if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
                {
                    txtArea1.document.open("txt/html", "replace");
                    txtArea1.document.write(tab_text);
                    txtArea1.document.close();
                    txtArea1.focus();
                    sa = txtArea1.document.execCommand("SaveAs", true, "Global View Task.xls");
                }
                else //other browser not tested on IE 11
                    sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));


            });
        });

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>
</body>
</html>
