<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teorik.aspx.cs" Inherits="diler.Web.Forms.EndMuh.teorik" %>


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
    <link href="../../assets1/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets1/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="//cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.css" />


    <script src="../../js/modernizr.min.js"></script>

    <style>
        div.table-responsive .table tbody tr td {
            font-size: 14px !important;
            text-align: center;
            padding: 4px;
            border: 1px solid #fddcfc;
        }

        div .table-responsive .table thead tr th {
            line-height: 1em;
            font-weight: bold;
            font-size: 12px !important;
            text-align: center;
            padding: 1px;
            margin: 0;
        }

        div .table-responsive .table thead tr {
            background-color: #dee9ff;
        }

        div .table-responsive .table_genel tbody tr:hover {
            background-color: #dee9ff !important;
        }

        .nav-pills li a {
            border-radius: 4px;
            text-decoration: none;
        }

        .nav-pills > li.active > a, .nav-pills > li.active > a:focus, .nav-pills > li.active > a:hover {
            color: #fff;
            background-color: #ad40ab;
            FONT-WEIGHT: BOLD;
        }

        .nav-pills > li {
            FONT-WEIGHT: BOLD;
        }

        .BtnDizaynn {
            width: 100px;
            height: 35px;
            margin-top: 15px;
            font-size: 12px;
            font-weight: bold;
            background: #ad40ab;
            color: White;
            border: 0px;
        }
    </style>

</head>

<body>
    <form runat="server">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                <p style="text-align: center; font-size: 18px; color: #ad40ab; font-weight: bold;">TEORİK TOLERANS </p>
            </div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
            </div>
        </div>

        <div class="col-sm-12" style="margin-top: 2px">

            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <div class="table-responsive" data-pattern="priority-columns" style="background-color: #add8e6;">

                    <table id="table-responsive" class="table table-bordered table-striped table_teorik_tolerans" style="padding: 0; margin: 0; border: none; background-color: #dee9ff; height: 80px;">
                        <tbody style="border: none;">
                            <tr>

                                <td style="width: 200px">Sipariş Numarası:
                                             <asp:TextBox ID="txt_siparisNo" runat="server" CssClass="form-control unstyled_date" class="dokum_no"></asp:TextBox>

                                </td>

                                <td style="width: 200px">
                                    <asp:Button ID="btn_listele" runat="server" Text="Listele" CssClass="btn-danger"
                                        Style="width: 150px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #ad40ab;" OnClick="btn_listele_Click" />


                                </td>

                                <td style="width: 10px">
                                    <asp:ImageButton ID="Home_image" runat="server" Style="height: 23px; margin-top: 15px" OnClick="Home_image_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-sm-4"></div>

        </div>

        <div class="col-lg-12 col-md-12 col-sm-12">

            <div class="panel">
                <div class="panel-body table-rep-plugin table-rapor">
                    <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                        <table id="tech-companies-1" class="table table-bordered table-striped table_teorik">
                            <thead>
                                <tr>
                                    <th>Sipariş No
                                    </th>
                                    <th>Lot</th>
                                    <th>Çap(mm)</th>
                                    <th>Boy(m)</th>
                                    <th>Çubuk Sayısı</th>
                                    <th>Teorik Ağırlık(Kg/m)</th>
                                    <th>L/C(Ton)
                                        <br />
                                        ( + / -10 %)</th>

                                    <th>Renk</th>
                                    <th>Paket Sayısı</th>
                                    <th>Kantar Ağırlığı</th>
                                    <th>Teorik Paket
                                        <br />
                                        Ağırlığı</th>
                                    <th>Teorik Haddeleme
                                        <br />
                                        Toleransı %</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ph_teorik_tolerans" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>

                    </div>
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

        <script src="../../js/jquery-1.11.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../js/notify.js"></script>




        <script src="../../dataTables_Js/DataTables/datatables.min.js"></script>
        <script src="../../dataTables_Js/DataTables/FixedHeader-3.1.4/js/dataTables.fixedHeader.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/dataTables.buttons.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/buttons.colVis.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/buttons.print.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/buttons.flash.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/buttons.html5.min.js"></script>
        <script src="../../dataTables_Js/DataTables/Buttons-1.5.2/js/buttons.print.min.js"></script>


        <script src="../../dataTables_Js/DataTables/CloudFlare/jszip.js"></script>
        <script src="../../dataTables_Js/DataTables/CloudFlare/pdfMake.js"></script>
        <script src="../../dataTables_Js/DataTables/CloudFlare/vfs.js"></script>

        <script type="text/javascript">

            $(document).ready(function () {


                $('#tech-companies-1').DataTable({
                    dom: 'Bfrtip',

                    //"language": {
          
                    //"sSearch": "Ara:",
                    //"sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
                    //"sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                    //"sInfoEmpty": "Kayıt yok",
                    //},
                    lengthMenu: [
                        [-1],
                        ['Hepsi']
                    ],
                    "order": [], //ASC AND DESC FUNCTİON DONT WORKİNG
                    buttons: [

                        {
                            extend: 'excelHtml5',
                            exportOptions: {
                                //columns: ':visible'
                            }
                          
                        }

                    ]
                });

                $('.buttons-html5').css({ "background": "#b5d77c", "width": "80px","height":"29px", "border": "none" });
       
            });

        </script>


    </form>
</body>

</html>
