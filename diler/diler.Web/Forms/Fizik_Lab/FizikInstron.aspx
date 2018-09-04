<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FizikInstron.aspx.cs" Inherits="diler.Web.FizikInstron" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!-- Font Icons -->

    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />

    <!-- Waves-effect -->
    <link href="../../css/waves-effect.css" rel="stylesheet" />
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap.min2.css" rel="stylesheet" />
    <link href="../../css/index.css" rel="stylesheet" />


    <script src="../../js/modernizr.min.js"></script>


    <!-- Base Css Files -->
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />

    <!-- animate css -->
    <link href="../../css/animate.css" rel="stylesheet" />

    <!-- Waves-effect -->
    <link href="../../css/waves-effect.css" rel="stylesheet" />

    <!-- Custom Files -->
    <link href="../../css/helper.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/rapor_style.css" rel="stylesheet" />


    <style>
        div.table-responsive .table tbody tr td {
            font-size: 14px !important;
            text-align: center;
            padding: 5px;
            border: 1px solid #d8f5dd;
        }

        div .table-responsive .table tbody tr:hover {
            background-color: #e7f3e8 !important;
        }

        div.table-responsive .table thead tr {
            background-color: #d8f5dd;
            height: 20px;
        }

            div.table-responsive .table thead tr th {
                font-size: 12px !important;
            }
    </style>

</head>

<body>
    <!-- Input groups -->
    <div class="content">
        <form class="form-horizontal" role="form" enctype="multipart/form-data" runat="server">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="background-color: #5f1a65">
                <p style="text-align: center; padding: 10px; font-size: 18px; color: #eae8ec; font-weight: bold;">ANALİZ İNSTRON VERİLERİ</p>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 5px;">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                    <p>Döküm no :</p>
                    <asp:TextBox ID="tx_dokum_no" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date" OnTextChanged="tx_dokum_no_TextChanged" AutoPostBack="True"></asp:TextBox>
                </div>

                <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                    <p>Tarih1 :</p>
                    <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date" OnTextChanged="tx_rapor_tarihi_TextChanged" AutoPostBack="True"></asp:TextBox>
                </div>

                <div class="col-lg-2 col-md-4 col-sm-4 col-xs4">
                    <p>Tarih2 :</p>
                    <asp:TextBox ID="tx_rapor_tarihi2" runat="server" TextMode="Date" CssClass="form-control unstyled_date" OnTextChanged="tx_rapor_tarihi_TextChanged" AutoPostBack="True"></asp:TextBox>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3">
                    <asp:ImageButton ID="ImageButton2" runat="server" Style="height: 23px; width: 29px; margin-top: 28PX;"
                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" />
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                    <div class="panel-body">
                        <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped txt_parsing">
                                <thead>
                                    <tr>
                                        <th>Tarih</th>
                                        <th>Yol</th>
                                        <th>Döküm No</th>
                                        <th>Testi Yapan</th>
                                        <th>Çap</th>
                                        <th>Nervür
                                            <br />
                                            Merkezi</th>
                                        <th>Enine 
                                            <br />
                                            Nervür Yüksekliği(1/4)</th>
                                        <th>Enine 
                                            <br />
                                            Nervür Yüksekliği(3/4)</th>
                                        <th>CS Mesafesi</th>
                                        <th>Toplam E Mesafesi</th>
                                        <th>Enine 
                                            <br />
                                            Nervür Uzunluğu</th>
                                        <th>Enine
                                            <br />
                                            Nervür Genişliği</th>
                                        <th>Beta Açısı</th>
                                        <th>Alfa Açısı</th>
                                        <th>FR</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_rm_veriler" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </form>
    </div>
    <!-- End content -->

    <!-- jQuery  -->
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../js/waves.js" type="text/javascript"></script>
    <script src="../../js/wow.min.js" type="text/javascript"></script>


</body>
</html>
