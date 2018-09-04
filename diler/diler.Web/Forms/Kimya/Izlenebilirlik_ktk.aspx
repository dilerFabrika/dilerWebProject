<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Izlenebilirlik_ktk.aspx.cs" Inherits="diler.Web.Forms.Kimya.Izlenebilirlik_ktk" %>

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
            padding: 3px;
        }

        div.table-responsive .table thead tr th {
            font-size: 11px !important;
        }

        .table_t:hover {
            background: #7ef59c !important;
            /*background:#87da90  !important;
           background: #f9c9bc !important;*/
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
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #ED4517; margin-left: 30px; font-weight: bold;">DÖKÜM BAZINDA KÜTÜK TAKİBİ</p>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td style="width: 200px"><span style="font-weight: bold; color: #816969; margin-top: 27px;">Dökümno1:</span>
                                    <asp:TextBox ID="tx_dokum_no" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date" Style="width: 200px"></asp:TextBox>

                                </td>
                                <td style="width: 200px"><span style="font-weight: bold; color: #816969; margin-top: 27px;">Dökümno2:</span>
                                    <asp:TextBox ID="tx_dokum_no2" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date" Style="width: 200px"></asp:TextBox>

                                </td>
                                <td style="width: 105px">

                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #ED4517; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px"
                                        CssClass="btn-danger" OnClick="btn_Listele_Click" Height="38px" />

                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Style="height: 23px; width: 29px; margin-top: 15px" OnClick="ImageButton1_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                            </tr>
                        </tbody>
                    </table>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">

                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped ktk_izlenebilirlik">
                                <thead>
                                    <tr>
                                        <th>Döküm numarası</th>
                                        <th>Çelik cinsi</th>
                                        <th>Üretilen kütük adedi</th>
                                        <th>Sıcak ve Soğuk şarj adedi</th>
                                        <th>İstif Adet</th>
                                        <th>Tel çubuk haddesi adedi<br />
                                        </th>
                                        <th>Kütük paketleme adedi</th>
                                        <th>Kütük satış adedi</th>
                                        <th>Toplam kütük adedi</th>
                                        <th>Sonuç</th>
                                        <th>Ocak Önü</th>

                                        <th>Açıklama</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_ktk_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


        </form>
    </div>

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

 
    </script>
</body>

</html>
