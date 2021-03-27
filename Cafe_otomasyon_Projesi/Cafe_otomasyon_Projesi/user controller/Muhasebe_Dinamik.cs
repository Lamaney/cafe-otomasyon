using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_otomasyon_Projesi.user_controller
{
    public partial class Muhasebe_Dinamik : UserControl
    {
        public Muhasebe_Dinamik()
        {
            InitializeComponent();
        }
        protected int masa_no;
        protected float masa_hesap;
        protected string tarih;
        private void Muhasebe_Dinamik_Load(object sender, EventArgs e)
        {

        }

        public void dinamik (int no, float hesap, string h_tarih)
        {
            doldur(no,hesap,h_tarih);
            formlar.Muhasebe_Form.muhasebe_Form.Masa_hesap_flow.Controls.Add(this);


        }
    
        
        void doldur(int no, float hesap, string h_tarih) {
            label1.Text = "Masa "+no.ToString();
            label2.Text = "HESAP ÖDEMESİ";
            label3.Text = hesap.ToString() + " TL";
            label4.Text = h_tarih;
        }
    }
}
