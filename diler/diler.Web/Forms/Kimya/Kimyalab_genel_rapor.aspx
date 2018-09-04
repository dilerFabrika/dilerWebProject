<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kimyalab_genel_rapor.aspx.cs" Inherits="diler.Web.Forms.Kimya.Kimyalab_genel_rapor" %>

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
        div.table-responsive .table tbody tr td {
            border: 2px solid #e3d3f1;
            font-size: 12px !important;
            padding: 5px;
        }

        div.table-responsive .table thead tr th {
            font-size: 11px !important;
        }

        div .table-responsive .table tbody tr:hover {
            background-color: #e3d3f1 !important;
        }
    </style>
</head>

<body>

    <!-- Start content -->
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


                <div class="col-sm-4" style="background-color: #1e88e5;">
                    <table class="table" style="padding: 0; margin: 0; border: none;">
                        <tbody style="border: none;">
                            <tr>
                                <td>
                                    <div class="col-md-3 col-sm-3">
                                        <a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a>
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date" OnTextChanged="tx_rapor_tarihi_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                                <td>
                                    <div class="col-md-3 col-sm-3">
                                        <a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
            <div class="tablolar panel panel-border panel-primary">
                <div style="margin-bottom: 5px;">
                    <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #1e88e5; margin-top: 10px; font-weight: bold;">GÜNLÜK TAKİP</h3>
                </div>
                <div class="col-sm-12">
                    <div class="panel">
                        <div class="col-md-7" style="margin-right: 0; padding: 0;">
                            <div class="panel-body table-rep-plugin table-rapor">
                                <%--     <p class="tbl_baslik" style="background-color: #1e88e5; color: #FFF;">
                                        Mesaisi Girilecek Personel Listesi--%>
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="test" class="table table-small-font table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>Dökümno</th>
                                                <th>Çelik<br />
                                                    Cinsi</th>
                                                <th>C</th>
                                                <th>Si</th>
                                                <th>S</th>
                                                <th>P</th>
                                                <th>Mn</th>
                                                <th>Ni</th>
                                                <th>Cr</th>
                                                <th>Cu</th>
                                                <th>Mo</th>
                                                <th>Sn</th>
                                                <th>V</th>
                                                <th>N</th>
                                                <th>Ceg</th>
                                                <th>B</th>
                                                <th>Ca</th>
                                                <th>Ti</th>
                                                <th>Al</th>
                                                <th>Pb</th>
                                                <th>Nb</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_kimya_listesi" runat="server"></asp:PlaceHolder>
                                        </tbody>

                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="panel">
                                <div class="col-md-12" style="margin-right: 0; padding: 0;">
                                    <div class="panel-body table-rep-plugin table-rapor">
                                        <div class="table-responsive" data-pattern="priority-columns">
                                            <table id="tbl_kimya_listesi2" class="table table-bordered" style="font-size: 12px;">
                                                <thead>
                                                    <tr>

                                                        <th>Dökümno</th>
                                                        <th>Çelik Cinsi</th>
                                                        <th>Sırano</th>
                                                        <th>Vrd</th>
                                                        <th>T/BS</th>
                                                        <th>Kütük<br />
                                                            Sayısı</th>
                                                        <th>KS2</th>
                                                        <th>Ebat</th>
                                                        <th>Boy</th>
                                                        <th>Radyasyon<br />
                                                            Değeri</th>
                                                        <th>Üretimden<br />
                                                            Sapma</th>
                                                        <th>Standart<br />
                                                            Dışı</th>
                                                        <th>Sipariş No</th>
                                                        <th>Açıklama</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_kimya_listesi2" runat="server"></asp:PlaceHolder>
                                                </tbody>

                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <div class="panel">
                            <div class="col-md-12" style="margin-right: 0; padding: 0;">
                                <div class="panel-body table-rep-plugin table-rapor">
                                    <div class="table-responsive" data-pattern="priority-columns">
                                        <table id="tbl_kimya_tablosu3" class="table table-bordered" style="font-size: 12px;">
                                            <thead>
                                                <tr>
                                                    <th>Çelik Cinsi</th>
                                                    <th>Ebat</th>
                                                    <th>Boy</th>
                                                    <th>Kütük Sayısı</th>
                                                    <th>Toplam Tonaj</th>


                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder ID="ph_kimya_listesi3" runat="server"></asp:PlaceHolder>
                                            </tbody>

                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="panel">
                            <div class="col-md-12" style="margin-right: 0; padding: 0;">
                                <div class="panel-body table-rep-plugin table-rapor">
                                    <div class="table-responsive" data-pattern="priority-columns">
                                        <table id="tbl_kimya_tablosu4" class="table table-bordered" style="font-size: 12px;">
                                            <thead>
                                                <tr>
                                                    <th>Çelik Cinsi</th>
                                                    <th>ORT C</th>
                                                    <th>ORT Si</th>
                                                    <th>ORT Mn</th>
                                                    <th>ORT V</th>
                                                    <th>ORT Nb</th>
                                                    <th>ORT Ca</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder ID="ph_kimya_listesi4" runat="server"></asp:PlaceHolder>
                                            </tbody>

                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="clear"></div>
            </div>
            <!-- end row -->
        </form>
    </div>

    <!-- content -->

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

        addNumeration("table-striped")
    </script>

</body>

</html>

