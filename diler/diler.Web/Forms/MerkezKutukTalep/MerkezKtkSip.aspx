<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MerkezKtkSip.aspx.vb" Inherits="MerkezSip" title="Merkezden AS400 Kutuk Giriş" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register assembly="FarPoint.Web.Spread" namespace="FarPoint.Web.Spread" tagprefix="FarPoint" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxe" %>


    <form id="form1" runat="server">



    <p>
        <span style="color: #FF0066"><table 
        
        
        
            style="width: 96%; top: 0px; left: 2px; position: absolute; height: 25px; border: 1px solid #F0F8FF; background-color: #D3DEEF">
        <tr>
            <td style="width: 1px">

    <span style="color: #FF0066">
    
        <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
            ImageUrl="~/Images//AnaSayfa.png" Width="27px" BorderWidth="1px" ToolTip="Ana Menüye Dönün" />
        </span>
            </td>
            <td style="width: 1px">
        <span style="color: #FF0066"><span style="border-width: thin; color: #FF0066">
                        <asp:ImageButton ID="Image4" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_plain.png" Width="21px" 
                    ToolTip="Yeni Kayıt Oluşturmak için temizle" />
                </span> 
                            </span>
            </td>
            <td style="width: 1px">
        <span style="color: #FF0066">
                        <asp:ImageButton ID="Image6" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_check.png" Width="20px" 
                    ToolTip="Sakla veya Değiştir..." />
                            </span>
            </td>
            <td style="width: 1px">
    <span style="color: #FF0066">
                        <asp:ImageButton ID="Image5" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_error.png" Width="20px" 
                    ToolTip="Sil" />
                            </span></td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 12px">
    <span style="color: #FF0066">
                        <asp:ImageButton ID="Image9" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/mail_add.png" Width="20px" 
                    ToolTip="Bilgileri Mail Olarak Gönder..." />
                            </span></td>
            <td style="width: 12px">
                &nbsp;</td>
            <td style="width: 568px">
                <span style="color: #FF0066">
                        &nbsp;</span></td>
            <td style="width: 130px">
                &nbsp;</td>
        </tr>
    </table>
                            </span>
    <br />
</p>
<p style="color: #FF0000">
    Sn. Metin Şener Bey&#39;in Dikkatine !<br />
        <table style="width: 100%; height: 182px; color: #3366FF;">
                <tr>
                    <td style="width: 626px">
                        Aşağıda özellikleri belirtilen&nbsp; siparişin AS400 Sistemine girilmesini Arz 
                        / Rica 
                        ederim.</td>
                    <td style="width: 73px">
                        &nbsp;</td>
                    <td style="width: 23px">
                        &nbsp;</td>
                    <td style="width: 248px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 626px">
                        <br />
                        Saygılarımla,<br />
                        <br />
                        Turgay ENER.<br />
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server" 
                            Text="Sadece Acık Talepleri Getir" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="drpTalepEdenBolumler" runat="server" Height="31px" 
                            Width="209px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" BackColor="#6699FF" Font-Bold="True" 
                            Font-Size="Small" ForeColor="White" Height="28px" 
                            Text="Mail Göndermem Gerekenler" Width="252px" />
                        <br />
                    </td>
                    <td style="width: 73px">
                        &nbsp;</td>
                    <td style="width: 23px">
                        &nbsp;</td>
                    <td style="width: 248px">
                        &nbsp;</td>
                </tr>
            </table>
</p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
            <table style="border-style: double; width: 89%; top: 314px; left: 16px; position: absolute; height: 37px;">
                <tr style="color: #0000FF">
                    <td style="width: 68px">
                        <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="Bildirim Tar" 
                            Width="78px"></asp:Label>
                    </td>
                    <td style="width: 6px">
                        &nbsp;</td>
                    <td style="width: 61px">
                        &nbsp;</td>
                    <td style="width: 61px">
                        Yer</td>
                    <td style="width: 59px">
                        <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="Çap(mm)" 
                            Width="71px"></asp:Label>
                    </td>
                    <td style="width: 75px">
                        Cins&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td style="width: 80px">
                        Boy (mt)</td>
                    <td style="width: 81px">
                        <asp:Label ID="Label6" runat="server" BorderStyle="None" 
                            Text="Tonaj&nbsp;&nbsp;&nbsp;(Kg)" 
                            Width="72px"></asp:Label>
                    </td>
                    <td style="width: 75px">
                        Açıklama</td>
                    <td style="width: 248px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 68px">
                        <dx:ASPxDateEdit ID="dateBildirimTar" runat="server" Height="20px" Width="156px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 6px">
                        &nbsp;</td>
                    <td style="width: 61px">
                        <asp:ImageButton ID="Image3" runat="Server" 
                            AlternateText="Click to show calendar" Height="20px" 
                            ImageUrl="~/Images/document_zoom_in.png" Width="20px" 
                            ToolTip="SeçilenTarihi Getir........" />
                    </td>
                    <td style="width: 61px">
                        <asp:TextBox ID="txtYer" runat="server" Width="68px" BorderStyle="Inset" 
                            BorderWidth="1px"></asp:TextBox>
                    </td>
                    <td style="width: 59px">
                        <asp:TextBox ID="txtCap" runat="server" Width="68px" BorderStyle="Inset" 
                            BorderWidth="1px"></asp:TextBox>
                    </td>
                    <td style="width: 75px">
                        <asp:TextBox ID="txtCins" runat="server" Width="73px" BorderStyle="Inset" 
                            BorderWidth="1px"></asp:TextBox>
                    </td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtBoy" runat="server" Width="78px" BorderStyle="Inset" 
                            BorderWidth="1px"></asp:TextBox>
                    </td>
                    <td style="width: 81px">
                        <asp:TextBox ID="txtTonaj" runat="server" Width="78px" BorderStyle="Inset" 
                            BorderWidth="1px"></asp:TextBox>
                                    </td>
                    <td style="width: 75px">
                        <asp:TextBox ID="txtAciklama" runat="server" Width="437px" 
                            style="margin-right: 0px" BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
                    </td>
                    <td style="width: 248px">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <table style="border-style: double; width: 61%; top: 268px; left: 13px; position: absolute; height: 37px; right: 563px;">
                <tr style="color: #0000FF">
                    <td style="width: 96px">
                        Talebi Yapan</td>
                    <td style="width: 6px">
                        &nbsp;</td>
                    <td style="width: 61px">
                        <asp:TextBox ID="txtTalepBirimi" runat="server" Width="543px" 
                            style="margin-right: 0px" BorderStyle="Solid" BorderWidth="1px" 
                            BackColor="#EFEFEF" Height="17px"></asp:TextBox>
                    </td>
                </tr>
                </table>
            <br />
            <FarPoint:FpSpread ID="FpSpread1" runat="server" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="1px" Height="288px" 
                Width="998px" ActiveSheetViewIndex="0" 
                DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Spread /&gt;" 
                EnableClientScript="False" CommandBarOnBottom="False" 
                CommandBar-Visible="False">
                
<TitleInfo BackColor="#E7EFF7" ForeColor="" HorizontalAlign="Center" VerticalAlign="NotSet" 
                    Font-Size="X-Large" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" Text=""></TitleInfo>

                <HierBar Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" />
                <Pager Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" />
               
                <Sheets>
                    <FarPoint:SheetView AllowPage="False" AllowUserFormulas="False" 
                        SheetName="Sheet1" 
                        
                        
                        
                        
                        
                        
                        DesignString="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;Sheet&gt;&lt;Data&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;9&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.String&quot; whitespace=&quot; &quot; /&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Bildirim Tar&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Yer&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Talep Eden&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;4&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Çap&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;5&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Cins&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;6&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Boy&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;7&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Tonaj(kg)&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;8&quot;&gt;&lt;Data type=&quot;System.String&quot;&gt;Açıklama&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;3&quot; columns=&quot;9&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;SheetName&gt;Sheet1&lt;/SheetName&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;1&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;9&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;/ColumnFooter&gt;&lt;/Data&gt;&lt;Presentation&gt;&lt;AxisModels&gt;&lt;Column class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;9&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;Item index=&quot;0&quot;&gt;&lt;Size&gt;71&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;1&quot;&gt;&lt;Size&gt;74&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;2&quot;&gt;&lt;Size&gt;67&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;3&quot;&gt;&lt;Size&gt;179&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;4&quot;&gt;&lt;Size&gt;39&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;5&quot;&gt;&lt;Size&gt;64&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;6&quot;&gt;&lt;Size&gt;43&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;7&quot;&gt;&lt;Size&gt;59&lt;/Size&gt;&lt;/Item&gt;&lt;Item index=&quot;8&quot;&gt;&lt;Size&gt;338&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/Column&gt;&lt;RowHeaderColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;40&quot; orientation=&quot;Horizontal&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;40&lt;/Size&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/RowHeaderColumn&gt;&lt;ColumnHeaderRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnHeaderRow&gt;&lt;ColumnFooterRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; defaultSize=&quot;22&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;Size&gt;22&lt;/Size&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/ColumnFooterRow&gt;&lt;/AxisModels&gt;&lt;StyleModels&gt;&lt;RowHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;RowHeaderDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/RowHeader&gt;&lt;ColumnHeader class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;9&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnHeaderDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnHeader&gt;&lt;DataArea class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;3&quot; Columns=&quot;9&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;DataAreaDefault&quot; /&gt;&lt;ColumnStyles&gt;&lt;ColumnStyle Index=&quot;0&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.ButtonCellType&quot;&gt;&lt;CommandName&gt;Getir&lt;/CommandName&gt;&lt;Text&gt;Getir&lt;/Text&gt;&lt;ButtonCellType /&gt;&lt;/CellType&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;4&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;5&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;6&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.TextCellType&quot;&gt;&lt;TextCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;ColumnStyle Index=&quot;7&quot;&gt;&lt;CellType class=&quot;FarPoint.Web.Spread.CurrencyCellType&quot;&gt;&lt;ErrorMsg&gt;Currency: (ex, 1234,56)&lt;/ErrorMsg&gt;&lt;AllowWrap&gt;False&lt;/AllowWrap&gt;&lt;IsDateFormat&gt;False&lt;/IsDateFormat&gt;&lt;NumberFormatInfo&gt;&lt;CurrencyDecimalDigits&gt;2&lt;/CurrencyDecimalDigits&gt;&lt;CurrencyDecimalSeparator&gt;.&lt;/CurrencyDecimalSeparator&gt;&lt;CurrencyGroupSeparator&gt;,&lt;/CurrencyGroupSeparator&gt;&lt;CurrencyGroupSizes&gt;&lt;Item&gt;3&lt;/Item&gt;&lt;/CurrencyGroupSizes&gt;&lt;CurrencyNegativePattern&gt;0&lt;/CurrencyNegativePattern&gt;&lt;CurrencyPositivePattern&gt;0&lt;/CurrencyPositivePattern&gt;&lt;CurrencySymbol /&gt;&lt;NaNSymbol /&gt;&lt;NegativeInfinitySymbol&gt;-Infinity&lt;/NegativeInfinitySymbol&gt;&lt;NegativeSign&gt;-&lt;/NegativeSign&gt;&lt;NumberDecimalDigits&gt;2&lt;/NumberDecimalDigits&gt;&lt;NumberDecimalSeparator&gt;.&lt;/NumberDecimalSeparator&gt;&lt;NumberGroupSeparator&gt;,&lt;/NumberGroupSeparator&gt;&lt;NumberGroupSizes&gt;&lt;Item&gt;3&lt;/Item&gt;&lt;/NumberGroupSizes&gt;&lt;NumberNegativePattern&gt;1&lt;/NumberNegativePattern&gt;&lt;PercentDecimalDigits&gt;2&lt;/PercentDecimalDigits&gt;&lt;PercentDecimalSeparator&gt;.&lt;/PercentDecimalSeparator&gt;&lt;PercentGroupSeparator&gt;,&lt;/PercentGroupSeparator&gt;&lt;PercentGroupSizes&gt;&lt;Item&gt;3&lt;/Item&gt;&lt;/PercentGroupSizes&gt;&lt;PercentNegativePattern&gt;0&lt;/PercentNegativePattern&gt;&lt;PercentPositivePattern&gt;0&lt;/PercentPositivePattern&gt;&lt;PercentSymbol&gt;%&lt;/PercentSymbol&gt;&lt;PerMilleSymbol&gt;‰&lt;/PerMilleSymbol&gt;&lt;PositiveInfinitySymbol&gt;Infinity&lt;/PositiveInfinitySymbol&gt;&lt;PositiveSign&gt;+&lt;/PositiveSign&gt;&lt;/NumberFormatInfo&gt;&lt;GeneralCellType /&gt;&lt;NumberFormat&gt;AAEAAAD/////AQAAAAAAAAAEAQAAACVTeXN0ZW0uR2xvYmFsaXphdGlvbi5OdW1iZXJGb3JtYXRJbmZvIQAAABBudW1iZXJHcm91cFNpemVzEmN1cnJlbmN5R3JvdXBTaXplcxFwZXJjZW50R3JvdXBTaXplcwxwb3NpdGl2ZVNpZ24MbmVnYXRpdmVTaWduFm51bWJlckRlY2ltYWxTZXBhcmF0b3IUbnVtYmVyR3JvdXBTZXBhcmF0b3IWY3VycmVuY3lHcm91cFNlcGFyYXRvchhjdXJyZW5jeURlY2ltYWxTZXBhcmF0b3IOY3VycmVuY3lTeW1ib2wSYW5zaUN1cnJlbmN5U3ltYm9sCW5hblN5bWJvbBZwb3NpdGl2ZUluZmluaXR5U3ltYm9sFm5lZ2F0aXZlSW5maW5pdHlTeW1ib2wXcGVyY2VudERlY2ltYWxTZXBhcmF0b3IVcGVyY2VudEdyb3VwU2VwYXJhdG9yDXBlcmNlbnRTeW1ib2wOcGVyTWlsbGVTeW1ib2wMbmF0aXZlRGlnaXRzCm1fZGF0YUl0ZW0TbnVtYmVyRGVjaW1hbERpZ2l0cxVjdXJyZW5jeURlY2ltYWxEaWdpdHMXY3VycmVuY3lQb3NpdGl2ZVBhdHRlcm4XY3VycmVuY3lOZWdhdGl2ZVBhdHRlcm4VbnVtYmVyTmVnYXRpdmVQYXR0ZXJuFnBlcmNlbnRQb3NpdGl2ZVBhdHRlcm4WcGVyY2VudE5lZ2F0aXZlUGF0dGVybhRwZXJjZW50RGVjaW1hbERpZ2l0cxFkaWdpdFN1YnN0aXR1dGlvbgppc1JlYWRPbmx5EW1fdXNlVXNlck92ZXJyaWRlFXZhbGlkRm9yUGFyc2VBc051bWJlchd2YWxpZEZvclBhcnNlQXNDdXJyZW5jeQcHBwEBAQEBAQEBAQEBAQEBAQYAAAAAAAAAAAAAAAAAAAgICAgICAgICAgICAgBAQEBCQIAAAAJAwAAAAkEAAAABgUAAAABKwYGAAAAAS0GBwAAAAEuBggAAAABLAkIAAAACQcAAAAGCgAAAAAKCQoAAAAGCwAAAAhJbmZpbml0eQYMAAAACS1JbmZpbml0eQkHAAAACQgAAAAGDwAAAAElBhAAAAAD4oCwCREAAAAAAAAAAgAAAAIAAAAAAAAAAAAAAAEAAAAAAAAAAAAAAAIAAAABAAAAAAABAQ8CAAAAAQAAAAgDAAAADwMAAAABAAAACAMAAAAPBAAAAAEAAAAIAwAAABERAAAACgAAAAYSAAAAATAGEwAAAAExBhQAAAABMgYVAAAAATMGFgAAAAE0BhcAAAABNQYYAAAAATYGGQAAAAE3BhoAAAABOAYbAAAAATkL&lt;/NumberFormat&gt;&lt;CurrencyCellType /&gt;&lt;/CellType&gt;&lt;HorizontalAlign&gt;Center&lt;/HorizontalAlign&gt;&lt;TabStop&gt;True&lt;/TabStop&gt;&lt;VerticalAlign&gt;Middle&lt;/VerticalAlign&gt;&lt;/ColumnStyle&gt;&lt;/ColumnStyles&gt;&lt;ConditionalFormatCollections /&gt;&lt;/DataArea&gt;&lt;SheetCorner class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;1&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/DefaultStyle&gt;&lt;ConditionalFormatCollections /&gt;&lt;/SheetCorner&gt;&lt;ColumnFooter class=&quot;FarPoint.Web.Spread.Model.DefaultSheetStyleModel&quot; Rows=&quot;1&quot; Columns=&quot;9&quot;&gt;&lt;AltRowCount&gt;2&lt;/AltRowCount&gt;&lt;DefaultStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;ColumnFooterDefault&quot; /&gt;&lt;ConditionalFormatCollections /&gt;&lt;/ColumnFooter&gt;&lt;/StyleModels&gt;&lt;MessageRowStyle class=&quot;FarPoint.Web.Spread.Appearance&quot;&gt;&lt;BackColor&gt;LightYellow&lt;/BackColor&gt;&lt;ForeColor&gt;Red&lt;/ForeColor&gt;&lt;/MessageRowStyle&gt;&lt;SheetCornerStyle class=&quot;FarPoint.Web.Spread.NamedStyle&quot; Parent=&quot;CornerDefault&quot;&gt;&lt;Background class=&quot;FarPoint.Web.Spread.Background&quot;&gt;&lt;BackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chbg.gif&lt;/BackgroundImageUrl&gt;&lt;SelectedBackgroundImageUrl&gt;SPREADCLIENTPATH:/img/chm.png&lt;/SelectedBackgroundImageUrl&gt;&lt;/Background&gt;&lt;/SheetCornerStyle&gt;&lt;AllowLoadOnDemand&gt;false&lt;/AllowLoadOnDemand&gt;&lt;LoadRowIncrement &gt;10&lt;/LoadRowIncrement &gt;&lt;LoadInitRowCount &gt;30&lt;/LoadInitRowCount &gt;&lt;TopRow&gt;0&lt;/TopRow&gt;&lt;PreviewRowStyle class=&quot;FarPoint.Web.Spread.PreviewRowInfo&quot; /&gt;&lt;/Presentation&gt;&lt;Settings&gt;&lt;Name&gt;Sheet1&lt;/Name&gt;&lt;Categories&gt;&lt;Appearance&gt;&lt;GridLineColor&gt;#d0d7e5&lt;/GridLineColor&gt;&lt;SelectionBorder class=&quot;FarPoint.Web.Spread.Border&quot; /&gt;&lt;SelectionBackColor&gt;#eaecf5&lt;/SelectionBackColor&gt;&lt;/Appearance&gt;&lt;Behavior&gt;&lt;SelectionPolicy&gt;Single&lt;/SelectionPolicy&gt;&lt;AllowPage&gt;False&lt;/AllowPage&gt;&lt;OperationMode&gt;SingleSelect&lt;/OperationMode&gt;&lt;AllowUserFormulas&gt;False&lt;/AllowUserFormulas&gt;&lt;/Behavior&gt;&lt;Layout&gt;&lt;RowHeaderColumnCount&gt;1&lt;/RowHeaderColumnCount&gt;&lt;ColumnCount&gt;9&lt;/ColumnCount&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;/Layout&gt;&lt;/Categories&gt;&lt;ColumnHeaderRowCount&gt;1&lt;/ColumnHeaderRowCount&gt;&lt;ColumnFooterRowCount&gt;1&lt;/ColumnFooterRowCount&gt;&lt;PrintInfo&gt;&lt;Header /&gt;&lt;Footer /&gt;&lt;ZoomFactor&gt;0&lt;/ZoomFactor&gt;&lt;FirstPageNumber&gt;1&lt;/FirstPageNumber&gt;&lt;Orientation&gt;Auto&lt;/Orientation&gt;&lt;PrintType&gt;All&lt;/PrintType&gt;&lt;PageOrder&gt;Auto&lt;/PageOrder&gt;&lt;BestFitCols&gt;False&lt;/BestFitCols&gt;&lt;BestFitRows&gt;False&lt;/BestFitRows&gt;&lt;PageStart&gt;-1&lt;/PageStart&gt;&lt;PageEnd&gt;-1&lt;/PageEnd&gt;&lt;ColStart&gt;-1&lt;/ColStart&gt;&lt;ColEnd&gt;-1&lt;/ColEnd&gt;&lt;RowStart&gt;-1&lt;/RowStart&gt;&lt;RowEnd&gt;-1&lt;/RowEnd&gt;&lt;ShowBorder&gt;True&lt;/ShowBorder&gt;&lt;ShowGrid&gt;True&lt;/ShowGrid&gt;&lt;ShowColor&gt;True&lt;/ShowColor&gt;&lt;ShowColumnHeader&gt;Inherit&lt;/ShowColumnHeader&gt;&lt;ShowRowHeader&gt;Inherit&lt;/ShowRowHeader&gt;&lt;ShowColumnFooter&gt;Inherit&lt;/ShowColumnFooter&gt;&lt;ShowColumnFooterEachPage&gt;True&lt;/ShowColumnFooterEachPage&gt;&lt;ShowTitle&gt;True&lt;/ShowTitle&gt;&lt;ShowSubtitle&gt;True&lt;/ShowSubtitle&gt;&lt;UseMax&gt;True&lt;/UseMax&gt;&lt;UseSmartPrint&gt;False&lt;/UseSmartPrint&gt;&lt;Opacity&gt;255&lt;/Opacity&gt;&lt;PrintNotes&gt;None&lt;/PrintNotes&gt;&lt;Centering&gt;None&lt;/Centering&gt;&lt;RepeatColStart&gt;-1&lt;/RepeatColStart&gt;&lt;RepeatColEnd&gt;-1&lt;/RepeatColEnd&gt;&lt;RepeatRowStart&gt;-1&lt;/RepeatRowStart&gt;&lt;RepeatRowEnd&gt;-1&lt;/RepeatRowEnd&gt;&lt;SmartPrintPagesTall&gt;1&lt;/SmartPrintPagesTall&gt;&lt;SmartPrintPagesWide&gt;1&lt;/SmartPrintPagesWide&gt;&lt;HeaderHeight&gt;-1&lt;/HeaderHeight&gt;&lt;FooterHeight&gt;-1&lt;/FooterHeight&gt;&lt;/PrintInfo&gt;&lt;TitleInfo class=&quot;FarPoint.Web.Spread.TitleInfo&quot;&gt;&lt;Style class=&quot;FarPoint.Web.Spread.StyleInfo&quot;&gt;&lt;BackColor&gt;#e7eff7&lt;/BackColor&gt;&lt;HorizontalAlign&gt;Right&lt;/HorizontalAlign&gt;&lt;/Style&gt;&lt;Value type=&quot;System.String&quot; whitespace=&quot;&quot; /&gt;&lt;/TitleInfo&gt;&lt;LayoutTemplate class=&quot;FarPoint.Web.Spread.LayoutTemplate&quot;&gt;&lt;Layout&gt;&lt;ColumnCount&gt;4&lt;/ColumnCount&gt;&lt;RowCount&gt;1&lt;/RowCount&gt;&lt;/Layout&gt;&lt;Data&gt;&lt;LayoutData class=&quot;FarPoint.Web.Spread.Model.DefaultSheetDataModel&quot; rows=&quot;1&quot; columns=&quot;4&quot;&gt;&lt;AutoCalculation&gt;True&lt;/AutoCalculation&gt;&lt;AutoGenerateColumns&gt;True&lt;/AutoGenerateColumns&gt;&lt;ReferenceStyle&gt;A1&lt;/ReferenceStyle&gt;&lt;Iteration&gt;False&lt;/Iteration&gt;&lt;MaximumIterations&gt;1&lt;/MaximumIterations&gt;&lt;MaximumChange&gt;0.001&lt;/MaximumChange&gt;&lt;Cells&gt;&lt;Cell row=&quot;0&quot; column=&quot;0&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;0&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;1&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;1&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;2&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;2&lt;/Data&gt;&lt;/Cell&gt;&lt;Cell row=&quot;0&quot; column=&quot;3&quot;&gt;&lt;Data type=&quot;System.Int32&quot;&gt;3&lt;/Data&gt;&lt;/Cell&gt;&lt;/Cells&gt;&lt;/LayoutData&gt;&lt;/Data&gt;&lt;AxisModels&gt;&lt;LayoutColumn class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Horizontal&quot; count=&quot;4&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot;&gt;&lt;SortIndicator&gt;Ascending&lt;/SortIndicator&gt;&lt;/Item&gt;&lt;/Items&gt;&lt;/LayoutColumn&gt;&lt;LayoutRow class=&quot;FarPoint.Web.Spread.Model.DefaultSheetAxisModel&quot; orientation=&quot;Vertical&quot; count=&quot;1&quot;&gt;&lt;Items&gt;&lt;Item index=&quot;-1&quot; /&gt;&lt;/Items&gt;&lt;/LayoutRow&gt;&lt;/AxisModels&gt;&lt;/LayoutTemplate&gt;&lt;LayoutMode&gt;CellLayoutMode&lt;/LayoutMode&gt;&lt;/Settings&gt;&lt;/Sheet&gt;" 
                        OperationMode="SingleSelect">
                    </FarPoint:SheetView>
                </Sheets>

<CommandBar Visible="False">
<Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif"></Background>
</CommandBar>
            </FarPoint:FpSpread>
    <br />
    <br />
<br />
    <br />
    <br />


</form>



