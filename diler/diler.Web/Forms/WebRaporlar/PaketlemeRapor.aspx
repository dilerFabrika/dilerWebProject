<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaketlemeRapor.aspx.cs" Inherits="diler.Web.Forms.Paketleme.KalibrasyonRpr" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

    

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Paketmele Özet  Ekranı</title>

    <style>
     div.bluediv {
         border: 1px solid #1C6EA4;
         border-collapse: collapse;
     }

     .button {
         background-color: #008CBA; /* Green */
         border: none;
         color: white;
         padding: 15px 32px;
         text-align: center;
         text-decoration: none;
         display: inline-block;
         font-size: 16px;
         margin: 4px 2px;
         cursor: pointer;
     }

     .combostyle {
         background-color: #add8e6; /* Green */
         border: none;
         color: black;
         padding: 15px 20px;
         text-align: center;
         text-decoration: none;
         display: inline-block;
         font-size: 10px;
         margin: 4px 2px;
         cursor: pointer;
     }

     .combostyle2 {
         background-color: #add8e6; /* Green */
         border: none;
         color: black;
         padding: 15px 20px;
         font-size: 10px;
     }



     table {
         font-family: arial, sans-serif;
         border-collapse: collapse;
         width: 100%;
     }

     td, th {
         border: 1px solid black;
         text-align: left;
         padding: 8px;
     }

     tr:nth-child(even) {
         background-color: #dddddd;
     }

     <style type="text/css" class="init" > .auto-style1 {
         width: 464px;
     }

     .auto-style5 {
         font-size: medium;
     }

     .auto-style6 {
         font-size: small;
     }

     .auto-style8 {
         text-align: center;
         color: #0033CC;
     }
 </style>

    <style>
        table.blueTable {
            border: 1px solid #1C6EA4;
            background-color: #EEEEEE;
            width: 100%;
            text-align: left;
            border-collapse: collapse;
        }

            table.blueTable td, table.blueTable th {
                border: 1px solid #AAAAAA;
                padding: 3px 2px;
            }

            table.blueTable tbody td {
                font-size: 13px;
            }

            table.blueTable tr:nth-child(even) {
                background: #D0E4F5;
            }

            table.blueTable thead {
                background: #1C6EA4;
                background: -moz-linear-gradient(top, #5592bb 0%, #327cad 66%, #1C6EA4 100%);
                background: -webkit-linear-gradient(top, #5592bb 0%, #327cad 66%, #1C6EA4 100%);
                background: linear-gradient(to bottom, #5592bb 0%, #327cad 66%, #1C6EA4 100%);
                border-bottom: 2px solid #444444;
            }

                table.blueTable thead th {
                    font-size: 15px;
                    font-weight: bold;
                    color: #FFFFFF;
                    border-left: 2px solid #D0E4F5;
                }

                    table.blueTable thead th:first-child {
                        border-left: none;
                    }

            table.blueTable tfoot {
                font-size: 14px;
                font-weight: bold;
                color: #FFFFFF;
                background: #D0E4F5;
                background: -moz-linear-gradient(top, #dcebf7 0%, #d4e6f6 66%, #D0E4F5 100%);
                background: -webkit-linear-gradient(top, #dcebf7 0%, #d4e6f6 66%, #D0E4F5 100%);
                background: linear-gradient(to bottom, #dcebf7 0%, #d4e6f6 66%, #D0E4F5 100%);
                border-top: 2px solid #444444;
            }

                table.blueTable tfoot td {
                    font-size: 14px;
                }

                table.blueTable tfoot .links {
                    text-align: right;
                }

                    table.blueTable tfoot .links a {
                        display: inline-block;
                        background: #1C6EA4;
                        color: #FFFFFF;
                        padding: 2px 8px;
                        border-radius: 5px;
                    }

        .auto-style10 {
            color: #0000FF;
            text-align: center;
            background-color: #ADD0F4;
        }

        .auto-style11 {
            text-align: center;
            background-color: #ADD0F4;
        }

        .auto-style12 {
            color: #0000FF;
        }

        .auto-style13 {
            background-color: #FFFFFF;
        }

        .auto-style14 {
            color: #0000FF;
            background-color: #ADD0F4;
        }

        .auto-style15 {
            width: 197px;
            color: #0000FF;
            background-color: #ADD0F4;
        }

        .auto-style16 {
            background-color: #FFFFFF;
            text-align: left;
        }
    </style>


    <%--<link href="../../css/DataTables.css" rel="stylesheet" />--%>
    <link rel="stylesheet"  href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"/>
	<link rel="stylesheet"  href="//cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.css"/>

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

    <script src="../../dataTables_Js/DataTables/jQuery-3.3.1/jquery-3.3.1.min.js"></script>
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


   <%-- <script type="text/javascript"  src="https://code.jquery.com/jquery-3.3.1.js"></script>
	<script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

   <script type="text/javascript" src="https://cdn.datatables.net/fixedheader/3.1.5/js/dataTables.fixedHeader.min.js"></script>

    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.colVis.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
	<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.flash.min.js"></script>

	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js"></script>
	<script type="text/javascript"  src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js"></script>

	<script type="text/javascript"  src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
	<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
--%>

	<script type="text/javascript" class="init">
	    $(document).ready
            (
                    function () {

                        $('#tech-companies-1').DataTable
                                             (

                                                        {
                                                            "stateSave": true,
                                                            "searchHighlight": true,
                                                            "autoWidth": true,
                                                            "responsive": true,
                                                            "scrollY": "500px",
                                                            "language": {
                                                                "sDecimal": ",",
                                                                "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
                                                                "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                                                                "sInfoEmpty": "Kayıt yok",
                                                                "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
                                                                "sInfoPostFix": "",
                                                                "sInfoThousands": ".",
                                                                "sLengthMenu": "Sayfada _MENU_ kayıt göster",
                                                                "sLoadingRecords": "Yükleniyor...",
                                                                "sProcessing": "İşleniyor...",
                                                                "sSearch": "Ara:",
                                                                "sZeroRecords": "Eşleşen kayıt bulunamadı",
                                                                "oPaginate": {
                                                                    "sFirst": "İlk",
                                                                    "sLast": "Son",
                                                                    "sNext": "Sonraki",
                                                                    "sPrevious": "Önceki"
                                                                },
                                                                "oAria": {
                                                                    "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                                                                    "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
                                                                },
                                                                "select": {
                                                                    "rows": {
                                                                        "_": "%d kayıt seçildi",
                                                                        "0": "",
                                                                        "1": "1 kayıt seçildi"
                                                                    }
                                                                }

                                                            },
                                                            "pagingType": "full_numbers",
                                                            "paging": false, // bunu acarsan sayfa sayfa gozukur
                                                            "bLengthChange": false,
                                                            "bInfo": false,
                                                            fixedHeader: true,
                                                            dom: 'Bfrtip',
                                                        }
                                                            ,
                                                        {
                                                            // aLengthMenu: [[5, 10, 20, 50, 100, "Hepsi"]],
                                                            buttons: [
                                                                'copy', {
                                                                    'sExtends': 'print',
                                                                    'bShowAll': false,
                                                                    "bProcessing": true,
                                                                    "bServerSide": true,
                                                                }
                                                            , 'csv',
                                                            {
                                                                'sExtends': 'xls',
                                                                'sFileName': 'Datalar.xls',
                                                                'sButtontext': 'Save to Excel'
                                                            }
                                                            ,
                                                            {
                                                                'sExtends': 'pdf',
                                                                'bFooter': false
                                                            }

                                                            , 'print'],
                                                        }

                                             );



                        $('a.toggle-vis').on('click', function (e) {
                            e.preventDefault();

                            // Get the column API object
                            var column = table.column($(this).attr('data-column'));

                            // Toggle the visibility
                            column.visible(!column.visible());
                        });

                    }
        );
	    //bu satırı eklersek butonları yıyor
	    //aLengthMenu: [[5, 10, 20, 50,100, "Hepsi"]],


	    //$(document).ready(function() {
	    //    $('#tech-companies-1').dataTable
	    //        (
	    //        {
	    //            "bInfo": false
	    //            ,"bLengthChange":false
	    //            ,"bFilter":false
	    //            ,"bPaginate":false
	    //            ,"bSort": false
	    //            , "oLanguage": { "sZeroRecords": "", "tech-companies-1": "" }
	    //        }
	    //        );
	    //});
    </script>


</head>
<body>
    <!-- Start content -->
   
        <form class="form-horizontal" role="form" enctype="multipart/form-data" runat="server">

            <!-- Page-Title -->
         
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                                 &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="24px"
                                            ImageUrl="~/Images//AnaSayfa.png" Width="29px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />
                                    <br />
                                 Ana Sayfa</div>
                             <div class="auto-style5">
                                     <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6;">
                                        <tbody style="border: none;">
                                            <tr>
                                                <td class="auto-style8"><strong>PAKETLEME RAPOR EKRANI</strong></td>
                                                <%--<td class="auto-style1"><a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a></td>
                                                <td class="auto-style2">
                                                    <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode = "Date" CssClass="form-control unstyled_date" AutoPostBack="True" Style="border-style: none; border-color: inherit; border-width: 0px; border-radius:0px; font-weight:bold;" OnTextChanged="tx_rapor_tarihi_TextChanged" Width="145px"></asp:TextBox>
                                                </td>
                                                <td class="text-right"><a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a></td>--%>

                                            </tr>
                                        </tbody>
                                    </table>
                            </div> 
                        <div class="text-center">
                             </div>
                      </div>

            


            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-top: 10px;">
                <%--SOL TARAF--%>
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                                  <table class="table" border:1; background-color: #add8e6; height: 80px;">
                                  <tr>
                                     <td colspan="2">BASTAR</td>
                                     <td colspan="2">BITTAR</td>
                                 </tr>
                                       <tr>
                                     <td colspan="2"><asp:TextBox ID="TxtBasTar" runat="server" TextMode = "Date" CssClass="form-control unstyled_date" Style="border-style: none; border-color: inherit; border-width: 0px; border-radius:0px; font-weight:bold; background-color: #ADD0F4;" Width="145px"></asp:TextBox></td>
                                     <td colspan="2"><asp:TextBox ID="TxtBitTar" runat="server" TextMode = "Date" CssClass="form-control unstyled_date" Style="border-style: none; border-color: inherit; border-width: 0px; border-radius:0px; font-weight:bold; background-color: #ADD0F4;" Width="145px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>YOL / VRD</td>
                                     <td> <asp:DropDownList ID="CmbYol"  runat="server" Height="20px" Width="83px">
                                         <asp:ListItem>YOL 1+2</asp:ListItem>
                                         <asp:ListItem>YOL 1</asp:ListItem>
                                         <asp:ListItem>YOL 2</asp:ListItem>
                                         </asp:DropDownList></td>
                                     <td> VRD</td>
                                     <td> <asp:DropDownList ID="CmbVrd"  runat="server" Height="20px" Width="83px">
                                         <asp:ListItem>VRD 1+2+3</asp:ListItem>
                                         <asp:ListItem>VRD 1</asp:ListItem>
                                         <asp:ListItem>VRD 2</asp:ListItem>
                                         <asp:ListItem>VRD 3</asp:ListItem>
                                         </asp:DropDownList></td>
                                 </tr>
                                                                 <tr>
                             
                                     <td>CAP</td>
                             
                                     <td>
                                         <asp:TextBox ID="TxtCap" runat="server"></asp:TextBox>
                                                                     </td>
                                       <td>BOY</td>
                                       <td>
                                           <asp:TextBox ID="TxtBoy" runat="server"></asp:TextBox>
                                                                     </td>
                                 </tr>
                                 <tr>
                             
                                     <td>SİPARİŞ</td>
                             
                                     <td>
                                         <asp:TextBox ID="TxtSip" runat="server"></asp:TextBox>
                                     </td>
                                       <td>LOT</td>
                                       <td>
                                           <asp:TextBox ID="TxtLot" runat="server"></asp:TextBox>
                                     </td>
                                 </tr>
                                       <tr>
                             
                                     <td colspan="2">YER</td>
                                       <td colspan="2"><asp:DropDownList ID="CmbYer"   runat="server" CssClass="auto-style6">
                                           <asp:ListItem>PAKETLEME</asp:ListItem>
                                         <asp:ListItem>İHRACAT</asp:ListItem>
                                           <asp:ListItem>İÇ PİYASA</asp:ListItem>
                                           <asp:ListItem>STANDAT DIŞI</asp:ListItem>
                                           <asp:ListItem>KISA PARÇA</asp:ListItem>
                                         <asp:ListItem>Kalibrasyon</asp:ListItem>
                                           <asp:ListItem>STOK</asp:ListItem>
                                         </asp:DropDownList>
                                      </td>
                                 </tr>
                                 <tr>
                                     <td colspan="4" >
                                         <asp:Button ID="BtnListele" class="button" runat="server" Text="Listele" OnClick="BtnListele_Click" /></td>
                                 </tr>
                             </table>
                               </div>
                              <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                                   <table class="blueTable" border:1; background-color: #add8e6; height: 80px;">
                              <tr>
                                 <td colspan="3" class="auto-style10"><strong>PAKETLEME KANTARI VERILERI</strong></td>
                             </tr>
                                   <tr>
                                 <td class="auto-style15">&nbsp;</td>
                                 <td class="auto-style10"><strong>CUBUK (TON)</strong></td>
                                 <td class="auto-style10"><strong>KISA PARCA (TON)</strong></td>
                             </tr>
                                   <tr>
                                 <td class="auto-style15"><strong>1 YOL URETIM</strong></td>
                                 <td class="auto-style13">
                                     <asp:TextBox ID="T1" runat="server" BorderStyle="None"></asp:TextBox></td>
                                 <td class="auto-style13"><asp:TextBox ID="T4" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                                 <td class="auto-style15"><strong>2 YOL URETIM</strong></td>
                                 <td class="auto-style13"> <asp:TextBox ID="T2" runat="server" BorderStyle="None"></asp:TextBox></td>
                                 <td class="auto-style13"> <asp:TextBox ID="T5" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                             
                                 <td class="auto-style15"><strong>TOPLAM URETIM</strong></td>
                                   <td class="auto-style13"><asp:TextBox ID="T3" runat="server" BorderStyle="None"></asp:TextBox></td>
                                   <td class="auto-style13"><asp:TextBox ID="T6" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                                 <td class="auto-style14" >
                                     <strong>GENEL TOPLAM</strong></td>
                                 <td colspan="2" class="auto-style16" >
                                     <asp:TextBox ID="T7" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                         </table>
                                 <br>
                                  
                               </div>
                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
                                   <table class="blueTable"  border:1; background-color: #add8e6; height: 80px;">
                              <tr>
                                 <td colspan="3" class="auto-style10"><strong>ISLETME PROGRAMI VERILERI (KP ICIN)</strong></td>
                             </tr>
                                   <tr>
                                 <td class="auto-style15">&nbsp;</td>
                                 <td class="auto-style11"><span class="auto-style12"><strong>CUBUK (TON)</strong></td>
                                 <td class="auto-style10"><strong>KISA PARCA (TON)</strong></span></td>
                             </tr>
                                   <tr>
                                 <td class="auto-style15"><strong>1 YOL URETIM</strong></td>
                                 <td class="auto-style13"><asp:TextBox ID="T8" runat="server" BorderStyle="None"></asp:TextBox></td>
                                 <td class="auto-style13"><asp:TextBox ID="T11" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                                 <td class="auto-style15"><strong>2 YOL URETIM</strong></td>
                                 <td class="auto-style13"> <asp:TextBox ID="T9" runat="server" BorderStyle="None"></asp:TextBox></td>
                                 <td class="auto-style13"> <asp:TextBox ID="T12" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                             
                                 <td class="auto-style15"><strong>TOPLAM URETIM</strong></td>
                                   <td class="auto-style13"><asp:TextBox ID="T10" runat="server" BorderStyle="None"></asp:TextBox></td>
                                   <td class="auto-style13"><asp:TextBox ID="T13" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                             <tr>
                                 <td class="auto-style14" >
                                     <strong>GENEL TOPLAM</strong></td>
                                 <td colspan="2" class="auto-style13" >
                                     <asp:TextBox ID="T14" runat="server" BorderStyle="None"></asp:TextBox></td>
                             </tr>
                         </table>
                               </div>

                      </div>
                </div>
                <%--ORTA --%>
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                                         <div class="panel panel-border panel-primary" style="border-color: #eceded">
                                                <div class="panel-body">
                                                    <div class="table-responsive" data-pattern="priority-columns">
                                                        <table id="tech-companies-1" class="table table-bordered table-striped ana_stok_takip">
                                                            <%--<thead>
                                                                <tr>
                                                                    <th class="auto-style5">Tarih</th>
                                                                    <th class="auto-style5">Vrd</th>
                                                                    <th class="auto-style5">Yol</span></th>
                                                                    <th class="auto-style3">KalibreTnm</th>
                                                                    <th class="auto-style3">Tonaj</th>
                                                                    <th class="auto-style5">Saat</th>
                                                                </tr>
                                                            </thead>--%>
                                                            

                                                            <asp:PlaceHolder ID="paketleme_kalibrasyon_html_table" runat="server"></asp:PlaceHolder>
                                                            
                                                          

                                                        </table>
                                                    </div>
                                                </div>
                                         </div>
                                 </div>

                <%--SAG TARAF BOS SUANDA --%>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            </div>

    
             
    </form>
        </body>

</html>

