<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Celikhane_rapor.aspx.cs" Inherits="diler.Web.Forms.Celikhane.Celikhane_rapor" %>

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
    <link href="../../rapor_css/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Icons -->
    <link href="../../rapor_css/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../rapor_css/assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="../../rapor_css/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <!-- animate css -->
    <link href="../../rapor_css/css/animate.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="../../rapor_css/css/waves-effect.css" rel="stylesheet" />
    <!-- Responsive-table -->
    <link href="../../rapor_css/assets/responsive-table/rwd-table.min.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- Custom Files -->
    <link href="../../rapor_css/css/helper.css" rel="stylesheet" type="text/css" />
    <link href="../../rapor_css/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../rapor_css/css/rapor_style.css" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->
    <script src="../../rapor_css/js/modernizr.min.js"></script>


    <style>
        div.table-responsive .table tbody tr td {
            font-size: 12px !important;
            text-align: LEFT;
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
                            <ul class="nav navbar-nav">
                                <li class="dropdown">
                                    <a href="javascript:void(0)" data-toggle="dropdown" class="dropdown-toggle">Menu <b class="caret"></b></a>
                                    <ul class="dropdown-menu dropdown-menu-left">
                                        <li><a href="../../Default2.aspx">Ana Sayfa</a></li>

                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-4  rapor_tarihi_getir">
                        <table class="table" style="padding: 0; margin: 0; border: none;">
                            <tbody style="border: none;">
                                <tr>
                                    <td>
                                        <div class="col-md-3 col-sm-2">
                                            <%-- <a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a>--%>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date" OnTextChanged="tx_rapor_tarihi_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                                    <td>
                                        <div class="col-md-3 col-sm-2">
                                            <%--<a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a>--%>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                    <div class="col-sm-4">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                            <%--<a href="YaziciCelikhaneRapor.aspx" title="Yazıcı Çelikhane Raporları">Yazıcı Çelikhane İçin Tıklayın<i class="ion-arrow-right-a"></i>
                            </a>--%>
                        </div>
                    </div>
                </div>
                <div class="row tablolar">
                    <div class="col-sm-12">
                        <div class="panel panel-border panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title " style="text-align: center; font-size: 21px;">Diler Çelikhane Üretimi</h3>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-md-4" style="margin-right: 0; padding: 0;">
                                    <div class="col-sm-6">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">ÜRETİM</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-1" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Döküm<br />
                                                                Sayısı</th>
                                                            <th>İmale Sevk<br />
                                                                Hurda</th>
                                                            <th>Üretim</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_uretim" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">ÜRETİM ÖZET</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-10" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>Kalite</th>
                                                            <th data-priority="1">Ebat</th>
                                                            <th data-priority="3">Boy</th>
                                                            <th data-priority="1">Tonaj</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_uretim_ozet" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">ENERJİLER</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-2" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th data-priority="1">Gün Kwh</th>
                                                            <th data-priority="3">Kwh (Ton)</th>
                                                            <th data-priority="1">Ay Kwh</th>
                                                            <th data-priority="3">Kwh (Ton)</th>
                                                            <th data-priority="3">Yıl Kwh</th>
                                                            <th data-priority="6">Kwh (Ton)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_enerjiler" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">SARFİYATLAR</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-5" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th data-priority="1">Gün Miktar/kg</th>
                                                            <th data-priority="3">kg(Ton)</th>
                                                            <th data-priority="1">Ay Miktar/kg</th>
                                                            <th data-priority="3">kg(Ton)</th>
                                                            <th data-priority="3">Yıl Miktar/kg</th>
                                                            <th data-priority="6">kg(Ton)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_sarfiyatlar" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4" style="margin-right: 0; padding: 0;">
                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">
                                                DURUŞLAR<asp:LinkButton ID="btn_durus_ayrinti_getir" runat="server" OnClick="btn_durus_ayrinti_getir_Click" Visible="false">DURUŞLAR AYRINTI</asp:LinkButton>
                                            </p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-3" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>Duruş Nedeni</th>
                                                            <th data-priority="1">Süre(dk)</th>
                                                            <th data-priority="3">Gün Tekrar</th>
                                                            <th data-priority="1">%</th>
                                                            <th data-priority="3">Süre(dk)</th>
                                                            <th data-priority="3">Ay Tekrar</th>
                                                            <th data-priority="6">%</th>
                                                            <th data-priority="3">Süre(dk)</th>
                                                            <th data-priority="3">Yıl Tekrar</th>
                                                            <th data-priority="6">%</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_duruslar" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">DURUŞ AYRINTISI</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-6" class="table table-small-font table-bordered table-striped tbl_durus_ayrintisi">
                                                    <thead>
                                                        <tr>
                                                            <th>Duruş Tipi</th>
                                                            <th data-priority="1">Arıza Nedeni</th>
                                                            <th data-priority="3">Toplam Süre(dk)</th>
                                                            <th data-priority="1">Gün Tekrar(Adet)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <asp:PlaceHolder ID="ph_durus_ayrintisi" runat="server"></asp:PlaceHolder>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-4" style="margin-right: 0; padding: 0;">

                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">HURDALAR</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-4" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th data-priority="1">Günlük<br />
                                                                Kullanım</th>
                                                            <th data-priority="3">Aylık
                                                            <br />
                                                                Kullanım</th>
                                                            <th data-priority="1">Yıllık
                                                            <br />
                                                                Kullanım</th>
                                                            <th data-priority="3">Günlük
                                                            <br />
                                                                Giriş</th>
                                                            <th data-priority="3">Aylık
                                                            <br />
                                                                Giriş</th>
                                                            <th data-priority="6">Yıllık
                                                            <br />
                                                                Giriş</th>
                                                            <th data-priority="6">Stok</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_hurdalar" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">OKSİJEN</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-7" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th data-priority="1">Miktar(kg)</th>
                                                            <th data-priority="3">kg(Ton)</th>
                                                            <th data-priority="1">Miktar(kg)</th>
                                                            <th data-priority="3">kg(Ton)</th>
                                                            <th data-priority="3">Miktar(kg)</th>
                                                            <th data-priority="6">kg(Ton)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_oksijen" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik">ANALİZLER</p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-8" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>Dokum No</th>
                                                            <th data-priority="1">C</th>
                                                            <th data-priority="3">Si</th>
                                                            <th data-priority="1">S</th>
                                                            <th data-priority="3">P</th>
                                                            <th data-priority="3">Mn</th>
                                                            <th data-priority="6">Ni</th>
                                                            <th data-priority="3">Cr</th>
                                                            <th data-priority="3">Cu</th>
                                                            <th data-priority="6">V</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_analizler" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
    <script src="../../rapor_css/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../rapor_css/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../rapor_css/js/waves.js" type="text/javascript"></script>

    <script src="../../rapor_css/js/wow.min.js" type="text/javascript"></script>
    <script src="../../rapor_css/js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../../rapor_css/js/jquery.scrollTo.min.js" type="text/javascript"></script>
    <script src="../../rapor_css/assets/jquery-detectmobile/detect.js" type="text/javascript"></script>
    <script src="../../rapor_css/assets/fastclick/fastclick.js" type="text/javascript"></script>
    <script src="../../rapor_css/assets/jquery-slimscroll/jquery.slimscroll.js" type="text/javascript"></script>
    <script src="../../rapor_css/assets/jquery-blockui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../rapor_css/js/masonry.js" type="text/javascript"></script>

    <!-- CUSTOM JS -->
    <script src="../../rapor_css/js/jquery.app.js" type="text/javascript"></script>

    <!-- responsive-table 
    <script src="assets/responsive-table/rwd-table.min.js" type="text/javascript"></script>-->
    <script src="../../rapor_css/js/rapor_js.js" type="text/javascript"></script>



</body>
</html>
