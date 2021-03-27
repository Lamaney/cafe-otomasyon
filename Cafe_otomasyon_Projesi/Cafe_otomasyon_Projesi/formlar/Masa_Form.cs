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
    public partial class Masa_Form : Form
    {

        public static Masa_Form masalar;
        classlar.Sql_İslemleri sql_sorgu = new classlar.Sql_İslemleri();
        
        
        
        
        public Masa_Form()
        {
            InitializeComponent();
        }

        private void Masa_Form_Load(object sender, EventArgs e)
        {
            masalar = this;
            
            sql_sorgu.Masa_bilgi();
            
        }

        
        

        private void Masa_Click(object sender, EventArgs e)
        {
             formlar.Masa_Detay_Form masa_Detay = new Masa_Detay_Form();
            masa_Detay.Show();

           
           
           
        }

        private void Masa_Ekle_Button_Click(object sender, EventArgs e)
        {
           
            sql_sorgu.Masa_ekle();
            
        }
    }
}
