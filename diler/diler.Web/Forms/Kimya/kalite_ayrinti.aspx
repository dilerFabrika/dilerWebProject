<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kalite_ayrinti.aspx.cs" Inherits="diler.Web.Forms.Kimya.kalite_ayrinti" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxe" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />


    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
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

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->

    <script src="../../js/modernizr.min.js"></script>
    <style>
        div.table-responsive .table tbody tr td {
            font-size: 14px !important;
            text-align: center;
            padding: 4px;
            border: 1px solid #fddcfc;
        }

        div .table-responsive .table thead tr th {
            line-height: 1em;
            font-weight: bold;
            font-size: 12px !important;
            text-align: center;
            padding: 1px;
            margin: 0;
        }

        div .table-responsive .table thead tr {
            background-color: #dee9ff;
        }

        div .table-responsive .table_genel tbody tr:hover {
            background-color: #dee9ff !important;
        }

        .nav-pills li a {
            border-radius: 4px;
            text-decoration: none;
        }

        .nav-pills > li.active > a, .nav-pills > li.active > a:focus, .nav-pills > li.active > a:hover {
            color: #fff;
            background-color: #ad40ab;
            FONT-WEIGHT: BOLD;
        }

        .nav-pills > li {
            FONT-WEIGHT: BOLD;
        }

        .BtnDizaynn {
            width: 100px;
            height: 35px;
            margin-top: 15px;
            font-size: 12px;
            font-weight: bold;
            background: #ad40ab;
            color: White;
            border: 0px;
        }
    </style>

</head>

<body>
    <form runat="server">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs4">
                <p style="text-align: center; font-size: 18px; color: #ad40ab; font-weight: bold;">KALİTE AYRINTI </p>
            </div>
        </div>

        <div class="col-sm-12" style="margin-top: 2px">

            <div class="col-sm-1"></div>
            <div class="col-sm-9">
                <div class="table-responsive" data-pattern="priority-columns" style="background-color: #add8e6;">

                    <table id="table-responsive" class="table table-bordered table-striped table_arkocagi_genell" style="padding: 0; margin: 0; border: none; background-color: #dee9ff; height: 80px;">
                        <tbody style="border: none;">
                            <tr>
                                <td>Tarih1:
                                    <asp:TextBox ID="txt_tarih1" runat="server" TextMode="Date" CssClass="form-control unstyled_date" class="tarih1" OnTextChanged="txt_tarih1_TextChanged" AutoPostBack="True"></asp:TextBox>

                                </td>

                                <td>Tarih2:
                                    <asp:TextBox ID="txt_tarih2" runat="server" TextMode="Date" CssClass="form-control unstyled_date" class="tarih2" OnTextChanged="txt_tarih1_TextChanged" AutoPostBack="True"></asp:TextBox>

                                </td>

                                <td>Kalite:
                                    <asp:DropDownList ID="cmb_kalite" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False" Style="width: 200px" class="kalite">
                                        <%-- <asp:ListItem Selected="True" Value="All">Tümü</asp:ListItem>--%>
                                    </asp:DropDownList>

                                </td>

                                <td>Döküm numarası:
                                             <asp:TextBox ID="txt_dokum_no" pattern="[0-9]{10}" runat="server" TextMode="Number" CssClass="form-control unstyled_date" Style="width: 200px" class="dokum_no"></asp:TextBox>

                                </td>

                                <td>Sipariş numarası:
                                              <asp:TextBox ID="txt_sipno" runat="server" CssClass="form-control unstyled_date" Style="width: 200px" class="sip_no"></asp:TextBox>

                                </td>

                                <td>Döküm Tipi:
                                    <asp:DropDownList ID="cmb_dokumtipi" runat="server" CssClass="form-control unstyled_date" AutoPostBack="False" Style="width: 200px" class="dokum_tip">
                                        <asp:ListItem Selected="True" Value="Seçiniz">Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="AC">AC</asp:ListItem>
                                        <asp:ListItem Value="YK">YK</asp:ListItem>
                                        <asp:ListItem Value="TK">TK</asp:ListItem>
                                    </asp:DropDownList>

                                </td>

                                <td>

                                    <dx:ASPxButton ID="Btn_liste" runat="server" AutoPostBack="False"
                                        ClientInstanceName="Btn_liste" CssClass="BtnDizaynn"
                                        CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                                        CssPostfix="Office2003Blue"
                                        SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                                        Text="LİSTELE" Theme="Youthful">
                                        <ClientSideEvents Click="function(s, e) {  ASPxCallbackPanel_ark_genel.PerformCallback('ark_ocagi_genel_liste');
                                                                               ASPxCallbackPanel_pota_genel.PerformCallback('pota_ocagi_genel_liste');
                                                                               ASPxCallbackPanel_sdm_genel.PerformCallback('sdm_genel_liste');
                                                                               ASPxCallbackPanel_enerji.PerformCallback('enerji_liste'); 
                                                                               ASPxCallbackPanel_sarfmalzeme.PerformCallback('sarf_liste');
                                                                               ASPxCallbackPanel_hurda.PerformCallback('hurda_liste');
                                                                               ASPxCallbackPanel_ao_alyaj.PerformCallback('ao_alyaj_liste');
                                                                               ASPxCallbackPanel_po_alyaj.PerformCallback('po_alyaj_liste');
                                        }"></ClientSideEvents>
                                    </dx:ASPxButton>

                                </td>

                                <td>
                                    <asp:ImageButton ID="Home_image" runat="server" Style="height: 23px; margin-top: 15px" OnClick="Home_image_Click"
                                        ImageUrl="~/Images//AnaSayfa.png" ToolTip="Ana Sayfa" /></td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-sm-1"></div>

        </div>

        <ul class="nav nav-pills" style="margin-top: 10PX;">
            <li class="active">
                <a href="#1a" data-toggle="tab">Ark Ocağı Genel</a>
            </li>
            <li>
                <a href="#2a" data-toggle="tab">Pota Ocağı Genel</a>
            </li>
            <li><a href="#3a" data-toggle="tab">Sdm Genel</a>
            </li>
            <li><a href="#4a" data-toggle="tab">Enerji Bilgileri</a>
            </li>
            <li><a href="#5a" data-toggle="tab">Sarf Malzeme</a>
            </li>
            <li><a href="#6a" data-toggle="tab">Hurda</a>
            </li>
            <li><a href="#7a" data-toggle="tab">Ark Ocağı Alyaj</a>
            </li>
            <li><a href="#8a" data-toggle="tab">Pota Ocağı Alyaj</a>
            </li>

        </ul>

        <div class="tab-content clearfix" style="margin-top: 5px">

            <div class="tab-pane active" id="1a">

                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_ark_genel" runat="server" ClientInstanceName="ASPxCallbackPanel_ark_genel" OnCallback="ASPxCallbackPanel_ark_genel_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Döküm başlangıç saati
                                                        </th>
                                                        <th>Devirme saati</th>
                                                        <th>Döküm süresi</th>
                                                        <th>Çanak döküm sayısı</th>
                                                        <th>Kapak döküm sayısı</th>
                                                        <th>Yürek döküm sayısı</th>
                                                        <th>Rbt delik sayısı</th>
                                                        <th>Yürek no</th>
                                                        <th>Ted Al/Saati</th>
                                                        <th>Ted tırnak açma saati </th>
                                                        <th>Ted Tb süre</th>
                                                        <th>Enerjili süre</th>
                                                        <th>Enerjisiz süre<br />
                                                        </th>
                                                        <th>Devirme sıcaklık</th>
                                                        <th>Elektrodkodu</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_arkocagi_genel" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>

            </div>

            <div class="tab-pane" id="2a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_pota_genel" runat="server" ClientInstanceName="ASPxCallbackPanel_pota_genel" OnCallback="ASPxCallbackPanel_pota_genel_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Giriş saati
                                                        </th>
                                                        <th>Çıkış saati</th>
                                                        <th>Brüt süre</th>
                                                        <th>Enerjili süre</th>
                                                        <th>Power off time</th>
                                                        <th>Giriş sıcaklık</th>
                                                        <th>Çıkış sıcaklık</th>
                                                        <th>Sıvı çelik son</th>
                                                        <th>Boş pota tonaj</th>
                                                        <th>Sıvı çelik net </th>
                                                        <th>Ek faz1</th>
                                                        <th>Ek faz2</th>
                                                        <th>Ek faz3<br />
                                                        </th>
                                                        <th>Genel açıklama</th>
                                                        <th>Yeniden ısıtma giriş</th>
                                                        <th>Yeniden ısıtma çıkış</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_potaocagi_genel" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>



                <div class="clear"></div>
            </div>

            <div class="tab-pane" id="3a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_sdm_genel" runat="server" ClientInstanceName="ASPxCallbackPanel_sdm_genel" OnCallback="ASPxCallbackPanel_sdm_genel_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Kalıp
                                                            <br />
                                                            döküm sayısı1
                                                        </th>
                                                        <th>Kalıp<br />
                                                            döküm sayısı2</th>
                                                        <th>Kalıp<br />
                                                            döküm sayısı3</th>
                                                        <th>Kalıp<br />
                                                            döküm sayısı4</th>
                                                        <th>Kalıp<br />
                                                            döküm sayısı5</th>
                                                        <th>Kalıp<br />
                                                            döküm sayısı6</th>
                                                        <th>Tandiş<br />
                                                            başlangıç sıcaklık</th>
                                                        <th>Tandiş<br />
                                                            orta sıcaklık</th>
                                                        <th>Tandiş no</th>
                                                        <th>Tandiş<br />
                                                            bindirme sayısı </th>
                                                        <th>Pota<br />
                                                            açma saati</th>
                                                        <th>Pota
                                                            <br />
                                                            kapatma saati</th>

                                                        <th>Net süre</th>
                                                        <th>Pota plaka no</th>
                                                        <th>Pota durumu</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_sdm_genel" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="4a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_enerji" runat="server" ClientInstanceName="ASPxCallbackPanel_enerji" OnCallback="ASPxCallbackPanel_enerji_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Ao Enerji </th>
                                                        <th>Ao tırnak kapatma enerjisi</th>
                                                        <th>Brl doğalgaz</th>
                                                        <th>Rcb brl doğalgaz</th>
                                                        <th>Pc doğalgaz</th>
                                                        <th>Po enerji</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_enerji" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="5a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_sarfmalzeme" runat="server" ClientInstanceName="ASPxCallbackPanel_sarfmalzeme" OnCallback="ASPxCallbackPanel_sarfmalzeme_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş<br />
                                                            numarası</th>
                                                        <th>Ladle
                                                            <br />
                                                            shroud adet </th>
                                                        <th>Ladle shroud
                                                            <br />
                                                            gasket adet</th>
                                                        <th>Tundish 
                                                            <br />
                                                            cmp asidik kg</th>
                                                        <th>Tundish 
                                                            <br />
                                                            cmp bazik kg</th>
                                                        <th>Tundish 
                                                            <br />
                                                            cmp wkg</th>

                                                        <th>Ses shroud adet</th>
                                                        <th>Scorialit 
                                                            <br />
                                                            sphc41181e kg</th>
                                                        <th>Scorialit 
                                                            <br />
                                                            sphc176als 9kg</th>
                                                        <th>Scorialit
                                                            <br />
                                                            sphc 189v3kg</th>
                                                        <th>Ramag 92p 
                                                            <br />
                                                            ramming mass kg</th>
                                                        <th>Natural gas m3</th>
                                                        <th>Melting 
                                                            <br />
                                                            gasketc52 adet</th>
                                                        <th>Scorialit 
                                                            <br />
                                                            sphc 189gm23kg</th>
                                                        <th>Scorialit 
                                                            <br />
                                                            sphc 189e3kg</th>
                                                        <th>Sphc 
                                                            <br />
                                                            189vv1</th>
                                                        <th>Brlo2</th>
                                                        <th>Eltio2</th>
                                                        <th>Rcb refo2</th>
                                                        <th>Rcb brlo2</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_sarfmalzeme" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="6a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_hurda" runat="server" ClientInstanceName="ASPxCallbackPanel_hurda" OnCallback="ASPxCallbackPanel_hurda_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Değirmen</th>
                                                        <th>Hms1</th>
                                                        <th>Hms2</th>
                                                        <th>Piyasa</th>
                                                        <th>Hms1_2</th>
                                                        <th>Pik<br />
                                                        </th>
                                                        <th>Elek</th>
                                                        <th>Skal</th>
                                                        <th>Hbi</th>
                                                        <th>Talas</th>
                                                        <th>Dkp</th>
                                                        <th>Busheling</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_hurda" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="7a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_ao_alyaj" runat="server" ClientInstanceName="ASPxCallbackPanel_ao_alyaj" OnCallback="ASPxCallbackPanel_ao_alyaj_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm tipi</th>
                                                        <th>Sipariş numarası</th>
                                                        <th>Parça kök</th>
                                                        <th>Enjekte Kok Elti</th>
                                                        <th>Enjekte Kok panel</th>
                                                        <th>Parça kireç</th>
                                                        <th>Enjekte
                                                            <br />
                                                            kireç</th>
                                                        <th>Dev al<br />
                                                        </th>
                                                        <th>Dev fesi65</th>
                                                        <th>Dev fesi70</th>
                                                        <th>Dev fesi75</th>
                                                        <th>Dev fesimn60</th>
                                                        <th>Dev fesimn65</th>
                                                        <th>Dev fesimn70</th>
                                                        <th>Dev femn </th>
                                                        <th>Dev femn hcr</th>
                                                        <th>Fesilowal</th>
                                                        <th>Femnlowc</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_ao_alyaj" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="tab-pane" id="8a">
                <div class="tablolar panel panel-border panel-primary" style="border-color: #ffffff;">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_po_alyaj" runat="server" ClientInstanceName="ASPxCallbackPanel_po_alyaj" OnCallback="ASPxCallbackPanel_po_alyaj_Callback" Theme="Office2010Silver">
                            <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                            <PanelCollection>
                                <dxe:PanelContent runat="server">
                                    <div class="panel">
                                        <div class="table-responsive" data-pattern="priority-columns" style="margin-top: 5px">

                                            <table id="" class="table table-bordered table-striped table_genel">
                                                <thead>
                                                    <tr>
                                                        <th>Tarih</th>
                                                        <th>Dökümno</th>
                                                        <th>Kalite</th>
                                                        <th>Döküm
                                                            <br />
                                                            tipi</th>
                                                        <th>Sipariş
                                                            <br />
                                                            numarası</th>
                                                        <th>C</th>

                                                        <th>Cao</th>
                                                        <th>Fesi65</th>
                                                        <th>Fesi70</th>
                                                        <th>Fesi75</th>
                                                        <th>Dev_kireç</th>
                                                        <th>Fesilowal</th>
                                                        <th>Fesimn60</th>

                                                        <th>Fesimn65</th>
                                                        <th>Fesimn70</th>
                                                        <th>Fesimn6030</th>
                                                        <th>Femn</th>
                                                        <th>Femnhcr</th>
                                                        <th>Femnlowc</th>
                                                        <th>Fev</th>

                                                        <th>Al</th>
                                                        <th>Al<br />
                                                            granul</th>
                                                        <th>Casi</th>
                                                        <th>Caf2</th>

                                                        <th>Mgo</th>
                                                        <th>Boksit</th>
                                                        <th>Cafe</th>

                                                        <th>Alwire</th>
                                                        <th>Feti</th>
                                                        <th>Dolamitik<br />
                                                            kireç</th>
                                                        <th>Cac2</th>

                                                        <th>Silis<br />
                                                            kumu</th>
                                                        <th>Feb</th>
                                                        <th>Kolamanit</th>
                                                        <th>Fecr</th>
                                                        <th>S</th>
                                                        <th>Fep</th>
                                                        <th>Nb</th>
                                                        <th>Ca<br />
                                                            solid tel</th>
                                                        <th>Azotsuz<br />
                                                            C</th>
                                                        <th>Al<br />
                                                            curufu</th>


                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="ph_po_alyaj" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                        </div>

                                    </div>
                                </dxe:PanelContent>
                            </PanelCollection>
                        </dxe:ASPxCallbackPanel>

                    </div>

                    <div class="clear"></div>
                </div>
            </div>

            <div class="clear"></div>

        </div>



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
        <!-- Bootstrap core JavaScript
       ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>--%>
        <script src="../../js/jquery-1.11.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../js/notify.js"></script>


    </form>
</body>

</html>
