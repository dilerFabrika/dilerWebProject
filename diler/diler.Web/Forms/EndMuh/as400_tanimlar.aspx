<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="as400_tanimlar.aspx.cs" Inherits="diler.Web.Forms.EndMuh.as400_tanimlar" %>


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
        }

        div.table-responsive .table thead tr th {
            font-size: 12px !important;
        }

        .fa-trash:hover {
            color: #e26fb6 !important;
        }

        .tanim_tablosu:hover {
            background: #ead4e2 !important;
        }

        }
    </style>
</head>

<body>
    <form class="form-horizontal" role="form" enctype="multipart/form-data" runat="server">
        <!-- Page-Title -->
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                <p style="text-align: center; padding: 2px; font-size: 18px; color: #1f1d1e; margin-left: 30px; font-weight: bold;">AS400 TANIM DÜZENLEME EKRANI</p>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                    <tbody style="border: none;">
                        <tr>
                            <td style="width: 120px"></td>
                            <td style="width: 190px">Tanım tipi:
                                 <asp:DropDownList ID="cmb_tanimtipi" runat="server" class="form-control">
                                     <asp:ListItem>BOY</asp:ListItem>
                                     <asp:ListItem>CAP</asp:ListItem>
                                     <asp:ListItem>KALITE</asp:ListItem>
                                     <asp:ListItem>MAMULSTANDART</asp:ListItem>
                                 </asp:DropDownList>
                            </td>

                            <td style="width: 100px">

                                <asp:Button ID="btn_listele" runat="server" Text="Listele" CssClass="btn-danger"
                                    Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #e26fb6" OnClick="btn_listele_Click" />

                            </td>
                            <td>
                                <asp:ImageButton ID="Image_home" runat="server" Style="height: 23px; width: 29px; margin-top: 15px" OnClick="Image_home_Click"
                                    ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                        </tr>
                    </tbody>
                </table>

            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
        </div>


        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 5px;">
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs8">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped tanim_listesi">
                                <thead>
                                    <tr>
                                        <th>AS 400 Kod</th>
                                        <th>AS 400 İsim</th>
                                        <th>Pc Kod</th>
                                        <th>Pc İsim</th>

                                        <th class="action">Sil</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_tanim_listesi" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div id="PanelRegisterForm">
                    <div class="form-group">
                        AS400 Kod 
                        <asp:TextBox ID="txt_as400_kod" class="form-control" value="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        As400 İsim: 
                        <asp:TextBox ID="txt_as400_isim" class="form-control" value="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        Pc Kod:  
                        <asp:TextBox ID="txt_pcKod" class="form-control" value="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        Pc İsim:
                        <asp:TextBox ID="txt_pcİsim" class="form-control" value="" runat="server"></asp:TextBox>
                    </div>

                    <asp:Button ID="btn_yeni_tanim_ekle" runat="server" Style="width: 125px; background-color: #525252; font-weight: bold; margin-top: 15px; border-color: #525252; border-radius: 0px"
                        CssClass="btn btn-primary" Text="Tanım Ekle" OnClick="btn_yeni_tanim_ekle_Click" />
                    <%--  <asp:Button ID="Btn_tanim_guncelle" runat="server" Style="width: 125px; background-color: #525252; font-weight: bold; margin-top: 15px; border-color: #525252; border-radius: 0px"
                        CssClass="btn btn-primary" Text="Güncelle" OnClick="Btn_tanim_guncelle_Click" />--%>
                </div>
            </div>
        </div>

    </form>

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



        $("#tech-companies-1 tbody tr").click(function () {

            var as400_kod = $(this).find("td").eq(0).text();
            var as400_isim = $(this).find("td").eq(1).text();
            var pc_kod = $(this).find("td").eq(2).text();
            var pc_isim = $(this).find("td").eq(3).text();

            $("#txt_as400_kod").val(as400_kod);
            $("#txt_as400_isim").val(as400_isim);
            $("#txt_pcKod").val(pc_kod);
            $("#txt_pcİsim").val(pc_isim);


        });


        $(".tanim_sil").click(function () {
            var row = $(this).closest('tr');

            // var istif_yeri = $('#Cmb_istif_yeri').val();
            var as400_kod = row.find('td:eq(0)').text();
            var as400_isim = row.find('td:eq(1)').text();
            var pc_isim = row.find('td:eq(3)').text();
            var tanim_tipi = $("#cmb_tanimtipi").val();

            var answer = confirm("Tanımı silmek istediğinizden emin misiniz?");
            if (answer == true) {
                $.ajax({
                    type: "POST",
                    url: "as400_tanimlar.aspx/as400_tanim_sil",
                    data: "{'as400_kod':'" + as400_kod + "','as400_isim': '" + as400_isim + "','pc_isim': '" + pc_isim + "','tanim_tipi': '" + tanim_tipi + "'}",
                    contentType: "application/json",
                    dataType: "json",
                    success: function (result) {
                        if (result.d == 1) {
                            alert("TANIM SİLİNDİ.");
                        }
                        else {
                            alert("   HATA OLUŞTU TEKRAR DENEYİNİZ!!     ");
                        }
                    },

                });
                $("#btn_listele").trigger("click");
            }


        });

    </script>
</body>

</html>