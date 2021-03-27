using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Cafe_otomasyon_Projesi.classlar
{
    class Sql_İslemleri
    {
      SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");
        

        /// <summary>
        /// personel güncelleme.
        /// </summary>
        
        public void Personel_Update(int per_id, string per_ad,string per_soyad,string per_telefon,string per_mail,string per_gorev,string per_cinsiyet,string per_tarih,string per_fotograf)
        {
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("Update Personel_Bilgi_Tbl set Per_ad=@ad,Per_Soyad=@soyad,Per_Telefon=@tel,Per_Email=@email,Per_Gorev=@gorev,Per_Cinsiyet=@cinsiyet,Per_İsegiris=@tarih,Per_Fotograf=@fotograf where Per_id=@id", baglanti);
                   
                    guncelle.Parameters.AddWithValue("@ad", per_ad);
                    guncelle.Parameters.AddWithValue("@soyad", per_soyad);
                    guncelle.Parameters.AddWithValue("@tel", per_telefon);
                    guncelle.Parameters.AddWithValue("@email", per_mail);
                    guncelle.Parameters.AddWithValue("@gorev", per_gorev);
                    guncelle.Parameters.AddWithValue("@cinsiyet", per_cinsiyet);
                    guncelle.Parameters.AddWithValue("@tarih", per_tarih);
                    guncelle.Parameters.AddWithValue("@fotograf", per_fotograf);
                    guncelle.Parameters.AddWithValue("@id", per_id);
                    guncelle.ExecuteNonQuery();
                    
                    baglanti.Close();
                    MessageBox.Show("Değişiklikler Başarıyla Kaydedildi", "Uyarı");
                    
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message,"Hata!");
                
                
            }
                


        }
       
        
        
        /// <summary>
        /// personel silme.
        /// </summary>
       

        public void Personel_Sil(int personel_id)
        {
           DialogResult silme_onay=MessageBox.Show("Bu personeli silmek istediğinize emin misiniz ?","Uyarı",MessageBoxButtons.YesNo);

            if (silme_onay==DialogResult.Yes)
            {
                
                
                    try
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                            SqlCommand per_sil = new SqlCommand("DELETE from Personel_Bilgi_Tbl where Per_İd=@1", baglanti);
                            per_sil.Parameters.AddWithValue("@1", personel_id);
                            per_sil.ExecuteNonQuery();
                            baglanti.Close();

                            MessageBox.Show("Personel Başarıyla Silinmiştir", "Uyarı!");
                        }                    
                        }
                    catch (Exception Hata)
                    {
                        MessageBox.Show(Hata.Message, "Hata");
                        throw;
                    }
                
            }
            
        }
    
        /// <summary>
        /// Personel kaydetme.
        /// </summary>
        
        public void Personel_Kaydet(string per_ad,string per_soyad, string per_telefon,string per_email,string per_gorev,string per_cinsiyet,string per_tarih,string per_fotoğraf_path)
        {
                      
                try
                {
                    if (baglanti.State == ConnectionState.Closed) { 

                        baglanti.Open();
                    SqlCommand komut = new SqlCommand("INSERT into Personel_Bilgi_Tbl(Per_Ad,Per_Soyad,Per_Telefon,Per_Email,Per_Gorev,Per_Cinsiyet,Per_İsegiris,Per_Fotograf)values(@per_ad,@per_soyad,@per_tel,@per_mail,@per_gorev,@per_cinsiyet,@per_tarih,@per_fotograf)", baglanti);
                    
                    komut.Parameters.AddWithValue("@per_ad", per_ad);
                    komut.Parameters.AddWithValue("@per_soyad", per_soyad);
                    komut.Parameters.AddWithValue("@per_tel", per_telefon);
                    komut.Parameters.AddWithValue("@per_mail", per_email);
                    komut.Parameters.AddWithValue("@per_gorev", per_gorev);
                    komut.Parameters.AddWithValue("@per_cinsiyet", per_cinsiyet);
                    komut.Parameters.AddWithValue("@per_tarih", per_tarih);
                    komut.Parameters.Add("@per_fotograf", per_fotoğraf_path);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Personel başarıyla kaydedildi!", "Uyarı!");
                     }
                }
                catch (Exception)
                {

                    throw;
                }
            

        }


     

        
        /// <summary>
        /// masa Ekleme
        /// </summary>
        
        public void Masa_ekle()
        {
            //Masa_bilgi();



            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    bool durum = false;
                    baglanti.Open();
                    SqlCommand masa_ekle = new SqlCommand("INSERT into Masa_Table (Masa_No,Masa_Durumu) values (@1,@2) ", baglanti);
                    masa_ekle.Parameters.AddWithValue("@1", masa_id + 1);
                    masa_ekle.Parameters.AddWithValue("@2", durum);
                    masa_ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show((masa_id+1)+". masa eklendi!", "Uyarı");
                    Masa_bilgi();


                }


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");
                throw;
            }
        }


        /// <summary>
        /// Db'den Masaları ve durumlarını çeken method.
        /// </summary>
        int masa_id;
        public void Masa_bilgi()
        {
            formlar.Masa_Form.masalar.Masalar_Flow.Controls.Clear();
           bool masa_durum;
           
            
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand oku = new SqlCommand("Select * from Masa_Table ORDER by Masa_No ASC", baglanti);
                    SqlDataReader reader = oku.ExecuteReader();
                    while (reader.Read())
                    {
                        masa_id = int.Parse(reader["Masa_No"].ToString());
                        masa_durum = (bool)reader["Masa_Durumu"];






                        // formlar.Masa_Form.masalar.masa_ekle(masa_id, masa_durum);
                        user_controller.Masa mas = new user_controller.Masa();
                        mas.a(masa_id,masa_durum);
                        formlar.Masa_Form.masalar.Masalar_Flow.Controls.Add(mas);
                        formlar.Masa_Form.masalar.Masalar_Flow.Controls.Add(formlar.Masa_Form.masalar.Masa_Ekle_Button);
                    }
                    
                    baglanti.Close();
                    
                    

                    
                }
               
            }
            catch (Exception hata) 
            {
                MessageBox.Show(hata.Message);

               
            }
        }


        public void hesap_odendi(float ödeme)
        {


        }

    }
}
