using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Cafe_otomasyon_Projesi.classlar
{
    class Urunler_Sql_İslemleri
    {
        SqlConnection baglanti = new SqlConnection("Data Source = ADMINISTRATOR\\SQLEXPRESS; Initial Catalog = Cafe_Otomasyon_Db; Integrated Security = True");






        /// <summary>
        /// Ürün ekleme Methodu
        /// </summary>

        public void Urun_ekleme(string kategori, string ad, float fiyat, string fotograf)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand urun_ekle = new SqlCommand("Insert into Urunler (Urun_Adi,Urun_Fiyat,Urun_Fotografi,Urun_Kategori) values (@1,@2,@3,@4)", baglanti);
                    urun_ekle.Parameters.AddWithValue("@1", ad);
                    urun_ekle.Parameters.AddWithValue("@2", fiyat);
                    urun_ekle.Parameters.AddWithValue("@3", fotograf);
                    urun_ekle.Parameters.AddWithValue("@4", kategori);
                    urun_ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Ürün Başarıyla Kaydedildi");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");
                throw;
            }

        }




        /// <summary>
        /// Ürün Silen Method.
        /// </summary>
        public void Urun_Sil(int id)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand urunsil = new SqlCommand("DELETE from Urunler where Urun_id=@1 ", baglanti);
                    urunsil.Parameters.AddWithValue("@1", id);
                    urunsil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Ürün Başarıyla silindi.", "Uyarı");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");
                throw;
            }

        }


        /// <summary>
        ///Ürün Güncelleme methodu
        /// </summary>
        public void Urun_update(int id, string ad, float fiyat, string kategori,string fotograf)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand update = new SqlCommand("Update Urunler set Urun_adi=@1,Urun_Fiyat=@2,Urun_Fotografi=@3,Urun_Kategori=@4 where Urun_id=@5", baglanti);
                    update.Parameters.AddWithValue("@1", ad);
                    update.Parameters.AddWithValue("@2", fiyat);
                    update.Parameters.AddWithValue("@3", fotograf);
                    update.Parameters.AddWithValue("@4", kategori);
                    update.Parameters.AddWithValue("@5", id);
                    update.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Ürün Başarıyla güncellendi!", "Uyarı");
                    
                }
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }

        }
   
    
        
    
    }
}
