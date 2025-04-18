using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Horian_Şifre_Yöneticisi
{
    public partial class hesap_frame_form : UserControl
    {
        public hesap_frame_form()
        {
            InitializeComponent();
        }

        private void hesap_frame_form_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            RemoveUserFromFile();
            this.Parent.Controls.Remove(this);
        }

        public hesap_frame_form(string programName, string email, string password, string phone, string adSoyad, string takmaAd, string diger)
        {
            InitializeComponent();
            txtProgramName.Text = programName;
            txtEmail.Text = email;
            txtPassword.Text = password;
            txtPhone.Text = phone;
            txtFullName.Text = adSoyad;
            txtNickname.Text = takmaAd;
            txtOther.Text = diger;
        }

        private readonly string userDataFilePath = "users.txt";

        private void RemoveUserFromFile()
        {
            List<string> lines = new List<string>();
            if (File.Exists(userDataFilePath))
            {
                lines = File.ReadAllLines(userDataFilePath).ToList();
            }

            string userData = $"{txtProgramName.Text};{txtEmail.Text};{txtPassword.Text};{txtPhone.Text};{txtFullName.Text};{txtNickname.Text};{txtOther.Text}";
            lines.Remove(userData);
            File.WriteAllLines(userDataFilePath, lines);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string userData = $"{txtProgramName.Text};{txtEmail.Text};{txtPassword.Text};{txtPhone.Text};{txtFullName.Text};{txtNickname.Text};{txtOther.Text}";
            güncelleme_form editUserForm = new güncelleme_form(userData, (hesap_listesi_form)this.ParentForm);
            editUserForm.ShowDialog();
        }

        private bool isPasswordVisible = false;

        private void txtPassword_IconRightClick(object sender, EventArgs e)
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(txtPassword.Text);
                e.SuppressKeyPress = true;
            }
        }
    }
}
