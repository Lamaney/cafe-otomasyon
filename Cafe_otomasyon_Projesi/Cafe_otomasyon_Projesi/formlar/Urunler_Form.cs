using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Urunler_Form : Form
    {
        public static Urunler_Form urunler;
        formlar.Urun_Ekle_Form urun_ekle = new Urun_Ekle_Form();
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");

        public Urunler_Form()
        {
            InitializeComponent();
        }

        private void Urunler_Form_Load(object sender, EventArgs e)
        {
            urunler = this;
            Urun_cek();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            urun_ekle.ShowDialog();
        }
    
    
        public void Urun_cek()
        {
            Kahveler_Flow.Controls.Clear();
            Tatlilar_Flow.Controls.Clear();
            Yemekler_Flow.Controls.Clear();
            İcecekler_Flow.Controls.Clear();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand oku = new SqlCommand("Select * from Urunler", baglanti);
                    SqlDataReader reader = oku.ExecuteReader();
                    while (reader.Read())
                    {
                        user_controller.urun_dinamik dinamik_urun = new user_controller.urun_dinamik();
                        int id = int.Parse(reader["Urun_id"].ToString());
                        string urun_adi = reader["Urun_Adi"].ToString();
                        float fiyat = float.Parse(reader["Urun_Fiyat"].ToString());
                        string Urun_Fotgari = reader["Urun_Fotografi"].ToString();
                        string kategori = reader["Urun_Kategori"].ToString();
                        
                        switch (kategori)
                        {
                            case "Kahve":
                                dinamik_urun.urun_detay(id, urun_adi, fiyat, kategori, Urun_Fotgari);
                                Kahveler_Flow.Controls.Add(dinamik_urun);
                                break;
                            case "Tatlı":
                                dinamik_urun.urun_detay(id, urun_adi, fiyat, kategori, Urun_Fotgari);
                                Tatlilar_Flow.Controls.Add(dinamik_urun);
                                break;
                            case "Yiyecek":
                                dinamik_urun.urun_detay(id, urun_adi, fiyat, kategori, Urun_Fotgari);
                                Yemekler_Flow.Controls.Add(dinamik_urun);
                                break;
                            case "İçecek":
                                dinamik_urun.urun_detay(id, urun_adi, fiyat, kategori, Urun_Fotgari);
                                İcecekler_Flow.Controls.Add(dinamik_urun);
                                break;

                        }
                    }

                    baglanti.Close();

                    


                }
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

               
            }


        }
    
    }
}
