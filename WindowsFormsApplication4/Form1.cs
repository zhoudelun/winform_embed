using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormTransparent_ShowMenu);
        }
        void FormTransparent_ShowMenu(object sender, KeyEventArgs  e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("hh");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取查找窗体句柄(通过窗体标题名)
            string className = "FormTest";
            string name = "Form123";// "ACC.Platform";
            IntPtr mainHandle = FindWindow(null, name);
            


            MyProcess myProcess = new MyProcess();      var allProcess = System.Diagnostics.Process.GetProcesses();
            var apps = allProcess.Where(w => w.ProcessName== "ACC.Server" ).OrderBy(o => o.StartTime);
            foreach (var item in apps)
            {
                string x = item.ProcessName;

                string path = item.MainModule.FileName;
                if (path == @"D:\ACC\ACC.Server\ACC.Server.exe")
                {
                    int id = item.Id;
                    if (id > 0)
                    {
                        mainHandle = myProcess.GetMainWindowHandle(id);
                        if(mainHandle!= IntPtr.Zero)
                            break; 
                    }
                }
            } 
            this.label1.Text = "FindWindow(null,\"Form123\")      " + mainHandle.ToString();
        }


        /// <summary>
        /// 获取窗体的句柄函数
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回句柄</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 通过句柄，窗体显示函数
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="cmdShow">显示方式</param>
        /// <returns>返工成功与否</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync", SetLastError = true)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        private void FormTest_Load(object sender, EventArgs e)
        {

            button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        }

    } 

}
