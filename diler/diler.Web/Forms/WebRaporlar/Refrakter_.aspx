﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refrakter_.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.Refrakter_" %>

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
            font-size: 12px !important;
            padding: 4px;
        }

        div.table-responsive .table thead tr th {

          
 
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
                    <span style="color: #FF0066">

                        <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 23px; width: 29px; background-color: lightblue;"
                            ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" />
                    </span>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #890d62; margin-left: 30px; font-weight: bold;">ÇELİKHANE REFRAKTER AYLIK TAKİBİ</p>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6;">
                    <div class="table-responsive" style="border: 0px">

                        <table class="table" style="padding: 0; margin: 0; border: none;">
                            <tbody>

                                <div class="col-md-3 col-sm-3">
                                    <span style="font-weight: bold; color: #060606;">Ay seçiniz:</span>
                                    <asp:DropDownList ID="cmb_ay" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False">
                                        <asp:ListItem Selected="True" Value="01">Ocak</asp:ListItem>
                                        <asp:ListItem Value="02">Şubat</asp:ListItem>
                                        <asp:ListItem Value="03">Mart</asp:ListItem>
                                        <asp:ListItem Value="04">Nisan</asp:ListItem>
                                        <asp:ListItem Value="05">Mayıs</asp:ListItem>
                                        <asp:ListItem Value="06">Haziran</asp:ListItem>
                                        <asp:ListItem Value="07">Temmuz</asp:ListItem>
                                        <asp:ListItem Value="08">Ağustos</asp:ListItem>
                                        <asp:ListItem Value="09">Eylül</asp:ListItem>
                                        <asp:ListItem Value="10">Ekim</asp:ListItem>
                                        <asp:ListItem Value="11">Kasım</asp:ListItem>
                                        <asp:ListItem Value="12">Aralık</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-sm-3">
                                    <span style="font-weight: bold; color: #060606;">Yıl seçiniz:</span>
                                    <asp:DropDownList ID="cmb_yil" runat="server" CssClass="form-control unstyled_date">
                               <%--         <asp:ListItem Selected="True">2017</asp:ListItem>--%>
                                        <asp:ListItem>2018</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-sm-3">
                                    <span style="font-weight: bold; color: #060606; opacity: 0">Yıl seçiniz:</span>
                                    <asp:DropDownList ID="cmb_yer" runat="server" CssClass="form-control unstyled_date">
                                        <asp:ListItem Selected="True">Gaz Tapası</asp:ListItem>
                                        <asp:ListItem>Üst nozul</asp:ListItem>
                                        <asp:ListItem>Alt nozul</asp:ListItem>
                                        <asp:ListItem>Plaka T</asp:ListItem>
                                        <asp:ListItem>Plaka Y</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-sm-3 ">
                                    <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger"
                                        Style="width: 100px; background-color: #890d62; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold;" OnClick="btn_Listele_Click" />
                                </div>

                            </tbody>
                        </table>

                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs1"></div>
                <div class="col-lg-5 col-md-5 col-sm-5 col-xs5">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                              <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">Firma bazında takip</</p>
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-1" class="table table-bordered table-striped refrakter_takip">
                                    <thead>
                                        <tr>
                                            <th>Firma</th>
                                            <th>Toplam </th>
                                            <th>Kullanılan adet</th>
                                            <th>Ort Döküm sayısı</th>


                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_refrakter_takip" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                             <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">Genel takip</</p>
                           <%-- <p class="tbl_baslik" style="background-color: #F00; color: #FFF; padding:0">Genel takip</p>--%>
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-18" class="table table-bordered table-striped refrakter_takip">
                                    <thead>
                                        <tr>
                                            <th>Firma</th>
                                            <th>Toplam </th>
                                            <th>Kullanılan adet</th>
                                            <th>Ort Döküm sayısı</th>


                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_refrakter_takip_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
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