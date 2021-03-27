using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Cafe_otomasyon_Projesi.classlar
{
    class Masa_Ara_Class
    {
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");

        public void Hesap_Ode (int masa_no,float hesap_tutari)
        {
            string hesap_tarihi = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand hesap_ode = new SqlCommand("INSERT into Masa_Hesap  (Masa_No, Masa_Hesap,Hesap_Tarihi) values (@1,@2,@3)",baglanti);
                    hesap_ode.Parameters.AddWithValue("@1",masa_no);
                    hesap_ode.Parameters.AddWithValue("@2", hesap_tutari);
                    hesap_ode.Parameters.AddWithValue("@3", hesap_tarihi);
                    hesap_ode.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Hesap Ödendi", "Uyarı!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                
            }

        }
        
       
       


    }
}
