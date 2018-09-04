<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iyilestirme_raporu.aspx.cs" Inherits="diler.Web.Forms.Dosis.iyilestirme_raporu" %>

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
            font-size: 13px !important;
            text-align: center;
            padding: 4px;
        }

        .table_t:hover {
            background: #e2bfd8 !important;
            /*background: #f5cbe8 !important;*/
            /*background: #dab8d0 !important;*/
        }

        div.table-responsive .dosis_iyilestirme_ayrinti tbody tr td {
            text-align: left;
            padding: 8px;
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
                    <p style="text-align: center; padding: 10px; font-size: 18px; color: #a51b7c; margin-left: 30px; font-weight: bold;">DÖSİS İYİLEŞTİRME RAPORU</p>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>

                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                    <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td style="width: 100px">Yıl seçiniz:                               
                                    <asp:DropDownList ID="cmb_yil" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False" Style="width: 100px">
                                        <asp:ListItem Selected="True" Value="Tümü">Tümü</asp:ListItem>
                                        <asp:ListItem Value="2012">2012</asp:ListItem>
                                        <asp:ListItem Value="2013">2013</asp:ListItem>
                                        <asp:ListItem Value="2014">2014</asp:ListItem>
                                        <asp:ListItem Value="2015">2015</asp:ListItem>
                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                        <asp:ListItem Value="2018">2018</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                                <td style="width: 220px">Bölüm seçiniz:
                                    <asp:DropDownList ID="cmb_bolum" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False" Style="width: 220px">
                                        <asp:ListItem Selected="True" Value="All">Tümü</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td style="width: 200px">Kategori seçiniz:
                                    <asp:DropDownList ID="cmb_kategori" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False" Style="width: 200px">
                                        <asp:ListItem Selected="True" Value="All">Tümü</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td style="width: 100px">

                                    <asp:Button ID="btn_listele" runat="server" Text="Listele" CssClass="btn-danger"
                                        Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #a51b7c" OnClick="btn_listele_Click" />

                                </td>
                                <td>
                                    <asp:ImageButton ID="Home_image" runat="server" Style="height: 23px; width: 29px; margin-top: 15px" OnClick="Home_image_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                            </tr>
                        </tbody>
                    </table>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>

            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                        <div class="panel-body">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tbl_iyilestirme_no" class="table table-bordered table-striped dosis_iyilestirme_no">
                                    <thead>
                                        <tr>
                                            <th>Sırano</th>
                                            <th>İyileştirme no </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_dosis_iyilestirme_no" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs10">
                    <div id="PanelRegisterForm">
                        <div class="form-group">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                                <div class="col-lg-3 col-md-3 col-sm3 col-xs3">
                                    <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Seçilen İyileştirme numarası:</span>
                                    <asp:TextBox ID="txt_iyilestirme_numarasi" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                                    <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Çalışma başlangıç:</span>
                                    <asp:TextBox ID="txt_calisma_baslangic" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                                    <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Çalışma bitiş:</span>
                                    <asp:TextBox ID="txt_calisma_bitis" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                                    <span style="color: #a51b7c; font-weight: bold; font-size: 13px">İyileştirme kategori:</span>
                                    <asp:TextBox ID="txt_iyilestirme_kategori" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Konu:</span>
                            <asp:TextBox ID="txt_konu" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Çalışma grubu:</span>
                            <asp:TextBox ID="txt_calisma_grubu" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Kaynaklar:</span>
                            <asp:TextBox ID="txt_kaynak" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Problem tanımı:</span>
                            <asp:TextBox ID="txt_problem_tanimi" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Hedef:</span>
                            <asp:TextBox ID="txt_hedef" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Yapılan işler:</span>
                            <asp:TextBox ID="txt_yapilan_is" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Style="height: 80px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <span style="color: #a51b7c; font-weight: bold; font-size: 13px">Değerlendirme:</span>
                            <asp:TextBox ID="txt_degerlendirme" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Style="height: 150px"></asp:TextBox>
                        </div>
                    </div>
                 
                </div>


            </div>
            <asp:TextBox ID="txt_iyilestirme_no" runat="server" Style="display: none"></asp:TextBox>
            <asp:Button ID="btn_listele_iyilestirmeno_trigger" runat="server" Text="Liste" Style="display: none" OnClick="btn_listele_iyilestirmeno_trigger_Click" />


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

        var addNumeration = function (cl) {
            var table = document.querySelector('table.' + cl)
            var trs = table.querySelectorAll('tr')
            var counter = 1

            Array.prototype.forEach.call(trs, function (x, i) {
                var firstChild = x.children[0]
                if (firstChild.tagName === 'TD') {
                    var cell = document.createElement('td')
                    cell.textContent = counter++
                    x.insertBefore(cell, firstChild)
                } else {
                    firstChild.setAttribute('colspan', 1)
                }
            })
        }

        addNumeration("dosis_iyilestirme_no")


        $("#tbl_iyilestirme_no tbody tr").click(function () {

            var iyilestirme_no = $(this).find("td").eq(1).text();
            $("#txt_iyilestirme_no").val(iyilestirme_no);
            if (iyilestirme_no != "Kayıt yok") {
                $("#btn_listele_iyilestirmeno_trigger").trigger("click");

            }

        });

        $("#btn_listele").click(function () {

            $("#txt_iyilestirme_no").val('');


        });
    </script>

</body>

</html>
