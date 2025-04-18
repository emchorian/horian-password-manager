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
    public partial class hesap_listesi_form : Form
    {
        public hesap_listesi_form()
        {
            InitializeComponent();
        }

        private void hesap_listesi_form_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            string filePath = "users.txt";

            if (File.Exists(filePath))
            {
                flowLayoutPanel.Controls.Clear();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] userData = line.Split(';');

                    if (userData.Length == 7)
                    {
                        hesap_frame_form userControl = new hesap_frame_form(
                            userData[0],
                            userData[1],
                            userData[2],
                            userData[3],
                            userData[4],
                            userData[5],
                            userData[6]
                        );

                        flowLayoutPanel.Controls.Add(userControl);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı verileri dosyası bulunamadı.");
            }
        }

        public void ReloadUsers()
        {
            LoadUsers();
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

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = search_tb.Text.ToLower();
            string filePath = "users.txt";

            if (File.Exists(filePath))
            {
                flowLayoutPanel.Controls.Clear();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] userData = line.Split(';');

                    if (userData.Length == 7)
                    {
                        string programName = userData[0].ToLower();

                        if (programName.StartsWith(searchTerm))
                        {
                            hesap_frame_form userControl = new hesap_frame_form(
                                userData[0],
                                userData[1],
                                userData[2],
                                userData[3],
                                userData[4],
                                userData[5],
                                userData[6]
                            );

                            flowLayoutPanel.Controls.Add(userControl);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı verileri dosyası bulunamadı.");
            }
        }

        private void search_tb_IconRightClick(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = false;
        }
    }
}
