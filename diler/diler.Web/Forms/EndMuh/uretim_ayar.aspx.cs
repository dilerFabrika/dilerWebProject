using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.EndMuh
{
    public partial class uretim_ayar : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        public string yeni_kutuk_sayisi, yeni_tonaj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                tx_rapor_tarihi.Text = tarih;
                raporu_getir(tarih.Replace("-", ""));
            }

        }

        private void raporu_getir(string tarih)
        {
            db.Connect();
            List<uretim_bilgileri> dokumler = new List<uretim_bilgileri>();
            dokumler = db.dokum_listesi(Convert.ToInt32(tarih));
            Grd_celikhane_uretim.DataSource = dokumler;
            Grd_celikhane_uretim.DataBind();
            db.Disconnect();
        }

        private void uretim_kayit_duzenleme()
        {
            db.Connect();
            string dokum_no, sira_no, kutuk_sayisi, mesaj, yazilan_deger;
            for (int i = 0; i <= Grd_celikhane_uretim.VisibleRowCount - 1; i++)
            {
                TextBox deger = (TextBox)Grd_celikhane_uretim.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)Grd_celikhane_uretim.Columns["degeri"], "txt_degeri");

                yazilan_deger = deger.Text.Equals("") ? "0" : deger.Text.ToString();
                if (yazilan_deger != "0")
                {
                    kutuk_sayisi = Grd_celikhane_uretim.GetRowValues(i, "KTKADET").ToString();
                    double tonaj = double.Parse(Grd_celikhane_uretim.GetRowValues(i, "STDKTKTONAJ").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    dokum_no = Grd_celikhane_uretim.GetRowValues(i, "DOKUMNO").ToString();
                    sira_no = Grd_celikhane_uretim.GetRowValues(i, "SIRANO").ToString();

                    string brm_tonaj = (Convert.ToDouble(tonaj) / Convert.ToDouble(kutuk_sayisi)).ToString().Replace(",", ".");
                    try
                    {
                        yeni_kutuk_sayisi = (Convert.ToInt32(kutuk_sayisi) + Convert.ToInt32(yazilan_deger)).ToString();
                        if (Convert.ToInt32(kutuk_sayisi) > 0)
                        {

                            mesaj = db.uretim_kayit(dokum_no, sira_no, yeni_kutuk_sayisi, brm_tonaj, tx_rapor_tarihi.Text.Replace("-", ""));
                            Uretim_message.Text = mesaj;
                            Uretim_message.ShowOnPageLoad = true;


                        }
                    }
                    catch
                    {
                        Uretim_message.Text = "LÜTFEN KÜTÜK SAYISINI İSTENİLEN FORMATTA GİRİNİZ ! ";
                        Uretim_message.ShowOnPageLoad = true;
                    }
                }
            }
            db.Disconnect();
        }
        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            raporu_al();
        }

        private void raporu_al()
        {
            string tarih = tx_rapor_tarihi.Text;
            raporu_getir(tarih.Replace("-", ""));

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void ASPxCallbackPanel_URETIM_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "uretim_kayit")
            {
                uretim_kayit_duzenleme();
                raporu_al();
            }
        }
    }
}