<%@ Page Language="vb" AutoEventWireup="false" Inherits="CubukSiparis"
    CodeFile="CubukSiparis.aspx.vb" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FarPoint.Web.Spread" Namespace="FarPoint.Web.Spread" TagPrefix="farpoint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<style type="text/css">
    pre
    {
        border: solid 1px #ccc;
        background-color: #ffa;
        padding: 5px;
        color: #a00;
        line-height: 1.5em;
    }
    .buttonstyleCss
    {
        color: White;
        border: 1px solid Red;
        background-color: #0066FF;
    }

    .btn-primary {
    color: #fff;
    background-color: #0495c9;
    border-color: #357ebd; /*set the color you want here*/
}
.btn-primary:hover, .btn-primary:focus, .btn-primary:active, .btn-primary.active, .open>.dropdown-toggle.btn-primary {
    color: #fff;
    background-color: #00b3db;
    border-color: #285e8e; /*set the color you want here*/
}
    /*.fancy-green .ajax__tab_header
    {
        background: url(green_bg_Tab.gif) repeat-x;
        cursor: pointer;
    }
    .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
    {
        background: url(green_left_Tab.gif) no-repeat left top;
    }
    .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
    {
        background: url(green_right_Tab.gif) no-repeat right top;
    }
    .fancy .ajax__tab_header
    {
        font-size: 13px;
        font-weight: bold;
        color: #000;
        font-family: sans-serif;
    }
    .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
    {
        height: 46px;
    }
    .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
    {
        height: 46px;
        margin-left: 16px; /* offset the width of the left image */
    }
    /*.fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
    {
        margin: 16px 16px 0px 0px;
    }
    .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
    {
        color: #fff;
    }
    .fancy .ajax__tab_body
    {
        font-family: Arial;
        font-size: 10pt;
        border-top: 0;
        border: 1px solid #999999;
        padding: 8px;
        background-color: #ffffff;
    }*/*/
    .style2
    {
        width: 28px;
    }
    .style4
    {
        color: #FFFFFF;
        font-weight: bold;
    }
    .style32
    {
        width: 1237px;
    }
    #btnprint
    {
        top: 2px;
        left: 441px;
        position: absolute;
        height: 30px;
        width: 72px;
        right: -83px;
    }
    #btnprint0
    {
        top: 105px;
        left: 885px;
        position: absolute;
        height: 32px;
        width: 63px;
    }
    .fancy-green
    {
        margin-right: 0px;
    }
    #btnprint1
    {
        top: 5px;
        position: absolute;
        height: 29px;
        width: 73px;
        right: 9px;
    }
    .headerRow
    {
        width: 14%;
        height: 20px;
        left: 4px;
        position: relative;
        background-color: #D6DFEF;
        top: 0px;
    }
    .style40
    {
        color: white;
        border: 1px solid Red;
        background-color: #CC0066;
        font-weight: bold;
    }
    #btnprint2
    {
        top: 87px;
        position: absolute;
        height: 31px;
        width: 60px;
        left: 5px;
    }
    #btnprint2
    {
        top: 8px;
        position: absolute;
        height: 29px;
        width: 62px;
        right: 74px;
    }
    #Button8
    {
        width: 45px;
    }
    #Button9
    {
        width: 45px;
    }
    #Button10
    {
        width: 45px;
    }
    .style41
    {
        width: 44px;
        height: 22px;
    }
    .style42
    {
        height: 22px;
    }
    #form1
    {
        height: 7px;
    }
    .button
    {
        z-index: 1;
        left: 961px;
        top: 104px;
        position: absolute;
        height: 34px;
        width: 107px;
        right: 242px;
    }
    .auto-style1 {
        font-size: small;
    }
    .auto-style2 {
        width: 44px;
        height: 22px;
        font-size: small;
        background-color: #FFFFFF;
    }
    .auto-style3 {
        height: 22px;
        font-size: small;
        background-color: #FFFFFF;
    }
    .auto-style5 {
        position: absolute;
        height: 17px;
        top: 16px;
        left: 35px;
        width: 80px;
        right: 979px;
    }
    .auto-style6 {
        position: absolute;
        height: 35px;
        top: 37px;
        left: 109px;
        width: 1213px;
        right: 1px;
    }
    .auto-style7 {
        width: 44px;
        height: 6px;
    }
    .auto-style8 {
        height: 6px;
    }
    .auto-style11 {
        height: 52px;
        width: 142px;
    }
    .auto-style13 {
        height: 47px;
        left: 77px;
        position: absolute;
        width: 466px;
        top: 52px;
    }
    .auto-style14 {
        width: 84px;
    }
    .auto-style15 {
        height: 46px;
        left: 11px;
        position: absolute;
        width: 713px;
        top: 132px;
    }
    .auto-style16 {
        position: absolute;
        height: 34px;
        top: 180px;
        left: 11px;
        width: 345px;
        right: 954px;
    }
    .auto-style19 {
        position: absolute;
        height: 93px;
        top: 534px;
        left: 11px;
        width: 712px;
        right: 587px;
    }
    .auto-style20 {
        position: absolute;
        height: 264px;
        top: 216px;
        width: 345px;
        left: 11px;
    }
    .auto-style21 {
        position: absolute;
        height: 345px;
        top: 181px;
        left: 364px;
        width: 360px;
        right: 586px;
    }
    .auto-style22 {
        position: absolute;
        height: 15px;
        top: 88px;
        left: 11px;
        width: 713px;
    }
    .auto-style23 {
        height: 44px;
        left: 11px;
        position: absolute;
        width: 713px;
        top: 47px;
    }
    .auto-style24 {
        position: absolute;
        height: 30px;
        top: 638px;
        left: 11px;
        width: 1240px;
        right: 43px;
    }
    .auto-style25 {
        width: 73px;
    }
    .auto-style26 {
        width: 108px;
    }
    .auto-style31 {
        font-size: medium;
    }
    .auto-style34 {
        position: absolute;
        height: 40px;
        top: 100px;
        width: 698px;
        left: 136px;
        right: 476px;
    }
    .auto-style35 {
        left: 885px;
        top: 105px;
        position: relative;
        z-index: 2;
        height: 64px;
    }
    .auto-style36 {
        height: 22px;
        text-align: center;
        background-color: #FFFFFF;
    }
    .auto-style37 {
        width: 44px;
        height: 22px;
        background-color: #FFFFFF;
        text-align: center;
        font-size: medium;
    }
    .auto-style38 {
        position: absolute;
        top: 47px;
        left: 13px;
        width: 1057px;
        height: 42px;
    }
    .auto-style41 {
        position: absolute;
        height: 106px;
        top: 380px;
        left: 1037px;
        width: 180px;
        right: 45px;
    }
    .auto-style42 {
        position: absolute;
        height: 58px;
        top: 313px;
        left: 1037px;
        width: 166px;
        right: 73px;
    }
    .auto-style47 {
        font-size: small;
        height: 23px;
        background-color: #D3E4FA;
    }
    .auto-style48 {
        height: 23px;
    }
    .auto-style50 {
        height: 14px;
    }
    .auto-style56 {
        position: absolute;
        height: 285px;
        top: 697px;
        left: 7px;
        width: 1788px;
    }
    .auto-style57 {
        height: 16px;
    }
    .auto-style59 {
        top: 45px;
        width: 297px;
        position: absolute;
        height: 431px;
        left: 731px;
    }
    .auto-style60 {
        font-size: small;
        height: 6px;
    }
    .auto-style64 {
        font-family: Arial;
        font-size: large;
        color: #0000FF;
        width: 64px;
        background-color: #FFFFFF;
    }
    .auto-style65 {
        width: 930px;
        height: 42px;
        background-color: #FFFFFF;
        position: absolute;
        top: 86px;
        left: 13px;
        z-index: 1;
    }
    .auto-style66 {
        text-align: center;
        width: 160px;
        background-color: #FFFFFF;
    }
    .auto-style67 {
        width: 44px;
        height: 22px;
        background-color: #FFFFFF;
    }
    .auto-style68 {
        height: 22px;
        background-color: #FFFFFF;
    }
    .auto-style69 {
        text-align: center;
        background-color: #FFFFFF;
    }
    .auto-style70 {
        text-align: center;
        background-color: #FFFFFF;
        font-size: small;
    }
    .auto-style71 {
        height: 108px;
        left: 14px;
        position: absolute;
        width: 941px;
        top: 144px;
    }
    .auto-style72 {
        color: white;
        border: 1px solid Red;
        background-color: #CC0066;
        font-weight: bold;
        font-size: x-small;
    }
    .auto-style73 {
        height: 22px;
        background-color: #D3E4FA;
    }
    .auto-style74 {
        height: 22px;
        font-size: small;
        background-color: #D3E4FA;
    }
    .auto-style75 {
        background-color: #D3E4FA;
    }
    .auto-style76 {
        font-size: small;
        background-color: #D3E4FA;
    }
    .auto-style77 {
        height: 16px;
        background-color: #D3E4FA;
    }
    .auto-style78 {
        position: absolute;
        height: 65px;
        top: 46px;
        left: 1036px;
        width: 212px;
        right: 62px;
    }
    .auto-style79 {
        display: block;
        width: 100%;
        height: 34px;
        padding: 6px 12px;
        font-size: x-small;
        line-height: 1.42857143;
        color: #555;
        background-color: #fff;
        background-image: none;
        border: 1px solid #ccc;
        border-radius: 4px;
        -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
    }
    .auto-style80 {
        display: block;
        width: 100%;
        height: 34px;
        padding: 6px 12px;
        font-size: small;
        line-height: 1.42857143;
        color: #555;
        background-color: #fff;
        background-image: none;
        border: 1px solid #ccc;
        border-radius: 4px;
        -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
    }
    </style>
    <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    
    
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<script src="/js/notifyit/notifIt.js"></script>

<head runat="server">
    <title></title>

    <script type="text/javascript">

        // <meta http-equiv="refresh" content="10;URL=CubukSiparis.aspx">
        //        function btnMarkaGetir_onclick() {
        //            // get the control values
        //            //var text1 = document.getElementById('drpMarka').value;
        //            //var text2 = document.getElementById('txtRevizyon').value;
        //            var str1 = document.getElementById('drpMarka').value;
        //            var str2 = document.getElementById('drpMamulTip').value;
        //            //var bool1 = Checkbox1.checked;
        //            //  document.getElementById('CheckBox2').checked = bool1;
        //            // create an array with the values
        //            if (str2 == "Çubuk") {
        //                str2 = "C"
        //            }
        //            else {
        //                str2 = "K"
        //            }

        //            var url = "marka.aspx?MARKA_ADI=" + str1 + "&MAMUL_TIP=" + str2

        //            var winArgs = new Array(str1);
        //            var winSettings = 'center:yes;resizable:no;help:no;' + 'status:no;dialogWidth:1200px;dialogHeight:800px';

        //            // return the dialog control values after passing them as a parameter
        //            //winArgs = window.showModalDialog('lot.aspx', winArgs, winSettings);
        //            winArgs = window.showModalDialog("marka.aspx?MARKA_ADI=" + str1 + "&MAMUL_TIP=" + str2, winArgs, winSettings);
        //            // see if the array is null
        //            //if (winArgs == null) {
        //            //window.alert('Bu Şekilde çıkış yapmayın, seçilen sipariş yenilemesi yapılamadı! KAPAT butonunu kullanın');
        //            //}
        //            //else {
        //            // set the values from what's returned
        //            //Text1.value = winArgs[0];
        //            //Text2.value = winArgs[1];
        //            //Checkbox1.checked = winArgs[2];
        //            // document.getElementById('CheckBox2').checked = winArgs[2];
        //            //window.location.reload();
        //            //window.location.href = window.location.href;
        //            //history.go(0);
        //            //}
        //        }
        //        function btnRed_onclick() {
        //            var sipNo = document.getElementById('txtUretimSipNo').value;
        //            var revNo = document.getElementById('txtRevizyon').value;
        //            var prgKod = document.getElementById('hiddenPrgKod').value;
        //            //var url = "RedNedeni.aspx?SNO=" + str1 + "&REVNO=" + str2
        //            var winArgs = new Array(sipNo);
        //            var winSettings = 'center:yes;resizable:no;help:no;' + 'status:no;dialogWidth:1200px;dialogHeight:800px';
        //            winArgs = window.showModalDialog("RedNedeni.aspx?SNO=" + sipNo + "&REVNO=" + revNo + "&PRGKOD=" + prgKod, winArgs, winSettings);
        //            //window.location.reload();
        //            //window.location.href = window.location.href;
        //        }


        //        function btnMarkaGetir_onclick() {

        //        }
        function changeText2Value() {
            //                //var terminBas = $get("dateTerminBas");
            //                var terminBas = document.getElementById('dateTerminBas');
            //                
            //                var terminBit = $get("dateTerminBit");
            //                //var terminBit = document.getElementById('dateTerminBit');
            //                if (terminBas )
            //                {
            //                terminBas.text="545";
            //                //terminBit.value = terminBas.value;
            //                 }
            //                else
            //                {
            //                terminBit.text="545";
            //                }
            //                
        }
        function PrintDiv() {
            var divToPrint = document.getElementById('printArea');
            var popupWin = window.open('', '_blank', 'width=1200,height=1200,location=no,left=200px');
            popupWin.document.open();
            popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
            popupWin.document.close();

        }

        var doc = new jsPDF();
        var specialElementHandlers = {
            'DIV to be rendered out': function(element, renderer) {
                return true;
            }
        };


        $('#printarea').click(function() {
            var html = $(".wrap_all").html();
            doc.fromHTML(html, 200, 200, {
                'width': 500,
                'elementHandlers': specialElementHandlers
            });
            doc.save("Test.pdf");
        });


        function btnprint1_onclick() {

        }

        function btnprint0_onclick() {

        }

function btnprint0_onclick() {

}

    </script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" class="auto-style5">
        <tr>
            <td class="style32">
                                <asp:ImageButton ID="Image_home" runat="server" Style="margin-top: 15px" OnClick="Image_home_Click"
                                    ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" Height="31px" Width="33px" /></td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table border="1" class="auto-style6">
                <tr>
                    <td class="style32">
                        <asp:Button ID="Buton_SIP_GIRIS" runat="server" Text="ONAYA GÖNDER" Width="121px"
                            CssClass="auto-style72" meta:resourcekey="Buton_SIP_GIRISResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_SIL" runat="server" Text="SİPARİŞİ SİL" Width="94px"
                            CssClass="auto-style72" meta:resourcekey="Buton_SIP_SILResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_GIR_ONAY" runat="server" Text="SİPARİŞ GİRİŞ ONAY"
                            Width="148px" CssClass="auto-style72" meta:resourcekey="Buton_SIP_GIR_ONAYResource1"
                            Height="30px" />
                        &nbsp;<asp:Button ID="buton_SIP_KONTROL" runat="server" Text="SİPAPİŞ KONTROL" Width="148px"
                            CssClass="auto-style72" meta:resourcekey="buton_SIP_KONTROLResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_ONAY" runat="server" Text="ONAY" Width="102px" CssClass="auto-style72"
                            meta:resourcekey="Buton_SIP_ONAYResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_IPTAL" runat="server" Text="SİPARİŞ İPTAL" Width="103px"
                            CssClass="auto-style72" meta:resourcekey="Buton_SIP_IPTALResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_IADE" runat="server" Text="SİPARİŞ İADE" Width="101px"
                            CssClass="auto-style72" meta:resourcekey="Buton_SIP_IADEResource1" Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_REVIZYON" runat="server" Text="SİPARİŞ REVİZYON"
                            Width="134px" CssClass="auto-style72" meta:resourcekey="Buton_SIP_REVIZYONResource1"
                            Height="30px" />
                        &nbsp;<asp:Button ID="Buton_SIP_URT_CEVIR" runat="server" Text="Üretime Çevir" Width="97px"
                            CssClass="auto-style72" meta:resourcekey="Buton_SIP_URT_CEVIRResource1" Height="30px" />
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div style="position: absolute; top: 39px; left: 10px; width: 1119px; height: 849px;
                overflow: auto; top: 79px; left: 11px; height: 1300px; width: 1310px;">
                <ajaxToolkit:TabContainer ID="tabAnaliz" runat="server" CssClass="fancy fancy-green"
                    Width="1310px" Height="1070px" ActiveTabIndex="0" Font-Size="Medium" meta:resourcekey="TabContainer1Resource1"
                    Style="font-weight: bold">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" meta:resourcekey="TabPanel1Resource1">
                        <HeaderTemplate>
                            Sipariş Listeleri</HeaderTemplate>
                        <ContentTemplate>
                            <table style="border-style: none; border-color: inherit; border-width: 1px; background-color: #D3DEEF; font-size: x-small;
                                " class="auto-style71">
                                <tr>
                                    <td class="style167">
                                        <farpoint:FpSpread ID="fpSiparisGetir" runat="server" ActiveSheetViewIndex="0" BorderColor="Black"
                                            BorderStyle="Solid" BorderWidth="1px" ClientAutoCalculation="True" CommandBarOnBottom="False"
                                            DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                            EditModeReplace="True" EnableAjaxCall="False" EnableClientScript="False" EnableTheming="True"
                                            Height="125px" HierarchicalView="False" HorizontalScrollBarPolicy="Never" meta:resourceKey="fpSiparisGetirResource1"
                                            scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500"
                                            VerticalScrollBarPolicy="Always" Width="991px" ClientIDMode="AutoID">
                                            <CommandBar ButtonType="LinkButton">
                                                <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                            </CommandBar>
                                            <Pager ForeColor="Red" Mode="Number" Position="TopCommandBar" />
                                            <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" />
                                            <Sheets>
                                                <farpoint:SheetView AllowSort="True" AllowUserFormulas="False" ColumnFooterHeight="40"
                                                    ColumnHeaderAutoTextIndex="0" ColumnHeaderHeight="40" 
                                                    DefaultRowHeight="16" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;15&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sipariş No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rev. No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top. Mik.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ülke&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Durum&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Siparişi Giriş&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sipariş Giriş Onayı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Siparisi Kontrolü&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Üretim Siparis Onayı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;UrtPlanlama Onay&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt; sİPsAHİBİ&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Drm&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;15&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Siparis_Listesi&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;15&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Default&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;Empty&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Empty&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;Empty&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;Empty&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;False&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;False&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;False&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;Empty&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;Empty&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;Empty&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;#7999c2&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;AxisModels&gt;&lt;Row class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;16&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;16&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Row&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;15&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;90&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;56&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;77&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;122&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;60&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;117&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;107&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;SortIndicator&gt;Descending&lt;/SortIndicator&gt;&lt;Size&gt;116&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Size&gt;150&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;21&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;31&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;27&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Size&gt;50&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;SortIndicator&gt;Descending&lt;/SortIndicator&gt;&lt;Size&gt;57&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;137&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;15&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;15&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;15&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;12&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;15&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;Names&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;/Names&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;3&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;8&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;10&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;11&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;12&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;EbatMiktarGetir&lt;/CommandName&gt;&lt;ImageUrl&gt;GETIR&lt;/ImageUrl&gt;&lt;Text&gt;GETIR&lt;/Text&gt;&lt;BackColor&gt;#0080c0&lt;/BackColor&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;Names&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;/Names&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;#3333ff&lt;/ForeColor&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;Enable&gt;False&lt;/Enable&gt;&lt;/Background&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;13&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;ONAY&lt;/CommandName&gt;&lt;Text&gt;ONAY&lt;/Text&gt;&lt;BackColor&gt;Red&lt;/BackColor&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;Names&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;/Names&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;14&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;15&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Siparis_Listesi&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;ColumnFooterHeight&gt;40&lt;/ColumnFooterHeight&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;ColumnHeaderHeight&gt;40&lt;/ColumnHeaderHeight&gt;&lt;RowHeaderWidth&gt;15&lt;/RowHeaderWidth&gt;&lt;ColumnHeaderAutoTextIndex&gt;0&lt;/ColumnHeaderAutoTextIndex&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;OperationMode&gt;ReadOnly&lt;/OperationMode&gt;&lt;PageSize&gt;15&lt;/PageSize&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;AllowUserFormulas&gt;False&lt;/AllowUserFormulas&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;DefaultRowHeight&gt;16&lt;/DefaultRowHeight&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;15&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                    GridLineColor="#D0D7E5" OperationMode="ReadOnly" PageSize="15" RowHeaderVisible="False"
                                                    RowHeaderWidth="15" SelectionBackColor="#EAECF5" 
                                                    SheetName="Siparis_Listesi">
                                                    <ColumnHeader AutoTextIndex="0" Height="40" />
                                                    <ColumnFooter Height="40" />
                                                    <RowHeader Visible="False" Width="15" />
                                                </farpoint:SheetView>
                                            </Sheets>
                                            <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                            </TitleInfo>
                                        </farpoint:FpSpread>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="border-style: inherit; margin-bottom: 0px;
                                " class="auto-style65">
                                <tr>
                                    <td style="border-style: ridge; color: #0000FF; font-family: Arial; " class="auto-style3">
                                        Sipariş No
                                    </td>
                                    <td class="auto-style2" style="border-style: ridge; color: #0000FF; font-family: Arial;
                                        ">
                                        SiparişDurumu
                                    </td>
                                    <td class="auto-style64" rowspan="2" style="border-style: ridge; ">
                                        <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="52px" meta:resourceKey="Button1Resource1" Style="font-size: small; margin-left: 0%; margin-right: 0%" Text="Listele" Width="103px" CssClass="btn btn-info" BackColor="Blue" />
                                    </td>
                                    <td class="auto-style66" style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        " rowspan="2">&nbsp;</td>
                                    <td class="auto-style70" style="border-style: ridge; color: #0000FF; font-family: Arial;">Başlangıç Tar</td>
                                    <td class="auto-style70" style="border-style: ridge; color: #0000FF; font-family: Arial;">Bitiş Tar </td>
                                    <td class="auto-style69" rowspan="2" style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        ">
                                        <asp:Button ID="btnListele" runat="server" CssClass="btn btn-info" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="51px" Text="Tarih Aralığını Listele" Width="177px" BackColor="Blue" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        " class="auto-style68">
                                        <asp:TextBox ID="txtSipNoRapor" runat="server" Font-Size="X-Small" Style="font-size: medium"
                                            Width="94px" meta:resourcekey="txtSipNoRaporResource1" ToolTip="Direk Siparişi çağırmak için"></asp:TextBox>
                                    </td>
                                    <td class="auto-style67" style="border-style: ridge; color: #0000FF; font-family: Arial;
                                        font-size: large; ">
                                        <asp:DropDownList ID="drpSiparisDurum1" runat="server" Height="30px" Style="font-size: large;
                                            font-weight: 700; text-align: center" Width="272px">
                                            <asp:ListItem>Yeni Sipariş</asp:ListItem>
                                            <asp:ListItem>Giriş Onayı Bekleyen</asp:ListItem>
                                            <asp:ListItem>Kontrol Bekleyen</asp:ListItem>
                                            <asp:ListItem>Müdür Onayı Bekleyen</asp:ListItem>
                                            <asp:ListItem>Planlamaya Yönlendirilen Siparişler</asp:ListItem>
                                            <asp:ListItem>Uretilecek Siparisler</asp:ListItem>
                                            <asp:ListItem>Uretimi Tamamlanmıs Siparisler</asp:ListItem>
                                            <asp:ListItem>Iptal Edilen Siparisler</asp:ListItem>
                                            <asp:ListItem>Revize Edilen Siparisler</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style69" style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        ">
                                        <dx:ASPxDateEdit ID="dateRaporBas" runat="server" Width="129px">
                                        </dx:ASPxDateEdit>
                                    </td>
                                    <td class="auto-style69" style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        ">
                                        <dx:ASPxDateEdit ID="dateRaporBit" runat="server" Height="23px" Width="119px">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                            </table>
                            <div class="panel">
                              <div class="panel-body">
                                        <asp:Label ID="UsrTxt" runat="server" Font-Italic="True" Font-Strikeout="False" Font-Underline="True" ForeColor="#3333FF" meta:resourceKey="UsrTxtResource1" Style="font-size: small" Text="User :"></asp:Label>
                              </div>
                            </div>
                            <div id="myDiv" runat="server">
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" meta:resourcekey="TabPanel2Resource1">
                        <HeaderTemplate>
                            Yeni Sipariş</HeaderTemplate>
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <table border="1" style="background-color: #D3E4FA;" class="auto-style59">
                                            <tr>
                                                <td class="auto-style1" colspan="3">
                                                    <asp:Button ID="btnSatirEkle" runat="server" BackColor="#0066FF" BorderColor="SteelBlue" BorderWidth="2px" CssClass="btn-primary:hover" Font-Size="Small" ForeColor="White" Height="36px" meta:resourceKey="btnSatirEkleResource1" TabIndex="38" Text="Satır Ekle" Width="300px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style60" colspan="3">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Eklenen Satırı Saklasın" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Lot No </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtLotNo" runat="server" Font-Size="Small" meta:resourceKey="txtLotNoResource1" Style="font-weight: 700; text-align: center;" TabIndex="15" Width="84px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Mamul Tipi(*)
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="drpMamulTip" runat="server" AutoPostBack="True" Font-Size="Small"
                                                        TabIndex="16" Width="146px" Height="22px" meta:resourcekey="drpMamulTipResource1" CssClass="dropdown">
                                                        <asp:ListItem meta:resourcekey="ListItemResource9">Çubuk</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource10">Kangal</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource11">Kangal Doğrultma</asp:ListItem>
                                                        <asp:ListItem>Kutuk</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Mamul Standart(*)
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="drpStandart" runat="server" AutoPostBack="True" Font-Size="8pt"
                                                        TabIndex="17" Width="146px" Height="24px" meta:resourcekey="drpStandartResource1" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Mamul Kalite(*)
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="drpKalite" runat="server" Font-Size="Small" Height="24px" TabIndex="18"
                                                        Width="146px" meta:resourcekey="drpKaliteResource1" AutoPostBack="True" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" CssClass="style179" Text="Çap" style="font-size: small"></asp:Label>
                                                </td>
                                                <td class="style177" colspan="2">
                                                    <asp:DropDownList ID="drpCap" runat="server" Font-Size="Small" Height="22px" TabIndex="19"
                                                        Width="65px" meta:resourcekey="drpCapResource1" CssClass="dropdown">
                                                        <asp:ListItem meta:resourcekey="ListItemResource12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtEbatTolNeg" runat="server" Width="30px"></asp:TextBox><asp:TextBox
                                                        ID="txtEbatTolPoz" runat="server" Width="29px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style74">
                                                    Nervürlü/Düz (*)
                                                </td>
                                                <td class="auto-style73" colspan="2">
                                                    <asp:DropDownList ID="drpND" runat="server" Font-Size="Small" Height="24px" TabIndex="20"
                                                        Width="146px" meta:resourcekey="drpNDResource1" AutoPostBack="True" CssClass="dropdown">
                                                        <asp:ListItem meta:resourcekey="ListItemResource13"></asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource14">N</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource15">D</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Boy (M)
                                                </td>
                                                <td class="style178" colspan="2">
                                                    <asp:DropDownList ID="drpBoy" runat="server" Font-Size="Small" Height="20px" meta:resourcekey="drpBoyResource1"
                                                        TabIndex="21" Width="146px" CssClass="dropdown">
                                                        <asp:ListItem meta:resourcekey="ListItemResource16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Boy Tol(-/+ mm)
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtBoyTolNeg" runat="server" Font-Size="Small" TabIndex="22" Width="62px"
                                                        meta:resourcekey="txtBoyTolNegResource1" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtBoyTolPoz" runat="server" CssClass="form-control" Font-Size="Small" Height="20px" meta:resourcekey="txtBoyTolPozResource1" TabIndex="23" Width="65px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Miktarı (MT)(*)
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtMiktar" runat="server" Font-Size="Small" TabIndex="24" meta:resourcekey="txtMiktarResource1"
                                                        Width="140px" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <span class="auto-style1">Top. Miktar </span><b>
                                                        <br class="auto-style1" />
                                                    </b><span class="auto-style1">Tol.% (Mn/Mx) </span>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtTopMikTolMin" runat="server" Width="65px" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtTopMikTolMax" runat="server" CssClass="form-control" Height="20px" Width="58px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Çap Mik Tol.%(Mn/Mx)
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtCapMikTolMin" runat="server" Width="65px" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtCapMikTolMax" runat="server" CssClass="form-control" Height="20px" Width="65px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Boyama
                                                </td>
                                                <td class="style171" colspan="2">
                                                    <asp:TextBox ID="txtBoyama" runat="server" Font-Size="Small" TabIndex="25" meta:resourcekey="txtBoyamaResource1"
                                                        Width="140px" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Çubuk Sayısı
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtCubukSayisi" runat="server" Font-Size="Small" TabIndex="27" Width="140px"
                                                        meta:resourcekey="txtCubukSayisiResource1" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Birim Ağırlık(Kg)
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtBirimAgirlik" runat="server" Font-Size="Small" TabIndex="29"
                                                        Width="140px" meta:resourcekey="txtBirimAgirlikResource1" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Paket Ağırlığı(Kg)
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtPaketAgirlik" runat="server" Font-Size="Small" TabIndex="30"
                                                        Width="140px" meta:resourcekey="txtPaketAgirlikResource1" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="auto-style1">Hadde Tol %</span><br class="auto-style1" /> <span class="auto-style1">(min-max) </span>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtHadde_Tol_N" runat="server" Font-Size="Small" meta:resourcekey="txtHadde_Tol_NResource1"
                                                        TabIndex="31" Width="65px" CssClass="form-control" Height="20px"></asp:TextBox>
                                                </td>
                                                <td class="style178">
                                                    <asp:TextBox ID="txtHadde_Tol_P" runat="server" CssClass="form-control" Font-Size="Small" Height="20px" meta:resourcekey="txtHadde_Tol_PResource1" TabIndex="32" Width="65px"></asp:TextBox>
                                                </td>
                                            </tr>
                                              <%--  <td>
                                                    Isıl İşlem Drm
                                                </td>--%>
                                            
                                                
<%--       <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Font-Size="Small"
       TabIndex="16" Width="138px" Height="22px" meta:resourcekey="drpMamulTipResource1">
       <asp:ListItem meta:resourcekey="ListItemResource8" Selected="True">-</asp:ListItem>
       <asp:ListItem meta:resourcekey="ListItemResource9">Çubuk</asp:ListItem>
       <asp:ListItem meta:resourcekey="ListItemResource10">Kangal</asp:ListItem>
       <asp:ListItem meta:resourcekey="ListItemResource11">Kangal Doğrultma</asp:ListItem>
       <asp:ListItem>Kutuk</asp:ListItem>
       </asp:DropDownList>--%>
         <%--                                           
       <asp:DropDownList ID="IsılIslemler" runat="server" AutoPostBack="True"
       <asp:ListItem>-</asp:ListItem>
       <asp:ListItem>+U</asp:ListItem>
       <asp:ListItem>+AC</asp:ListItem>
       </asp:DropDownList>--%>
       
       </td>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                        <table border="1" style="position: absolute; height: 184px; top: 118px; left: 1037px;
                                            background-color: #D3E4FA; width: 213px;" width="100">
                                            <tr>
                                                <td class="auto-style1">
                                                    Ürün Bilgisi
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="drpUrunBilgi" runat="server" Height="24px" TabIndex="36" Width="185px" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Kütük Menşei
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="drpKutukTedarikci" runat="server" Height="24px" TabIndex="37"
                                                        Width="185px" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Kütük Kalite
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="txtKutukKalite" runat="server" Height="24px" TabIndex="38"
                                                        Width="185px" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Firma</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="txtMusteriAdi" runat="server" Font-Size="Small" 
                                                        Height="20px" meta:resourcekey="drpRotorTipResource1" TabIndex="39" 
                                                        Width="186px" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="1" style="background-color: #D3E4FA; " class="auto-style78">
                                            <tr>
                                                <td class="auto-style1">
                                                    Baş.Termin
                                                </td>
                                                <td class="style24">
                                                    <asp:TextBox ID="dateTerminBas" runat="server" false="True" Width="120px" Style="height: 22px"
                                                        TabIndex="33" meta:resourcekey="dateTerminBasResource1" AutoPostBack="True" Height="22px"></asp:TextBox><ajax:CalendarExtender
                                                            ID="CalendarExtender3" runat="server" Enabled="True" Format="dd'/'MM'/'yyyy"
                                                            PopupButtonID="dateTerminBas" TargetControlID="dateTerminBas" OnClientDateSelectionChanged="changeText2Value">
                                                        </ajax:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Bit. Termin
                                                </td>
                                                <td class="style47">
                                                    <asp:TextBox ID="dateTerminBit" runat="server" false="True" Width="120px" Height="22px"
                                                        TabIndex="34" meta:resourcekey="dateTerminBitResource1"></asp:TextBox><ajax:CalendarExtender
                                                            ID="CalendarExtender4" runat="server" Enabled="True" Format="dd'/'MM'/'yyyy"
                                                            PopupButtonID="dateTerminBit" TargetControlID="dateTerminBit">
                                                        </ajax:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="1" style="background-color: #D3E4FA; " class="auto-style42">
                                            <tr>
                                                <td class="auto-style1">
                                                    Rotor Tipi
                                                </td>
                                                <td class="style179">
                                                    <asp:DropDownList ID="drpRotorTip" runat="server" Font-Size="Small" Height="24px"
                                                        meta:resourcekey="drpRotorTipResource1" TabIndex="39" Width="100px" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Boş.Limanı
                                                </td>
                                                <td class="style179">
                                                    <asp:TextBox ID="txtBosLiman" runat="server" CssClass="form-control" 
                                                        Font-Size="Small" Height="20px" meta:resourcekey="txtBosLimanResource1" 
                                                        TabIndex="35" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="1" style="background-color: #D3E4FA; " class="auto-style41" width="100">
                                            <tr>
                                                <td class="auto-style1">
                                                    Köşe Radyusu
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style15">
                                                    <asp:TextBox ID="txtKoseRadyusu" runat="server" Font-Size="Small" meta:resourcekey="txtBosLimanResource1"
                                                        TabIndex="35" Width="200px" CssClass="form-control" style="font-size: small" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Rombiklik
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <span class="style169">
                                                        <asp:TextBox ID="txtRombiklik" runat="server" Font-Size="Small" meta:resourcekey="txtBosLimanResource1"
                                                            TabIndex="35" Width="200px" CssClass="form-control" style="font-size: small" Height="20px"></asp:TextBox></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Doğruluktan Sapma
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style15">
                                                    <asp:TextBox ID="txtDogSapma" runat="server" Font-Size="Small" meta:resourcekey="txtBosLimanResource1"
                                                        TabIndex="35" Width="200px" CssClass="form-control" style="font-size: small" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Burulma
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style13">
                                                    <asp:TextBox ID="txtBurulma" runat="server" Font-Size="Small" meta:resourcekey="txtBosLimanResource1"
                                                        TabIndex="35" Width="200px" CssClass="form-control" style="font-size: small" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    Kesme Şekli
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style13">
                                                    <asp:TextBox ID="txtKesmeSekli" runat="server" Font-Size="Small" meta:resourceKey="txtBosLimanResource1"
                                                        TabIndex="35" Width="200px" CssClass="form-control" style="font-size: small" Height="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <table border="1" frame="border" style="font-size: Small; " class="auto-style20">
                                        <tr>
                                            <td class="auto-style77">
                                                Mamul
                                            </td>
                                            <td class="auto-style57" colspan="2">
                                                <asp:TextBox ID="txtMamul" runat="server" Font-Size="Small" Height="30px" TabIndex="2"
                                                    TextMode="MultiLine" Width="220px" CssClass="style137" meta:resourcekey="txtMamulResource1"
                                                    Font-Names="Tahoma"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style75">
                                                Toplam Miktar
                                            </td>
                                            <td class="style156" colspan="2">
                                                <asp:TextBox ID="txtToplamMik" runat="server" Font-Size="Small" Width="103px" BackColor="Silver"
                                                    ReadOnly="True" CssClass="style137" meta:resourcekey="txtToplamMikResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style76">
                                                <span class="style170">Top. Miktar </span><b>
                                                    <br />
                                                </b><span class="style170">Tol.% (Mn/Mx) </span>
                                            </td>
                                            <td class="text-center">
                                                <asp:TextBox ID="txtTopMikTolNeg" runat="server" Font-Size="Small" TabIndex="3" Width="60px"
                                                    meta:resourcekey="txtTopMikTolNegResource1" CssClass="form-control" Height="20px"></asp:TextBox>
                                            </td>
                                            <td class="text-center">
                                                <asp:TextBox ID="txtTopMikTolPoz" runat="server" CssClass="form-control" Font-Size="Small" Height="20px" meta:resourcekey="txtTopMikTolPozResource1" TabIndex="4" Width="60px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style47">
                                                <span class="style170">Çap Miktar </span><b>
                                                    <br />
                                                </b><span class="style170">Tol %(Mn/Mx) </span>
                                            </td>
                                            <td class="auto-style48">
                                                <asp:TextBox ID="txtCapMikTolNeg" runat="server" Font-Size="Small" TabIndex="5" Width="60px"
                                                    CssClass="form-control" meta:resourcekey="txtCapMikTolNegResource1" Height="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style48">
                                                <asp:TextBox ID="txtCapMikTolPoz" runat="server" CssClass="form-control" Font-Size="Small" Height="20px" meta:resourcekey="txtCapMikTolPozResource1" TabIndex="6" Width="60px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style75">
                                                Faturalama
                                            </td>
                                            <td class="style163" colspan="2">
                                                <asp:RadioButtonList ID="rdFaturalama" runat="server" CellPadding="0" CellSpacing="0"
                                                    Height="16px" RepeatDirection="Horizontal" Style="font-size: Small" TabIndex="7"
                                                    Width="194px" meta:resourcekey="rdFaturalamaResource1">
                                                    <asp:ListItem Value="GERCEK" meta:resourcekey="ListItemResource17" Text="GERCEK"></asp:ListItem>
                                                    <asp:ListItem Value="TEORİK" meta:resourcekey="ListItemResource18" Text="TEORİK"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style75">
                                                Ülke
                                            </td>
                                            <td class="auto-style50" colspan="2">
                                                <asp:DropDownList ID="drpUlke" runat="server" CssClass="style137" Font-Size="Small"
                                                    Height="30px" TabIndex="8" Width="122px" meta:resourcekey="drpUlkeResource1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style75">
                                                Eklenen Dosya
                                            </td>
                                            <td class="style43">
                                                <asp:Label ID="lblEk" runat="server" Font-Size="X-Small" meta:resourcekey="lblEkResource1"></asp:Label>
                                            </td>
                                            <td class="style43">
                                                <asp:Button ID="Button6" runat="server" Text="İncele" Width="80px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style44" bgcolor="#D3E4FA">
                                                Dosya Ekle
                                            </td>
                                            <td class="style41" bgcolor="#D3E4FA" colspan="2">
                                                <div style="width: 243px">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                        <ProgressTemplate>
                                                            Bekleyin..</ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="125px" 
                                                                Font-Size="X-Small" Height="21px" />&#160;<asp:Button
                                                                ID="Button5" runat="server" OnClick="Button5_Click" OnClientClick="ShowProgress();"
                                                                Text="Yükle" Height="28px" Width="60px" /><br />
                                                            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label></ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger runat="server" ControlID="Button5" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table border="1" style="background-color: #D3E4FA;" id="ozettablo" class="auto-style56">
                                <tr>
                                    <td class="style52">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div id="divContent" style="overflow: scroll; width: 1257px; height: 400px; margin-right: 0px;">
                                                    <farpoint:FpSpread ID="fpEbatMiktar" runat="server" ActiveSheetViewIndex="0" BorderColor="#ADB6CE"
                                                        BorderStyle="Solid" BorderWidth="1px" CommandBarOnBottom="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                        EnableTheming="True" Height="320px" ScrollBar3DLightColor="White" scrollContent="true"
                                                        scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500" ShowFocusRectangle="True"
                                                        Width="1225px" meta:resourcekey="fpEbatMiktarResource1" ClientAutoCalculation="True">
                                                        <Tab ScrollIncrement="2" VisibleCount="2" />
                                                        <CommandBar Visible="False">
                                                            <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                        </CommandBar>
                                                        <Pager ForeColor="Red" Mode="Number" Position="Top" />
                                                        <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False" />
                                                        <Sheets>
                                                            <farpoint:SheetView AllowPage="False" AllowSort="True" BackColor="White" ColumnHeaderHeight="35"
                                                                DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;38&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Lot No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Standart&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Kalite&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Cap&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;ND&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy Tol (-)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy Tol  (+)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Miktar (Ton)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çubuk Sayısı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Brm Ağırlık (Kg)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Paket Ağırlık (kg)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;15&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Hadde Tol  Min&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Hadde Tol Max&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rotor Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;18&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ürün Bilgisi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;19&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kütük Menşei&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;20&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kütük Kalite&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;21&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Termin Baş&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;22&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Termin Bit&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;23&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boşaltım Limanı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;24&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boyama&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;25&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Köşe Radyusu&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;26&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rombiklik&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;27&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Doğruluktan  Sapma&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;28&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Burulma&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;29&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kesme Şekli&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;30&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat Tol -&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;31&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat Tol +&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;32&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap. Mik. Tol. Min.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;33&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap. Mik. Tol. Max.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;34&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top.Mik. Tol. Min.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;35&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top.Mik. Tol. Max.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;36&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Müşteri Adı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;37&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;38&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;15&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;18&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;19&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;20&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;21&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;22&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;23&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;24&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;25&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;26&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;27&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;28&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;29&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;30&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;31&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;32&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;33&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;34&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;35&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;20&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;38&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;Protect&gt;False&lt;/Protect&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;38&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;31&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;29&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;31&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;37&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;26&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;43&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;28&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;45&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;38&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;32&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;15&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;16&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;17&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;18&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;64&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;19&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;20&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;21&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;34&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;22&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;23&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;24&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;25&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;26&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;27&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;28&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;29&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;30&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;30&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;31&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;30&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;32&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;33&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;34&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;35&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;36&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;60&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;37&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;32&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;35&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;38&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;11&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;38&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;XX-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;SIL&lt;/CommandName&gt;&lt;ImageUrl&gt;Images/collapse_blue.jpg&lt;/ImageUrl&gt;&lt;Text&gt;SIL&lt;/Text&gt;&lt;Type&gt;ImageButton&lt;/Type&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Incele&lt;/CommandName&gt;&lt;ImageUrl&gt;Images/document_zoom_in1.png&lt;/ImageUrl&gt;&lt;Text&gt;Incele&lt;/Text&gt;&lt;Type&gt;ImageButton&lt;/Type&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;BackColor&gt;#e3fdfd&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;3&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;BackColor&gt;#d7ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;False&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;8&quot;&gt;&lt;BackColor&gt;#d7ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;10&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;11&quot;&gt;&lt;BackColor&gt;#d9ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;12&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;13&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;14&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;15&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;16&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;17&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;18&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;19&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;20&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;21&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;22&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;23&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;24&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;25&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;26&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;27&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;28&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;29&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;30&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;31&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;32&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;33&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;34&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;35&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;37&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.CheckBoxCellType&quot; /&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;2&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;3&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;4&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;CellStyles&gt;&lt;CellStyle Row=&quot;0&quot; Column=&quot;2&quot;&gt;&lt;h&gt;Center&lt;/h&gt;&lt;/CellStyle&gt;&lt;/CellStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;38&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#0080c0&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;ColumnHeaderHeight&gt;35&lt;/ColumnHeaderHeight&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;ScrollingContentVisible&gt;True&lt;/ScrollingContentVisible&gt;&lt;SelectionPolicy&gt;MultiRange&lt;/SelectionPolicy&gt;&lt;PageSize&gt;5&lt;/PageSize&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;GroupMaximumLevel&gt;1&lt;/GroupMaximumLevel&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowCount&gt;5&lt;/RowCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;38&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ActiveRow&gt;0&lt;/ActiveRow&gt;&lt;ActiveColumn&gt;2&lt;/ActiveColumn&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                                GridLineColor="#D0D7E5" GroupMaximumLevel="1" PageSize="5" RowHeaderVisible="False"
                                                                SelectionBackColor="#0080C0" SelectionForeColor="White" SelectionPolicy="MultiRange"
                                                                SheetName="Sheet1">
                                                                <ColumnHeader Height="35" />
                                                                <RowHeader Visible="False" />
                                                            </farpoint:SheetView>
                                                        </Sheets>
                                                        <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                            HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                        </TitleInfo>
                                                    </farpoint:FpSpread></div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; font-size: Small; font-weight: 700; color: #000099;
                                margin-bottom: 0px;" class="auto-style23">
                                <tr style="font-size: Small">
                                    <td class="style45">
                                        <asp:TextBox ID="txtKayitDurumu" runat="server" Font-Size="Small" Height="26px" ReadOnly="True"
                                            TabIndex="3" TextMode="MultiLine" Width="697px" BackColor="#AABE74" 
                                            meta:resourcekey="txtKayitDurumuResource1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; font-size: Small; font-weight: 700; color: #000099;
                                margin-bottom: 0px;" class="auto-style15">
                                <tr style="font-size: Small">
                                    <td>
                                        Sip./Rev.Tar.
                                    </td>
                                    <td class="style21">
                                        <asp:TextBox ID="dateSipTar" runat="server" CssClass="auto-style80" Font-Size="X-Small"
                                            Height="29px" ReadOnly="True" Width="135px" meta:resourcekey="dateSipTarResource1"></asp:TextBox>
                                    </td>
                                    <td>
                                        Sipariş Numarası
                                    </td>
                                    <td class="style56">
                                        <asp:TextBox ID="txtUretimSipNo" runat="server" Enabled="False" Font-Size="Small"
                                            Height="34px" Style="text-align: center; font-weight: 700;" TabIndex="1" Width="135px"
                                            meta:resourcekey="txtUretimSipNoResource1" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td class="style57">
                                        Revizyon Numarası
                                    </td>
                                    <td class="auto-style14">
                                        <asp:TextBox ID="txtRevizyon" runat="server" CssClass="form-control" Enabled="False"
                                            Font-Size="Small" Height="29px" Width="65px" meta:resourcekey="txtRevizyonResource1"
                                            Style="font-size: medium"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; " class="auto-style21">
                                <tr>
                                    <td class="auto-style1" style="background-color: #FFFFFF">
                                        Paketleme</td>
                                </tr>
                                <tr>
                                    <td class="style162" style="background-color: #FFFFFF">
                                        <asp:TextBox ID="txtPaketleme" runat="server" Font-Names="Tahoma" 
                                            Font-Size="Small" Height="85px" meta:resourceKey="txtPaketlemeResource1" 
                                            TabIndex="9" TextMode="MultiLine" Width="350px" Font-Bold="True" CssClass="auto-style1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1" style="background-color: #FFFFFF">
                                        Etiket
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style166" style="background-color: #FFFFFF">
                                        <asp:TextBox ID="txtEtiket" runat="server" Font-Names="Tahoma" 
                                            Font-Size="Small" Height="100px" meta:resourceKey="txtEtiketResource1" 
                                            TabIndex="10" TextMode="MultiLine" Width="350px" CssClass="auto-style1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1" style="background-color: #FFFFFF">
                                        Gözetim</td>
                                </tr>
                                <tr>
                                    <td class="style164" style="background-color: #FFFFFF">
                                        <asp:TextBox ID="txtGozetim" runat="server" Font-Names="Tahoma" 
                                            Font-Size="Small" Height="62px" meta:resourceKey="txtGozetimResource1" 
                                            TabIndex="11" TextMode="MultiLine" Width="350px" CssClass="auto-style1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; " class="auto-style19">
                                <tr>
                                    <td class="auto-style1">
                                        Özel Şartlar
                                    </td>
                                    <td class="style24">
                                        <asp:TextBox ID="txtOzelSart" runat="server" Font-Size="Small" Height="97px" TabIndex="12"
                                            TextMode="MultiLine" Width="649px" meta:resourcekey="txtOzelSartResource1" 
                                            Font-Names="Tahoma" CssClass="auto-style1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; " class="auto-style22">
                                <tr>
                                    <td class="style48">
                                        <asp:Button ID="IhrKaySip_Yeni" runat="server" BackColor="#0066FF" BorderColor="White"
                                            BorderStyle="Outset" BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px"
                                            meta:resourceKey="BtnYeniResource1" Style="font-size: x-small" Text="IhrKaySip_Yeni"
                                            Width="114px" CssClass="btn-primary:hover" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="BtnYeni" runat="server" BackColor="#0066FF" BorderColor="White" BorderStyle="Outset"
                                            BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px" meta:resourceKey="BtnYeniResource1"
                                            Style="font-size: x-small; margin-left: 0px;" Text="Yeni" Width="57px" CssClass="btn-primary:hover" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="TavlıSip" runat="server" BackColor="#CCFFFF" ForeColor="#000066" Height="34px" Text="TavlıSip_Yeni" Width="114px" CssClass="btn-primary:hover" style="font-size: x-small" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="Button7" runat="server" BackColor="#0066FF" BorderColor="White" BorderStyle="Outset" BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px" Text="Siparişi Sil" Width="83px" CssClass="btn-primary:hover" style="font-size: x-small" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="BtnSakla" runat="server" BackColor="#0066FF" BorderColor="White"
                                            BorderStyle="Outset" BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px"
                                            meta:resourceKey="BtnSaklaResource1" Style="font-size: x-small" Text="Sakla" Width="57px"
                                            Enabled="False" CssClass="btn-primary:hover" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="BtnYeni3" runat="server" BackColor="#0066FF" BorderColor="White"
                                            BorderStyle="Outset" BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px"
                                            Style="font-size: x-small" Text="Düzelt" Width="57px" meta:resourcekey="BtnYeni3Resource1" CssClass="btn-primary:hover" Visible="True" />
                                    </td>
                                    <td class="auto-style25">
                                        <asp:Button ID="BtnKopyala" runat="server" BackColor="#0066FF" BorderColor="White"
                                            BorderStyle="Outset" BorderWidth="2px" Font-Size="Small" ForeColor="White" Height="34px"
                                            Style="font-size: x-small" Text="Kopyala" Width="70px" meta:resourcekey="BtnKopyalaResource1" CssClass="btn-primary:hover" />
                                    </td>
                                    <td class="style48">
                                        <asp:Button ID="btnAnalizGir" runat="server" BackColor="#993333" ForeColor="White"
                                          BorderStyle="Outset" BorderWidth="2px" Height="34px" Text="Analiz" Width="50px" CssClass="auto-style79" />
                                    </td>

                                    <td class="style48">
                                        &nbsp;</td>
                                   
                                     <td class="auto-style26">

                                      <input id="btnprint1" onclick="PrintDiv()" onclick="return btnprint1_onclick()" onclick="return btnprint1_onclick()"
                                            onclick="return btnprint1_onclick()" type="button" value="Yazdır" />&nbsp;
                                   </td>
                                </tr>
                            </table>
                            <table border="1" style="background-color: #D3E4FA; " class="auto-style16">
                                <tr>
                                    <td style="font-weight: 700;" 
                                        class="auto-style76">
                                        Yönlenecek Sahibi
                                    </td>
                                    <td style="background-color: #FFFFFF">
                                        <asp:DropDownList ID="Siparis_Sahibi" runat="server" Enabled="False" Font-Size="Medium"
                                            Height="30px" Width="206px" Style="font-size: small; font-weight: 700" meta:resourcekey="Siparis_SahibiResource1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <asp:DropDownList ID="drpMarka" runat="server" CssClass="style169" Font-Size="Small"
                                Height="16px" meta:resourcekey="drpMarkaResource1" TabIndex="25" Visible="False"
                                Width="71px">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtFirma" runat="server" CssClass="style137" Enabled="False" Font-Size="Small"
                                meta:resourcekey="txtFirmaResource1" Style="font-size: medium; font-weight: bold"
                                TabIndex="14" Visible="False" Width="93px"></asp:TextBox>
                            <table border="1" style="background-color: #D3E4FA; " class="auto-style24">
                                    <tr>
                                        <td class="auto-style3">
                                            Kaynak Lot
                                        </td>
                                        <td class="style24">
                                            <asp:TextBox ID="txtKaynakLotNo" runat="server" class="form-control" Font-Size="Small"
                                                meta:resourceKey="txtKaynakLotNoResource1" TabIndex="22" Width="60px" Height="20px"
                                                BackColor="White" style="font-size: small"></asp:TextBox>
                                        </td>
                                        <td class="auto-style1">
                                            Yeni Lot
                                        </td>
                                        <td class="style24">
                                            <asp:TextBox ID="txtYeniLotNo" runat="server" class="form-control"  Font-Size="Small"
                                                meta:resourceKey="txtYeniLotNoResource1" TabIndex="22" Width="60px" 
                                                Height="20px" style="font-size: small"></asp:TextBox>
                                        </td>
                                        <td class="style24">
                                            <asp:Button ID="btnSatirCogalt" runat="server" BackColor="Red" Font-Size="7pt" ForeColor="White" Height="30px"
                                                meta:resourceKey="btnSatirCogaltResource1" TabIndex="38" 
                                                Text="Lotu Çoğalt" Width="80px" class="btn btn-danger" />
                                        </td>
                                        <td class="style51">
                                            <asp:TextBox ID="txtKopyalaBasildimi" runat="server"    Enabled="False"
                                                Font-Size="Small" Height="20px" 
                                                TabIndex="22" Visible="False" Width="35px" style="font-size: small" class="form-control"></asp:TextBox>
                                        </td>
                                        <td class="auto-style1">
                                            Değ. Lot No
                                        </td>
                                        <td class="style24">
                                            <asp:TextBox ID="txtDegisecekLot" runat="server" BackColor="#99CCFF" 
                                                Height="20px" Width="60px" class="form-control" ></asp:TextBox>
                                        </td>
                                        <td class="auto-style1">
                                            &nbsp;Değer
                                        </td>
                                        <td class="style24">
                                            <asp:TextBox ID="txtLotYeniDegeri1" runat="server" BackColor="#99CCFF" 
                                                false="True" Height="20px" meta:resourceKey="dateTerminBitResource1" 
                                                TabIndex="34" Width="60px" class="form-control" ></asp:TextBox>
                                        </td>
                                        <td class="style24">
                                            <asp:TextBox ID="txtLotYeniDegeri2" runat="server" BackColor="#99CCFF" 
                                                false="True" Height="20px" meta:resourceKey="dateTerminBitResource1" 
                                                TabIndex="34" Width="60px" class="form-control" ></asp:TextBox>
                                        </td>
                                        <td class="style24">
                                            <asp:Button ID="btnTopMikDegistir" runat="server" BackColor="Red" 
                                                Height="30px" Text="Top.Mik.Tol.Değiştir" Width="120px" class="btn btn-danger" Font-Size="7pt" />
                                        </td>
                                        <td class="style24">
                                            <asp:Button ID="btnCapMikDegistir" runat="server" Text="Çap.Mik.Tol.Değiştir" 
                                                Width="120px" BackColor="Red"
                                                Height="30px" CssClass="btn btn-danger" Font-Size="7pt" />
                                        </td>
                                        <td class="style24">
                                            <asp:Button ID="btnTarihDegistir" runat="server" Text="Tarihi Değiştir" 
                                                Width="100px" BackColor="Red"
                                                Height="30px" CssClass="btn btn-danger" Font-Size="7pt" />
                                        </td>
                                        <td class="style24">
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style1" Font-Bold="True" Font-Italic="False" Font-Size="9pt" ForeColor="Blue" Height="35px" Width="90px">
                                                <asp:ListItem>Mam Kalite</asp:ListItem>
                                                <asp:ListItem>Ktk Kalite</asp:ListItem>
                                                <asp:ListItem>Ktk Menşei</asp:ListItem>
                                                <asp:ListItem>Ürün Bilgisi</asp:ListItem>
                                                <asp:ListItem>Rotor Tipi</asp:ListItem>
                                                <asp:ListItem>Paket Agırlık</asp:ListItem>
                                                <asp:ListItem>Bas.Termin</asp:ListItem>
                                                <asp:ListItem>Bit.Termin</asp:ListItem>
                                                <asp:ListItem>Miktar(Ton)</asp:ListItem>
                                                <asp:ListItem>Boyama</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style24">
                                            <asp:Button ID="SecilenUpdate" runat="server" BackColor="Blue" CssClass="btn btn-primary" Font-Size="7pt" ForeColor="White" Height="30px" Text="Seçilenleri Güncelle" Width="110px" />
                                        </td>
                                    </tr>
                            </table>

                            &#160;&#160;
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajax:TabPanel ID="TabPanel3" runat="server" HeaderText="Onay" meta:resourcekey="TabPanel3Resource1">
                        <HeaderTemplate>
                            Onay</HeaderTemplate>
                        <ContentTemplate>
                            <div id="printArea">
                                <table style="border-style: inherit" border="1" class="auto-style38">
                                    <tr>
                                        <td style="width: 42px">
                                            <asp:Image ID="Image2" runat="server" Height="35px" ImageUrl="~/Images/AMBLEM.png"
                                                Style="text-align: center" Width="41px" meta:resourcekey="Image2Resource1" />
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblBaslik" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF"
                                                Text="DİLER DEMİR ÇELİK A.Ş. SİPARİŞ BİLDİRİM FORMU " meta:resourcekey="lblBaslikResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="border-style: inherit; background-color: #FFFFFF; margin-bottom: 0px; "
                                    border="1" class="auto-style34">
                                    <tr>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; background-color: #FFFFFF" class="auto-style31">
                                            Sipariş Tarihi :
                                        </td>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                            background-color: #FFFFFF" class="auto-style29">
                                            <asp:TextBox ID="dateSipTarOnay" runat="server" BorderStyle="None" 
                                                Font-Bold="True" Font-Size="Large" ForeColor="Black" Height="25px" 
                                                meta:resourceKey="dateSipTarOnayResource1" ReadOnly="True" Width="112px"></asp:TextBox>
                                        </td>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; background-color: #FFFFFF" class="auto-style31">
                                            Sipariş No :
                                        </td>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                            background-color: #FFFFFF" class="auto-style29">
                                            <asp:TextBox ID="txtUretimSipNoOnay" runat="server" BorderStyle="None" 
                                                Font-Bold="True" Font-Size="Large" ForeColor="Black" Height="24px" 
                                                meta:resourceKey="txtUretimSipNoOnayResource1" ReadOnly="True" 
                                                Style="text-align: center;" TabIndex="1" 
                                                Width="115px"></asp:TextBox>
                                        </td>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; background-color: #FFFFFF" class="auto-style31">
                                            Rev No :
                                        </td>
                                        <td style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                            background-color: #FFFFFF" class="auto-style29">
                                            <asp:TextBox ID="txtRevizyonOnay" runat="server" BorderStyle="None" 
                                                Enabled="False" Font-Bold="True" Font-Size="Large" ForeColor="Black" 
                                                Height="23px" meta:resourceKey="txtRevizyonOnayResource1" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table border="1" style="height: 8px; left: 6px; position: absolute; font-size: Small;
                                    width: 1051px; top: 150px; table-layout: auto;" frame="border">
                                    <tr>
                                        <td class="auto-style37">
                                            <span class="auto-style31">Mamul </span> 
                                                                                        
                                        </td>
                                        <td style="font-size: large" class="auto-style36">
                                            <asp:TextBox ID="txtMamulOnay" runat="server" BorderStyle="None" 
                                                Font-Bold="True" Font-Size="Large" ForeColor="Black" Height="25px" 
                                                meta:resourceKey="dateSipTarOnayResource1" ReadOnly="True" Width="901px" CssClass="auto-style31"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style139" colspan="2">
                                            <farpoint:FpSpread ID="fpEbatMiktarOnay" runat="server" ActiveSheetViewIndex="0"
                                                BorderColor="#ADB6CE" BorderStyle="Solid" BorderWidth="1px" CommandBarOnBottom="False"
                                                DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                EditModeReplace="True" EnableTheming="True" Height="214px" ScrollBar3DLightColor="White"
                                                scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500"
                                                ShowFocusRectangle="True" Width="1066px" EnableClientScript="False" 
                                                meta:resourcekey="fpEbatMiktarOnayResource1" ClientIDMode="AutoID">
                                                <Tab ScrollIncrement="2" VisibleCount="2" />
                                                <CommandBar Visible="False">
                                                    <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                </CommandBar>
                                                <Pager ForeColor="Red" Mode="Number" Position="Top" />
                                                <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" />
                                                <Sheets>
                                                    <farpoint:SheetView AllowPage="False" AllowSort="True" BackColor="White" ColumnHeaderHeight="35"
                                                        DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;35&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Lot No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Standart&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Kalite&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Cap&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;ND&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy(M)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy Tol - (mm)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy Tol +(mm)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Miktar (Ton)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boyama&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çubuk Sayısı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Brm Ağırlık (Kg)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Paket Ağırlığı (Kg)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Hadde Tol  (min)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;15&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Hadde Tol (max)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rotor Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boşaltım Limanı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;18&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ürün Bilgisi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;19&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kütük Menşei&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;20&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kütük Kalite&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;21&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Termin Baş&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;22&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Termin Bit&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;23&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Köşe Radyusu&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;24&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rombik&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;25&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Doğruluktan Sapma&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;26&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Burulma&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;27&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kesme Şekli&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;28&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat Tol -&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;29&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat Tol +&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;30&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap Mik Tol Min&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;31&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap Mik Tol Max&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;32&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top Mik Tol Min&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;33&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap Mik Tol Max&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;34&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Müşteri Adı&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;35&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;15&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;17&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;18&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;19&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;20&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;21&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;22&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;16&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;35&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;Protect&gt;False&lt;/Protect&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;35&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;46&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;89&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;151&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;146&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;39&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;33&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;41&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;44&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;49&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Size&gt;56&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;72&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Size&gt;61&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Size&gt;68&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;61&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;SortIndicator&gt;Descending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;51&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;15&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;55&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;16&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;Size&gt;104&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;17&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;18&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;95&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;19&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;77&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;20&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;103&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;21&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;60&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;22&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;60&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;23&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;24&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;25&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;26&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;27&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;28&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;29&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;30&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;31&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;32&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;33&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;34&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;Size&gt;70&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;35&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;35&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;10&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;#0000cc&lt;/ForeColor&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;35&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;BackColor&gt;#e3fdfd&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Left&lt;/HorizontalAlign&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;3&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Left&lt;/HorizontalAlign&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;BackColor&gt;#d7ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;Locked&gt;False&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;BackColor&gt;#d7ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;8&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;BackColor&gt;#d9ffff&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;10&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;11&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;12&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;13&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;14&quot;&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;15&quot;&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;16&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;17&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;18&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;19&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;20&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;21&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;22&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Large&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;2&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;3&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;4&quot;&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;CellStyles&gt;&lt;CellStyle Row=&quot;0&quot; Column=&quot;2&quot;&gt;&lt;h&gt;Left&lt;/h&gt;&lt;/CellStyle&gt;&lt;/CellStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;35&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/PreviewRowStyle&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#0080c0&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;ColumnHeaderHeight&gt;35&lt;/ColumnHeaderHeight&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;ScrollingContentVisible&gt;True&lt;/ScrollingContentVisible&gt;&lt;OperationMode&gt;ReadOnly&lt;/OperationMode&gt;&lt;PageSize&gt;5&lt;/PageSize&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;GroupMaximumLevel&gt;1&lt;/GroupMaximumLevel&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowCount&gt;5&lt;/RowCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;35&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                        GridLineColor="#D0D7E5" GroupMaximumLevel="1" PageSize="5" RowHeaderVisible="False"
                                                        SelectionBackColor="#0080C0" SelectionForeColor="White" SheetName="Sheet1" 
                                                        OperationMode="ReadOnly">
                                                        <ColumnHeader Height="35" />
                                                        <RowHeader Visible="False" />
                                                    </farpoint:SheetView>
                                                </Sheets>
                                                <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                    HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                </TitleInfo>
                                            </farpoint:FpSpread>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9" colspan="2">
                                            <farpoint:FpSpread ID="raporgrd" runat="server" ActiveSheetViewIndex="0" BorderColor="#ADB6CE"
                                                BorderStyle="Solid" BorderWidth="1px" CommandBarOnBottom="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                EditModeReplace="True" EnableClientScript="False" EnableTheming="True" Height="698px"
                                                ScrollBar3DLightColor="White" scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50"
                                                scrollContentTime="500" ShowFocusRectangle="True" Width="1066px" 
                                                meta:resourcekey="raporgrdResource1" ClientIDMode="AutoID">
                                                <Tab ScrollIncrement="2" VisibleCount="2" />
                                                <CommandBar Visible="False">
                                                    <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                </CommandBar>
                                                <Pager ForeColor="Red" Mode="Number" Position="Top" />
                                                <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" />
                                                <Sheets>
                                                    <farpoint:SheetView AllowPage="False" AllowSort="True" BackColor="White" ColumnHeaderHeight="35"
                                                        ColumnHeaderVisible="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;17&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;2&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Lot No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Mamul Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;17&quot; columns=&quot;2&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Toplam Miktar (Mt)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top. Miktar Tol
% (Min / Max)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap. Miktar Tol
% (Min / Max)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy Tol 
 (- / + MM)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat Tol 
(- / + MM)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;5&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Termin Baş-Bit Tarih&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;5&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;6&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Faturalama
&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;6&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;7&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Paketleme&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;8&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Etiket&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;9&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Gözetim&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;10&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Özel Şartlar&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;11&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ülke
&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;12&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ekli Dosya&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;13&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boşaltma Limanı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;13&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;14&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boyama(Lot/Ebat)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;15&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Müşteri Adi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;15&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;2&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;Protect&gt;False&lt;/Protect&gt;&lt;AxisModels&gt;&lt;Row class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;17&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Size&gt;59&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Size&gt;50&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Size&gt;86&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;15&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Row&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;2&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;176&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;891&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;35&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;SpanModels&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetSpanModel&quot;&gt;&lt;CellRange Row=&quot;16&quot; Column=&quot;0&quot; RowCount=&quot;1&quot; ColumnCount=&quot;2&quot; /&gt;&lt;/DataArea&gt;&lt;/SpanModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;17&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;2&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;17&quot; Columns=&quot;2&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;BackColor&gt;#e3fdfd&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;Multiline&gt;True&lt;/Multiline&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;2&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;3&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;5&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;6&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;7&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;8&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;9&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;10&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;11&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;12&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;RowStyle Index=&quot;13&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;CellStyles&gt;&lt;CellStyle Row=&quot;0&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;0&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;1&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;1&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;2&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;2&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;3&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;3&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;4&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;4&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;5&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;5&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;6&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;6&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;7&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;7&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;8&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;8&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;9&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;9&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;10&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;10&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;11&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;h&gt;Left&lt;/h&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;11&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;m&gt;True&lt;/m&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;12&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;12&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;13&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;13&quot; Column=&quot;1&quot;&gt;&lt;c class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;l&gt;500&lt;/l&gt;&lt;t /&gt;&lt;/c&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;14&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;14&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;15&quot; Column=&quot;0&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;b&gt;True&lt;/b&gt;&lt;/n&gt;&lt;f&gt;Blue&lt;/f&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;15&quot; Column=&quot;1&quot;&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;v&gt;Middle&lt;/v&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;16&quot; Column=&quot;0&quot;&gt;&lt;b&gt;White&lt;/b&gt;&lt;n&gt;&lt;s&gt;Medium&lt;/s&gt;&lt;/n&gt;&lt;f&gt;#0000db&lt;/f&gt;&lt;/CellStyle&gt;&lt;CellStyle Row=&quot;16&quot; Column=&quot;1&quot;&gt;&lt;b&gt;White&lt;/b&gt;&lt;/CellStyle&gt;&lt;/CellStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;2&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#0080c0&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;ColumnHeaderVisible&gt;False&lt;/ColumnHeaderVisible&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;ColumnHeaderHeight&gt;35&lt;/ColumnHeaderHeight&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;ScrollingContentVisible&gt;True&lt;/ScrollingContentVisible&gt;&lt;OperationMode&gt;ReadOnly&lt;/OperationMode&gt;&lt;PageSize&gt;5&lt;/PageSize&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;GroupMaximumLevel&gt;1&lt;/GroupMaximumLevel&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowCount&gt;17&lt;/RowCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;2&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                        GridLineColor="#D0D7E5" GroupMaximumLevel="1" OperationMode="ReadOnly" PageSize="5"
                                                        SelectionBackColor="#0080C0" SelectionForeColor="White" SheetName="Sheet1" 
                                                        RowHeaderVisible="False">
                                                        <ColumnHeader Height="35" Visible="False" />
                                                        <RowHeader Visible="False" />
                                                    </farpoint:SheetView>
                                                </Sheets>
                                                <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                    HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                </TitleInfo>
                                            </farpoint:FpSpread>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9" colspan="2">
                                            <farpoint:FpSpread ID="GrdAnaliz" runat="server" ActiveSheetViewIndex="0" BorderColor="#ADB6CE"
                                                BorderStyle="Solid" BorderWidth="0px" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                EnableTheming="True" Height="781px" ScrollBar3DLightColor="White" scrollContent="true"
                                                scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500" Width="199px"
                                                ClientAutoCalculation="True" EnableAjaxCall="False" ClientIDMode="AutoID">
                                                <CommandBar Visible="False">
                                                    <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                </CommandBar>
                                                <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" />
                                                <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" />
                                                <Sheets>
                                                    <farpoint:SheetView BackColor="White" ColumnHeaderHeight="12" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;0&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Element&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;0&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;62&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;80&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;12&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;12&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;10&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;0&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;0&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot; /&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;BackColor&gt;#cc3300&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;ColumnHeaderHeight&gt;12&lt;/ColumnHeaderHeight&gt;&lt;RowHeaderWidth&gt;80&lt;/RowHeaderWidth&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;PageSize&gt;1000&lt;/PageSize&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowCount&gt;0&lt;/RowCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;1&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                        GridLineColor="#D0D7E5" PageSize="1000" RowHeaderVisible="False" SelectionBackColor="#EAECF5"
                                                        SheetName="Sheet1" RowHeaderWidth="80">
                                                        <ColumnHeader Height="12" />
                                                        <RowHeader Visible="False" Width="80" />
                                                    </farpoint:SheetView>
                                                </Sheets>
                                                <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                    HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                </TitleInfo>
                                            </farpoint:FpSpread>
                                        </td>
                                    </tr>
                                </table>
                                <input id="btnprint0" onclick="PrintDiv()" type="button" value="Yazdır" onclick="return btnprint0_onclick()" onclick="return btnprint0_onclick()" class="auto-style35" />
                               <asp:Button ID="btnNewEntry" runat="server" CssClass="auto-style32" Text="Dokuman İncele"
 
OnClick="btnNewEntry_Click" OnClientClick="target='_blank'" style="z-index: 1; position: absolute; top: 105px; left: 954px; height: 32px"/>
                            </div>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" meta:resourcekey="TabPanel4Resource1">
                        <HeaderTemplate>
                            Sipariş Red</HeaderTemplate>
                        <ContentTemplate>
                            <table border="1" class="style5" style="position: absolute; top: 60px; left: 4px;
                                height: 310px;">
                                <tr>
                                    <td style="text-align: center; font-weight: 700; color: #3366FF" class="style7">
                                        RED NEDENINI YAZINIZ
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; font-weight: 700; color: #3366FF">
                                        <asp:TextBox ID="REDNDN" runat="server" Height="233px" meta:resourceKey="REDNDNResource1"
                                            TextMode="MultiLine" Width="681px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style19">
                                        <asp:Button ID="btnRedSakla" runat="server" BackColor="#0066FF" BorderColor="SteelBlue"
                                            BorderWidth="2px" ForeColor="White" Height="34px" meta:resourceKey="btnRedSaklaResource1"
                                            Text="TAMAM" Width="680px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajax:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                        <HeaderTemplate>
                            Analiz</HeaderTemplate>
                        <ContentTemplate>
                            <table style="height: 75px; position: absolute; top: 53px; left: 618px; width: 324px;
                                font-size: x-small;" border="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Kırmızı Arkaplan değişim olduğunu ifade eder."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Kırmızı Arkaplan var ve içerisi boş ise bir önceki revizyonda değer varken şuan ki revizyonda silinmiş olduğunu ifade eder."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHataAyrinti" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="Analiz" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <table style="height: 87px">
                                            <tr>
                                                <td>
                                                    <table border="1" style="height: 619px; left: 297px; background-color: #D3E4FA; position: absolute;
                                                        font-size: Small; width: 168px; top: 115px; font-weight: 700; color: #000099;
                                                        margin-bottom: 0px;">
                                                        <tr style="font-size: Small">
                                                            <td class="auto-style7">
                                                                <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="67px" Style="font-weight: 700;
                                                                    font-size: medium; color: #FFFFFF; background-color: #FF3300">
                                                                    <asp:ListItem>C</asp:ListItem>
                                                                    <asp:ListItem>SI</asp:ListItem>
                                                                    <asp:ListItem>S</asp:ListItem>
                                                                    <asp:ListItem>P</asp:ListItem>
                                                                    <asp:ListItem>MN</asp:ListItem>
                                                                    <asp:ListItem>NI</asp:ListItem>
                                                                    <asp:ListItem>CR</asp:ListItem>
                                                                    <asp:ListItem>MO</asp:ListItem>
                                                                    <asp:ListItem>V</asp:ListItem>
                                                                    <asp:ListItem>CU</asp:ListItem>
                                                                    <asp:ListItem>W</asp:ListItem>
                                                                    <asp:ListItem>TI</asp:ListItem>
                                                                    <asp:ListItem>SN</asp:ListItem>
                                                                    <asp:ListItem>CO</asp:ListItem>
                                                                    <asp:ListItem>AL</asp:ListItem>
                                                                    <asp:ListItem>ALSOL</asp:ListItem>
                                                                    <asp:ListItem>ALOXY</asp:ListItem>
                                                                    <asp:ListItem>PB</asp:ListItem>
                                                                    <asp:ListItem>B ppm</asp:ListItem>
                                                                    <asp:ListItem>SB</asp:ListItem>
                                                                    <asp:ListItem>NB</asp:ListItem>
                                                                    <asp:ListItem>CA</asp:ListItem>
                                                                    <asp:ListItem>ZN</asp:ListItem>
                                                                    <asp:ListItem>N ppm</asp:ListItem>
                                                                    <asp:ListItem>FE</asp:ListItem>
                                                                    <asp:ListItem>F</asp:ListItem>
                                                                    <asp:ListItem>CEQ</asp:ListItem>
                                                                    <asp:ListItem>S+P</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="auto-style8">
                                                                <asp:TextBox ID="txtLotAnaliz0" runat="server" BackColor="#66FFCC" CssClass="style141"
                                                                    Font-Size="Small" Height="16px" meta:resourceKey="txtUretimSipNoResource1" Style="background-color: #FF3300;
                                                                    text-align: center; font-weight: bold; color: #FFFFFF; font-size: medium;" TabIndex="1"
                                                                    Width="50px"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style8">
                                                                <asp:TextBox ID="txtLotAnaliz1" runat="server" BackColor="#66FFCC" CssClass="style141"
                                                                    Font-Size="Small" Height="26px" meta:resourceKey="txtUretimSipNoResource1" Style="background-color: #FF3300;
                                                                    text-align: center; font-weight: bold; color: #FFFFFF; font-size: medium;" TabIndex="1"
                                                                    Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-size: Small">
                                                            <td class="style41" colspan="3">
                                                                <asp:Button ID="Button4" runat="server" BackColor="#0066FF" ForeColor="White" Height="38px"
                                                                    Style="font-family: Arial, Helvetica, sans-serif; font-weight: 700" Text="EKLE"
                                                                    Width="222px" />
                                                            </td>
                                                        </tr>
                                                        <tr style="font-size: Small">
                                                            <td class="style41">
                                                                Seçilen Lot
                                                            </td>
                                                            <td class="style43">
                                                                <asp:TextBox ID="txtLotAnaliz" runat="server" BackColor="#66FFCC" CssClass="style141"
                                                                    Font-Size="Small" Height="19px" meta:resourceKey="txtUretimSipNoResource1" Style="background-color: #FFFFFF;
                                                                    text-align: center; font-weight: 700; color: #FF0000;" TabIndex="1" Width="50px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                                <asp:Button ID="Button2" runat="server" BackColor="#0066FF" ForeColor="White" Text="Temizle"
                                                                    Width="56px" />
                                                            </td>
                                                        </tr>
                                                        <tr style="font-size: Small">
                                                            <td class="style41" colspan="3">
                                                                <farpoint:FpSpread ID="fpLotKimyasal" runat="server" ActiveSheetViewIndex="0" BorderColor="#ADB6CE"
                                                                    BorderStyle="Solid" BorderWidth="1px" ClientAutoCalculation="True" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                                    EnableAjaxCall="False" EnableTheming="True" Height="545px" ScrollBar3DLightColor="White"
                                                                    scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500"
                                                                    Width="229px">
                                                                    <CommandBar Visible="False">
                                                                        <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                                    </CommandBar>
                                                                    <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                        Font-Underline="False" />
                                                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                        Font-Underline="False" />
                                                                    <Sheets>
                                                                        <farpoint:SheetView BackColor="White" ColumnHeaderHeight="12" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;28&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;3&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Element&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Min %&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Max %&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;28&quot; columns=&quot;3&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.0001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;C&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;1&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;SI&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;2&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;S&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;3&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;P&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;4&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;MN&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;5&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;NI&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;6&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;CR&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;7&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;MO&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;8&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;V&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;9&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;CU&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;10&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;W&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;11&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;TI&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;12&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;SN&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;13&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;CO&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;14&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;AL&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;15&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;ALSOL&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;16&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;ALOXY&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;17&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;PB&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;18&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;B ppm&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;19&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;SB&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;20&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;NB&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;21&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;CA&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;22&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;ZN&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;23&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;N ppm&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;24&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;FE&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;25&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;F&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;26&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;CEQ&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;27&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;S+P&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;3&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;AxisModels&gt;&lt;Row class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;28&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;15&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;16&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;17&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;18&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;19&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;20&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;21&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;22&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;23&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;24&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;25&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;26&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;27&quot;&gt;&lt;Size&gt;17&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Row&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;3&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;62&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;84&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;84&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;80&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;80&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;12&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;12&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;30&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;28&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;3&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;RowStyles&gt;&lt;RowStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/RowStyle&gt;&lt;/RowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;28&quot; Columns=&quot;3&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot; /&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;BackColor&gt;#cc3300&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;False&lt;/Locked&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;3&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;RowHeaderWidth&gt;80&lt;/RowHeaderWidth&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;ColumnHeaderHeight&gt;12&lt;/ColumnHeaderHeight&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;PageSize&gt;1000&lt;/PageSize&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;3&lt;/ColumnCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowCount&gt;28&lt;/RowCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ActiveRow&gt;0&lt;/ActiveRow&gt;&lt;ActiveColumn&gt;1&lt;/ActiveColumn&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                                            GridLineColor="#D0D7E5" PageSize="1000" RowHeaderVisible="False" RowHeaderWidth="80"
                                                                            SelectionBackColor="#EAECF5" SheetName="Sheet1" MaximumChange="0.0001">
                                                                            <ColumnHeader Height="12" />
                                                                            <RowHeader Visible="False" Width="80" />
                                                                        </farpoint:SheetView>
                                                                    </Sheets>
                                                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                        Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                                        HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                                    </TitleInfo>
                                                                </farpoint:FpSpread>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="1" style="background-color: #D3E4FA; font-size: Small; font-weight: 700; color: #000099;
                                                        margin-bottom: 0px;" class="auto-style13">
                                                        <tr style="font-size: Small">
                                                            <td class="style44">
                                                                <asp:ImageButton ID="ImageButton1" runat="server" BorderColor="#3399FF" ImageUrl="~/Images/AnaSayfa.png" />
                                                            </td>
                                                            <td>
                                                                Sip.&nbsp;No
                                                            </td>
                                                            <td class="style46">
                                                                <asp:TextBox ID="txtUretimSipNoAnaliz" runat="server" BackColor="#66FFCC" CssClass="style141"
                                                                    Enabled="False" Font-Size="Small" Height="34px" meta:resourceKey="txtUretimSipNoResource1"
                                                                    Style="background-color: #FFFFFF; text-align: center; font-weight: 700; color: #FF0000;"
                                                                    TabIndex="1" Width="93px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                Rev. No
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRevizyonAnaliz" runat="server" CssClass="style133" Enabled="False"
                                                                    Font-Size="Small" Height="29px" meta:resourceKey="txtRevizyonResource1" Width="63px"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style11">
                                                                <asp:Button ID="btnAnalizKaydet" runat="server" Text="Analizleri Kaydet" BackColor="#3333FF"
                                                                    Font-Bold="True" ForeColor="White" Height="46px" Style="font-size: medium" Width="141px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="1" style="margin-bottom: 0px; margin-left: auto; top: 114px; left: 76px;
                                                        height: 47px; width: 204px; position: absolute; background-color: #D3E4FA; font-weight: 700;
                                                        font-size: Small; color: #000099;">
                                                        <tr style="font-size: Small">
                                                            <td class="style53">
                                                                <farpoint:FpSpread ID="fpLotListe" runat="server" ActiveSheetViewIndex="0" BorderColor="#ADB6CE"
                                                                    BorderStyle="Solid" BorderWidth="1px" CommandBarOnBottom="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                                                    EnableTheming="True" Height="421px" meta:resourcekey="fpEbatMiktarResource1"
                                                                    ScrollBar3DLightColor="White" scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50"
                                                                    scrollContentTime="500" ShowFocusRectangle="True" Width="193px">
                                                                    <Tab ScrollIncrement="2" VisibleCount="2" />
                                                                    <CommandBar Visible="False">
                                                                        <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                                                    </CommandBar>
                                                                    <Pager ForeColor="Red" Mode="Number" Position="Top" />
                                                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                        Font-Underline="False" />
                                                                    <Sheets>
                                                                        <farpoint:SheetView AllowPage="False" AllowSort="True" BackColor="White" ColumnHeaderHeight="35"
                                                                            DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Lot No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Drm&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Klt&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;5&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;Protect&gt;False&lt;/Protect&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;29&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;31&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;42&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;35&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;5&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;X-Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Incele&lt;/CommandName&gt;&lt;ImageUrl&gt;Images/document_zoom_in1.png&lt;/ImageUrl&gt;&lt;Text&gt;Incele&lt;/Text&gt;&lt;Type&gt;ImageButton&lt;/Type&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;BackColor&gt;#e3fdfd&lt;/BackColor&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Small&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Locked&gt;True&lt;/Locked&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;CellStyles&gt;&lt;CellStyle Row=&quot;0&quot; Column=&quot;1&quot;&gt;&lt;h&gt;Center&lt;/h&gt;&lt;/CellStyle&gt;&lt;/CellStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;SelectionBackColor&gt;#0080c0&lt;/SelectionBackColor&gt;&lt;ColumnHeaderHeight&gt;35&lt;/ColumnHeaderHeight&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;ScrollingContentVisible&gt;True&lt;/ScrollingContentVisible&gt;&lt;SelectionPolicy&gt;MultiRange&lt;/SelectionPolicy&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;PageSize&gt;5&lt;/PageSize&gt;&lt;GroupMaximumLevel&gt;1&lt;/GroupMaximumLevel&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowCount&gt;5&lt;/RowCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ActiveRow&gt;0&lt;/ActiveRow&gt;&lt;ActiveColumn&gt;3&lt;/ActiveColumn&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                                            GridLineColor="#D0D7E5" GroupMaximumLevel="1" PageSize="5" RowHeaderVisible="False"
                                                                            SelectionBackColor="#0080C0" SelectionForeColor="White" SelectionPolicy="MultiRange"
                                                                            SheetName="Sheet1">
                                                                            <ColumnHeader Height="35" />
                                                                            <RowHeader Visible="False" />
                                                                        </farpoint:SheetView>
                                                                    </Sheets>
                                                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                        Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                                        HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                                                    </TitleInfo>
                                                                </farpoint:FpSpread>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanel6" runat="server" HeaderText="Üretimdeki Siparişler">
                        <ContentTemplate>
                            <table style="border-style: none; border-color: inherit; border-width: 1px; height: 108px;
                                position: absolute; top: 122px; left: 16px; width: 689px; font-size: x-small;
                                background-color: #D3DEEF;">
                                <tr>
                                    <td class="style167">
                                        <farpoint:FpSpread ID="grdcelalbey" runat="server" ActiveSheetViewIndex="0" BorderColor="Black"
                                            BorderStyle="Solid" BorderWidth="1px" ClientAutoCalculation="True" CommandBarOnBottom="False"
                                            DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;"
                                            EditModeReplace="True" EnableAjaxCall="False" EnableClientScript="False" EnableTheming="True"
                                            Height="125px" HierarchicalView="False" HorizontalScrollBarPolicy="Never" meta:resourceKey="fpSiparisGetirResource1"
                                            scrollContent="true" scrollContentColumns="" scrollContentMaxHeight="50" scrollContentTime="500"
                                            VerticalScrollBarPolicy="Always" Width="682px">
                                            <CommandBar>
                                                <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                            </CommandBar>
                                            <Pager ForeColor="Red" Mode="Number" Position="TopCommandBar" />
                                            <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" />
                                            <Sheets>
                                                <farpoint:SheetView AllowSort="True" AllowUserFormulas="False" ColumnFooterHeight="40"
                                                    ColumnHeaderAutoTextIndex="0" ColumnHeaderHeight="40" DefaultRowHeight="16" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;14&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sipariş No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Rev. No&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Top. Mik.&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ülke&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Durum&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Siparişi Knt&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sipariş Giriş Onayı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Siparişi Sahibi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Üretim Siparis Onayı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;UrtPlanlama Onay&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Siparişin Sahibi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Üretilen Miktar&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;14&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Siparis_Listesi&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;14&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Default&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;Empty&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Empty&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;Empty&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;Empty&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;False&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;False&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;False&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;Empty&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;Empty&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;Empty&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;#7999c2&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;AxisModels&gt;&lt;Row class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;16&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;16&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Row&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;14&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;53&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;60&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;167&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;189&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Size&gt;185&lt;/Size&gt;&lt;SortIndicator&gt;Descending&lt;/SortIndicator&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Size&gt;159&lt;/Size&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Size&gt;35&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Size&gt;238&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Size&gt;27&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Size&gt;78&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;15&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;15&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;14&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;14&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;Font&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;Names&gt;&lt;Name&gt;Arial&lt;/Name&gt;&lt;/Names&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;3&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;8&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;ImeMode&gt;Disabled&lt;/ImeMode&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;Font&gt;&lt;Size&gt;Medium&lt;/Size&gt;&lt;Bold&gt;False&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;13&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Getir&lt;/CommandName&gt;&lt;Text&gt;Getir&lt;/Text&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;14&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Siparis_Listesi&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;ColumnFooterHeight&gt;40&lt;/ColumnFooterHeight&gt;&lt;ColumnHeaderAutoTextIndex&gt;0&lt;/ColumnHeaderAutoTextIndex&gt;&lt;RowHeaderWidth&gt;15&lt;/RowHeaderWidth&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;ColumnHeaderHeight&gt;40&lt;/ColumnHeaderHeight&gt;&lt;RowHeaderVisible&gt;False&lt;/RowHeaderVisible&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;AllowSort&gt;True&lt;/AllowSort&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;PageSize&gt;15&lt;/PageSize&gt;&lt;OperationMode&gt;ReadOnly&lt;/OperationMode&gt;&lt;AllowUserFormulas&gt;False&lt;/AllowUserFormulas&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;14&lt;/ColumnCount&gt;&lt;DefaultRowHeight&gt;16&lt;/DefaultRowHeight&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;"
                                                    GridLineColor="#D0D7E5" OperationMode="ReadOnly" PageSize="15" RowHeaderVisible="False"
                                                    RowHeaderWidth="15" SelectionBackColor="#EAECF5" SheetName="Siparis_Listesi"
                                                    AllowPage="False">
                                                    <ColumnHeader AutoTextIndex="0" Height="40" />
                                                    <ColumnFooter Height="40" />
                                                    <RowHeader Visible="False" Width="15" />
                                                </farpoint:SheetView>
                                            </Sheets>
                                            <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor=""
                                                HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                            </TitleInfo>
                                        </farpoint:FpSpread>
                                    </td>
                                </tr>
                            </table>
                            <table border="1" style="border-style: inherit; position: absolute; height: 38px;
                                top: 53px; width: 109px; left: 16px; background-color: #E3FDFD; margin-bottom: 0px;
                                right: 1205px; bottom: 1209px;">
                                <tr>
                                    <td style="border-style: ridge; color: #0000FF; font-family: Arial; font-size: large;
                                        background-color: #D7FFFF">
                                        <asp:Button ID="Button3" runat="server" BackColor="Gray" Font-Bold="True" Font-Size="X-Small"
                                            ForeColor="White" Height="40px" meta:resourceKey="Button1Resource1" Style="font-size: medium;
                                            margin-left: 5%; margin-right: 0%" Text="Listele" Width="87px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajax:TabPanel>
                </ajaxToolkit:TabContainer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
