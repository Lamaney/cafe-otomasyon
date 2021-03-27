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
    public partial class Urun_Cikar : UserControl
    {

        protected int Urun_id;
        protected string Urun_ad;
        protected float Urun_Fiyat;
        protected string Urun_Kategori;
        protected string Urun_fotograf;

        public Urun_Cikar()
        {
            InitializeComponent();
        }


        private void Urun_Cikar_Load(object sender, EventArgs e)
        {

        }


        public void Urun_Cikar_Detay(int id, string ad, float Fiyat, string Kategori, string fotograf)
        {
            doldur(ad, Fiyat, fotograf);
            Urun_id = id;
            Urun_ad = ad;
            Urun_Fiyat = Fiyat;
            Urun_Kategori = Kategori;
            Urun_fotograf = fotograf;

            formlar.Masa_Detay_Form.masa_detay.Hesap_Flow.Controls.Add(this);
            
        }

        void doldur(string ad, float Fiyat, string fotograf)
        {

            label1.Text = ad;
            label2.Text = Fiyat.ToString() + " TL";

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = fotograf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formlar.Masa_Detay_Form.masa_detay.hesap_cikar(Urun_Fiyat);
            formlar.Masa_Detay_Form.masa_detay.Hesap_Flow.Controls.Remove(this);
        }
    }
}
