using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Horian_Şifre_Yöneticisi
{
    public partial class yuklenme_form : Form
    {
        public yuklenme_form()
        {
            InitializeComponent();
        }

        private void yuklenme_form_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            int cornerRadius = 7;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(guna2Panel2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(guna2Panel2.Width - cornerRadius, guna2Panel2.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, guna2Panel2.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            guna2Panel2.Region = new Region(path);
        }

        private Timer timer;
        private int dotCount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2Panel2.Width += 3;
            if (guna2Panel2.Width >= 609)
            {
                timer1.Stop();
                giris_form giris_form = new giris_form();
                giris_form.Show();
                this.Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string dots = new string('.', dotCount);
            label1.Text = "Şifreler Yükleniyor" + dots;
            dotCount++;
            if (dotCount > 3)
            {
                dotCount = 0;
            }
        }

        private void yuklenme_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer2.Stop();
            timer2.Dispose();
            timer1.Stop();
            timer1.Dispose();
        }
    }
}
