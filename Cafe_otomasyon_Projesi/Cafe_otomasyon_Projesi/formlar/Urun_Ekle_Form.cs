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
    public partial class Urun_Ekle_Form : Form
    {
        classlar.Urunler_Sql_İslemleri urun_Sql = new classlar.Urunler_Sql_İslemleri();
        protected int id;
        protected string ad, kategori,fotograf;
        protected float fiyat;
       

        
        public Urun_Ekle_Form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();
            
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                resim_path = fileDialog.FileName.ToString();
                File.Copy(resim_path, hedef_path + ad);
                hedef_path = hedef_path + ad;
                this.pictureBox1.ImageLocation = resim_path;

            }
        }

        private void Urun_Ekle_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Urunler_Form.urunler.Urun_cek();
            pictureBox1.ImageLocation = Application.StartupPath + @"\Food Images\default.png";
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void Duzenle_ok_Click(object sender, EventArgs e)
        {

            urun_Sql.Urun_update(id, textBox1.Text, float.Parse(textBox2.Text), comboBox1.Text, hedef_path);
        }

        private void Duzenle_No_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            urun_Sql.Urun_ekleme(comboBox1.Text,textBox1.Text,float.Parse(textBox2.Text),hedef_path);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Close();
        }

        private void Urun_Ekle_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
