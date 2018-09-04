<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KatsayiKontrol.aspx.cs" Inherits="diler.Web.Forms.EndMuh.KatsayiKontrol" %>

<%@ Register assembly="FarPoint.Web.Spread" namespace="FarPoint.Web.Spread" tagprefix="FarPoint" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="stylesheet" href="../../js/notifyit/notifIt.css" />
    <script src="../../js/jquery-2.0.3.min.js"></script>
    <script src="../../js/notifyit/notifIt.js"></script>

    <script src="../js/notifyit/Notifier.js"></script>



    <!-- Font Icons -->
    <link href="../../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="../../css/waves-effect.css" rel="stylesheet" />

    <link rel="stylesheet" href="../../css/bootstrap.css" />
    <link rel="stylesheet" href="../../css/bootstrap.min2.css" />
    <link rel="stylesheet" href="../../css/index.css" />

    <script src="../../js/notifier.js"></script>
        <script src="../../js/modernizr.min.js"></script>

    <%--confirm butonlar ini--%>
    
       <script src="../../js/jquery-2.0.3.min.js"></script>
        <script src="../../jquery/jquery.confirm.js"></script>


    <%--confirm butonlar ini--%>

    <%--yes no--%>
    <script src="../../fancybox/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../fancybox/jquery.fancybox.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox.css" media="screen" />

    <style type="text/css">
          body
        {
            font-family: Calibri;
            font-weight: bold;
        }
          .lnkButton
        {
            text-decoration: none;
            color: #000;
            font-size: 13px;
            background-color: #ECB21E;
            border: 1px solid #666;
            padding: 7px 15px;
            cursor: pointer;
        }
        .btnGreen
        {
            text-decoration: none;
            color: #000;
            font-size: 13px;
            background-color: #a5cba4;
            border: 1px solid #666;
            padding: 7px 15px;
            cursor: pointer;
        }
        .btnRed
        {
            text-decoration: none;
            color: #000;
            font-size: 13px;
            background-color: #E08584;
            border: 1px solid #666;
            padding: 7px 15px;
            cursor: pointer;
        }

        .auto-style1 {
            width: 92px;
            text-align: justify;
            height: 42px;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            margin-left: 11;
        }
        .auto-style4 {
            height: 42px;
            width: 35px;
        }
    </style>

</head>
<body style="height: 655px">
    <form id="form1"  runat="server">
    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="jumbotron text-center" style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: medium; height: 1px; width: 1871px;">
        ÇELİKHANE KATSAYI KONTROL MODULU<table>
            <tr>
                    <td class="auto-style4"> 
    
        <asp:ImageButton ID="ImageButton3" runat="server" Height="19px" 
            ImageUrl="~/Images//AnaSayfa.png" Width="25px" OnClick="ImageButton1_Click" />
                    </td>
            </tr>

        </table>
            </div>
        <div>
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="auto-style2">&nbsp; Tarih&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td class="auto-style2">&nbsp; </td>
                                        <td class="auto-style2">
                                            <asp:TextBox ID="bastar" runat="server" CssClass="auto-style3" Height="26px" TextMode="Date" Width="132px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style2">
                                        </td>
                                        <td class="auto-style2">
                                        </td>
                                        <td class="auto-style2" style="color: #2B3E50">__</td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Button4" runat="server" class="btn btn-danger" Height="32px" OnClick="Button4_Click" Text="Listele" Width="88px" />
                                        </td>
                                        <td class="auto-style2">
                                            <asp:LinkButton ID="LnkButton" runat="server" UseSubmitBehavior="True"  CssClass="lnkButton" OnClick="LnkButton1_Click" OnClientClick="return fancyConfirm('Tüm Kırmızı satırlar Update edilecek. Emin misiniz?', this, 'Yes', 'No');" Text="Tümünü Sakla"></asp:LinkButton>
                                            <%--<asp:LinkButton ID="LinkButton1"  OnClientClick="onay('Are you sure you want delete');" UseSubmitBehavior="False"  runat="server" CssClass="lnkButton" OnClick="LnkButton1_Click" Text="Tümünü Sakla"></asp:LinkButton>--%>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:Button ID="Button6" runat="server" class="btn btn-danger" Height="32px" OnClick="Button4_Click" Text="Sakla" Width="88px" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td class="auto-style2">&nbsp; Dökm Tipine Göre Rapor&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        <td class="auto-style2">
                                            &nbsp;</td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Button5" runat="server" class="btn btn-danger" Height="35px" OnClick="Button5_Click" Text="Listele" Width="88px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <FarPoint:FpSpread ID="FpSpread1" runat="server" ActiveSheetViewIndex="0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ClientIDMode="AutoID" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" Height="516px" OnButtonCommand="FpSpread1_ButtonCommand" Width="1390px" EditModeReplace="True">
                                    <CommandBar BackColor="Control" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight" ButtonShadowColor="ControlDark" Visible="False">
                                        <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                    </CommandBar>
                                    <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <Sheets>
                                        <FarPoint:SheetView AllowPage="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;16&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;DokumNo&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sıra&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Vrd&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Ebat&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Celik Cinsi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kutuk Adet&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Kutuk Tonaj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Uretim Katsayısı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Stn.KarışımSayısı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Stn.KarışımTonaj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;11&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Uretim Katsayısı&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;12&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Tartımdan Genel KatSay&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;13&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yeni Üretim Tnj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;14&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;YeniÜretimTnjKrsm&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;15&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Sakla&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;16&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;16&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Professional3&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;#dedfde&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Black&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;White&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;#4a3c8c&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;#e7e7ff&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;False&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;False&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;True&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;#9471de&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;Empty&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;Empty&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;16&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;11&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;12&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;13&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;14&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;15&quot;&gt;&lt;Visible&gt;False&lt;/Visible&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot;&gt;&lt;BackColor&gt;#4a3c8c&lt;/BackColor&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;#e7e7ff&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;16&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;BackColor&gt;#4a3c8c&lt;/BackColor&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;#e7e7ff&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;16&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;BackColor&gt;#dedfde&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;1&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;2&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;3&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;8&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;9&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;10&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;11&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;12&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;13&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;14&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;15&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Button&lt;/CommandName&gt;&lt;Text&gt;Button&lt;/Text&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#4a3c8c&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;#e7e7ff&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;16&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot;&gt;&lt;BackColor&gt;#4a3c8c&lt;/BackColor&gt;&lt;ForeColor&gt;#e7e7ff&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#4a3c8c&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;#e7e7ff&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;White&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#9471de&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;DataAutoCellTypes&gt;False&lt;/DataAutoCellTypes&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;16&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" GridLineColor="White" SelectionBackColor="#9471DE" SelectionForeColor="White" SheetName="Sheet1" DataAutoCellTypes="False">
                                        </FarPoint:SheetView>
                                    </Sheets>
                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="" HorizontalAlign="Center" VerticalAlign="NotSet">
                                    </TitleInfo>
                                </FarPoint:FpSpread>
                            </td>
                            <td>
                                <FarPoint:FpSpread ID="FpSpread2" runat="server" ActiveSheetViewIndex="0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" Height="507px" Width="1031px" ClientIDMode="AutoID">
                                    <CommandBar BackColor="Control" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight" ButtonShadowColor="ControlDark">
                                        <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif" />
                                    </CommandBar>
                                    <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <Sheets>
                                        <FarPoint:SheetView AllowPage="False" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;11&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Dokum Tipi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Gunluk Adet&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Gunluk Tonaj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Aylık Adet&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Aylık Adet Oran&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Aylık Tonaj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Aylık Tonaj Oran&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yıllık Adet&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yıllık Adet Oran&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;9&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yıllık Tonaj&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;10&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yıllık Tonaj Oran&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;11&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;11&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Colorful5&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;White&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Black&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;None&lt;/GridLines&gt;&lt;GridLineColor&gt;Empty&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;Tan&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;Black&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;False&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;False&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;True&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;DarkSlateBlue&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;GhostWhite&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;LightGoldenrodYellow&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;PaleGoldenrod&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;11&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;9&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;Item index=&quot;10&quot;&gt;&lt;Visible&gt;True&lt;/Visible&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot;&gt;&lt;BackColor&gt;Tan&lt;/BackColor&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;11&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;BackColor&gt;Tan&lt;/BackColor&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;11&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;AltRowStyles&gt;&lt;AltRowStyle Index=&quot;0&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;LightGoldenrodYellow&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;AltRowStyle Index=&quot;1&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;PaleGoldenrod&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;/AltRowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;Tan&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;11&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot;&gt;&lt;BackColor&gt;Tan&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;Tan&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;Empty&lt;/GridLineColor&gt;&lt;GridLines&gt;None&lt;/GridLines&gt;&lt;SelectionForeColor&gt;GhostWhite&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;DarkSlateBlue&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;GhostWhite&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;SelectionPolicy&gt;MultiRange&lt;/SelectionPolicy&gt;&lt;OperationMode&gt;ExtendedSelect&lt;/OperationMode&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;11&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" GridLineColor="" GridLines="None" OperationMode="ExtendedSelect" SelectionBackColor="DarkSlateBlue" SelectionForeColor="GhostWhite" SelectionPolicy="MultiRange" SheetName="Sheet1">
                                        </FarPoint:SheetView>
                                    </Sheets>
                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="" HorizontalAlign="Center" Text="" VerticalAlign="NotSet">
                                    </TitleInfo>
                                </FarPoint:FpSpread>
                            </td>
                        </tr>
                     </table>
                </ContentTemplate>
                </asp:UpdatePanel>
        </div>

    </form>

<script type='text/javascript'>

            $(document).ready(function () {

            });

            document.getElementById("btnsakla").onclick = BilgiSakla;


    
            function BilgiSakla()
            {
         
                var serviceURL = '/../../KatsayiKontrol.aspx/BilgileriSakla';
               
                $.ajax
               ({

                    type: "POST",
                    url: serviceURL,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    error: errorFunc1,
                });

                function OnSuccess(response)
                {
                    alert(response.d);
                }
                function errorFunc1()
                {
                    alert('error');
                }

             }

            $("#simpleConfirm").confirm();
            $("#complexConfirm").confirm({
                title: "Delete confirmation",
                text: "This is very dangerous, you shouldn't do it! Are you really really sure?",
                confirm: function (button) {
                    button.fadeOut(2000).fadeIn(2000);
                    BilgiSakla();
                    alert("You just confirmed.");
                },
                cancel: function (button) {
                    button.fadeOut(2000).fadeIn(2000);
                    alert("You aborted the operation.");
                },
                confirmButton: "Yes I am",
                cancelButton: "No"
            });
            $("#dataConfirm").confirm();
            $("#manualTrigger").click(function () {
                $.confirm({
                    text: "This is a confirmation dialog manually triggered! Please confirm:",
                    confirm: function () {
                        alert("You just confirmed.");
                    },
                    cancel: function () {
                        alert("You cancelled.");
                    }
                });
            });
            $("#noCancelButton").confirm({
                text: "This is a confirmation dialog manually triggered! Please confirm:",
                cancelButton: false,
                confirm: function () {
                    alert("You just confirmed.");
                },
            });
            $("#modalOptions").confirm({
                text: "You can't escape! You are forced to choose!",
                modalOptionsBackdrop: 'static',
                modalOptionsKeyboard: false,
                confirm: function () {
                    alert("You just confirmed.");
                },
                cancel: function () {
                    alert("You cancelled.");
                }
            });
            function GosterIsim()
            {
                   PageMethods.GetirIsim("ad", "dgule", islemBasarili, islemHatali);
                    function islemBasarili(sonuc) {
                        alert(sonuc);
                    }
                    function islemHatali(sonuc) {
                        alert('Bir hata oluştu.');
                    }
            }
            function show_prompt()
            {
                var name = prompt("Please enter your name", "Pritesh");
                if (name != null && name != "")
                {
                    document.write("<p>Hello " + name + "</p>");
                }
            }

            function fancyConfirm(msg, btn, OkBtnText, CancelBtnText) {
                var arrbtn = btn.id.split('_');
                var html = '<div id="dialog-confirm" style="text-align:center;"><h4>';
                html += msg + '</h4><div class="form-subscribe">';
                html += '<div style="text-align: center;"><a id="fancyConfirm_ok" class="btnGreen" style="display: inline-block; margin: 15px 15px 0 0;">' + OkBtnText + '</a>';
                html += '<a id="fancyConfirm_cancel" class="btnRed">' + CancelBtnText + '</a>';
                html += '</div></div></div>';
                jQuery.fancybox({
                    'modal': true,
                    'content': html,
                    autoHeight: true,
                    autoWidth: true,
                    afterShow: function () {
                        $("#fancyConfirm_ok").bind("click", function (event) {
                            $.fancybox.close();
                            var event = $("#" + btn.id).attr('href').split(':')[1].replace("__doPostBack('", "").replace("','')", "");
                            __doPostBack(event, '');
                            return true;
                        });
                        $("#fancyConfirm_cancel").bind("click", function (event) {
                            $.fancybox.close();
                        });
                    },
                    afterClose: function () {
                        $.fancybox.close();
                    }
                });
                return false;
            }

            function confirmUpdate() {
                return confirm('Update yapılacak Emin misin?');
            }
            function updateConfirmation() {

                return confirm("update yapılacak onaylıyormusunuz test 2?")
            }
            function onay() {
                document.getElementById("TextBox1").value = "asda";
                //return confirm("update yapılacak onaylıyormusunuz test 2?")
            }



</script>
      <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js"></script>
</body>
</html>
