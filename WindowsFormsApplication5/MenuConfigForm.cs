using iPlant.IEMS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class MenuConfigForm : Form
    {
        public delegate void TitleChangedHandler(string title);

        public TitleChangedHandler TitleChanged;

        public MenuConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载树节点
        /// </summary>
        private void setTreeView()
        {
            foreach (AccModel item in list)
            {
                var node = new TreeNode();
                node.Text = item.name;
                node.Tag = item.key;
                foreach (var app in item.Child)
                {
                    var cNode = new TreeNode
                    {
                        Text = app.name,
                        Tag = app
                    }; 
                    
                    node.Nodes.Add(cNode);
                }
                treeView1.Nodes.Add(node);
            }
            treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
  
            //treeView1.Click += new EventHandler(CNode_Click);
        }


         
        //private event TreeNodeMouseClickEventHandler NodeMouseClick; 
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)  //鼠标点击节点触发的事件
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)  //单击鼠标左键才响应
            {
                HideForm();
                if (e.Node.Level == 1) //判断子节点才响应
                {
                    var acc = e.Node.Tag as AddrProcess;
                    this.txtServiceName.Text = e.Node.Text;
                    txtAddrUrl.Text = acc.addrUrl;
                    txtProcessID.Text = acc.ProcessID.ToString();
                    txtHandle.Text = acc.MainWindowHandle;
                    btnAddChild.Enabled = true;
                    btnAddRootNode.Enabled = false;
                    cbFullScreen.Checked = acc.FullScreen == 1;

                    HidePanel(panel2);
                    lbTips.Text = "修改服务";
                    lbTips.Show();
                    lbWorkShop.Show();
                    tbWorkShopTip.Text = e.Node.Parent.Text;
                    tbWorkShopTip.Enabled = false;
                    tbWorkShopTip.Visible = true;
                    lbWorkShopTip.Visible = true;
                    lbService.Visible = true;
                    lbAddrUrl.Visible = true;
                    btnChoose.Visible = true;
                    txtAddrUrl.Visible = true;
                    cbFullScreen.Visible = true;
                    txtServiceName.Visible = true;
                    btnEditService.Visible = true;
                    btnDeleteService.Visible = true;
                }
                else
                {
                    this.txtNodeName.Text = e.Node.Text;
                    txtAddrUrl.Text = "";
                    txtHandle.Text = "";
                    txtProcessID.Text = "";
                    btnAddChild.Enabled = true;
                    btnAddRootNode.Enabled = true;

                    HidePanel(panel1);
                    lbTips.Text = "修改车间";
                    lbTips.Show(); 
                    lbWorkShop.Visible = true;
                    txtNodeName.Visible = true; 
                    btnShowAddService.Visible = true;
                    btnShowAddService.Show();
                    btnEditWorkShop.Visible = true;
                    btnDeleteWorkShop.Visible = true;

                }
            }    
        }
         


        private void ClearForm()
        {
            txtHandle.Text = "";
            txtAddrUrl.Text = "";
            txtNodeName.Text = "";
            txtServiceName.Text = "";
            txtProcessID.Text = "";
        }

        //初始化 
        List<AccModel> list;
        private void MenuConfigForm_Load(object sender, EventArgs e)
        { 
            ////初始化自定义资源 
            list = MyResourceManager.Init(); 
            setTreeView();
            HideForm();
        }

        /// <summary>
        /// 添加车间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRootNode_Click(object sender, EventArgs e)
        {
            string name = txtNodeName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("节点名不可以为空");
                return;
            }
            var node1 = new TreeNode();
           
            node1.Text =name;
            string key=MyResourceManager.GetMaxKey();
            node1.Tag = key;//记录下来
            //添加最后
            treeView1.Nodes.Add(node1);
            //写入xml
            MyResourceManager.AddResource(new AccModel { key= key,name = name});
            ClearForm();
            MyResourceManager.Init(); 
        }


        /// <summary>
        /// 添加子节点服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddChild_Click(object sender, EventArgs e)
        {
            string addrUrl = txtAddrUrl.Text.Trim();
            string name = txtServiceName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("节点名不可以为空");
                return;
            }
            if (string.IsNullOrEmpty(addrUrl))
            {
                MessageBox.Show("地址不能为空");
                return;
            }
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选中父节点");
                return;
                //treeView1.Nodes.Add(node1);
            }

            int FullScreen = 0;
            if (cbFullScreen.Checked)
            {
                FullScreen  = 1;
            }

            var node1 = new TreeNode();
            node1.Text = name;
            int pid =0;
            if (!string.IsNullOrEmpty(txtProcessID.Text.Trim()))
            {
                if (!int.TryParse(txtProcessID.Text.Trim(), out pid))
                {
                    MessageBox.Show("PID 必须是数字");
                    return;
                }
            }
            string handle = "0";
            if (!string.IsNullOrEmpty(txtHandle.Text.Trim()))
            {
                handle = txtHandle.Text.Trim();
            }
            string key =string.Empty ;
            node1.Tag = new AddrProcess { key = key, addrUrl = addrUrl, MainWindowHandle = handle, ProcessID = pid, embedResult = 0, FullScreen = FullScreen };
            int level = treeView1.SelectedNode.Level ;
            if (level == 0)
            {
                key = treeView1.SelectedNode.Tag.ToString();
                node1.Tag = new AddrProcess { key = key, addrUrl = addrUrl, MainWindowHandle = handle, ProcessID = pid, embedResult = 0, FullScreen = FullScreen };
                treeView1.SelectedNode.Nodes.Add(node1);
            }
            else
            {
                key = treeView1.SelectedNode.Parent.Tag.ToString();
                node1.Tag = new AddrProcess { key = key, addrUrl = addrUrl, MainWindowHandle = handle, ProcessID = pid, embedResult = 0, FullScreen = FullScreen };
                treeView1.SelectedNode.Parent.Nodes.Add(node1);  
            }

            //写入xml
            MyResourceManager.AddResource(new AccModel { key = key, Child = new AddrProcess[]  { new AddrProcess{ name = name, MainWindowHandle= handle, ProcessID= pid, embedResult=0, addrUrl= addrUrl , FullScreen= FullScreen }} });

            //txtHandle.Text = "";
            //txtAddrUrl.Text = "";
            //txtNodeName.Text = "";
            //txtServiceName.Text = "";
            //txtProcessID.Text = "";
            MyResourceManager.Init(); 
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择节点");
                return;
            }
            DialogResult result = MessageBox.Show("确认删除" + treeView1.SelectedNode.Text + "?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
            {
                return;
            }

            //清空
            ClearForm();
            var oldNode = new AccModel();
            if (treeView1.SelectedNode.Level == 0)
            {
                oldNode.key = treeView1.SelectedNode.Tag.ToString();
            }
            else
            {
                oldNode.key = treeView1.SelectedNode.Parent.Tag.ToString();
                oldNode.Child = new AddrProcess[] { new AddrProcess { name = treeView1.SelectedNode.Text } };
            }
            MyResourceManager.DelResource(oldNode);
            treeView1.SelectedNode.Remove();
            MyResourceManager.Init(); 
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择节点");
                return;
            } 
            string name = txtNodeName.Text.Trim();
            object tag = new object();
            var node = new AccModel();
            string oldName = "";//子name
            if (treeView1.SelectedNode.Level == 0)
            {
                tag = treeView1.SelectedNode.Tag.ToString();
                node.key = treeView1.SelectedNode.Tag.ToString();
                node.name = name;
            }
            else
            {
                name= txtServiceName.Text.Trim();
                node.key = treeView1.SelectedNode.Parent.Tag.ToString();
                oldName = treeView1.SelectedNode.Text;
                int pid = 0;
                if (!string.IsNullOrEmpty(txtProcessID.Text.Trim()))
                {
                    if (!int.TryParse(txtProcessID.Text.Trim(), out pid))
                    {
                        MessageBox.Show("PID 必须是数字");
                        return;
                    }
                }
                string handle = "0";
                if (!string.IsNullOrEmpty(txtHandle.Text.Trim()))
                {
                    handle = txtHandle.Text.Trim();
                }
                node.Child = new AddrProcess[] { new AddrProcess { name = name, MainWindowHandle = handle, ProcessID = pid, embedResult = 0, addrUrl = txtAddrUrl.Text.Trim(), FullScreen = cbFullScreen.Checked  ?1:0 } };
                tag = new AddrProcess { name = name, MainWindowHandle = handle, ProcessID = pid, embedResult = 0, addrUrl = txtAddrUrl.Text.Trim(), FullScreen = cbFullScreen.Checked ? 1 : 0 };
            }
            MyResourceManager.EditResource(node,oldName);
            treeView1.SelectedNode.Text = name;
            treeView1.SelectedNode.Tag = tag;
            MyResourceManager.Init(); 
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "exe文件(*.exe)|*.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAddrUrl.Text=  openFileDialog1.FileName ;
            }
        }

        /// <summary>
        /// 触发显示添加车间界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSetting_Click(object sender, EventArgs e)
        {
            HideForm();
            HidePanel(panel1);
            lbWorkShop.Visible = true;
            txtNodeName.Text = "";
            txtNodeName.Visible = true;
            btnAddRootNode.Visible = true;
            lbTips.Text = "新增车间";
            lbTips.Show();
        }

        /// <summary>
        /// 隐藏所有form控件
        /// </summary>
        void HideForm()
        {
            lbTips.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false; 
        }

        /// <summary>
        /// 隐藏panel
        /// </summary>
        /// <param name="panel"></param>
        void HidePanel(Panel panel)
        {
            panel.Visible = true;
            foreach (Control item in panel.Controls)
            {
                item.Visible = false;
            }
        }

        /// <summary>
        /// 显示添加服务界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        { 
            HideForm();
            HidePanel(panel2);
            lbWorkShopTip.Visible = true;
            tbWorkShopTip.Text = txtNodeName.Text;
            tbWorkShopTip.Visible = true;
            lbService.Visible = true;
            txtServiceName.Visible = true;
            txtServiceName.Text = "";
            lbAddrUrl.Visible = true;
            txtAddrUrl.Visible = true;
            txtAddrUrl.Text = "";
            btnChoose.Visible = true;
            btnAddChild.Visible = true;
            lbTips.Text = "添加服务";
            lbTips.Show();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //初始化自定义资源 
            list = MyResourceManager.Init();
 
            //if (TitleChanged != null) 
            //    TitleChanged("Test Title"); //委托调用
             
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
