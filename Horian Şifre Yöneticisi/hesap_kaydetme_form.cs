using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horian_Şifre_Yöneticisi
{
    public partial class hesap_kaydetme_form : Form
    {
        public hesap_kaydetme_form()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void hesap_kaydetme_form_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            anasayfa_form anasayfa = new anasayfa_form();
            anasayfa.Show();
            this.Hide();
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

        private void ClearTextBoxes()
        {
            txtProgramName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtFullName.Clear();
            txtNickname.Clear();
            txtOther.Clear();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            string programName = txtProgramName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;
            string fullName = txtFullName.Text;
            string nickname = txtNickname.Text;
            string other = txtOther.Text;

            string userData = $"{programName};{email};{password};{phone};{fullName};{nickname};{other}";

            string filePath = "users.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(userData);
            }

            MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearTextBoxes();
        }

        private void hesap_kaydetme_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string programName = txtProgramName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string phone = txtPhone.Text;
                string fullName = txtFullName.Text;
                string nickname = txtNickname.Text;
                string other = txtOther.Text;

                string userData = $"{programName};{email};{password};{phone};{fullName};{nickname};{other}";

                string filePath = "users.txt";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(userData);
                }

                MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearTextBoxes();

                e.SuppressKeyPress = true;
            }
        }

        private bool isPasswordVisible = false;

        private void sifre_tb_IconRightClick(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
                txtPassword.IconRight = Properties.Resources.eye;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '●';
                txtPassword.IconRight = Properties.Resources.hidden;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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
