<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uretim_ayar.aspx.cs" Inherits="diler.Web.Forms.EndMuh.uretim_ayar" %>


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
            color: #9fa4a9;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 23px;
            border-radius: 1px;
            border: 2px solid #e4effa;
            font-size: 13px;
        }

        div.clear {
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="col-sm-4">
                <div class="col-md-3">
                </div>
            </div>
            <div class="col-sm-4">
                <h3 class="panel-title" style="text-align: center; font-size: 21px; color: #fb3e9c; font-weight: bold;">KÜTÜK SAYISI DÜZENLEME
                </h3>
            </div>
            <div class="col-sm-4"></div>
        </div>
        <div class="row icon-list" style="padding: 5px 0; padding-bottom: 0;">
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4" style="background-color: #000000;">
                <table class="table" style="padding: 0; margin: 0; border: none; background-color: #000000;">
                    <tbody style="border: none;">
                        <tr>
                            <td>
                                <div class="col-md-3 col-sm-3">
                                    <a href="javascript:void(0)" class="tarih_onceki" title="Bir Önceki Gün"><i class="fa fa-long-arrow-left fa-long-arrow-white"></i></a>
                                </div>
                            </td>
                            <td>

                                <asp:TextBox ID="tx_rapor_tarihi" runat="server" TextMode="Date" CssClass="form-control unstyled_date"
                                    AutoPostBack="True" OnTextChanged="tx_rapor_tarihi_TextChanged"></asp:TextBox>

                            </td>
                            <td style="width: 85px;">
                                <div class="col-md-3 col-sm-3">
                                    <a href="javascript:void(0)" class="tarih_sonraki" title="Bir Sonraki Gün"><i class="fa fa-long-arrow-right fa-long-arrow-white"></i></a>
                                </div>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" Style="background-color: #fb3e9c; height: 24px; width: 29px; margin-top: 5px"
                                    ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" /></td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <div class="col-sm-4"></div>
        </div>
        <div class="col-lg-12 col-md-12 col-sm-12" style="margin-top: 10px">

            <div class="col-lg-2 col-md-2 col-sm-2"></div>
            <div class="col-lg-8 col-md-8 col-sm-8">

                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="940px" Theme="Office2010Silver">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <table>
                                <tr>
                                    <td class="style6">
                                        <dx:ASPxButton ID="btn_kayit" runat="server" AutoPostBack="False"
                                            ClientInstanceName="btn_kayit" CssClass="btn btn-success" Text="Kayıt" Style="height: 35px; margin-bottom: 5px; border-radius: 0px; padding-top: 4px; font-size: 12px; background-color: #252525; border: 0px; font-weight: bold; width: 100px;">
                                            <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_URETIM.PerformCallback('uretim_kayit');
                                                             }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Height="632px"
                    Width="1248px" Theme="Office2003Blue">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_URETIM" runat="server" Width="1248px"
                                ClientInstanceName="ASPxCallbackPanel_URETIM" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_URETIM_Callback">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <table style="height: 164px">
                                            <tr>
                                                <td class="style6">
                                                    <dx:ASPxGridView ID="Grd_celikhane_uretim" runat="server" AutoGenerateColumns="False"
                                                        ClientInstanceName="Grd_celikhane_uretim"
                                                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                        CssPostfix="Office2010Blue" EnableTheming="False"
                                                        Width="1248px">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Döküm numarası" FieldName="DOKUMNO"
                                                                VisibleIndex="1" Width="100px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Sıra no" FieldName="SIRANO"
                                                                VisibleIndex="2" Width="100px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Kalite" FieldName="CELIKCINSI"
                                                                VisibleIndex="3" Width="80px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Ebat" FieldName="KTKEBAT"
                                                                VisibleIndex="4" Width="80px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Boy" FieldName="KTKBOY"
                                                                VisibleIndex="5" Width="80px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Kütük Adet(Karışım sayısı Hariç)" FieldName="KTKADET"
                                                                VisibleIndex="6" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Tonaj(Karışım tonajı Hariç)" FieldName="STDKTKTONAJ"
                                                                VisibleIndex="7" Width="100px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Ekleme/Çıkarma" FieldName="degeri"
                                                                ToolTip="DEĞERİ" VisibleIndex="8" Width="100px">
                                                                <DataItemTemplate>
                                                                    <asp:TextBox ID="txt_degeri" runat="server" CssClass="txt_css"
                                                                        Text='<%#Eval("degeri")%>'></asp:TextBox>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="35"
                                                            Visible="False">
                                                        </SettingsPager>
                                                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="980" />
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

                                                    <dxpc:ASPxPopupControl ID="Uretim_message" runat="server" AllowDragging="True"
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
            <div class="col-lg-2 col-md-2 col-sm-2"></div>
        </div>


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

    <%--    <script src="../../assets/responsive-table/rwd-table.min.js" type="text/javascript"></script>--%>
    <script src="../../js/rapor_js.js" type="text/javascript"></script>
</body>
</html>
