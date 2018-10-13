<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="istif_giris.aspx.cs" Inherits="diler.Web.Forms.Kimya.istif_giris" %>



<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxe" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="content-language" content="tr" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Diler Demir Çelik</title>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
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

    <link href="../../css/Kimya_analiz.css" rel="stylesheet" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->

    <script src="../../js/modernizr.min.js"></script>
    <style type="text/css">
        .txt_css {
            color: #7f7575;
            font-weight: bold;
            text-align: center;
            width: 100px;
            height: 33px;
            border-radius: 1px;
            /*border: 1px solid #c7cfd8;*/
            border: 2px solid #e4effa;
            font-size: 13px;
        }

        .txt_alanlar {
            color: #7f7575;
            font-weight: bold;
            text-align: center;
            width: 60px;
            height: 33px;
            border-radius: 1px;
            /*border: 1px solid #c7cfd8;*/
            border: 2px solid #e4effa;
            font-size: 13px;
        }

        div.clear {
            clear: both;
        }

        #btn_delete:hover {
            color: #ff0000 !important;
        }

        .txt_dno {
            opacity: 0;
        }
    </style>

    <script type="text/javascript">


        function istif_id(Value) {

            var answer = confirm("Kaydı silmek istediğinizden emin misiniz?");
            if (answer == true) {
                txt_istif_id.SetText(Value[0]);
                txt_istif_id.Focus();

            }

        }


        function istif_id_copy(Value) {

            txt_copy.SetText(Value[0]);
            txt_copy.Focus();

        }



        function confirmDeleteAction(s, e) {
            $("#dialog-confirmDeleteAction").dialog({
                resizable: false,
                height: 140,
                modal: true,
                buttons: {
                    "Delete": function () {
                        $(this).dialog("close");
                        e.ProcessOnServer = true;
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                        e.ProcessOnServer = false;
                    }
                }
            });
        }

        function gv_OnCustomButtonClick(s, e) {
            if (e.visibleIndex % 2 === 0)
                alert("You cannot edit this row!");
            else
                s.StartEditRow(e.visibleIndex);
        }

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var txt = e.srcElement;
            var val = txt.value;
            if (val.indexOf('.') != -1 && e.keyCode == 46)
                return false;
            var charCode = e.which || e.keyCode;

            if (charCode == 46 || (charCode >= 48 && charCode <= 57))
                return true;

            return false;
        }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


    </script>

</head>

<body>
    <form id="form1" runat="server">


        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                <p style="text-align: center; padding: 10px; font-size: 18px; color: #6f2398; margin-left: 30px; font-weight: bold;">İSTİFE KÜTÜK GÖNDERİMİ </p>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="background-color: #add8e6; height: 80px;">
                <table class="table" style="padding: 0; margin: 0; border: none; background-color: #add8e6; height: 80px;">
                    <tbody style="border: none;">
                        <tr>
                            <td style="width: 50px"></td>

                            <td style="width: 220px">İstif yeri:
                                    <asp:DropDownList ID="Cmb_istif_yeri" runat="server" Style="width: 220px" CssClass="form-control unstyled_date">
                                        <asp:ListItem Selected="True">İstif yeri seçiniz</asp:ListItem>
                                      
                                        <asp:ListItem>1 HH 1. Istif Hidrolik Unitesi</asp:ListItem>
                                        <asp:ListItem>2 HH 2. Istif Kulube Onu</asp:ListItem>
                                        <asp:ListItem>3 HH 3. Istif Yol tarafi</asp:ListItem>
                                        <asp:ListItem>4 HH 1. Istif Cubuk Saha</asp:ListItem>
                                        <asp:ListItem>5 HH 2. Istif Cubuk Saha</asp:ListItem>
                                        <asp:ListItem>6 HH 6. Istif Kose Basi</asp:ListItem>
                                        <asp:ListItem>7 HH 7. Istif 1. Yigma</asp:ListItem>
                                        <asp:ListItem>8 HH 8. Istif 2. Yigma</asp:ListItem>
                                        <asp:ListItem>9 HH 1. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>10 HH 2. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>11 HH 4. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>12 HH 3. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>13 HH 5. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>14 HH 7. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>15 HH 6. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>16 HH 8. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>17 HH 9. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>18 HH 10. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>19 HH 11. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>20 HH 12. Paket Istifi</asp:ListItem>
                                        <asp:ListItem>21 Aktarma Hatti Yani 1</asp:ListItem>
                                        <asp:ListItem>22 Aktarma Hatti Yani 2</asp:ListItem>
                                        <asp:ListItem>23 Kutuk Aktarma Hatti Onu</asp:ListItem>
                                        <asp:ListItem>50 CH 5. Istif</asp:ListItem>
                                  
                                        <asp:ListItem>100 Filmaşin Kuyu 1</asp:ListItem>
                                        <asp:ListItem>101 Filmaşin Kuyu 2</asp:ListItem>
                                        <asp:ListItem>102 Tavşancıl</asp:ListItem>
                                        <asp:ListItem>103 Resa</asp:ListItem>
                                        <asp:ListItem>104 Assan Park Saha</asp:ListItem>

                                    </asp:DropDownList>

                            </td>

                            <td style="width: 100px">

                                <asp:Button ID="btn_Listele" runat="server" Text="Listele" CssClass="btn-danger"
                                    Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #6f2398" OnClick="btn_Listele_Click" />

                            </td>

                            <td>
                                <asp:Button ID="btn_yedekleme" runat="server" Text="Yedekleme" CssClass="btn-danger"
                                    Style="width: 100px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #271d1f; border-radius: 15PX;" OnClick="btn_yedekleme_Click" />

                            </td>

                            <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" Style="height: 23px; width: 29px; margin-top: 15px" OnClick="ImageButton1_Click"
                                    ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" />

                            </td>

                        </tr>
                    </tbody>
                </table>

            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4"></div>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12" style="margin-top: 10px">

            <div class="col-lg-1 col-md-1 col-sm-1"></div>

            <div class="col-lg-10 col-md-10 col-sm-10">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="940px" Theme="Office2010Silver">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <table>
                                <tr>
                                    <td class="style6">
                                        <asp:Button ID="btn_row_insert" runat="server" Text="Yeni kayıt satırı ekle" CssClass="btn-danger"
                                            Style="height: 35px; margin-bottom: 5px; border-radius: 0px; padding-top: 4px; font-size: 12px; background-color: #6f2398; border: 0px; font-weight: bold; width: 130px;" OnClick="btn_row_insert_Click" />
                                    </td>

                                    <td class="style6" style="padding-left: 1158px;">
                                        <asp:HyperLink ID="lnk_istif_yedek" runat="server" Target="_blank"
                                            NavigateUrl="istif_yedekleri.aspx" Style="color: #271e1f; text-decoration: none; background-color: #e4eefa;">İstif yedekleri için tıklayınız</asp:HyperLink>

                                        <dx:ASPxButton ID="btn_all_row_insert" runat="server" AutoPostBack="False"
                                            ClientInstanceName="btn_kayit" CssClass="btn btn-success" Text="Tüm kayıtları sakla"
                                            Style="height: 35px; margin-bottom: 5px; border-radius: 0px; padding-top: 4px; font-size: 12px; background-color: #ff0000; border: 0px; font-weight: bold; width: 100px;">
                                            <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_istif.PerformCallback('istif_kayit');
                                                             }" />
                                        </dx:ASPxButton>
                                    </td>

                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Height="632px"
                    Width="1448px" Theme="Office2003Blue">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_istif" runat="server" Width="1448px"
                                ClientInstanceName="ASPxCallbackPanel_istif" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_istif_Callback">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <table style="height: 564px">
                                            <tr>
                                                <td class="style6">
                                                    <dx:ASPxGridView ID="Grd_istif" runat="server" AutoGenerateColumns="False" KeyFieldName="Id"
                                                        ClientInstanceName="Grd_istif"
                                                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                        CssPostfix="Office2010Blue" EnableTheming="False"
                                                        Width="1448px">
                                                        <SettingsBehavior AllowSelectByRowClick="True"
                                                            AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" AllowFocusedRow="True" />

                                                        <ClientSideEvents CustomButtonClick="function OnCustomButtonClick(s, e) 
                                                            { 
                                                            if (e.buttonID == 'copy_paste' ) 
                                                            {
                                                             //alert(e.visibleIndex);
                                                             txt_paste.SetText(e.visibleIndex);
                                                             txt_paste.Focus(); 
                                                            }
                                                            if (e.buttonID == 'copy' )
                                                            {  Grd_istif.GetRowValues(e.visibleIndex,'Id;',istif_id_copy); }
                                                            if (e.buttonID == 'delete' )
                                                            {  Grd_istif.GetRowValues(e.visibleIndex,'Id;',istif_id); } 
                                                            }" />

                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Sıra no" FieldName="DOKUMNO"
                                                                VisibleIndex="0" Width="50px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_sirano" runat="server" CssClass="txt_alanlar" Style="width: 50px" onkeypress="return isNumber(event)"
                                                                        Text='<%#Eval("Istif_sirano")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="İstif tarihi"
                                                                VisibleIndex="1" Width="110px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_istif_tarihi" runat="server" CssClass="txt_css" Style="width: 120px"
                                                                        Text='<%#Eval("Dokum_tarihi")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Dökümno"
                                                                VisibleIndex="2" Width="120px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_dokumno" runat="server" CssClass="txt_css" Style="width: 120px" onkeypress="return isNumber(event)"
                                                                        Text='<%#Eval("Dokum_no")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="İstif yeri"
                                                                VisibleIndex="3" Width="70px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_istif_yeri" runat="server" CssClass="txt_alanlar" onkeypress="return isNumber(event)"
                                                                        Text='<%#Eval("Istif_yeri")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="İstif adedi"
                                                                VisibleIndex="4" Width="70px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_istif_adet" runat="server" CssClass="txt_alanlar" onkeypress="return isNumber(event)"
                                                                        Text='<%#Eval("Istif_adet")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Çelik cinsi" FieldName="KTKADET"
                                                                VisibleIndex="5" Width="120px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_celik_cinsi" runat="server" CssClass="txt_css" Style="width: 120px; text-align: left"
                                                                        Text='<%#Eval("Celik_cinsi")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Boy"
                                                                VisibleIndex="6" Width="70px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_boy" runat="server" CssClass="txt_alanlar" onkeypress="return onlyNumbers(event)"
                                                                        Text='<%#Eval("Boy")%>'></asp:TextBox>

                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Ebat"
                                                                VisibleIndex="7" Width="80px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_ebat" runat="server" CssClass="txt_alanlar" onkeypress="return isNumber(event)"
                                                                        Text='<%#Eval("Ebat")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Sipno" FieldName="Sipno"
                                                                VisibleIndex="8" Width="100px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_sipno" runat="server" CssClass="txt_css"
                                                                        Text='<%#Eval("Sipno")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Lot" FieldName="Lot"
                                                                VisibleIndex="9" Width="70px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_lot" runat="server" CssClass="txt_alanlar"
                                                                        Text='<%#Eval("Lot")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Açıklama" FieldName="Açıklama"
                                                                VisibleIndex="11" Width="170px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_aciklama" runat="server" CssClass="txt_css" Style="width: 200px; text-align: left"
                                                                        Text='<%#Eval("Aciklama")%>' TextMode="MultiLine"></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewCommandColumn Caption="Sil"
                                                                VisibleIndex="13" Width="30px">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton ID="delete" Text=" " Image-ToolTip="Satırı sil" Image-Url="../../Images/Sil.png" Image-Width="20PX" Styles-Native="False" Image-AlternateText="Sil">
                                                                        <Image AlternateText="Sil" ToolTip="Satırı sil" Width="20px" Url="../../Images/Sil.png"></Image>
                                                                    </dx:GridViewCommandColumnCustomButton>
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewCommandColumn Caption="Kopyala"
                                                                VisibleIndex="14" Width="50px">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton ID="copy" Text=" " Image-ToolTip="Satırı Kopyala" Image-Width="20PX" Styles-Native="False" Image-AlternateText="Sil">
                                                                        <Image AlternateText="Sil" ToolTip="Satırı Kopyala" Width="20px" Url="../../Images/copy.png"></Image>
                                                                    </dx:GridViewCommandColumnCustomButton>
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewCommandColumn Caption="Yapıştır"
                                                                VisibleIndex="15" Width="42px">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton ID="copy_paste" Text=" " Image-ToolTip="Kopyanılan satırı yapıştır" Image-Url="../../Images/document_check.png" Image-Width="20PX" Styles-Native="False" Image-AlternateText="Sil">
                                                                        <Image AlternateText="Sil" ToolTip="Kopyanılan satırı yapıştır" Width="20px" Url="../../Images/document_check.png"></Image>
                                                                    </dx:GridViewCommandColumnCustomButton>
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Name="Id"
                                                                VisibleIndex="16" Width="1px">
                                                            </dx:GridViewDataTextColumn>

                                                        </Columns>

                                                        <SettingsPager AlwaysShowPager="True" NumericButtonCount="20" PageSize="120"
                                                            Visible="False">
                                                        </SettingsPager>

                                                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="5480" />

                                                        <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                            <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                            </LoadingPanelOnStatusBar>
                                                            <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                            </LoadingPanel>
                                                        </Images>

                                                        <ImagesFilterControl>
                                                            <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                            </LoadingPanel>
                                                        </ImagesFilterControl>

                                                        <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                            CssPostfix="Office2010Blue">
                                                            <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                            </Header>
                                                            <LoadingPanel ImageSpacing="5px">
                                                            </LoadingPanel>
                                                        </Styles>

                                                        <StylesPager>
                                                            <PageNumber ForeColor="#3E4846">
                                                            </PageNumber>
                                                            <Summary ForeColor="#1E395B">
                                                            </Summary>
                                                        </StylesPager>

                                                        <StylesEditors ButtonEditCellSpacing="0">
                                                            <ProgressBar Height="21px">
                                                            </ProgressBar>
                                                        </StylesEditors>
                                                    </dx:ASPxGridView>

                                                    <dxpc:ASPxPopupControl ID="istif_message" runat="server" AllowDragging="True"
                                                        ClientInstanceName="Uretim_message" CloseAction="CloseButton"
                                                        CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                        CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                        HeaderText="MESAJ EKRANI" Height="17px" PopupAnimationType="Fade"
                                                        PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                        PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                        SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="272px" Theme="Aqua">
                                                        <LoadingPanelImage Url="~/App_Themes/Office2003Silver/Web/Loading.gif">
                                                        </LoadingPanelImage>
                                                        <HeaderStyle>
                                                            <Paddings PaddingRight="6px" />
                                                        </HeaderStyle>
                                                        <ContentCollection>
                                                            <dxpc:PopupControlContentControl runat="server">
                                                            </dxpc:PopupControlContentControl>
                                                        </ContentCollection>
                                                    </dxpc:ASPxPopupControl>
                                                </td>

                                            </tr>
                                        </table>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </div>

            <div class="col-lg-1 col-md-1 col-sm-1"></div>

        </div>



        <dx:ASPxTextBox ID="txt_istif_id" ClientInstanceName="txt_istif_id" runat="server" Width="170px" CssClass="txt_dno">
            <ClientSideEvents
                GotFocus="function(s, e) {     ASPxCallbackPanel_istif.PerformCallback('satiri_sil'); }" />
        </dx:ASPxTextBox>
        <dx:ASPxTextBox ID="txt_copy" ClientInstanceName="txt_copy" runat="server" Width="170px" CssClass="txt_dno">
            <ClientSideEvents />
        </dx:ASPxTextBox>
        <dx:ASPxTextBox ID="txt_paste" ClientInstanceName="txt_paste" runat="server" Width="170px" CssClass="txt_dno">
            <ClientSideEvents
                GotFocus="function(s, e) {     ASPxCallbackPanel_istif.PerformCallback('kopyanilan_satiri_yapistir'); }" />
            <ClientSideEvents />
        </dx:ASPxTextBox>

    </form>

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
    <script src="../../assets1/responsive-table/rwd-table.min.js" type="text/javascript"></script>
    <script src="../../js/rapor_js.js" type="text/javascript"></script>

</body>

</html>
