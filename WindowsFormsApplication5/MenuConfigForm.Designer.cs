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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddRootNode = new System.Windows.Forms.Button();
            this.lbWorkShop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddrUrl = new System.Windows.Forms.TextBox();
            this.lable3 = new System.Windows.Forms.Label();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lbService = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
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
            this.txtNodeName.Location = new System.Drawing.Point(356, 31);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(262, 23);
            this.txtNodeName.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(362, 485);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddRootNode
            // 
            this.btnAddRootNode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRootNode.Location = new System.Drawing.Point(543, 58);
            this.btnAddRootNode.Name = "btnAddRootNode";
            this.btnAddRootNode.Size = new System.Drawing.Size(75, 23);
            this.btnAddRootNode.TabIndex = 4;
            this.btnAddRootNode.Text = "添加车间";
            this.btnAddRootNode.UseVisualStyleBackColor = true;
            this.btnAddRootNode.Click += new System.EventHandler(this.btnAddRootNode_Click);
            // 
            // lbWorkShop
            // 
            this.lbWorkShop.AutoSize = true;
            this.lbWorkShop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkShop.Location = new System.Drawing.Point(283, 31);
            this.lbWorkShop.Name = "lbWorkShop";
            this.lbWorkShop.Size = new System.Drawing.Size(67, 14);
            this.lbWorkShop.TabIndex = 5;
            this.lbWorkShop.Text = "车间名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(283, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "服务地址";
            // 
            // txtAddrUrl
            // 
            this.txtAddrUrl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddrUrl.Location = new System.Drawing.Point(356, 191);
            this.txtAddrUrl.Multiline = true;
            this.txtAddrUrl.Name = "txtAddrUrl";
            this.txtAddrUrl.Size = new System.Drawing.Size(209, 47);
            this.txtAddrUrl.TabIndex = 6;
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable3.Location = new System.Drawing.Point(295, 258);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(53, 14);
            this.lable3.TabIndex = 5;
            this.lable3.Text = "进程ID";
            // 
            // txtProcessID
            // 
            this.txtProcessID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProcessID.Location = new System.Drawing.Point(356, 258);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.Size = new System.Drawing.Size(262, 23);
            this.txtProcessID.TabIndex = 1;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable4.Location = new System.Drawing.Point(307, 319);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(37, 14);
            this.lable4.TabIndex = 5;
            this.lable4.Text = "句柄";
            // 
            // txtHandle
            // 
            this.txtHandle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHandle.Location = new System.Drawing.Point(356, 316);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(262, 23);
            this.txtHandle.TabIndex = 1;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddChild.Location = new System.Drawing.Point(543, 343);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 4;
            this.btnAddChild.Text = "添加服务";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(479, 485);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(54, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtServiceName
            // 
            this.txtServiceName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServiceName.Location = new System.Drawing.Point(356, 147);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(262, 23);
            this.txtServiceName.TabIndex = 1;
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbService.Location = new System.Drawing.Point(283, 147);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(67, 14);
            this.lbService.TabIndex = 5;
            this.lbService.Text = "服务名称";
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(571, 191);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(47, 23);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "查找";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // MenuConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 705);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtAddrUrl);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.lable3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbService);
            this.Controls.Add(this.lbWorkShop);
            this.Controls.Add(this.btnAddChild);
            this.Controls.Add(this.btnAddRootNode);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtHandle);
            this.Controls.Add(this.txtProcessID);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.treeView1);
            this.Name = "MenuConfigForm";
            this.Text = "MenuConfigForm";
            this.Load += new System.EventHandler(this.MenuConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddRootNode;
        private System.Windows.Forms.Label lbWorkShop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddrUrl;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.TextBox txtProcessID;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Button btnChoose;
    }
}