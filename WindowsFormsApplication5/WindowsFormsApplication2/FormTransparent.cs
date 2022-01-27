using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class FormTransparent : Form
    { 
        private Color tr_color = Color.Transparent;
        private bool b_start = false;
        bool[] b_visible = null;
        public FormTransparent()
        {
            InitializeComponent();
        } 

        private void FormTransparent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width,Screen.PrimaryScreen.WorkingArea.Bottom-this.Height);
            SetBackgroundImageTransparent();
        }
        private void SetBackgroundImageTransparent()
        {
            Point pt = this.PointToScreen(new Point(0, 0));
            Bitmap b = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(pt, new Point(), new Size(this.Width, this.Height));
            }

            this.BackgroundImage = b;
        }
        private void BeginSet()
        {
            tr_color = this.TransparencyKey;
            b_start = true;
        }
        private void Setting()
        {
            if (b_start)
            {
                b_visible = new bool[Controls.Count];
                for (int i = 0; i < Controls.Count; i++)
                {
                    b_visible[i] = Controls[i].Visible;
                    Controls[i].Visible = false;
                }
                BackgroundImage = null;
                BackColor = Color.White;
                b_start = false;
                this.TransparencyKey = Color.White;
            }
        }
        private void EndSet()
        {
            SetBackgroundImageTransparent();
            this.TransparencyKey = tr_color;
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = b_visible[i];
            }
            b_start = false;
        }

        private void FormTransparent_Resize(object sender, EventArgs e)
        {
            Setting();
        }
        private void FormTransparent_ResizeBegin(object sender, EventArgs e)
        {
            BeginSet();
        }
        private void FormTransparent_ResizeEnd(object sender, EventArgs e)
        {
            EndSet();
        }
        private void FormTransparent_Move(object sender, EventArgs e)
        {
            Setting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.BackColor= System.Drawing.Color.FromArgb(10, Color.LightGray);
            this.label1.Text = "ok!"+DateTime.Now.ToString();
        }
    }
}