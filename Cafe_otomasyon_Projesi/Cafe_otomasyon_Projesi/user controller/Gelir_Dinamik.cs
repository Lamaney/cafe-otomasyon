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
    public partial class Gelir_Dinamik : UserControl
    {
        public Gelir_Dinamik()
        {
            InitializeComponent();
        }

        private void Gelir_Dinamik_Load(object sender, EventArgs e)
        {

        }

        public void dinamik(string aciklama, float tutar)
        {
            doldur(aciklama,tutar);
            formlar.Muhasebe_Form.muhasebe_Form.Gelir_flow.Controls.Add(this);


        }

        void doldur(string aciklama,float tutar)
        {
            label2.Text = aciklama;
            label3.Text = tutar.ToString()+" TL";
           
        }
    }
}
