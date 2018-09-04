using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_sarfmalzeme
    {
        private int id;
        private string kalite;
        private string hurda;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;
        private string ladle_shroud_adet;
        private string ladle_shroud_gasket_adet;
        private string tundish_c_m_p_asidik_kg;
        private string tundish_c_m_p_bazik_kg;
        private string tundish_c_m_p_w_kg;
        private string natural_gas_m3;
        private string ses_shroud_adet;
        private string scorialit_sph_c_411_81_e_kg;
        private string scorialit_sph_c_176_als_9_kg;
        private string scorialit_sph_c_189_v_3_kg;
        private string ramag_92p_ramming_mass_kg;
        private string melting_gasket_c52_adet;
        private string scorialit_sph_c_189_gm_23_kg;
        private string scorialit_sph_c_189_e_3_kg;
        private string sph_c_189_vv1;
        private string brl_o2;
        private string elti_o2;
        private string rcb_ref_o2;
        private string rcb_brl_o2;





        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    id = 0;
                }
                else
                {
                    id = value;
                }
            }
        }

        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
        }
        public string Hurda
        {
            get { return hurda; }
            set { hurda = value; }
        }
        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }
        public string Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public string Dokum_tip
        {
            get { return dokum_tip; }
            set { dokum_tip = value; }
        }
        public string Sip_no
        {
            get { return sip_no; }
            set { sip_no = value; }
        }
        public string Ladle_shroud_adet
        {
            get { return ladle_shroud_adet; }
            set { ladle_shroud_adet = value; }
        }
        public string Ladle_shroud_gasket_adet
        {
            get { return ladle_shroud_gasket_adet; }
            set { ladle_shroud_gasket_adet = value; }
        }
        public string Tundish_c_m_p_asidik_kg
        {
            get { return tundish_c_m_p_asidik_kg; }
            set { tundish_c_m_p_asidik_kg = value; }
        }
        public string Tundish_c_m_p_bazik_kg
        {
            get { return tundish_c_m_p_bazik_kg; }
            set { tundish_c_m_p_bazik_kg = value; }
        }
        public string Tundish_c_m_p_w_kg
        {
            get { return tundish_c_m_p_w_kg; }
            set { tundish_c_m_p_w_kg = value; }
        }
        public string Natural_gas_m3
        {
            get { return natural_gas_m3; }
            set { natural_gas_m3 = value; }
        }
        public string Ses_shroud_adet
        {
            get { return ses_shroud_adet; }
            set { ses_shroud_adet = value; }
        }
        public string Scorialit_sph_c_411_81_e_kg
        {
            get { return scorialit_sph_c_411_81_e_kg; }
            set { scorialit_sph_c_411_81_e_kg = value; }
        }
        public string Scorialit_sph_c_176_als_9_kg
        {
            get { return scorialit_sph_c_176_als_9_kg; }
            set { scorialit_sph_c_176_als_9_kg = value; }

        }
        public string Scorialit_sph_c_189_v_3_kg
        {
            get { return scorialit_sph_c_189_v_3_kg; }
            set { scorialit_sph_c_189_v_3_kg = value; }
        }
        public string Ramag_92p_ramming_mass_kg
        {
            get { return ramag_92p_ramming_mass_kg; }
            set { ramag_92p_ramming_mass_kg = value; }
        }
        public string Melting_gasket_c52_adet
        {
            get { return melting_gasket_c52_adet; }
            set { melting_gasket_c52_adet = value; }
        }
        public string Scorialit_sph_c_189_gm_23_kg
        {
            get { return scorialit_sph_c_189_gm_23_kg; }
            set { scorialit_sph_c_189_gm_23_kg = value; }
        }
        public string Scorialit_sph_c_189_e_3_kg
        {
            get { return scorialit_sph_c_189_e_3_kg; }
            set { scorialit_sph_c_189_e_3_kg = value; }
        }
        public string Sph_c_189_vv1
        {
            get { return sph_c_189_vv1; }
            set { sph_c_189_vv1 = value; }
        }
        public string Brl_o2
        {
            get { return brl_o2; }
            set { brl_o2 = value; }
        }
        public string Elti_o2
        {
            get { return elti_o2; }
            set { elti_o2 = value; }
        }
        public string Rcb_ref_o2
        {
            get { return rcb_ref_o2; }
            set { rcb_ref_o2 = value; }
        }

        public string Rcb_brl_o2
        {
            get { return rcb_brl_o2; }
            set { rcb_brl_o2 = value; }
        }


    }
}
