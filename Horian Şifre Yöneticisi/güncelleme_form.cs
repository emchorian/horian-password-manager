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
    public partial class güncelleme_form : Form
    {
        public güncelleme_form()
        {
            InitializeComponent();
        }

        public güncelleme_form(string userData)
        {
            InitializeComponent();
            originalUserData = userData;
            LoadUserData(userData);
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            string updatedUserData = $"{txtProgramName.Text};{txtEmail.Text};{txtPassword.Text};{txtPhone.Text};{txtFullName.Text};{txtNickname.Text};{txtOther.Text}";

            bool isUpdated = UpdateUserInFile(originalUserData, updatedUserData);

            mainForm.ReloadUsers();

            this.Close();
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = false;
        }

        public güncelleme_form(string userData, hesap_listesi_form form)
        {
            InitializeComponent();
            originalUserData = userData;
            mainForm = form;
            LoadUserData(userData);
        }

        private hesap_listesi_form mainForm;

        private bool UpdateUserInFile(string originalUserData, string updatedUserData)
        {
            try
            {
                string[] lines = File.ReadAllLines("users.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == originalUserData)
                    {
                        lines[i] = updatedUserData;
                        File.WriteAllLines("users.txt", lines);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

            return false;
        }

        private void LoadUserData(string userData)
        {
            string[] data = userData.Split(';');
            txtProgramName.Text = data[0];
            txtEmail.Text = data[1];
            txtPassword.Text = data[2];
            txtPhone.Text = data[3];
            txtFullName.Text = data[4];
            txtNickname.Text = data[5];
            txtOther.Text = data[6];
        }

        private string userDataFilePath = "users.txt";

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

        private void güncelleme_form_Load(object sender, EventArgs e)
        {

        }

        private void güncelleme_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string updatedUserData = $"{txtProgramName.Text};{txtEmail.Text};{txtPassword.Text};{txtPhone.Text};{txtFullName.Text};{txtNickname.Text};{txtOther.Text}";

                bool isUpdated = UpdateUserInFile(originalUserData, updatedUserData);

                if (isUpdated)
                {
                    mainForm.ReloadUsers();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı verileri güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                e.SuppressKeyPress = true;
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private string originalUserData;
    }
}
