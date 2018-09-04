using diler.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using diler.Dal;
using System.Web.UI.WebControls;
using diler.Entity;

namespace diler.Web
{
    public partial class login1 : System.Web.UI.Page
    {
    
        Login_db db = new Login_db();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string user = txtKullanici.Text;
            user = user.ToUpper();
            string password = txtSifre.Text;
            Kullanici_giris(user, password);
        }


        private void Kullanici_giris(string user, string password)
        {

            if (user != "" && password != "")
            {
                db.Connect();
                string kullanici = db.kullanici_giris(user, password);

                db.Disconnect();
                if (kullanici != null)
                {
                    Session.Add("kullanici", user);
                    Session.Add("password", password);
                    Response.Redirect("Default2.aspx", false);

                }

                else
                {
                    Response.Write("<script language='javascript'>alert('Böyle bir kullanıcı bulunmamaktadır!!');</script>");
                }

            }

            else
            {
                Response.Redirect("Default2.aspx", false);
                //Response.Write("<script language='javascript'>alert('Lütfen Tüm Alanları Doldurunuz !!');</script>");

            }

        }


        //private void kullanici_bilgisi_getir(string user, string password)
        //{

        //    if (user != "")
        //    {
        //        List<Kullanici_bilgileri> kullanici_bilgileri = new List<Kullanici_bilgileri>();
        //        db.Connect();
        //        kullanici_bilgileri = db.kullanici_bilgisi_getir(user);    
        //        foreach (var kayit in kullanici_bilgileri)
        //        {

        //            Session.Add("IKIDSI", kayit.Ik_id);
        //            Session.Add("Personel_id", kayit.Ik_id);
        //            Session.Add("SIFRESI", password);
        //            Session.Add("KULLANICI_AD", kayit.Ik_adsadx);
        //            string kullanici_ozet = db.Ikden_Unite_bul(Convert.ToInt32(kayit.Ik_id));
        //            Session.Add("KULLANICI_OZET", kullanici_ozet);
        //        }

              
        //    }

        //    db.Disconnect();
        //}

    }
}
