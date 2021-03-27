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
    public partial class Gelir_Gider_Form : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");


        public Gelir_Gider_Form()
        {
            InitializeComponent();
        }

        public void gelir_gider_goster(string durum)
        {
            switch (durum)
            {
                case "gelir":
                    label1.Text = "GELİR GİR";
                    Gelir_btn.Visible = true;
                   kaydet_btn.Visible = false;
                    break;

                case "gider":
                    label1.Text = "GİDER GİR";
                    Gelir_btn.Visible = false;
                    kaydet_btn.Visible = true;
                    break;
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Gelir_Gider_Form_Load(object sender, EventArgs e)
        {

        }
    
    
        public void gelir_gider(string durum)
        {



        }
    
        public void sql_islem_gider(string aciklama,float tutar)
        {
            baglanti.Open();
            SqlCommand gider = new SqlCommand("INSERT into Gider(Gider_Aciklama,Gider) values (@1,@2)", baglanti);
            gider.Parameters.AddWithValue("@1",aciklama);
            gider.Parameters.AddWithValue("@2", tutar);
            gider.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Gider Eklendi", "Uyarı");
            cleaner();
            this.Close();

        }

        public void sql_islem_gelir(string aciklama, float tutar)
        {
            baglanti.Open();
            SqlCommand gelir = new SqlCommand("INSERT into Gelir_table(Gelir_Aciklama,Gelir) values (@1,@2)", baglanti);
            gelir.Parameters.AddWithValue("@1", aciklama);
            gelir.Parameters.AddWithValue("@2", tutar);
            gelir.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Gelir Eklendi", "Uyarı");
            cleaner();
            this.Close();

        }

        void cleaner()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Gelir_Gider_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            formlar.Muhasebe_Form.muhasebe_Form.gider_reader();
            formlar.Muhasebe_Form.muhasebe_Form.label7.Text = formlar.Muhasebe_Form.muhasebe_Form.f_gider.ToString();
            formlar.Muhasebe_Form.muhasebe_Form.gelir_reader();
            formlar.Muhasebe_Form.muhasebe_Form.Reader();
            formlar.Muhasebe_Form.muhasebe_Form.label6.Text = formlar.Muhasebe_Form.muhasebe_Form.f_gelir.ToString();
            
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            sql_islem_gider(textBox1.Text, float.Parse(textBox2.Text));
        }

        private void Gelir_btn_Click(object sender, EventArgs e)
        {
            sql_islem_gelir(textBox1.Text, float.Parse(textBox2.Text));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            this.Close();
        }
    }
}
