using iPlant.IEMS.Util;
using SmileWei.EmbeddedApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_ShowMenu);
        }
        void Form1_ShowMenu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { 
                this.flowLayoutPanel1.Show();
            } 
        }


        /// <summary>  
        /// 改变按钮位置  
        /// </summary>  
        /// <param name="btn"></param>  
        private void ChangeLocation(Button btn)
        {
            this.flowLayoutPanel1.TabIndex = btn.TabIndex + 1;
            this.flowLayoutPanel1.Top  = btn.Top + btn.Height;
           
        }  

        /// <summary>
        /// 初始化菜单
        /// </summary>
       public void InitButtonMenu3(List<AccModel> list )
       { 
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            { 
                var item = flowLayoutPanel1.Controls[i];
                if (item is FlowLayoutPanel) 
                {
                    continue;
                }
                this.flowLayoutPanel1.Controls.Remove(item);
                i--;
            }
            
            flowLayoutPanel2.Controls.Clear();
            int count = list.Count();
            //添加 9个button
            for (int i = 1; i < count + 1; i++)
            {
                var b = new Button(); 
                b.Width = this.flowLayoutPanel1.Width;
                b.Height = 35;
                b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                b.UseVisualStyleBackColor = true;
                b.Margin = new System.Windows.Forms.Padding(0);
                b.Padding = new System.Windows.Forms.Padding(0);
                b.Text = list[i-1].name; //"btn_" + i;
                b.Name = "btn_" + i;
                b.Click += new System.EventHandler(Btn_Clicked);
                this.flowLayoutPanel1.Controls.Add(b);
            }
             
            //panel_1.AutoSize = true;
            //添加9组 label
            for (int i = 1; i < count + 1; i++)
            {
                var accmodel = list[i - 1];
                string key = accmodel.key;

                //每组 包含3个label ,后改成button了
                for (int j = 1; j <  accmodel.Child.Length + 1; j++)
                {
                    var l = new Button(); 
                    l.TextAlign = ContentAlignment.MiddleLeft;
                    l.Margin = new System.Windows.Forms.Padding(0);
                    l.Padding = new System.Windows.Forms.Padding(0);
                    l.FlatStyle = FlatStyle.Flat;
                    l.FlatAppearance.BorderSize = 1;

                    l.Width= this.flowLayoutPanel1 .Width;
                    var child= MakeProcessChild(j,accmodel);

                    bool liveStatus = GetRunning (child)>0;
                    l.BackColor =liveStatus? Color.Green:Color.LightGray;
                    l.Text =child.name ;  // i + "label_" + j;
                    l.Name = key + "," + j;// i + "," + j;
                    var cm=new System.Windows.Forms.ContextMenu(); 
                    l.ContextMenu = cm;
                    var myItem = new MenuItem();
                     
                    myItem.Text = liveStatus? "关闭":"开启";
                    myItem.Name = key + "," + j;// i + "," + j;
                    myItem.Click += new EventHandler(CustomItem_Click);////这里为子菜单添加Click事件
                    cm.MenuItems.Add(myItem);

                    //只显示第一组label
                    l.Visible = i == 1;
                    //l.Click += new EventHandler(Label_Clicked);
                    l.MouseDown += new MouseEventHandler(Label_MouseDown);
                    this.flowLayoutPanel2.Controls.Add(l);
                }

            }
            this.flowLayoutPanel1.Controls.SetChildIndex(flowLayoutPanel2, 1); 
        }  

        /// <summary>
        /// 获取服务对象
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        AddrProcess MakeProcessChild(int i, AccModel acc)
        {
            return acc.Child[i-1]; 
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private bool GetLive(int i, int j)
        {
            return new Random().Next(3) == j; 
        }
        private void CustomItem_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            string text= mi.Text;
            string name = mi.Name; 
            //根据sender的Name属性来区分是点了哪个了菜单，写相应的事件处理代码
            //MessageBox.Show(((MenuItem)sender).Name);

            //开关相应的程序
            //如果成功修改状态
            var controls= this.flowLayoutPanel2.Controls;
            foreach (var item in controls)
	        {
                Button l = (Button)item;
                if(l.Name==name)
                {
                    if(text=="开启"){
                        //var mi2 = new MenuItem("关闭 ", new EventHandler(CustomItem_Click));
                        //mi2.Name = name;
                        //l.ContextMenu = new ContextMenu(new MenuItem[] {mi2  });
                        //l.Text= "关闭";
                        var arrayName  = name.Split(',');
                        var acc = list.Where(w => w.key == arrayName[0]).FirstOrDefault();
                        var child = MakeProcessChild(int.Parse(arrayName[1]), acc);
                       
                        int id=  DoProcess(child);
                        if (id == 0)
                        {
                            MessageBox.Show("启动失败");
                        }
                        else
                        { 
                            l.BackColor = Color.Green;
                            mi.Text = "关闭";
                        }
                    }
                    else
                    {
                        l.BackColor=Color.LightGray;
                        mi.Text = "开启"; 
                    }
                    break;
                }
 	        }
        } 
 
        //初始化 
        List<AccModel> list;
        SuspensionForm suspensionForm = new SuspensionForm();
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TopMost = true;

      

            //初始化自定义资源 
            list = MyResourceManager.Init();

            InitButtonMenu3(list);
            MakeNewParent();

            //弹出悬浮窗体
            suspensionForm.Owner = this;
            suspensionForm.Show();  
        } 

        private void ComBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox a = (ComboBox)sender;
            MessageBox.Show(a.SelectedItem.ToString());
        }

        /// <summary>
        /// 按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            //MessageBox.Show(a.Text.ToString());
            int i = int.Parse(btn.Name.Replace("btn_","")); 
            int btnIndex=btn.TabIndex ;
            foreach (var f in this.flowLayoutPanel2.Controls)
            {
                if (f is Button)
                {
                    var l = f as Button;

                    if (l.Name.Split(',')[0] == list[i - 1].key)
                    {
                        l.Visible = true;
                    }
                    else
                    {
                        l.Visible = false;
                    }
                } 
                this.flowLayoutPanel1.Controls.SetChildIndex(flowLayoutPanel2, btnIndex);
            }
        }


        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Clicked(object sender, EventArgs e)
        {
            var a = (Button)sender; 
            if (a.BackColor == Color.Green)
            {
                var arrayName = a.Name .Split(',');
                var acc = list.Where(w => w.key == arrayName[0]).FirstOrDefault();
                var child = MakeProcessChild(int.Parse(arrayName[1]), acc);
                DoProcess(child);
            }  
            //MessageBox.Show(a.Text.ToString());
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var a = (Button)sender;
            if (e.Button  == MouseButtons.Left)
            {
                if (a.BackColor == Color.Green)
                {
                    var arrayName = a.Name.Split(',');
                    var acc = list.Where(w => w.key == arrayName[0]).FirstOrDefault();
                    var child = MakeProcessChild(int.Parse(arrayName[1]), acc);
                    int id= DoProcess(child);
                    if (id == 0)
                    {
                         MessageBox.Show("打开失败"); 
                    }
                } 
            }
        }

        //contextMenuStrip1
        private void Label_Right(object sender, EventArgs e)
        {
            var a = (Label)sender;
            
        }

        #region 控制显示
        Dictionary<int, string> dict = new Dictionary<int, string>();
  
        /// <summary>
        /// 展示窗体进程
        /// </summary>
        /// <param name="accprocess"></param>
        /// <param name="fullScreen">全屏</param>
        /// <returns></returns>
        private int DoProcess(AddrProcess accprocess)
        {
            bool fullScreen = accprocess.FullScreen==1;

            string name =accprocess.addrUrl;
            int id = accprocess.ProcessID;
            //var allProcess = System.Diagnostics.Process.GetProcesses(); 
            //var app = allProcess.Where(w => w.ProcessName == name).OrderBy(o => o.StartTime).FirstOrDefault(); 
            bool appRuning = false;
            try
            {
                //var app = System.Diagnostics.Process.GetProcessById(id);
                //if (app != null)
                //{
                //    if (app.MainWindowHandle != IntPtr.Zero)
                //    {
                //        appBox.AppProcess = app;
                //        appBox.EmbedAgain();
                //    }
                //    else
                //    {
                //        int mainWindowHandle = 2954846;//嵌入后变成0
                //        appBox.ShowWindowTest(mainWindowHandle);
                //    }
                //    appRuning = true;
                //}
                if (id > 0  )
                {
                    id = GetRunning(accprocess);
                    if (id > 0)
                    { 
                        var mHandle=new IntPtr(int.Parse(accprocess.MainWindowHandle));
                        //var app = System.Diagnostics.Process.GetProcessById(id);
                        //app.MainModule.FileName;

                        if (fullScreen)
                        {
                            var b =Win32API. ShowWindow(mHandle , 3);//0表示隐藏窗口 
                            int testTime = 0;
                            while (!b&&testTime<3)
                            {
                                b = Win32API.ShowWindow(mHandle, 3); 
                                Thread.Sleep(200);
                                testTime++;
                            }
                            if (b)
                            { 
                                this.WindowState = FormWindowState.Minimized;
                                suspensionForm.Show();
                                appRuning = true;
                            }
                            else
                            {
                                appRuning = false;
                            }
                        }
                        else
                        { 
                            //如果进程已经脱离主窗体
                            if (accprocess.embedResult == 0)
                            {
                                bool embed = appBox.EmbedAgain(mHandle);
                                if (embed)
                                {
                                    foreach (var item in list)
                                    {
                                        foreach (var c in item.Child)
                                        {
                                            if (c.ProcessID == id)
                                            {
                                                c.embedResult = 1;
                                                break;
                                            }
                                        }
                                    }

                                    //显示 
                                    appBox.ShowWindowByPidDict(id, dict);
                                    appRuning = true;
                                }
                                else
                                {
                                    appRuning = false;
                                }
                            }
                            else
                            {
                                //直接显示 
                                bool show = appBox.ShowWindowByPidDict(id, dict);
                                appRuning = true; 
                            } 
                        }
 
                    } 
                }
            }
            catch (Exception ex)
            { 
            }
            //重新启动
            if (!appRuning)
            {
                ////kill  
                //var allProcess = System.Diagnostics.Process.GetProcesses();
                //var app = allProcess.Where(w => w.ProcessName == name).OrderBy(o => o.StartTime).FirstOrDefault(); 
       
                var kv = StartProcess(name,fullScreen);
                id = kv.Key;
                if (id != accprocess.ProcessID)
                {
                    accprocess.ProcessID = id;//新的
                    accprocess.MainWindowHandle = kv.Value;
                    accprocess.embedResult = 1;
                    MyResourceManager.WriteResource(accprocess);
                    SetEmbed(id,accprocess); 
                } 
                
            }
            ////进入最大化模式 
            //this.appBox.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //this.flowLayoutPanel1.Hide();
            ////透明度
            //this.flowLayoutPanel1.BackColor=            System.Drawing.Color.FromArgb(10, Color.LightGray);
            return id; // appRuning = true; 
        }

        /// <summary>
        /// 设置嵌入
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newId">新id代表需更新</param>
        /// <returns></returns>
        void SetEmbed(int id, AddrProcess accprocess)
        {
            foreach (var item in list)
            {
                foreach (var c in item.Child)
                {
                    if (c.ProcessID == id)
                    {
                        c.ProcessID = accprocess.ProcessID;
                        c.MainWindowHandle = accprocess.MainWindowHandle;
                        c.embedResult = accprocess.embedResult;
                        break;
                    }
                }
            } 
        }
 
        /// <summary>
        /// 移出来
        /// </summary>
        /// <param name="appMainWindowHandle"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool UnEmbedProcessByMainWindowHandle(IntPtr appMainWindowHandle,IntPtr parent)
        {
            // Get the main handle
            if (appMainWindowHandle == IntPtr.Zero  ) return false;
             
            try
            {
                // Put it out this container
                var b=   Win32API.SetParent(appMainWindowHandle, parent)>0;


                //   border and whatnot               
                //Win32API.SetWindowLong(new HandleRef(this, appMainWindowHandle), Win32API.GWL_STYLE, Win32API.WS_VISIBLE);
                return b;
            }
            catch (Exception)
            { }
            return false;
        }

        /// <summary>
        /// 获取进程状态
        /// </summary>
        /// <param name="accprocess"></param>
        /// <returns>pid</returns>
        int GetRunning( AddrProcess  accprocess)
        {
            string name =accprocess.addrUrl;
            int id = accprocess.ProcessID; 
            //p.OrderBy(o => o.StartTime).LastOrDefault(w => w.MainModule.FileName == oldName);
            var mc = Regex.Match(name, @"[^\\|^/]+$");
            if (mc.Success)
            {
                name = mc.Value.Replace(".exe","");
            }
           
            Process[] p = System.Diagnostics.Process.GetProcessesByName(name);//.OrderBy(o => o.Id).LastOrDefault();

            if (p != null)
            { 
                var currentProcess = p.FirstOrDefault(w => w.Id ==  id);
               
                if (currentProcess == null)
                {
                    IntPtr mainHandle = IntPtr.Zero;
                    //通过名称直接找pid
                    foreach (var item in p)
                    {
                         //item.ProcessName; 
                        string path = string.Empty;

                        try
                        {
                            path = item.MainModule.FileName; 
                        }
                        catch (Exception)
                        {  
                            continue;
                        }
                            
                        if (path == accprocess.addrUrl )
                        {
                            int pid = item.Id;
                            if (pid > 0)
                            { 
                                mainHandle = new MyProcess().GetMainWindowHandle(pid);
                                if (mainHandle != IntPtr.Zero)
                                {
                                    if (!dict.ContainsKey(pid))
                                    {
                                        dict.Add(pid, mainHandle.ToString());
                                    }
                                    else
                                    {
                                        dict[pid]=  mainHandle.ToString();
                                    }

                                    //修改xml 
                                    accprocess.ProcessID = pid;
                                    accprocess.MainWindowHandle = mainHandle.ToString();
                                    //accprocess.embedResult = 0;
                                    MyResourceManager.WriteResource(accprocess);
                                    return pid;
                                }
                            }
                        }
                    } 
                    return   0;
                }
                else
                {
                    //窗体检查并不准确
                    //var isExist = IsWindowExist((IntPtr) int.Parse( accprocess.MainWindowHandle));
                    //if (isExist)
                    //{ 
                    //    return UpdateList(id);
                    //}
                    //return false; 
                    UpdateList(id);
                    return id;
                }
            }
            return 0;
            
        } 

        /// <summary>
        /// 修改process
        /// path为标准
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <param name="MainWindowHandle"></param>
        /// <returns></returns>
        private bool UpdateList( int id   )
        {
            foreach (var item in list)
            {
                for (int i = 0; i < item.Child.Length; i++)
                {
                    var process = item.Child[i]; 
                    if (process.ProcessID == id)
                    {
                        if (int.Parse(process.MainWindowHandle) > 0)
                        {
                            if (!dict.ContainsKey(id))
                            {
                                //主窗体崩了需要补充
                                dict.Add(id, process.MainWindowHandle);
                            }else
                            {

                                dict[id] = process.MainWindowHandle;
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            } 
            return true;
        }

        /// <summary>
        /// 获取进程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Process GetProcessById(int id)
        {
            return   System.Diagnostics.Process.GetProcessById(id); 
        }
        

        // Handle Exited event and display process information.
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            var app = (Process)sender;
            int pid= app.Id; 
            string name = "";
            foreach (AccModel model in list)
            { 
                int i=1;
                foreach (var child in model.Child)
	            {
		            if(child.ProcessID==pid){
                        name= model.key+","+i ; 
                    }
                    i++;
	            } 
            }
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var controls = this.flowLayoutPanel2.Controls;
            foreach (var item in controls)
            {
                Button l = (Button)item;
                if (l.Name == name)
                { 
                    l.BackColor = Color.LightGray;
                    MenuItem mi = l.ContextMenu.MenuItems[0];
                    mi.Text = "开启"; 
                    break;
                }
            }
        }


        /// <summary>
        /// 启动一个新的
        /// </summary>
        /// <param name="path"></param>
        private KeyValuePair<int, string> StartProcess(string path,bool fullScreen=false)
        {
            var kv=new KeyValuePair<int, string>();
            if (fullScreen) {
                Process myProcess = new Process();
                IntPtr OtherExeWnd = new IntPtr(0); 
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = path;
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += new EventHandler(myProcess_Exited);
                var b = myProcess.Start();

                while (myProcess.MainWindowHandle == IntPtr.Zero)
                {
                }

                OtherExeWnd = myProcess.MainWindowHandle;
                 
                b = Win32API. ShowWindow(OtherExeWnd, 3);//0表示隐藏窗口
                if (b)
                {
                   // this.WindowState = FormWindowState.Minimized;
                    kv = new KeyValuePair<int, string>(myProcess.Id,myProcess.MainWindowHandle.ToString() );  
                }
                else
                {
                    kv =  new KeyValuePair<int, string>(0,"启动失败");
                }
            }
            else
            {
                appBox.AppFilename = path;// @"C:\Users\Administrator\Downloads\article_src\AppControl\WindowsFormsApplication3\bin\Debug\WindowsFormsApplication3.exe";
                kv = appBox.Start(  new EventHandler(myProcess_Exited));
                if (appBox.IsStarted)
                {
                    //txtAppFilename.Text = appBox.AppFilename;
                }
            }
            
            if (!dict.ContainsKey(kv.Key))
            {
                dict.Add(kv.Key, kv.Value);
            }
            else
            { 
                dict[kv.Key] = kv.Value;
            }
            return kv;
        }

        
        #endregion

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //修改xml
            MyResourceManager. WriteResource();
            var newParent = parentHandle;

            foreach (var item in list)
	        {
                for (int i = 0; i < item.Child.Length; i++)
			    {
                    var app=item.Child[i];
                    if (app.embedResult == 1)
                    {
                        var b = UnEmbedProcessByMainWindowHandle((IntPtr)int.Parse(item.Child[i].MainWindowHandle), newParent); 

                    }
			    }
	        }
            //MessageBox.Show("88");
        }
        static IntPtr parentHandle = IntPtr.Zero;

        /// <summary>
        /// 创建新父窗体
        /// </summary>
        /// <returns></returns>
        private   IntPtr MakeNewParent()
        {
            if (parentHandle != IntPtr.Zero)
            {
                return parentHandle;
            }

            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string path =   config.AppSettings.Settings["EmptyFormPath"].Value;
            string name="";
            //如果窗体存在,不用新启动
            var mc = Regex.Match(path, @"[^\\|^/]+$");
            if (mc.Success)
            {
                name = mc.Value.Replace(".exe","");
            }
            Process[] p = System.Diagnostics.Process.GetProcessesByName(name);
            IntPtr newParent = IntPtr.Zero;
            if (p != null)
            { 
                bool exist= false;
                foreach (var item in p)
	            {
                    exist=IsWindowExist(   item.MainWindowHandle);
                    if(exist){
                        newParent= item.MainWindowHandle;
                        break;
                    }

	            }
            }

            if( newParent == IntPtr.Zero)
            { 
                ProcessStartInfo info = new ProcessStartInfo(path);
                info.UseShellExecute = true;

                info.WindowStyle = ProcessWindowStyle.Minimized;
                // info.WindowStyle = ProcessWindowStyle.Hidden;
                var AppProcess = System.Diagnostics.Process.Start(info);
                // Wait for process to be created and enter idle condition
                AppProcess.WaitForInputIdle();

                Thread.Sleep(200);
                newParent = AppProcess.MainWindowHandle;
            }
            parentHandle = newParent;
            return newParent;
        }

        #region Win32API
        /// <summary>
        /// 判断窗口是否存在
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        private bool IsWindowExist(IntPtr handle)
        {
            return (!(GetWindow(new HandleRef(this, handle), 4) != IntPtr.Zero) && IsWindowVisible(new HandleRef(this, handle)));
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(HandleRef hWnd);

        ///// <summary>
        ///// 获取应用程序窗口句柄
        ///// </summary>
        ///// <param name="processId"></param>
        ///// <returns></returns>
        //private IntPtr GetWindowHandle(int processId)
        //{
        //    var windowHandle = IntPtr.Zero;
        //    EnumThreadWindowsCallback windowsCallback = new EnumThreadWindowsCallback(FindMainWindow);
        //    EnumWindows(windowsCallback, IntPtr.Zero);
        //    //保持循环
        //    GC.KeepAlive(windowsCallback);

        //    bool FindMainWindow(IntPtr handle, IntPtr extraParameter)
        //    {
        //        int num;
        //        GetWindowThreadProcessId(new HandleRef(this, handle), out num);
        //        if (num == processId && IsWindowExist(handle))
        //        {
        //            windowHandle = handle;
        //            return true;
        //        }
        //        return false;
        //    }

        //    return windowHandle;
        //}
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
        #endregion

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MenuConfigForm dialog = new MenuConfigForm();
            dialog.TitleChanged = new MenuConfigForm.TitleChangedHandler(FormTitleChanged);
            
            //dialog.Show();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitButtonMenu3(list); //子窗体关闭触发刷新菜单
            }
        }

        protected void FormTitleChanged(string title)
        { 
            this.Text = title;
            //InitButtonMenu3(list); 
        }
         
        /// <summary>
        /// 调整窗体
        /// 修改窗体大小触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            //显示 
            int id = 28564;
            //appBox.ShowWindowByPidDict(id, dict);

        }
         
    }
}
