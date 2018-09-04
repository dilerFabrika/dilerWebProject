<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="ResaAracTalep.aspx.vb" Inherits="AracTalep" title="Resa Araç Talep Ekranı" %>

<%@ Register assembly="FarPoint.Web.Spread" namespace="FarPoint.Web.Spread" tagprefix="FarPoint" %>

<script runat="server">

</script>

<head>
    <style type="text/css">
        #form1
        {
            height: 886px;
        }
        .auto-style1 {
            width: 46%;
            height: 0px;
            top: 182px;
            left: 261px;
            position: absolute;
        }
        .auto-style2 {
            width: 9px;
            height: 10px;
        }
        .auto-style3 {
            width: 67px;
            height: 10px;
            color: #000099;
        }
        .auto-style4 {
            width: 69px;
            height: 10px;
            font-size: x-small;
            color: #000099;
        }
        .auto-style5 {
            width: 33px;
            height: 10px;
            color: #000099;
        }
        .auto-style6 {
            width: 75px;
            height: 10px;
            color: #000099;
        }
        .auto-style7 {
            width: 80px;
            height: 10px;
            color: #000099;
        }
        .auto-style8 {
            width: 84px;
            height: 10px;
            color: #000099;
        }
        .auto-style9 {
            font-size: x-small;
        }
        .auto-style10 {
            width: 67px;
            height: 10px;
            font-size: x-small;
            color: #000099;
        }
        .auto-style11 {
            width: 96%;
            top: 17px;
            left: 12px;
            position: absolute;
            height: 17px;
        }
        .auto-style12 {
            width: 209px;
            height: 154px;
            position: absolute;
            top: 129px;
            left: 541px;
            z-index: 1;
        }
        .auto-style13 {
            height: 64px;
            width: 479px;
            position: absolute;
            top: 217px;
            left: 48px;
            z-index: 1;
        }
        .auto-style14 {
            width: 44%;
            height: 0px;
            top: 9px;
            left: 7px;
            position: absolute;
        }
        .auto-style15 {
            width: 46%;
            height: 0px;
            top: 5px;
            left: 3px;
            position: absolute;
        }
        .auto-style16 {
            width: 96%;
            height: 100px;
            top: 5px;
            left: 4px;
            position: absolute;
        }
        .auto-style18 {
            width: 495px;
            position: absolute;
            top: -55px;
            left: -213px;
            z-index: 1;
        }
        .auto-style20 {
            width: 698px;
            height: 51px;
            position: absolute;
            top: 65px;
            left: 47px;
            z-index: 1;
        }
        .auto-style21 {
            width: 658px;
            height: 64px;
            position: absolute;
            top: 293px;
            left: 48px;
            z-index: 1;
        }
        .auto-style22 {
            font-size: small;
        }
        .auto-style23 {
            font-size: x-small;
            color: #000099;
        }
        .auto-style24 {
            color: #000099;
        }
        .auto-style25 {
            width: 758px;
            height: 194px;
            position: absolute;
            top: 371px;
            left: 47px;
            z-index: 1;
        }
    </style>
</head>
<form id="form1" runat="server">

    <span style="border-width: thin; color: #FF0066">
        &nbsp;<span style="color: #FF0066"><table 
        
        
        
        
    
        
        
    style="border: 1px solid #F0F8FF; background-color: #D3DEEF" class="auto-style11">
        <tr>
            <td style="width: 1px">
    
        <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
            ImageUrl="~/Images//AnaSayfa.png" Width="27px" BorderWidth="1px" ToolTip="Ana Menüye Dönün" />
            </td>
            <td style="width: 1px">
                <span style="color: #FF0066">
                <asp:ImageButton ID="Image6" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_plain.png" Width="20px" 
                    ToolTip="Yeni Kayıt" BorderWidth="1px" />
                </span>
            </td>
            <td style="width: 1px">
                <span style="color: #FF0066"><span style="border-width: thin; color: #FF0066">
                <asp:ImageButton ID="Image4" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_add.png" Width="21px" 
                    ToolTip="Sakla veya Değiştir..." OnClick="Image4_Click" BorderWidth="1px" />
                </span></span>
            </td>
            <td style="width: 1px">
                <span style="color: #FF0066">
                <asp:ImageButton ID="Image5" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_error.png" Width="20px" 
                    ToolTip="Sil" BorderWidth="1px" />
                </span>
            </td>
            <td style="width: 12px">

    <span style="color: #FF0066">
                <asp:ImageButton ID="Image10" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/Yazdir.png" Width="20px" 
                    ToolTip="Dökümanı Yazdır" BorderWidth="1px" />
    </span>
            </td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 568px">
                <span style="color: #FF0066">&nbsp;<asp:TextBox ID="TextBox21" runat="server" Width="257px" Font-Size="X-Small" BorderWidth="0px" Height="21px" BackColor="#D3DEEF" CssClass="auto-style22">AA</asp:TextBox>
                </span></td>
            <td style="width: 130px">
                &nbsp;</td>
        </tr>
    </table>
    </span>
    <br />

    <span style="color: #FF0066">
        <br />
       <div class="auto-style20">
            <table class="auto-style2">
            <tr style="color: #3399FF">
                <td class="auto-style10">
                        Araç Cinsi</td>
                <td class="auto-style4">
                        Araç Sayısı</td>
                <td class="auto-style5">
                    <asp:Label ID="Label24" runat="server" BorderStyle="None" Text="Süre" 
                            Width="53px" CssClass="auto-style9"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label25" runat="server" BorderStyle="None" Text="Süre Brm" 
                            Width="65px" CssClass="auto-style9"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label26" runat="server" BorderStyle="None" Text="Tlp Eden" 
                            Width="79px" CssClass="auto-style9"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label28" runat="server" BorderStyle="None" 
                            style="margin-left: 6px" Text="Sefer Sayısı" Width="74px" CssClass="auto-style9"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="Label29" runat="server" BorderStyle="None" 
                            style="margin-left: 6px" Text="Gemi" Width="36px" CssClass="auto-style9"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="Label30" runat="server" BorderStyle="None" 
                            style="margin-left: 6px" Text="Posta" Width="50px" CssClass="auto-style9"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 67px; height: 24px;">
                    <asp:DropDownList ID="DropDownList8" runat="server">
                        <asp:ListItem>Şöför</asp:ListItem>
                        <asp:ListItem>Çekici</asp:ListItem>
                        <asp:ListItem>DamperDorse</asp:ListItem>
                        <asp:ListItem>Forklift</asp:ListItem>
                        <asp:ListItem>Hi-Up</asp:ListItem>
                        <asp:ListItem>Kamyon</asp:ListItem>
                        <asp:ListItem>Lowebad</asp:ListItem>
                        <asp:ListItem>Saldorse</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 69px; height: 24px;">
                    <asp:TextBox ID="TextBox25" runat="server" Width="64px" BorderColor="#FF0066" 
                        BorderWidth="1px"></asp:TextBox>
                </td>
                <td style="width: 33px; height: 24px;">
                    <asp:TextBox ID="TextBox26" runat="server" Width="40px"></asp:TextBox>
                </td>
                <td style="width: 67px; height: 24px;">
                    <asp:DropDownList ID="DropDownList9" runat="server" Height="23px" Width="65px">
                        <asp:ListItem>Vrd</asp:ListItem>
                        <asp:ListItem>Saat</asp:ListItem>
                        <asp:ListItem>Gün</asp:ListItem>
                        <asp:ListItem>Ay</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 75px; height: 24px;">
                    <asp:TextBox ID="TextBox28" runat="server" Width="129px"></asp:TextBox>
                </td>
                <td style="width: 67px; height: 24px;">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox31" runat="server" Width="68px"></asp:TextBox>
                    </span>
                </td>
                <td style="width: 80px; height: 24px;">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox32" runat="server" Width="112px"></asp:TextBox>
                    </span>
                </td>
                <td style="width: 84px; height: 24px;">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox33" runat="server" Width="54px"></asp:TextBox>
                    </span>
                </td>
            </tr>
        </table>

       </div>
    </span><br />
        <div class="auto-style18">
            <table class="auto-style1">
            <tr style="color: #3399FF">
                <td style="width: 46px; color: #0000FF;">
                    <asp:Label ID="Label31" runat="server" BorderStyle="None" Text="Alınacak Yer" 
                            Width="97px" CssClass="auto-style23"></asp:Label>
                </td>
                <td style="width: 108px">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox34" runat="server" Width="379px"></asp:TextBox>
        </span></td>
            </tr>
            <tr>
                <td style="width: 46px; color: #0000FF;" class="auto-style9">
        <span style="color: #FF0066">
                    <asp:Label ID="Label41" runat="server" BorderStyle="None" Text="Bırakılacak Yer" 
                            Width="97px" CssClass="auto-style23"></asp:Label>
        </span>
                </td>
                <td style="width: 108px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox42" runat="server" Width="378px"></asp:TextBox>
        </span>
                </td>
            </tr>
            <tr>
                <td style="width: 46px; color: #0000FF;" class="auto-style9">
        <span style="color: #FF0066">
                    <asp:Label ID="Label32" runat="server" BorderStyle="None" Text="Mlz Cinsi" 
                            Width="73px" CssClass="auto-style23"></asp:Label>
        </span>
                </td>
                <td style="width: 108px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox52" runat="server" Width="377px"></asp:TextBox>
        </span>
                </td>
            </tr>
        </table>
        </div>
        <br />
        <br />
        <br />
        <br />
        
        <br />
        <br />
        <br />
        <div class="auto-style13"><table class="auto-style14">
            <tr style="color: #3399FF">
                <td style="color: #0000FF;" class="auto-style9">
        <span style="color: #FF0066">
                    <asp:Label ID="Label33" runat="server" BorderStyle="None" Text="Mlz Agırlığı" 
                            Width="64px" CssClass="auto-style23"></asp:Label>
        </span>
                </td>
                <td style="color: #0000FF;">
        <span style="color: #FF0066">
                    <asp:Label ID="Label34" runat="server" BorderStyle="None" Text="Mlz Tonajı" 
                            Width="65px" CssClass="auto-style23"></asp:Label>
        </span></td>
                <td style="color: #0000FF;">
        <span style="color: #FF0066">
                    <asp:Label ID="Label35" runat="server" BorderStyle="None" Text="Masraf Kodu" 
                            Width="79px" CssClass="auto-style23"></asp:Label>
        </span>
                </td>
                <td style="color: #0000FF;">
        <span style="color: #FF0066">
                        <asp:Label ID="Label36" runat="server" BorderStyle="None" Text="İletişim Gsm" 
                            Width="76px" CssClass="auto-style23"></asp:Label>
        </span></td>
                <td style="color: #0000FF;">
        <span style="color: #FF0066">
                    <asp:Label ID="Label37" runat="server" BorderStyle="None" 
                            style="margin-left: 6px" Text="İletişim Dah." Width="77px" CssClass="auto-style23"></asp:Label>
        </span>
                </td>
                <td class="auto-style23">
                    Mlz Boyut</td>
            </tr>
            <tr>
                <td style="width: 9px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox36" runat="server" Width="60px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 57px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox53" runat="server" Width="70px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 22px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox37" runat="server" Width="73px" BorderColor="#FF0066" 
                        BorderWidth="1px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 75px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox38" runat="server" Width="79px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 64px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox39" runat="server" Width="88px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 67px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox35" runat="server" Width="62px"></asp:TextBox>
        </span></td>
            </tr>
        </table></div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="auto-style12"><table class="auto-style16">
            <tr>
                <td style="height: 4px;" class="auto-style24">
                    Açıklama</td>
            </tr>
            <tr>
                <td>
        <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox54" runat="server" Width="194px" Height="112px" 
                        TextMode="MultiLine"></asp:TextBox>
        </span>
                </td>
            </tr>
        </table></div>
        <br />
        <div class="auto-style21">
            <table class="auto-style15">
            <tr style="color: #3399FF">
                <td style="width: 9px">
                    <asp:Label ID="Label38" runat="server" BorderStyle="None" Text="Talep Tar." 
                            Width="97px"></asp:Label>
                </td>
                <td style="width: 108px">
                        Başlangıç Tar.</td>
                <td style="width: 17px">
                    <asp:Label ID="Label39" runat="server" BorderStyle="None" Text="Baş Saat" 
                            Width="64px"></asp:Label>
                </td>
                <td style="width: 75px">
                        Bitiş Tar</td>
                <td style="width: 64px">
                    <asp:Label ID="Label40" runat="server" BorderStyle="None" Text="Bit. Saat" 
                            Width="64px"></asp:Label>
                </td>
                <td style="width: 96px">
                        &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                        
                    <asp:TextBox ID="DATE7" runat="server" TextMode="Date"></asp:TextBox>
                        
                </td>
                <td style="width: 108px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="DATE9" runat="server" TextMode="Date"></asp:TextBox>
        </span>
                </td>
                <td style="width: 17px">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox51" runat="server" Width="65px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 75px">
        <span style="color: #FF0066">
                    <asp:TextBox ID="DATE10" runat="server" TextMode="Date"></asp:TextBox>
        </span>
                </td>
                <td style="width: 64px">
                    <span style="color: #FF0066">
                    <asp:TextBox ID="TextBox46" runat="server" Width="58px"></asp:TextBox>
        </span>
                </td>
                <td style="width: 96px">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
        <br />
        <br />
        
        <br />
        <br />
        <br />
        <div class="auto-style25">
&nbsp;<FarPoint:FpSpread ID="FpSpread1" runat="server" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="1px" Height="350px" 
                Width="757px" ActiveSheetViewIndex="0" 
                DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" 
                EnableClientScript="False" CommandBarOnBottom="False" 
                CommandBar-Visible="False">
            <TitleInfo BackColor="#E7EFF7" ForeColor="" HorizontalAlign="Center" VerticalAlign="NotSet" 
                    Font-Size="X-Large" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" Text="">
            </TitleInfo>
            <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" />
            <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" />
            <Sheets>
                <FarPoint:SheetView AllowPage="False" AllowUserFormulas="False" 
                        SheetName="Sheet1" 
                        
                        
                        
                        
                        
                    
                    DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;7&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Birim&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;TlpEden&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Bildirim Tar&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;BaşTar&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;AraçCinsi&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Gemi&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;7&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;7&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;ActiveSkin class=&quot;FarPoint.Web.Spread.SheetSkin&quot;&gt;&lt;Name&gt;Classic&lt;/Name&gt;&lt;BackColor&gt;Empty&lt;/BackColor&gt;&lt;CellBackColor&gt;Empty&lt;/CellBackColor&gt;&lt;CellForeColor&gt;Empty&lt;/CellForeColor&gt;&lt;CellSpacing&gt;0&lt;/CellSpacing&gt;&lt;GridLines&gt;Both&lt;/GridLines&gt;&lt;GridLineColor&gt;LightGray&lt;/GridLineColor&gt;&lt;HeaderBackColor&gt;Control&lt;/HeaderBackColor&gt;&lt;HeaderForeColor&gt;Empty&lt;/HeaderForeColor&gt;&lt;FlatColumnHeader&gt;False&lt;/FlatColumnHeader&gt;&lt;FlatRowHeader&gt;False&lt;/FlatRowHeader&gt;&lt;HeaderFontBold&gt;False&lt;/HeaderFontBold&gt;&lt;SelectionBackColor&gt;LightBlue&lt;/SelectionBackColor&gt;&lt;SelectionForeColor&gt;Empty&lt;/SelectionForeColor&gt;&lt;EvenRowBackColor&gt;Empty&lt;/EvenRowBackColor&gt;&lt;OddRowBackColor&gt;Empty&lt;/OddRowBackColor&gt;&lt;ShowColumnHeader&gt;True&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;True&lt;/ShowRowHeader&gt;&lt;ColumnHeaderBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/ColumnHeaderBackground&gt;&lt;SheetCornerBackground class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/SheetCornerBackground&gt;&lt;HeaderGrayAreaColor&gt;Control&lt;/HeaderGrayAreaColor&gt;&lt;/ActiveSkin&gt;&lt;HeaderGrayAreaColor&gt;Control&lt;/HeaderGrayAreaColor&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;7&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;38&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;139&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;130&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;59&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;56&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;94&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;137&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot;&gt;&lt;BackColor&gt;Control&lt;/BackColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;7&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;BackColor&gt;Control&lt;/BackColor&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;7&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot; /&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Liste&lt;/CommandName&gt;&lt;Text&gt;Liste&lt;/Text&gt;&lt;BackColor&gt;White&lt;/BackColor&gt;&lt;ForeColor&gt;Black&lt;/ForeColor&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;Control&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;7&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot;&gt;&lt;BackColor&gt;Control&lt;/BackColor&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;BackColor&gt;Control&lt;/BackColor&gt;&lt;Border class=&quot;FarPoint.Web.Spread.Border&quot; Size=&quot;1&quot; Style=&quot;Solid&quot;&gt;&lt;Bottom Color=&quot;ControlDark&quot; /&gt;&lt;Left Size=&quot;0&quot; /&gt;&lt;Right Color=&quot;ControlDark&quot; /&gt;&lt;Top Size=&quot;0&quot; /&gt;&lt;/Border&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/BackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;HeaderGrayAreaColor&gt;Control&lt;/HeaderGrayAreaColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;AllowUserFormulas&gt;False&lt;/AllowUserFormulas&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;7&lt;/ColumnCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" GridLineColor="#D0D7E5" SelectionBackColor="#EAECF5">
                    <SelectionBorder BorderStyle="NotSet" BorderStyleBottom="NotSet" 
                            BorderStyleLeft="NotSet" BorderStyleRight="NotSet" BorderStyleTop="NotSet" />
                    <RowHeader Width="40" />
                </FarPoint:SheetView>
            </Sheets>
            <CommandBar Visible="False">
                <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif">
                </Background>
            </CommandBar>
        </FarPoint:FpSpread>
        </div>
        <br />
        </span>&nbsp;&nbsp;<br />
    
    <br />
    </span>
    <br />
    <br />
    <br />


</form>



