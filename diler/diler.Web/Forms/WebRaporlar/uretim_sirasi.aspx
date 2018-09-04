<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uretim_sirasi.aspx.cs" Inherits="diler.Web.Forms.WebRaporlar.uretim_sirasi" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
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
            line-height: 1em;
            font-weight: normal;
            font-size: 13px !important;
            text-align: center;
            padding: 12px;
        }

        div.table-responsive .table thead tr th {
            font-size: 15px !important;
        }
    </style>

</head>

<body>
    <form runat="server">

        <div class="row icon-list">
            <div class="col-sm-4">
                <div class="col-md-3">
                </div>
            </div>
            <div class="col-sm-4" style="margin-left: 150px;">
                <div class="col-md-1">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="24px" Style="margin-top: 10px;"
                        ImageUrl="~/Images//AnaSayfa.png" Width="29px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />
                </div>
                <div class="col-md-5">
                    <p style="text-align: center; padding: 5px; font-size: 18px; color: #323232; font-weight: bold;">ÜRETİM SIRASI</p>
                </div>


            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <div class="col-lg-1 col-md-1 col-sm-1 col-xs1"></div>
            <div class="col-lg-10 col-md-10 col-sm-10 col-xs10">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped uretim_sirasi">
                                <thead>
                                    <tr style="height: 25px;">
                                        <th>Üretim tarihi</th>
                                        <th>Ebat & Boy</th>
                                        <th>Kalite</th>
                                        <th>Üretim miktarı</th>
                                        <th>Açıklama<br />
                                        </th>
                                        <th>Sipariş no</th>
                                        <th class="action"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_uretim_sirasi" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-1 col-xs1"></div>

        </div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <asp:TextBox ID="txt_genel_aciklama" runat="server" Style="margin-left: 200px; border: 0px solid; width: 1320px; font-size: 17px;" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        </div>
        <asp:TextBox ID="txt_siparis_no" runat="server" Style="display: none"></asp:TextBox>

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

        $(document).ready(function () {
            $(".sip_ayrinti").click(function () {

                var row = $(this).closest('tr');
                var sip_no = $(row).closest('tr').find("td").eq(5).text();

                var siparis_no = "*" + ""+ sip_no + "";
               // alert(siparis_no);

                //$.ajax({
                //    type: "POST",
                //    url: "uretim_sirasi.aspx/order_detail_pdf_view",
                //    data: "{'sip_no':'" + sip_no + "'}",
                //    contentType: "application/json",
                //    dataType: "json",
                //    success: function (result) {
                //        if (result.d == 1) {

                //        }

                //    },

                //});
                if (siparis_no.trim() != "*") {
                    var adres = ("../../siparis/CH/" + sip_no.trim() + ".pdf").toString();


                    window.open(adres);
                }


            });
        });

    </script>


</body>

</html>
