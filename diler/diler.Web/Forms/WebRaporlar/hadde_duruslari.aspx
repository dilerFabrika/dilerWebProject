<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hadde_duruslari.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.hadde_duruslari" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />


    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
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
            font-size: 14px !important;
            text-align: center;
            padding: 4px;
        }


        .nav-pills li a {
            border-radius: 4px;
            text-decoration: none;
        }

        div .table-responsive .table thead tr th {
            line-height: 1em;
            font-weight: bold;
            font-size: 12px !important;
            text-align: center;
            padding: 1px;
            margin: 0;
        }


        .nav-pills > li.active > a, .nav-pills > li.active > a:focus, .nav-pills > li.active > a:hover {
            color: #fff;
            background-color: #890d62;
            FONT-WEIGHT: BOLD;
        }

        .nav-pills > li {
            FONT-WEIGHT: BOLD;
        }

        tr:hover { background:#f7c7e8 !important; }
    </style>

</head>

<body>
    <form runat="server">
        <div class="row icon-list">
            <div class="col-sm-12" style="margin-top: 20px">

                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="background-color: #add8e6; width: 600px; height: 65px;">
                    <div class="table-responsive" style="border: 0px;">
                        <table class="table" style="padding: 0; margin: 0; border: none;">
                            <tbody>
                                <div class="col-lg-4 col-md-4 col-sm-4"  style="margin-top: 15px;"">
                           
                                        <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4"  style="margin-top: 15px;">
                                       <asp:TextBox ID="tx_rapor_tarihi2" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger" OnClick="btn_Listele_Click"
                                        Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #890d62;" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" Style="height: 23px; width: 29px; background-color: #add8e6; margin-left: 20px;"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" />
                                </div>

                            </tbody>
                        </table>

                    </div>

                </div>
                <div class="col-sm-1"></div>

            </div>
        </div>


        <ul class="nav nav-pills" style="margin-top: 10PX;">
            <li class="active">
                <a href="#1a" data-toggle="tab">Çubuk Hadde Duruşları</a>
            </li>
            <li><a href="#2a" data-toggle="tab">Tel Çubuk Hadde Duruşları</a>
            </li>


        </ul>
        <div class="tab-content clearfix">

            <div class="tab-pane active" id="1a">


                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">

                                <table id="" class="table table-bordered table-striped table_durus">
                                    <thead>
                                        <tr>
                                            <th>Tarih</th>
                                            <th>Vrd</th>
                                            <th>Çap</th>
                                            <th>Duruş Nedeni</th>
                                            <th>Arıza Nedeni</th>
                                            <th>Başlangıç Süresi</th>
                                            <th>Bitiş Süresi</th>
                                            <th>Net Süre(Dak)</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_cubuk_durus" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="2a">

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">

                                <table id="" class="table table-bordered table-striped table_durus">

                                    <thead>
                                        <tr>
                                            <th>Tarih</th>
                                            <th>Vrd</th>
                                            <th>Çap</th>
                                            <th>Duruş Nedeni</th>
                                            <th>Arıza Nedeni</th>
                                            <th>Başlangıç Süresi</th>
                                            <th>Bitiş Süresi</th>
                                            <th>Net Süre(Dak)</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_telcubuk_durus" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="clear"></div>
                </div>

            </div>

        </div>

        <div class="clear"></div>


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

    </form>
</body>

</html>
