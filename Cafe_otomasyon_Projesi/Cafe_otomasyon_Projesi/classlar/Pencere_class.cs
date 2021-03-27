using Cafe_otomasyon_Projesi.formlar;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_otomasyon_Projesi.classlar
{
    class Pencere_class
    {

        Masalar_Form masa_pencere = new Masalar_Form();
        Personel_Form personel_pencere = new Personel_Form();
        Urunler_Form urunler_pencere = new Urunler_Form();
        
        public void pencere_acma(Form1 form)
        {
            form.panel2.BackColor = Color.Red;
            //switch (acilacak_pencere)
            //{
            //    case "masa":
            //        panel2.Controls.Clear();
            //        masa_pencere.TopLevel = false;
            //        masa_pencere.Dock = DockStyle.Fill;
            //        panel2.Controls.Add(masa_pencere);
            //        masa_pencere.Show();
            //        break;

            //    case "personel":
            //        panel2.Controls.Clear();
            //        personel_pencere.TopLevel = false;
            //        personel_pencere.Dock = DockStyle.Fill;
            //        panel2.Controls.Add(personel_pencere);
            //        personel_pencere.Show();
            //        personel_pencere.yenile();
            //        break;
            //    case "urunler":
            //        panel2.Controls.Clear();
            //        urunler_pencere.TopLevel = false;
            //        urunler_pencere.Dock = DockStyle.Fill;
            //        panel2.Controls.Add(urunler_pencere);
            //        urunler_pencere.Show();
            //        break;

            //}
        }
    }
}
