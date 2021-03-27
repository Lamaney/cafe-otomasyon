using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Muhasebe_Form : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");

        public static Muhasebe_Form muhasebe_Form;
        public Muhasebe_Form()
        {
            InitializeComponent();
        }
        public float f_gider=0;
        public float f_gelir=0;
        public float y_gelir = 0;
        private void Muhasebe_Form_Load(object sender, EventArgs e)
        {
            muhasebe_Form = this;
            
            gider_reader();
            gelir_reader();
            Reader();
            label6.Text = f_gelir.ToString();
            label7.Text = f_gider.ToString();

        }


        public void Reader()
        {
          f_gelir= 0;
            Masa_hesap_flow.Controls.Clear();
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand read = new SqlCommand("Select *from Masa_Hesap ", baglanti);
                    SqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        int no = int.Parse(reader["Masa_no"].ToString());
                        float hesap = float.Parse(reader["Masa_hesap"].ToString());
                        string tarih = reader["Hesap_tarihi"].ToString();

                       
                            f_gelir += hesap;
                            
                            
                       
                        
                       
                        user_controller.Muhasebe_Dinamik dinamik = new user_controller.Muhasebe_Dinamik();
                        dinamik.dinamik(no, hesap, tarih);
                    }

                    baglanti.Close();
                    f_gelir += y_gelir;
                    label6.Text = f_gelir.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        public void gider_reader()
        {
            f_gider = 0;
          
            Gider_Flow.Controls.Clear();
           
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand read = new SqlCommand("Select *from Gider ", baglanti);
                    SqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        string aciklama = reader["Gider_Aciklama"].ToString();
                        float gider=float.Parse(reader["Gider"].ToString());
                        user_controller.Gider_Dinamik gider_dinamik = new user_controller.Gider_Dinamik();
                        gider_dinamik.dinamik(aciklama, gider);
                        f_gider += gider;
                        
                    }
                    
                    baglanti.Close();
                    f_gelir += y_gelir;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void gelir_reader()
        {
           Gelir_flow.Controls.Clear();
            y_gelir = 0;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand read = new SqlCommand("Select *from Gelir_Table ", baglanti);
                    SqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        string aciklama = reader["Gelir_Aciklama"].ToString();
                        float gelir = float.Parse(reader["Gelir"].ToString());
                        y_gelir += gelir;
                        user_controller.Gelir_Dinamik gelir_Dinamik = new user_controller.Gelir_Dinamik();
                        gelir_Dinamik.dinamik(aciklama, gelir);
                       

                    }

                    baglanti.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Gelir_Gider_Form form = new Gelir_Gider_Form();
            form.gelir_gider_goster("gelir");
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gelir_Gider_Form form = new Gelir_Gider_Form();
            form.gelir_gider_goster("gider");
            form.ShowDialog();
        }
    }
}
