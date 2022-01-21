namespace WindowsFormsApplication5
{
    partial class MenuConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnAddRootNode = new System.Windows.Forms.Button();
            this.lbWorkShop = new System.Windows.Forms.Label();
            this.lbAddrUrl = new System.Windows.Forms.Label();
            this.txtAddrUrl = new System.Windows.Forms.TextBox();
            this.lable3 = new System.Windows.Forms.Label();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnEditService = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lbService = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnEditWorkShop = new System.Windows.Forms.Button();
            this.btnShowAddService = new System.Windows.Forms.Button();
            this.lbTips = new System.Windows.Forms.Label();
            this.btnDeleteWorkShop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbWorkShopTip = new System.Windows.Forms.Label();
            this.tbWorkShopTip = new System.Windows.Forms.TextBox();
            this.btnShowAddWorkShop = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(264, 681);
            this.treeView1.TabIndex = 0;
            // 
            // txtNodeName
            // 
            this.txtNodeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNodeName.Location = new System.Drawing.Point(75, 12);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(262, 23);
            this.txtNodeName.TabIndex = 1;
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteService.Image = global::WindowsFormsApplication5.Properties.Resources.delete1;
            this.btnDeleteService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteService.Location = new System.Drawing.Point(199, 170);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteService.TabIndex = 3;
            this.btnDeleteService.Text = "删除";
            this.btnDeleteService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddRootNode
            // 
            this.btnAddRootNode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRootNode.Image = global::WindowsFormsApplication5.Properties.Resources.保存1;
            this.btnAddRootNode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRootNode.Location = new System.Drawing.Point(75, 53);
            this.btnAddRootNode.Name = "btnAddRootNode";
            this.btnAddRootNode.Size = new System.Drawing.Size(75, 23);
            this.btnAddRootNode.TabIndex = 4;
            this.btnAddRootNode.Text = "保存";
            this.btnAddRootNode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRootNode.UseVisualStyleBackColor = true;
            this.btnAddRootNode.Click += new System.EventHandler(this.btnAddRootNode_Click);
            // 
            // lbWorkShop
            // 
            this.lbWorkShop.AutoSize = true;
            this.lbWorkShop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkShop.Location = new System.Drawing.Point(3, 15);
            this.lbWorkShop.Name = "lbWorkShop";
            this.lbWorkShop.Size = new System.Drawing.Size(63, 14);
            this.lbWorkShop.TabIndex = 5;
            this.lbWorkShop.Text = "车间名称";
            // 
            // lbAddrUrl
            // 
            this.lbAddrUrl.AutoSize = true;
            this.lbAddrUrl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddrUrl.Location = new System.Drawing.Point(3, 87);
            this.lbAddrUrl.Name = "lbAddrUrl";
            this.lbAddrUrl.Size = new System.Drawing.Size(63, 14);
            this.lbAddrUrl.TabIndex = 5;
            this.lbAddrUrl.Text = "服务地址";
            // 
            // txtAddrUrl
            // 
            this.txtAddrUrl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddrUrl.Location = new System.Drawing.Point(76, 84);
            this.txtAddrUrl.Multiline = true;
            this.txtAddrUrl.Name = "txtAddrUrl";
            this.txtAddrUrl.Size = new System.Drawing.Size(209, 47);
            this.txtAddrUrl.TabIndex = 6;
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable3.Location = new System.Drawing.Point(284, 545);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(49, 14);
            this.lable3.TabIndex = 5;
            this.lable3.Text = "进程ID";
            this.lable3.Visible = false;
            // 
            // txtProcessID
            // 
            this.txtProcessID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProcessID.Location = new System.Drawing.Point(356, 536);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.Size = new System.Drawing.Size(262, 23);
            this.txtProcessID.TabIndex = 1;
            this.txtProcessID.Visible = false;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable4.Location = new System.Drawing.Point(284, 594);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(35, 14);
            this.lable4.TabIndex = 5;
            this.lable4.Text = "句柄";
            this.lable4.Visible = false;
            // 
            // txtHandle
            // 
            this.txtHandle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHandle.Location = new System.Drawing.Point(356, 594);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(262, 23);
            this.txtHandle.TabIndex = 1;
            this.txtHandle.Visible = false;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddChild.Image = global::WindowsFormsApplication5.Properties.Resources.保存1;
            this.btnAddChild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddChild.Location = new System.Drawing.Point(75, 141);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 4;
            this.btnAddChild.Text = "保存";
            this.btnAddChild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnEditService
            // 
            this.btnEditService.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditService.Image = global::WindowsFormsApplication5.Properties.Resources.edit1;
            this.btnEditService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditService.Location = new System.Drawing.Point(75, 170);
            this.btnEditService.Name = "btnEditService";
            this.btnEditService.Size = new System.Drawing.Size(75, 23);
            this.btnEditService.TabIndex = 7;
            this.btnEditService.Text = "修改";
            this.btnEditService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditService.UseVisualStyleBackColor = true;
            this.btnEditService.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtServiceName
            // 
            this.txtServiceName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServiceName.Location = new System.Drawing.Point(76, 40);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(262, 23);
            this.txtServiceName.TabIndex = 1;
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbService.Location = new System.Drawing.Point(3, 43);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(63, 14);
            this.lbService.TabIndex = 5;
            this.lbService.Text = "服务名称";
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(291, 84);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(47, 23);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "查找";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnEditWorkShop
            // 
            this.btnEditWorkShop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditWorkShop.Image = global::WindowsFormsApplication5.Properties.Resources.edit1;
            this.btnEditWorkShop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditWorkShop.Location = new System.Drawing.Point(75, 82);
            this.btnEditWorkShop.Name = "btnEditWorkShop";
            this.btnEditWorkShop.Size = new System.Drawing.Size(75, 23);
            this.btnEditWorkShop.TabIndex = 7;
            this.btnEditWorkShop.Text = "修改";
            this.btnEditWorkShop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditWorkShop.UseVisualStyleBackColor = true;
            this.btnEditWorkShop.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnShowAddService
            // 
            this.btnShowAddService.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowAddService.Image = global::WindowsFormsApplication5.Properties.Resources.Add1;
            this.btnShowAddService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowAddService.Location = new System.Drawing.Point(75, 136);
            this.btnShowAddService.Name = "btnShowAddService";
            this.btnShowAddService.Size = new System.Drawing.Size(95, 29);
            this.btnShowAddService.TabIndex = 10;
            this.btnShowAddService.Text = "添加服务";
            this.btnShowAddService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAddService.UseVisualStyleBackColor = true;
            this.btnShowAddService.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTips
            // 
            this.lbTips.AutoSize = true;
            this.lbTips.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTips.Location = new System.Drawing.Point(284, 12);
            this.lbTips.Name = "lbTips";
            this.lbTips.Size = new System.Drawing.Size(62, 16);
            this.lbTips.TabIndex = 11;
            this.lbTips.Text = "label1";
            // 
            // btnDeleteWorkShop
            // 
            this.btnDeleteWorkShop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteWorkShop.Image = global::WindowsFormsApplication5.Properties.Resources.delete1;
            this.btnDeleteWorkShop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteWorkShop.Location = new System.Drawing.Point(199, 82);
            this.btnDeleteWorkShop.Name = "btnDeleteWorkShop";
            this.btnDeleteWorkShop.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteWorkShop.TabIndex = 12;
            this.btnDeleteWorkShop.Text = "删除";
            this.btnDeleteWorkShop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteWorkShop.UseVisualStyleBackColor = true;
            this.btnDeleteWorkShop.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditWorkShop);
            this.panel1.Controls.Add(this.btnDeleteWorkShop);
            this.panel1.Controls.Add(this.txtNodeName);
            this.panel1.Controls.Add(this.btnAddRootNode);
            this.panel1.Controls.Add(this.btnShowAddService);
            this.panel1.Controls.Add(this.lbWorkShop);
            this.panel1.Location = new System.Drawing.Point(287, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 191);
            this.panel1.TabIndex = 111;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.tbWorkShopTip);
            this.panel2.Controls.Add(this.lbWorkShopTip);
            this.panel2.Controls.Add(this.btnEditService);
            this.panel2.Controls.Add(this.btnAddChild);
            this.panel2.Controls.Add(this.btnDeleteService);
            this.panel2.Controls.Add(this.lbService);
            this.panel2.Controls.Add(this.btnChoose);
            this.panel2.Controls.Add(this.txtServiceName);
            this.panel2.Controls.Add(this.txtAddrUrl);
            this.panel2.Controls.Add(this.lbAddrUrl);
            this.panel2.Location = new System.Drawing.Point(287, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 234);
            this.panel2.TabIndex = 0;
            // 
            // lbWorkShopTip
            // 
            this.lbWorkShopTip.AutoSize = true;
            this.lbWorkShopTip.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lbWorkShopTip.Location = new System.Drawing.Point(3, 12);
            this.lbWorkShopTip.Name = "lbWorkShopTip";
            this.lbWorkShopTip.Size = new System.Drawing.Size(63, 14);
            this.lbWorkShopTip.TabIndex = 9;
            this.lbWorkShopTip.Text = "车间名称";
            // 
            // tbWorkShopTip
            // 
            this.tbWorkShopTip.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWorkShopTip.Location = new System.Drawing.Point(76, 6);
            this.tbWorkShopTip.Name = "tbWorkShopTip";
            this.tbWorkShopTip.Size = new System.Drawing.Size(262, 23);
            this.tbWorkShopTip.TabIndex = 10;
            // 
            // btnShowAddWorkShop
            // 
            this.btnShowAddWorkShop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowAddWorkShop.Image = global::WindowsFormsApplication5.Properties.Resources.Add;
            this.btnShowAddWorkShop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowAddWorkShop.Location = new System.Drawing.Point(12, 658);
            this.btnShowAddWorkShop.Name = "btnShowAddWorkShop";
            this.btnShowAddWorkShop.Size = new System.Drawing.Size(92, 35);
            this.btnShowAddWorkShop.TabIndex = 9;
            this.btnShowAddWorkShop.Text = "添加车间";
            this.btnShowAddWorkShop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAddWorkShop.UseVisualStyleBackColor = true;
            this.btnShowAddWorkShop.Click += new System.EventHandler(this.btnAddSetting_Click);
            // 
            // MenuConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(645, 705);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTips);
            this.Controls.Add(this.btnShowAddWorkShop);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.lable3);
            this.Controls.Add(this.txtHandle);
            this.Controls.Add(this.txtProcessID);
            this.Controls.Add(this.treeView1);
            this.Name = "MenuConfigForm";
            this.Text = "MenuConfigForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Button btnAddRootNode;
        private System.Windows.Forms.Label lbWorkShop;
        private System.Windows.Forms.Label lbAddrUrl;
        private System.Windows.Forms.TextBox txtAddrUrl;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.TextBox txtProcessID;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnShowAddWorkShop;
        private System.Windows.Forms.Button btnEditWorkShop;
        private System.Windows.Forms.Button btnShowAddService;
        private System.Windows.Forms.Label lbTips;
        private System.Windows.Forms.Button btnDeleteWorkShop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbWorkShopTip;
        private System.Windows.Forms.Label lbWorkShopTip;
    }
}