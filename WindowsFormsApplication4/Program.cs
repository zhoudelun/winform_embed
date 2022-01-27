using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest());

            //this.applicationControl1 = new AppControl.ApplicationControl();
            //this.SuspendLayout();
            //// 
            //// applicationControl1
            //// 
            //this.applicationControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            //this.applicationControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //// 在这里设置要嵌入的程序路径，我试验了灵格斯翻译专家成功，QQ没试，据说不成功，我不清楚呵呵。）
            //this.applicationControl1.ExeName = @"f:/EditPlus/EDITPLUS.EXE";
            ////this.applicationControl1.ExeName = @"f:/Tencent/QQ/QQ.exe";//QQ的没成功
            //this.applicationControl1.Location = new System.Drawing.Point(29, 26);
            //this.applicationControl1.Name = "applicationControl1";
            //this.applicationControl1.Size = new System.Drawing.Size(230, 195);
            //this.applicationControl1.TabIndex = 0;

        }
    }
}



