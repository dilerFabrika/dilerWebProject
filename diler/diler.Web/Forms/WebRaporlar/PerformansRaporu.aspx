<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformansRaporu.aspx.cs" Inherits="diler.Web.PerformansRaporu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Performans Raporları</title>
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

    <link href="../../css/rapor_style.css" rel="stylesheet" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->

    <script src="../../js/modernizr.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
        <style type="text/css">
        div.table-responsive .table tbody tr td {
            font-size: 12px !important;
             padding: 4px;
        }
        div.table-responsive .table thead tr th {
            font-size: 11px !important;
        }
    </style>
</head>
<body>
    <div class="content">

        <form id="form_rapor" method="post" runat="server">

            <!-- Page-Title -->
        
            <div class="row icon-list" style="padding: 5px 0; padding-bottom: 0;">
                <div class="col-md-12 col-sm-12">
                    <div class="col-sm-4">
                        <div class="col-md-3">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="24px"
                                ImageUrl="~/Images//AnaSayfa.png" Width="29px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4" style="background-color:#add8e6;">
                        <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6;">
                            <tbody style="border: none;">
                                <tr>
                                    <td><a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a></td>
                                    <td style="width: 50px">
                                        <asp:DropDownList ID="cmb_vrd" runat="server" AutoPostBack="True" Style="height: 34PX; width: 70px; font-size: 12px; border:0px; font-weight:bold;"
                                            OnSelectedIndexChanged="cmb_vrd_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="all">Tümü</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date" AutoPostBack="True" Style="text-align: center;
                                            border:0px; border-radius:0px; font-weight:bold;" OnTextChanged="tx_rapor_tarihi_TextChanged"></asp:TextBox>


                                    </td>
                                    <td><a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>
                    <div class="col-md-4 col-sm-4">
                        
                    </div>

                </div>
            </div>
            <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">
                <div class="">
                    <h3 class="panel-title" style="text-align: center; font-size: 21px; color:#323232; margin-top: 10px; font-weight: bold;">PERFORMANS RAPORU</h3>
                </div>
            </div>     
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-border panel-primary" style="border-color: #ffffff;">
                    <div class="panel-body">
                     
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-1" class="table table-bordered table-striped table_performans_raporu">
                                <thead>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th>Döküm<br />
                                            Numarası</th>
                                        <th>Vrd</th>
                                        <th>Şarj</th>
                                        <th>Toplam Şarj</th>
                                        <th>Döküm başlangıç<br />
                                            Saati</th>
                                        <th>Dev<br />
                                            Saati</th>
                                        <th>E'li<br />
                                            Süre</th>
                                        <th>E'siz<br />
                                            Süre</th>
                                        <th>Toplam<br />
                                            Süre</th>
                                        <th>Dev.Sıc</th>
                                        <th>PO<br />
                                            Gir.Sıc</th>
                                        <th>AO<br />
                                            Enerji</th>
                                        <th>PO<br />
                                            Enj</th>
                                         <th>PO<br />
                                            Enerjili Süre</th>
                                        <th>PO<br />
                                            Brüt süre</th>
                                        <th>Enj<br />
                                            Kok</th>
                                        <th>Parça<br />
                                            Kireç</th>
                                        <th>Enj<br />
                                            Kireç</th>
                                        <th>Toplam<br />
                                            Kireç</th>
                                        <th>Kütük Tonaj</th>
                                        <th>Tan<br />
                                            B S</th>
                                        <th>Çan<br />
                                            D S</th>
                                        <th>Kap<br />
                                            D S</th>
                                        <th>Yür<br />
                                            D S</th>
                                        <th>RBT D<br />
                                            Sayısı</th>
                                        <th>AO Tırnak<br />
                                            Kapatma<br />
                                            Enerjisi </th>
                                        <th>Brl<br />
                                            DGaz</th>
                                        <th>RCB<br />
                                            Brl<br />
                                            DGaz</th>
                                        <th>PC<br />
                                            DGaz</th>
                                        <th>Toplam<br />
                                            DGaz</th>
                                        <th>ToplamDGaz/<br />
                                            Ktktonaj </th>
                                        <th>Toplamkireç/<br />
                                            Ktktonaj </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_performans_raporu" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </div>
                        <div class="table-responsive" data-pattern="priority-columns">
                            <table id="tech-companies-2" class="table table-bordered table-striped table_performans_raporu">
                                <thead>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th>Bilgisi girilen<br />
                                            Döküm Sayısı</th>
                                        <th>Ort Şrj</th>
                                        <th>Ort  <br />
                                            Toplam Şrj</th>
                                        <th>Ort<br />
                                            E'li Süre</th>
                                        <th>Ort E'siz<br />
                                            Süre</th>
                                        <th>Ort Toplam<br />
                                            Süre</th>
                                        <th>Ort<br />
                                            Dev.Sıc</th>
                                        <th>Ort PO<br />
                                            Gir.Sıc</th>
                                        <th>Ort AO<br />
                                            Enerji</th>
                                        <th>Ort PO<br />
                                            Enj</th>
                                        <th>Ort PO<br />
                                            Enerjili Süre</th>
                                        <th>Ort PO<br />
                                            Brüt süre</th>
                                        <th>Ort Enj<br />
                                            Kok</th>
                                        <th>Ort Enjekte<br />
                                            Kireç</th>
                                        <th>Ort Parça<br />
                                            Kireç</th>
                                        <th>Ort Toplam<br />
                                            Kireç</th>
                                        <th>Ort<br />
                                            Kütük Tonaj</th>
                                        <th>MAX Tan<br />
                                            B S</th>
                                        <th>MAX Çan<br />
                                            D S</th>
                                        <th>MAX Kap<br />
                                            D S</th>
                                        <th>MAX Yür<br />
                                            D S</th>
                                        <th>Ort AO Tırnak<br />
                                            Kapatma<br />
                                            Enerjisi </th>
                                        <th>Ort Brl<br />
                                            DGaz</th>
                                        <th>Ort RCB<br />
                                            Brl<br />
                                            DGaz</th>
                                        <th>Ort PC<br />
                                            DGaz</th>
                                        <th>Ort Toplam<br />
                                            DGaz</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="ph_performans_raporu_Ort" runat="server"></asp:PlaceHolder>
                                </tbody>
                            </table>

                        </div>

                        <div class="col-md-4">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-18" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                     
                                            <th>ÇELİK CİNSİ</th>
                                            <th>EBAT</th>
                                            <th>BOY</th>
                                            <th>KÜTÜKSAYISI</th>
                                            <th>DÖKÜMSAYISI</th>
                                            <th>TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_uretim_ozet" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                                <table id="" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                         
                                            <th>AÇILAN TOPLAM DÖKÜM SAYISI</th>
                                            <th>TOPLAM TONAJ</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_toplam_uretim" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="" class="table table-bordered table-striped table_performans_raporu">
                                    <thead>
                                        <tr>
                                          
                                            <th>TOPLAM HURDA</th>
                                            <th>TOPLAM TONAJ</th>
                                            <th>VERİM</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_verim" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clear"></div>

        </form>
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

        addNumeration("table_performans_raporu")
    </script>

</body>
</html>
