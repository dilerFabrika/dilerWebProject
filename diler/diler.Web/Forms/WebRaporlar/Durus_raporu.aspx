<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Durus_raporu.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.Durus_raporu" %>

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
            text-align:center;
            padding:6px;
             border: 1px solid #f9d3d3;
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
    </style>

</head>

<body>
    <form runat="server">

        <div class="row icon-list">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="background-color: #add8e6; width: 600px; height: 65px;">
                <div class="table-responsive" style="border: 0px;">
                    <table class="table" style="padding: 0; margin: 0; border: none;">
                        <tbody>
                            <div class="col-md-4 col-sm-4" style="margin-top: 15px;">
                                <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                            </div>
                            <div class="col-md-4 col-sm-4" style="margin-top: 15px;">
                                <asp:TextBox ID="tx_rapor_tarihi2" runat="server" TextMode="Date" CssClass="form-control unstyled_date"></asp:TextBox>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger"
                                    Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #890d62;" OnClick="btn_Listele_Click" />
                                <asp:ImageButton ID="ImageButton2" runat="server" Style="height: 23px; width: 29px; background-color: #add8e6; margin-left: 20px;"
                                    ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" />
                            </div>

                        </tbody>
                    </table>

                </div>

            </div>
        </div>
        <ul class="nav nav-pills" style="margin-top: 10PX;">
            <li class="active">
                <a href="#1a" data-toggle="tab">DURUŞ RAPORU</a>
            </li>
            <li><a href="#2a" data-toggle="tab">DURUŞ AYRINTI</a>
            </li>

        </ul>
        <div class="tab-content clearfix">

            <div class="tab-pane active" id="1a">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">

                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body">
                                <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">DURUŞ NEDEN LİSTESİ</</p>
                                <div class="table-responsive" data-pattern="priority-columns">
                                        <table id="tech-companies-1" class="table table-bordered table-striped durus_tablosu">
                                        <thead>
                                            <tr>
                                                <th>Duruş nedeni</th>
                                                <th>Duruş süresi</th>
                                                <th>Adet</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_durus_tablosu" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body">
                                <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">DÖKÜM BAZINDA ARIZA NEDENLERİ </p>
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-12" class="table table-bordered table-striped durus_tablosu2">
                                        <thead>
                                            <tr>
                                                <th>Tarih</th>
                                                <th>Vrd</th>
                                                <th>Döküm no</th>
                                                <th>Arıza nedeni</th>
                                                <th>Arıza Kodu</th>
                                                <th>Süre</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_durus_tablosu2" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body">
                                <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">DURUŞ NEDENİ BAZINDA ARIZA SÜRE TOPLAMI </p>
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-123" class="table table-bordered table-striped durus_tablosu4">
                                        <thead>
                                            <tr>

                                                <th>Duruş nedeni</th>
                                                <th>Arıza nedeni</th>
                                                <th>Arıza Kodu</th>
                                                <th>Toplam döküm</th>
                                                <th>Süre</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_durus_tablosu4" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="fillname" value="" Style="opacity: 0">  </asp:TextBox>
                    <asp:TextBox runat="server" ID="txt_arizakod" value="" Style="opacity: 0" OnTextChanged="txt_arizakod_TextChanged">  </asp:TextBox>

                </div>

            </div>
            <div class="tab-pane" id="2a">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                            <p class="tbl_baslik" style="background-color: #890d62; color: #FFF; margin-bottom: 0PX;">DURUŞ LİSTESİ</</p>
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-18" class="table table-bordered table-striped durus_tablosu3">
                                    <thead>
                                        <tr>
                                            <th>Döküm no</th>
                                            <th>Vrd</th>
                                            <th>Tarih</th>
                                            <th>Başlangıç Saati</th>
                                            <th>Bitiş Saati</th>
                                            <th>Net süre</th>
                                            <th>Duruş nedeni</th>
                                            <th>Duruş Kodu</th>
                                            <th>Arıza nedeni</th>
                                            <th>Arıza Kodu</th>
                                            <th>Şarj durumu</th>
                                            <th>Açıklama</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_durus_tablosu3" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

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
        <!-- Bootstrap core JavaScript
       ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>--%>
        <script src="../../js/jquery-1.11.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../js/notify.js"></script>

        <br />
        <script type="text/javascript">

            var pickedup;

            $(document).ready(function () {

                $("#tech-companies-1 tbody tr").click(function () {
                    if (pickedup != null) {
                        pickedup.css("background-color", "#ffffff");
                    }
                    $(this).css("background-color", "#dbb3ce");
                    pickedup = $(this);

                    $(this).addClass('selected').siblings().removeClass('selected');
                    $("#fillname").val($(this).find("td").eq(0).html());

                    $("#btn_Listele").trigger("click");

                });
            });

            $(document).ready(function () {

                $("#tech-companies-12 tbody tr").click(function () {

                    var tarih = $("#tx_rapor_tarihi").val();
                    var tarih2 = $("#tx_rapor_tarihi2").val();
                    if (pickedup != null) {
                        pickedup.css("background-color", "#ffffff");
                    }
                    $(this).css("background-color", "#dbb3ce");
                    pickedup = $(this);

                    $(this).addClass('selected').siblings().removeClass('selected');
                    $("#txt_arizakod").val($(this).find("td").eq(4).html());
                    var arizakodu = $(this).find("td").eq(4).text();


                    $.ajax({
                        type: "POST",
                        url: "Durus_raporu.aspx/detay",
                        data: "{'arizakodu':'" + arizakodu + "','tarih':'" + tarih + "','tarih2':'" + tarih2 + "'}",
                        contentType: "application/json",
                        dataType: "json",
                        success: function (result) {
                            alert(result.d);

                        },
                        error: function () {
                            alert("Tekrar deneyiniz!");
                        },
                    });


                });
            });

            var ALERT_TITLE = "";
            var ALERT_BUTTON_TEXT = "TAMAM";

            if (document.getElementById) {
                window.alert = function (txt) {
                    createCustomAlert(txt);
                }
            }

            function createCustomAlert(txt) {
                d = document;

                if (d.getElementById("modalContainer")) return;

                mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
                mObj.id = "modalContainer";
                mObj.style.height = d.documentElement.scrollHeight + "px";

                alertObj = mObj.appendChild(d.createElement("div"));
                alertObj.id = "alertBox";
                if (d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
                alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth) / 2 + "px";
                alertObj.style.visiblity = "visible";

                h1 = alertObj.appendChild(d.createElement("h1"));
                h1.appendChild(d.createTextNode(ALERT_TITLE));

                msg = alertObj.appendChild(d.createElement("p"));
                //msg.appendChild(d.createTextNode(txt));
                msg.innerHTML = txt;

                btn = alertObj.appendChild(d.createElement("a"));
                btn.id = "closeBtn";
                btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
                btn.href = "#";
                btn.focus();
                btn.onclick = function () { removeCustomAlert(); return false; }

                alertObj.style.display = "block";

            }

            function removeCustomAlert() {
                document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
            }
            function ful() {
                alert('Alert this pages');
            }
        </script>
    </form>
</body>

</html>