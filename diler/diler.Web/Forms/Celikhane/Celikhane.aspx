<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Celikhane.aspx.cs" Inherits="diler.Web.celikhanex" %>


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
    <style type="text/css">
        body {
            /*/*background: url(..\diler\diler.Web\Images\kutuk.jpg) no-repeat fixed;*/
            /*background: url(/images/resim1.jpg) 0 0 no-repeat fixed;*/
            /*background:  url(/images/resim3.jpg)50% 50% / cover;*/
        }

        html, body {
            height: 100%;
        }

        .style1 {
            width: 89%;
            height: 824px;
            z-index: 1;
            left: 18px;
            top: 30px;
            position: absolute;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin-left: 0px;
            margin-right: 0;
            margin-top: 0;
            margin-bottom: 0;
            padding: 0;
        }

        .yazi {
            font-size: 10px;
            width: 62px;
        }

        .style2 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin-left: 0px;
            margin-right: 0;
            margin-top: 0;
            margin-bottom: 0;
            padding: 0;
        }

        .style3 {
            height: 20px;
            width: 202px;
            background-color: #e0eee0;
        }

        .style4 {
            width: 202px;
            height: 751px;
        }

        .dxgvControl,
        .dxgvDisabled {
            border: 1px Solid #9F9F9F;
            font: 12px Tahoma;
            background-color: #F2F2F2;
            color: Black;
            cursor: default;
        }

        .dxgvTable {
            -webkit-tap-highlight-color: rgba(0,0,0,0);
        }

        .dxgvTable {
            background-color: White;
            border-width: 0;
            border-collapse: separate !important;
            overflow: hidden;
            color: Black;
        }

        .dxgvHeader {
            cursor: pointer;
            white-space: nowrap;
            padding: 4px 6px 5px;
            border: 1px Solid #9F9F9F;
            background-color: #DCDCDC;
            overflow: hidden;
            font-weight: normal;
            text-align: left;
        }

        body input.dxeEditArea {
            color: #d2d5da;
            text-align: center;
        }

        #ANATAB_ASPxPanel10_ASPxCallbackPanel_DURUSKAYIT_txt_Aciklama_I {
            color: #131313;
        }

        .style8 {
            height: 751px;
        }

        .style6 {
            width: 2px;
        }

        .auto-style1 {
            width: 648px;
            height: 35px;
            background-color: #eef0f1;
        }

        .auto-style2 {
            width: 374px;
            height: 35px;
            background-color: #eef0f1;
        }

        .auto-style3 {
            width: 159px;
            height: 35px;
            background-color: #eef0f1;
        }

        .auto-style7 {
            margin-left: 28px;
            border: 2px solid #88b2f3;
        }

        .auto-style8 {
            height: 35px;
            width: 183px;
            background-color: #eef0f1;
        }

        .auto-style9 {
            width: 183px;
            height: 751px;
        }

        .auto-style11 {
            width: 228px;
        }

        .auto-style16 {
            width: 644px;
        }

        .auto-style17 {
            height: 164px;
            width: 665px;
        }

        .table2 {
            margin-left: 56px;
        }

        .auto-style34 {
            width: 57px;
        }

        .auto-style36 {
            width: 3px;
        }

        .auto-style37 {
            width: 87px;
            height: 47px;
        }

        .auto-style38 {
            width: 3px;
            height: 47px;
        }

        .auto-style39 {
            width: 57px;
            height: 47px;
        }

        .auto-style40 {
            width: 211px;
            height: 47px;
        }

        .auto-style41 {
            width: 87px;
        }

        .auto-style43 {
            height: 47px;
        }

        .auto-style44 {
            width: 211px;
        }

        .auto-style45 {
            width: 91px;
        }

        .paneller {
            width: 1162px;
        }

        .sol_panel {
            width: 580px;
            float: left;
        }

        .sag_panel {
            width: 530px;
            float: left;
        }

        .soll_panel {
            width: 530px;
            float: left;
        }

        .sagg_panel {
            width: 530px;
            float: left;
            margin-top: 50px;
        }

        .durus {
            font-size: 13px;
            opacity: 0;
            -webkit-opacity: 0;
            -moz-opacity: 0;
            -ms-opacity: 0;
            -o-opacity: 0;
        }

        .txt_dno {
            opacity: 0;
            -webkit-opacity: 0;
            -moz-opacity: 0;
            -ms-opacity: 0;
            -o-opacity: 0;
        }

        #btn_Cks {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            opacity: 0.93;
            width: 150px;
            font-size: 0.90rem;
            font-family: font-family:, Nunito, sans-serif;
            margin-left: 10px;
            /*background: #d43f3a;*/
            /*background: #88b2f3;*/
            background: #f08080;
            color: White;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
        }

        .BtnDizaynn {
            width: 100px;
            font-size: 0.90rem;
            background: lightcoral;
            color: White;
            border: none;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
        }

        .BtnDizayn {
            width: 100px;
            font-size: 0.90rem;
            margin-left: 10px;
            background: lightcoral;
            color: White;
            border: none;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
        }

        .Btn_listele {
            height: 36px;
            width: 278px;
            color: rgb(255, 255, 255);
            FONT-WEIGHT: BOLD;
            TEXT-DECORATION-COLOR: LAVENDER;
            font: 12px Tahoma, Geneva, sans-serif;
            BORDER: 1PX SOLID #88b2f3;
            background-color: #88b2f3;
            padding: 3px;
        }

        .GRD_CELIKHANE_DOKUMNO {
            text-align: center;
            font-size: 12px;
        }

        .refrakter_message {
            border-bottom: 1px solid #6f1b1b;
            background: #e85532;
            background-color: white;
            border: 1px solid #e41919;
        }

        .expenses {
            color: #9fa4a9;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 27px;
            border-radius: 1px;
            border: 2px solid #e4effa;
        }

        .txt_css {
            color: #9fa4a9;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 23px;
            border-radius: 1px;
            border: 2px solid #e4effa;
        }

        .expenses_sum {
            color: #9fa4a9;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 27px;
            border-radius: 1px;
            border: 2px solid #e4effa;
        }



        .input-mini {
            color: #352f2f;
            background-color: #e7ebef;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 37px;
            border-radius: 1px;
            border: 2px solid #f7a9a9;
        }

        .sum_toplam_sarj {
            color: #352f2f;
            background-color: #e7ebef;
            FONT-WEIGHT: BOLD;
            text-align: center;
            width: 100px;
            height: 37px;
            border-radius: 1px;
            border: 2px solid #f7a9a9;
        }

        #btn_dokum_cagir {
            TEXT-DECORATION-COLOR: LAVENDER;
            font: 12px Tahoma, Geneva, sans-serif;
            padding: 3px;
            height: 33px;
            width: 105px;
            border: 0;
            background-color: #88b2f3;
            color: lemonchiffon;
            font-weight: bold;
        }

        div.clear {
            clear: both;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <span style="color: #FF0066"></span>
        <script type="text/javascript">
            function secilen_dokum_no(Value) {
                txt_DokumNo.SetText(Value[0]);
                txt_DokumNo.Focus();

                txt_dokumno_durus_liste.SetText(Value[0]);
                txt_dokumno_durus_liste.Focus();
            }

            function secilen_dokum_no_ref_bilgi(Value) {
                tx_refrakter_dokum.SetText(Value[0]);
                tx_refrakter_dokum.Focus();
            }
            function secilen_dokum_noo(Value) {
                txt_dokumno_ref_liste.SetText(Value[0]);
                txt_dokumno_ref_liste.Focus();
            }

            function sira_no_bilgi(Value) {
                txt_Sirano.SetText(Value[0]);
                txt_Sirano.Focus();
            }

            function durus_id_bilgi(Value) {
                var durus_Id = Value[0];
                txt_DurusID.SetText(durus_Id);
                txt_DurusID.Focus();

            }
            function durus_kod_bilgi(Value) {
                var durus_kod = Value[0];
                txt_durusKod.SetText(durus_kod);
                txt_durusKod.Focus();

            }

            $(document).ready(function () {
                $('#btn_Cks').click(function () {
                    //alert("JQuery Running!");
                    window.location.href = "../../Default2.aspx";
                });

            });
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


            function sumall(txt) {
                var $input = $(txt);
                var $row = $input.closest('tr');
                var sum = 0;
                $row.find(".expenses").each(function () {
                    sum += parseInt(this.value) || 0;
                });
                $row.find(".expenses_sum").val(sum);



                $(".expenses").each(function () {
                    $(this).keyup(function () {
                        calculateSum();
                    });
                });


            }

            function calculateSum() {

                var sum = 0;
                //iterate through each textboxes and add the values
                $(".expenses").each(function () {
                    //add only if the value is number
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseInt(this.value);
                    }
                });

                var sumQ = [];
                for (var i = 1; i <= 5; i++) {
                    sumQ[i] = 0;
                    $('td:nth-child(' + (i + 1) + ')').find(".expenses").each(function () {
                        if (!isNaN(this.value) && this.value.length != 0) {
                            sumQ[i] += parseInt(this.value);
                        }

                    });

                    $(".span7").find('input').eq(i - 1).val(sumQ[i]);
                }

                //.toFixed() method will roundoff the final sum to 2 decimal places
                $(".sum_toplam_sarj").val(sum);
            }

        </script>

        <table class="style1">
            <tr>
                <td style="font-size: small;" class="auto-style8">Liste için Tarih Seçimi Yapınız..</td>
                <td style="text-align: right; font-family: Tahoma; font-size: small; color: #88b2f3; font-weight: bold; margin-left: 10px;"
                    class="auto-style2">
                    <asp:Label ID="lbl_secilen_dno" runat="server" Text="SEÇİLEN DÖKÜM NO:"></asp:Label></td>
                <td style="text-align: right;" class="auto-style3">
                    <dxe:ASPxTextBox ID="txt_DokumNo" runat="server"
                        ClientInstanceName="txt_DokumNo" Width="178px" text-align="center"
                        Font-Bold="True" Font-Size="19px" Text="0"
                        Height="35px" CssClass="auto-style7" color="black" ReadOnly="True" onkeypress="return isNumber(event)">
                        <ClientSideEvents
                            GotFocus="function(s, e) {                                        
                                 ASPxCallbackPanel_ALYAJ.PerformCallback('alyaj_listesi');
                                 ASPxCallbackPanel_HURDA.PerformCallback('hurda_listesi');
                                 ASPxCallbackPanel_SARFMALZEMELER.PerformCallback('sarf_liste');                  
	                             ASPxCallbackPanel_GENELBILGILER.PerformCallback('genel_bilgi_listesi');
                                 ASPxCallbackPanel_ENERJI.PerformCallback('enerji_listesi');  
                                 ASPxCallbackPanel_KUTUKLISTE.PerformCallback('uretim_listesi');
                                 ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('uretim_bilgi');  
                                 ASPxCallbackPanel_Send_Ktk.PerformCallback('send_ktk_dokum');  
                                ASPxCallbackPanel_Analiz.PerformCallback('analiz_listesi');    }" />
                    </dxe:ASPxTextBox>


                </td>


                <td style="text-align: left;" class="auto-style1">
                    <dx:ASPxButton ID="btn_dokum_cagir" runat="server" AutoPostBack="False" Text="Döküm Getir" Theme="iOS" Visible="False">
                        <ClientSideEvents Click="function(s, e) {
	  ASPxCallbackPanel_ALYAJ.PerformCallback('alyaj_listesi');
         ASPxCallbackPanel_HURDA.PerformCallback('hurda_listesi');
         ASPxCallbackPanel_SARFMALZEMELER.PerformCallback('sarf_liste');                  
	  ASPxCallbackPanel_GENELBILGILER.PerformCallback('genel_bilgi_listesi');
         ASPxCallbackPanel_ENERJI.PerformCallback('enerji_listesi');  
          ASPxCallbackPanel_KUTUKLISTE.PerformCallback('uretim_listesi');
          ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('uretim_bilgi');  
          ASPxCallbackPanel_Send_Ktk.PerformCallback('send_ktk_dokum');  
          ASPxCallbackPanel_Analiz.PerformCallback('analiz_listesi');}" />
                    </dx:ASPxButton>


                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <dx:ASPxDateEdit ID="Txt_tarih" runat="server" Height="30px" Width="278px" Style="font-weight: bold;"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        DisplayFormatString="dd/MM/yyyy"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Spacing="0" Theme="Office2010Silver">
                        <ButtonStyle Width="13px">
                        </ButtonStyle>
                        <CalendarProperties>
                            <HeaderStyle Spacing="1px" />
                        </CalendarProperties>
                    </dx:ASPxDateEdit>
                    <dx:ASPxButton ID="Btn_listele" runat="server"
                        AutoPostBack="False" Text="LİSTELE"
                        Height="36px"
                        Width="278px" CssClass="Btn_listele" Style="color: white; font-size: 14px; font-weight: bold; font-family: font-family, Nunito, sans-serif" Theme="iOS">
                        <ClientSideEvents Click="function(s, e) {
        GRD_CELIKHANE_DOKUMNO.PerformCallback('dokum_listele'); 
   ASPxCallbackPanel_REFRAKTERLISTE.PerformCallback('refrakter_liste');
   ASPxCallbackPanel_Analiz.PerformCallback('analiz_listesi');}" />
                    </dx:ASPxButton>
                    <dx:ASPxGridView ID="GRD_CELIKHANE_DOKUMNO" runat="server"
                        AutoGenerateColumns="False" ClientInstanceName="GRD_CELIKHANE_DOKUMNO"
                        KeyFieldName="DOKUMNO" OnCustomCallback="GRD_CELIKHANE_DOKUMNO_CustomCallback" CssClass="GRD_CELIKHANE_DOKUMNO">
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"
                            AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" />
                        <SettingsPager AlwaysShowPager="True" NumericButtonCount="50" PageSize="50">
                        </SettingsPager>
                        <ClientSideEvents RowClick="function(s, e) { GRD_CELIKHANE_DOKUMNO.GetRowValues(e.visibleIndex,'DOKUMNO;',secilen_dokum_no);
                                                                     GRD_CELIKHANE_DOKUMNO.GetRowValues(e.visibleIndex,'DOKUMNO;',secilen_dokum_no_ref_bilgi);
                                                                     GRD_CELIKHANE_DOKUMNO.GetRowValues(e.visibleIndex,'DOKUMNO;',secilen_dokum_noo); }" />
                        <SettingsLoadingPanel ShowImage="False" Text="" />
                        <Columns>
                            <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="DOKUMNO" Caption="Döküm no">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="durum" Caption="Durum">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="610" />
                        <Styles>
                            <FocusedRow BackColor="#88b2f3">
                            </FocusedRow>
                        </Styles>
                    </dx:ASPxGridView>
                    &nbsp;</td>
                <td colspan="3" class="style8">
                    <dx:ASPxPageControl ID="ANATAB" runat="server" ActiveTabIndex="0" Height="719px"
                        Width="960px" CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css" CssPostfix="Office2003Blue"
                        EnableClientSideAPI="True"
                        SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css" EnableTheming="True" Theme="Office2010Silver">
                        <TabPages>
                            <%-- ÜRETİM--%>
                            <dx:TabPage Text="ÜRETİM">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div style="background-color: #f1f1f1; padding-left: 12px; padding-bottom: 25px;">
                                            <dxe:ASPxPanel ID="ASPxPanel13" runat="server" Style="margin-top: 21px;" Theme="Office2010Silver" Width="1282px">
                                                <PanelCollection>
                                                    <dxe:PanelContent runat="server">
                                                        <table>
                                                            <tr>
                                                                <td class="auto-style45">
                                                                    <dx:ASPxButton ID="Btn_Uretimsakla" runat="server" AutoPostBack="False" Text="KAYIT" CssClass="BtnDizayn">
                                                                        <ClientSideEvents Click="function(s, e) {
	            ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('uretim_sakla');
                ASPxCallbackPanel_KUTUKLISTE.PerformCallback('uretim_listesi');}" />
                                                                        <Image Url="~/Images/Sakla.png">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="Btn_dokumac" runat="server" AutoPostBack="False" CssClass="BtnDizayn" Text="DÖKÜM AÇ" Height="41px">
                                                                        <ClientSideEvents Click="function(s, e) {  
                                                                            ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('dokum_ac');
                                                                            GRD_CELIKHANE_DOKUMNO.PerformCallback('dokum_listele');}" />
                                                                    </dx:ASPxButton>
                                                                </td>

                                                                <td>
                                                                    <br />
                                                                    <dx:ASPxButton ID="Btn_dkmsira_delete" runat="server" AutoPostBack="False" CssClass="BtnDizayn"
                                                                        ClientInstanceName="Btn_dkmsira_delete"
                                                                        Text="DÖKÜM SİL" ImageSpacing="10px" Theme="Youthful" Width="80px" Height="41px" Style="margin-left: 30px">
                                                                        <ClientSideEvents Click="function(s, e) {  
                                                                            ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('dokum_sirasi_sil');
                                                                            ASPxCallbackPanel_KUTUKLISTE.PerformCallback('uretim_listesi');
                                                                            GRD_CELIKHANE_DOKUMNO.PerformCallback('dokum_listele');}" />
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                                <td>
                                                                    <br />
                                                                    <dx:ASPxButton ID="btn_dokum_kapat" runat="server" AutoPostBack="False"
                                                                        ClientInstanceName="dokumKapat"
                                                                        Text="DÖKÜM KAPAT" Theme="Youthful" Width="70px" CssClass="BtnDizayn" Height="41px" Style="margin-left: 30px" Visible="false">
                                                                        <ClientSideEvents Click="function(s, e) {  ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('dokum_kapat'); 
                                                                                                                    GRD_CELIKHANE_DOKUMNO.PerformCallback('dokum_listele');}" />
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dxe:PanelContent>
                                                </PanelCollection>
                                            </dxe:ASPxPanel>
                                            <dxe:ASPxPanel ID="ASPxPanel14" runat="server" Style="margin-top: 31px;" Theme="Office2010Silver" Width="800px">
                                                <PanelCollection>
                                                    <dxe:PanelContent runat="server">
                                                        <div class="paneller">
                                                            <div class="sol_panel">
                                                                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_KUTUKKAYIT" runat="server" ClientInstanceName="ASPxCallbackPanel_KUTUKKAYIT" OnCallback="ASPxCallbackPanel_KUTUKKAYIT_Callback" Theme="Office2010Silver">
                                                                    <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                                                                    <PanelCollection>
                                                                        <dxe:PanelContent runat="server">
                                                                            <table class="auto-style16">
                                                                                <tr>
                                                                                    <td class="auto-style41">Seçilen döküm tarihi:</td>
                                                                                    <td class="auto-style36" style="margin-left: 10px;">
                                                                                        <dxe:ASPxTextBox ID="tx_dokum_tarihi" runat="server" CssPostfix="RedWine" Height="25px" Style="font-size: 13px; margin-bottom: 6px" Theme="Office2010Silver" Width="120px" ReadOnly="True">
                                                                                        </dxe:ASPxTextBox>

                                                                                    </td>
                                                                                    <td class="auto-style34">Tandis/bindirme:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_tandis_bindirme" runat="server" ClientInstanceName="txt_tandis_bindirme" CssPostfix="RedWine" Height="30px" Style="font-size: 14px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style41">Çelik Cinsi:</td>
                                                                                    <td class="auto-style36" style="margin-left: 10px;">
                                                                                        <dxe:ASPxComboBox ID="Cmb_Celikcinsii" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                            <ClientSideEvents ValueChanged="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('dokumtipGetir'); }" />
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Döküm Tip:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_dkmtip" runat="server" ClientInstanceName="dokumTip" CssPostfix="RedWine" Height="30px" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" ReadOnly="True">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style41">ÖZEL KOD:</td>
                                                                                    <td class="auto-style36" style="margin-left: 10px;">
                                                                                        <dxe:ASPxTextBox ID="txt_OzelKod" runat="server" ClientInstanceName="Ozel_kod" CssPostfix="RedWine" Height="30px" Style="font-weight: bold; font-size: 14px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Vardiya:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dx:ASPxComboBox ID="Cmb_vrd" runat="server" ClientInstanceName="Cmb_vrd" ValueType="System.String" Height="30px" Style="font-size: 12px" Theme="Office2010Silver" Width="120px">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Text="1" Value="0" />
                                                                                                <dxe:ListEditItem Text="2" Value="1" />
                                                                                                <dxe:ListEditItem Text="3" Value="2" />
                                                                                            </Items>
                                                                                        </dx:ASPxComboBox>
                                                                                        <%-- <dxe:ASPxTextBox ID="txt_vrd" runat="server" ClientInstanceName="vrd" CssPostfix="RedWine" Height="30px" Style="font-weight: bold; font-size: 15px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style37">Sıra No:</td>
                                                                                    <td class="auto-style38">
                                                                                        <div style="width: 120px; padding: 0; margin: 0;">
                                                                                            <div style="width: 70px; float: left;">
                                                                                                <dxe:ASPxButton ID="btn_yeniSira" runat="server" Text="YENİ SIRA" Theme="Youthful" Height="30px" Paddings-Padding="0" AutoPostBack="false">
                                                                                                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('dokum_yeni_sira'); }" />
                                                                                                    <Paddings Padding="0px"></Paddings>
                                                                                                </dxe:ASPxButton>
                                                                                            </div>
                                                                                            <div style="width: 30px; float: left; margin-left: 20px; display: block;">
                                                                                                <dxe:ASPxTextBox ID="txt_Sirano" runat="server" ClientInstanceName="txt_Sirano" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-weight: bold; font-size: 14px" Theme="Office2010Silver" Width="30px" ReadOnly="True">
                                                                                                    <ClientSideEvents GotFocus="function(s, e) {   ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('uretim_secilen_getir'); }" />
                                                                                                </dxe:ASPxTextBox>
                                                                                            </div>
                                                                                            <div style="clear: both"></div>
                                                                                        </div>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style43">Standart Kütük Sayısı:</td>
                                                                                    <td class="auto-style44">
                                                                                        <div>
                                                                                            <div style="width: 60px; float: left;">
                                                                                                <dxe:ASPxTextBox ID="txt_KutukSayisi" runat="server" ClientInstanceName="txt_KutukSayisi" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="50px" onkeypress="return isNumber(event)">
                                                                                                    <ClientSideEvents KeyUp="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('standartKutukTonajiGetir'); }" />
                                                                                                </dxe:ASPxTextBox>
                                                                                            </div>
                                                                                            <div style="width: 60px; float: left;">
                                                                                                <dx:ASPxLabel ID="lbl_kutukTonaj" runat="server" Style="color: lightcoral" Text="" ClientInstanceName="lbl_kutukTonaj"></dx:ASPxLabel>
                                                                                                <%--  <asp:Label ID="lbl_kutukTonaj" runat="server" Style="color: lightcoral" Text="Kütük Tonaj"></asp:Label>--%>
                                                                                            </div>
                                                                                            <div class="clear"></div>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style41">Kütük Boyu:</td>
                                                                                    <td class="auto-style36" style="margin-left: 10px;">
                                                                                        <dxe:ASPxComboBox ID="Cmb_Kutukboy" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                            <ClientSideEvents ValueChanged="function(s, e) {  ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('katsayiGetir'); }" />
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Standart Kütük Tonajı:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="Txt_KutukTonaj" runat="server" ClientInstanceName="dokum_no" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return onlyNumbers();" ReadOnly="True">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="vertical-align: top">
                                                                                    <td class="auto-style37">Kütük Ebat:</td>
                                                                                    <td class="auto-style38" style="margin-left: 10px;">
                                                                                        <dxe:ASPxComboBox ID="Cmb_KutukEbat" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                            <ClientSideEvents ValueChanged="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('katsayiGetir'); }" />
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style39">Sarı Kütük Sayısı:</td>
                                                                                    <td class="auto-style40">
                                                                                        <dxe:ASPxTextBox ID="txt_SarikutukSayisi" runat="server" ClientInstanceName="txt_SarikutukSayisi" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Theme="Office2010Silver" Style="font-size: 14px" Width="120px" onkeypress="return isNumber(event)">
                                                                                            <ClientSideEvents KeyUp="function(s, e) {ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('sariKutukTonajiGetir'); }" />
                                                                                        </dxe:ASPxTextBox>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="vertical-align: top">
                                                                                    <td class="auto-style37">Üretimden Sapma Nedeni:</td>
                                                                                    <td class="auto-style38" style="margin-left: 10px; margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="Cmb_sapmanedeni" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Selected="True" Value="" />
                                                                                                <dxe:ListEditItem Text="Hammadde Kaynaklı" Value="0" />
                                                                                                <dxe:ListEditItem Text="İşletme Kaynaklı" Value="1" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(Planlama)" Value="2" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(HH Verim)" Value="3" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(StDışı- Urt Sapma)" Value="4" />
                                                                                                <dxe:ListEditItem Text="Kalite Değişimi(Planlama)" Value="5" />
                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                    </td>
                                                                                    <td class="auto-style39">Sarı kütük Tonajı:</td>
                                                                                    <td class="auto-style40">
                                                                                        <dxe:ASPxTextBox ID="txt_SarikutukTonaji" runat="server" ClientInstanceName="dokum_vrd" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return onlyNumbers();" ReadOnly="True">
                                                                                        </dxe:ASPxTextBox>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="vertical-align: top">
                                                                                    <td class="auto-style41">Üretim Sapma Kimyasalı:</td>
                                                                                    <td class="auto-style36" style="margin-left: 10px; margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="Cmb_sapmaKimyasali" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Selected="True" Value="" />
                                                                                                <dxe:ListEditItem Text="C" Value="0" />
                                                                                                <dxe:ListEditItem Text="Si" Value="1" />
                                                                                                <dxe:ListEditItem Text="S" Value="2" />
                                                                                                <dxe:ListEditItem Text="P" Value="3" />
                                                                                                <dxe:ListEditItem Text="Mn" Value="4" />
                                                                                                <dxe:ListEditItem Text="Ni" Value="5" />
                                                                                                <dxe:ListEditItem Text="Cr" Value="6" />
                                                                                                <dxe:ListEditItem Text="Cu" Value="7" />
                                                                                                <dxe:ListEditItem Text="Sn" Value="8" />
                                                                                                <dxe:ListEditItem Text="Al" Value="9" />
                                                                                                <dxe:ListEditItem Text="V" Value="10" />
                                                                                                <dxe:ListEditItem Text="O2" Value="11" />
                                                                                                <dxe:ListEditItem Text="Mo" Value="12" />
                                                                                                <dxe:ListEditItem Text="Ti" Value="13" />
                                                                                                <dxe:ListEditItem Text="N" Value="14" />
                                                                                                <dxe:ListEditItem Text="Pb" Value="15" />
                                                                                                <dxe:ListEditItem Text="Ca" Value="16" />
                                                                                                <dxe:ListEditItem Text="B" Value="17" />
                                                                                                <dxe:ListEditItem Text="Nb" Value="18" />
                                                                                                <dxe:ListEditItem Text="Zr" Value="19" />
                                                                                                <dxe:ListEditItem Text="Ceq" Value="20" />
                                                                                                <dxe:ListEditItem Text="Ce" Value="21" />

                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Sarı Kütük Çelik Cinsi:</td>
                                                                                    <td class="auto-style44" style="margin-left: 10px; margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="cmb_sarikutukCelikcinsi" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Text="SARI" Value="0" />
                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="vertical-align: top">
                                                                                    <td class="auto-style41">Standart Dışı Nedeni:</td>
                                                                                    <td class="auto-style36" style="margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="cmb_standartDisinedeni" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Selected="True" Value="" />
                                                                                                <dxe:ListEditItem Text="Hammadde Kaynaklı" Value="0" />
                                                                                                <dxe:ListEditItem Text="İşletme Kaynaklı" Value="1" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(Planlama)" Value="2" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(HH Verim)" Value="3" />
                                                                                                <dxe:ListEditItem Text="Kütük Yetersiz(StDışı-UrtSapma)" Value="4" />
                                                                                                <dxe:ListEditItem Text="Kalite Değişimi(Planlama)" Value="5" />
                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Standart Karışım Sayısı:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_standartKarisimSayisi" runat="server" ClientInstanceName="dokum_no" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                            <ClientSideEvents KeyUp="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('stdKarisimTonajiGetir'); }" />
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="vertical-align: top">
                                                                                    <td class="auto-style41">Standart Dışı Kimyasalı:</td>
                                                                                    <td style="margin-left: 10px; margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="cmb_standartDisiKimyasali" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Selected="True" Value="" />
                                                                                                <dxe:ListEditItem Text="C" Value="0" />
                                                                                                <dxe:ListEditItem Text="Si" Value="1" />
                                                                                                <dxe:ListEditItem Text="S" Value="2" />
                                                                                                <dxe:ListEditItem Text="P" Value="3" />
                                                                                                <dxe:ListEditItem Text="Mn" Value="4" />
                                                                                                <dxe:ListEditItem Text="Ni" Value="5" />
                                                                                                <dxe:ListEditItem Text="Cr" Value="6" />
                                                                                                <dxe:ListEditItem Text="Cu" Value="7" />
                                                                                                <dxe:ListEditItem Text="Sn" Value="8" />
                                                                                                <dxe:ListEditItem Text="Al" Value="9" />
                                                                                                <dxe:ListEditItem Text="V" Value="10" />
                                                                                                <dxe:ListEditItem Text="O2" Value="11" />
                                                                                                <dxe:ListEditItem Text="Mo" Value="12" />
                                                                                                <dxe:ListEditItem Text="Ti" Value="13" />
                                                                                                <dxe:ListEditItem Text="N" Value="14" />
                                                                                                <dxe:ListEditItem Text="Pb" Value="15" />
                                                                                                <dxe:ListEditItem Text="Ca" Value="16" />
                                                                                                <dxe:ListEditItem Text="B" Value="17" />
                                                                                                <dxe:ListEditItem Text="Nb" Value="18" />
                                                                                                <dxe:ListEditItem Text="Zr" Value="19" />
                                                                                                <dxe:ListEditItem Text="Ceq" Value="20" />
                                                                                                <dxe:ListEditItem Text="Ce" Value="21" />
                                                                                                

                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td class="auto-style34">Standart Karışım Tonajı:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_karisimTonaji" runat="server" ClientInstanceName="txt_karisimTonaji" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return onlyNumbers();" ReadOnly="True">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style41">Kütüğün Gideceği Yer:</td>
                                                                                    <td style="margin-left: 10px; margin-top: 15px">
                                                                                        <dxe:ASPxComboBox ID="cmb_KutukGidecekYer" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" ClientInstanceName="cmb_KutukGidecekYer" Theme="Office2010Silver">
                                                                                            <Items>
                                                                                                <dxe:ListEditItem Text="Haddehane" Value="0" />
                                                                                                <dxe:ListEditItem Text="İç Piyasa" Value="1" />
                                                                                                <dxe:ListEditItem Text="Filmaşin" Value="2" />
                                                                                                <dxe:ListEditItem Text="Kutuk Ihracat" Value="3" />
                                                                                            </Items>
                                                                                        </dxe:ASPxComboBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td>Sipariş No:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_Siparisno" runat="server" ClientInstanceName="txt_Siparisno" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Radyo Aktivite Alanı:</td>
                                                                                    <td class="auto-style41">
                                                                                        <dxe:ASPxTextBox ID="tx_radyoaktivite" runat="server" ClientInstanceName="tx_radyoaktivite" CssPostfix="RedWine" Height="30px" Style="font-size: 14px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td>Eğrilen kütük:</td>
                                                                                    <td class="auto-style44">
                                                                                        <dxe:ASPxTextBox ID="txt_egri_kutuk_sayisi" runat="server" ClientInstanceName="txt_egri_kutuk_sayisi" onkeypress="return isNumber(event)"
                                                                                            CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:TextBox ID="txt_Genelaciklama" runat="server" placeholder="Genel Açıklama" Style="height: 50px; width: 497px; text-align: center;" ClientInstanceName="txt_Genelaciklama"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <dxe:ASPxPopupControl ID="KUTUK_MSG" runat="server" AllowDragging="True" AutoUpdatePosition="True" ClientInstanceName="KUTUK_MSG" CloseAction="CloseButton" CloseOnEscape="True" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False" HeaderText="MESAJ EKRANI" Height="30px" Modal="True" PopupAnimationType="Fade" PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40" PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40" SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Youthful" Width="252px">
                                                                                <HeaderStyle>
                                                                                    <Paddings PaddingRight="6px" />
                                                                                </HeaderStyle>
                                                                                <ContentCollection>
                                                                                    <dxe:PopupControlContentControl runat="server">
                                                                                    </dxe:PopupControlContentControl>
                                                                                </ContentCollection>
                                                                            </dxe:ASPxPopupControl>
                                                                        </dxe:PanelContent>
                                                                    </PanelCollection>
                                                                </dxe:ASPxCallbackPanel>
                                                            </div>
                                                            <div class="sag_panel">
                                                                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_KUTUKLISTE" runat="server" ClientInstanceName="ASPxCallbackPanel_KUTUKLISTE" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_KUTUKLISTE_Callback">
                                                                    <PanelCollection>
                                                                        <dxe:PanelContent runat="server">
                                                                            <dxe:ASPxGridView ID="GRD_KUTUKURETIM" runat="server" AutoGenerateColumns="False" ClientInstanceName="GRD_KUTUKURETIM" EnableTheming="False" KeyFieldName="SIRANO" Width="581px">
                                                                                <ClientSideEvents RowClick="function(s, e) {
                                                                                     GRD_KUTUKURETIM.GetRowValues(e.visibleIndex,'SIRANO;',sira_no_bilgi);  }" />
                                                                                <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25" Visible="False">
                                                                                </SettingsPager>
                                                                                <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="180" />
                                                                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" />
                                                                                <SettingsLoadingPanel ShowImage="False" Text="" />
                                                                                <StylesEditors ButtonEditCellSpacing="0">
                                                                                    <ProgressBar Height="21px">
                                                                                    </ProgressBar>
                                                                                </StylesEditors>
                                                                                <StylesPager>
                                                                                    <PageNumber ForeColor="#3E4846">
                                                                                    </PageNumber>
                                                                                    <Summary ForeColor="#1E395B">
                                                                                    </Summary>
                                                                                </StylesPager>
                                                                                <Columns>
                                                                                    <dxe:GridViewDataTextColumn Caption="SIRANO" FieldName="SIRANO" Name="SIRANO" ShowInCustomizationForm="True" VisibleIndex="2" Width="58px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="DÖKÜMNO" FieldName="DOKUMNO" Name="DOKUMNO" ShowInCustomizationForm="True" VisibleIndex="3" Width="72px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="KALİTE" FieldName="CELIKCINSI" Name="CELIKCINSI" ShowInCustomizationForm="True" VisibleIndex="4" Width="79px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="BOY" FieldName="KTKBOY" Name="KTKBOY" ShowInCustomizationForm="True" VisibleIndex="5" Width="50px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="EBAT" FieldName="KTKEBAT" Name="KTKEBAT" ShowInCustomizationForm="True" VisibleIndex="6" Width="50px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="KTKADET" FieldName="KTKADET" Name="KTKADET" ShowInCustomizationForm="True" VisibleIndex="7" Width="64px">
                                                                                    </dxe:GridViewDataTextColumn>

                                                                                    <dxe:GridViewDataTextColumn Caption="STDKTKTONAJ" FieldName="STDKTKTONAJ" Name="STDKTKTONAJ" ShowInCustomizationForm="True" VisibleIndex="8" Width="93px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="KARIŞIMSAYISI" FieldName="KARISIMSAYISI" Name="KARISIMSAYISI" ShowInCustomizationForm="True" VisibleIndex="9" Width="96px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="KARIŞIMTONAJ" FieldName="KARISIMTONAJ" Name="KARISIMTONAJ" ShowInCustomizationForm="True" VisibleIndex="10" Width="94px">
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                </Columns>
                                                                                <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                                    <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                                                    </Header>
                                                                                </Styles>
                                                                            </dxe:ASPxGridView>
                                                                            <br />
                                                                            <table>
                                                                                <tr>
                                                                                    <td style="font-size: 11px; font-weight: BOLD; color: #f08080;">
                                                                                        <p>Toplam Tonaj :</p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="Txt_KutukTonajii" runat="server" Style="color: #f08080; text-align: center; width: 190px; height: 35px; border-radius: 1px; border: 2px solid #e4effa; margin-left: 15px; font-weight: bold;" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dxe:PanelContent>
                                                                    </PanelCollection>
                                                                </dxe:ASPxCallbackPanel>
                                                                <br />
                                                                <div class="clear"></div>
                                                            </div>
                                                            <div class="sag_panel">
                                                                <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_Send_Ktk" runat="server" ClientInstanceName="ASPxCallbackPanel_Send_Ktk" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_Send_Ktk_Callback">
                                                                    <SettingsLoadingPanel ShowImage="False" Text=""></SettingsLoadingPanel>
                                                                    <PanelCollection>
                                                                        <dxe:PanelContent runat="server">
                                                                            <dxe:ASPxGridView ID="GRD_Send_Ktk" runat="server" AutoGenerateColumns="False" ClientInstanceName="GRD_Send_Ktk" EnableTheming="False" KeyFieldName="DOKUMNO" Width="551px">
                                                                                <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25" Visible="False">
                                                                                </SettingsPager>
                                                                                <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="180" />
                                                                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" />

                                                                                <SettingsLoadingPanel ShowImage="False"></SettingsLoadingPanel>

                                                                                <StylesEditors ButtonEditCellSpacing="0">
                                                                                    <ProgressBar Height="21px">
                                                                                    </ProgressBar>
                                                                                </StylesEditors>
                                                                                <StylesPager>
                                                                                    <PageNumber ForeColor="#3E4846">
                                                                                    </PageNumber>
                                                                                    <Summary ForeColor="#1E395B">
                                                                                    </Summary>
                                                                                </StylesPager>
                                                                                <Columns>
                                                                                    <dxe:GridViewDataTextColumn Caption="DÖKÜM NO" FieldName="DOKUMNO" Name="DOKUMNO" ShowInCustomizationForm="True" VisibleIndex="2" Width="40px">
                                                                                        <CellStyle BackColor="#EAD0D1">
                                                                                        </CellStyle>
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="GİDEN KÜTÜK" FieldName="GIDENKUTUK" Name="GIDENKUTUK" ShowInCustomizationForm="True" VisibleIndex="3" Width="47px">
                                                                                        <BatchEditModifiedCellStyle HorizontalAlign="Center">
                                                                                        </BatchEditModifiedCellStyle>
                                                                                        <CellStyle BackColor="#D2E0C9" CssClass="giden_kutuk">
                                                                                        </CellStyle>
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="GÖNDERİLECEK KÜTÜK SAYISI" FieldName="GKTKSAYISI" Name="GKTKSAYISI" ShowInCustomizationForm="True" ToolTip="GKTKSAYISI" VisibleIndex="4" Width="100px">
                                                                                        <DataItemTemplate>
                                                                                            <asp:TextBox ID="GKTKSAYISI" runat="server" CssClass="txt_css" Text='<%#Eval("GKTKSAYISI")%>' Width="180px" Height="25px" onkeypress="return isNumber(event)"></asp:TextBox>
                                                                                        </DataItemTemplate>
                                                                                        <CellStyle BackColor="#D2E0C9">
                                                                                        </CellStyle>
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                    <dxe:GridViewDataTextColumn Caption="TRANSFER" FieldName="TRANSFER" Name="TRANSFER" ShowInCustomizationForm="True" VisibleIndex="5" Width="85px">
                                                                                        <DataItemTemplate>
                                                                                            <dx:ASPxButton ID="btn_Transfer" runat="server" Text="SICAK ŞARJA GÖNDER" CommandName="btn_Transfer" HoverStyle-BackColor="#FF3300" AutoPostBack="False" Style="width: 150px; border-radius: 4px;">
                                                                                                <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_KUTUKKAYIT.PerformCallback('transfer');
                                                                                                                                      ASPxCallbackPanel_Send_Ktk.PerformCallback('send_ktk_dokum');}" />

                                                                                            </dx:ASPxButton>
                                                                                        </DataItemTemplate>
                                                                                        <CellStyle BackColor="#B6D8E2">
                                                                                        </CellStyle>
                                                                                    </dxe:GridViewDataTextColumn>
                                                                                </Columns>
                                                                                <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                                    <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                                                    </Header>
                                                                                </Styles>
                                                                                <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                </Images>
                                                                            </dxe:ASPxGridView>
                                                                        </dxe:PanelContent>
                                                                    </PanelCollection>
                                                                </dxe:ASPxCallbackPanel>
                                                                <div class="clear"></div>
                                                            </div>
                                                            <div class="clear"></div>
                                                        </div>
                                                    </dxe:PanelContent>
                                                </PanelCollection>
                                            </dxe:ASPxPanel>
                                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- GENEL BİLGİ--%>
                            <dx:TabPage Text="GENEL BİLGİLER">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel5" runat="server" Width="1142px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_genelbilgisakla" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_genelbilgisakla"
                                                                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css" CssClass="BtnDizaynn"
                                                                    CssPostfix="Office2003Blue"
                                                                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css"
                                                                    Text="SAKLA" ImageSpacing="10px" Theme="Youthful" Width="96px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_GENELBILGILER.PerformCallback('genel_bilgi_sakla'); }" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel6" runat="server" Height="532px"
                                            Width="942px">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_GENELBILGILER" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_GENELBILGILER" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_GENELBILGILER_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table class="auto-style17">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server"
                                                                                ClientInstanceName="Panel_GENELBILGI_AO"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ARK OCAĞI GENEL BİLGİLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Office2010Silver" CssClass="auto-style13">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_GENELBILGILER_AO" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="  GRD_CH_GENELBILGILER_AO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="344px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM" VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri7" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="GENELBILGI_MSG" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="GENELBILGI_MSG" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server"
                                                                                ClientInstanceName="Panel_GENELBILGI_PO"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="POTA OCAĞI GENEL BİLGİLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Office2010Silver" CssClass="auto-style13">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_GENELBILGILER_PO" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="  GRD_CH_GENELBILGILER_PO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="344px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM" VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri8" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' OnTextChanged="po_genel_bilgi_TextChanged" Width="80px"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="Panel_GENELBILGI_SDM" runat="server"
                                                                                ClientInstanceName="Panel_GENELBILGI_SDM"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="SDM GENEL BİLGİLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="63px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_GENELBILGILER_SDM" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="GRD_CH_GENELBILGILER_SDM"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="344px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM"
                                                                                                    VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri6" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' OnTextChanged="sdm_genel_bilgi_TextChanged" Width="80px"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                            </dx:PanelContent>
                                                        </PanelCollection>
                                                    </dx:ASPxCallbackPanel>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- ENERJI--%>
                            <dx:TabPage Text="ENERJİ & D.GAZ">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="942px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_enerjisakla" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_enerjisakla"
                                                                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                                                                    CssPostfix="Office2003Blue"
                                                                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css" CssClass="BtnDizaynn"
                                                                    Text="SAKLA" ImageSpacing="10px" Theme="Youthful" Width="96px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {ASPxCallbackPanel_ENERJI.PerformCallback('enerji_sakla');}" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel4" runat="server" Height="532px" Width="936px">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_ENERJI" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_ENERJI" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_ENERJI_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table class="auto-style17">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="Panel_ENERJI_AO" runat="server"
                                                                                ClientInstanceName="Panel_ENERJI_AO"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ARK OCAĞI ENERJİ BİLGİLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="63px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_ENERJI_AO" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="GRD_CH_ENERJI_AO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="374px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM"
                                                                                                    VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri6" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return isNumber(event)"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>

                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="ENERJI_MSG" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="ENERJI_MSG" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="Panel_ENERJI_PO" runat="server"
                                                                                ClientInstanceName="Panel_ENERJI_PO"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="POTA OCAĞI ENERJİ BİLGİLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Office2010Silver" CssClass="auto-style13">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_ENERJI_PO" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="GRD_CH_ENERJI_PO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="374px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM" VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri7" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return isNumber(event)"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </dx:PanelContent>
                                                        </PanelCollection>
                                                    </dx:ASPxCallbackPanel>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- SARF--%>
                            <dx:TabPage Text="SARF MALZEME">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel11" runat="server" Width="942px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_sarfsakla" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_sarfsakla"
                                                                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                                                                    CssPostfix="Office2003Blue"
                                                                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css" Text="SAKLA" CssClass="BtnDizaynn" Theme="Youthful" Visible="False">
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                    <ClientSideEvents Click="function(s, e) {   ASPxCallbackPanel_SARFMALZEMELER.PerformCallback('sarf_sakla');  }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel12" runat="server" Height="532px" Width="936px">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_SARFMALZEMELER" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_SARFMALZEMELER" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_SARFMALZEMELER_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table class="auto-style17">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel5" runat="server"
                                                                                ClientInstanceName="ASPxRoundPanel5"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="SDM"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="63px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_SARFMLZ_SDM" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="GRD_CH_SARFMLZ_SDM"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="314px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="SARFMALZEME TANIMI" FieldName="SARFMLZTNM" Name="SARFMLZTNM"
                                                                                                    VisibleIndex="0" Width="300px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri4" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>

                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="SARFMLZ_MSG" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="SARFMLZ_MSG" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server"
                                                                                ClientInstanceName="ASPxRoundPanel6"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ARK"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Office2010Silver" CssClass="auto-style13">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_SARFMLZ_AO" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="GRD_CH_SARFMLZ_AO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="314px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="SARFMALZEME TANIMI" FieldName="SARFMLZTNM" Name="SARFMLZTNM"
                                                                                                    VisibleIndex="0" Width="300px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri4" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </dx:PanelContent>
                                                        </PanelCollection>
                                                    </dx:ASPxCallbackPanel>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- HURDA--%>
                            <dx:TabPage Text="HURDALAR">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <table>
                                            <tr style="vertical-align: top">
                                                <td class="auto-style11">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 1px">
                                                                <dxe:ASPxButton ID="Btn_hurdasakla" runat="server" AutoPostBack="False" Text="SAKLA" CssClass="BtnDizaynn" Theme="Youthful" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {ASPxCallbackPanel_HURDA.PerformCallback('hurda_sakla');}" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dxe:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <caption>
                                                <br />
                                                <tr style="vertical-align: top">
                                                    <td class="auto-style11" style="width: 3008px;">
                                                        <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_HURDA" runat="server" ClientInstanceName="ASPxCallbackPanel_HURDA" OnCallback="ASPxCallbackPanel_HURDA_Callback">
                                                            <PanelCollection>
                                                                <dxe:PanelContent runat="server">
                                                                    <dxe:ASPxGridView ID="GRD_CH_HURDA" runat="server" AutoGenerateColumns="False" ClientInstanceName="GRD_CH_HURDA" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" KeyFieldName="HURDATIP" Theme="Office2010Silver" Enabled="False">
                                                                        <SettingsPager Visible="False" NumericButtonCount="15" PageSize="15">
                                                                        </SettingsPager>
                                                                        <Settings VerticalScrollableHeight="200" />
                                                                        <StylesEditors ButtonEditCellSpacing="0">
                                                                            <ProgressBar Height="21px">
                                                                            </ProgressBar>
                                                                        </StylesEditors>
                                                                        <StylesPager>
                                                                            <PageNumber ForeColor="#3E4846">
                                                                            </PageNumber>
                                                                            <Summary ForeColor="#1E395B">
                                                                            </Summary>
                                                                        </StylesPager>
                                                                        <Columns>
                                                                            <dxe:GridViewDataTextColumn Caption="HURDA TİPİ" FieldName="HURDATIP" Name="HURDATIP" ShowInCustomizationForm="True" VisibleIndex="1" Width="150px">
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn VisibleIndex="0">
                                                                                <CellStyle BackColor="#EEF0F1">
                                                                                </CellStyle>
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn Caption="1.SARJ" FieldName="SARJ1" Name="SARJ1" ShowInCustomizationForm="True" ToolTip="SARJ1" VisibleIndex="2" Width="120px">
                                                                                <DataItemTemplate>
                                                                                    <asp:TextBox ID="SARJ1" CssClass='expenses' runat="server" Text='<%#Eval("SARJ1")%>' onkeypress="return isNumber(event)" onkeyup="return sumall(this)"></asp:TextBox>
                                                                                </DataItemTemplate>
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn Caption="2.SARJ" FieldName="SARJ2" Name="SARJ2" ShowInCustomizationForm="True" ToolTip="SARJ2" VisibleIndex="3" Width="120px">
                                                                                <DataItemTemplate>
                                                                                    <asp:TextBox ID="SARJ2" CssClass='expenses' runat="server" Text='<%#Eval("SARJ2")%>' onkeypress="return isNumber(event)" onkeyup="return sumall(this)"></asp:TextBox>
                                                                                </DataItemTemplate>
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn Caption="3.SARJ" FieldName="SARJ3" Name="SARJ3" ShowInCustomizationForm="True" ToolTip="SARJ3" VisibleIndex="4" Width="120px">
                                                                                <DataItemTemplate>
                                                                                    <asp:TextBox ID="SARJ3" CssClass='expenses' runat="server" Text='<%#Eval("SARJ3")%>' onkeypress="return isNumber(event)" onkeyup="return sumall(this)"></asp:TextBox>
                                                                                </DataItemTemplate>
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn Caption="4.SARJ" FieldName="SARJ4" Name="SARJ4" ShowInCustomizationForm="True" ToolTip="SARJ4" VisibleIndex="5" Width="120px">
                                                                                <DataItemTemplate>
                                                                                    <asp:TextBox ID="SARJ4" CssClass='expenses' runat="server" Text='<%#Eval("SARJ4")%>' onkeypress="return isNumber(event)" onkeyup="return sumall(this)"></asp:TextBox>
                                                                                </DataItemTemplate>
                                                                            </dxe:GridViewDataTextColumn>
                                                                            <dxe:GridViewDataTextColumn Caption="TOPLAM" FieldName="TOPLAM" Name="TOPLAM" ShowInCustomizationForm="True" ToolTip="TOPLAM" VisibleIndex="6" Width="100px">
                                                                                <DataItemTemplate>
                                                                                    <asp:TextBox ID="TOPLAM" CssClass='expenses_sum' runat="server" Text='<%#Eval("TOPLAM")%>' onkeypress="return isNumber(event)" onkeyup="return sumall()" ReadOnly="true"></asp:TextBox>
                                                                                </DataItemTemplate>
                                                                            </dxe:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                            <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                                            </Header>
                                                                            <LoadingPanel ImageSpacing="5px">
                                                                            </LoadingPanel>
                                                                        </Styles>
                                                                        <Styles CssPostfix="Office2010Blue" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"></Styles>
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
                                                                    </dxe:ASPxGridView>
                                                                    <br />

                                                                    <%--  <table class="span7" style="margin-left: 54px">
                                                                        <tr>
                                                                            <td>
                                                                                <input type="text" class="input-mini" style="margin-left: 0px; opacity: 0" />
                                                                            </td>
                                                                            <td>
                                                                                <input type="text" class="input-mini" title="ŞARJ1 TOPLAM" id="Toplam_sarj1" style="margin-left: 29px;" readonly=" readonly " />
                                                                            </td>
                                                                            <td>
                                                                                <input type="text" class="input-mini" title="ŞARJ2 TOPLAM" id="Toplam_sarj2" style="margin-left: 29px;" readonly=" readonly " />
                                                                            </td>
                                                                            <td>
                                                                                <input type="text" class="input-mini" title="ŞARJ3 TOPLAM" id="Toplam_sarj3" style="margin-left: 31px;" readonly=" readonly " />
                                                                            </td>
                                                                            <td>
                                                                                <input type="text" class="input-mini" title="ŞARJ4 TOPLAM"  id="Toplam_sarj4" style="margin-left: 31px;" readonly=" readonly " />
                                                                            </td>
                                                                            <td>
                                                                                <input type="text" id="sum" class="input-mini" title="TOPLAM ŞARJ" style="margin-left: 31px;" readonly=" readonly " />
                                                                            </td>
                                                                        </tr>

                                                                    </table>--%>


                                                                    <table class="span7" style="margin-left: 54px">
                                                                        <tr>
                                                                            <td>

                                                                                <input type="text" class="input-mini" style="margin-left: 0px; opacity: 0" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Txt_Toplam_sarj1" class="input-mini" runat="server" Style="margin-left: 29px;" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Txt_Toplam_sarj2" class="input-mini" runat="server" Style="margin-left: 29px;" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Txt_Toplam_sarj3" class="input-mini" runat="server" Style="margin-left: 31px;" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Txt_Toplam_sarj4" class="input-mini" runat="server" Style="margin-left: 31px;" ReadOnly="True"></asp:TextBox>

                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Txt_Toplam_sarj" class="sum_toplam_sarj" runat="server" Style="margin-left: 31px;" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

                                                                    </table>

                                                                    <%--   <table style="margin-left:465px"">
                                                                                <tr>
                                                                                    <td style="font-size: 11px; font-weight: BOLD; color: #f08080;">
                                                                                        <p style="width: 150px;">Toplam Hurda Miktarı:</p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="Txt_HurdaToplam" runat="server" Style="color: #f08080; text-align: center; width: 180px; height: 35px; border-radius: 1px; border: 2px solid #e4effa; margin-left: 12px; font-weight: bold;" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>--%>
                                                                    <dxe:ASPxPopupControl ID="HURDA_MSG" runat="server" AllowDragging="True" ClientInstanceName="HURDA_MSG" CloseAction="CloseButton" CloseOnEscape="True" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" EnableHotTrack="False" EnableViewState="False" HeaderText="MESAJ EKRANI" Height="150px" Modal="True" PopupAnimationType="Fade" PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40" PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" Theme="Youthful" Width="300px">
                                                                        <LoadingPanelImage Url="~/App_Themes/Office2010Blue/Web/Loading.gif">
                                                                        </LoadingPanelImage>
                                                                        <HeaderStyle>
                                                                            <Paddings PaddingLeft="7px" />
                                                                        </HeaderStyle>
                                                                        <LoadingPanelStyle ImageSpacing="5px">
                                                                        </LoadingPanelStyle>
                                                                        <ContentCollection>
                                                                            <dxe:PopupControlContentControl runat="server">
                                                                            </dxe:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                    </dxe:ASPxPopupControl>
                                                                </dxe:PanelContent>
                                                            </PanelCollection>
                                                        </dxe:ASPxCallbackPanel>
                                                    </td>
                                                </tr>
                                            </caption>
                                        </table>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- ALYAJ--%>
                            <dx:TabPage Text="ALYAJLAR">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="940px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_alyajsakla" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_alyajsakla" CssClass="BtnDizaynn" Text="SAKLA" ImageSpacing="10px" Width="96px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_ALYAJ.PerformCallback('alyaj_sakla'); }" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel2" runat="server" Height="532px"
                                            Width="956px" Theme="Office2003Blue">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_ALYAJ" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_ALYAJ" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_ALYAJ_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table style="height: 164px">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server"
                                                                                ClientInstanceName="ASPxRoundPanel1"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ARK OCAĞI"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="348px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_ALYAJ_AO" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="GRD_CH_ALYAJ_AO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="SARJTIP"
                                                                                            Width="414px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="ŞARJ TİPİ" FieldName="SARJTIP" Name="SARJTIP"
                                                                                                    VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="LOKASYON" FieldName="LOKASYON"
                                                                                                    Name="LOKASYON" VisibleIndex="1" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ (Kg)" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="35"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="550" />
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="ALYAJ_MSG" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="ALYAJ_MSG" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="POTA OCAĞI"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="348px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="GRD_CH_ALYAJ_PO" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="GRD_CH_ALYAJ_PO"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="SARJTIP"
                                                                                            Width="400px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="ŞARJ TİPİ" FieldName="SARJTIP"
                                                                                                    Name="SARJTIP" VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="LOKASYON" FieldName="LOKASYON"
                                                                                                    Name="LOKASYON" VisibleIndex="1" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ (Kg)" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="85"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="550" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </dx:PanelContent>
                                                        </PanelCollection>
                                                    </dx:ASPxCallbackPanel>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- DURUŞ--%>
                            <dx:TabPage Text="DURUŞLAR">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dxe:ASPxPanel ID="ASPxPanel9" runat="server" Style="margin-top: 21px;" Theme="Office2010Silver" Width="1272px">
                                            <PanelCollection>
                                                <dxe:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="auto-style45">
                                                                <dxe:ASPxButton ID="Btn_durusSakla" runat="server" AutoPostBack="False" ClientInstanceName="Btn_durusSakla" ImageSpacing="10px" Text="KAYIT" CssClass="BtnDizaynn" Theme="Youthful" Width="96px" Height="46px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {
	           ASPxCallbackPanel_DURUSKAYIT.PerformCallback('durus_kayit');
                           ASPxCallbackPanel_DURUSLISTE.PerformCallback('durus_liste'); }" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td>
                                                                <dx:ASPxButton ID="Btn_yenidurus" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_yenidurus"
                                                                    Text="YENİ DURUŞ" ImageSpacing="10px" CssClass="BtnDizaynn" Width="96px" Height="46px" Style="margin-left: 30px">
                                                                    <ClientSideEvents Click="function(s, e) {     ASPxCallbackPanel_DURUSKAYIT.PerformCallback('yeni_durus'); }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td>
                                                                <dx:ASPxButton ID="Btn_Sablon" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_Sablon"
                                                                    Text="ŞABLON" ImageSpacing="10px" CssClass="BtnDizaynn" Theme="Youthful" Width="96px" Height="46px" Style="margin-left: 30px">
                                                                    <ClientSideEvents Click="function(s, e) {    
                                                                            ASPxCallbackPanel_DURUSKAYIT.PerformCallback('durus_sablon_getir');
                                                                            ASPxCallbackPanel_DURUSLISTE.PerformCallback('durus_liste'); }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td>
                                                                <dx:ASPxButton ID="Btn_durus_sil" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_durus_sil"
                                                                    Text="DURUŞ SİL" ImageSpacing="10px" CssClass="BtnDizaynn" Theme="Youthful" Width="96px" Height="46px" Style="margin-left: 30px">
                                                                    <ClientSideEvents Click="function(s, e) {    
                                                                            ASPxCallbackPanel_DURUSKAYIT.PerformCallback('durus_sil');
                                                                            ASPxCallbackPanel_DURUSLISTE.PerformCallback('durus_liste'); }" />
                                                                </dx:ASPxButton>
                                                            </td>


                                                        </tr>
                                                    </table>
                                                </dxe:PanelContent>
                                            </PanelCollection>
                                        </dxe:ASPxPanel>
                                        <dxe:ASPxPanel ID="ASPxPanel10" runat="server" Style="margin-top: 71px;" Theme="Office2010Silver" Width="800px">
                                            <PanelCollection>
                                                <dxe:PanelContent runat="server">
                                                    <div class="paneller">
                                                        <div class="sol_panel">
                                                            <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_DURUSKAYIT" runat="server" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_DURUSKAYIT_Callback" ClientInstanceName="ASPxCallbackPanel_DURUSKAYIT">
                                                                <PanelCollection>
                                                                    <dxe:PanelContent runat="server">
                                                                        <table class="auto-style16">
                                                                            <tr style="vertical-align: top">
                                                                                <td class="auto-style41">Duruş Nedeni:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px;">
                                                                                    <dxe:ASPxComboBox ID="cmb_durusNeden" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" ClientInstanceName="cmb_durusNeden" Theme="Office2010Silver">
                                                                                        <ClientSideEvents ValueChanged="function(s, e) {           ASPxCallbackPanel_DURUSKAYIT.PerformCallback('durusKodGetir'); }" />
                                                                                    </dxe:ASPxComboBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">Duruş Kodu:</td>
                                                                                <td class="auto-style44">
                                                                                    <dxe:ASPxTextBox ID="txt_durusKod" runat="server" CssPostfix="RedWine" Height="30px" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" ClientInstanceName="txt_durusKod" ReadOnly="True">
                                                                                        <ClientSideEvents GotFocus="function(s, e) {  ASPxCallbackPanel_DURUSKAYIT.PerformCallback('ariza_neden'); }" />
                                                                                    </dxe:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top">
                                                                                <td class="auto-style43">Arıza Nedeni:</td>
                                                                                <td class="auto-style43">
                                                                                    <dx:ASPxComboBox ID="Cmb_ArizaNeden" runat="server" ValueType="System.String" Height="30px" Width="120px" TextField="SEÇİNİZ" ClientInstanceName="Cmb_ArizaNeden" Theme="Office2010Silver">
                                                                                        <ClientSideEvents ValueChanged="function(s, e) { ASPxCallbackPanel_DURUSKAYIT.PerformCallback('ArizaKodGetir'); }" />
                                                                                    </dx:ASPxComboBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style43">Arıza Kodu:</td>
                                                                                <td class="auto-style43">
                                                                                    <dxe:ASPxTextBox ID="txt_ArizaKod" runat="server" CssPostfix="RedWine" Height="30px" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" ClientInstanceName="txt_ArizaKod" ReadOnly="True">
                                                                                    </dxe:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top">
                                                                                <td>Şarj Durumu:</td>
                                                                                <td>
                                                                                    <dxe:ASPxComboBox ID="cmb_sarjdurumu" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" ClientInstanceName="cmb_sarjdurumu" SelectedIndex="0" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Selected="True" Value="" />
                                                                                            <dxe:ListEditItem Text="1.ŞARJ ALMA" Value="0" />
                                                                                            <dxe:ListEditItem Text="2.ŞARJ ALMA" Value="1" />
                                                                                            <dxe:ListEditItem Text="3.ŞARJ ALMA" Value="2" />
                                                                                            <dxe:ListEditItem Text="4.ŞARJ ALMA" Value="3" />
                                                                                            <dxe:ListEditItem Text="TD 1.ŞARJ ALMA" Value="4" />
                                                                                            <dxe:ListEditItem Text="1.VE 2. ŞARJ ALMA" Value="5" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top">
                                                                                <td>Başlangıç Saati:</td>
                                                                                <td>
                                                                                    <dx:ASPxTimeEdit ID="txt_BasSaat" runat="server" Height="30px" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" ClientInstanceName="txt_BasSaat">
                                                                                        <ClientSideEvents ValueChanged="function(s, e) {	ASPxCallbackPanel_DURUSKAYIT.PerformCallback('NetsureGetir');}" />
                                                                                    </dx:ASPxTimeEdit>
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top">
                                                                                <td>Bitiş Saati:</td>
                                                                                <td>
                                                                                    <dx:ASPxTimeEdit ID="txt_BitisSaat" runat="server" Height="30px" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" ClientInstanceName="txt_BitisSaat">
                                                                                        <ClientSideEvents ValueChanged="function(s, e) {ASPxCallbackPanel_DURUSKAYIT.PerformCallback('NetsureGetir');}" />
                                                                                    </dx:ASPxTimeEdit>
                                                                                    <br />
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top">
                                                                                <td>Net Süre:
                                                                                        <br />
                                                                                    (Dakika)</td>
                                                                                <td>
                                                                                    <dxe:ASPxTextBox ID="txt_Netsure" runat="server" ClientInstanceName="txt_Netsure" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 11px" Theme="Office2010Silver" Width="120px">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td>
                                                                                    <dxe:ASPxTextBox ID="txt_DurusID" runat="server" ClientInstanceName="txt_DurusID" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" CssClass="durus" Theme="Office2010Silver" Width="1px" ReadOnly="True">
                                                                                        <ClientSideEvents GotFocus="function(s, e) {  ASPxCallbackPanel_DURUSKAYIT.PerformCallback('durus_bilgisi_getir'); }" />
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <caption>
                                                                                <br />
                                                                                <br />
                                                                                <tr style="vertical-align: top">
                                                                                    <td colspan="4">
                                                                                        <dxe:ASPxTextBox ID="txt_Aciklama" runat="server" ClientInstanceName="txt_Aciklama" Height="70px" Text="GENEL AÇIKLAMA" Width="498px">
                                                                                        </dxe:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </caption>
                                                                        </table>
                                                                        <dxe:ASPxPopupControl ID="DURUS_MSG" runat="server" AllowDragging="True" AutoUpdatePosition="True" ClientInstanceName="DURUS_MSG" CloseAction="CloseButton" CloseOnEscape="True" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False" HeaderText="MESAJ EKRANI" Height="30px" Modal="True" PopupAnimationType="Fade" PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="30" PopupVerticalAlign="Middle" PopupVerticalOffset="380" SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Youthful" Width="252px">
                                                                            <LoadingPanelImage Url="~/App_Themes/Office2003Silver/Web/Loading.gif">
                                                                            </LoadingPanelImage>
                                                                            <CloseButtonStyle Font-Bold="False" Font-Names="Rod">
                                                                            </CloseButtonStyle>
                                                                            <HeaderStyle>
                                                                                <Paddings PaddingRight="6px" />
                                                                            </HeaderStyle>
                                                                            <ContentCollection>
                                                                                <dxe:PopupControlContentControl runat="server">
                                                                                </dxe:PopupControlContentControl>
                                                                            </ContentCollection>
                                                                        </dxe:ASPxPopupControl>
                                                                    </dxe:PanelContent>
                                                                </PanelCollection>
                                                            </dxe:ASPxCallbackPanel>
                                                        </div>
                                                        <div class="sag_panel">
                                                            <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_DURUSLISTE" runat="server" ClientInstanceName="ASPxCallbackPanel_DURUSLISTE" OnCallback="ASPxCallbackPanel_DURUSLISTE_Callback">
                                                                <PanelCollection>
                                                                    <dxe:PanelContent runat="server">
                                                                        <dxe:ASPxGridView ID="GRD_DURUS" runat="server" KeyFieldName="ARIZAKOD" AutoGenerateColumns="False" ClientInstanceName="GRD_DURUS" EnableTheming="False" Width="524px" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                            <ClientSideEvents RowClick="function(s, e) {  GRD_DURUS.GetRowValues(e.visibleIndex,'DURUS_ID;',durus_id_bilgi );
                                                                                                                          GRD_DURUS.GetRowValues(e.visibleIndex,'DURUSKOD;',durus_kod_bilgi ); }" />
                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25" Visible="False">
                                                                            </SettingsPager>
                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="340" />

                                                                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" />
                                                                            <StylesEditors ButtonEditCellSpacing="0">
                                                                                <ProgressBar Height="21px">
                                                                                </ProgressBar>
                                                                            </StylesEditors>
                                                                            <StylesPager>
                                                                                <PageNumber ForeColor="#3E4846">
                                                                                </PageNumber>
                                                                                <Summary ForeColor="#1E395B">
                                                                                </Summary>
                                                                            </StylesPager>
                                                                            <Columns>
                                                                                <dxe:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                </dxe:GridViewCommandColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="BAŞ.SAATİ" FieldName="BASSAATI" Name="BASSAATI" ShowInCustomizationForm="True" VisibleIndex="3" Width="79px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="BİTİŞ SAATİ" FieldName="BITISSAATI" Name="BITISSAATI" ShowInCustomizationForm="True" VisibleIndex="4" Width="82px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="SÜRE" FieldName="SURE" Name="SURE" ShowInCustomizationForm="True" VisibleIndex="5" Width="69px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DURUSNEDEN" FieldName="DURUSNEDEN" Name="DURUSNEDEN" ShowInCustomizationForm="True" VisibleIndex="6" Width="93px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ARIZA NEDEN" FieldName="ARIZANEDEN" Name="ARIZANEDEN" ShowInCustomizationForm="True" VisibleIndex="7" Width="93px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ARIZAKOD" FieldName="ARIZAKOD" Name="ARIZAKOD" ShowInCustomizationForm="True" VisibleIndex="8" Width="88px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ŞARJ ALMA" FieldName="SARJALMA" Name="SARJALMA" ShowInCustomizationForm="True" VisibleIndex="9" Width="85px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DURUŞKOD" FieldName="DURUSKOD" Name="DURUSKOD" ShowInCustomizationForm="True" VisibleIndex="10" Width="85px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DURUS_ID" FieldName="DURUS_ID" Name="DURUS_ID" ShowInCustomizationForm="True" VisibleIndex="11" Visible="False">
                                                                                </dxe:GridViewDataTextColumn>
                                                                            </Columns>
                                                                            <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                                                </Header>
                                                                                <LoadingPanel ImageSpacing="5px">
                                                                                </LoadingPanel>
                                                                            </Styles>
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
                                                                        </dxe:ASPxGridView>
                                                                    </dxe:PanelContent>
                                                                </PanelCollection>
                                                            </dxe:ASPxCallbackPanel>
                                                            <div class="clear"></div>
                                                        </div>

                                                        <div class="clear"></div>
                                                    </div>
                                                </dxe:PanelContent>
                                            </PanelCollection>
                                        </dxe:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <%-- Refrakter--%>
                            <dx:TabPage Text="REFRAKTER">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dxe:ASPxPanel ID="ASPxPanel7" runat="server" Style="margin-top: 21px;" Theme="Office2010Silver" Width="1492px">
                                            <PanelCollection>
                                                <dxe:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="auto-style45">
                                                                <dxe:ASPxButton ID="Btn_Refraktersakla" runat="server" AutoPostBack="False" ClientInstanceName="Btn_Refraktersakla" CssClass="BtnDizayn" ImageSpacing="4px" Text="SAKLA" Theme="Youthful" Width="96px" Height="46px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {
	                              ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_kayit');
                                   ASPxCallbackPanel_REFRAKTERLISTE.PerformCallback('refrakter_liste');}" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td class="auto-style45">
                                                                <dxe:ASPxButton ID="Btn_Refrakteryeni" runat="server" AutoPostBack="False" ClientInstanceName="Btn_Refrakteryeni" CssClass="BtnDizayn" ImageSpacing="4px" Text="YENİ" Theme="Youthful" Width="96px" Height="46px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_RefrakterKayit.PerformCallback('yeni_refrakter');
                                                                                                              ASPxCallbackPanel_REFRAKTERLISTE.PerformCallback('refrakter_liste'); }" />
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td class="auto-style45">
                                                                <dxe:ASPxButton ID="Btn_refrakter_dokum_sil" runat="server" AutoPostBack="False" ClientInstanceName="Btn_refrakter_dokum_sil" CssClass="BtnDizayn" ImageSpacing="4px" Text="SİL" Theme="Youthful" Width="96px" Height="46px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) { ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_dokum_sil');
                                                                                                                ASPxCallbackPanel_REFRAKTERLISTE.PerformCallback('refrakter_liste'); }" />
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td class="auto-style45">
                                                                <%--<dxe:ASPxTextBox ID="tx_refrakter_dokum" runat="server" ClientInstanceName="tx_refrakter_dokum" Height="30px" CssClass="tx_refrakter_dokum" Style="font-size: 14px; margin-left:28px" Width="120px" >
                                                                                        <ClientSideEvents GotFocus="function(s, e)     {  ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_bilgi');     }"></ClientSideEvents>
                                                                                    </dxe:ASPxTextBox>--%>
                                                                <%-- <dxe:ASPxTextBox ID="tx_refrakter_dokum" runat="server"  ClientInstanceName="tx_refrakter_dokum" Width="178px" color="#d2d5da" text-align="center"
                                                                   Font-Bold="True" Font-Size="Medium" Text="0" Height="43px" CssClass="tx_refrakter_dokum" ReadOnly="True">
                                                                  <ClientSideEvents GotFocus="function(s, e)     {  ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_bilgi');}"></ClientSideEvents>  </dxe:ASPxTextBox>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dxe:PanelContent>
                                            </PanelCollection>
                                        </dxe:ASPxPanel>
                                        <dxe:ASPxPanel ID="ASPxPanel8" runat="server" Style="margin-top: 30px;" Theme="Office2010Silver" Width="800px">
                                            <PanelCollection>
                                                <dxe:PanelContent runat="server">
                                                    <div class="paneller">
                                                        <div class="soll_panel">
                                                            <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_RefrakterKayit" runat="server" ClientInstanceName="ASPxCallbackPanel_RefrakterKayit" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_RefrakterKayit_Callback">
                                                                <PanelCollection>
                                                                    <dxe:PanelContent runat="server">
                                                                        <table class="auto-style16">
                                                                            <tr>
                                                                                <td class="auto-style41">Seçilen Döküm Numarası :</td>
                                                                                <td class="auto-style36" style="margin-left: 10px;">
                                                                                    <dxe:ASPxTextBox ID="tx_refrakter_dokum" runat="server" ClientInstanceName="tx_refrakter_dokum" Height="34px" Style="border: 2px solid  #e0bfbf; font-weight: bold; font-size: 15px" Width="120px" ReadOnly="True">
                                                                                        <ClientSideEvents GotFocus="function(s, e)     {  ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_bilgi'); }"></ClientSideEvents>
                                                                                    </dxe:ASPxTextBox>

                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style41">Başlangıç Tarihi:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px;">
                                                                                    <dx:ASPxDateEdit ID="date_baslangicTarihi" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" DisplayFormatString="dd/MM/yyyy"
                                                                                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                                                        Theme="Office2010Silver" Width="120px">
                                                                                    </dx:ASPxDateEdit>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">POTA NO:</td>
                                                                                <td class="auto-style44">
                                                                                    <dx:ASPxComboBox ID="cmb_Potano" runat="server" ClientInstanceName="cmb_Potano" ValueType="System.String" Height="30px" Style="font-size: 15px; font-weight: bold" Theme="Office2010Silver" Width="120px">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="1" Value="0" />
                                                                                            <dxe:ListEditItem Text="2" Value="1" />
                                                                                            <dxe:ListEditItem Text="3" Value="2" />
                                                                                            <dxe:ListEditItem Text="4" Value="3" />
                                                                                            <dxe:ListEditItem Text="5" Value="4" />
                                                                                            <dxe:ListEditItem Text="6" Value="5" />
                                                                                            <dxe:ListEditItem Text="7" Value="6" />
                                                                                        </Items>
                                                                                    </dx:ASPxComboBox>

                                                                                    <br />
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style41">DÖKÜM SAYISI:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px;">
                                                                                    <dxe:ASPxTextBox ID="txt_Dokumsayisi" runat="server" ClientInstanceName="txt_Dokumsayisi" CssPostfix="RedWine" Height="30px" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style43">Psk Tmr:</td>
                                                                                <td class="auto-style44">
                                                                                    <dx:ASPxComboBox ID="cmb_pskTmr" runat="server" ClientInstanceName="cmb_pskTmr" ValueType="System.String" Height="30px" Style="font-size: 12px" Theme="Office2010Silver" Width="120px">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="E" Value="0" />
                                                                                            <dxe:ListEditItem Text="H" Value="1" />
                                                                                        </Items>
                                                                                    </dx:ASPxComboBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style34">TUĞLA FİRMA:</td>
                                                                                <td>
                                                                                    <dx:ASPxComboBox ID="cmb_TuglaFirma" runat="server" ClientInstanceName="cmb_TuglaFirma" ValueType="System.String" Height="30px" Style="font-size: 12px" Theme="Office2010Silver" Width="120px">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="KÜMAŞ" Value="0" />
                                                                                            <dxe:ListEditItem Text="HAZNEDAR" Value="1" />
                                                                                            <%--   <dxe:ListEditItem Text="LWB" Value="2" />--%>
                                                                                            <dxe:ListEditItem Text="RHI & MAGNESITA" Value="2" />

                                                                                            <dxe:ListEditItem Text="VESUVIUS" Value="3" />
                                                                                            <dxe:ListEditItem Text="SÖRMAŞ" Value="4" />

                                                                                        </Items>
                                                                                    </dx:ASPxComboBox>
                                                                                    <br />


                                                                                </td>
                                                                                <td class="auto-style34">TANDİŞ PLK/FRM:</td>
                                                                                <td class="auto-style44">
                                                                                    <dx:ASPxComboBox ID="Cmb_Tandis_Plk_Frm" runat="server" ClientInstanceName="cmb_Potano" ValueType="System.String" Height="30px" Style="font-size: 12px" Theme="Office2010Silver" Width="120px" Enabled="false">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="ASMAŞ" Value="0" />
                                                                                            <dxe:ListEditItem Text="ÇUKUROVA" Value="1" />
                                                                                            <dxe:ListEditItem Text="PIROMET" Value="2" />
                                                                                        </Items>
                                                                                    </dx:ASPxComboBox>

                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style37">Pota Durum:</td>
                                                                                <td class="auto-style38">
                                                                                    <dx:ASPxComboBox ID="cmb_Potadurum" runat="server" ClientInstanceName="cmb_Potadurum" ValueType="System.String" Height="30px" Style="font-size: 12px" Theme="Office2010Silver" Width="120px">
                                                                                        <ClientSideEvents TextChanged="function(s, e) {
	  ASPxCallbackPanel_RefrakterKayit.PerformCallback('pota_durum');

}" />
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="DEVAM" Value="0" />
                                                                                            <%--  <dxe:ListEditItem Text="ÖRÜMDE" Value="1" />--%>
                                                                                            <dxe:ListEditItem Text="ISKARTA" Value="1" />
                                                                                            <%--    <dxe:ListEditItem Text="HAZIR" Value="3" />--%>
                                                                                        </Items>
                                                                                    </dx:ASPxComboBox>
                                                                                    <br />
                                                                                </td>

                                                                                <td class=" auto-style34">Iskarta Tarihi:</td>
                                                                                <td class="auto-style44">

                                                                                    <dx:ASPxDateEdit ID="Date_IskartaTarih" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" DisplayFormatString="dd/MM/yyyy"
                                                                                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                                                        Theme="Office2010Silver" Width="120px">
                                                                                    </dx:ASPxDateEdit>

                                                                                </td>

                                                                            </tr>
                                                                            <tr style="background-color: #cdcdb4;">
                                                                                <td class="auto-style41"><span style="font-weight: bold;">[GAZ TAPASI]</span>DS:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px;">

                                                                                    <dxe:ASPxTextBox ID="Txt_gazds" runat="server" ClientInstanceName="Txt_gazds" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 13px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">FİRMA:</td>
                                                                                <td class="auto-style44">
                                                                                    <dxe:ASPxComboBox ID="Cmb_gazFirma" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="METAMİN" Value="0" />
                                                                                            <dxe:ListEditItem Text="RHI" Value="1" />
                                                                                            <dxe:ListEditItem Text="VESUVIUS" Value="2" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top; background-color: #cdcdb4;">
                                                                                <td class="auto-style37">TİP:</td>
                                                                                <td class="auto-style38" style="margin-left: 10px;">
                                                                                    <dxe:ASPxComboBox ID="cmb_Tip" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="SEGMENT" Value="0" />
                                                                                            <dxe:ListEditItem Text="KANALLI" Value="1" />
                                                                                            <dxe:ListEditItem Text="HIBRIT" Value="2" />

                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style37"></td>
                                                                                <td class="auto-style36">
                                                                                    <%--    <dxe:ASPxTextBox ID="tx_refrakter_dokum" runat="server" ClientInstanceName="tx_refrakter_dokum" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px"  SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Theme="Office2010Silver" Style="font-size: 14px" Width="120px" ReadOnly="True">
                                                                                        <ClientSideEvents GotFocus="function(s, e)     {  ASPxCallbackPanel_RefrakterKayit.PerformCallback('refrakter_bilgi');     }"></ClientSideEvents>
                                                                                    </dxe:ASPxTextBox>--%>
                                                                                    <br />
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="vertical-align: top; background-color: #ff6a6a;">
                                                                                <td class="auto-style41"><span style="font-weight: bold;">[ÜST NOZUL]</span> DS:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxTextBox ID="Txt_UstDS" runat="server" ClientInstanceName="Txt_UstDS" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">FİRMA:</td>
                                                                                <td class="auto-style44" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxComboBox ID="Cmb_UstFirma" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="METAMİN" Value="0" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top; background-color: #ffd39b;">
                                                                                <td class="auto-style41"><span style="font-weight: bold;">[ALT NOZUL]</span> DS:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxTextBox ID="Txt_AltDS" runat="server" ClientInstanceName="Txt_AltDS" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">FİRMA:</td>
                                                                                <td class="auto-style44" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxComboBox ID="Cmb_AltFirma" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="METAMİN" Value="0" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top; background-color: #eeeed1;">
                                                                                <td class="auto-style41"><span style="font-weight: bold;">[SÜRGÜ PLAKASI]</span>DS:</td>
                                                                                <td class="auto-style36" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxTextBox ID="Txt_surguDS" runat="server" ClientInstanceName="Txt_surguDS" CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" Height="30px" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Style="font-size: 14px" Theme="Office2010Silver" Width="120px" onkeypress="return isNumber(event)">
                                                                                    </dxe:ASPxTextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">FİRMA:</td>
                                                                                <td class="auto-style44" style="margin-left: 10px; margin-top: 15px">
                                                                                    <dxe:ASPxComboBox ID="Cmb_SurguFirma" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Text="ANADOLU" Value="0" />
                                                                                            <dxe:ListEditItem Text="RASTAŞ" Value="1" />
                                                                                            <dxe:ListEditItem Text="VESUVIUS" Value="2" />
                                                                                            <dxe:ListEditItem Text="METAMİN" Value="3" />
                                                                                            <dxe:ListEditItem Text="PUYANG" Value="4" />

                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="vertical-align: top; background-color: #eeeed1;">
                                                                                <td class="auto-style41">Plk T/Y:</td>
                                                                                <td class="auto-style36" style="margin-top: 15px">
                                                                                    <dxe:ASPxComboBox ID="cmb_PlkTY" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Selected="True" Value="" />
                                                                                            <dxe:ListEditItem Text="T" Value="0" />
                                                                                            <dxe:ListEditItem Text="Y" Value="1" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style34">KONTROL EDEN:</td>
                                                                                <td class="auto-style44">
                                                                                    <dxe:ASPxComboBox ID="Cmb_KontrolEden" runat="server" Height="30px" TextField="SEÇİNİZ" Width="120px" SelectedIndex="0" Theme="Office2010Silver">
                                                                                        <Items>
                                                                                            <dxe:ListEditItem Selected="True" Value="" />
                                                                                            <dxe:ListEditItem Text="ŞİNASİ ALTINÖZ" Value="0" />
                                                                                            <dxe:ListEditItem Text="HALİL EKİNCİ" Value="1" />
                                                                                            <dxe:ListEditItem Text="AHMET DUMAN" Value="2" />
                                                                                            <dxe:ListEditItem Text="ASLAN BAYGÜL" Value="3" />
                                                                                            <dxe:ListEditItem Text="RAMAZAN YOLAL" Value="4" />
                                                                                        </Items>
                                                                                    </dxe:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <%--     <tr style="vertical-align: top">
                                                                                <td class="auto-style41">TANDİŞ PLK/FRM:</td>



                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td class="auto-style41">POTA ÇIKIŞ SAATİ:</td>
                                                                                <td style="margin-left: 10px; margin-top: 15px">
                                                                                    <dx:ASPxTimeEdit ID="dt_Cks_saati" runat="server" Theme="Office2003Olive" Height="30px" Style="font-size: 14px" Width="120px"></dx:ASPxTimeEdit>
                                                                                    <br />
                                                                                </td>
                                                                                <td>POTA GELİŞ SAATİ:</td>
                                                                                <td class="auto-style44">
                                                                                    <dx:ASPxTimeEdit ID="dt_Gelis_saati" runat="server" Theme="Office2003Olive" Height="30px" Style="font-size: 14px" Width="120px"></dx:ASPxTimeEdit>
                                                                                    <br />
                                                                                </td>

                                                                            </tr>
                                                                            <tr>

                                                                                <td colspan="4">
                                                                                    <asp:TextBox ID="txt_Genelaciklamaa" runat="server" placeholder="Genel Açıklama" Width="505px" Height="70px" ClientInstanceName="txt_Genelaciklama"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <dxe:ASPxPopupControl ID="REFRAKTER_MSG" runat="server" AllowDragging="True" AutoUpdatePosition="True" ClientInstanceName="REFRAKTER_MSG" CloseAction="CloseButton" CloseOnEscape="True" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False" HeaderText="MESAJ EKRANI" Height="30px" Modal="True" PopupAnimationType="Fade" PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40" PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40" SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Youthful" Width="252px">
                                                                            <LoadingPanelImage Url="~/App_Themes/Office2003Silver/Web/Loading.gif">
                                                                            </LoadingPanelImage>
                                                                            <HeaderStyle>
                                                                                <Paddings PaddingRight="6px" />
                                                                            </HeaderStyle>
                                                                            <ContentCollection>
                                                                                <dxe:PopupControlContentControl runat="server">
                                                                                </dxe:PopupControlContentControl>
                                                                            </ContentCollection>
                                                                        </dxe:ASPxPopupControl>
                                                                    </dxe:PanelContent>
                                                                </PanelCollection>
                                                            </dxe:ASPxCallbackPanel>
                                                        </div>
                                                        <div class="sagg_panel">
                                                            <dxe:ASPxCallbackPanel ID="ASPxCallbackPanel_REFRAKTERLISTE" runat="server" ClientInstanceName="ASPxCallbackPanel_REFRAKTERLISTE" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_REFRAKTERLISTE_Callback" SettingsLoadingPanel-ShowImage="False" SettingsLoadingPanel-Enabled="False">
                                                                <SettingsLoadingPanel Enabled="False" ShowImage="False"></SettingsLoadingPanel>
                                                                <PanelCollection>
                                                                    <dxe:PanelContent runat="server">
                                                                        <dxe:ASPxGridView ID="GRD_REFRAKTER" runat="server" AutoGenerateColumns="True" ClientInstanceName="GRD_REFRAKTER" EnableTheming="False" KeyFieldName="POTANO" Width="970px">
                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="45" Visible="False">
                                                                            </SettingsPager>
                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="390" HorizontalScrollBarMode="Visible" />
                                                                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" EnableRowHotTrack="True" />
                                                                            <SettingsLoadingPanel ShowImage="False" Text="" />
                                                                            <StylesEditors ButtonEditCellSpacing="0">
                                                                                <ProgressBar Height="21px">
                                                                                </ProgressBar>
                                                                            </StylesEditors>
                                                                            <StylesPager>
                                                                                <PageNumber ForeColor="#3E4846">
                                                                                </PageNumber>
                                                                                <Summary ForeColor="#1E395B">
                                                                                </Summary>
                                                                            </StylesPager>
                                                                            <Columns>
                                                                                <dxe:GridViewDataTextColumn Caption="DÖKÜMNO" FieldName="DOKUMNO" Name="DOKUMNO" ShowInCustomizationForm="True" VisibleIndex="0" Width="78px" FixedStyle="Left">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="POTANO" FieldName="POTANO" Name="POTANO" ShowInCustomizationForm="True" VisibleIndex="1" Width="60px" FixedStyle="Left">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DÖKÜMSAYISI" FieldName="DKMSAYISI" Name="DKMSAYISI" ShowInCustomizationForm="True" VisibleIndex="2" Width="90px" FixedStyle="Left">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="TUĞLAFİRMA" FieldName="TUGLAFIRMA" Name="TUGLAFIRMA" ShowInCustomizationForm="True" VisibleIndex="3" Width="85px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="PÜSKÜRTMELİ" FieldName="PUSKURTMELI" Name="PUSKURTMELI" ShowInCustomizationForm="True" VisibleIndex="4" Width="91px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DEV.ALMA TAR" FieldName="BASLANGICTARIHI" Name="BASLANGICTARIHI" ShowInCustomizationForm="True" VisibleIndex="5" Width="91px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="DURUM" FieldName="POTADURUM" Name="POTADURUM" ShowInCustomizationForm="True" VisibleIndex="6" Width="61px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ISKARTATAR" FieldName="ISKARTATARIHI" Name="ISKARTATARIHI" ShowInCustomizationForm="True" VisibleIndex="7" Width="91px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="GAZTAPASIDS" FieldName="GAZTAPASIDS" Name="GAZTAPASIDS" ShowInCustomizationForm="True" VisibleIndex="8" Width="90px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ÜSTNOZULDS" FieldName="USTNOZULDS" Name="USTNOZULDS" ShowInCustomizationForm="True" VisibleIndex="9" Width="90px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ALTNOZULDS" FieldName="ALTNOZULDS" Name="ALTNOZULDS" ShowInCustomizationForm="True" VisibleIndex="10" Width="90px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="SÜRGÜDS" FieldName="SURGUDS" Name="SURGUDS" ShowInCustomizationForm="True" VisibleIndex="11" Width="65px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="SÜRGÜFİRMA" FieldName="SURGUFIRMA" Name="SURGUFIRMA" ShowInCustomizationForm="True" VisibleIndex="12" Width="86px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="SÜRGÜPLKT/Y" FieldName="SURGUPLKTY" Name="SURGUPLKTY" ShowInCustomizationForm="True" VisibleIndex="13" Width="90px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="ÇIKIŞSAAT" FieldName="POTACIKISSAATI" Name="POTACIKISSAATI" ShowInCustomizationForm="True" VisibleIndex="14" Width="70px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="GELİŞSAAT" FieldName="POTAGELISSAATI" Name="POTAGELISSAATI" ShowInCustomizationForm="True" VisibleIndex="15" Width="70px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="KONTROLEDEN" FieldName="KONTROLEDEN" Name="KONTROLEDEN" ShowInCustomizationForm="True" VisibleIndex="16" Width="130px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                                <dxe:GridViewDataTextColumn Caption="AÇIKLAMA" FieldName="ACIKLAMA" Name="ACIKLAMA" ShowInCustomizationForm="True" VisibleIndex="17" Width="135px">
                                                                                </dxe:GridViewDataTextColumn>
                                                                            </Columns>
                                                                            <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                                                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                                                </Header>
                                                                                <LoadingPanel ImageSpacing="5px">
                                                                                </LoadingPanel>
                                                                                <FixedColumn BackColor="#E4EFFA">
                                                                                </FixedColumn>
                                                                            </Styles>
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
                                                                        </dxe:ASPxGridView>
                                                                    </dxe:PanelContent>
                                                                </PanelCollection>
                                                            </dxe:ASPxCallbackPanel>
                                                            <br />
                                                            <div class="clear"></div>
                                                        </div>
                                                        <div class="clear"></div>
                                                    </div>
                                                </dxe:PanelContent>
                                            </PanelCollection>
                                        </dxe:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                            <%-- ANALİZ--%>
                            <dx:TabPage Text="ANALİZ">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel15" runat="server" Width="942px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_analiz_kayit" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_analiz_kayit"
                                                                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                                                                    CssPostfix="Office2003Blue"
                                                                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css" CssClass="BtnDizaynn"
                                                                    Text="KAYIT" ImageSpacing="10px" Theme="Youthful" Width="96px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {  ASPxCallbackPanel_Analiz.PerformCallback('analiz_kayit'); }" />
                                                                    <Image Url="~/Images/Sakla.png">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel16" runat="server" Height="532px" Width="936px">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_Analiz" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_Analiz" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_Analiz_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table class="auto-style17">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="Roundpanel_analiz" runat="server"
                                                                                ClientInstanceName="Roundpanel_analiz"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ANALİZ ARALIKLARI1"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="63px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="Grd_analiz1" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="Grd_analiz1"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="374px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM"
                                                                                                    VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri6" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>

                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="Analiz_msg" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="Analiz_msg" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                                                        <td class="style7">
                                                                            <dx:ASPxRoundPanel ID="Roundpanel_analiz2" runat="server"
                                                                                ClientInstanceName="Roundpanel_analiz2"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="ANALİZ ARALIKLARI2"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Theme="Office2010Silver" CssClass="auto-style13">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="Grd_analiz2" runat="server"
                                                                                            AutoGenerateColumns="False" ClientInstanceName="Grd_analiz2"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="BILGITNM"
                                                                                            Width="374px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="BİLGİ TANIMI" FieldName="BILGITNM"
                                                                                                    Name="BILGITNM" VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DEĞERİ" FieldName="DEGERI" Name="DEGERI"
                                                                                                    ToolTip="DEĞERİ" VisibleIndex="2" Width="70px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri7" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("DEGERI")%>' Width="80px"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="25"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="600" />
                                                                                            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                                                                <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                                                                </LoadingPanelOnStatusBar>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
                                                                                                </LoadingPanel>
                                                                                            </Images>
                                                                                            <ImagesFilterControl>
                                                                                                <LoadingPanel Url="~/App_Themes/Office2010Silver/GridView/Loading.gif">
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </dx:PanelContent>
                                                        </PanelCollection>
                                                    </dx:ASPxCallbackPanel>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                            <%-- TARİH/VARDİYA DEĞİŞTİR--%>
                            <dx:TabPage Text="TARİH/VARDİYA DEĞİŞTİR">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxPanel ID="ASPxPanel17" runat="server" Width="942px" Theme="Office2010Silver">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="style6">
                                                                <dx:ASPxButton ID="Btn_vrd_tarih_change" runat="server" AutoPostBack="False"
                                                                    ClientInstanceName="Btn_vrd_tarih_change"
                                                                    CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css"
                                                                    CssPostfix="Office2003Blue"
                                                                    SpriteCssFilePath="~/App_Themes/Office2003Blue/{0}/sprite.css" CssClass="BtnDizaynn"
                                                                    Text="Değişiklik yap" ImageSpacing="10px" Theme="Youthful" Width="136px" Height="35px" Visible="False">
                                                                    <ClientSideEvents Click="function(s, e) {   ASPxCallbackPanel_Dokum_Ozellikleri.PerformCallback('dokum_ozellik_change'); }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                        <dx:ASPxPanel ID="ASPxPanel18" runat="server" Height="532px" Width="936px" Style="margin-top: 4px;">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel_Dokum_Ozellikleri" runat="server" Width="289px"
                                                        ClientInstanceName="ASPxCallbackPanel_Dokum_Ozellikleri" CssClass="style6" Theme="Office2010Silver" OnCallback="ASPxCallbackPanel_Dokum_Ozellikleri_Callback">
                                                        <PanelCollection>
                                                            <dx:PanelContent>
                                                                <table class="auto-style17">
                                                                    <tr>
                                                                        <td class="style6">
                                                                            <dx:ASPxRoundPanel ID="Roundpanel_vrd_degistir" runat="server"
                                                                                ClientInstanceName="Roundpanel_vrd_degistir"
                                                                                CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver"
                                                                                GroupBoxCaptionOffsetY="-25px" HeaderText="DÖKÜM ÖZELLİKLERİ"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css"
                                                                                Width="63px" Theme="Office2010Silver" CssClass="auto-style14">
                                                                                <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
                                                                                <HeaderStyle>
                                                                                    <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px"
                                                                                        PaddingRight="2px" />
                                                                                </HeaderStyle>
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent runat="server">
                                                                                        <dx:ASPxGridView ID="Grd_dokum_ozellikleri" runat="server" AutoGenerateColumns="False"
                                                                                            ClientInstanceName="Grd_dokum_ozellikleri"
                                                                                            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                                                            CssPostfix="Office2010Blue" EnableTheming="False" KeyFieldName="SARJTIP"
                                                                                            Width="414px" Enabled="False">
                                                                                            <Columns>
                                                                                                <dx:GridViewDataTextColumn Caption="DÖKÜM NUMARASI" FieldName="DOKUMNO" Name="DOKUMNO"
                                                                                                    VisibleIndex="0" Width="100px">
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="VARDİYA" FieldName="vardiya"
                                                                                                    Name="vardiya" VisibleIndex="1" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri_vrd" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("vardiya")%>' Width="80px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                                <dx:GridViewDataTextColumn Caption="DÖKÜM TARİHİ" FieldName="dokumtarihi" Name="dokumtarihi"
                                                                                                    ToolTip="DOKUMTARIHI" VisibleIndex="2" Width="100px">
                                                                                                    <DataItemTemplate>
                                                                                                        <asp:TextBox ID="txtDegeri_dokumtarihi" runat="server" CssClass="txt_css"
                                                                                                            Text='<%#Eval("dokumtarihi")%>' Width="90px" onkeypress="return onlyNumbers();"></asp:TextBox>
                                                                                                    </DataItemTemplate>
                                                                                                </dx:GridViewDataTextColumn>
                                                                                            </Columns>
                                                                                            <SettingsPager AlwaysShowPager="True" NumericButtonCount="25" PageSize="35"
                                                                                                Visible="False">
                                                                                            </SettingsPager>
                                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="550" />
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

                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                            <dxpc:ASPxPopupControl ID="Dokum_ozellik_msg" runat="server" AllowDragging="True"
                                                                                ClientInstanceName="Dokum_ozellik_msg" CloseAction="CloseButton"
                                                                                CloseOnEscape="true" CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css"
                                                                                CssPostfix="Office2003Silver" EnableHotTrack="False" EnableViewState="False"
                                                                                HeaderText="MESAJ EKRANI" Height="17px" Modal="True" PopupAnimationType="Fade"
                                                                                PopupHorizontalAlign="WindowCenter" PopupHorizontalOffset="40"
                                                                                PopupVerticalAlign="WindowCenter" PopupVerticalOffset="40"
                                                                                SpriteCssFilePath="~/App_Themes/Office2003Silver/{0}/sprite.css" Width="252px" Theme="Youthful">
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
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                        </TabPages>

                        <TabStyle>
                            <HoverStyle BackColor="White">
                            </HoverStyle>
                        </TabStyle>
                    </dx:ASPxPageControl>
                </td>
            </tr>
        </table>

        <span style="color: #FF0066">

            <asp:ImageButton ID="ImageButton1" runat="server" Height="21px"
                ImageUrl="~/Images//AnaSayfa.png" Width="27px" ToolTip="Ana Menüye Dönün" OnClick="ImageButton1_Click" />
        </span>
        <dx:ASPxTextBox ID="txt_dokumno_ref_liste" runat="server" CssClass="txt_dno"
            ClientInstanceName="txt_dokumno_ref_liste" Width="178px">
            <ClientSideEvents GotFocus="function(s, e) {        
                                  ASPxCallbackPanel_ALYAJ.PerformCallback('alyaj_listesi2');
                                 ASPxCallbackPanel_HURDA.PerformCallback('hurda_listesi2');
                                 ASPxCallbackPanel_SARFMALZEMELER.PerformCallback('sarf_liste2');                  
	                             ASPxCallbackPanel_GENELBILGILER.PerformCallback('genel_bilgi_listesi2');
                                 ASPxCallbackPanel_ENERJI.PerformCallback('enerji_listesi2');  
                 }"></ClientSideEvents>
        </dx:ASPxTextBox>
        <dx:ASPxTextBox ID="txt_dokumno_durus_liste" ClientInstanceName="txt_dokumno_durus_liste" CssClass="txt_dno" runat="server" Width="170px">
            <ClientSideEvents GotFocus="function(s, e) {       
                 ASPxCallbackPanel_DURUSLISTE.PerformCallback('durus_liste');    
                 ASPxCallbackPanel_Dokum_Ozellikleri.PerformCallback('dokum_ozellikleri_liste');     
                 }"></ClientSideEvents>
        </dx:ASPxTextBox>
    </form>
</body>
</html>
