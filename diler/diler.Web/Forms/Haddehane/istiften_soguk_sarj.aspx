<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="istiften_soguk_sarj.aspx.cs" Inherits="diler.Web.Forms.Haddehane.istiften_soguk_sarj" %>


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

        .istif_takip tbody tr:first-child td {
            /*background-color: #ffaaa8;*/
            background-color: #e2d0ec;
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
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #6f2398; margin-left: 30px; font-weight: bold;">STOK VE İSTİF BAZINDA DÖKÜM TAKİBİ</p>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td style="width: 150px">Stok yeri:
                                        <asp:DropDownList ID="Cmb_stok_yeri" runat="server" CssClass="form-control unstyled_date" AutoPostBack="True" Style="width: 150px"
                                            OnSelectedIndexChanged="Cmb_stok_yeri_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Stok yeri seçiniz</asp:ListItem>
                                            <asp:ListItem>Çelikhane</asp:ListItem>
                                            <asp:ListItem>Haddehane</asp:ListItem>
                                            <asp:ListItem>Filmaşin</asp:ListItem>
                                            <asp:ListItem>Tavşancıl</asp:ListItem>
                                            <asp:ListItem>Assan Park Saha</asp:ListItem>
                                            <asp:ListItem>Resa</asp:ListItem>
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
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs8">
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
                                            <th class="action">Gönder</th>

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

                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body">
                                <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-12" class="table table-bordered table-striped istif_takip_ozet">
                                        <thead>
                                            <tr>
                                                <th>Yer</th>
                                                <th>Adet</th>
                                                <th>Ebat</th>
                                                <th>Çelik cinsi</th>
                                                <th>Boy</th>
                                                <th>Çelik cinsi Orj<br />
                                                </th>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_istif_Ozet" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                            <asp:TextBox ID="txt_genel_aciklama" runat="server" Style="border: 0px solid; width: 550px; height: 110px; color: #4e51cc; font-weight: bold; font-size: 13px;" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                            <asp:TextBox ID="txt_genel_aciklama2" runat="server" Style="border: 0px solid; width: 550px; height: 50px; color: #ff0000; font-weight: bold; font-size: 14px;" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                            <asp:TextBox ID="txt_genel_aciklama3" runat="server" Style="border: 0px solid; width: 550px; height: 100px; color: #4e51cc; font-weight: bold; font-size: 13px;" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
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
        $(".ktk_gonder").click(function () {

            var row = $(this).closest('tr');
            // var istif_yeri = $('#Cmb_istif_yeri').val();
            var istif_sira_no = row.find('td:eq(0)').text();
            var dokum_no = row.find('td:eq(2)').text();
            var istif_adet = row.find('td:eq(5)').text();
            var istif_yeri = row.find('td:eq(4)').text();
            var kalite = row.find('td:eq(6)').text();
            var boy = row.find('td:eq(7)').text();
            var ebat = row.find('td:eq(8)').text();
            var siparis_no = row.find('td:eq(9)').text();
            var row_number = row.index();

            if (row_number == 0) {
                var answer = confirm("Fırına atmak istediğinizden emin misiniz?");
                if (answer == true) {
                    $.ajax({
                        type: "POST",
                        url: "istiften_soguk_sarj.aspx/soguksarja_kutuk_gonder",
                        data: "{'dokum_no':'" + dokum_no + "','istif_adet': '" + istif_adet + "','istif_sirano': '" + istif_sira_no + "','istif_yeri':'" + istif_yeri + "','kalite':'" + kalite + "','boy': '" + boy + "','ebat':'" + ebat + "','siparis_no':'" + siparis_no + "'}",
                        contentType: "application/json",
                        dataType: "json",
                        success: function (result) {
                            if (result.d == 1) {
                                alert("FIRIN İÇİ TRANSFER İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ");
                            }
                            else {
                                alert("        FIRINA GÖNDERECEĞİNİZ ADET FAZLA !!!      ");
                            }
                        },

                    });
                }
                //else {
                //    alert(" FIRIN İÇİ TRANSFER İŞLEMİ İPTAL EDİLDİ ");
                //}

            }

            else {
                alert("LÜTFEN İLK SATIRDAKİ DÖKÜMÜ GÖNDERİNİZ !! ");
            }
            location.reload();
            $("#btn_Listele").trigger("click");

        });

    </script>
</body>
</html>
