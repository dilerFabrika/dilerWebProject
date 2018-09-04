<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flm_genel_uretim.aspx.cs" Inherits="diler.Web.Forms.EndMuh.Flm_genel_uretim" %>

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
            text-align: center;
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
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #f71bd3; margin-left: 30px; font-weight: bold;">FİLMAŞİN ÜRETİM RAPORU</p>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6;">

                    <div class="table-responsive" style="border: 0px; margin-bottom: 15px; padding: 5px;">

                        <table class="table" style="padding: 0; margin: 0; border: none;">
                            <tbody>
                                <div class="col-md-4 col-sm-4">
                                    <span style="font-weight: bold; color: #816969; margin-top: 27px;">Tarih1:</span>
                                    <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <span style="font-weight: bold; color: #816969; margin-top: 27px;">Tarih2:</span>
                                    <asp:TextBox ID="tx_rapor_tarihi2" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4">

                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #dd4dc5; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px"
                                        CssClass="btn-danger" OnClick="btn_Listele_Click" Height="38px" />

                                    <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 23px; width: 29px; margin-left: 18PX;" OnClick="ImageButton1_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" />
                                </div>

                            </tbody>
                        </table>

                    </div>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">

                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped hh_uretim_raporu">
                                <thead>
                                    <tr>
                                        <th>Tarih</th>
                                        <th>Çelik kalitesi</th>
                                        <th>İ S Kütük (Ton)</th>
                                        <th>Mamul standardı</th>
                                        <th>Ebat</th>
                                        <th>N Y</th>
                                        <th>Mamul tonajı</th>
                                        <th>Hadde bozuğu (Ton)</th>
                                        <th>Uçbaş (Ton)</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_filmasin_uretim_raporu" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


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

</body>
</html>
