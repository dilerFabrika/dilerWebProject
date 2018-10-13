<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kimyalab_ikitarih_arasi.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.Kimyalab_ikitarih_arasi" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!-- Base Css Files -->

    <link href="../../css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Icons -->

    <link href="../../assets1/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets1/ionicon/css/ionicons.min.css" rel="stylesheet" />


    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />

    <!-- animate css -->

    <link href="../../css/animate.css" rel="stylesheet" />

    <!-- Waves-effect -->

    <link href="../../css/waves-effect.css" rel="stylesheet" />

    <!-- Responsive-table -->

    <link href="../../assets1/responsive-table/rwd-table.min.css" rel="stylesheet" type="text/css" media="screen" />

    <!-- Custom Files -->

    <link href="../../css/helper.css" rel="stylesheet" />
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/rapor_style.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->

    <script src="../../js/modernizr.min.js"></script>
    <style type="text/css">
        div.table-responsive .table tbody tr td {
            font-size: 13px !important;
            text-align: left;
            padding: 4px;
        }

        div.table-responsive .table thead tr th {
            font-size: 11px !important;
        }
    </style>

</head>

<body>
    <!-- Start content -->
    <div class="content">

        <form class="form-horizontal" role="form" enctype="multipart/form-data" runat="server">
            <!-- Page-Title -->
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <span style="color: #FF0066"></span>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #f71bd3; margin-left: 30px; font-weight: bold;">ÇELİKHANE ÜRETİM RAPORU</p>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td>Tarih1:
                                    <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox></td>
                                <td>Tarih2:
                                    <asp:TextBox ID="tx_rapor_tarihi2" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>

                                </td>
                                <td>

                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #dd4dc5; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px"
                                        CssClass="btn-danger" OnClick="btn_Listele_Click" Height="38px" />

                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 23px; width: 29px; margin-top: 15px" OnClick="ImageButton1_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                            </tr>
                        </tbody>
                    </table>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            </div>


            <div class="col-lg-12 col-md-12 col-sm-12" style="margin-top: 25px;">
                <div class="panel">
                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-1" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                            <th>ÇELİK CİNSİ</th>
                                            <th>EBAT</th>
                                            <th>BOY</th>
                                            <th>KÜTÜKSAYISI</th>
                                            <th>DÖKÜMSAYISI</th>
                                            <th>TONAJ</th>
                                            <th>ÜRETİM YERİ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_uretim_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                                <table id="" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                            <th>TOPLAM DÖKÜM SAYISI</th>
                                            <th>TOPLAM KÜTÜK SAYISI</th>
                                            <th>TOPLAM TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_toplam_uretim" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>

                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik" style="background-color: #1e88e5; color: #FFF; margin-bottom: 0PX;">FİLMAŞİN ÜRETİMLERİ </p>

                                <table id="tech-companies-185" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                            <th>ÇELİK CİNSİ</th>
                                            <th>EBAT</th>
                                            <th>BOY</th>
                                            <th>KÜTÜKSAYISI</th>
                                            <th>DÖKÜMSAYISI</th>
                                            <th>TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_filmasin_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                                <table id="" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>

                                            <th>TOPLAM DÖKÜM SAYISI</th>
                                            <th>TOPLAM KÜTÜK SAYISI</th>
                                            <th>TOPLAM TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_filmasin_uretim_toplam" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>

                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik" style="background-color: #1e88e5; color: #FFF; margin-bottom: 0PX;">İHRACAT ÜRETİMLERİ </p>
                                <table id="tech-companies-85" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>SİPARİŞ NO</th>
                                            <th>ÇELİK CİNSİ</th>
                                            <th>EBAT</th>
                                            <th>BOY</th>
                                            <th>KÜTÜKSAYISI</th>
                                            <th>DÖKÜMSAYISI</th>
                                            <th>TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_ihracat_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                                <table id="" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>

                                            <th>TOPLAM DÖKÜM SAYISI</th>
                                            <th>TOPLAM KÜTÜK SAYISI</th>
                                            <th>TOPLAM TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_ihracat_uretim_toplam" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">

                                <table id="tech-companies-18" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>

                                            <th>STD DIŞI ELEMENT<br />
                                            </th>
                                            <th>DÖKÜM SAYISI</th>
                                            <th>TONAJ</th>
                                            <th>NEDENİ </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_uretim_std_disi_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-189" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>

                                            <th>ÜRETİMDEN SAPMA ELEMENT</th>
                                            <th>DÖKÜM SAYISI</th>
                                            <th>TONAJ</th>
                                            <th>NEDEN </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_uretimden_sapma_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="clear"></div>
        </form>
    </div>
    <!-- end row -->

    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/waves.js"></script>
    <script src="../../js/wow.min.js"></script>
    <script src="../../js/jquery.nicescroll.js"></script>
    <script src="../../js/jquery.scrollTo.min.js"></script>
    <script src="../../assets1/jquery-detectmobile/detect.js"></script>
    <script src="../../assets1/fastclick/fastclick.js"></script>
    <script src="../../assets1/jquery-slimscroll/jquery.slimscroll.js"></script>
    <script src="../../assets1/jquery-blockui/jquery.blockUI.js"></script>

    <script src="../../js/masonry.js" type="text/javascript"></script>

    <!-- CUSTOM JS -->

    <script src="../../js/jquery.app.js"></script>
    <script src="../../js/rapor_js.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var sum = 0;
            var table = document.getElementById("tech-companies-189");
            var ths = table.getElementsByTagName('th');
            var tds = table.getElementsByClassName('tonaj');
            for (var i = 0; i < tds.length; i++) {
                sum += isNaN(tds[i].innerText) ? 0 : parseFloat(tds[i].innerText);
            }

            var row = table.insertRow(table.rows.length);
            var cell = row.insertCell(0);
            cell.setAttribute('colspan', ths.length);

            var totalBalance = document.createTextNode('Toplam tonaj:' + " " + sum.toFixed(3));
            cell.appendChild(totalBalance);
            // $(cell).css("color", "#e602f3;");
            $(cell).css({ "color": "#e602f3", "font-weight": "Bold" });
        });



        $(document).ready(function () {

            var sum = 0;
            var table = document.getElementById("tech-companies-18");
            var ths = table.getElementsByTagName('th');
            var tds = table.getElementsByClassName('tonaj');
            for (var i = 0; i < tds.length; i++) {
                sum += isNaN(tds[i].innerText) ? 0 : parseFloat(tds[i].innerText);
            }

            var row = table.insertRow(table.rows.length);
            var cell = row.insertCell(0);
            cell.setAttribute('colspan', ths.length);

            var totalBalance = document.createTextNode('Toplam tonaj:' + " " + sum.toFixed(3));
            cell.appendChild(totalBalance);
            // $(cell).css("color", "#e602f3;");
            $(cell).css({ "color": "#e602f3", "font-weight": "Bold" });

        });

    </script>
</body>
</html>
