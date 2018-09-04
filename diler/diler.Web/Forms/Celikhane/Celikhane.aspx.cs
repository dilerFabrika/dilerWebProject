using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using diler.Dal;
using diler.Entity;
namespace diler.Web
{
    public partial class celikhanex : System.Web.UI.Page
    {

        dynamic gun_kontrol;
        dynamic DonenDeger;
        dynamic KULLANICI;
        public string gelentarih, gelen_durus_kodu;
        public string tarih_parse;
        public string message;
        public int hurda_miktar;
        Celikhane_db database = new Celikhane_db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Cmb_Celikcinsii.Text = "S 220";
                txt_dkmtip.Text = "AC";
                Txt_tarih.Value = DateTime.Today;
                KULLANICI = Session["KULLANICI"];
                Btn_Refrakteryeni.Visible = false;
                Btn_hurdasakla.Visible = false;
                ANATAB.TabPages[0].Visible = false; //Üretim
                ANATAB.TabPages[1].Visible = true;  //Genel bilgi
                ANATAB.TabPages[2].Visible = true; //Enerji
                ANATAB.TabPages[3].Visible = true; //Sarf
                ANATAB.TabPages[4].Visible = true;  //Hurda
                ANATAB.TabPages[5].Visible = true;  //Alyaj
                ANATAB.TabPages[6].Visible = false;  //Duruş
                ANATAB.TabPages[7].Visible = false; //Refrakter
                ANATAB.TabPages[8].Visible = false; //Analiz
                ANATAB.TabPages[9].Visible = false; //TARİH/VARDİYA DEĞİŞTİR
                Btn_Refraktersakla.Visible = false;
                GRD_CH_SARFMLZ_AO.Enabled = false;


                if (KULLANICI == "CHAOOPR")
                {
                    GRD_CH_GENELBILGILER_AO.Enabled = true;
                    GRD_CH_ENERJI_AO.Enabled = true;
                    GRD_CH_SARFMLZ_AO.Enabled = true;
                    GRD_CH_HURDA.Enabled = true;
                    GRD_CH_ALYAJ_AO.Enabled = true;
                    Btn_genelbilgisakla.Visible = true;
                    ANATAB.TabPages[6].Visible = true; //Duruş
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                    ANATAB.TabPages[9].Visible = true; //TARİH/VARDİYA DEĞİŞTİR
                    Btn_durusSakla.Visible = true;
                    Btn_alyajsakla.Visible = true;
                    Btn_hurdasakla.Visible = true;
                    Btn_sarfsakla.Visible = true;
                    Btn_enerjisakla.Visible = true;
                    Btn_vrd_tarih_change.Visible = true;
                    Grd_dokum_ozellikleri.Enabled = true;
                }
                if (KULLANICI == "D1947")  //Kenan Kırboğa görüyor
                {
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                }
                if (KULLANICI == "D1001641")  //Mehmet Ali Tosun görüyor
                {
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                    ANATAB.TabPages[0].Visible = true;//Üretim
                    ANATAB.TabPages[6].Visible = true;  //Duruş
                    Btn_Uretimsakla.Visible = false;
                    Btn_dokumac.Visible = false;
                    Btn_dkmsira_delete.Visible = false;
                    Btn_yenidurus.Visible = false;
                    Btn_Sablon.Visible = false;
                    Btn_durus_sil.Visible = false;

                }
                if (KULLANICI == "D1003081")  //özgür incesu görüyor
                {
                    ANATAB.TabPages[0].Visible = true;//Üretim
                    ANATAB.TabPages[8].Visible = true; //Analiz
                    Grd_analiz1.Enabled = true;
                    Grd_analiz2.Enabled = true;
                    Btn_analiz_kayit.Visible = true;

                }
                if (KULLANICI == "D2587")  //Onur meydan görüyor
                {

                    ANATAB.TabPages[0].Visible = true;//Üretim

                    Btn_Uretimsakla.Visible = false;
                    Btn_dokumac.Visible = false;
                    Btn_dkmsira_delete.Visible = false;


                }
                if (KULLANICI == "CHPOOPR")
                {
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                    ANATAB.TabPages[8].Visible = true; //Analiz
                    GRD_CH_GENELBILGILER_PO.Enabled = true;
                    GRD_CH_ENERJI_PO.Enabled = true;
                    GRD_CH_ALYAJ_PO.Enabled = true;
                    Btn_genelbilgisakla.Visible = true;
                    Btn_alyajsakla.Visible = true;
                    Btn_enerjisakla.Visible = true;


                }
                if (KULLANICI == "CHSDMOPR")
                {
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                    GRD_CH_GENELBILGILER_SDM.Enabled = true;
                    GRD_CH_SARFMLZ_SDM.Enabled = true;
                    Btn_genelbilgisakla.Visible = true;
                    Btn_sarfsakla.Visible = true;

                }
                if (KULLANICI == "OPRKIM")
                {

                    ANATAB.TabPages[0].Visible = true; //Üretim
                    ANATAB.TabPages[8].Visible = true; //Analiz
                    Grd_analiz1.Enabled = true;
                    Grd_analiz2.Enabled = true;
                    Btn_analiz_kayit.Visible = true;
                    txt_DokumNo.ReadOnly = false;
                    btn_dokum_cagir.Visible = true;
                    btn_dokum_kapat.Visible = true;

                }
                if (KULLANICI == "CHREFOPR")
                {
                    ANATAB.TabPages[7].Visible = true; //Refrakter
                    Btn_Refraktersakla.Visible = true;
                    Btn_Refrakteryeni.Visible = true;
                    Btn_refrakter_dokum_sil.Visible = true;
                    //GRD_REFRAKTER.Enabled = false;
                    txt_DokumNo.Visible = false;
                    Label1.Visible = false;

                }


            }
            else
            {
                KULLANICI = Session["KULLANICI"];
            }
            kutukboy_comboDoldur();
            kutukEbat_comboDoldur();
            kalite_comboDoldur();
            durusNeden_cmbDoldur();
            arizaNeden_cmbDoldur();


        }

        public void dokum_listesi()
        {
            database.connect();
            List<uretim_bilgileri> dokumler = new List<uretim_bilgileri>();
            dokumler = database.dokum_listesi(Convert.ToDateTime(Txt_tarih.Text));
            GRD_CELIKHANE_DOKUMNO.DataSource = dokumler;
            GRD_CELIKHANE_DOKUMNO.DataBind();
            database.disConnect();
        }

        //Alyaj
        public void alyaj_listesi_ao(object dokum_no)
        {
            database.connect();
            string lokasyon = "AO";
            List<alyaj_bilgileri> alyaj_listesi_veriler = new List<alyaj_bilgileri>();
            alyaj_listesi_veriler = database.alyaj_listesi(dokum_no, lokasyon);
            GRD_CH_ALYAJ_AO.DataSource = alyaj_listesi_veriler;
            GRD_CH_ALYAJ_AO.DataBind();
            database.disConnect();

        }
        public void alyaj_listesi_po(object dokum_no)
        {
            database.connect();
            string lokasyon = "PO";
            List<alyaj_bilgileri> alyaj_listesi_veriler = new List<alyaj_bilgileri>();
            alyaj_listesi_veriler = database.alyaj_listesi(dokum_no, lokasyon);
            GRD_CH_ALYAJ_PO.DataSource = alyaj_listesi_veriler;
            GRD_CH_ALYAJ_PO.DataBind();
            database.disConnect();
        }
        public void alyaj_kayit_ao()
        {
            database.connect();
            string degeri, sarj_tip, lokasyon, MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_ALYAJ_AO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_ALYAJ_AO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_ALYAJ_AO.Columns["DEGERI"], "txtDegeri");
                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                    sarj_tip = GRD_CH_ALYAJ_AO.GetRowValues(i, "SARJTIP").ToString();
                    lokasyon = GRD_CH_ALYAJ_AO.GetRowValues(i, "LOKASYON").ToString();
                    if (degeri != ".")
                    {
                        if (Convert.ToDecimal(degeri) > 0)
                        {
                            MESAJ = database.alyaj_kayit( txt_DokumNo.Text, degeri, sarj_tip, lokasyon);
                            ALYAJ_MSG.Text = "DÖKÜMÜN ALYAJ BİLGİLERİ " + MESAJ;
                            ALYAJ_MSG.ShowOnPageLoad = true;
                        }
                    }

                }
            }

            else
            {
                ALYAJ_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                ALYAJ_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();

        }
        public void alyaj_kayit_po()
        {
            database.connect();
            string degeri, sarj_tip, lokasyon, MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_ALYAJ_PO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_ALYAJ_PO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_ALYAJ_PO.Columns["DEGERI"], "txtDegeri");

                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                    sarj_tip = GRD_CH_ALYAJ_PO.GetRowValues(i, "SARJTIP").ToString();
                    lokasyon = GRD_CH_ALYAJ_PO.GetRowValues(i, "LOKASYON").ToString();
                    if (degeri != ".")
                    {
                        if (Convert.ToDecimal(degeri) > 0)
                        {
                            MESAJ = database.alyaj_kayit( txt_DokumNo.Text, degeri, sarj_tip, lokasyon);
                            ALYAJ_MSG.Text = "DÖKÜMÜN ALYAJ BİLGİLERİ " + MESAJ;
                            ALYAJ_MSG.ShowOnPageLoad = true;
                        }
                    }

                }
            }
            else
            {
                ALYAJ_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                ALYAJ_MSG.ShowOnPageLoad = true;
            }

            database.disConnect();
        }

        //Hurda
        public void hurda_listesi(object dokum_no)
        {
            database.connect();
            List<hurda_bilgileri> hurda_listesi_veriler = new List<hurda_bilgileri>();
            hurda_listesi_veriler = database.hurda_listesi(dokum_no);
            List<string> kayitlar = new List<string>();
            kayitlar = database.Toplam_Sarj_(txt_DokumNo.Text);
            Txt_Toplam_sarj1.Text = kayitlar[0];
            Txt_Toplam_sarj2.Text = kayitlar[1];
            Txt_Toplam_sarj3.Text = kayitlar[2];
            Txt_Toplam_sarj4.Text = kayitlar[3];
            Txt_Toplam_sarj.Text = kayitlar[4];
            GRD_CH_HURDA.DataSource = hurda_listesi_veriler;
            GRD_CH_HURDA.DataBind();
            database.disConnect();

        }
        public void hurda_kayit()
        {
            int sarj1_degeri, sarj2_degeri, sarj3_degeri, sarj4_degeri;
            string hurda_tanim;
            for (int i = 0; i <= GRD_CH_HURDA.VisibleRowCount - 1; i++)
            {

                TextBox sarj1 = (TextBox)GRD_CH_HURDA.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_HURDA.Columns["SARJ1"], "SARJ1");
                TextBox sarj2 = (TextBox)GRD_CH_HURDA.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_HURDA.Columns["SARJ2"], "SARJ2");
                TextBox sarj3 = (TextBox)GRD_CH_HURDA.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_HURDA.Columns["SARJ3"], "SARJ3");
                TextBox sarj4 = (TextBox)GRD_CH_HURDA.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_HURDA.Columns["SARJ4"], "SARJ4");

                sarj1_degeri = Convert.ToInt32(sarj1.Text.Equals("") ? "0" : sarj1.Text);
                sarj2_degeri = Convert.ToInt32(sarj2.Text.Equals("") ? "0" : sarj2.Text);
                sarj3_degeri = Convert.ToInt32(sarj3.Text.Equals("") ? "0" : sarj3.Text);
                sarj4_degeri = Convert.ToInt32(sarj4.Text.Equals("") ? "0" : sarj4.Text);

                hurda_tanim = GRD_CH_HURDA.GetRowValues(i, "HURDATIP").ToString();

                if (sarj1_degeri >= 0)
                    hurda_Insert(Convert.ToDateTime(Txt_tarih.Text), txt_DokumNo.Text, 1, hurda_tanim, sarj1_degeri);
                if (sarj2_degeri >= 0)
                    hurda_Insert(Convert.ToDateTime(Txt_tarih.Text), txt_DokumNo.Text, 2, hurda_tanim, sarj2_degeri);
                if (sarj3_degeri >= 0)
                    hurda_Insert(Convert.ToDateTime(Txt_tarih.Text), txt_DokumNo.Text, 3, hurda_tanim, sarj3_degeri);
                if (sarj4_degeri >= 0)
                    hurda_Insert(Convert.ToDateTime(Txt_tarih.Text), txt_DokumNo.Text, 4, hurda_tanim, sarj4_degeri);
            }
        }
        public void hurda_Insert(DateTime tarih, object dokum_no, object sarj_no, object hurda_tanim, int sarj_degeri)
        {
            database.connect();
            string MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(tarih);
            if (gun_kontrol == "True")
            {
                if (sarj_degeri == 0)
                {
                    hurda_miktar = database.hurda_degeri_bul_kayit(tarih, dokum_no, sarj_no, hurda_tanim, sarj_degeri);
                    if (hurda_miktar != 0)
                    {
                        MESAJ = database.hurda_kayit(dokum_no, sarj_no, hurda_tanim, sarj_degeri);

                        HURDA_MSG.Text = "\n" + "DÖKÜMÜN HURDA BİLGİLERİ " + MESAJ;
                        HURDA_MSG.ShowOnPageLoad = true;
                    }
                }
                else
                {

                    MESAJ = database.hurda_kayit(dokum_no, sarj_no, hurda_tanim, sarj_degeri);

                    HURDA_MSG.Text = "\n" + "DÖKÜMÜN HURDA BİLGİLERİ " + MESAJ;
                    HURDA_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                HURDA_MSG.Text = "\n" + " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                HURDA_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }


        //Sarf
        public void sarf_listesi_sdm(object dokum_no)
        {
            database.connect();
            dynamic alan_adi = null;
            List<sarf_bilgileri> sarf_listesi_veriler = new List<sarf_bilgileri>();
            sarf_listesi_veriler = database.Sarf_Listesi(dokum_no);
            GRD_CH_SARFMLZ_SDM.DataSource = sarf_listesi_veriler;
            GRD_CH_SARFMLZ_SDM.DataBind();
            for (int i = 0; i <= GRD_CH_SARFMLZ_SDM.VisibleRowCount - 1; i++)
            {
                alan_adi = GRD_CH_SARFMLZ_SDM.GetRowValues(i, "SARFMLZTNM").ToString();

                TextBox he = (TextBox)GRD_CH_SARFMLZ_SDM.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_SARFMLZ_SDM.Columns["DEGERI4"], "txtDegeri4");
                if (alan_adi == "STARTER TUBE (ADET)")
                {
                    DonenDeger = "6";

                }
            }
            database.disConnect();
        }
        public void sarf_listesi_ao(object dokum_no)
        {
            database.connect();
            string lokasyon = "AO";
            List<sarf_bilgileri> sarf_listesi_veriler = new List<sarf_bilgileri>();
            sarf_listesi_veriler = database.sarf_veriler(dokum_no, lokasyon);
            GRD_CH_SARFMLZ_AO.DataSource = sarf_listesi_veriler;
            GRD_CH_SARFMLZ_AO.DataBind();
            database.disConnect();
        }
        public void sarf_kayit_sdm()
        {
            database.connect();
            string degeri, sarf_malzeme_tanimi, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_SARFMLZ_SDM.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_SARFMLZ_SDM.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_SARFMLZ_SDM.Columns["DEGERI4"], "txtDegeri4");

                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();

                    sarf_malzeme_tanimi = GRD_CH_SARFMLZ_SDM.GetRowValues(i, "SARFMLZTNM").ToString();
                    lokasyon = "SDM";
                    if (degeri != ".")
                    {
                        if (Convert.ToDecimal(degeri) > 0)
                        {
                            mesaj = database.sarf_kayit(txt_DokumNo.Text, degeri, sarf_malzeme_tanimi, lokasyon);
                            SARFMLZ_MSG.Text = "Dökümün Sarf Bilgileri" + mesaj;
                            SARFMLZ_MSG.ShowOnPageLoad = true;
                        }
                    }
                }
            }
            else

            {
                SARFMLZ_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                SARFMLZ_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }
        public void sarf_kayit_ao()
        {
            database.connect();
            string degeri, sarf_malzeme_tanimi, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_SARFMLZ_AO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_SARFMLZ_AO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_SARFMLZ_SDM.Columns["DEGERI4"], "txtDegeri4");
                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                    sarf_malzeme_tanimi = GRD_CH_SARFMLZ_AO.GetRowValues(i, "SARFMLZTNM").ToString();
                    lokasyon = "AO";
                    if (degeri != ".")
                    {
                        if (Convert.ToDecimal(degeri) > 0)
                        {
                            mesaj = database.sarf_kayit( txt_DokumNo.Text, degeri, sarf_malzeme_tanimi, lokasyon);
                            SARFMLZ_MSG.Text = "Dökümün Sarf Bilgileri" + mesaj;
                            SARFMLZ_MSG.ShowOnPageLoad = true;
                        }

                    }

                }
            }
            else

            {
                SARFMLZ_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                SARFMLZ_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }


        //Genelbilgi

        public void genel_bilgi_listesi_sdm(object dokum_no)
        {

            database.connect();
            string lokasyon = "SDM";
            List<genel_bilgiler> genel_bilgi_listesi_veriler = new List<genel_bilgiler>();
            genel_bilgi_listesi_veriler = database.genel_bilgi_listesi(dokum_no, lokasyon);
            GRD_CH_GENELBILGILER_SDM.DataSource = genel_bilgi_listesi_veriler;
            GRD_CH_GENELBILGILER_SDM.DataBind();
            database.disConnect();

        }
        public void genel_bilgi_listesi_ao(object dokum_no)
        {
            database.connect();
            string lokasyon = "AO";
            List<genel_bilgiler> genel_bilgi_listesi_veriler = new List<genel_bilgiler>();
            genel_bilgi_listesi_veriler = database.genel_bilgi_listesi(dokum_no, lokasyon);
            GRD_CH_GENELBILGILER_AO.DataSource = genel_bilgi_listesi_veriler;
            GRD_CH_GENELBILGILER_AO.DataBind();
            database.disConnect();

        }
        public void genel_bilgi_listesi_po(object dokum_no)
        {
            database.connect();
            string lokasyon = "PO";
            List<genel_bilgiler> genel_bilgi_listesi_veriler = new List<genel_bilgiler>();
            genel_bilgi_listesi_veriler = database.genel_bilgi_listesi(dokum_no, lokasyon);
            GRD_CH_GENELBILGILER_PO.DataSource = genel_bilgi_listesi_veriler;
            GRD_CH_GENELBILGILER_PO.DataBind();
            database.disConnect();

        }
        public void genel_bilgi_kayit_sdm()
        {
            database.connect();
            string degeri, bilgi_tanimi, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_GENELBILGILER_SDM.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_SDM.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_SDM.Columns["DEGERI"], "txtDegeri6");
                    degeri = deger.Text;
                    bilgi_tanimi = GRD_CH_GENELBILGILER_SDM.GetRowValues(i, "BILGITNM").ToString();
                    lokasyon = "SDM";
                    if (degeri != "")
                    {
                        mesaj = database.genel_bilgi_kayit(txt_DokumNo.Text, degeri, bilgi_tanimi, lokasyon);

                        GENELBILGI_MSG.Text = "DÖKÜMÜN GENEL BİLGİLERİ " + mesaj;
                        GENELBILGI_MSG.ShowOnPageLoad = true;
                    }
                }
            }

            else
            {
                GENELBILGI_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                GENELBILGI_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();
        }
        public void genel_bilgi_kayit_ao()
        {
            database.connect();
            string degeri, bilgi_tanimi, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_GENELBILGILER_AO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_AO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_AO.Columns["DEGERI"], "txtDegeri7");
                    degeri = deger.Text;
                    bilgi_tanimi = GRD_CH_GENELBILGILER_AO.GetRowValues(i, "BILGITNM").ToString();
                    lokasyon = "AO";
                    if (degeri != "")
                    {
                        mesaj = database.genel_bilgi_kayit(txt_DokumNo.Text, degeri, bilgi_tanimi, lokasyon);

                        GENELBILGI_MSG.Text = "DÖKÜMÜN GENEL BİLGİLERİ " + mesaj;
                        GENELBILGI_MSG.ShowOnPageLoad = true;
                    }

                }

            }
            else
            {
                GENELBILGI_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                GENELBILGI_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }
        public void genel_bilgi_kayit_po()
        {
            database.connect();
            string degeri, bilgi_tanimi, lokasyon,mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {

                for (int i = 0; i <= GRD_CH_GENELBILGILER_PO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    degeri = deger.Text;
                    bilgi_tanimi = GRD_CH_GENELBILGILER_PO.GetRowValues(i, "BILGITNM").ToString();
                    lokasyon = "PO";
                    if (degeri != "")
                    {
                        mesaj = database.genel_bilgi_kayit(txt_DokumNo.Text, degeri, bilgi_tanimi, lokasyon);

                        GENELBILGI_MSG.Text = "DÖKÜMÜN GENEL BİLGİLERİ " + mesaj;
                        GENELBILGI_MSG.ShowOnPageLoad = true;
                    }
        

                }
            }

            else
            {

                GENELBILGI_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                GENELBILGI_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();

        }




        //Enerji
        public void enerji_liste_ao(object dokum_no)
        {
            database.connect();
            string lokasyon = "AO";
            List<genel_bilgiler> enerji_listesi_veriler = new List<genel_bilgiler>();
            enerji_listesi_veriler = database.enerji_liste(dokum_no, lokasyon);
            GRD_CH_ENERJI_AO.DataSource = enerji_listesi_veriler;
            GRD_CH_ENERJI_AO.DataBind();
            database.disConnect();

        }
        public void enerji_liste_po(object dokum_no)
        {
            database.connect();
            string lokasyon = "PO";
            List<genel_bilgiler> enerji_listesi_veriler = new List<genel_bilgiler>();
            enerji_listesi_veriler = database.enerji_liste(dokum_no, lokasyon);
            GRD_CH_ENERJI_PO.DataSource = enerji_listesi_veriler;
            GRD_CH_ENERJI_PO.DataBind();
            database.disConnect();
        }
        public void enerji_kayit_ao()
        {
            database.connect();
            string degeri, bilgi_tanim, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= GRD_CH_ENERJI_AO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_ENERJI_AO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_ENERJI_AO.Columns["DEGERI"], "txtDegeri6");
                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                    bilgi_tanim = GRD_CH_ENERJI_AO.GetRowValues(i, "BILGITNM").ToString();
                    lokasyon = "AO";
                    if (degeri != "0")
                    {
                        mesaj = database.enerji_kayit(txt_DokumNo.Text, degeri, bilgi_tanim, lokasyon);
                        ENERJI_MSG.Text = "DÖKÜMÜN ENERJİ BİLGİLERİ " + mesaj;
                        ENERJI_MSG.ShowOnPageLoad = true;
                    }

                }
            }

            else
            {
                ENERJI_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                ENERJI_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();

        }
        public void enerji_kayit_po()
        {
            database.connect();
            string degeri, bilgi_tanim, lokasyon, mesaj;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {

                for (int i = 0; i <= GRD_CH_ENERJI_PO.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)GRD_CH_ENERJI_PO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_ENERJI_PO.Columns["DEGERI"], "txtDegeri7");
                    degeri = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                    bilgi_tanim = GRD_CH_ENERJI_PO.GetRowValues(i, "BILGITNM").ToString();
                    lokasyon = "PO";
                    if (degeri != "0")
                    {
                        mesaj = database.enerji_kayit(txt_DokumNo.Text, degeri, bilgi_tanim, lokasyon);
                        ENERJI_MSG.Text = "DÖKÜMÜN ENERJİ BİLGİLERİ " + mesaj;
                        ENERJI_MSG.ShowOnPageLoad = true;
                    }

                }
            }
            else
            {
                ENERJI_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                ENERJI_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }


        //Üretim
        public void uretim_liste()
        {
            database.connect();
            string dokum_no = txt_DokumNo.Text;
            List<uretim_bilgileri> uretim_listesi_veriler = new List<uretim_bilgileri>();
            uretim_listesi_veriler = database.uretim_liste(dokum_no);
            GRD_KUTUKURETIM.DataSource = uretim_listesi_veriler;
            GRD_KUTUKURETIM.DataBind();

            database.disConnect();

        }
        public void Dokum_ac()
        {

            database.connect();
            string dokum_durumu, vardiya, MESAJ;
            txt_Sirano.Text = "1";
            vardiya = Cmb_vrd.Text;
            dokum_durumu = "AÇIK";
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (vardiya != "")
                {
                    MESAJ = database.dokum_kayit(txt_Sirano.Text, Convert.ToDateTime(Txt_tarih.Text), vardiya, dokum_durumu);
                    KUTUK_MSG.Text = MESAJ;
                    KUTUK_MSG.ShowOnPageLoad = true;

                }
                else
                {
                    MESAJ = "VARDİYA ALANINI DOLDURUNUZ.";
                    KUTUK_MSG.Text = MESAJ;
                    KUTUK_MSG.ShowOnPageLoad = true;
                }

                Cmb_Celikcinsii.Text = ""; txt_Sirano.Text = "";
                Cmb_Kutukboy.Text = ""; Cmb_KutukEbat.Text = "";
                txt_KutukSayisi.Text = ""; txt_dkmtip.Text = "";
                Cmb_vrd.Text = ""; txt_SarikutukSayisi.Text = "";
                txt_SarikutukTonaji.Text = ""; cmb_KutukGidecekYer.Text = "";
                cmb_sarikutukCelikcinsi.Text = ""; txt_karisimTonaji.Text = "";
                txt_Siparisno.Text = ""; Cmb_sapmanedeni.Text = "";
                cmb_standartDisinedeni.Text = ""; cmb_standartDisiKimyasali.Text = "";
                Cmb_sapmaKimyasali.Text = ""; txt_standartKarisimSayisi.Text = "";
                txt_OzelKod.Text = ""; txt_Genelaciklama.Text = ""; tx_radyoaktivite.Text = "";
                Txt_KutukTonaj.Text = ""; txt_egri_kutuk_sayisi.Text = "";

            }
            else
            {

                KUTUK_MSG.Text = "GÜN KAPANMIŞTIR. DÖKÜM AÇAMAZSINIZ !!";
                KUTUK_MSG.ShowOnPageLoad = true;
            }

            Cmb_Celikcinsii.Text = ""; txt_Sirano.Text = "";
            Cmb_Kutukboy.Text = ""; Cmb_KutukEbat.Text = "";
            txt_KutukSayisi.Text = ""; txt_dkmtip.Text = "";
            Cmb_vrd.Text = ""; txt_SarikutukSayisi.Text = "";
            txt_SarikutukTonaji.Text = ""; cmb_KutukGidecekYer.Text = "";
            cmb_sarikutukCelikcinsi.Text = ""; txt_karisimTonaji.Text = "";
            txt_Siparisno.Text = ""; Cmb_sapmanedeni.Text = "";
            cmb_standartDisinedeni.Text = ""; cmb_standartDisiKimyasali.Text = "";
            Cmb_sapmaKimyasali.Text = ""; txt_standartKarisimSayisi.Text = "";
            txt_OzelKod.Text = ""; txt_Genelaciklama.Text = "";
            Txt_KutukTonaj.Text = ""; tx_radyoaktivite.Text = ""; txt_egri_kutuk_sayisi.Text = "";
            database.disConnect();
        }
        public void dokum_kapat(object gelen_dokum)
        {

            dynamic MESAJ;
            string d3 = "KAPALI";
            // string d3 = "✔";
            if (txt_DokumNo.Text != "")
            {
                int d1 = Convert.ToInt32(txt_DokumNo.Text);
                if (d1 > 0)
                {
                    database.connect();
                    database.dokum_kapat(gelen_dokum, d3);
                    database.disConnect();
                    MESAJ = "DÖKÜM DURUMU KAPATILDI";
                    KUTUK_MSG.Text = MESAJ;
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
                else
                {
                    MESAJ = "DÖKÜM NUMARASI LİSTESİNDEN DÖKÜM SEÇİNİZ";
                    KUTUK_MSG.Text = MESAJ;
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }

        }
        public void uretim_kayit()
        {
            database.connect();
            string sira_no, boy, ebat, kalite, kutuk_sayisi, ozelkod, stn_karisim_sayisi, sapma_element, st_disi_element, st_disi_neden, sapma_nedeni, sari_kutuk_sayisi,
                siparis_no, kutugun_gideceği_yer, tandis_bindirme,
                sari_kutuk_kalite, aciklama, radyo_aktivite, MESAJ, dokum_durumu, vardiya, dokumtip, egri_kutuk_sayisi;
            List<string> uretimDegiskenleri = new List<string>();
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (txt_DokumNo.Text != "0")
                {
                    kutugun_gideceği_yer = cmb_KutukGidecekYer.Text;
                    if (kutugun_gideceği_yer != "")
                    {
                        uretimDegiskenleri = database.uretimdegiskeni_Bul(txt_DokumNo.Text);
                        sira_no = txt_Sirano.Text;
                        boy = Cmb_Kutukboy.Text;
                        ebat = Cmb_KutukEbat.Text;
                        kalite = Cmb_Celikcinsii.Text;
                        kutuk_sayisi = txt_KutukSayisi.Text;
                        dokum_durumu = uretimDegiskenleri[0];
                        vardiya = Cmb_vrd.Text;
                        dokumtip = txt_dkmtip.Text;
                        string kutuk_tonaj = Txt_KutukTonaj.Text.Replace(",", ".").Equals("") ? "0" : Txt_KutukTonaj.Text.Replace(",", ".").ToString();
                        string karisim_tonaj = txt_karisimTonaji.Text.Replace(",", ".").Equals("") ? "0" : txt_karisimTonaji.Text.Replace(",", ".").ToString();
                        ozelkod = txt_OzelKod.Text;
                        stn_karisim_sayisi = txt_standartKarisimSayisi.Text;
                        sapma_element = Cmb_sapmaKimyasali.Text;
                        st_disi_element = cmb_standartDisiKimyasali.Text;
                        st_disi_neden = cmb_standartDisinedeni.Text;
                        sapma_nedeni = Cmb_sapmanedeni.Text;
                        double sari_ktk_tonaj = Convert.ToDouble(txt_SarikutukTonaji.Text.Replace(",", ".").Equals("") ? "0.0" : txt_SarikutukTonaji.Text.Replace(",", ".").ToString());
                        sari_kutuk_sayisi = txt_SarikutukSayisi.Text;
                        siparis_no = txt_Siparisno.Text;
                        sari_kutuk_kalite = cmb_sarikutukCelikcinsi.Text;
                        aciklama = txt_Genelaciklama.Text;
                        radyo_aktivite = tx_radyoaktivite.Text;
                        egri_kutuk_sayisi = txt_egri_kutuk_sayisi.Text;
                        tandis_bindirme = txt_tandis_bindirme.Text;
                        if (Txt_tarih.Text == tx_dokum_tarihi.Text)
                        {
                            MESAJ = database.uretim_kayit(txt_DokumNo.Text, sira_no, Convert.ToDateTime(Txt_tarih.Text), vardiya, ozelkod, siparis_no, kalite, boy,
                           ebat, sapma_nedeni, sapma_element, st_disi_neden, st_disi_element, kutugun_gideceği_yer, kutuk_sayisi, kutuk_tonaj,
                           sari_kutuk_sayisi, sari_ktk_tonaj, sari_kutuk_kalite, stn_karisim_sayisi,
                           karisim_tonaj, aciklama, dokum_durumu, dokumtip, radyo_aktivite, egri_kutuk_sayisi,tandis_bindirme);
                        }
                        else
                        {
                            MESAJ = database.uretim_kayit(txt_DokumNo.Text, sira_no, Convert.ToDateTime(tx_dokum_tarihi.Text), vardiya, ozelkod, siparis_no, kalite, boy,
                          ebat, sapma_nedeni, sapma_element, st_disi_neden, st_disi_element, kutugun_gideceği_yer, kutuk_sayisi, kutuk_tonaj,
                          sari_kutuk_sayisi, sari_ktk_tonaj, sari_kutuk_kalite, stn_karisim_sayisi,
                          karisim_tonaj, aciklama, dokum_durumu, dokumtip, radyo_aktivite, egri_kutuk_sayisi,tandis_bindirme);
                            
                        }

                        KUTUK_MSG.Text = "\n" + MESAJ;
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                    else
                    {
                        KUTUK_MSG.Text = "KÜTÜĞÜN GİDECEĞİ YERİ YAZINIZ !";
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                    //**kimyacı kapat dedi

                    //Cmb_Celikcinsii.Text = ""; txt_Sirano.Text = "";
                    //Cmb_Kutukboy.Text = ""; Cmb_KutukEbat.Text = "";
                    //txt_KutukSayisi.Text = ""; txt_dkmtip.Text = "";
                    //Cmb_vrd.Text = ""; txt_SarikutukSayisi.Text = "";
                    //txt_SarikutukTonaji.Text = ""; cmb_KutukGidecekYer.Text = "";
                    //cmb_sarikutukCelikcinsi.Text = ""; txt_karisimTonaji.Text = "";
                    //txt_Siparisno.Text = ""; Cmb_sapmanedeni.Text = "";
                    //cmb_standartDisinedeni.Text = ""; cmb_standartDisiKimyasali.Text = "";
                    //Cmb_sapmaKimyasali.Text = ""; txt_standartKarisimSayisi.Text = "";
                    //txt_OzelKod.Text = ""; txt_Genelaciklama.Text = "";
                    //Txt_KutukTonaj.Text = ""; tx_radyoaktivite.Text = "";

                    //**kimyacı kapat dedi

                }

                else
                {
                    KUTUK_MSG.Text = "DÖKÜM SEÇMEDEN ÜRETİM BİLGİSİ SAKLAYAMAZSINIZ !!";
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }

            else
            {
                KUTUK_MSG.Text = "GÜN KAPANMIŞTIR. İŞLEM YAPAMAZSINIZ !!";
                KUTUK_MSG.ShowOnPageLoad = true;
            }


            database.disConnect();
        }
        public void dokum_tip_getir(object gelen_celik_cinsi)
        {
            database.connect();
            string gelen_dokum_tip = database.dokum_tip_getir(gelen_celik_cinsi);
            txt_dkmtip.Text = gelen_dokum_tip;
            database.disConnect();

        }
        public void uretim_secilen_getir()
        {

            List<uretim_bilgileri> kayitlar = new List<uretim_bilgileri>();
            database.connect();
            kayitlar = database.uretim_secilen_getir(txt_DokumNo.Text, txt_Sirano.Text);
            if (kayitlar.Count != 0)
            {
                foreach (var kayit in kayitlar)
                {
                    Cmb_Celikcinsii.Text = kayit.CELIKCINSI.ToString();
                    Cmb_Kutukboy.Text = kayit.KTKBOY.ToString();
                    Cmb_KutukEbat.Text = kayit.KTKEBAT.ToString();
                    txt_KutukSayisi.Text = kayit.KTKADET.ToString();
                    Cmb_vrd.Text = kayit.vrd;
                    txt_dkmtip.Text = kayit.dokumTip;
                    txt_OzelKod.Text = kayit.ozel_kod.ToString();
                    txt_Siparisno.Text = kayit.sipnum;
                    Cmb_sapmanedeni.Text = kayit.sapma_Nedeni;
                    Cmb_sapmaKimyasali.Text = kayit.sapma_Element;
                    cmb_standartDisinedeni.Text = kayit.std_Neden;
                    cmb_standartDisiKimyasali.Text = kayit.std_Element;
                    cmb_KutukGidecekYer.Text = kayit.gidecegi_yer;
                    Txt_KutukTonaj.Text = kayit.stdktkton.ToString();
                    txt_SarikutukSayisi.Text = kayit.sariktksay.ToString();
                    cmb_sarikutukCelikcinsi.Text = kayit.kalitekodsari.ToString();
                    txt_standartKarisimSayisi.Text = kayit.stnkarsay.ToString();
                    txt_karisimTonaji.Text = kayit.stnkarton.ToString();
                    txt_Genelaciklama.Text = kayit.ktkaciklama;
                    txt_Sirano.Text = kayit.SIRANO.ToString();
                    tx_radyoaktivite.Text = kayit.radyo_aktivite.ToString();
                    txt_egri_kutuk_sayisi.Text = kayit.egri_kutuk_sayisi.ToString();
                    txt_tandis_bindirme.Text = kayit.tandis_bindirme.ToString();

                }
            }

            database.disConnect();
        }

        public void uretim_secilen_getir_deneme()
        {
            database.connect();
            List<uretim_bilgileri> kayitlar = new List<uretim_bilgileri>();
            kayitlar = database.uretim_secilen_getir(txt_DokumNo.Text, "1");
            if (kayitlar.Count != 0)
            {
                foreach (var kayit in kayitlar)
                {
                    Cmb_Celikcinsii.Text = kayit.CELIKCINSI.ToString();
                    Cmb_Kutukboy.Text = kayit.KTKBOY.ToString();
                    Cmb_KutukEbat.Text = kayit.KTKEBAT.ToString();
                    txt_KutukSayisi.Text = kayit.KTKADET.ToString();
                    Cmb_vrd.Text = kayit.vrd;
                    txt_dkmtip.Text = kayit.dokumTip;
                    txt_OzelKod.Text = kayit.ozel_kod.ToString();
                    txt_Siparisno.Text = kayit.sipnum;
                    Cmb_sapmanedeni.Text = kayit.sapma_Nedeni;
                    Cmb_sapmaKimyasali.Text = kayit.sapma_Element;
                    cmb_standartDisinedeni.Text = kayit.std_Neden;
                    cmb_standartDisiKimyasali.Text = kayit.std_Element;
                    cmb_KutukGidecekYer.Text = kayit.gidecegi_yer;
                    Txt_KutukTonaj.Text = kayit.stdktkton.ToString();
                    txt_SarikutukSayisi.Text = kayit.sariktksay.ToString();
                    cmb_sarikutukCelikcinsi.Text = kayit.kalitekodsari.ToString();
                    txt_standartKarisimSayisi.Text = kayit.stnkarsay.ToString();
                    txt_karisimTonaji.Text = kayit.stnkarton.ToString();
                    txt_Genelaciklama.Text = kayit.ktkaciklama;
                    txt_Sirano.Text = "1";
                    tx_radyoaktivite.Text = kayit.radyo_aktivite.ToString();
                    txt_egri_kutuk_sayisi.Text = kayit.egri_kutuk_sayisi.ToString();
                    string yil_ = kayit.dokumtar.ToString().Substring(0, 4);
                    string ay_ = kayit.dokumtar.ToString().Substring(4).Substring(0, 2);
                    string gun_ = kayit.dokumtar.ToString().Substring(6);
                    tx_dokum_tarihi.Text = gun_ + "." + ay_ + "." + yil_;
                    txt_tandis_bindirme.Text = kayit.tandis_bindirme.ToString();

                }
            }
            database.disConnect();

        }


        public void dokum_yeni_sira()
        {

            txt_Sirano.Text = "";
            Cmb_Kutukboy.Text = ""; Cmb_KutukEbat.Text = "";
            txt_KutukSayisi.Text = "";
            txt_SarikutukSayisi.Text = "";
            txt_SarikutukTonaji.Text = ""; cmb_KutukGidecekYer.Text = "";
            cmb_sarikutukCelikcinsi.Text = ""; txt_karisimTonaji.Text = "";
            txt_Siparisno.Text = ""; Cmb_sapmanedeni.Text = "";
            cmb_standartDisinedeni.Text = ""; cmb_standartDisiKimyasali.Text = "";
            Cmb_sapmaKimyasali.Text = ""; txt_standartKarisimSayisi.Text = "";
            txt_OzelKod.Text = ""; txt_Genelaciklama.Text = "";
            Txt_KutukTonaj.Text = ""; txt_egri_kutuk_sayisi.Text = ""; txt_tandis_bindirme.Text = "";
            Cmb_Celikcinsii.Enabled = false;
            Cmb_vrd.Enabled = false; txt_dkmtip.Enabled = false;
            if (txt_DokumNo.Text != "0")
            {
                database.connect();
                dynamic gelen_sirano = database.dokum_yeni_sira(txt_DokumNo.Text);
                gelen_sirano = Convert.ToInt32(gelen_sirano) + 1;
                txt_Sirano.Text = Convert.ToString(gelen_sirano);
                database.disConnect();
            }
            else
            {
                KUTUK_MSG.Text = "DÖKÜM NUMARASI SEÇMEDEN YENİ SIRA ALAMAZSINIZ !!";
                KUTUK_MSG.ShowOnPageLoad = true;

            }
        }
        public void kutukboy_comboDoldur()
        {
            Cmb_Kutukboy.Items.Clear();
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.kutukboy_comboDoldur();
            foreach (var boy in kayitlar)
            {
                Cmb_Kutukboy.Items.Add(boy);
            }
            database.disConnect();
        }
        public void kutukEbat_comboDoldur()
        {
            Cmb_KutukEbat.Items.Clear();
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.kutukEbat_comboDoldur();
            foreach (var ebat in kayitlar)
            {
                Cmb_KutukEbat.Items.Add(ebat);
            }
            database.disConnect();
        }
        public void kalite_comboDoldur()
        {
            Cmb_Celikcinsii.Items.Clear();
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.kalite_comboDoldur();
            foreach (var kalite in kayitlar)
            {
                Cmb_Celikcinsii.Items.Add(kalite);
            }
            database.disConnect();

        }
        public void standartKutukTonajiGetir()
        {
            database.connect();
            decimal std_ktk_tonaj;
            string boy, ebat, vardiya, kalite;
            boy = Cmb_Kutukboy.Text; ebat = Cmb_KutukEbat.Text; kalite = Cmb_Celikcinsii.Text; vardiya = Cmb_vrd.Text;
            Txt_KutukTonaj.Text = "";
            List<string> uretimDegiskenleri = new List<string>();
            if (txt_DokumNo.Text != "0")
            {
                if (boy != "" && ebat != "")
                {
                    string tonaj = database.katsayiGetir(boy, ebat, Convert.ToDateTime(Txt_tarih.Text), vardiya, kalite);
                    if (tonaj != null)
                    {

                        decimal tonajj = Convert.ToDecimal(tonaj) / 1000;
                        lbl_kutukTonaj.Text = Convert.ToString(tonajj).Replace(",", ".");
                        if (lbl_kutukTonaj.Text != "" && lbl_kutukTonaj.Text != null)
                        {
                            if (txt_KutukSayisi.Text != "")
                            {
                                int kutuksayisi = Convert.ToInt32(txt_KutukSayisi.Text);
                                if (kutuksayisi != 0)
                                {
                                    std_ktk_tonaj = kutuksayisi * tonajj;
                                    Txt_KutukTonaj.Text = Convert.ToString(std_ktk_tonaj).Replace(",", ".");

                                }
                            }
                            else
                            {

                                KUTUK_MSG.Text = "\n" + "KÜTÜK SAYISI GİRİNİZ !";
                                KUTUK_MSG.ShowOnPageLoad = true;
                            }

                        }
                    }
                    else
                    {
                        txt_KutukSayisi.Text = "";
                        KUTUK_MSG.Text = "TONAJ BULUNAMADIĞI İÇİN STANDART KÜTÜK TONAJI HESAPLANAMIYOR!";
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }

                }
                else
                {
                    txt_KutukSayisi.Text = "";
                    KUTUK_MSG.Text = "TONAJIN HESAPLANABİLMESİ İÇİN BOY VE EBATI GİRİNİZ !! ";
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                KUTUK_MSG.Text = "DÖKÜM SEÇİNİZ !! ";
                KUTUK_MSG.ShowOnPageLoad = true;
            }

            database.disConnect();

        }
        public void sariKutukTonajiGetir()
        {

            database.connect();
            decimal sari_kutuk_tonaji;
            string boy, ebat, vardiya, kalite;
            boy = Cmb_Kutukboy.Text; ebat = Cmb_KutukEbat.Text; kalite = Cmb_Celikcinsii.Text; vardiya = Cmb_vrd.Text;
            txt_SarikutukTonaji.Text = "";
            List<string> uretimDegiskenleri = new List<string>();
            if (txt_DokumNo.Text != "0")
            {
                if (boy != "" && ebat != "")
                {
                    string tonaj = database.katsayiGetir(boy, ebat, Convert.ToDateTime(Txt_tarih.Text), vardiya, kalite);
                    if (tonaj != null)
                    {
                        decimal tonajj = Convert.ToDecimal(tonaj.Replace(",", "."));
                        tonajj = tonajj / 1000;
                        lbl_kutukTonaj.Text = Convert.ToString(tonajj);
                        if (lbl_kutukTonaj.Text != "" && lbl_kutukTonaj.Text != null)
                        {
                            if (txt_SarikutukSayisi.Text != "")
                            {
                                int sari_ktk_sayisi = Convert.ToInt32(txt_SarikutukSayisi.Text);
                                if (sari_ktk_sayisi != 0)
                                {
                                    sari_kutuk_tonaji = sari_ktk_sayisi * tonajj;
                                    txt_SarikutukTonaji.Text = Convert.ToString(sari_kutuk_tonaji).Replace(",", ".");

                                }
                            }
                            else
                            {

                                KUTUK_MSG.Text = "\n" + " SARI KÜTÜK SAYISI GİRİNİZ !";
                                KUTUK_MSG.ShowOnPageLoad = true;
                            }

                        }
                    }
                    else
                    {
                        txt_SarikutukSayisi.Text = "";
                        KUTUK_MSG.Text = "TONAJ BULUNAMADIĞI İÇİN SARI KÜTÜK TONAJI HESAPLANAMIYOR!";
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                }

                else
                {
                    txt_SarikutukSayisi.Text = "";
                    KUTUK_MSG.Text = "TONAJIN HESAPLANABİLMESİ İÇİN BOY VE EBATI GİRİNİZ !! ";
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                KUTUK_MSG.Text = "DÖKÜM SEÇİNİZ !! ";
                KUTUK_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }
        public void stdKarisimTonajiGetir()
        {

            database.connect();
            decimal karisim_tonaj;
            string boy, ebat, vardiya, kalite;
            boy = Cmb_Kutukboy.Text; ebat = Cmb_KutukEbat.Text; kalite = Cmb_Celikcinsii.Text; vardiya = Cmb_vrd.Text;
            txt_karisimTonaji.Text = "";
            List<string> uretimDegiskenleri = new List<string>();
            if (txt_DokumNo.Text != "0")
            {
                if (boy != "" && ebat != "")
                {
                    string tonaj = database.katsayiGetir(boy, ebat, Convert.ToDateTime(Txt_tarih.Text), vardiya, kalite);
                    if (tonaj != null)
                    {
                        decimal tonajj = Convert.ToDecimal(tonaj) / 1000;
                        lbl_kutukTonaj.Text = Convert.ToString(tonajj).Replace(",", ".");
                        if (lbl_kutukTonaj.Text != "" && lbl_kutukTonaj.Text != null)
                        {
                            if (txt_standartKarisimSayisi.Text != "")
                            {
                                int std_karisim_sayisi = Convert.ToInt32(txt_standartKarisimSayisi.Text);
                                if (std_karisim_sayisi != 0)
                                {
                                    karisim_tonaj = std_karisim_sayisi * tonajj;
                                    txt_karisimTonaji.Text = Convert.ToString(karisim_tonaj).Replace(",", ".");

                                }
                            }
                            else
                            {

                                txt_standartKarisimSayisi.Text = "";
                                KUTUK_MSG.Text = "\n" + "STANDART KARIŞIM SAYISI GİRİNİZ !";
                                KUTUK_MSG.ShowOnPageLoad = true;
                            }

                        }
                    }
                    else
                    {
                        txt_standartKarisimSayisi.Text = "";
                        KUTUK_MSG.Text = "TONAJ BULUNAMADIĞI İÇİN STANDART KARIŞIM TONAJI HESAPLANAMIYOR!";
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                }

                else
                {
                    txt_standartKarisimSayisi.Text = "";
                    KUTUK_MSG.Text = "TONAJIN HESAPLANABİLMESİ İÇİN BOY VE EBATI GİRİNİZ !! ";
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                KUTUK_MSG.Text = "DÖKÜM SEÇİNİZ !! ";
                KUTUK_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }
        public void send_ktk_dokum_liste()
        {
            database.connect();
            List<uretim_bilgileri> dokumno = new List<uretim_bilgileri>();
            dokumno = database.send_ktk_dokum_liste(txt_DokumNo.Text);
            GRD_Send_Ktk.DataSource = dokumno;
            GRD_Send_Ktk.DataBind();
            database.disConnect();
        }
        public void sicak_sarja_gonderilecek_kutuk()
        {
            database.connect();
            string x, MESAJ, sirano;
            int gonderilecek_kutuk_sayisi;
            sirano = txt_Sirano.Text;
            for (int i = 0; i <= GRD_Send_Ktk.VisibleRowCount - 1; i++)
            {
                TextBox deger = (TextBox)GRD_Send_Ktk.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_Send_Ktk.Columns["GTKSAYISI"], "GKTKSAYISI");
                x = Convert.ToString(deger.Text);
                if (x != "")
                {
                    gonderilecek_kutuk_sayisi = Convert.ToInt32(deger.Text);
                    List<string> degiskenler = new List<string>();
                    if (Cmb_Celikcinsii.Text != "" && Cmb_Kutukboy.Text != "" && Cmb_KutukEbat.Text != "")
                    {
                        degiskenler = database.kaliteBoyEbat_Kodbul(Cmb_Celikcinsii.Text, Cmb_Kutukboy.Text, Cmb_KutukEbat.Text);
                        string kalite = degiskenler[0];
                        string boy = degiskenler[1];
                        string ebat = degiskenler[2];
                        MESAJ = database.sicak_sarja_gonderilecek_kutuk(Convert.ToDateTime(Txt_tarih.Text), txt_DokumNo.Text, gonderilecek_kutuk_sayisi, kalite, boy, ebat);
                        KUTUK_MSG.Text = MESAJ;
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                    else
                    {
                        KUTUK_MSG.Text = "      Kalite,boy, ebat alanını doldurunuz !!";
                        KUTUK_MSG.ShowOnPageLoad = true;
                    }
                }
                else
                {
                    KUTUK_MSG.Text = " SICAK ŞARJA GÖNDERECEĞİNİZ KÜTÜK ADETİ 0'DAN FARKLI OLMALIDIR !!";
                    KUTUK_MSG.ShowOnPageLoad = true;

                }
            }
            database.disConnect();

        }
        public void toplam_tonaj_getir()
        {
            database.connect();
            string toplamTonaj = database.toplam_tonaj_getir(Convert.ToInt32(txt_DokumNo.Text));
            Txt_KutukTonajii.Text = toplamTonaj.Replace(",", ".");
            database.disConnect();

        }
        public void dokum_sirasi_sil()
        {
            database.connect();
            string d1, MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (txt_DokumNo.Text != "0")
                {

                    d1 = txt_Sirano.Text;
                    MESAJ = database.dokum_sirasi_sil(txt_DokumNo.Text, d1, Convert.ToDateTime(Txt_tarih.Text));
                    KUTUK_MSG.Text = MESAJ;
                    KUTUK_MSG.ShowOnPageLoad = true;

                    Cmb_Celikcinsii.Text = ""; txt_Sirano.Text = "";
                    Cmb_Kutukboy.Text = ""; Cmb_KutukEbat.Text = "";
                    txt_KutukSayisi.Text = ""; txt_dkmtip.Text = "";
                    Cmb_vrd.Text = ""; txt_SarikutukSayisi.Text = "";
                    txt_SarikutukTonaji.Text = ""; cmb_KutukGidecekYer.Text = "";
                    cmb_sarikutukCelikcinsi.Text = ""; txt_karisimTonaji.Text = "";
                    txt_Siparisno.Text = ""; Cmb_sapmanedeni.Text = "";
                    cmb_standartDisinedeni.Text = ""; cmb_standartDisiKimyasali.Text = "";
                    Cmb_sapmaKimyasali.Text = ""; txt_standartKarisimSayisi.Text = "";
                    txt_OzelKod.Text = ""; txt_Genelaciklama.Text = "";
                    Txt_KutukTonaj.Text = ""; txt_egri_kutuk_sayisi.Text = "";
                    tx_radyoaktivite.Text = ""; txt_tandis_bindirme.Text = "";

                }

                else
                {
                    KUTUK_MSG.Text = "DÖKÜM SIRASI SEÇMEDEN ÜRETİM BİLGİSİ SİLEMEZSİNİZ  !!";
                    KUTUK_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                KUTUK_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                KUTUK_MSG.ShowOnPageLoad = true;
            }

            database.disConnect();

        }



        //Duruş
        public void durus_liste()
        {
            database.connect();
            List<durus_bilgileri> durus_listesi_veriler = new List<durus_bilgileri>();
            durus_listesi_veriler = database.durus_liste(txt_DokumNo.Text);
            GRD_DURUS.DataSource = durus_listesi_veriler;
            GRD_DURUS.DataBind();
            database.disConnect();
        }
        public void durus_kayit()
        {
            database.connect();
            string durusneden, duruskod, ariza_neden, vardiya, sarj_durum, tesis, netsure, ariza_kod, aciklama, baslangic_saat, bitis_saat, durus_id, MESAJ;
            durusneden = cmb_durusNeden.Text;
            duruskod = txt_durusKod.Text;
            ariza_neden = Cmb_ArizaNeden.Text;
            ariza_kod = txt_ArizaKod.Text;
            tesis = "DCH";
            sarj_durum = cmb_sarjdurumu.Text;
            baslangic_saat = txt_BasSaat.Text;
            bitis_saat = txt_BitisSaat.Text;
            netsure = txt_Netsure.Text;
            durus_id = txt_DurusID.Text;
            aciklama = txt_Aciklama.Text;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (txt_DokumNo.Text != "0")
                {
                    List<string> uretimDegiskenleri = new List<string>();
                    uretimDegiskenleri = database.uretimdegiskeni_Bul(txt_DokumNo.Text);
                    vardiya = uretimDegiskenleri[1];
                    if (durusneden != "" && duruskod != "" && ariza_neden != "" && ariza_kod != "" && baslangic_saat != "" && bitis_saat != "" && netsure != "")
                    {
                        MESAJ = database.durus_kayit(txt_DokumNo.Text, durusneden, duruskod, ariza_neden, vardiya, sarj_durum, tesis,
                            netsure, ariza_kod, aciklama, baslangic_saat, bitis_saat, durus_id);
                        durus_liste();
                        DURUS_MSG.Text = MESAJ;
                        DURUS_MSG.ShowOnPageLoad = true;

                        cmb_durusNeden.Text = "";
                        txt_durusKod.Text = "";
                        Cmb_ArizaNeden.Text = "";
                        txt_ArizaKod.Text = "";
                        cmb_sarjdurumu.Text = "";
                        txt_Netsure.Text = "";
                        txt_Aciklama.Text = "";
                        txt_BasSaat.Text = "";
                        txt_BitisSaat.Text = "";
                        txt_DurusID.Text = "";
                    }
                    else
                    {

                        MESAJ = "   LÜTFEN TÜM ALANLARI DOLDURUNUZ !";
                        DURUS_MSG.Text = MESAJ;
                        DURUS_MSG.ShowOnPageLoad = true;

                    }
                }

                else
                {

                    MESAJ = "DÖKÜM NUMARASI SEÇMEDEN DURUŞ GİREMEZSİNİZ !!";
                    DURUS_MSG.Text = MESAJ;
                    DURUS_MSG.ShowOnPageLoad = true;

                }
            }
            else
            {
                DURUS_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ! ";
                DURUS_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();

        }
        public void yeni_durus_Getir()
        {
            durus_liste();
            cmb_durusNeden.Text = "";
            txt_durusKod.Text = "";
            Cmb_ArizaNeden.Text = "";
            txt_ArizaKod.Text = "";
            cmb_sarjdurumu.Text = "";
            txt_Netsure.Text = "";
            txt_Aciklama.Text = "";
            txt_BasSaat.Text = "";
            txt_BitisSaat.Text = "";
            txt_DurusID.Text = "";

        }
        public void durus_sablon_getir()
        {
            database.connect();
            dynamic MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (txt_DokumNo.Text != "0")
                {
                    database.durus_sablon_getir(txt_DokumNo.Text, Convert.ToDateTime(Txt_tarih.Text));
                }

                else
                {
                    MESAJ = "DÖKÜM NUMARASI SEÇMEDEN ŞABLON GETİREMEZSİNİZ!!";
                    DURUS_MSG.Text = MESAJ;
                    DURUS_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                DURUS_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ! ";
                DURUS_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();

        }
        public void durusNeden_cmbDoldur()
        {
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.durusNeden_comboDoldur();
            foreach (var neden in kayitlar)
            {
                cmb_durusNeden.Items.Add(neden);
                durus_kod_getir(cmb_durusNeden.SelectedItem);
            }
            database.disConnect();
        }
        public void durus_kod_getir(object gelen_neden)
        {
            database.connect();
            gelen_durus_kodu = database.durus_kod_getir(gelen_neden);
            txt_durusKod.Text = gelen_durus_kodu;
            // arizaNeden_cmbDoldur();
            database.disConnect();
        }
        public void arizaNeden_cmbDoldur()
        {
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.ariza_neden_cmbDoldur(gelen_durus_kodu);
            foreach (var neden in kayitlar)
            {
                Cmb_ArizaNeden.Items.Add(neden);
            }

            database.disConnect();

        }
        public void arizaNeden_cmbDoldur(object gelen_durus_kodu)
        {
            database.connect();
            List<string> kayitlar = new List<string>();
            kayitlar = database.ariza_neden_cmbDoldur(gelen_durus_kodu);
            foreach (var neden in kayitlar)
            {
                Cmb_ArizaNeden.Items.Add(neden);
            }

            database.disConnect();

        }
        public void ariza_kod_getir(object gelen_ariza_neden)
        {
            database.connect();
            //if (gelenarizaNeden.ToString() == "SARJ ALMA")
            //{
            //    cmb_sarjdurumu.Enabled = true;

            //}
            string durus_kod = txt_durusKod.Text;
            string gelen_ariza_kodu = database.ariza_kod_getir(gelen_ariza_neden, durus_kod);
            txt_ArizaKod.Text = gelen_ariza_kodu;
            database.disConnect();
        }
        public string net_sure_getir()
        {

            string d3, d4;
            d3 = txt_BasSaat.Text;
            d4 = txt_BitisSaat.Text;
            if (d3 != "" && d4 != "")
            {
                DateTime d1 = DateTime.ParseExact(txt_BasSaat.Text, "HH:mm", null);
                DateTime d2 = DateTime.ParseExact(txt_BitisSaat.Text, "HH:mm", null);
                if (d2.Hour == d1.Hour && d2.Minute < d1.Minute)
                {
                    txt_Netsure.Text = "";
                    message = "DAKİKAYI TEKRAR DÜZENLEYİNİZ !!";
                    DURUS_MSG.Text = message;
                    DURUS_MSG.ShowOnPageLoad = true;


                }
                if (d2.Hour == d1.Hour && d2.Minute == d1.Minute)
                {
                    txt_Netsure.Text = "0";

                }
                else
                if (d2.Hour >= d1.Hour)
                {
                    TimeSpan t = d2.Subtract(d1);
                    int saat = int.Parse(t.Hours.ToString());
                    int dakika = int.Parse(t.Minutes.ToString());
                    int toplamFark = saat * 60 + dakika;
                    txt_Netsure.Text = toplamFark.ToString();
                }
                else
                {
                    txt_Netsure.Text = "";
                    message = "BİTİŞ SAATİNİ BAŞLANGIÇ SAATİNDEN GERİ SEÇEMEZSİNİZ !!";
                    DURUS_MSG.Text = message;
                    DURUS_MSG.ShowOnPageLoad = true;
                }

            }
            return txt_Netsure.Text;
        }
        public string Netsure_Getir(string d10, string d11)
        {

            string d3, d4;
            d3 = txt_BasSaat.Text;
            d4 = txt_BitisSaat.Text;
            if (d3 != "" && d4 != "")
            {
                DateTime d1 = DateTime.ParseExact(txt_BasSaat.Text, "HH:mm", null);
                DateTime d2 = DateTime.ParseExact(txt_BitisSaat.Text, "HH:mm", null);
                if (d2.Hour == d1.Hour && d2.Minute < d1.Minute)
                {
                    txt_Netsure.Text = "";
                    message = "DAKİKAYI TEKRAR DÜZENLEYİNİZ !!";
                    DURUS_MSG.Text = message;
                    DURUS_MSG.ShowOnPageLoad = true;


                }
                if (d2.Hour == d1.Hour && d2.Minute == d1.Minute)
                {
                    txt_Netsure.Text = "0";

                }
                else
                if (d2.Hour >= d1.Hour)
                {
                    TimeSpan t = d2.Subtract(d1);
                    int saat = int.Parse(t.Hours.ToString());
                    int dakika = int.Parse(t.Minutes.ToString());
                    int toplamFark = saat * 60 + dakika;
                    txt_Netsure.Text = toplamFark.ToString();
                }
                else
                {
                    txt_Netsure.Text = "";
                    message = "BİTİŞ SAATİNİ BAŞLANGIÇ SAATİNDEN GERİ SEÇEMEZSİNİZ !!";
                    DURUS_MSG.Text = message;
                    DURUS_MSG.ShowOnPageLoad = true;
                }

            }
            return txt_Netsure.Text;
        }
        public void durus_bilgisi_getir()
        {
            database.connect();
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            kayitlar = database.durus_bilgisi_getir(txt_DokumNo.Text, txt_DurusID.Text);
            if (kayitlar.Count != 0)
            {
                foreach (var kayit in kayitlar)
                {
                    txt_BasSaat.Text = kayit.BASSAATI;
                    txt_BitisSaat.Text = kayit.BITISSAATI;
                    cmb_sarjdurumu.Text = kayit.SARJALMA;
                    cmb_durusNeden.Text = kayit.DURUSNEDEN;
                    Cmb_ArizaNeden.Text = kayit.ARIZANEDEN;
                    txt_durusKod.Text = kayit.DURUSKOD;
                    txt_ArizaKod.Text = kayit.ARIZAKOD;
                    txt_Netsure.Text = kayit.SURE;
                    txt_Aciklama.Text = kayit.aciklama;
                }
            }
            database.disConnect();

        }
        public void durus_delete()
        {

            database.connect();
            string d1, MESAJ;
            string durus_Id = txt_DurusID.Text;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                if (durus_Id != "")
                {

                    MESAJ = database.durus_bilgisi_sil(durus_Id);
                    DURUS_MSG.Text = MESAJ;
                    DURUS_MSG.ShowOnPageLoad = true;

                    cmb_durusNeden.Text = "";
                    txt_durusKod.Text = "";
                    Cmb_ArizaNeden.Text = "";
                    txt_ArizaKod.Text = "";
                    cmb_sarjdurumu.Text = "";
                    txt_Netsure.Text = "";
                    txt_Aciklama.Text = "";
                    txt_BasSaat.Text = "";
                    txt_BitisSaat.Text = "";
                    txt_DurusID.Text = "";

                }
                else
                {
                    DURUS_MSG.Text = "DURUŞ BİLGİSİ SEÇİNİZ   !!";
                    DURUS_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                DURUS_MSG.Text = "GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ ! ";
                DURUS_MSG.ShowOnPageLoad = true;
            }

            database.disConnect();

        }


        //  Refrakter

        public void refrakter_listesi()
        {
            if (Txt_tarih.Text != "")
            {
                database.connect();
                List<refrakter_bilgileri> refrakter_listesi_veriler = new List<refrakter_bilgileri>();
                refrakter_listesi_veriler = database.refrakter_liste(Convert.ToDateTime(Txt_tarih.Text));
                GRD_REFRAKTER.DataSource = refrakter_listesi_veriler;
                GRD_REFRAKTER.DataBind();
                database.disConnect();
            }

        }
        public void refrakter_kayit()
        {
            database.connect();
            string baslangic_tarih, pota_no, dokum_sayisi, d4, d5, d6, d7, d8, d9, d10, d13, d14, d15, d16, d17, d18, d19, d20, iskarta_tarih, d22, d23, d24, MESAJ;
            baslangic_tarih = date_baslangicTarihi.Text;
            pota_no = cmb_Potano.Text;
            dokum_sayisi = txt_Dokumsayisi.Text;
            d4 = cmb_TuglaFirma.Text;
            d5 = cmb_Potadurum.Text;
            d6 = cmb_pskTmr.Text;
            d7 = Txt_gazds.Text;
            d8 = Cmb_gazFirma.Text;
            d9 = cmb_Tip.Text;
            d10 = Cmb_Tandis_Plk_Frm.Text;
            d13 = Txt_UstDS.Text;
            d14 = Cmb_UstFirma.Text;
            d15 = Txt_AltDS.Text;
            d16 = Cmb_AltFirma.Text;
            d17 = Txt_surguDS.Text;
            d18 = Cmb_SurguFirma.Text;
            d19 = cmb_PlkTY.Text;
            d20 = Cmb_KontrolEden.Text;
            iskarta_tarih = Date_IskartaTarih.Text;
            d22 = dt_Gelis_saati.Text;
            d23 = dt_Cks_saati.Text;
            d24 = txt_Genelaciklamaa.Text;

            if (tx_refrakter_dokum.Text != "")
            {
                if (pota_no != "" && dokum_sayisi != "" && baslangic_tarih != "" && d4 != "" && d5 != "" && d6 != "" && d7 != "" &&
                    d8 != "" && d9 != "" && d13 != "" && d14 != "" && d15 != "" && d16 != "" && d17 != "" && d18 != "")
                {

                    MESAJ = database.refrakter_kayit(tx_refrakter_dokum.Text, baslangic_tarih, pota_no,
                        dokum_sayisi, d4, d5, d6, d7, d8, d9, d10, d13, d14, d15, d16, d17, d18, d19, d20, iskarta_tarih, d22, d23, d24);
                    REFRAKTER_MSG.Text = MESAJ;
                    REFRAKTER_MSG.ShowOnPageLoad = true;

                    date_baslangicTarihi.Text = ""; cmb_Potano.Text = "";
                    txt_Dokumsayisi.Text = ""; cmb_TuglaFirma.Text = "";
                    cmb_Potadurum.Text = ""; cmb_pskTmr.Text = "";
                    Txt_gazds.Text = ""; Cmb_gazFirma.Text = "";
                    cmb_Tip.Text = "";
                    Txt_UstDS.Text = ""; Cmb_UstFirma.Text = "";
                    Txt_AltDS.Text = ""; Cmb_AltFirma.Text = "";
                    Txt_surguDS.Text = ""; Cmb_SurguFirma.Text = "";
                    cmb_PlkTY.Text = ""; Cmb_KontrolEden.Text = "";
                    Date_IskartaTarih.Text = ""; dt_Gelis_saati.Text = "";
                    dt_Cks_saati.Text = ""; txt_Genelaciklamaa.Text = ""; tx_refrakter_dokum.Text = "";
                }
                else
                {
                    REFRAKTER_MSG.Text = "  LÜTFEN TÜM ALANLARI DOLDURUNUZ !!";
                    REFRAKTER_MSG.ShowOnPageLoad = true;
                }
            }
            else
            {
                REFRAKTER_MSG.Text = " DÖKÜM NUMARASI SEÇİNİZ ";
                REFRAKTER_MSG.ShowOnPageLoad = true;
            }
            database.disConnect();
        }

        public void refrakter_bilgisi_getir()
        {

            database.connect();
            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
            kayitlar = database.refrakter_bilgisi_getir(tx_refrakter_dokum.Text);
            if (kayitlar.Count != 0)
            {
                foreach (var kayit in kayitlar)
                {
                    cmb_Potadurum.Text = kayit.POTADURUM;
                    txt_Dokumsayisi.Text = kayit.DKMSAYISI.ToString();
                    cmb_TuglaFirma.Text = kayit.TUGLAFIRMA;
                    cmb_pskTmr.Text = kayit.PUSKURTMELI.ToString();
                    Txt_gazds.Text = kayit.GAZTAPASIDS.ToString();
                    Cmb_gazFirma.Text = kayit.gazFirma;
                    cmb_Tip.Text = kayit.gazTip;
                    Txt_UstDS.Text = kayit.USTNOZULDS.ToString();
                    Cmb_UstFirma.Text = kayit.ustFirma;
                    Txt_AltDS.Text = kayit.ALTNOZULDS.ToString();
                    Cmb_AltFirma.Text = kayit.altFirma;
                    Txt_surguDS.Text = kayit.SURGUDS.ToString();
                    Cmb_SurguFirma.Text = kayit.SURGUFIRMA.ToString();
                    cmb_PlkTY.Text = kayit.SURGUPLKTY;
                    Cmb_KontrolEden.Text = kayit.KONTROLEDEN;
                    if (kayit.ISKARTATARIHI != "")
                    {
                        int Iskarta = Convert.ToInt32(kayit.ISKARTATARIHI);
                        tarih_parse = database.tarihFormat1(Iskarta);
                        Date_IskartaTarih.Text = tarih_parse;

                    }
                    else
                    {
                        Date_IskartaTarih.Text = "";

                    }
                    if (kayit.BASLANGICTARIHI != "")
                    {
                        int baslangicTarihi = Convert.ToInt32(kayit.BASLANGICTARIHI);
                        tarih_parse = database.tarihFormat1(baslangicTarihi);
                        date_baslangicTarihi.Text = tarih_parse;
                    }
                    else
                    {
                        date_baslangicTarihi.Text = "";
                    }


                    dt_Gelis_saati.Text = kayit.POTAGELISSAATI.ToString();
                    dt_Cks_saati.Text = kayit.POTACIKISSAATI.ToString();
                    txt_Genelaciklamaa.Text = kayit.ACIKLAMA;
                    cmb_Potano.Text = kayit.POTANO.ToString();
                    Cmb_Tandis_Plk_Frm.Text = kayit.TANDIS_PLK_FRM.ToString();
                    string gelen_tandis_miktari = database.tandis_degeri_bul(tx_refrakter_dokum.Text);
                    if (gelen_tandis_miktari == "1")
                    {
                        Cmb_Tandis_Plk_Frm.Enabled = true;
                    }
                    if (kayit.POTADURUM == "ISKARTA")
                    {
                        Date_IskartaTarih.Enabled = true;
                    }
                    else
                    {
                        gelen_tandis_miktari = database.tandis_degeri_bul(tx_refrakter_dokum.Text);
                        if (gelen_tandis_miktari == "1")
                        {
                            Cmb_Tandis_Plk_Frm.Enabled = true;
                        }
                    }
                }
            }
            database.disConnect();
        }
        public void yeni_refrakter()
        {
            database.connect();
            string potano;
            potano = cmb_Potano.Text;
            if (potano == "")
            {
                REFRAKTER_MSG.Text = "POTA NUMARASI SEÇİNİZ";
                REFRAKTER_MSG.ShowOnPageLoad = true;
            }
            else
            {
                List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
                kayitlar = database.yeni_refrakter(potano);
                if (kayitlar.Count != 0)
                {
                    tx_refrakter_dokum.Text = database.yenirefrakter_dokum(Convert.ToDateTime(Txt_tarih.Text));
                    foreach (var kayit in kayitlar)
                    {
                        if (tx_refrakter_dokum.Text != "0")
                        {
                            cmb_Potadurum.Text = kayit.POTADURUM;
                            if (cmb_Potadurum.Text == "ISKARTA")
                            {
                                cmb_Potadurum.Text = "DEVAM";
                                cmb_TuglaFirma.Text = "HAZNEDAR";
                                Cmb_UstFirma.Text = "METAMİN";
                                Cmb_AltFirma.Text = "METAMİN";
                                Cmb_gazFirma.Text = "METAMİN";
                                cmb_Tip.Text = "HIBRIT";
                            }
                            else
                            {

                                cmb_Potadurum.Text = kayit.POTADURUM;
                                cmb_TuglaFirma.Text = kayit.TUGLAFIRMA;
                                Cmb_gazFirma.Text = kayit.gazFirma;
                                Cmb_UstFirma.Text = kayit.ustFirma;
                                Cmb_AltFirma.Text = kayit.altFirma;
                                cmb_Tip.Text = kayit.gazTip;
                            }
                            txt_Dokumsayisi.Text = kayit.DKMSAYISI.ToString();
                            cmb_pskTmr.Text = kayit.PUSKURTMELI.ToString();
                            Txt_gazds.Text = kayit.GAZTAPASIDS.ToString();

                            Txt_UstDS.Text = kayit.USTNOZULDS.ToString();
                            Txt_AltDS.Text = kayit.ALTNOZULDS.ToString();
                            Txt_surguDS.Text = kayit.SURGUDS.ToString();

                            cmb_PlkTY.Text = kayit.SURGUPLKTY;
                            Cmb_KontrolEden.Text = kayit.KONTROLEDEN;
                            if (kayit.ISKARTATARIHI != "")
                            {
                                int Iskarta = Convert.ToInt32(kayit.ISKARTATARIHI);
                                tarih_parse = database.tarihFormat1(Iskarta);
                                Date_IskartaTarih.Text = tarih_parse;

                            }
                            else
                            {
                                Date_IskartaTarih.Text = "";

                            }
                            if (kayit.BASLANGICTARIHI != "")
                            {
                                int baslangicTarihi = Convert.ToInt32(kayit.BASLANGICTARIHI);
                                tarih_parse = database.tarihFormat1(baslangicTarihi);
                                date_baslangicTarihi.Text = tarih_parse;
                            }
                            else
                            {
                                date_baslangicTarihi.Text = "";
                            }

                            string saat = string.Format("{0:HH:mm}", DateTime.Now);

                            string saat2 = (Convert.ToInt32(DateTime.Now.Hour) + 2).ToString();
                            string dakika2 = DateTime.Now.Minute.ToString();
                            if (saat2.Length == 1)
                            {
                                saat = "0" + saat2;
                            }
                            if (dakika2.Length == 1)
                            {
                                dakika2 = "0" + dakika2;
                            }

                            dt_Cks_saati.Text = saat;
                            dt_Gelis_saati.Text = saat2 + ":" + dakika2;
                            txt_Genelaciklamaa.Text = kayit.ACIKLAMA;
                            cmb_Potano.Text = kayit.POTANO.ToString();
                            Cmb_Tandis_Plk_Frm.Text = kayit.TANDIS_PLK_FRM.ToString();
                        }

                        else
                        {
                            date_baslangicTarihi.Text = ""; cmb_Potano.Text = "";
                            txt_Dokumsayisi.Text = ""; cmb_TuglaFirma.Text = "";
                            cmb_Potadurum.Text = ""; cmb_pskTmr.Text = "";
                            Txt_gazds.Text = ""; Cmb_gazFirma.Text = "";
                            cmb_Tip.Text = "";
                            Txt_UstDS.Text = ""; Cmb_UstFirma.Text = "";
                            Txt_AltDS.Text = ""; Cmb_AltFirma.Text = "";
                            Txt_surguDS.Text = ""; Cmb_SurguFirma.Text = "";
                            cmb_PlkTY.Text = ""; Cmb_KontrolEden.Text = "";
                            Date_IskartaTarih.Text = ""; dt_Gelis_saati.Text = "";
                            dt_Cks_saati.Text = ""; txt_Genelaciklamaa.Text = "";
                            tx_refrakter_dokum.Text = "";
                            REFRAKTER_MSG.Text = "REFRAKTER TABLOSUNDA BUGÜN GİRİLMİŞ KAYIT BULUNMAMAKTADIR. !";
                            REFRAKTER_MSG.ShowOnPageLoad = true;

                        }
                    }
                }
                database.disConnect();
            }
        }
        private void refrakter_dokum_sil()
        {
            database.connect();
            string mesaj;
            if (tx_refrakter_dokum.Text != "")
            {

                mesaj = database.refrakter_dokum_sil(tx_refrakter_dokum.Text);
                REFRAKTER_MSG.Text = mesaj;
                REFRAKTER_MSG.ShowOnPageLoad = true;

                date_baslangicTarihi.Text = ""; cmb_Potano.Text = "";
                txt_Dokumsayisi.Text = ""; cmb_TuglaFirma.Text = "";
                cmb_Potadurum.Text = ""; cmb_pskTmr.Text = "";
                Txt_gazds.Text = ""; Cmb_gazFirma.Text = "";
                cmb_Tip.Text = "";
                Txt_UstDS.Text = ""; Cmb_UstFirma.Text = "";
                Txt_AltDS.Text = ""; Cmb_AltFirma.Text = "";
                Txt_surguDS.Text = ""; Cmb_SurguFirma.Text = "";
                cmb_PlkTY.Text = ""; Cmb_KontrolEden.Text = "";
                Date_IskartaTarih.Text = ""; dt_Gelis_saati.Text = "";
                dt_Cks_saati.Text = ""; txt_Genelaciklamaa.Text = ""; tx_refrakter_dokum.Text = "";

            }
            database.disConnect();

        }


        // 
        public void analiz_listesi1()
        {
            database.connect();
            string lokasyon = "URT";
            List<genel_bilgiler> analiz_listesi_veriler = new List<genel_bilgiler>();
            analiz_listesi_veriler = database.genel_bilgi_listesi_analiz(Convert.ToDateTime(Txt_tarih.Text), lokasyon);
            Grd_analiz1.DataSource = analiz_listesi_veriler;
            Grd_analiz1.DataBind();
            database.disConnect();

        }
        public void analiz_kayit()
        {
            database.connect();
            string d1, d2, d3, MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {

                for (int i = 0; i <= Grd_analiz1.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)Grd_analiz1.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_analiz1.Columns["DEGERI"], "txtDegeri6");
                    d1 = deger.Text;
                    d2 = Grd_analiz1.GetRowValues(i, "BILGITNM").ToString();
                    d3 = "URT";

                    MESAJ = database.genel_bilgi_kayit_analiz(Convert.ToDateTime(Txt_tarih.Text), d1, d2, d3);
                    Analiz_msg.Text = MESAJ;
                    Analiz_msg.ShowOnPageLoad = true;

                }
                for (int i = 0; i <= Grd_analiz2.VisibleRowCount - 1; i++)
                {
                    TextBox deger = (TextBox)Grd_analiz2.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_analiz2.Columns["DEGERI"], "txtDegeri7");
                    d1 = deger.Text;
                    d2 = Grd_analiz2.GetRowValues(i, "BILGITNM").ToString();
                    d3 = "URT2";
                    MESAJ = database.genel_bilgi_kayit_analiz(Convert.ToDateTime(Txt_tarih.Text), d1, d2, d3);
                    Analiz_msg.Text = MESAJ;
                    Analiz_msg.ShowOnPageLoad = true;

                }

            }

            else
            {

                GENELBILGI_MSG.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                GENELBILGI_MSG.ShowOnPageLoad = true;

            }
            database.disConnect();

        }
        public void analiz_listesi2()
        {
            database.connect();
            string lokasyon = "URT2";
            List<genel_bilgiler> analiz_listesi_veriler = new List<genel_bilgiler>();
            analiz_listesi_veriler = database.genel_bilgi_listesi_analiz(Convert.ToDateTime(Txt_tarih.Text), lokasyon);
            Grd_analiz2.DataSource = analiz_listesi_veriler;
            Grd_analiz2.DataBind();
            database.disConnect();

        }


        //

        public void dokum_ozellikleri_liste()
        {

            database.connect();
            List<uretim_bilgileri> dokumler = new List<uretim_bilgileri>();
            dokumler = database.dokum_ozellikleri_liste(Convert.ToDateTime(Txt_tarih.Text));
            Grd_dokum_ozellikleri.DataSource = dokumler;
            Grd_dokum_ozellikleri.DataBind();
            database.disConnect();


        }
        public void dokum_ozellikleri_kayit()
        {
            database.connect();
            string dokum_no, vardiya, dokum_tarihi, MESAJ;
            gun_kontrol = database.gun_kontrolu_yap(Convert.ToDateTime(Txt_tarih.Text));
            if (gun_kontrol == "True")
            {
                for (int i = 0; i <= Grd_dokum_ozellikleri.VisibleRowCount - 1; i++)
                {
                    TextBox deger1 = (TextBox)Grd_dokum_ozellikleri.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_dokum_ozellikleri.Columns["vardiya"], "txtDegeri_vrd");
                    TextBox deger2 = (TextBox)Grd_dokum_ozellikleri.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_dokum_ozellikleri.Columns["dokumtarihi"], "txtDegeri_dokumtarihi");
                    vardiya = deger1.Text;
                    dokum_no = Grd_dokum_ozellikleri.GetRowValues(i, "DOKUMNO").ToString();
                    dokum_tarihi = deger2.Text;

                    MESAJ = database.dokum_ozellikleri_kayit(vardiya, dokum_no, dokum_tarihi);
                    Dokum_ozellik_msg.Text = "DÖKÜMÜN BİLGİLERİ " + MESAJ;
                    Dokum_ozellik_msg.ShowOnPageLoad = true;

                }

            }
            else
            {
                Dokum_ozellik_msg.Text = " GÜN KAPANMIŞTIR.İŞLEM YAPAMAZSINIZ !!";
                Dokum_ozellik_msg.ShowOnPageLoad = true;
            }
            database.disConnect();

        }




        //

        protected void sdm_genel_bilgi_TextChanged(object sender, EventArgs e)
        {

            for (int i = 0; i <= GRD_CH_GENELBILGILER_SDM.VisibleRowCount - 1; i++)
            {
                if (GRD_CH_GENELBILGILER_SDM.GetRowValues(i, "BILGITNM").ToString() == "POTA KAPATMA SAATI")
                {

                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_SDM.FindRowCellTemplateControl(i - 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_SDM.Columns["DEGERI"], "txtDegeri6");
                    TextBox deger2 = (TextBox)GRD_CH_GENELBILGILER_SDM.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_SDM.Columns["DEGERI"], "txtDegeri6");
                    TextBox deger3 = (TextBox)GRD_CH_GENELBILGILER_SDM.FindRowCellTemplateControl(i + 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_SDM.Columns["DEGERI"], "txtDegeri6");
                    if (deger.Text != "" && deger2.Text != "")
                    {
                        try
                        {
                            DateTime d1 = DateTime.ParseExact(deger.Text, "HH:mm", null);
                            DateTime d2 = DateTime.ParseExact(deger2.Text.Replace(";", ":"), "HH:mm", null);

                            if (d2.Hour == d1.Hour && d2.Minute < d1.Minute)
                            {
                                deger3.Text = "";

                            }
                            if (d2.Hour == d1.Hour && d1.Minute < d2.Minute)
                            {
                                TimeSpan t = d2.Subtract(d1);
                                int saat = int.Parse(t.Hours.ToString());
                                int dakika = int.Parse(t.Minutes.ToString());
                                int toplamFark = saat * 60 + dakika;
                                deger3.Text = toplamFark.ToString();

                            }
                            if (d2.Hour == d1.Hour && d2.Minute == d1.Minute)
                            {
                                deger3.Text = "0";

                            }
                            else
                             if (d2.Hour > d1.Hour && (d2.Minute >= d1.Minute || d1.Minute >= d2.Minute))
                            {
                                TimeSpan t = d2.Subtract(d1);
                                int saat = int.Parse(t.Hours.ToString());
                                int dakika = int.Parse(t.Minutes.ToString());
                                int toplamFark = saat * 60 + dakika;
                                deger3.Text = toplamFark.ToString();
                            }
                            if (d1.Hour > d2.Hour)
                            {
                                deger3.Text = "";

                            }
                            if (d2.Hour == 00 && d1.Hour != 00)
                            {
                                int giris_dakikasi = 60 - int.Parse(d1.Minute.ToString());
                                int total_dakika = giris_dakikasi + int.Parse(d2.Minute.ToString());
                                deger3.Text = total_dakika.ToString();
                            }   //örnek:çıkış saati 00:00  giriş saati 23:38 için 23ü 00dan büyük gördüğü için bu fonksiyonda gerekiyor.20.04.2018

                        }
                        catch
                        {
                            message = "SAAT FORMATINI İSTENİLEN ŞEKİLDE GİRİNİZ  !!";
                            GENELBILGI_MSG.Text = message;
                            GENELBILGI_MSG.ShowOnPageLoad = true;
                        }


                    }
                }
            }
        }
        protected void po_genel_bilgi_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GRD_CH_GENELBILGILER_PO.VisibleRowCount - 1; i++)
            {
                if (GRD_CH_GENELBILGILER_PO.GetRowValues(i, "BILGITNM").ToString() == "PO BOS POTA TONAJ")
                {

                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i - 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    TextBox deger2 = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    TextBox deger3 = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i + 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    if (deger2.Text != "" && deger.Text != "")
                    {
                        int deger8 = Convert.ToInt32(deger.Text);
                        int deger9 = Convert.ToInt32(deger2.Text);

                        if (deger8 >= deger9)
                        {
                            int net = Convert.ToInt32(deger.Text) - Convert.ToInt32(deger2.Text);
                            deger3.Text = net.ToString();
                        }
                        else
                        {
                            deger3.Text = "";
                        }
                    }
                }


                if (GRD_CH_GENELBILGILER_PO.GetRowValues(i, "BILGITNM").ToString() == "PO CIKIS SAATI")
                {

                    TextBox deger = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i - 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    TextBox deger2 = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    TextBox deger3 = (TextBox)GRD_CH_GENELBILGILER_PO.FindRowCellTemplateControl(i + 1, (DevExpress.Web.GridViewDataColumn)GRD_CH_GENELBILGILER_PO.Columns["DEGERI"], "txtDegeri8");
                    if (deger.Text != "" && deger2.Text != "")
                    {
                        DateTime d1 = DateTime.ParseExact(deger.Text, "HH:mm", null);
                        DateTime d2 = DateTime.ParseExact(deger2.Text, "HH:mm", null);
                        if (d2.Hour == d1.Hour && d2.Minute < d1.Minute)
                        {
                            deger3.Text = "";
                            //message = "PO GIRIS SAATI KISMININ DAKİKASINI TEKRAR DÜZENLEYİNİZ !!";
                            //GENELBILGI_MSG.Text = message;
                            //GENELBILGI_MSG.ShowOnPageLoad = true;

                        }
                        if (d2.Hour == d1.Hour && d1.Minute < d2.Minute)
                        {
                            TimeSpan t = d2.Subtract(d1);
                            int saat = int.Parse(t.Hours.ToString());
                            int dakika = int.Parse(t.Minutes.ToString());
                            int toplamFark = saat * 60 + dakika;
                            deger3.Text = toplamFark.ToString();

                        }
                        if (d2.Hour == d1.Hour && d2.Minute == d1.Minute)
                        {
                            deger3.Text = "0";

                        }
                        else
                        if (d2.Hour > d1.Hour && (d2.Minute >= d1.Minute || d1.Minute >= d2.Minute))
                        {
                            TimeSpan t = d2.Subtract(d1);
                            int saat = int.Parse(t.Hours.ToString());
                            int dakika = int.Parse(t.Minutes.ToString());
                            int toplamFark = saat * 60 + dakika;
                            deger3.Text = toplamFark.ToString();
                        }
                        if (d1.Hour > d2.Hour)
                        {
                            deger3.Text = "";

                        }
                        if (d2.Hour == 00 && d1.Hour != 00)
                        {
                            int giris_dakikasi = 60 - int.Parse(d1.Minute.ToString());
                            int total_dakika = giris_dakikasi + int.Parse(d2.Minute.ToString());
                            deger3.Text = total_dakika.ToString();
                        }   //örnek:çıkış saati 00:00  giriş saati 23:38 için 23ü 00dan büyük gördüğü için bu fonksiyonda gerekiyor. 20.04.2018
                    }
                }

            }
        }

        protected void GRD_CELIKHANE_DOKUMNO_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "dokum_listele")
            {
                dokum_listesi();
            }

        }
        protected void ASPxCallbackPanel_ALYAJ_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "alyaj_sakla")
            {

                if (KULLANICI == "CHAOOPR")
                {
                    alyaj_kayit_ao();

                }
                else if (KULLANICI == "CHPOOPR")
                {
                    alyaj_kayit_po();


                }
            }

            if (e.Parameter == "alyaj_listesi")
            {
                if (txt_DokumNo.Text != "")
                {
                    alyaj_listesi_ao(txt_DokumNo.Text);
                    alyaj_listesi_po(txt_DokumNo.Text);
                }
            }
            if (e.Parameter == "alyaj_listesi2")
            {
                alyaj_listesi_ao(txt_dokumno_ref_liste.Text);
                alyaj_listesi_po(txt_dokumno_ref_liste.Text);
            }

        }
        protected void ASPxCallbackPanel_HURDA_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "hurda_sakla")
            {
                if (KULLANICI == "CHAOOPR")
                {


                    hurda_kayit();
                    hurda_listesi(txt_DokumNo.Text);

                }
            }
            if (e.Parameter == "hurda_listesi")
            {
                if (txt_DokumNo.Text != "")
                {
                    hurda_listesi(txt_DokumNo.Text);
                }
                // HurdaListesi2();
            }
            if (e.Parameter == "hurda_listesi2")
            {
                hurda_listesi(txt_dokumno_ref_liste.Text);

            }

        }
        protected void ASPxCallbackPanel_SARFMALZEMELER_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "sarf_sakla")
            {
                if (KULLANICI == "CHSDMOPR")
                {
                    sarf_kayit_sdm();

                }
                else if (KULLANICI == "CHAOOPR")
                {
                    sarf_kayit_ao();

                }
            }

            if (e.Parameter == "sarf_liste")
            {
                if (txt_DokumNo.Text != "")
                {
                    sarf_listesi_sdm(txt_DokumNo.Text);
                    sarf_listesi_ao(txt_DokumNo.Text);
                }

            }

            if (e.Parameter == "sarf_liste2")
            {

                sarf_listesi_sdm(txt_dokumno_ref_liste.Text);
                sarf_listesi_ao(txt_dokumno_ref_liste.Text);

            }
        }
        protected void ASPxCallbackPanel_GENELBILGILER_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "genel_bilgi_sakla")
            {
                if (KULLANICI == "CHSDMOPR")
                {
                    genel_bilgi_kayit_sdm();

                }
                else if (KULLANICI == "CHAOOPR")
                {
                    genel_bilgi_kayit_ao();

                }
                else if (KULLANICI == "CHPOOPR")
                {
                    genel_bilgi_kayit_po();
                }

            }
            if (e.Parameter == "genel_bilgi_listesi")
            {
                if (txt_DokumNo.Text != "")
                {
                    genel_bilgi_listesi_sdm(txt_DokumNo.Text);
                    genel_bilgi_listesi_ao(txt_DokumNo.Text);
                    genel_bilgi_listesi_po(txt_DokumNo.Text);
                }
            }
            if (e.Parameter == "genel_bilgi_listesi2")
            {
                genel_bilgi_listesi_sdm(txt_dokumno_ref_liste.Text);
                genel_bilgi_listesi_ao(txt_dokumno_ref_liste.Text);
                genel_bilgi_listesi_po(txt_dokumno_ref_liste.Text);
            }


        }
        protected void ASPxCallbackPanel_ENERJI_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "enerji_sakla")
            {
                if (KULLANICI == "CHAOOPR") { enerji_kayit_ao(); }
                if (KULLANICI == "CHPOOPR") { enerji_kayit_po(); }
            }

            if (e.Parameter == "enerji_listesi")
            {
                if (txt_DokumNo.Text != "")
                {
                    enerji_liste_ao(txt_DokumNo.Text);
                    enerji_liste_po(txt_DokumNo.Text);
                }
            }
            if (e.Parameter == "enerji_listesi2")
            {

                enerji_liste_ao(txt_dokumno_ref_liste.Text);
                enerji_liste_po(txt_dokumno_ref_liste.Text);
            }
        }
        protected void ASPxCallbackPanel_KUTUKKAYIT_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "uretim_sakla")
            {
                uretim_kayit();
            }
            if (e.Parameter == "dokum_yeni_sira")
            {
                dokum_yeni_sira();
            }

            if (e.Parameter == "dokum_ac")
            {
                Dokum_ac();

            }
            if (e.Parameter == "dokum_sirasi_sil")
            {
                dokum_sirasi_sil();

            }
            if (e.Parameter == "dokum_kapat")
            {
                dokum_kapat(txt_DokumNo.Text);


            }

            if (e.Parameter == "dokumtipGetir")
            {

                dokum_tip_getir(Cmb_Celikcinsii.SelectedItem);
            }

            if (e.Parameter == "uretim_secilen_getir")
            {
                uretim_secilen_getir();
            }

            if (e.Parameter == "katsayiGetir")
            {
                //katsayiGetir();
            }
            if (e.Parameter == "standartKutukTonajiGetir")
            {
                standartKutukTonajiGetir();
            }
            if (e.Parameter == "sariKutukTonajiGetir")
            {
                sariKutukTonajiGetir();
            }
            if (e.Parameter == "stdKarisimTonajiGetir")
            {
                stdKarisimTonajiGetir();

            }
            if (e.Parameter == "transfer")
            {
                sicak_sarja_gonderilecek_kutuk();
            }
            if (e.Parameter == "uretim_bilgi")
            {
                if (txt_DokumNo.Text != "")
                {
                    uretim_secilen_getir_deneme();
                }


            }

        }
        protected void ASPxCallbackPanel_KUTUKLISTE_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "uretim_listesi")
            {
                if (txt_DokumNo.Text != "")
                {
                    uretim_liste();
                    toplam_tonaj_getir();
                }


            }

        }
        protected void ASPxCallbackPanel_DURUSLISTE_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "durus_liste")
            {

                durus_liste();

            }

        }
        protected void ASPxCallbackPanel_DURUSKAYIT_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "durus_kayit")
            {
                durus_kayit();
            }
            if (e.Parameter == "durus_sablon_getir")
            {
                durus_sablon_getir();
            }
            if (e.Parameter == "ArizaKodGetir")
            {
                ariza_kod_getir(Cmb_ArizaNeden.SelectedItem);

            }
            if (e.Parameter == "yeni_durus")
            {

                yeni_durus_Getir();
            }
            if (e.Parameter == "NetsureGetir")
            {
                net_sure_getir();
            }
            if (e.Parameter == "durus_bilgisi_getir")
            {
                durus_bilgisi_getir();
            }
            if (e.Parameter == "ariza_neden")
            {
                arizaNeden_cmbDoldur(txt_durusKod.Text);
            }
            if (e.Parameter == "durus_sil")
            {
                durus_delete();
            }

        }
        protected void ASPxCallbackPanel_Send_Ktk_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "send_ktk_dokum")
            {
                if (txt_DokumNo.Text != "")
                {
                    send_ktk_dokum_liste();
                }

            }

        }
        protected void ASPxCallbackPanel_REFRAKTERLISTE_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "refrakter_liste")
            {
                refrakter_listesi();
            }

        }
        protected void ASPxCallbackPanel_RefrakterKayit_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "refrakter_kayit")
            {
                refrakter_kayit();
            }
            if (e.Parameter == "refrakter_bilgi")
            {
                refrakter_bilgisi_getir();

            }
            if (e.Parameter == "yeni_refrakter")
            {
                yeni_refrakter();

            }

            if (e.Parameter == "pota_durum")
            {
                if (cmb_Potadurum.Text == "ISKARTA")
                {
                    Date_IskartaTarih.Enabled = true;
                }

            }
            if (e.Parameter == "refrakter_dokum_sil")
            {
                refrakter_dokum_sil();

            }

        }
        protected void ASPxCallbackPanel_Analiz_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "analiz_listesi")
            {

                analiz_listesi1();
                analiz_listesi2();

            }

            if (e.Parameter == "analiz_kayit")
            {

                analiz_kayit();



            }


        }
        protected void ASPxCallbackPanel_Dokum_Ozellikleri_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "dokum_ozellikleri_liste")
            {
                dokum_ozellikleri_liste();

            }

            if (e.Parameter == "dokum_ozellik_change")
            {

                dokum_ozellikleri_kayit();
            }

        }

        protected void btn_dokum_cagir_Click(object sender, EventArgs e)
        {
            if (txt_DokumNo.Text != "")
            {
                alyaj_listesi_ao(txt_DokumNo.Text);
                alyaj_listesi_po(txt_DokumNo.Text);
                hurda_listesi(txt_DokumNo.Text);
                sarf_listesi_sdm(txt_DokumNo.Text);
                sarf_listesi_ao(txt_DokumNo.Text);
                genel_bilgi_listesi_sdm(txt_DokumNo.Text);
                genel_bilgi_listesi_ao(txt_DokumNo.Text);
                genel_bilgi_listesi_po(txt_DokumNo.Text);
                enerji_liste_ao(txt_DokumNo.Text);
                enerji_liste_po(txt_DokumNo.Text);
                uretim_liste();
                toplam_tonaj_getir();
                send_ktk_dokum_liste();
                uretim_secilen_getir_deneme();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            KULLANICI = Session["KULLANICI"];
            Response.Redirect("../../Default2.aspx");
        }


    }
}
