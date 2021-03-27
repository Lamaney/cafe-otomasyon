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
    public partial class Masa_Detay_Form : Form
    {
        classlar.Sql_İslemleri sql_query = new classlar.Sql_İslemleri();
        public static Masa_Detay_Form masa_detay;

        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");

        protected int numara;
        protected bool durum;
        protected float toplam=0;

        public void a(int a, bool b)
        {
            numara = a;
            durum = b;


        }

        public Masa_Detay_Form()
        {

            InitializeComponent();

            masa_detay = this;

        }
        
        user_controller.Masa renk;


        public void obje_al (user_controller.Masa masa_use){

            
            renk = masa_use;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Masa_Detay_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
          
           
            Masa_renk_degistir();
        }

        private void Masa_Detay_Form_Load(object sender, EventArgs e)
        {
            Urun_cek();

            masa_detay = this;
        }

        public void Masa_renk_degistir()
        {
            if (this.Hesap_Flow.Controls.Count==0)
            {
                renk.BackColor = Color.White;
            }

            else
            {
                renk.BackColor = Color.FromArgb(150, 114, 89);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        public void hesap_cikar(float fiyat)
        {
            toplam -= fiyat;
             label7.Text = toplam.ToString()+" TL";
        }

        public void hesap_ekle(float fiyat)
        {
            toplam += fiyat;
            label7.Text = toplam.ToString()+" TL";
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
                        user_controller.Urun_Masa_Detay dinamik_urun = new user_controller.Urun_Masa_Detay();
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

        private void button2_Click(object sender, EventArgs e)
        {
            classlar.Masa_Ara_Class hesap = new classlar.Masa_Ara_Class();
            hesap.Hesap_Ode(numara,toplam);
            Hesap_Flow.Controls.Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Masa iptal edilecek, emin misiniz?","uyarı",MessageBoxButtons.YesNoCancel);

            if (sonuc==DialogResult.Yes)
            {
                Hesap_Flow.Controls.Clear();
                this.Close();
            }
        }
    }
}
