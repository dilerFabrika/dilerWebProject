<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrtakRapor.aspx.cs" Inherits="diler.Web.Forms.holding_raporlari.OrtakRapor" %>

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
                        </div>
                    </div>
                    <div class="col-sm-4 rapor_tarihi_getir">

                        <table class="table" style="padding:0;margin:0;border:none;">
                                <tbody style="border:none;">
                                    <tr>
                                        <td>
                                            <div class="col-md-3 col-sm-2">
                                                <a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a>
                                            </div>
                                        </td>
                                        <td><asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date" OnTextChanged="tx_rapor_tarihi_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                                        <td>
                                            <div class="col-md-3 col-sm-2">
                                                <a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a>
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
                            <!--<a href="YaziciHaddehaneRapor.aspx" title="Yazıcı Haddehane Raporları">Yazıcı Haddehane İçin Tıklayın<i class="ion-arrow-right-a"></i>
                        </a>-->
                        </div>
                    </div>
                </div>

                <div class="row tablolar" style="margin-top: 21px;">
                    <!-- ORTAK RAPOR 
                   SELECT * FROM API_DB_001 WHERE TARIH=20170510 AND FIRMA='RAPOR_ORTAK' AND UNITE='RAPOR_ORTAK' AND TABLOTIP='RAPOR_ORTAK' ORDER BY CONVERT(INT,BILGISIRANO) ASC
                -->
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="panel panel-border panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title " style="text-align: center; font-size: 21px; color: #562501;">ORTAK RAPORLAR</h3>
                                </div>
                                <div class="row" style="margin-top: 10px;">
                                    <div class="col-md-12">
                                        <div class="panel-body table-rep-plugin table-rapor">
                                            <p class="tbl_baslik"></p>
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-11" class="table table-small-font table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="3" rowspan="2" class="td_kahve"></th>
                                                            <th colspan="7" class="td_kahve">DILER</th>
                                                            <th colspan="7" class="td_kahve">YAZICI</th>
                                                            <th class="td_kahve">TOPLAM</th>
                                                            <th class="td_kahve">TOPLAM</th>
                                                        </tr>
                                                        <tr>
                                                            <th class="td_turuncu">GÜN</th>
                                                            <th>GÜN<br />
                                                                ORT</th>
                                                            <th>AY</th>
                                                            <th>AY<br />
                                                                ORT</th>
                                                            <th>YIL</th>
                                                            <th>YIL<br />
                                                                ORT</th>
                                                            <th class="td_sari">YIL TEMPO<br />
                                                                (TON)</th>
                                                            <th class="td_turuncu">GÜN</th>
                                                            <th>GÜN<br />
                                                                ORT</th>
                                                            <th>AY</th>
                                                            <th>AY<br />
                                                                ORT</th>
                                                            <th>YIL</th>
                                                            <th>YIL<br />
                                                                ORT</th>
                                                            <th class="td_sari">YIL TEMPO<br />
                                                                (TON)</th>
                                                            <th class="td_mavi">YIL TEMPO<br />
                                                                (TON)</th>
                                                            <th class="td_mavi">YIL TEMPO<br />
                                                                (TON)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td class="td_mavi" colspan="2" rowspan="13" style="vertical-align: middle; text-align: center;">ÇELİKHANE</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_celikhane" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_mavi" colspan="2" rowspan="8" style="vertical-align: middle; text-align: center;">ÇUBUK HAD.</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_cubuk_had" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_mavi" colspan="2" rowspan="8" style="vertical-align: middle; text-align: center;">FİLMAŞİN YAZICI2</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_filmasin_yazici2" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_yesil" colspan="2" rowspan="4" style="vertical-align: middle; text-align: center;">MAMUL ÜRETİM</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_mamul_uretim" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_mavi" rowspan="16" style="vertical-align: middle; text-align: center;">SEVKIYAT</td>
                                                            <td class="td_mavi" rowspan="4" style="vertical-align: middle; text-align: center;">ÇUBUK</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_sevkiyat_cubuk" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_mavi" rowspan="4" style="vertical-align: middle; text-align: center;">FİLMAŞİN</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_sevkiyat_filmasin" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_yesil" rowspan="4" style="vertical-align: middle; text-align: center;">TOPLAM<br />
                                                                MAMUL</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_sevkiyat_toplam_mamul" runat="server"></asp:PlaceHolder>

                                                        <tr>
                                                            <td class="td_mavi" rowspan="4" style="vertical-align: middle; text-align: center;">KÜTÜK</td>
                                                            <td colspan="17"></td>
                                                        </tr>
                                                        <asp:PlaceHolder ID="ph_or_sevkiyat_kutuk" runat="server"></asp:PlaceHolder>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- end row -->
                </div>
                <!-- end row tablolar -->
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->

    <script>
        var resizefunc = [];
    </script>

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
