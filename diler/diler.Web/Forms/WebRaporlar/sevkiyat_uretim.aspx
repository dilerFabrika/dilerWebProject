<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sevkiyat_uretim.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.sevkiyat_uretim" %>

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
            font-size: 14px !important;
            text-align: center;
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

        <ul class="nav nav-pills" style="margin-top: 10PX;">
            <li class="active">
                <a href="#1a" data-toggle="tab">Döküm no Bulma</a>
            </li>
            <li><a href="#2a" data-toggle="tab">Dökümno + Çap</a>
            </li>
            <li><a href="#3a" data-toggle="tab">Sipno + Çap</a>
            </li>

        </ul>
        <div class="tab-content clearfix">

            <div class="tab-pane active" id="1a">
                <div class="col-sm-12" style="margin-top: 20px">

                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" style="background-color: #add8e6;">
                        <div id="PanelRegisterFormm1">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Tarih:
                                  <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Tike No:
                               <asp:TextBox ID="txt_tikeno" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <asp:Button ID="Btn_liste" runat="server" Style="width: 85px; background-color: #890d62; font-weight: bold; margin-top: 15px; border-color: #890d62; border-radius: 0px"
                            CssClass="btn btn-primary" Text="Listele" OnClientClick="return false" />
                    </div>
                    <div class="col-sm-1"></div>

                </div>

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">

                                <table id="" class="table table-bordered table-striped table_tike_dno_listesi">
                                    <thead>
                                        <tr>
                                            <th>Dökümno</th>
                                            <th>Çap</th>
                                            <th>Boy</th>
                                            <th>Standart</th>
                                            <th>Kalite</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_dnoya_gore" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="2a">
                <div class="col-sm-12" style="margin-top: 20px">

                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" style="background-color: #add8e6;">
                        <div id="PanelRegisterFormm2">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Döküm no:
                                  <asp:TextBox ID="Txt_dno" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Çap:
                                 <asp:TextBox ID="Txt_cap1" runat="server" CssClass="form-control unstyled_date"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btn_Listele" runat="server" Style="width: 85px; background-color: #890d62; font-weight: bold; margin-top: 15px; border-color: #890d62; border-radius: 0px"
                            CssClass="btn btn-primary" Text="Listele" OnClientClick="return false" />
                    </div>
                    <div class="col-sm-1"></div>

                </div>

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">

                                <table id="" class="table table-bordered table-striped table_dno_cap">

                                    <thead>
                                        <tr>
                                            <th>Tarih</th>
                                            <th>Çelik Kalitesi</th>
                                            <th>İ.S Kütük (Ton)</th>
                                            <th>Mamul Kalitesi</th>
                                            <th>Ebat</th>
                                            <th>Boy</th>
                                            <th>N Y</th>
                                            <th>F D</th>
                                            <th>Mamul tonajı</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_dno_cap" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                    <div class="clear"></div>
                </div>

            </div>
            <div class="tab-pane" id="3a">
                <div class="col-sm-12" style="margin-top: 20px">

                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" style="background-color: #add8e6;">
                        <div id="PanelRegisterFormm3">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Sipariş no:
                                 <asp:TextBox ID="Txt_siparisno" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    Çap:
                                  <asp:TextBox ID="Txt_cap" runat="server" CssClass="form-control unstyled_date"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btn_listele_sip" runat="server" Style="width: 85px; background-color: #890d62; font-weight: bold; margin-top: 15px; border-color: #890d62; border-radius: 0px"
                            CssClass="btn btn-primary" Text="Listele" OnClientClick="return false" />
                    </div>
                    <div class="col-sm-1"></div>

                </div>

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;"></h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">

                        <div class="panel">
                            <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 25px">
                                <table id="" class="table table-bordered table-striped table_sipno_cap">

                                    <thead>
                                        <tr>
                                            <th>Tarih</th>
                                            <th>Çelik Kalitesi</th>
                                            <th>İ.S Kütük (Ton)</th>
                                            <th>Mamul Kalitesi</th>
                                            <th>Ebat</th>
                                            <th>Boy</th>
                                            <th>N Y</th>
                                            <th>F D</th>
                                            <th>Mamul tonajı</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_siparis_cap" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>

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
                $('#Btn_liste').click(function () {
                    $(function () {
                        var tarih = $('#tx_rapor_tarihi').val();
                        var tike_no = $('#txt_tikeno').val();
                        if (tike_no == "") {
                            alert("Lütfen Tüm Alanları doldurunuz!");
                        } else {
                            $.ajax({
                                type: 'POST',
                                url: 'sevkiyat_uretim.aspx/tike_noya_gore_dno_listele',
                                data: '{"tarih":"' + tarih + '","tike_no":"' + tike_no + '"}',
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (result) {
                                    $.each($("table.table_tike_dno_listesi"), function (i, l) {
                                        $(this).find("tbody").html("").html("<tr><td>" + result.d[i] + "</td></tr>");
                                    });
                                },
                                error: function () {
                                    alert("Tekrar deneyiniz!");
                                }, complete: function () {
                                    ajax_istegi_dokum = 0;
                                }
                            });
                        }

                    });
                });
            });


            $(document).ready(function () {
                $('#btn_Listele').click(function () {
                    $(function () {
                        var dokum_no = $('#Txt_dno').val();
                        var cap = $('#Txt_cap1').val();
                        if (dokum_no == "") {
                            alert("Lütfen Tüm Alanları doldurunuz!");
                        } else {
                            $.ajax({
                                type: 'POST',
                                url: 'sevkiyat_uretim.aspx/dno_veya_capa_gore_listele',
                                data: '{"dokum_no":"' + dokum_no + '","cap":"' + cap + '"}',
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (result) {
                                    $.each($("table.table_dno_cap"), function (i, l) {
                                        $(this).find("tbody").html("").html("<tr><td>" + result.d[i] + "</td></tr>");
                                    });
                                },
                                error: function () {
                                    alert("Tekrar deneyiniz!");
                                }, complete: function () {
                                    ajax_istegi_dokum = 0;
                                }
                            });
                        }

                    });
                });
            });

            $(document).ready(function () {
                $('#btn_listele_sip').click(function () {
                    $(function () {
                        var siparis_no = $('#Txt_siparisno').val();
                        var cap = $('#Txt_cap').val();
                        if (siparis_no == "") {
                            alert("Lütfen Tüm Alanları doldurunuz!");
                        } else {
                            $.ajax({
                                type: 'POST',
                                url: 'sevkiyat_uretim.aspx/sipno_ve_capa_gore_listele',
                                data: '{"siparis_no":"' + siparis_no + '","cap":"' + cap + '"}',
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (result) {
                                    $.each($("table.table_sipno_cap"), function (i, l) {
                                        $(this).find("tbody").html("").html("<tr><td>" + result.d[i] + "</td></tr>");
                                    });
                                },
                                error: function () {
                                    alert("Tekrar deneyiniz!");
                                }, complete: function () {
                                    ajax_istegi_dokum = 0;
                                }
                            });
                        }

                    });
                });
            });

        </script>

    </form>
</body>

</html>
