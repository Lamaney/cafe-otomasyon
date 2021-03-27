using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using Cafe_otomasyon_Projesi.formlar;
using System.Data;
using System.Drawing;

namespace Cafe_otomasyon_Projesi
{
    public partial class Personel_Bilgi : UserControl
    {
        protected string per_ad;
        protected string per_soyad;
        protected string per_telefon;
        protected string per_email;
        protected string per_gorev;
        protected string per_cinsiyet;
        protected string per_tarih;
        protected string per_fotograf;
        protected int per_id;

        classlar.Sql_İslemleri sql_İslemleri = new classlar.Sql_İslemleri();

        public void per_bilgi(int id,string ad, string soyad, string telefon, string email, string gorev, string cinsiyet, string tarih,string fotograf)
        {
            Dinamik_doldurma(ad, soyad, gorev,fotograf);
            per_id = id;
            per_ad = ad;
            per_soyad = soyad;
            per_telefon = telefon;
            per_email = email;
            per_gorev = gorev;
            per_cinsiyet = cinsiyet;
            per_tarih = tarih;
            per_fotograf = fotograf;

        }
        
        public Personel_Bilgi()
        {
            InitializeComponent();
        }

        private void Personel_Bilgi_Load(object sender, EventArgs e)
        {
           


        }

        private void Bilgi_Al_Btn_Click(object sender, EventArgs e)
        {

            formlar.Per_Duzenle perduzenle = new Per_Duzenle();
            perduzenle.detay_getir(per_id,per_ad, per_soyad, per_telefon, per_email, per_gorev, per_cinsiyet, per_tarih,per_fotograf);
            perduzenle.ShowDialog();
        }
        
        private void Dinamik_doldurma(string ad,string soyad,string gorev,string foto_path)
        {
          
               
            try
            {
                label1.Text = ad + " " + soyad;
                label2.Text = gorev;
               pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = foto_path;

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                throw;
            }

                          



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql_İslemleri.Personel_Sil(per_id);
            Personel_Form.per_form.per_cek();
        }
    }
}
