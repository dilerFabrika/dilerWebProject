<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="diler.Web.Forms.holding_raporlari.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Diler Holding Demir Çelik Fabrikaları Raporları" />
    <meta name="author" content="Diler" />
    <title>Diler Holding Demir Çelik Fabrikaları Raporları</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!-- Font Icons -->
    <link href="../../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="../../css/material-design-iconic-font.min.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="../../css/waves-effect.css" rel="stylesheet" />

    <link rel="stylesheet" href="../../css/bootstrap.css" />
    <link rel="stylesheet" href="../../css/bootstrap.min2.css" />
    <link rel="stylesheet" href="../../css/index.css" />

    <link rel="stylesheet" href="../../assets/morris/morris.css" />

</head>

<body>
     <form runat="server">
    <!-- Ana menü-->
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#ana-menu"><span class="sr-only"></span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
        <a class="navbar-brand" style="padding: 3px 12px;" href="javascript:void(0)">
            <span>
                <img src="../../images/diler-logo3.png" />
            </span>
        </a>

        <div class="navbar-collapse collapse" id="ana-menu">
            <ul class="nav navbar-nav">
                <li class="active"><a href="../../Default2.aspx" style="line-height: 38px;">Anasayfa</a></li>
                <li><a href="DilerCelikhaneRapor.aspx" style="line-height: 38px;">Çelikhaneler</a></li>
                <li><a href="HaddehaneRapor.aspx" style="line-height: 38px;">Haddehaneler</a></li>
                <li><a href="FilmasinRapor.aspx" style="line-height: 38px;">Filmaşin</a></li>
                <li><a href="KarsilastirmalarRaporu.aspx" style="line-height: 38px;">Karşılaştırmalar Raporu</a></li>
                <li><a href="OrtakRapor.aspx" style="line-height: 38px;">Ortak Raporlar</a></li>
                <li><a href="CHTonajlari.aspx" style="line-height: 38px;">CH Tonajları</a></li>
                <li><a href="HHTonajlari.aspx" style="line-height: 38px;">HH Tonajları</a></li>
            </ul>
        </div>
    </div>

    <div class="col-sm-12" style="margin-top: 60px; font-size: 16px;">
        DEMİR ÇELİK FABRİKALARI RAPORLARI
    </div>
    <!-- Header-->
    <div class="col-sm-12 jumbotron ust" style="margin-top: 3px; padding: 0;">
        <div class="container2">
            <!--<h1>DilerHld</h1>-->
            <script src="../../js/jssor.slider-25.2.1.min.js" type="text/javascript"></script>
            <script type="text/javascript">
                jssor_1_slider_init = function () {

                    var jssor_1_SlideshowTransitions = [
                      { $Duration: 1200, x: -0.3, $During: { $Left: [0.3, 0.7] }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                      { $Duration: 1200, x: 0.3, $SlideOut: true, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 }
                    ];

                    var jssor_1_options = {
                        $AutoPlay: 1,
                        $SlideshowOptions: {
                            $Class: $JssorSlideshowRunner$,
                            $Transitions: jssor_1_SlideshowTransitions,
                            $TransitionsOrder: 1
                        },
                        $ArrowNavigatorOptions: {
                            $Class: $JssorArrowNavigator$
                        },
                        $ThumbnailNavigatorOptions: {
                            $Class: $JssorThumbnailNavigator$,
                            $Cols: 1,
                            $Orientation: 2,
                            $Align: 0,
                            $NoDrag: true
                        }
                    };

                    var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

                    /*#region responsive code begin*/
                    function ScaleSlider() {
                        var containerElement = jssor_1_slider.$Elmt.parentNode;
                        var containerWidth = containerElement.clientWidth;
                        if (containerWidth) {
                            var MAX_WIDTH = 980;

                            var expectedWidth = containerWidth;

                            if (MAX_WIDTH) {
                                expectedWidth = Math.min(MAX_WIDTH, expectedWidth);
                            }

                            jssor_1_slider.$ScaleWidth(expectedWidth);
                        }
                        else {
                            window.setTimeout(ScaleSlider, 30);
                        }
                    }

                    ScaleSlider();
                    $Jssor$.$AddEvent(window, "load", ScaleSlider);
                    $Jssor$.$AddEvent(window, "resize", ScaleSlider);
                    $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
                    /*#endregion responsive code end*/
                };
            </script>
            <style>
                .jssora061 {
                    display: block;
                    position: absolute;
                    cursor: pointer;
                }

                    .jssora061 .a {
                        fill: none;
                        stroke: #fff;
                        stroke-width: 360;
                        stroke-linecap: round;
                    }

                    .jssora061:hover {
                        opacity: .8;
                    }

                    .jssora061.jssora061dn {
                        opacity: .5;
                    }

                    .jssora061.jssora061ds {
                        opacity: .3;
                        pointer-events: none;
                    }
            </style>
            <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 980px; height: 380px; overflow: hidden; visibility: hidden;">
                <!-- Loading Screen -->
                <div data-u="loading" style="position: absolute; top: 0px; left: 0px; background: url('img/loading.gif') no-repeat 50% 50%; background-color: rgba(0, 0, 0, 0.7);"></div>
                <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 980px; height: 380px; overflow: hidden;">
                    <div>
                         <img src="../../css/images/r0.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                          <img src="../../css/images/r1.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                     <img src="../../css/images/r2.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                        <img src="../../css/images/r3.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                                  <img src="../../css/images/r4.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                           <img src="../../css/images/r5.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                                <img src="../../css/images/r6.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                          <img src="../../css/images/r7.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                               <img src="../../css/images/r8.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                          <img src="../../css/images/r9.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                           <img src="../../css/images/r10.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                                  <img src="../../css/images/r11.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                    <div>
                    <img src="../../css/images/r12.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>

                          <div>
                       <img src="../../css/images/r13.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                          <div>
                    <img src="../../css/images/r14.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                                <div>
                    <img src="../../css/images/r15.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                                <div>
                    <img src="../../css/images/r16.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                                <div>
                    <img src="../../css/images/r17.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                                  <div>
                    <img src="../../css/images/r18.png" alt="" />
                        <div u="thumb">Demir Çelik sektörünün sıcak gücü</div>
                    </div>
                </div>
                <!-- Thumbnail Navigator -->
                <div u="thumbnavigator" style="position: absolute; bottom: 0px; left: 0px; width: 980px; height: 50px; color: #FFF; overflow: hidden; cursor: default; background-color: rgba(0,0,0,.5);">
                    <div u="slides">
                        <div u="prototype" style="position: absolute; top: 0; left: 0; width: 980px; height: 50px;">
                            <div u="thumbnailtemplate" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; font-family: verdana; font-weight: normal; line-height: 50px; font-size: 16px; padding-left: 10px; box-sizing: border-box;"></div>
                        </div>
                    </div>
                </div>
                <!-- Arrow Navigator -->
                <div data-u="arrowleft" class="jssora061" style="width: 55px; height: 55px; top: 0px; left: 25px;" data-autocenter="2" data-scale="0.75" data-scale-left="0.75">
                    <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                        <path class="a" d="M11949,1919L5964.9,7771.7c-127.9,125.5-127.9,329.1,0,454.9L11949,14079"></path>
                    </svg>
                </div>
                <div data-u="arrowright" class="jssora061" style="width: 55px; height: 55px; top: 0px; right: 25px;" data-autocenter="2" data-scale="0.75" data-scale-right="0.75">
                    <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                        <path class="a" d="M5869,1919l5984.1,5852.7c127.9,125.5,127.9,329.1,0,454.9L5869,14079"></path>
                    </svg>
                </div>
                <div style="clear: both;"></div>
            </div>
            <script type="text/javascript">jssor_1_slider_init();</script>
            <!-- #endregion Jssor Slider End -->

            <!--<a class="btn btn-danger btn-lg" role="button"><b class="glyphicon glyphicon-edit f2"></b>&nbsp;&nbsp; Konuya Git &nbsp;&nbsp;</a>-->
        </div>
    </div>

  

    <div class="col-sm-12">

        <div class="col-xs12 col-sm-12 col-md-12">

            <div class="col-xs12 col-sm-12 col-md-6">
                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Uretim CH Aylık</h3>
                    </div>
                    <div class="panel-body">
                        <div id="chartContainer" style="height: 300px;"></div>
                    </div>
                </div>
            </div>

            <div class="col-xs12 col-sm-12 col-md-6">
                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Uretim HH Aylık </h3>
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

            <div class="col-xs12 col-sm-12 col-md-6">
                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Uretim CH Yıllık </h3>
                    </div>
                    <div class="panel-body">
                        <div id="chartContainer3" style="height: 300px;"></div>
                    </div>
                </div>
            </div>

            <div class="col-xs12 col-sm-12 col-md-6">
                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Uretim HH Yıllık </h3>
                    </div>
                    <div class="panel-body">
                        <div id="chartContainer-4" style="height: 300px;"></div>
                    </div>
                </div>
            </div>

        
            <div class="temiz"></div>
        </div>
       

        <div class="temiz"></div>
    </div>

    <div class="col-sm-12">
               <div class="col-xs12 col-sm-12 col-md-12">
              <div class="panel panel-border panel-primary">
              <div class="panel-heading">
                            <h3 class="panel-title">Diler Üretim Planlama</h3>
                        </div>
              <div class="col-xs12 col-sm-12 col-md-3"></div>
              <div class="col-xs12 col-sm-12 col-md-4">  <table class="table" style="padding: 0; margin: 0; border: none;  height: 50px;">
                          
                        <tbody style="border: none;">
                            <tr>
                                <td style="width:105px" >
                                    <div class="col-xs12 col-sm-12 col-md-2">

                                        <asp:Button ID="btn_telcubuk" runat="server" Text="Tel Çubuk Hadde" CssClass="btn-danger"
                                            Style="width:220px; height: 35px; border: 0px;  font-size: 15px; font-weight: bold; background-color: #3fa0d7" />
                                    </div>
                                </td>
                                <td style="width:56px">
                                    <div class="col-xs12 col-sm-12 col-md-2">

                                        <asp:Button ID="btn_cubuk" runat="server" Text="Çubuk Hadde" CssClass="btn-danger"
                                            Style="width:220px; height: 35px; border: 0px;  font-size: 15px; font-weight: bold; background-color: #d881ec" />
                                    </div>
                                </td>
                                <td style="width:120px"">
                                    <div class="col-xs12 col-sm-12 col-md-2">

                                        <asp:Button ID="btn_celikhane" runat="server" Text="Çelikhane" CssClass="btn-danger"
                                            Style="width:220px; height: 35px; border: 0px;font-size: 15px; font-weight: bold; background-color: #d09c39" />
                                         <asp:TextBox ID="txt_tarih" runat="server" style="opacity:0"  ></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                            
                    </table></div>
              <div class="col-xs12 col-sm-12 col-md-4"></div>
                  </div>
                   </div>

         </div>


    <div class="col-sm-12 alt f2">
        <p style="text-align:center; vertical-align:middle">Copyright © Diler Holding 2017. Tüm hakları saklıdır.</p>
    </div>

    <!-- jQuery  -->
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../js/waves.js" type="text/javascript"></script>
    <script src="../../js/wow.min.js" type="text/javascript"></script>


    <script src="../../js/canvasjs.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../js/holding_rapor.js"></script>

 <script type="text/javascript">

     $(document).ready(function () {

         $("#btn_telcubuk").click(function () {
             var tarih = $("#txt_tarih").val();
             var adres = ("../../URETIMPROGRAMI/THH" + tarih + ".pdf").toString();
             window.open(adres);

         });

         $("#btn_cubuk").click(function () {
             var tarih = $("#txt_tarih").val();
             var adres = ("../../URETIMPROGRAMI/CHH" + tarih + ".pdf").toString();
             window.open(adres);

         });

         $("#btn_celikhane").click(function () {
             var tarih = $("#txt_tarih").val();
             var adres = ("../../URETIMPROGRAMI/CH" + tarih + ".pdf").toString();
             window.open(adres);

         });
     });

        </script>
</form>
</body>

</html>