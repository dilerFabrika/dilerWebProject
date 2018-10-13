<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milltest_analiz.aspx.cs" Inherits="diler.Web.Forms.Kimya.Milltest_analiz" %>

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

    <script src="../../js/modernizr.min.js"></script>
    <style>
        div.table-responsive .table tbody tr td {
            font-size: 13px !important;
            padding: 6px;
            border: 1px solid #f9d3d3;
        }
    </style>

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
                                        <li><a href="Kimya_analiz.aspx">KimyaLab Analiz</a></li>
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

                <div class="tablolar panel panel-border panel-primary">
                    <div class="panel-heading" style="margin-bottom: 10px;">
                        <h3 class="panel-title" style="text-align: center; font-size: 21px;">KİMYA LAB. MİLL TEST PROGRAMI</h3>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                        <table class="table" style="padding: 0; margin: 0; border: none;">
                            <tbody style="border: none;">
                                <tr>
                                    <td><span style="font-weight: bold; color: #060606;">Dökümno1:</span>
                                        <div id="spinner4">
                                            <div class="input-group" style="width: 160px;">
                                                <div class="spinner-buttons input-group-btn">
                                                    <button type="button" class="btn spinner-down btn-pink waves-effect waves-light">
                                                        <i class="fa fa-minus"></i>
                                                    </button>
                                                </div>
                                                <asp:TextBox ID="tx_bas_dokum_no" runat="server" CssClass="spinner-input form-control"></asp:TextBox>
                                                <div class="spinner-buttons input-group-btn">
                                                    <button type="button" class="btn spinner-up btn-purple waves-effect waves-light">
                                                        <i class="fa fa-plus"></i>
                                                    </button>

                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span style="font-weight: bold; color: #060606;">Dökümno2:</span>
                                        <div id="spinner5">
                                            <div class="input-group" style="width: 160px;">
                                                <div class="spinner-buttons input-group-btn">
                                                    <button type="button" class="btn spinner-down btn-pink waves-effect waves-light">
                                                        <i class="fa fa-minus"></i>
                                                    </button>
                                                </div>
                                                <asp:TextBox ID="tx_bit_dokum_no" runat="server" CssClass="spinner-input form-control"></asp:TextBox>
                                                <div class="spinner-buttons input-group-btn">
                                                    <button type="button" class="btn spinner-up btn-purple waves-effect waves-light">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>

                                    </td>
                                    <td>
                                        <asp:Button ID="btn_mill_test" runat="server" CssClass="btn btn-primary btn-success" Text="MillTest" OnClick="btn_mill_test_Click" Style="margin-top: 15px; width: 100px; height: 35px;" />
                                    </td>
                                    <td></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>


                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel panel-border panel-primary">
                            <div class="panel-body">
                                <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-1" class="table table-bordered table-striped table_kimya_lab">
                                        <thead>
                                            <tr>
                                                <th>Yer</th>
                                                <th>Yıl</th>
                                                <th>Dökümno</th>
                                                <th>Çelik Cinsi</th>

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

                                                <th class="td_yesil ">B</th>

                                                <th class="td_mavi ">Bsol</th>
                                                <th class="td_mavi ">Binsol</th>
                                                <th class="td_mavi ">Sb</th>
                                                <th class="td_mavi ">Nb</th>
                                                <th class="td_mavi ">Ca</th>
                                                <th class="td_mavi ">Casol</th>

                                                <th class="td_sari ">Cainso</th>
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
                                                <th>Tliq</th>
                                                <th class="td_yesil ">RACT</th>
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

                    <div class="clear"></div>
                </div>
                <!-- end row -->
            </form>
        </div>
    </div>

    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
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

    <!-- responsive-table 
    <script src="assets/responsive-table/rwd-table.min.js" type="text/javascript"></script>-->
    <script src="../../js/rapor_js.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //spinner start
            $('#spinner4').spinner({ value: 0000001, step: 1, min: 0, max: 9999999 });
            $('#spinner5').spinner({ value: 0000001, step: 1, min: 0, max: 9999999 });


           // setInterval(function () { $("#btn_mill_test").click(); }, 10000);
        });

    </script>

</body>
</html>
