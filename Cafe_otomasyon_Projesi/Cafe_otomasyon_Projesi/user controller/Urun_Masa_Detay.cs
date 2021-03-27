using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_otomasyon_Projesi.user_controller
{
    public partial class Urun_Masa_Detay : UserControl
    {
        protected int Urun_id;
        protected string Urun_ad;
        protected float Urun_Fiyat;
        protected string Urun_Kategori;
        protected string Urun_fotograf;

        public Urun_Masa_Detay()
        {
            InitializeComponent();
        }

        public void urun_detay(int id, string ad, float Fiyat, string Kategori, string fotograf)
        {

            doldur(ad, Fiyat, fotograf);
            Urun_id = id;
            Urun_ad = ad;
            Urun_Fiyat = Fiyat;
            Urun_Kategori = Kategori;
            Urun_fotograf = fotograf;

        }

        private void Urun_Masa_Detay_Load(object sender, EventArgs e)
        {

        }


        void doldur(string ad, float fiyat, string fotograf)
        {
            label1.Text = ad;
            label2.Text = fiyat.ToString() + " TL";

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = fotograf;

        }

        private void Urun_Masa_Detay_MouseClick(object sender, MouseEventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formlar.Masa_Detay_Form.masa_detay.hesap_ekle(Urun_Fiyat);
            Urun_Cikar urun_hesap = new Urun_Cikar();
            urun_hesap.Urun_Cikar_Detay(Urun_id, Urun_ad, Urun_Fiyat, Urun_Kategori, Urun_fotograf);
        }

        
        

    }
}
