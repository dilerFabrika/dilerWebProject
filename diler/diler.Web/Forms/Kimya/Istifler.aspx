<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Istifler.aspx.cs" Inherits="diler.Web.Forms.Kimya.Istifler" %>

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
        .istif_tablosu:hover {
            /*background:#f5bdbd !important;*/
            background: #f7ac98 !important;
        }

        div.table-responsive .table tbody tr td {
            font-size: 13px !important;
            text-align: center;
            /*padding: 10px;*/
            border: 1px solid #f9d3d3;
        }



        .nav-pills li a {
            border-radius: 4px;
            text-decoration: none;
        }


        .nav-pills > li.active > a, .nav-pills > li.active > a:focus, .nav-pills > li.active > a:hover {
            color: #fff;
            background-color: #ED4517;
            FONT-WEIGHT: BOLD;
        }

        .nav-pills > li {
            FONT-WEIGHT: BOLD;
        }



        .btn, .btnn, .btnn_, .btn_ {
            box-shadow: 0 0 10px 2px #ED4517 inset, 0 0 0 0;
            transition: all 150ms ease-in-out;
        }

            btn:hover, .btnn:hover, .btnn_:hover, .btn_:hover {
                box-shadow: 0 0 3px 3px #ED4517 inset, 0 0 3px 3px #ED4517;
            }

        .istifbtn {
            opacity: 0;
        }
    </style>

</head>

<body>

    <form runat="server">

        <div class="row icon-list">
            <div class="col-sm-4">

                <div class="col-md-3">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="24px"
                        ImageUrl="~/Images//AnaSayfa.png" Width="29px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />

                </div>
            </div>
            <div class="col-sm-4">

                <p style="text-align: center; padding: 10px; font-size: 18px; color: #ED4517; margin-left: 30px; font-weight: bold;">STOK VE İSTİF BAZINDA DÖKÜM TAKİBİ</p>
            </div>
            <div class="col-sm-4">
            </div>
        </div>

        <ul class="nav nav-pills" style="margin-top: 10PX;">
            <li class="active"><a href="#1a" data-toggle="tab">HH 2.İSTİF</a>  </li>
            <li><a href="#2a" data-toggle="tab">HH 1.İSTİF</a>  </li>
            <li><a href="#3a" data-toggle="tab">HH ÇUBUK İSTİF</a> </li>
            <li><a href="#4a" data-toggle="tab">CH 5.İSTİF</a> </li>

        </ul>

        <div class="tab-content clearfix">

            <asp:TextBox ID="txt_istif" Style="opacity: 0" runat="server"></asp:TextBox>

            <div class="tab-pane active" id="1a">

                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                    <table>
                        <tbody style="border: none;">
                            <tr>
                                <td>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_2" runat="server" Text="Kulübe önü İstif(2)" class="btnn"
                                            Style="width: 155px; height: 95px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />

                                        <asp:Button ID="_3" runat="server" Text="Yol tarafı İstif(3)" class="btnn"
                                            Style="width: 155px; height: 95px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />

                                    </div>
                                </td>
                                <td style="width: 85px;">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_17" runat="server" Text="Paket İstif(17)" class="btnn"
                                            Style="width: 180px; height: 40px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />

                                        <span style="font-weight: bold; font-size: 15px;">9.İSTİF</span>

                                        <asp:Button ID="_18" runat="server" Text="Paket İstif(18)" class="btnn"
                                            Style="width: 180px; height: 40px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">10.İSTİF</span>


                                        <asp:Button ID="_19" runat="server" Text="Paket İstif(19)" class="btnn"
                                            Style="width: 180px; height: 40px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">11.İSTİF</span>


                                        <asp:Button ID="_20" runat="server" Text="Paket İstif(20)" class="btnn"
                                            Style="width: 180px; height: 40px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">12.İSTİF</span>

                                    </div>
                                </td>
                                <td>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_9" runat="server" Text="Paket İstif(9)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">1.İSTİF</span>
                                        <asp:Button ID="_10" runat="server" Text="Paket İstif(10)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">2.İSTİF</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_12" runat="server" Text="Paket İstif(12)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">3.İSTİF</span>
                                        <asp:Button ID="_11" runat="server" Text="Paket İstif(11)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">4.İSTİF</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_13" runat="server" Text="Paket İstif(13)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">5.İSTİF</span>
                                        <asp:Button ID="_15" runat="server" Text="Paket İstif(15)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">6.İSTİF</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                        <asp:Button ID="_14" runat="server" Text="Paket İstif(14)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">7.İSTİF</span>
                                        <asp:Button ID="_16" runat="server" Text="Paket İstif(16)" class="btnn"
                                            Style="width: 140px; height: 95px; border: 0px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        <span style="font-weight: bold; font-size: 15px;">8.İSTİF</span>
                                    </div>


                                </td>
                            </tr>

                        </tbody>
                    </table>


                </div>
                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_istif2" runat="server" ClientInstanceName="ASPxCallbackPanel_istif2" OnCallback="ASPxCallbackPanel_istif2_Callback" Theme="Office2010Silver">
                    <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                    <PanelCollection>
                        <dxe:PanelContent runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs8">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-15" class="table table-bordered table-striped istif_takipp">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>İstif sırano</th>
                                                            <th>Döküm tarihi</th>
                                                            <th>Döküm no</th>
                                                            <th>Stok yeri</th>
                                                            <th>İstif yeri<br />
                                                            </th>
                                                            <th>İstif adet</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                            <th>Ebat</th>
                                                            <th>Sipariş no</th>
                                                            <th>Lot</th>
                                                            <th>Açıklama</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_takiphh2" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs4" style="padding-left: 0;">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-14" class="table table-bordered table-striped istif_takipp">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>Yer</th>
                                                            <th>Adet</th>
                                                            <th>Ebat</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_Ozethh2" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </dxe:PanelContent>
                    </PanelCollection>
                </dxe:ASPxCallbackPanel>
                <dx:ASPxButton ID="btn_listehh2" runat="server" AutoPostBack="False"
                    ClientInstanceName="btn_liste2" CssClass="istifbtn"
                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                    CssPostfix="Office2003Blue"
                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                    Text="LİSTELE" Theme="Youthful">
                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_istif2.PerformCallback('istif_hh2');  }"></ClientSideEvents>
                </dx:ASPxButton>


            </div>

            <div class="tab-pane" id="2a">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs3" style="margin-top: 40px">

                        <table>
                            <tbody style="border: none;">
                                <tr>
                                    <td>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                            <asp:Button ID="btn_yol1" runat="server" Text="YOL"
                                                Style="width: 40px; height: 485px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #6e6a6b; color: white;" OnClientClick="return false" />
                                        </div>

                                    </td>
                                    <td>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                            <input type="button" id="_21" value="Aktarma hattı yanı(21)" class="btn"
                                                style="width: 155px; height: 145px; border: 0px; margin-top: 55px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" onclientclick="return false" />
                                            <asp:Button ID="_22" runat="server" Text="Aktarma hattı yanı(22)" class="btn"
                                                Style="width: 155px; height: 145px; border: 0px; margin-top: 55px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                                            <asp:Button ID="Btn_kutuk_aktarma_hatti" runat="server" Text="Kütük aktarma hattı"
                                                Style="width: 180px; height: 75px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                            <asp:Button ID="_23" runat="server" Text="Aktarma hattı Önü(23)" class="btn"
                                                Style="width: 180px; height: 45px; border: 0px; margin-top: 25px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                            <asp:Button ID="_6" runat="server" Text="Köşebaşı istifi(6)" class="btn"
                                                Style="width: 180px; height: 45px; border: 0px; margin-top: 95px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                            <asp:Button ID="_7" runat="server" Text="1.Yığma istifi(7)" class="btn"
                                                Style="width: 180px; height: 45px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                            <asp:Button ID="_1" runat="server" Text="Hidrolik ünitesi arkası(1)" class="btn"
                                                Style="width: 180px; height: 45px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                            <asp:Button ID="_8" runat="server" Text="2.Yığma istifi(8)" class="btn"
                                                Style="width: 180px; height: 45px; border: 0px; margin-top: 15px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                        </div>

                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>


                    <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_istif" runat="server" ClientInstanceName="ASPxCallbackPanel_istif" OnCallback="ASPxCallbackPanel_istif_Callback" Theme="Office2010Silver">
                        <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                        <PanelCollection>
                            <dxe:PanelContent runat="server">

                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs6">

                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-1" class="table table-bordered table-striped istif_takip">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>İstif sırano</th>
                                                            <th>Döküm tarihi</th>
                                                            <th>Döküm no</th>
                                                            <th>Stok yeri</th>
                                                            <th>İstif yeri<br />
                                                            </th>
                                                            <th>İstif adet</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                            <th>Ebat</th>
                                                            <th>Sipariş no</th>
                                                            <th>Lot</th>
                                                            <th>Açıklama</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_takiphh1" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs3" style="padding-left: 0;">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-12" class="table table-bordered table-striped istif_takip">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>Yer</th>
                                                            <th>Adet</th>
                                                            <th>Ebat</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_Ozethh1" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </dxe:PanelContent>
                        </PanelCollection>
                    </dxe:ASPxCallbackPanel>
                    <dx:ASPxButton ID="btn_listehh1" runat="server" AutoPostBack="False"
                        ClientInstanceName="btn_liste1" CssClass="istifbtn"
                        CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                        CssPostfix="Office2003Blue"
                        SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                        Text="LİSTELE" Theme="Youthful">
                        <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_istif.PerformCallback('istif_hh1');  }"></ClientSideEvents>
                    </dx:ASPxButton>

                </div>
            </div>

            <div class="tab-pane" id="3a">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-left: 20px">
                    <table>
                        <tbody style="border: none;">
                            <tr>
                                <td>
                                    <div class="col-lg-1 col-md-1 col-sm-1 col-xs1">
                                        <asp:Button ID="__4" runat="server" Text="Çubuk sahası 1.istif(4)" class="btn_"
                                            Style="width: 155px; height: 45px; border: 0px; margin-top: 25px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />

                                    </div>
                                </td>
                                <td>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2" style="margin-left: 10px">
                                        <asp:Button ID="__5" runat="server" Text="Çubuk sahası 2.istif(5)" class="btn_"
                                            Style="width: 155px; height: 45px; border: 0px; margin-top: 25px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                                    </div>
                                </td>

                            </tr>
                        </tbody>
                    </table>

                </div>

                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_cubukistif" runat="server" ClientInstanceName="ASPxCallbackPanel_cubukistif" OnCallback="ASPxCallbackPanel_cubukistif_Callback" Theme="Office2010Silver">
                    <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                    <PanelCollection>
                        <dxe:PanelContent runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                                <div class="col-lg-7 col-md-7 col-sm-7 col-xs7">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-157" class="table table-bordered table-striped istif_takip_">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>İstif sırano</th>
                                                            <th>Döküm tarihi</th>
                                                            <th>Döküm no</th>
                                                            <th>Stok yeri</th>
                                                            <th>İstif yeri<br />
                                                            </th>
                                                            <th>İstif adet</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                            <th>Ebat</th>
                                                            <th>Sipariş no</th>
                                                            <th>Lot</th>
                                                            <th>Açıklama</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_takipcubuk" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs5" style="padding-left: 0;">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-125" class="table table-bordered table-striped istif_takip_">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>Yer</th>
                                                            <th>Adet</th>
                                                            <th>Ebat</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_Ozetcubuk" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </dxe:PanelContent>
                    </PanelCollection>
                </dxe:ASPxCallbackPanel>

                <dx:ASPxButton ID="btn_liste_cubuk" runat="server" AutoPostBack="False"
                    ClientInstanceName="btn_liste_cubuk" CssClass="istifbtn"
                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                    CssPostfix="Office2003Blue"
                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                    Text="LİSTELE" Theme="Youthful">
                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_cubukistif.PerformCallback('istif_cubuk');  }"></ClientSideEvents>
                </dx:ASPxButton>

            </div>

            <div class="tab-pane" id="4a">


                <div class="col-lg-12 col-md-12 col-sm-12 col-xs12" style="margin-left: 20px">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs2">
                        <asp:Button ID="_50" runat="server" Text="5.İstif" class="btnn_"
                            Style="width: 155px; height: 45px; border: 0px; margin-top: 25px; font-size: 14px; background-color: #dddddd; color: #6e6a6b;" OnClientClick="return false" />
                    </div>
                </div>

                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_chistif" runat="server" ClientInstanceName="ASPxCallbackPanel_chistif" OnCallback="ASPxCallbackPanel_chistif_Callback" Theme="Office2010Silver">
                    <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                    <PanelCollection>
                        <dxe:PanelContent runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                                <div class="col-lg-7 col-md-7 col-sm-7 col-xs7">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies-" class="table table-bordered table-striped istif_takip2_">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>İstif sırano</th>
                                                            <th>Döküm tarihi</th>
                                                            <th>Döküm no</th>
                                                            <th>Stok yeri</th>
                                                            <th>İstif yeri<br />
                                                            </th>
                                                            <th>İstif adet</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                            <th>Ebat</th>
                                                            <th>Sipariş no</th>
                                                            <th>Lot</th>
                                                            <th>Açıklama</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_takipch" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs5" style="padding-left: 0;">
                                    <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                                        <div class="panel-body">
                                            <div class="table-responsive" data-pattern="priority-columns">
                                                <table id="tech-companies" class="table table-bordered table-striped istif_takip2_">
                                                    <thead>
                                                        <tr style="height: 25px;">
                                                            <th>Yer</th>
                                                            <th>Adet</th>
                                                            <th>Ebat</th>
                                                            <th>Çelik cinsi</th>
                                                            <th>Boy</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="ph_istif_Ozetch" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </dxe:PanelContent>
                    </PanelCollection>
                </dxe:ASPxCallbackPanel>

                <dx:ASPxButton ID="btn_liste_ch" runat="server" AutoPostBack="False"
                    ClientInstanceName="btn_liste_ch" CssClass="istifbtn"
                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                    CssPostfix="Office2003Blue"
                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                    Text="LİSTELE" Theme="Youthful">
                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_chistif.PerformCallback('istif_ch');  }"></ClientSideEvents>
                </dx:ASPxButton>

            </div>


        </div>

    </form>

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


    <script type="text/javascript">

        $(document).ready(function () {
            $(".btnn").click(function () {
                var istif_yeri = $(this).attr("id");
                $("#txt_istif").val(istif_yeri);
                $("#btn_listehh2").trigger("click");


            });

        });

        $(document).ready(function () {
            $(".btn").click(function () {
                var istif_yeri = $(this).attr("id");
                $("#txt_istif").val(istif_yeri);
                $("#btn_listehh1").trigger("click");


            });

        });

        $(document).ready(function () {
            $(".btn_").click(function () {
                var istif_yeri = $(this).attr("id");
                $("#txt_istif").val(istif_yeri);
                $("#btn_liste_cubuk").trigger("click");


            });

        });

        $(document).ready(function () {
            $(".btnn_").click(function () {
                var istif_yeri = $(this).attr("id");
                $("#txt_istif").val(istif_yeri);
                $("#btn_liste_ch").trigger("click");


            });

        });

    </script>


</body>

</html>
