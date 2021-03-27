using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Masalar_Form : Form
    {
        int sayac ;
        private void masa_ekle()
        {
            

                for (sayac=1; sayac< 31; sayac++)
                {
                    Button masa = new Button();
                    masa.Name = "masa " + Convert.ToString(sayac);
                    masa.Text = "masa " + Convert.ToString(sayac);
                    masa.Size = new Size(200, 200);
                    masa.FlatStyle = FlatStyle.Flat;
            
                    masa.TextAlign = ContentAlignment.BottomCenter;
                     masa.BackgroundImageLayout = ImageLayout.Center;

                    masa.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.table_restaurant___Kopya1));
                    masa.FlatAppearance.BorderSize = 0;

                    Masalar_Flow.Controls.Add(masa);
                    masa.Click += Masa_Click;
            
                    Masalar_Flow.Controls.Add(Masa_Ekle_Btn);
                   

                }
          

        }


        public Masalar_Form()
        {
            InitializeComponent();
            //masa_ekle(sayac);
            //sayac++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button masa = new Button();
            masa.Name = "masa " + Convert.ToString(sayac);
            masa.Text = "masa " + Convert.ToString(sayac);
            masa.Size = new Size(200, 200);
            masa.FlatStyle = FlatStyle.Flat;

            masa.TextAlign = ContentAlignment.BottomCenter;
            masa.BackgroundImageLayout = ImageLayout.Center;

            //masa.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.table_restaurant___Kopya1));
            masa.FlatAppearance.BorderSize = 0;

            Masalar_Flow.Controls.Add(masa);
            masa.Click += Masa_Click;

            Masalar_Flow.Controls.Add(Masa_Ekle_Btn);

        }

        private void Masa_Click(object sender, EventArgs e)
        {
           // Masa_Detay_Form masa_detay = new Masa_Detay_Form();
            
           // masa_detay.ShowDialog();

        }

        private void Masalar_Form_Load(object sender, EventArgs e)
        {
            //masa_ekle();
            
        }
    }
}
