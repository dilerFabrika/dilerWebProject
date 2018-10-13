<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DokumAlyajRaporu.aspx.cs" Inherits="diler.Web.DokumAlyajRaporu" %>

<%@ Register assembly="FarPoint.Web.Spread" namespace="FarPoint.Web.Spread" tagprefix="FarPoint" %>

<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

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

    <%--tab panel ıcın--%>
  <%--   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>


    <style type="text/css">
        .auto-style3 {
            width: 79px;
        }
        .auto-style4 {
            width: 15px;
        }
          a:hover,a:focus{
    outline: none;
    text-decoration: none;
}
.tab{ text-align: center; }
.tab .nav-tabs{
    display: inline-block;
    border-bottom: none;
    position: relative;
}
.tab .nav-tabs li{
    margin-bottom: 0;
}
.tab .nav-tabs li a{
    display: block;
    padding: 20px;
    border: none;
    border-radius: 0;
    font-size: 17px;
    font-weight: 700;
    color: #444;
    margin-right: 0;
    text-align: center;
    z-index: 1;
    transition: all 0.3s ease 0s;
}
.tab .nav-tabs li a i{
    display: block;
    font-size: 40px;
    color: #00a6ff;
    margin-bottom: 15px;
}
.tab .nav-tabs li.active a,
.tab .nav-tabs li a:hover{
    border: none;
    background: transparent;
}
.tab .nav-tabs li a:before,
.tab .nav-tabs li a:after{
    content: "";
    width: 0;
    border-top: 3px solid #00a6ff;
    position: absolute;
    bottom: -1px;
    left: 0;
    transition: all 0.3s ease 0s;
}
.tab .nav-tabs li a:after{
    left: auto;
    right: 0;
}
.tab .nav-tabs li.active a:before,
.tab .nav-tabs li a:hover:before,
.tab .nav-tabs li.active a:after,
.tab .nav-tabs li a:hover:after{
    width: 50%;
}
.tab .tab-content{
    padding: 20px;
    margin-top: -5px;
    border-radius: 0 0 5px 5px;
    border-top: 1px solid #d7d6d6;
    font-size: 15px;
    color: #757575;
    line-height: 30px;
}
.tab .tab-content h3{
    font-size: 24px;
    margin-top: 0;
}
@media only screen and (max-width: 479px){
    .tab .nav-tabs li{
        width: 100%;
        text-align: center;
        margin-bottom: 5px;
    }
    .tab .nav-tabs li a,
    .tab .nav-tabs li a:hover{ border-bottom: 1px solid #dfdfdf; }
    .tab .tab-content{ border-top: none; }
}
        .auto-style5 {
            width: 742px;
            height: 13px;
        }
        .auto-style6 {
            width: 111%;
            height: 34px;
            position: relative;
            min-height: 1px;
            float: left;
            left: 0px;
            top: -26px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style7 {
            width: 96%;
            height: 34px;
            position: relative;
            min-height: 1px;
            float: left;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        
        .auto-style8 {
            left: 0px;
            top: 0px;
            color: #3366FF;
        }
        .auto-style9 {
            color: #3366FF;
        }
        
        .auto-style10 {
            width: 186px;
        }
        .auto-style11 {
            width: 194px;
        }
        .auto-style12 {
            width: 98%;
            height: 34px;
            position: relative;
            min-height: 1px;
            float: left;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        
        .auto-style13 {
            height: 15px;
        }
        
    </style>

</head>
<body style="height: 655px">
    <form id="form1"  runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="jumbotron text-center" style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: medium; height: 8px;">
        ÇELİKHANE PROGRAMI ALYAJ DATALARI DUZELTME EKRANI
    </div>
  <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        Adım 1.     Tarih aralığını seçip Getir  tusuna basın Alyaj Listesi gelecektir
    </div>
    <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        Adım 2.     Sakla(Excel) tuşuna basın. Sakladığınız bu dosya üzerinde değişiklikleri yapınca. Dosyayı "\\192.168.198.8\Documents\ALYAJLAR.xlsx" olarak saklayın
    </div>
    <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        Adım 2 Not. Dosya isminiz ALYAJLAR.XLSX Olmalıdır.
    </div>
        <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        Adım 3.     Duzeltme yapıp kopylayadıgınız dosyayı Getir(Excel) tuşu ile çağırın ve Hazırla butonuna basın
    </div>
     <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        Adım 4.     Ozeti oluşan bu dosyayıda saklayın SaklaOzet(excel). Bu dosyayı Mail olarak atın
    </div>
    <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        
    </div>
    <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        
    </div>
            <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; height: 15px;">
        
    </div>
            <div style="color: #FFFFFF; font-family: 'Courier New', Courier, monospace; font-size: smaller; " class="auto-style13">
        
    </div>
        <div class="auto-style5">
        <table class="auto-style6">
            <tr>
                <td>                    <span style="color: #333333">

                        <asp:ImageButton ID="ImageButton1" runat="server" Style="background-color: lightblue;"
                            ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" OnClick="ImageButton1_Click" Height="27px" Width="34px" />
                    </span>
                </td>
                    <td class="auto-style12"> Baş. Tar. </td>
                    <td>
                        <asp:TextBox ID="bastar" runat="server"  Height="25px" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style7"> Bitiş Tar.&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="bittar" runat="server"  Height="25px" TextMode="Date" Width="115px"></asp:TextBox>
                    </td>
                <td style="color: #2B3E50">__</td>
                    <td> <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Getir" Width="75px" OnClick="Button1_Click" Height="34px" Font-Bold="False" Font-Size="Small" /></td>
                <td style="color: #2B3E50">&nbsp;</td>
                <td style="color: #2B3E50" class="auto-style4"><asp:Button ID="Button2" class="btn btn-warning" runat="server" Text="Sakla(Excel)" Width="113px" OnClick="Button2_Click" Height="36px" Font-Bold="False" Font-Size="Small" /></td>
                <td style="color: #2B3E50"> &nbsp;</td>
                    <td> <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Sakla" Width="68px" OnClick="Button3_Click" Height="36px" Font-Bold="False" Font-Size="Small" Visible="False" /></td>
                <td style="color: #2B3E50">_&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _</td>
                    <td class="auto-style3">  

                        <asp:FileUpload ID="FileUpload1" runat="server" Height="21px" OnInit="FileUpload1_Init" Width="16px" Visible="False"/>
                        </td>
                <td style="color: #2B3E50"><asp:Button ID="Button4" class="btn btn-default" runat="server" Text="Getir(Excel)" Width="104px"  Height="36px" Font-Bold="False" Font-Size="Small" OnClick="Button4_Click" /></td>
                    <td class="auto-style11"> &nbsp;</td>
                    <td class="auto-style10"> <asp:Button ID="Button5" class="btn btn-success" runat="server" Text="Hazırla" Width="85px"  Height="36px" Font-Bold="False" Font-Size="Small" OnClick="Button5_Click" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td> &nbsp;</td>
                

                <td> <asp:Button ID="Button6" class="btn btn-warning" runat="server" Text="SaklaOzet(Excel)" Width="153px" OnClick="Button6_Click" Height="36px" Font-Bold="False" Font-Size="Small" /></td>
                

            </tr>

            </table>
            </div>
        <div>
 <br />
           </div>
        <div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>  
                         <div class="container-fluid">
	                     <div class="row">
                               <div class="col-sm-12" style="background-color: #2B3E50; background-image: url('images/dilerlogo4.png');background-position : 50% 50%;">
    	          
                                     <div class="tab" role="tabpanel">
                                            <ul class="nav nav-tabs" role="tablist">
                                                <li role="presentation" class="active"><a href="#AyrıntılıRapor" aria-controls="home" role="tab" data-toggle="tab" class="auto-style8"><i class="fa fa-globe"></i> AyrıntılıRapor</a></li>
                                                <li role="presentation"><a href="#OzetRapor" aria-controls="profile" role="tab" data-toggle="tab" class="auto-style9"><i class="fa fa-rocket"></i> OzetRapor</a></li>
                                            </ul>
                                         <div class="tab-content tabs">
                                                 <div role="tabpanel" class="tab-pane fade in active" id="AyrıntılıRapor">
                                                        <FarPoint:FpSpread ID="FpSpread1" runat="server" ActiveSheetViewIndex="0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" EnableTheming="True" Height="249px" Width="431px" ClientIDMode="AutoID" VerticalScrollBarPolicy="Always">
                                    <commandbar backcolor="Transparent">
                                        <Background BackgroundImageUrl="{SPREADCLIENTPATH}/img/cbbg.gif" />
                                    </commandbar>
                                    <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <sheets>
                                        <FarPoint:SheetView DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Classic2&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;White&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Black&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;#dedfde&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;#6b696b&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;White&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;True&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;True&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;True&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;#ce5d5a&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;#f7f7de&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;White&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;/Border&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;/Border&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;AltRowStyles&gt;&lt;AltRowStyle Index=&quot;0&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#f7f7de&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;AltRowStyle Index=&quot;1&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;/AltRowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;#dedfde&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#ce5d5a&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" GridLineColor="#DEDFDE" SelectionBackColor="#CE5D5A" SelectionForeColor="White" SheetName="Sheet1" AllowPage="False">
                                        </FarPoint:SheetView>
                                    </sheets>
                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center">
                                    </TitleInfo>
                                </FarPoint:FpSpread>
                                                 </div>
                                                 <div role="tabpanel" class="tab-pane fade" id="OzetRapor">

                                                     <div>
                                                            <FarPoint:FpSpread ID="FpSpread2" runat="server" ActiveSheetViewIndex="0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" EnableTheming="True" Height="249px" Width="431px" ClientIDMode="AutoID" VerticalScrollBarPolicy="Always">
                                    <commandbar backcolor="Transparent">
                                        <Background BackgroundImageUrl="{SPREADCLIENTPATH}/img/cbbg.gif" />
                                    </commandbar>
                                    <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <sheets>
                                        <FarPoint:SheetView DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Classic2&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;White&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Black&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;#dedfde&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;#6b696b&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;White&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;True&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;True&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;True&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;#ce5d5a&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;#f7f7de&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;White&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;/Border&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;/Border&gt;&lt;Font&gt;&lt;Bold&gt;True&lt;/Bold&gt;&lt;Italic&gt;False&lt;/Italic&gt;&lt;Overline&gt;False&lt;/Overline&gt;&lt;Strikeout&gt;False&lt;/Strikeout&gt;&lt;Underline&gt;False&lt;/Underline&gt;&lt;/Font&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;AltRowStyles&gt;&lt;AltRowStyle Index=&quot;0&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#f7f7de&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;AltRowStyle Index=&quot;1&quot; class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;/AltRowStyle&gt;&lt;/AltRowStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;4&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;#6b696b&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;#dedfde&quot; Style=&quot;Solid&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;ForeColor&gt;White&lt;/ForeColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;#dedfde&lt;/GridLineColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBackColor&gt;#ce5d5a&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;White&lt;/SelectionForeColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;HeaderGrayAreaColor&gt;Empty&lt;/HeaderGrayAreaColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" GridLineColor="#DEDFDE" SelectionBackColor="#CE5D5A" SelectionForeColor="White" SheetName="Sheet1" AllowPage="False">
                                        </FarPoint:SheetView>
                                    </sheets>
                                    <TitleInfo BackColor="#E7EFF7" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center">
                                    </TitleInfo>
                                </FarPoint:FpSpread>
                                                      </div>
                                                 </div>
                                        </div>
                            </div>
                              </div>
	                     </div>
                     </div>
                </ContentTemplate>
             </asp:UpdatePanel>
        </div>

    </form>




      <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/waves.js"></script>
    <script src="js/wow.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="assets/jquery-detectmobile/detect.js"></script>
    <script src="assets/fastclick/fastclick.js"></script>
    <script src="assets/jquery-slimscroll/jquery.slimscroll.js"></script>
    <script src="assets/jquery-blockui/jquery.blockUI.js"></script>


    <!-- CUSTOM JS -->
    <script src="js/jquery.app.js"></script>

</body>
</html>
