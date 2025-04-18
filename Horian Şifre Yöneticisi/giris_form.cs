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
    public partial class giris_form : Form
    {
        public giris_form()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void giris_form_Load(object sender, EventArgs e)
        {
            hata_label.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        bool Mov;
        int MovX, MovY;

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = false;
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mov)
            {
                this.SetDesktopLocation(MousePosition.X - MovX, MousePosition.Y - MovY);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool isPasswordVisible = false;

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                sifre_tb.UseSystemPasswordChar = false;
                sifre_tb.PasswordChar = '\0';
                sifre_tb.IconRight = Properties.Resources.eye;
            }
            else
            {
                sifre_tb.UseSystemPasswordChar = true;
                sifre_tb.PasswordChar = '●';
                sifre_tb.IconRight = Properties.Resources.hidden;
            }
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            string dogruKullaniciAdi = "admin"; // Giriş için kullanıcı adı kısmı burdan değiştirilir!
            string dogruSifre = "admin123"; // Giriş için şifre kısmı burdan değiştirilir!
            string kullaniciAdi = kullanici_adi_tb.Text;
            string sifre = sifre_tb.Text;

            hata_label.Visible = false;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                hata_label.Text = "Kullanıcı adı ve şifre boş bırakılamaz!";
                hata_label.ForeColor = Color.Red;
                hata_label.Visible = true;
                return;
            }

            if (kullaniciAdi == dogruKullaniciAdi && sifre == dogruSifre)
            {
                anasayfa_form anasayfa = new anasayfa_form();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                hata_label.Text = "Kullanıcı adı veya şifre yanlış!";
                hata_label.ForeColor = Color.Red;
                hata_label.Visible = true;
            }
        }

        private void giris_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string dogruKullaniciAdi = "admin"; // Giriş için kullanıcı adı kısmı burdan değiştirilir!
                string dogruSifre = "admin123"; // Giriş için şifre kısmı burdan değiştirilir!
                string kullaniciAdi = kullanici_adi_tb.Text;
                string sifre = sifre_tb.Text;

                hata_label.Visible = false;

                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
                {
                    hata_label.Text = "Kullanıcı adı ve şifre boş bırakılamaz!";
                    hata_label.ForeColor = Color.Red;
                    hata_label.Visible = true;

                    e.SuppressKeyPress = true;
                    return;
                }

                if (kullaniciAdi == dogruKullaniciAdi && sifre == dogruSifre)
                {
                    anasayfa_form anasayfa = new anasayfa_form();
                    anasayfa.Show();
                    this.Hide();

                    e.SuppressKeyPress = true;
                }
                else
                {
                    hata_label.Text = "Kullanıcı adı veya şifre yanlış!";
                    hata_label.ForeColor = Color.Red;
                    hata_label.Visible = true;

                    e.SuppressKeyPress = true;
                }
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mov = true;
            MovX = e.X;
            MovY = e.Y;
        }
    }
}
