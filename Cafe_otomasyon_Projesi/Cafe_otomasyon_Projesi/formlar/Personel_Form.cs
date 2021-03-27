using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace Cafe_otomasyon_Projesi.formlar
{
    public partial class Personel_Form : Form
    {
        classlar.Sql_İslemleri persql = new classlar.Sql_İslemleri();
        public static Personel_Form per_form;

        public Personel_Form()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Personel_ekle per_ekle = new Personel_ekle();
            per_ekle.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Personel_Form_Load(object sender, EventArgs e)
        {
            per_form = this;
            per_cek();
            
        }

        //personellerin dinamik nesneleri.
        public void dinamik_personel(int id,string ad, string soyad, string telefon, string email, string gorev, string cinsiyet, string tarih,string fotograf)
        {
            
            Personel_Bilgi per_bilgi = new Personel_Bilgi();
            per_bilgi.per_bilgi(id,ad, soyad, telefon,email,gorev,cinsiyet,tarih,fotograf);
         
           
            this.flowLayoutPanel1.Controls.Add(per_bilgi);
            this.flowLayoutPanel1.Controls.Add(button1);
             
           

        }

        //personelleri veritabanından çekip dinamik nesneye aktarıyoruz.
        public void per_cek()
        {
            this.flowLayoutPanel1.Controls.Clear();
            SqlConnection baglanti;

            try
            {
                baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");

                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();


                    SqlCommand komut = new SqlCommand("SELECT * from Personel_Bilgi_Tbl", baglanti);
                    SqlDataReader read = komut.ExecuteReader();
                    while (read.Read())
                    {
                        int id = int.Parse(read["Per_İd"].ToString());
                        string ad = read["Per_Ad"].ToString();
                        string soyad = read["Per_Soyad"].ToString();
                        string gorev = read["Per_Gorev"].ToString();
                        string telefon = read["Per_Telefon"].ToString();
                        string email = read["Per_Email"].ToString();
                        string cinsiyet = read["Per_Cinsiyet"].ToString();
                        string isegiris = read["Per_isegiris"].ToString();
                        string fotograf = read["Per_Fotograf"].ToString();



                        dinamik_personel(id, ad, soyad, telefon, email, gorev, cinsiyet, isegiris, fotograf);





                    }


                    baglanti.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "uyarı", (MessageBoxButtons)MessageBoxIcon.Error);

            }

        }


       

        private void button2_Click(object sender, EventArgs e)
        {

            per_cek();
           
        }
    }
}
