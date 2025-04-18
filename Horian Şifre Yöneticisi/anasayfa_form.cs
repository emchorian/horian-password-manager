using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horian_Şifre_Yöneticisi
{
    public partial class anasayfa_form : Form
    {
        public anasayfa_form()
        {
            InitializeComponent();
        }

        private void anasayfa_form_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool Mov;
        int MovX, MovY;

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mov = true;
            MovX = e.X;
            MovY = e.Y;
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mov)
            {
                this.SetDesktopLocation(MousePosition.X - MovX, MousePosition.Y - MovY);
            }
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            hesap_kaydetme_form hesap_Kaydetme_Form = new hesap_kaydetme_form();
            hesap_Kaydetme_Form.Show();
            this.Hide();
        }

        private void listele_btn_Click(object sender, EventArgs e)
        {
            hesap_listesi_form hesap_Listesi_Form = new hesap_listesi_form();
            hesap_Listesi_Form.Show();
            this.Hide();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = false;
        }
    }
}
