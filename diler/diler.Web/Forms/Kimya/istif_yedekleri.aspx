<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="istif_yedekleri.aspx.cs" Inherits="diler.Web.Forms.Kimya.istif_yedekleri" %>


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
            font-size: 14px !important;
            text-align: center;
            padding: 4px;
        }

        div.table-responsive .table thead tr th {
            font-size: 12px !important;
        }

        .fa-check-square:hover {
            color: #a01ee6 !important;
        }

        .istif_takip tbody tr:hover {
            background-color: #e2d0ec !important;
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
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #6f2398; margin-left: 30px; font-weight: bold;">YEDEK İSTİF KAYITLARI</p>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>

                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>

                                <td style="width: 200px">Yedek Tarihi:
                                        <asp:DropDownList ID="cmb_yedek_tarihi" runat="server" CssClass="form-control unstyled_date" AutoPostBack="True" Style="width: 200px"
                                            OnSelectedIndexChanged="cmb_yedek_tarihi_SelectedIndexChanged">
                                        </asp:DropDownList>
                                </td>

                                <td style="width: 150px">Stok yeri:
                                        <asp:DropDownList ID="Cmb_stok_yeri" runat="server" CssClass="form-control unstyled_date" AutoPostBack="True" Style="width: 150px"
                                            OnSelectedIndexChanged="Cmb_stok_yeri_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Stok yeri seçiniz</asp:ListItem>
                                            <asp:ListItem>Çelikhane</asp:ListItem>
                                            <asp:ListItem>Haddehane</asp:ListItem>

                                        </asp:DropDownList>
                                </td>

                                <td style="width: 220px">İstif yeri:
                                    <asp:DropDownList ID="Cmb_istif_yeri" runat="server" Style="width: 220px" CssClass="form-control unstyled_date">
                                    </asp:DropDownList>

                                </td>

                                <td style="width: 100px">

                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger"
                                        Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #6f2398" OnClick="btn_Listele_Click" />

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
                            <table id="tech-companies-1" class="table table-bordered table-striped istif_takip">
                                <thead>
                                    <tr>

                                        <th>İstif sırano</th>
                                        <th>Döküm tarihi</th>
                                        <th>Döküm no</th>
                                        <th>Stok yeri</th>
                                        <th>İstif yeri<br />
                                        </th>
                                        <th>İstif adet</th>
                                        <th>Çelik cinsi</th>
                                        <th>Boy</th>
                                        <th>Ebat</th>
                                        <th>Sipariş no</th>
                                        <th>Lot</th>
                                        <th>Açıklama</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_istif_takip" runat="server"></asp:PlaceHolder>
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

</body>

</html>
