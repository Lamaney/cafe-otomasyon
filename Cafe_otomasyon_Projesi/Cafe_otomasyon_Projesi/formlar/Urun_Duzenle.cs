using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Urun_Duzenle : Form
    {
        public Urun_Duzenle()
        {
            InitializeComponent();
        }
        classlar.Urunler_Sql_İslemleri update = new classlar.Urunler_Sql_İslemleri();
        protected int urun_id;

        private void Urun_Detay_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void urun_update(int id, string ad, float Fiyat, string Kategori, string fotograf)
        {
            textBox1.Text = ad;
            textBox2.Text = Fiyat.ToString();
            comboBox1.Text = Kategori;
            this.pictureBox1.ImageLocation = fotograf;
            urun_id = id;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            update.Urun_update(urun_id, textBox1.Text, float.Parse(textBox2.Text), comboBox1.Text, hedef_path);
            Urunler_Form.urunler.Urun_cek();
            this.Close();
        }
        string hedef_path;
        string resim_path;
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = Guid.NewGuid() + ".jpg";
            hedef_path = Application.StartupPath + @"\Food Images\";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Fotoğraf Seç";
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                resim_path = fileDialog.FileName.ToString();
                File.Copy(resim_path, hedef_path + ad);
                hedef_path = hedef_path + ad;
                this.pictureBox1.ImageLocation = resim_path;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update.Urun_Sil(urun_id);
            this.Close();
            Urunler_Form.urunler.Urun_cek();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();
            this.Close();
        }
    }
}
