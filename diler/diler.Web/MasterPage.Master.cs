
using diler.Dal;
using diler.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace diler.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        Login_db db = new Login_db();
        public string Left_substr_donen;
        public ArrayList MenuList = new ArrayList();
        public object kullanici, password;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                kullanici = Session["kullanici"];
                ana_menu_listesi();
                Giris();

            }

            else
            {
                kullanici = Session["kullanici"];
                Giris();
            }
        }

        public void ana_menu_listesi()
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            DevExpress.Web.NavBarGroup group1 = new DevExpress.Web.NavBarGroup();
            DevExpress.Web.NavBarItem item1 = new DevExpress.Web.NavBarItem();

            kullanici = Session["kullanici"];

            db.Connect();
            kayitlar = db.ana_menu_gorulecekler(kullanici);
            foreach (var kayit in kayitlar)
            {

                if (kayit.birim != "0")
                {
                    AnaMenuList.Groups.Add(kayit.birim, kayit.birim);

                    Left_substr_donen = LEFT_SUBSTR("PRGLIST.PRGKOD", 1);
                    kayitlar = db.ana_menu_listesi(kullanici, Left_substr_donen, kayit.birim);
                    foreach (var kayitx in kayitlar)
                    {

                        if (kayitx.donen.ToString().Length > 0)
                            AnaMenuList.Groups.FindByName(kayit.birim).Items.Add(kayitx.donen, kayitx.prg_ad);

                    }
                    if (kayit.birim == "IK")
                    {
                       
                       AnaMenuList.Groups.FindByName("IK").Items.Add("Yıllık izin", "Yillikizin");

                    }

                    }
              
            }
                //else
                //{
                //    AnaMenuList.Groups.Add("IK", "IK");
                //    AnaMenuList.Groups.FindByName("IK").Items.Add("Yillikizin", "Yillikizin");
                //}
            
            db.Disconnect();


        }

        public string LEFT_SUBSTR(object GELEN, object karakterSay)
        {

            Left_substr_donen = "SUBSTR(" + GELEN + ",1," + karakterSay + ")";
            return Left_substr_donen;

        }
        private void Giris()
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            kullanici = Session["kullanici"];
            password = Session["password"];
            db.Connect();
            kayitlar = db.kullanici_bilgisi_getir(kullanici);

            foreach (var kayit in kayitlar)
            {
                Session.Add("IKIDSI", kayit.Ik_id);
                Session.Add("Personel_id", kayit.Ik_id);
                Session.Add("SIFRESI", password);
                Session.Add("KULLANICI_AD", kayit.Ik_adsadx);
                Session.Add("FRMKOD", kayit.FRMKOD);
                string kullanici_ozet = db.Ikden_Unite_bul(Convert.ToInt32(kayit.Ik_id));
                Session.Add("KULLANICI_OZET", kullanici_ozet);

                if (kayit.FRMKOD == "M")
                {
                    GirisWebSip();
                    Response.Write("<script>");
                    Response.Redirect("Forms/WebSip/CubukSiparis.aspx", false);
                    Response.Write("</script>");

                }

            }
            db.Disconnect();



        }


        private void GirisWebSip()
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            kullanici = Session["kullanici"];
            password = Session["password"];
            db.Connect();
            kayitlar = db.kullanici_bilgisi_getirWebSip(kullanici, password);

            foreach (var kayit in kayitlar)
            {

                Session.Add("PRGKOD", kayit.PRGKOD);
                Session.Add("KULLANICI", kayit.Ik_adsadx);
                Session.Add("USRNAME", kullanici);
                Session.Add("PASSWORD", password);
                Session.Add("IPADRES", kayit.IPADRES);

            }
            db.Disconnect();

        }

        protected void ASPxMenu1_ItemClick1(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Text == "Diler Holding")
            {
                Response.Write("<script>");
                Response.Write("window.open('http://www.dilerhld.com/','_blank')");
                Response.Write("</script>");

            }

            if (e.Item.Text == "ENVIDAS")
            {

                Response.Write("<script>");
                Response.Write("window.open('http://81.214.137.169','_blank')");
                Response.Write("</script>");

            }

            if (e.Item.Text == "Holding Raporları")
            {
                
                Response.Write("<script>");
                Response.Write("window.open('http://192.168.198.192/Dlrrapor/default.aspx','_blank')");           
                Response.Write("</script>");


            }

            if (e.Item.Text == "ÇIKIŞ")
            {
                Response.Write("<script>");
                Response.Redirect("Login.aspx", false);
                Response.Write("</script>");
            }


            if (e.Item.Text == "DUSWEB")
            {
                Response.Write("<script>");
                Response.Write("window.open('http://192.168.199.242:9080/dusWeb?view=TalepView&user=','_blank')");
                Response.Write("</script>");

            }
          

            if (e.Item.Text == "BOYS")
            {
                Response.Write("<script>");
                Response.Write("window.open('http://192.168.198.1/boysweb2/default.aspx','_blank')");
                Response.Write("</script>");

            }
            if (e.Item.Text == "ENTEGRE POLİTİKAMIZ")
            {
                Response.Write("<script>");
                Response.Write("window.open('../../entegrePolitika/ENTEGRE POLİTİKA 2018.pdf','_blank')");
          
                Response.Write("</script>");

            }
        }

        protected void AnaMenuList_ItemClick1(object source, DevExpress.Web.NavBarItemEventArgs e)
        {
            Response.Write("<script>");
            Response.Redirect("/Forms/" + e.Item.Group.Name + "/" + e.Item.Name + ".aspx", false);
          
            Response.Write("</script>");

        }
    }
}