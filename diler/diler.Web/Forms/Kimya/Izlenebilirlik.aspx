<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Izlenebilirlik.aspx.cs" Inherits="diler.Web.Forms.Kimya.Izlenebilirlik" %>

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
        .tbl_baslik {
            padding: 0px;
            background-color: #e9e9e9;
            margin-bottom: 0PX;
            color: #e52293;
            font-weight: bold;
            font-size: 13px;
        }

        div.table-responsive .table tbody tr td {
            font-size: 13px !important;
            text-align: center;
            padding: 4px;
        }
    </style>

</head>
<body>

    <div class="content">
        <form class="form-horizontal" role="form" enctype="multipart/form-data" runat="server">
            <!-- Page-Title -->
            <div class="row icon-list" style="padding: 5px 0; padding-bottom: 0;">
                <div class="col-sm-4">
                    <div class="col-md-3">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="24px"
                            ImageUrl="~/Images//AnaSayfa.png" Width="29px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />

                    </div>

                </div>
                <div class="col-sm-4" style="background-color: #e8ebec; width: 600px; height: 65px; padding-top: 11px;">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="margin-left: 52px; padding-right: 0px">
                        <asp:TextBox ID="tx_dokum_no" pattern="[0-9]{10}" runat="server" TextMode="Number" placeholder="Döküm No" CssClass="form-control unstyled_date" AutoPostBack="True"
                            Style="text-align: center; font-weight: bold; border-radius: 0; height: 40px; font-size: 15px;"></asp:TextBox>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                        <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn btn-info" AutoPostBack="True"
                            Style="background-color: #e52293; font-weight: bold; font-size: Small; height: 39px; width: 92px; border: 0; border-radius: 0; margin-bottom: 3px;" OnClick="btn_Listele_Click" />
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                        <asp:TextBox ID="txt_dokumnoyagore_tarih" pattern="[0-9]{10}" runat="server" ReadOnly="true" placeholder="Döküm Tarihi"
                            Style="margin-left: 20px; height: 37px; border-radius: 0; margin-top: 1px; font-weight: bold;" CssClass="form-control unstyled_date" AutoPostBack="True">
                        </asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                <div class="">
                    <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="col-md-6">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">ARK OCAĞI </p>
                                <table id="tech-companies-1" class="table table-bordered table-striped table_ao_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Vrd</th>
                                            <th>Döküm<br />
                                                başlangıç saati</th>
                                            <th>Döküm<br />
                                                bitiş saati</th>
                                            <th>Döküm<br />
                                                Süresi</th>
                                            <th>Enerjili
                                                    <br />
                                                Süre</th>
                                            <th>Enerjisiz
                                                    <br />
                                                Süre</th>
                                            <th>Devirme<br />
                                                Sıcaklık</th>
                                            <th>ParçaKireç</th>
                                            <th>EnjekteKireç</th>
                                            <th>ParçaKok</th>
                                            <th>Dolamit</th>
                                            <th>Dev Al</th>
                                            <th>DevFesiMn</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_ao_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">POTA OCAĞI </p>
                                <table id="tech-companies-18" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>

                                            <th>Potano</th>
                                            <th> PO<br />
                                                giriş saati</th>
                                            <th>PO<br />
                                                çıkış saati</th>
                                            <th>Giriş<br />
                                                Sıcaklık</th>
                                            <th>Çıkış<br />
                                                Sıcaklık</th>
                                            <th>Enerjili<br />
                                                Süre</th>
                                            <th>C  </th>
                                            <th>Cao</th>
                                            <th>Fesi<br />
                                            </th>
                                            <th>FesiMn</th>
                                            <th>Al</th>
                                            <th>CaF2</th>
                                            <th>MgO</th>
                                            <th>Boksit</th>
                                            <th>Fev</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_po_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">HURDA</p>
                                <table id="" class="table table-bordered table-striped table_toplam_hurda">
                                    <thead>
                                        <tr>

                                            <th>Toplam hurda</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_toplam_hurda" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="col-md-6">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">SDM</p>
                                <table id="" class="table table-bordered table-striped table_sdm_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Açma Saati</th>
                                            <th>Kapama Saati</th>
                                            <th>Yol1</th>
                                            <th>Yol2 </th>
                                            <th>Yol3 </th>
                                            <th>Yol4 </th>
                                            <th>Yol5 </th>
                                            <th>Yol6 </th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_sdm_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-3">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">KÜTÜK</p>
                                <table id="" class="table table-bordered table-striped table_izlenebilirlik_urt">
                                    <thead>
                                        <tr>

                                            <th>Boy</th>
                                            <th>Ebat</th>
                                            <th>Kalite</th>
                                            <th>Std</th>
                                            <th>Std dışı  </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_uretim_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-3">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">FİLMAŞİNE SEVK EDİLEN </p>
                                <table id="" class="table table-bordered table-striped table_ao_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Kalite</th>
                                            <th>Ebat</th>
                                            <th>Boy</th>
                                            <th>Kütük
                                                    <br />
                                                Sayısı</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_filmasin_sevk_kutuk" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>

                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">TAVFIRIN SICAKLIK </p>
                                <table id="" class="table table-bordered table-striped table_tavfrn_sicaklik">
                                    <thead>
                                        <tr>

                                            <th>Dökümno</th>
                                            <th>4.Bölge</th>
                                            <th>5.Bölge</th>
                                            <th>6.Bölge</th>
                                            <th>Kütük sıcaklığı</th>
                                            <th>Ebat </th>
                                            <th>Boy</th>
                                            <th>Kalite</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_tavfrn_sicaklik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">FIRIN İÇİ </p>
                                <table id="" class="table table-bordered table-striped table_ao_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Yıl</th>
                                            <th>Şarj<br />
                                                Tipi</th>
                                            <th>Çıkış
                                                    <br />
                                                Tarihi</th>
                                            <th>Giriş
                                                    <br />
                                                Saati</th>
                                            <th>Çıkış<br />
                                                Saati</th>
                                            <th>Çelik Cinsi </th>
                                            <th>Kütük Sayısı</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_tavfrn_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">FIRINDAN ÇIKAN </p>
                                <table id="" class="table table-bordered table-striped table_ao_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Tarih</th>
                                            <th>Çelik Cinsi</th>
                                            <th>Kütük Sayısı</th>
                                            <%--   <th>Giriş Saati</th>
                                            <th>Çıkış Saati</th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_firindan_dusmus" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>


                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">

                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">FİZİK </p>
                                <table id="" class="table table-bordered table-striped table_fizik_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Dökümno</th>
                                            <th>Çap</th>
                                            <th>Akma</th>
                                            <th>Çekme</th>
                                            <th>Uzama</th>
                                            <th>Çekme/Akma</th>
                                            <th>Agt</th>
                                            <th>Bend</th>
                                            <th>Rbend</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_fizik_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">TEMPCORE </p>
                                <table id="" class="table table-bordered table-striped table_tempcore_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Dökümno</th>
                                            <th>Debi<br />
                                                A</th>
                                            <th>Debi<br />
                                                B</th>
                                            <th>Debi<br />
                                                C</th>
                                            <th>Debi<br />
                                                D</th>
                                            <th>Mamul kalite</th>
                                            <th>Cap</th>
                                            <th>Nozul Çapı</th>
                                            <th>Hız</th>
                                            <th>Pompa Sayısı</th>
                                            <th>Pompa Basıncı</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_tempcore_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">ÇELİKHANE İSTİF HOLÜ </p>
                                <table id="" class="table table-bordered table-striped table_celikhane_istif_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Stok yeri</th>
                                            <th>İstif yeri</th>
                                            <th>Kütük sayısı</th>
                                            <th>Çelik cinsi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_celikhane_istif_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik">HADDEHANE İSTİF HOLÜ</p>
                                <table id="" class="table table-bordered table-striped table_haddahane_istif_izlenebilirlik">
                                    <thead>
                                        <tr>

                                            <th>Stok yeri</th>
                                            <th>İstif yeri</th>
                                            <th>Kütük sayısı</th>
                                            <th>Çelik cinsi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_haddahane_istif_izlenebilirlik" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                </div>

                <div class="clear"></div>
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
