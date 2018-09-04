<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="diler.Web.Default2" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Base Css Files -->

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/bootstrap.min2.css" />
    <link rel="stylesheet" href="css/index.css" />

    <link rel="stylesheet" href="assets/morris/morris.css" />


    <%--***************--%>

    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Icons -->
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="css/material-design-iconic-font.min.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="css/waves-effect.css" rel="stylesheet" />

    <!-- Responsive-table -->

    <link href="assets/responsive-table/rwd-table.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/helper.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/rapor_style.css" rel="stylesheet" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script> 
        <![endif]-->


    <style type="text/css">
        .style6 {
            height: 70px;
        }

        .style7 {
            height: 60px;
        }

        .style12 {
            height: 48px;
        }

        .style13 {
            height: 20px;
            text-align: center;
        }

        .style14 {
            color: #3399FF;
            font-weight: bold;
            font-size: small;
            font-family: Tahoma;
        }

        .style15 {
            height: 18px;
            text-align: center;
            width: 352px;
            color: #3399FF;
            font-weight: bold;
            font-size: small;
            font-family: Tahoma;
        }

        .style16 {
            height: 20px;
            text-align: center;
            font-size: small;
            width: 352px;
        }

        .style17 {
            height: 70px;
            width: 352px;
        }

        .style18 {
            width: 352px;
            height: 143px;
        }

        .style19 {
            height: 18px;
            font-weight: bold;
            font-family: Tahoma;
            color: #3399FF;
            font-size: small;
            text-align: center;
        }

        .style20 {
            height: 70px;
            width: 279px;
        }

        .style21 {
            width: 279px;
            height: 143px;
        }

        .style22 {
            height: 20px;
            text-align: center;
            width: 279px;
        }

        .style23 {
            height: 18px;
            width: 279px;
            text-align: center;
        }

        .style24 {
            width: 279px;
            height: 4px;
        }

        .style25 {
            width: 352px;
            height: 4px;
        }

        .style26 {
            height: 4px;
        }

        .style27 {
            height: 143px;
        }

        .style28 {
            height: 432px;
            text-align: center;
            width: 279px;
        }

        .style29 {
            height: 432px;
            text-align: center;
            font-size: small;
            width: 352px;
        }

        .style30 {
            height: 432px;
            text-align: center;
        }

        .auto-style1 {
            width: 951px;
            height: 833px;
        }

        .auto-style4 {
            width: 951px;
            height: 25px;
            font-weight: bold;
            text-align: left;
        }

        div.table-responsive .table thead tr th {
            background-color: #e2e9f3;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        img {
            max-width: 100%;
            height: auto;
        }

        .auto-style5 {
            left: 0px;
            top: 0px;
        }
    </style>

    <div style="z-index: 1; left: 196px; top: 52px; position: absolute; height: 845px; width: 1650px">
        <!-- Slider-->
        <div id="intro">
            <div class="shell">
                <div class="slider-holder">
                    <ul>
                        <!-- Slider resimleri -->
                        <li>
                            <div class="post-image">
                                <img src="css/images/r0.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>
                        <!-- /1. slider resmi sonu-->

                        <!-- 2 . slider başlangıcı -->
                        <li>
                            <div class="post-image">
                                <img src="css/images/r1.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>
                        <!-- /2. slider sonu -->

                        <!-- 3.slider başlangıcı -->
                        <li>
                            <div class="post-image">
                                <img src="css/images/r2.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>
                        <!-- /3. slider sonu -->


                        <!-- 4 . slider başlangıcı -->
                        <li>
                            <div class="post-image">
                                <img src="css/images/r3.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>
                        <!-- /4. slider sonu -->

                        <li>
                            <div class="post-image">
                                <img src="css/images/r4.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>


                        <li>
                            <div class="post-image">
                                <img src="css/images/r5.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r6.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>

                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r7.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r8.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r9.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r10.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r11.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r12.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r13.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r14.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>

                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r15.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r16.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>

                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r17.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>

                            </div>
                        </li>

                        <li>
                            <div class="post-image">
                                <img src="css/images/r18.png" alt="" />
                            </div>
                            <div class="post-data">
                                <h2>Demir Çelik sektörünün sıcak gücü</h2>
                            </div>
                        </li>
                    </ul>

                    <div class="slider-frame">&nbsp;</div>
                </div>

            </div>

        </div>

        <div id="main" style="border-bottom: 0px solid #d5d7d3;">

            <div class="col-sm-12">
                <div class="col-xs12 col-sm-12 col-md-12">

                    <div class="col-xs12 col-sm-12 col-md-6">
                        <div class="panel panel-border panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Uretim CH <a href="javascript:void(0);" style="float: right; clear: right;" class="grafik_degis" title="Yıllık">
                                  
                                   <input class="btn" type="button" value="Yıllık" style=" height: 30px; font-size: 12px; font-weight: bold; color: #ffffff; border: 1px solid #337ab7; background-color: #337ab7;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <div id="chartContainer" style="height: 300px;"></div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs12 col-sm-12 col-md-6">
                        <div class="panel panel-border panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Uretim HH <a href="javascript:void(0);" style="float: right; clear: right;" class="grafik_degis" title="Yıllık">
                                         <input class="btn" type="button" value="Yıllık" style=" height: 30px; font-size: 12px; font-weight: bold; color: #ffffff; border: 1px solid #337ab7; background-color: #337ab7;"  /></a></h3>
                            </div>
                            <div class="panel-body">
                                <div id="chartContainer-2" style="height: 300px;"></div>
                            </div>
                        </div>
                    </div>

                    <div class="temiz"></div>
                </div>
                <div class="temiz"></div>
            </div>

            <div class="col-sm-12">
                <div class="col-xs12 col-sm-12 col-md-12">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs6">
                        <h3 style="text-align: center"></h3>

                        <div>
                            <%--<img src="img/haber_logo1.png"" alt="" style="width: 405px; margin-bottom:43px; height: 85px;"/>--%>
                        </div>

                        <%--  <div class="entry" style="width: 485px">--%>
                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body" style="padding: 0">
                                <p class="tbl_baslik" style="background-color: #F00; color: #FFF; margin-bottom: 0px; font-size: 14px">DUYURULAR</p>
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-61" class="table table-bordered table-striped haber_takip">
                                        <thead>
                                            <tr>
                                                <th>Haber</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_haber_takip" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                        <%-- </div>--%>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs6">
                        <h3 style="padding-left: 144px"></h3>

                        <div>
                            <%--<img src="img/yemek.Jpeg" alt="" style="margin-bottom: 5px; height: 120px;" />--%>
                        </div>

                        <div class="panel panel-border panel-primary" style="border-color: #ffffff">
                            <div class="panel-body" style="padding: 0">
                                <p class="tbl_baslik" style="background-color: #F00; color: #FFF; margin-bottom: 0PX; font-size: 14px">YEMEK LİSTESİ</p>
                                <div class="table-responsive" data-pattern="priority-columns">
                                    <table id="tech-companies-1" class="table table-bordered table-striped ">
                                        <thead>
                                            <tr>
                                                <th>Gün</th>
                                                <th>Menü</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="ph_yemek_takip" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">

                <div class="col-lg-6 col-md-6 col-sm-6 col-xs6">
                    <h3 style="padding-left: 144px"></h3>

                    <div>
                        <img src="img/dosis.png" alt="" style="width: 805px; margin-bottom: 5px; height: 130px;" />

                    </div>

                    <div class="panel panel-border panel-primary" style="border-color: #e2e9f3">
                        <div class="panel-body" style="padding: 0">
                            <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-51" class="table table-bordered table-striped ">
                                    <thead>
                                        <tr>
                                            <th>Dösis</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_dosis_takip" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6 col-xs6">
                    <h3 style="padding-left: 144px"></h3>
                    <div>
                        <img src="Images/adsız.JPG" alt="" style="width: 805px; margin-bottom: 5px; height: 130px;" />

                    </div>

                    <div class="panel panel-border panel-primary" style="border-color: #e2e9f3">
                        <div class="panel-body" style="padding: 0">
                            <!--<p class="tbl_baslik" style="background-color: #F00; color: #FFF;">Diler</p>-->
                            <div class="table-responsive" data-pattern="priority-columns">
                                <table id="tech-companies-18" class="table table-bordered table-striped ">
                                    <thead>
                                        <tr>
                                            <th>5S</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ph_bes_takip" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>





                </div>

            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs12">



                <asp:Button ID="btn_show_hrapor" runat="server" Text="Holding raporları" CssClass="btn-danger"
                    Style="width: 180px; height: 35px; border: 0px; margin-top: 15px; font-size: 15px; font-weight: bold; background-color: #88b6f5" OnClick="btn_show_hrapor_Click" />


            </div>

        </div>
    </div>


    <!-- jQuery  -->
    <%--   <script src="js/jquery.min.js" type="text/javascript"></script>--%>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/canvasjs.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/anasayfa_js.js"></script>
    
</asp:Content>
