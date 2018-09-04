using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using AjaxControlToolkit;
using System.Text;

namespace diler.Web.Forms.Kimya
{
    public partial class istif_giris : System.Web.UI.Page
    {
        Istife_kutuk_gonderimi_db db = new Istife_kutuk_gonderimi_db();
        List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
        List<Istif_bilgileri> veriler = new List<Istif_bilgileri>();

        public string gelentarih;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public dynamic tarih_format(object gelen)
        {

            dynamic yil = Convert.ToDateTime(gelen).Year.ToString();
            dynamic ay = Convert.ToDateTime(gelen).Month.ToString();
            dynamic gun = Convert.ToDateTime(gelen).Day.ToString();
            if (ay.Length == 1)
            {
                ay = "0" + ay;
            }
            if (gun.Length == 1)
            {
                gun = "0" + gun;
            }
            gelentarih = yil + ay + gun;
            return gelentarih;

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void ASPxCallbackPanel_istif_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "satiri_sil")
            {
                istif_ide_gore_kayit_sil();

            }

            if (e.Parameter == "istif_kayit")
            {
                istif_kayitlarinin_tumunu_kaydet();

            }

            if (e.Parameter == "kopyanilan_satiri_yapistir")
            {
                kopyanilan_satiri_yapistir();

            }



        }

        private void kopyanilan_satiri_yapistir()
        {
            StringBuilder htmlTable = new StringBuilder();
            int satir = Convert.ToInt32(txt_paste.Text);
            object kopyanilan_satir_istif_id = txt_copy.Text;

            if (kopyanilan_satir_istif_id.ToString() != "")
            {
                TextBox istiftarihi = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Dokum_tarihi"], "txt_istif_tarihi"));
                TextBox dokumno = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Dokum_no"], "txt_dokumno"));
                TextBox istifyeri = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Istif_yeri"], "txt_Istif_yeri"));
                TextBox istifadet = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["istif_adet"], "txt_istif_adet"));
                TextBox celikcinsi = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Celik_cinsi"], "txt_celik_cinsi"));
                TextBox boy = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Boy"], "txt_boy"));
                TextBox ebat = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Ebat"], "txt_ebat"));
                TextBox sipno = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Sipno"], "txt_sipno"));
                TextBox lot = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Lot"], "txt_lot"));
                TextBox aciklama = (TextBox)(Grd_istif.FindRowCellTemplateControl(satir, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Aciklama"], "txt_aciklama"));
                db.Connect();

                kayitlar = db.istif_ide_gore_copy_paste(Convert.ToInt32(kopyanilan_satir_istif_id));
                db.Disconnect();
                foreach (var kayit in kayitlar)
                {
                    istiftarihi.Text = kayit.Dokum_tarihi;
                    dokumno.Text = "";
                    istifyeri.Text = kayit.Istif_yeri;
                    istifadet.Text = "";
                    celikcinsi.Text = kayit.Celik_cinsi;
                    boy.Text = kayit.Boy;
                    ebat.Text = kayit.Ebat;
                    sipno.Text = kayit.Sipno;
                    lot.Text = kayit.Lot;
                    aciklama.Text = kayit.Aciklama;


                }
            }
            else
            {
                istif_message.Text = "LÜTFEN KOPYALAMAK İSTEDİĞİNİZ SATIRI SEÇİNİZ";
                istif_message.ShowOnPageLoad = true;
            }

        }

        private void istif_kayitlarinin_tumunu_kaydet()
        {
            db.Connect();
            string celik_cinsi_orj, istif_id, istif_tarihi;
            string stok_yeri = "";
            string istif_yeri = "";
            string saha_tanim = "";
            for (int i = 0; i <= Grd_istif.VisibleRowCount - 1; i++)
            {
                istif_id = Grd_istif.GetRowValues(i, "Id").ToString();
                TextBox sirano = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Istif_sirano"], "txt_sirano"));
                TextBox istiftarihi = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Dokum_tarihi"], "txt_istif_tarihi"));
                TextBox dokumno = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Dokum_no"], "txt_dokumno"));
                TextBox istifyeri = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Istif_yeri"], "txt_Istif_yeri"));
                TextBox istifadet = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["istif_adet"], "txt_istif_adet"));
                //stok_yeri = Cmb_stok_yeri.Text;
                TextBox celikcinsi = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Celik_cinsi"], "txt_celik_cinsi"));
                TextBox boy = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Boy"], "txt_boy"));
                TextBox ebat = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Ebat"], "txt_ebat"));
                TextBox sipno = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Sipno"], "txt_sipno"));
                celik_cinsi_orj = celikcinsi.Text;
                TextBox lot = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Lot"], "txt_lot"));

                TextBox aciklama = (TextBox)(Grd_istif.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_istif.Columns["Aciklama"], "txt_aciklama"));


                istif_tarihi = istiftarihi.Text;
                if (istif_tarihi != "")
                {
                    gelentarih = tarih_format(istif_tarihi);
                }
                
                istif_yeri = istifyeri.Text;

                if (istif_yeri != "")
                {
                    veriler = db.stokYeri_v_sahaTanim_bul(istif_yeri);
                    foreach (var kayit in veriler)
                    {
                        stok_yeri = kayit.Stok_yeri;
                        saha_tanim = kayit.Saha_tanim;
                    }

                    istif_Insert(sirano.Text, gelentarih, dokumno.Text, stok_yeri, istif_yeri, istifadet.Text, celikcinsi.Text, boy.Text, ebat.Text, sipno.Text, lot.Text, saha_tanim, aciklama.Text, istif_id);
                }
                else
                {
                    istif_message.Text = "İSTİF YERİ ALANININI BOŞ BIRAKAMAZSINIZ. ";
                    istif_message.ShowOnPageLoad = true;
                }

            }
            try
            {
                istif_yeri = Cmb_istif_yeri.SelectedItem.ToString().Substring(0, 2).Trim();
                kayitlar = db.istifleri_listele(stok_yeri, istif_yeri.ToString());
                Grd_istif.DataSource = kayitlar;
                Grd_istif.DataBind();

            }
            catch
            {
                istif_message.Text = "TABLODA KAYIT YOK EKLEME YAPAMAZSINIZ.";
                istif_message.ShowOnPageLoad = true;
            }

            db.Disconnect();


        }

        private void istif_Insert(string sira_no, string istif_tarihi, string dokum_no, string stok_yeri, string istif_yeri,
            string istif_adet, string celik_cinsi, string boy, string ebat, string sipno, string lot, string saha_tanim, string aciklama, string istif_id)
        {

            string mesaj = db.all_row_insert(sira_no.Trim(), istif_tarihi, dokum_no.Trim(), stok_yeri,
                                            istif_yeri.Trim(), istif_adet.Trim(), celik_cinsi,
                                            boy.Trim(), ebat.Trim(), sipno, lot, saha_tanim, aciklama, istif_id);

            istif_message.Text = mesaj;
            istif_message.ShowOnPageLoad = true;

        }

        private void istif_ide_gore_kayit_sil()
        {
            string stok_yeri;
            db.Connect();
            string istif_id = txt_istif_id.Text;
            if (istif_id != "" && istif_id != null)
            {
                string row_delete = db.row_delete(Convert.ToInt32(istif_id));

                txt_istif_id.Value = null;

                txt_istif_id.Text = " ";


                if (Cmb_istif_yeri.Text != "İstif yeri seçiniz")
                {
                    //string stok_yeri = Cmb_stok_yeri.SelectedItem.ToString();                
                    string istif_yeri = Cmb_istif_yeri.SelectedItem.ToString().Substring(0, 2).Trim();

                    if (Convert.ToInt32(istif_yeri) >= 50)
                    {
                        stok_yeri = "Çelikhane";

                    }
                    else
                    {
                        stok_yeri = "Haddehane";
                    }

                    kayitlar = db.istifleri_listele(stok_yeri, istif_yeri);
                    Grd_istif.DataSource = kayitlar;
                    Grd_istif.DataBind();



                }
            }
            db.Disconnect();
        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string stok_yeri;
            if (Cmb_istif_yeri.Text != "İstif yeri seçiniz")
            {
                string istif_yeri = Cmb_istif_yeri.SelectedItem.ToString().Substring(0, 2).Trim();

                if (Convert.ToInt32(istif_yeri) >= 50)
                {
                    stok_yeri = "Çelikhane";

                }
                else
                {
                    stok_yeri = "Haddehane";
                }

                db.Connect();
                kayitlar = db.istifleri_listele(stok_yeri, istif_yeri);
                Grd_istif.DataSource = kayitlar;
                Grd_istif.DataBind();


                db.Disconnect();

            }
        }


        protected void btn_row_insert_Click(object sender, EventArgs e)
        {
            string stok_yeri;
            if (Cmb_istif_yeri.Text != "İstif yeri seçiniz")
            {

                string saha_tanim = Cmb_istif_yeri.SelectedItem.ToString().Substring(2).Trim();
                string istif_yeri = Cmb_istif_yeri.SelectedItem.ToString().Substring(0, 2).Trim();

                if (Convert.ToInt32(istif_yeri) >= 50)
                {
                    stok_yeri = "Çelikhane";

                }
                else
                {
                    stok_yeri = "Haddehane";
                }
                db.Connect();
                string single_row_insert = db.single_row_insert(Convert.ToInt32(istif_yeri), stok_yeri, saha_tanim);
                kayitlar = db.istifleri_listele(stok_yeri, istif_yeri);
                Grd_istif.DataSource = kayitlar;
                Grd_istif.DataBind();
                db.Disconnect();

            }
            else
            {

                istif_message.Text = "İSTİF YERİ SEÇİNİZ ";
                istif_message.ShowOnPageLoad = true;
            }
        }


        protected void btn_yedekleme_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string tarih = dt.ToString();

            db.Connect();

            string yedekleme = db.istif_kayitlari_yedekleme(tarih);


            db.Disconnect();
            istif_message.Text = " " + tarih + " TARİHİNDE İSTİFTE BULUNAN TÜM KAYITLAR YEDEK ALINDI. ";
            istif_message.ShowOnPageLoad = true;


        }

    }
}