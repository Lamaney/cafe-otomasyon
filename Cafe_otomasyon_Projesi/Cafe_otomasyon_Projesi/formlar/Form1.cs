
using Cafe_otomasyon_Projesi.formlar;
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


namespace Cafe_otomasyon_Projesi
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// form içinde sayfaları gösteren araç.
        /// </summary>
        Masa_Form masa_pencere = new Masa_Form();
        Personel_Form personel_pencere = new Personel_Form();
        Urunler_Form urunler_pencere = new Urunler_Form();
        Muhasebe_Form muhasebe = new Muhasebe_Form();
        public static Form1 anaform;
        public void pencere_acma(string acilacak_pencere)
        {
            switch (acilacak_pencere)
            {
                case "masa":
                    panel2.Controls.Clear();
                    masa_pencere.TopLevel = false;
                    masa_pencere.Dock = DockStyle.Fill;
                    panel2.Controls.Add(masa_pencere);
                    masa_pencere.Show();
                    break;

                case "personel":
                    panel2.Controls.Clear();
                    personel_pencere.TopLevel = false;
                    personel_pencere.Dock = DockStyle.Fill;
                    panel2.Controls.Add(personel_pencere);
                    personel_pencere.Show();
                    //personel_pencere.per_cek();
                    break;
                case "urunler":
                    panel2.Controls.Clear();
                    urunler_pencere.TopLevel = false;
                    urunler_pencere.Dock = DockStyle.Fill;
                    panel2.Controls.Add(urunler_pencere);
                    urunler_pencere.Show();
                    break;
                case "muhasebe":
                    panel2.Controls.Clear();
                    muhasebe.TopLevel = false;
                    muhasebe.Dock = DockStyle.Fill;
                    panel2.Controls.Add(muhasebe);
                    muhasebe.Show();
                    Muhasebe_Form.muhasebe_Form.Reader();
                    break;
            }
        }

       
        //------------------------------------------------------------------------------------------------------------

        private void Form1_Load(object sender, EventArgs e)
        {

           

            pencere_acma("masa");

        }






        
        public Form1()
        {
            InitializeComponent();
            
           
        }


        

       

        private void Masalar_Btn_Click(object sender, EventArgs e)
        {
            Side_Panel.Top = Masalar_Btn.Top;
            Side_Panel.Height = Masalar_Btn.Height;
            pencere_acma("masa");
        }

        private void Personel_Btn_Click(object sender, EventArgs e)
        {
            Side_Panel.Top = Personel_Btn.Top;
            Side_Panel.Height = Personel_Btn.Height;
           
            pencere_acma("personel");
        }

        private void Urunler_Btn_Click(object sender, EventArgs e)
        {
            Side_Panel.Top = Urunler_Btn.Top;
            Side_Panel.Height = Urunler_Btn.Height;
            pencere_acma("urunler");
        }

        private void Muhasebe_btn_Click(object sender, EventArgs e)
        {
            Side_Panel.Top = Muhasebe_btn.Top;
            Side_Panel.Height = Urunler_Btn.Height;
            pencere_acma("muhasebe");
        }

        private void Kapatma_Btn_Click_1(object sender, EventArgs e)
        {
            
            DialogResult cikis_onay = MessageBox.Show("Programdan Çıkmak İstiyor musunuz?", "Uyarı!", MessageBoxButtons.YesNo);

            if (cikis_onay == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

       

        private void Bilgi_Al_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Ayarlar_Btn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
