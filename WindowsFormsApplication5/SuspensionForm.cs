using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class SuspensionForm : Form
    {
        public SuspensionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var formMain =(FormMain) this.Owner;

            formMain.Show(); 
            formMain.BringToFront();
            formMain.Activate();
            formMain.TopMost = true;
            formMain.WindowState = FormWindowState.Maximized;
        }

        private void SuspensionForm_Load(object sender, EventArgs e)
        { 
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
            this.Size = new Size(this.button1.Width, this.button1.Height);
            this.TopMost = true;
        }
    }
}
