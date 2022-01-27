using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString() + this.Handle;
            var form2 = new lucencyForm();
            form2.Show();
        }

        private void FormTransparent_Load(object sender, EventArgs e)
        {

            this.textBox1.Text = @"E:\ACC\ACC.Config\ACC.Config.exe";
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, uint lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;

        public const int SWP_NOOWNERZORDER = 0x200;
        public const int SWP_NOREDRAW = 0x8;
        public const int SWP_NOZORDER = 0x4;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int WS_EX_MDICHILD = 0x40;
        public const int SWP_FRAMECHANGED = 0x20;
        public const int SWP_NOACTIVATE = 0x10;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;
        public const int GWL_STYLE = (-16);
        public const int WS_VISIBLE = 0x10000000;
        public const int WM_CLOSE = 0x10;
        public const int WS_CHILD = 0x40000000;

        public const int SW_HIDE = 0; //{隐藏, 并且任务栏也没有最小化图标}
        public const int SW_SHOWNORMAL = 1; //{用最近的大小和位置显示, 激活}
        public const int SW_NORMAL = 1; //{同 SW_SHOWNORMAL}
        public const int SW_SHOWMINIMIZED = 2; //{最小化, 激活}
        public const int SW_SHOWMAXIMIZED = 3; //{最大化, 激活}
        public const int SW_MAXIMIZE = 3; //{同 SW_SHOWMAXIMIZED}
        public const int SW_SHOWNOACTIVATE = 4; //{用最近的大小和位置显示, 不激活}
        public const int SW_SHOW = 5; //{同 SW_SHOWNORMAL}
        public const int SW_MINIMIZE = 6; //{最小化, 不激活}
        public const int SW_SHOWMINNOACTIVE = 7; //{同 SW_MINIMIZE}
        public const int SW_SHOWNA = 8; //{同 SW_SHOWNOACTIVATE}
        public const int SW_RESTORE = 9; //{同 SW_SHOWNORMAL}
        public const int SW_SHOWDEFAULT = 10; //{同 SW_SHOWNORMAL}
        public const int SW_MAX = 10; //{同 SW_SHOWNORMAL}

        Process myProcess = new Process();

        IntPtr OtherExeWnd = new IntPtr(0);

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = this.textBox1.Text;

            //判断是否运行
            if (OtherExeWnd== IntPtr.Zero || myProcess.HasExited)
            {

                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = path;
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                var b = myProcess.Start();

                while (myProcess.MainWindowHandle == IntPtr.Zero)
                { 
                    
                }

                OtherExeWnd = myProcess.MainWindowHandle;
            }
 
            //OtherExeWnd = FindWindow("SunAwtFrame", null);
            //判断这个窗体是否有效
            if (OtherExeWnd != IntPtr.Zero)
            {

                  //SendMessage(OtherExeWnd, 16, 0, 0);//关闭窗口，通过发送消息的方式 
                //new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
             //  var b = SetWindowPos(OtherExeWnd, (IntPtr)(0),0,0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,   SWP_SHOWWINDOW); //截取，并非缩放
                int x = ShowWindow(OtherExeWnd, 3);//0表示隐藏窗口

                this.WindowState= FormWindowState.Minimized ;
            }
            else
            {
                MessageBox.Show("can't find it");
                //Console.WriteLine("没有找到窗口");
            }

        }
         
        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        { 
            //OtherExeWnd = myProcess.MainWindowHandle;

            //判断这个窗体是否有效
            if (OtherExeWnd != IntPtr.Zero)
            { 
              int y=  ShowWindow(OtherExeWnd, 0); 
            }
            else
            {
                MessageBox.Show("can't find it");
                //Console.WriteLine("没有找到窗口");
            }
        }
    }
}
