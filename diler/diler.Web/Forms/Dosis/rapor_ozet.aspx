﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rapor_ozet.aspx.cs" Inherits="diler.Web.Forms.Dosis.rapor_ozet" %>

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
            text-align: left;
        }

        div.table-responsive .dosis_tablosu tbody tr td {
            padding: 6px;
    
        }

        div.table-responsive .table thead tr th {
            font-size: 11px !important;
        }

        .table_t:hover {
            background: #e2bfd8 !important;
            /*background: #f5cbe8 !important;*/
            /*background: #dab8d0 !important;*/
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
                    <p style="text-align: center; padding: 1px; font-size: 18px; color: #a51b7c; margin-left: 30px; font-weight: bold;">DÖSİS RAPOR ÖZETİ</p>
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

                                    <asp:Button ID="btn_listele" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #a51b7c; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px"
                                        CssClass="btn-danger" OnClick="btn_listele_Click" Height="38px" />

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

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 15px;">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tech-companies-12" class="table table-bordered table-striped oneri_sayisi_ozet">
                            <thead>
                                <tr>
                                    <th>Öneri formları</th>
                                    <th>Öneri sayısı</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_oneri_sayisi_ozet" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tbl_oneri_durumu" class="table table-bordered table-striped oneri_durum_ozet">
                            <thead>
                                <tr>

                                    <th>Öneri durumları</th>
                                    <th>Öneri sayısı</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_oneri_durum_ozet" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tbl_lokasyona_gore_oneri" class="table table-bordered table-striped lokasyona_gore_oneri_sayisi">
                            <thead>
                                <tr>
                                    <th>Lokasyon</th>
                                    <th>Öneri sayısı</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_lokasyona_gore_oneri_sayisi" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tbl_kategoriye_gore_oneri" class="table table-bordered table-striped kategoriye_gore_oneri_sayisi">
                            <thead>
                                <tr>
                                    <th>Kategori</th>
                                    <th>Öneri sayısı</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_kategoriye_gore_oneri_sayisi" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 15px;">

                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tech-companies-912" class="table table-bordered table-striped oneri_veren_bolum">
                            <thead>
                                <tr>
                                    <th>Öneri veren bölüm</th>
                                    <th>Öneri sayısı</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_oneri_veren_bolum" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table id="tech-companies-712" class="table table-bordered table-striped oneri_uygulayan_bolum">
                            <thead>
                                <tr>
                                    <th>Öneri uygulayan bölüm</th>
                                    <th>Öneri sayısı</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_oneri_uygulayan_bolum" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 15px;">

                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <p class="tbl_baslik" style="background-color: #a51b7c; color: #FFF; margin-bottom: 0px">ÖNERİ AYRINTI</p>
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped  dosis_tablosu">
                                <thead>
                                    <tr>
                                        <th>Öneri 
                                            <br />
                                            no</th>
                                        <th>Form
                                            <br />
                                            no</th>
                                        <th>Lokasyon</th>
                                        <th>Kategori</th>
                                        <th>Öneri
                                            <br />
                                            giriş tarihi</th>
                                        <th>Öneri 
                                            <br />
                                            veren ad/Soyad<br />
                                        </th>
                                        <th>Öneri
                                            <br />
                                            veren bölüm</th>
                                        <th>Uygulama
                                            <br />
                                            yeri</th>
                                        <th>Öneri 
                                            <br />
                                            özeti</th>
                                        <th>Müdür 
                                            <br />
                                            onayı</th>
                                        <th>Öneri
                                            <br />
                                            baş.Tarihi</th>
                                        <th>Planlanan
                                            <br />
                                            bitiş tarihi</th>
                                        <th>Öneri 
                                            <br />
                                            bitiş tarihi </th>
                                        <th>Öneri
                                            <br />
                                            kapanış tarihi</th>
                                        <th>Uygulama
                                            <br />
                                            görevlisi</th>
                                        <th>Uygulayan 
                                            <br />
                                            bölüm<br />
                                        </th>
                                        <th>Getiri 
                                            <br />
                                            açıklaması</th>
                                        <th>Getiri 
                                            <br />
                                            miktarı</th>
                                        <th>Ödül</th>
                                        <th>Ödül
                                            <br />
                                            veriliş tarihi</th>

                                        <th>İptal
                                            <br />
                                            nedeni</th>
                                        <th>Uygulayıcı 
                                            <br />
                                            red nedeni</th>
                                        <th>Müdür
                                            <br />
                                            red nedeni</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_dosis_tablosu" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                <asp:TextBox ID="txt_gelen_veri_oneri_durumu" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="txt_gelen_veri_lokasyon" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="txt_gelen_veri_kategori" runat="server" Style="display: none"></asp:TextBox>
                <asp:Button ID="btn_listele_lokasyon_trigger" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #a51b7c; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px; display: none"
                    CssClass="btn-danger" OnClick="btn_listele_lokasyon_trigger_Click" Height="38px" />
                <asp:Button ID="btn_listele_oneri_durumu_trigger" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #a51b7c; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px; display: none"
                    CssClass="btn-danger" OnClick="btn_listele_oneri_durumu_trigger_Click" Height="38px" />
                <asp:Button ID="btn_listele_kategori_trigger" runat="server" Text="Listele" Style="height: 35px; width: 105px; background-color: #a51b7c; font-weight: bold; border: 0px; margin-top: 15px; font-size: 14px; display: none"
                    CssClass="btn-danger" OnClick="btn_listele_kategori_trigger_Click" Height="38px" />
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
        $(document).ready(function () {

            $("#tbl_oneri_durumu tbody tr").click(function () {
                var tarih = $("#tx_rapor_tarihi").val();
                var tarih2 = $("#tx_rapor_tarihi2").val();
                var oneri_durumu = $(this).find("td").eq(0).text();

                $('#txt_gelen_veri_oneri_durumu').val(oneri_durumu);
                $("#btn_listele_oneri_durumu_trigger").trigger("click");

            });

            $("#tbl_lokasyona_gore_oneri tbody tr").click(function () {

                var tarih = $("#tx_rapor_tarihi").val();
                var tarih2 = $("#tx_rapor_tarihi2").val();
                var lokasyon = $(this).find("td").eq(0).text();
                $('#txt_gelen_veri_lokasyon').val(lokasyon);
                //if ($('#txt_gelen_veri_oneri_durumu').val() != "") {
                $("#btn_listele_lokasyon_trigger").trigger("click");
                //}
            });

            $("#tbl_kategoriye_gore_oneri tbody tr").click(function () {
                var tarih = $("#tx_rapor_tarihi").val();
                var tarih2 = $("#tx_rapor_tarihi2").val();
                var kategori = $(this).find("td").eq(0).text();

                $('#txt_gelen_veri_kategori').val(kategori);
                //if ($('#txt_gelen_veri_oneri_durumu').val() != "") {
                $("#btn_listele_kategori_trigger").trigger("click");
                // }


            });

            $("#btn_listele").click(function () {
                $('#txt_gelen_veri_oneri_durumu').val('');
                $('#txt_gelen_veri_lokasyon').val('');
                $('#txt_gelen_veri_kategori').val('')

            });

        });


    </script>
</body>
</html>