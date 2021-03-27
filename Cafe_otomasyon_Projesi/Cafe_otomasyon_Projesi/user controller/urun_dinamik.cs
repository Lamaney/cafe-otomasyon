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
    public partial class urun_dinamik : UserControl
    {
        protected int Urun_id;
        protected string Urun_ad;
        protected float Urun_Fiyat;
        protected string Urun_Kategori;
        protected string Urun_fotograf;
        formlar.Urun_Duzenle duzenle = new formlar.Urun_Duzenle();
        public urun_dinamik()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void urun_dinamik_Load(object sender, EventArgs e)
        {


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

        void doldur(string ad, float fiyat, string fotograf)
        {
            label1.Text = ad;
            label2.Text = fiyat.ToString()+" TL";

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = fotograf;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            duzenle.urun_update(Urun_id, Urun_ad, Urun_Fiyat, Urun_Kategori, Urun_fotograf);
            duzenle.ShowDialog();
            
        }

        public void urun_Duzenle()
        {

        }
    
    }
}
