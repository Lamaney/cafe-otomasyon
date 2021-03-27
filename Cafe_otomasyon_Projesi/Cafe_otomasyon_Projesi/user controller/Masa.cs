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
    public partial class Masa : UserControl
    {
        protected int mas_id;
        protected bool mas_durum;
        formlar.Masa_Detay_Form masa_detay = new formlar.Masa_Detay_Form();
        public static user_controller.Masa masa_user;

        public void a(int id,bool durum)
        {
            mas_id = id;
            label1.Text = "Masa "+id.ToString();

            if (durum==true)
            {
                this.BackColor = Color.FromArgb(150, 114, 89);
            }
        }

       


        public Masa()
        {
            InitializeComponent();
            masa_user = this;

           
        }

        private void Masa_Load(object sender, EventArgs e)
        {
            masa_detay.obje_al(this);
        }

        private void Masa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            masa_detay.a(mas_id, mas_durum);
            masa_detay.ShowDialog();
        }
    }
}
