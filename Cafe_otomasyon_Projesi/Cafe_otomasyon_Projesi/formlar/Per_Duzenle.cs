using System;

using System.Windows.Forms;
using System.IO;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Per_Duzenle : Form
    {
        int per_id;
        classlar.Sql_İslemleri sql_islem = new classlar.Sql_İslemleri();
       

        public Per_Duzenle()
        {
            InitializeComponent();
        }

        private void Per_Duzenle_Load(object sender, EventArgs e)
        {

        }
        
        public void detay_getir(int id,string ad,string soyad,string telefon,string email,string gorev,string cinsiyet,string tarih,string foto_path)
        {
            per_id = id;
            ad_lbl.Text = ad;
            soyad_lbl.Text = soyad;
            numara_lbl.Text = telefon;
            email_lbl.Text = email;
            gorev_lbl.Text = gorev;
            cinsiyet_lbl.Text = cinsiyet;
            tarih_lbl.Text = tarih;
            if (foto_path!=null)
            {
                
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = foto_path;
            }
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql_islem.Personel_Sil(per_id);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Duzenle_btn_Click(object sender, EventArgs e)
        {
            duzenle_gizle_goster("goster");
            label_gizle_goster("gizle");
           
        }
    
        void personel_update()
        {
            
            string per_cinsiyet = null;
            if (erkek_rb.Checked)
                per_cinsiyet = "erkek";

            if (kadin_rb.Checked)
                per_cinsiyet = "kadın";

            sql_islem.Personel_Update(per_id, ad_txt.Text, soyad_txt.Text, telefon_txt.Text, email_txt.Text, gorev_cmb.Text,per_cinsiyet,dateTimePicker1.Text, hedef_path);
            this.Close();

        }
    
        void duzenle_gizle_goster(string durum)
        {
            switch (durum)
            {
                case "goster":
                    ad_txt.Visible = true;
                    soyad_txt.Visible = true;
                    telefon_txt.Visible = true;
                    email_txt.Visible = true;
                    gorev_cmb.Visible = true;
                    erkek_rb.Visible = true;
                    kadin_rb.Visible = true;
                    dateTimePicker1.Visible = true;
                    Kaydet_Btn.Visible = true;
                    Vazgec_btn.Visible = true;
                    Fotograf_Duzenle_Btn.Visible = true;
                    //--------------------------------------------------
                    ad_txt.Text = ad_lbl.Text;
                    soyad_txt.Text = soyad_lbl.Text;
                    telefon_txt.Text = numara_lbl.Text;
                    email_txt.Text = email_lbl.Text;
                    gorev_cmb.Text = gorev_lbl.Text;
                    switch (cinsiyet_lbl.Text)
                    {
                        case "erkek":
                            erkek_rb.Checked=true;
                            break;
                        case "kadın":
                            kadin_rb.Checked = true;
                            break;
                    }
                    break;
                case "gizle":
                    ad_txt.Visible = false;
                    soyad_txt.Visible = false;
                    telefon_txt.Visible = false;
                    email_txt.Visible = false;
                    gorev_cmb.Visible = false;
                    erkek_rb.Visible = false;
                    kadin_rb.Visible = false;
                    dateTimePicker1.Visible = false;
                    Kaydet_Btn.Visible = false;
                    Vazgec_btn.Visible = false;
                    Fotograf_Duzenle_Btn.Visible = false;
                    //----------------------------------------------------
                    ad_txt.Clear();
                    soyad_txt.Clear();
                    telefon_txt.Clear();
                    email_txt.Clear();
                    break;
                
            }


        }


        void label_gizle_goster(string durum)
        {
            switch (durum)
            {
                case "goster":
                    ad_lbl.Visible = true;
                    soyad_lbl.Visible = true;
                    numara_lbl.Visible = true;
                    email_lbl.Visible = true;
                    gorev_lbl.Visible = true;
                    cinsiyet_lbl.Visible = true;
                    tarih_lbl.Visible = true;
                   //-----------------------------------------
                   
                    break;

                case "gizle":
                    ad_lbl.Visible = false;
                    soyad_lbl.Visible = false;
                    numara_lbl.Visible = false;
                    email_lbl.Visible = false;
                    gorev_lbl.Visible = false;
                    cinsiyet_lbl.Visible = false;
                    tarih_lbl.Visible = false;
                    break;
            }
        }

        private void Vazgec_btn_Click(object sender, EventArgs e)
        {
            duzenle_gizle_goster("gizle");
            label_gizle_goster("goster");
        }

        private void Kaydet_Btn_Click(object sender, EventArgs e)
        {
            personel_update();
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        string hedef_path,resim_path;

        private void Per_Duzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Personel_Form.per_form.per_cek();
        }

        private void Fotograf_Duzenle_Btn_Click(object sender, EventArgs e)
        {
            string ad = Guid.NewGuid() + ".jpg";
            hedef_path = Application.StartupPath + @"\Images\";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Fotoğraf Seç";
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                resim_path = fileDialog.FileName.ToString();
                File.Copy(resim_path, hedef_path + ad);
                hedef_path = hedef_path + ad;
                this.pictureBox1.ImageLocation = resim_path;

            }
        }
    }
}
