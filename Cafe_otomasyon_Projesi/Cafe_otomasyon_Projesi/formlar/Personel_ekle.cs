using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;

namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Personel_ekle : Form
    {
     
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");
        classlar.Sql_İslemleri sql_kayit = new classlar.Sql_İslemleri();
        


        void db_personel_kaydet()
        {
            
            try
            {
                    string per_cinsiyet=null;
                    if (Erkek_RadioBtn.Checked)
                        per_cinsiyet = "erkek";

                    if (Kadın_RadioBtn.Checked)
                        per_cinsiyet = "kadın";
            
                sql_kayit.Personel_Kaydet(per_ad_txt.Text, per_soyad_txt.Text, per_telefon_txt.Text, per_email_txt.Text, per_gorev_cmb.Text, per_cinsiyet, dateTimePicker1.Text, hedef_path);
                    this.Close();
                    
                    

               
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");

            }


        }
        formlar.Personel_Form per_form = new Personel_Form();

        public Personel_ekle()
        {
            InitializeComponent();
        }

        string resim_path;
        string hedef_path;
        protected void Fotoğraf_Ekle_Btn_Click(object sender, EventArgs e)
        {
           

            string ad =Guid.NewGuid()+".jpg";
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

      
      

        private void button2_Click(object sender, EventArgs e)
        {
            per_ad_txt.Clear();
            per_soyad_txt.Clear();
            per_telefon_txt.Clear();
            per_email_txt.Clear();



            this.Close();
           
            
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.pencere_acma("personel");
            db_personel_kaydet();
           
           
            

        }

        private void Personel_ekle_Load(object sender, EventArgs e)
        {

        }
       
        private void Personel_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {

            Personel_Form.per_form.per_cek();
            
            
        }
    }
}
