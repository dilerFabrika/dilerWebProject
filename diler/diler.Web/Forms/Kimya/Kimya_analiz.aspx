<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kimya_analiz.aspx.cs" Inherits="diler.Web.Forms.Kimya.Kimya_analiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>KİMYA LAB. YENİ ANALİZ PROGRAMI</title>
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
    <link href="../../css/helper.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <link href="../../css/Kimya_analiz.css" rel="stylesheet" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->


    <style>
        div.table-responsive .table tbody tr td {
            padding: 4px;
            border: 1px solid #f9d3d3;
        }
    </style>

</head>
<body>

    <!-- Start content -->
    <div class="content">

        <form id="form_rapor" method="post" runat="server">
            <!-- Page-Title -->
            <div class="row icon-list" style="padding: 5px 0; padding-bottom: 0;">
                <div class="col-sm-4">
                    <div class="col-md-3 ">
                        <ul class="nav navbar-nav">
                            <li class="dropdown">
                                <a href="javascript:void(0)" data-toggle="dropdown" class="dropdown-toggle">Menu <b class="caret"></b></a>
                                <ul class="dropdown-menu dropdown-menu-left">
                                    <li><a href="Milltest_analiz.aspx">Mill test</a></li>
                                    <li><a href="../../Default2.aspx">Anasayfa</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm-4">
                </div>
                <div class="col-sm-4">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                    </div>
                </div>
            </div>

            <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                <div class="panel-heading" style="margin-bottom: 10px;">
                    <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #414040;">KİMYA LAB. ANALİZ PROGRAMI</h3>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12" style="background-color: #fff;">
                <table class="table-responsive" style="padding: 0; margin: 0; border: none; margin-top: 10px;">
                    <tbody style="border: none;">
                        <tr>
                            <td style="width: 100px"><span style="font-weight: bold">DÖKÜM NO:</span> </td>
                            <td style="width: 220px">
                                <div id="spinner4">
                                    <div class="input-group" style="width: 190px;">
                                        <div class="spinner-buttons input-group-btn">
                                            <button type="button" class="btn spinner-down btn-pink waves-effect waves-light">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                        <asp:TextBox ID="tx_dokum_no" runat="server" CssClass="spinner-input form-control"></asp:TextBox>
                                        <div class="spinner-buttons input-group-btn">
                                            <button type="button" class="btn spinner-up btn-purple waves-effect waves-light">
                                                <i class="fa fa-plus"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>

                            </td>
                            <td style="width: 250px">
                                <asp:Button ID="btn_analiz_liste" runat="server" CssClass="btn btn-primary btn-success" Text="Listele"
                                    Style="width: 85px; font-weight: bold; background-color: #333232; border: 1px solid #414040;" OnClick="btn_analiz_liste_Click" />

                            </td>
                            <td style="width: 80px">

                                <asp:DropDownList ID="cmb_yer" runat="server" Style="height: 34PX; width: 70px; font-size: 15px; font-weight: bold; border: 2px solid #d6d6d6">
                                    <asp:ListItem Selected="True">Yer</asp:ListItem>
                                    <asp:ListItem Value="K1">K1</asp:ListItem>
                                    <asp:ListItem Value="P1">P1</asp:ListItem>
                                    <asp:ListItem Value="P2">P2</asp:ListItem>
                                    <asp:ListItem Value="P3">P3</asp:ListItem>
                                    <asp:ListItem Value="P4">P4</asp:ListItem>
                                    <asp:ListItem Value="P5">P5</asp:ListItem>
                                    <asp:ListItem Value="P6">P6</asp:ListItem>
                                    <asp:ListItem Value="P6">P7</asp:ListItem>
                                    <asp:ListItem Value="P6">P8</asp:ListItem>
                                    <asp:ListItem Value="P6">P9</asp:ListItem>
                                    <asp:ListItem Value="P6">P10</asp:ListItem>
                                    <asp:ListItem Value="S1">S1</asp:ListItem>
                                    <asp:ListItem Value="S2">S2</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px">

                                <asp:DropDownList ID="cmb_element" runat="server" Style="height: 34PX; width: 90px; font-size: 15px; font-weight: bold; border: 2px solid #d6d6d6">
                                    <asp:ListItem Selected="True">Element</asp:ListItem>
                                    <asp:ListItem Value="S">S</asp:ListItem>
                                    <asp:ListItem Value="Pb">Pb</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                            <td style="padding-right: 10px; width: 120px; font-weight: bold; font-size: 17px;">
                                <asp:TextBox ID="txt_deger" runat="server" placeholder="Miktar" CssClass="form-control" onkeypress="return onlyNumbers(event)"
                                    Style="border: 2px solid #d6d6d6; width: 120px"></asp:TextBox>

                            </td>
                            <td style="width: 150px;">
                                <asp:Button ID="btn_degistir" runat="server" CssClass="btn btn-primary btn-success" Text="Değiştir" OnClick="btn_degistir_Click"
                                    Style="width: 85px; font-weight: bold; background-color: #333232; border: 1px solid #414040;" /></td>
                            <td style="width: 80px">
                                <asp:DropDownList ID="cmb_yer2" runat="server" Style="height: 34PX; width: 70px; font-size: 15px; font-weight: bold; border: 2px solid #d6d6d6">
                                    <asp:ListItem Selected="True">Yer</asp:ListItem>
                                    <asp:ListItem Value="K1">K1</asp:ListItem>
                                    <asp:ListItem Value="P1">P1</asp:ListItem>
                                    <asp:ListItem Value="P2">P2</asp:ListItem>
                                    <asp:ListItem Value="P3">P3</asp:ListItem>
                                    <asp:ListItem Value="P4">P4</asp:ListItem>
                                    <asp:ListItem Value="P5">P5</asp:ListItem>
                                    <asp:ListItem Value="P6">P6</asp:ListItem>
                                    <asp:ListItem Value="S1">S1</asp:ListItem>
                                    <asp:ListItem Value="S2">S2</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btn_sil" runat="server" CssClass="btn btn-primary btn-success" Text="Sil" OnClick="btn_sil_Click"
                                    Style="width: 85px; font-weight: bold; background-color: #333232; border: 1px solid #414040;" />

                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="panel panel-border panel-primary">
                        <div class="panel-body">
                            <p class="tbl_baslik" style="background-color: #8763c6; color: #FFF; margin-top: 10px;">DÖKÜM AYRINTI</p>
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-81" class="table table-bordered table-striped table_kimya_lab">
                                    <thead>
                                        <tr>
                                            <th style="font-size: 15px !important;">Döküm Tarihi</th>
                                            <th style="font-size: 15px !important;">Çelik Cinsi</th>
                                            <th style="font-size: 15px !important;">Boy</th>
                                            <th style="font-size: 15px !important;">Ebat</th>

                                            <th style="font-size: 15px !important;">Adet</th>
                                            <th style="font-size: 15px !important;">Açıklama</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_dokum_ayrinti" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff;"></div>
                </div>

                <div class="col-lg-2 col-md-2 col-sm-2">
                    <div class="panel panel-border panel-primary" style="border-color: #ffffff;"></div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped table_kimya_lab">
                                <thead>
                                    <tr>
                                        <th>Yer</th>
                                        <th>Dökümno</th>

                                        <th class="td_sari ">C</th>
                                        <th class="td_sari ">Si</th>
                                        <th class="td_sari ">S</th>
                                        <th class="td_sari ">P</th>
                                        <th class="td_sari ">Mn</th>
                                        <th class="td_sari ">Ni</th>

                                        <th class="td_turuncu ">Cr</th>
                                        <th class="td_turuncu ">Mo</th>
                                        <th class="td_turuncu ">V</th>
                                        <th class="td_turuncu ">Cu</th>
                                        <th class="td_turuncu ">W</th>
                                        <th class="td_turuncu ">Sn</th>

                                        <th class="td_yesil ">Co</th>
                                        <th class="td_yesil ">Al</th>
                                        <th class="td_yesil ">Alsol</th>
                                        <th class="td_yesil ">Alinsol</th>
                                        <th class="td_yesil ">Pb</th>


                                        <th class="td_mavi ">Alsol / Al</th>
                                        <th>Ract</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_kimya_lab_analiz_1" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #00F; color: #FFF;">Yazıcı</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-2" class="table table-bordered table-striped table_kimya_lab">
                                <thead>
                                    <tr>
                                        <th>Yer</th>
                                        <th>Dökümno</th>

                                        <th class="td_yesil ">B</th>

                                        <th class="td_mavi ">Bsol</th>
                                        <th class="td_mavi ">Binsol</th>
                                        <th class="td_mavi ">Sb</th>
                                        <th class="td_mavi ">Nb</th>
                                        <th class="td_mavi ">Ca</th>
                                        <th class="td_mavi ">Casol</th>

                                        <th class="td_sari ">Cainsol</th>
                                        <th class="td_sari ">Zn</th>
                                        <th class="td_sari ">N</th>
                                        <th class="td_sari ">Ti</th>
                                        <th class="td_sari ">Tisol</th>
                                        <th class="td_sari ">Tiinsol</th>

                                        <th class="td_yesil ">As</th>
                                        <th class="td_yesil ">Zr</th>
                                        <th class="td_yesil ">Bi</th>
                                        <th class="td_yesil ">O</th>
                                        <th class="td_yesil ">Fe%</th>
                                        <th class="td_yesil ">CEQ</th>
                                        <th class="td_yesil ">CE</th>
                                        <th class="td_yesil ">Tliq</th>

                                        <th class="td_sari ">Cu+8Sn</th>
                                        <th>Ract</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_kimya_lab_analiz_2" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="panel-body">
                        <p class="tbl_baslik" style="background-color: #ffffff; color: #FF0000;">KALINTI DEĞERLERİ...</p>
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-3" class="table table-bordered table-striped table_kimya_lab">
                                <thead>
                                    <tr>
                                        <th>Yer</th>
                                        <th>Dökümno</th>

                                        <th class="td_yesil ">CrNiCu</th>

                                        <th class="td_mavi ">AlCaO</th>
                                        <th class="td_mavi ">AlMgO</th>
                                        <th class="td_mavi ">AlSiO</th>
                                        <th class="td_mavi ">AlTiO</th>
                                        <th class="td_mavi ">AlCa</th>
                                        <th class="td_mavi ">AlO</th>

                                        <th class="td_sari">CaO</th>
                                        <th class="td_sari ">CaS</th>
                                        <th class="td_sari ">TiO</th>
                                        <th class="td_sari ">TiAl</th>
                                        <th class="td_sari ">MnS</th>
                                        <th class="td_sari ">MgO</th>

                                        <th class="td_yesil ">ZrO</th>
                                        <th class="td_yesil ">SiO</th>

                                        <th class="td_pembe ">CuEQ</th>
                                        <th class="td_pembe ">Mn/S</th>
                                        <th class="td_pembe ">Mn/Si</th>
                                        <th>Ract</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_kimya_lab_analiz_3" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clear"></div>
        </form>
    </div>
    <!-- end row -->

    <!-- content -->

    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="../../js/modernizr.min.js"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../js/waves.js" type="text/javascript"></script>

    <script src="../../js/wow.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../../js/jquery.scrollTo.min.js" type="text/javascript"></script>
    <script src="../../assets1/jquery-detectmobile/detect.js" type="text/javascript"></script>
    <script src="../../assets1/fastclick/fastclick.js" type="text/javascript"></script>
    <script src="../../assets1/jquery-slimscroll/jquery.slimscroll.js" type="text/javascript"></script>
    <script src="../../assets1/jquery-blockui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../assets1/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
    <script src="../../assets1/spinner/spinner.min.js" type="text/javascript"></script>

    <!-- CUSTOM JS -->
    <script src="../../js/jquery.app.js" type="text/javascript"></script>

    <%--    <script src="../../assets/responsive-table/rwd-table.min.js" type="text/javascript"></script>--%>
    <script src="../../js/rapor_js.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {

            setInterval(function () {  $("#btn_analiz_liste").click(); }, 10000);

            //spinner start
            $('#spinner4').spinner({ value: 0000000001, step: 1, min: 0, max: 9999999999 });
            //spinner end



        });

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var txt = e.srcElement;
            var val = txt.value;
            if (val.indexOf('.') != -1 && e.keyCode == 46)
                return false;
            var charCode = e.which || e.keyCode;

            if (charCode == 46 || (charCode >= 48 && charCode <= 57))
                return true;

            return false;
        }

    </script>

</body>
</html>
