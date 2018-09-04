<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tanimlar.aspx.cs" Inherits="diler.Web.Forms.EndMuh.Tanimlar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />


    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
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
            text-align: center;
            padding:6px;
        }

        .nav-pills li a {
            border-radius: 4px;
            text-decoration: none;
        }

        div .table-responsive .table thead tr th {
            line-height: 1em;
            font-weight: bold;
            font-size: 12px !important;
            text-align: center;
            padding: 1px;
            margin: 0;
        }


        .nav-pills > li.active > a, .nav-pills > li.active > a:focus, .nav-pills > li.active > a:hover {
            color: #fff;
            background-color: #890d62;
            FONT-WEIGHT: BOLD;
        }

        .nav-pills > li {
            FONT-WEIGHT: BOLD;
        }




        #modalContainer {
            background-color: rgba(0, 0, 0, 0.3);
            position: absolute;
            top: 0;
            width: 100%;
            height: 100%;
            left: 0px;
            z-index: 10000;
        }

        #alertBox {
            position: relative;
            width: 33%;
            min-height: 100px;
            max-height: 400px;
            margin-top: 50px;
            border: 1px solid #fff;
            background-color: #fff;
            background-repeat: no-repeat;
            top: 30%;
            BORDER-RADIUS: 4px;
        }

        #modalContainer > #alertBox {
            position: fixed;
        }

        #alertBox h1 {
            margin: 0;
            font: bold 1em Raleway,arial;
            color: #FFF;
        }

        #alertBox p {
            FONT-WEIGHT: BOLD;
            FONT-SIZE: 15PX;
            height: 50px;
            padding-left: 5px;
            padding-top: 14px;
            text-align: center;
            vertical-align: middle;
        }

        #alertBox #closeBtn {
            display: block;
            position: relative;
            margin: 10px auto 10px auto;
            padding: 7px;
            border: 0 none;
            width: 100px;
            text-transform: uppercase;
            text-align: center;
            color: #FFF;
            background-color: #1f9caf;
            border-radius: 0px;
            text-decoration: none;
            outline: 0 !important;
            FONT-WEIGHT: BOLD;
        }

        /* unrelated styles */

        #mContainer {
            position: relative;
            width: 600px;
            margin: auto;
            padding: 5px;
            border-top: 2px solid #fff;
            border-bottom: 2px solid #fff;
        }

        h1, h2 {
            margin: 0;
            padding: 4px;
        }

        code {
            font-size: 1.2em;
            color: #069;
        }

        #credits {
            position: relative;
            margin: 25px auto 0px auto;
            width: 350px;
            font: 0.7em verdana;
            border-top: 1px solid #000;
            border-bottom: 1px solid #000;
            height: 90px;
            padding-top: 4px;
        }

            #credits img {
                float: left;
                margin: 5px 10px 5px 0px;
                border: 1px solid #000000;
                width: 80px;
                height: 79px;
            }

        .important {
            background-color: #F5FCC8;
            padding: 2px;
        }

        @media (max-width: 600px) {
            #alertBox {
                position: relative;
                width: 90%;
                top: 30%;
            }
        }
    </style>

</head>

<body>
    <form runat="server">

         <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 23px; width: 29px;"
                            ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" />

        <ul class="nav nav-pills" style="margin-top: 10PX; ">
            <li class="active">
                <a href="#1a" data-toggle="tab">StdKlt Tanım Kayıt</a>
            </li>
            <li><a href="#2a" data-toggle="tab">Tanım Kayıt</a>
            </li>
      

        </ul>
        <div class="tab-content clearfix">

            <div class="tab-pane active" id="1a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #b73076; margin-top: 10px; font-weight: bold;">STANDART KALİTE EKLEME</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-sm-5" style="margin-top: 25px;">
                            <div id="PanelRegisterForm">
                                <div class="form-group">
                                    Tesis:
                                    <asp:TextBox ID="tx_tesis" class="form-control" runat="server" Text="HH" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    Tanım Tipi:
                          <asp:TextBox ID="tx_tanim_tipi" class="form-control" runat="server" Text="STDKLT" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    Standart Açıklama:
                               <asp:DropDownList class="form-control" ID="ddl_std_aciklama" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    Kalite açıklaması:
                                 <asp:DropDownList class="form-control" ID="ddl_kalite_aciklama" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                            <asp:Button ID="btnRegister" runat="server" Style="width: 85px; background-color: #b73076; font-weight: bold; border-color: #b73076; border-radius: 0px" CssClass="btn btn-primary" Text="Kayıt" OnClick="btnRegister_Click" />



                        </div>
                        <div class="col-md-7" style="margin-top: 25px;">

                            <div class="table-responsive" data-pattern="priority-columns">
                                <p class="tbl_baslik" style="background-color: #b73076; color: #FFF; margin-bottom: 0PX;">TANIMLAR </p>
                                <table id="tech-companies-1" class="table table-bordered table-striped table_ao_izlenebilirlik">
                                    <thead>
                                        <tr>
                                            <th>TESİS</th>
                                            <th>TANIM TİPİ</th>
                                            <th>KOD</th>
                                            <th>KOD_ACK</th>

                                            <th>PRG1</th>
                                            <th>PRG2</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_stdklt_tablosu" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane" id="2a">
                <div class="col-sm-12" style="margin-top: 20px">
                 
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" style="background-color: #d6d6d6;">
                        <div id="PanelRegisterFormm">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Tesis:
                                 <asp:DropDownList ID="cmb_tesis_tanim" runat="server" class="form-control">
                                     <asp:ListItem>CH</asp:ListItem>
                                     <asp:ListItem>HH</asp:ListItem>
                                     <asp:ListItem>FLM</asp:ListItem>
                                 </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Tanım tipi:
                                 <asp:DropDownList ID="cmb_tanimtipi_tanim" runat="server" class="form-control">
                                     <asp:ListItem>BOY</asp:ListItem>
                                     <asp:ListItem>CAP</asp:ListItem>
                                     <asp:ListItem>EBAT</asp:ListItem>
                                     <asp:ListItem>KALITE</asp:ListItem>
                                     <asp:ListItem>STANDART</asp:ListItem>
                                 </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btn_Listele" runat="server" Style="width: 85px; background-color: #525252; font-weight: bold; margin-top: 15px; border-color: #525252; border-radius: 0px"
                            CssClass="btn btn-primary" Text="Listele" OnClientClick="return false" />
                    </div>
                    <div class="col-sm-1"></div>

                </div>

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-sm-5" style="margin-top: 25px;">
                            <div id="PanelRegisterFormj">
                                <div class="form-group">
                                    Tanım tipi açıklaması:(Kod_Ack)
                                    <asp:TextBox ID="txt_tanim_tipi_aciklamasi" class="form-control" value="" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    As 400 Kod:
                          <asp:TextBox ID="txt_as400_kod" class="form-control" value="" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    As 400 Ambardepo:
                                    <asp:TextBox ID="txt_as400ambardepo" class="form-control" value="" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="btn_yeni_tanim_ekle" runat="server" Style="width: 125px; background-color: #525252; font-weight: bold; margin-top: 15px; border-color: #525252; border-radius: 0px"
                                    CssClass="btn btn-primary" Text="Yeni Tanım Ekle" OnClientClick="return false" />
                            </div>

                            
                        </div>

                        <div class="col-sm-7">
                            <div class="panel">
                                <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">
                                    <p class="tbl_baslik" style="background-color: #b73076; color: #FFF; margin-bottom: 0PX;">TANIMLAR </p>
                                    <table id="" class="table table-bordered table-striped table_tanim_listesi">
                                        <thead>
                                            <tr>
                                                <th>TESİS</th>
                                                <th>TANIM TİPİ</th>
                                                <th>KOD</th>
                                                <th>KOD_ACK</th>
                                                <th>EKRAN SIRA NO</th>
                                                <th>EKRAN DURUM</th>
                                                <th>As400 Kod</th>
                                                <th>As400 Ambardepo</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_tanim_giris" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>

                                </div>

                            </div>
                        </div>


                    </div>

                    <div class="clear"></div>
                </div>

            </div>
        </div>

        <div class="clear"></div>


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
        <!-- Bootstrap core JavaScript
       ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>--%>
        <script src="../../js/jquery-1.11.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../js/notify.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#btn_Listele').click(function () {
                    $(function () {
                        var tesis = $('#cmb_tesis_tanim').val();
                        var tanim_tipi = $('#cmb_tanimtipi_tanim').val();
                        $.ajax({
                            type: 'POST',
                            url: 'Tanimlar.aspx/tanimlari_listele',
                            data: '{"tanim_tipi":"' + tanim_tipi + '","tesis":"' + tesis + '"}',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (result) {
                                $.each($("table.table_tanim_listesi"), function (i, l) {
                                    $(this).find("tbody").html("").html("<tr><td>" + result.d[i] + "</td></tr>");
                                });
                            },
                            error: function () {
                                alert("Tekrar deneyiniz!");
                            }, complete: function () {
                                ajax_istegi_dokum = 0;
                            }
                        });

                    });
                });
            });


            $(document).ready(function () {

                $('#btn_yeni_tanim_ekle').click(function () {

                    var tesis = $("#cmb_tesis_tanim").val();
                    var tanim_tipi = $("#cmb_tanimtipi_tanim").val();
                    var kod_ack = $("#txt_tanim_tipi_aciklamasi").val();
                    var as400_kod = $("#txt_as400_kod").val();
                    var as400ambar_depo = $("#txt_as400ambardepo").val();
                    if (kod_ack == "") {

                        alert("Lütfen tanım tipi açıklamasını yazınız !!")
                    }
                    else {
                        //alert(tesis);


                        {
                            $.ajax({
                                type: "POST",
                                url: "Tanimlar.aspx/yeni_tanim_ekle",
                                data: "{'tesis':'" + tesis + "','tanim_tipi':'" + tanim_tipi + "','kod_ack': '" + kod_ack + "','as400_kod':'" + as400_kod + "','as400ambar_depo':'" + as400ambar_depo + "'}",
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (result) {
                                    if (result.d == 1) {
                                        alert("Tanım bilgileri başarıyla kaydedildi.");
                                    } else {
                                        alert("Hata tekrar deneyin !!");

                                    }
                                },
                                error: function () {
                                    alert("Tekrar deneyiniz!");
                                },

                            });



                            $("#btn_Listele").trigger("click");
                        }
                    }

                });
            });

        </script>

    </form>
</body>

</html>
