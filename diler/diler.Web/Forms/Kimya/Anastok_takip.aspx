<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anastok_takip.aspx.cs" Inherits="diler.Web.Forms.Kimya.Anastok_takip" %>

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
    <style>
        div.table-responsive .table tbody tr td {
            font-size: 13px !important;
            border: 1px solid #f5d5d3;
            padding:4px;
        }

        div.table-responsive .table thead tr th {
            line-height: 1em;
            font-weight: bold;
            font-size: 12px !important;
            text-align: center;
            padding: 1px;
            margin: 0;
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
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <p style="text-align: center; font-size: 18px; color: #ED4517; margin-left: 30px; font-weight: bold;">ANA STOK TAKİP</p>
                </div>
            </div>
         
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td style="width: 100px;"></td>
                                <td style="width: 150px;">Ebat:
                                     <asp:DropDownList ID="Cmb_ebat" runat="server" CssClass="form-control unstyled_date" AutoPostBack="True" Style="width: 150px">
                                     </asp:DropDownList></td>

                                <td style="width: 120px;">
                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger"
                                        Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold;" OnClick="btn_Listele_Click" />

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


            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs8">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                            <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-1" class="table table-bordered table-striped ana_stok_takip">
                                    <thead>
                                        <tr>
                                            <th>Ebat</th>
                                            <th>Çelik cinsi</th>
                                            <th>Boy</th>
                                            <th>Adet</th>
                                            <th>Tonaj</th>
                                            <th>Orj çelik cinsi</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_ana_stok_takip" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                            <p class="tbl_baslik" style="background-color: #d43f3a; color: #FFF; margin-bottom: 0PX;">ÇELİK CİNSİ BAZINDA STOK</</p>

                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-18" class="table table-bordered table-striped ana_stok_takip">
                                    <thead>
                                        <tr>
                                            <th>Ebat</th>
                                            <th>Çelik cinsi</th>
                                            <th>Boy</th>
                                            <th>Adet</th>
                                            <th>Tonaj</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_celikcinsi_bazinda" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                            <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-12" class="table table-bordered table-striped istif_takip_ozet">
                                    <thead>
                                        <tr>
                                            <th>Stok yeri</th>
                                            <th>Döküm no</th>
                                            <th>Çelik cinsi</th>
                                            <th>İstif yeri</th>
                                            <th>Adet</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_ana_stok_takip_Ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:TextBox runat="server" ID="fillname" value="" OnTextChanged="fillname_TextChanged" Style="opacity: 0">  </asp:TextBox>
            </div>

        </form>
    </div>
    <!-- content -->

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

        var pickedup;

        $(document).ready(function () {
            $("#tech-companies-1 tbody tr").on("click", function (event) {
                if (pickedup != null) {
                    pickedup.css("background-color", "#ffffff");
                }
                $(this).css("background-color", "#ecced3");
                pickedup = $(this);

                $("#fillname").val($(this).find("td").eq(1).html());
                // var celik_cinsi = $(this).find("td").eq(1).html();

                //$("#fillname").trigger("change");
                $("#btn_Listele").trigger("click");


            });

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
            $(cell).css({ "color": "rgb(212, 63, 58)", "font-weight": "Bold" });
        });

        $(document).ready(function () {
            var sum = 0;
            var table = document.getElementById("tech-companies-1");
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
            $(cell).css({ "color": "rgb(212, 63, 58)", "font-weight": "Bold" });
        });

    </script>



</body>
</html>

