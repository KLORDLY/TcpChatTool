namespace ServeApp
{
    partial class ServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btStartServer = new System.Windows.Forms.Button();
            this.btStopServer = new System.Windows.Forms.Button();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.lbOnlineUser = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslOnlineUserNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbChatContent = new System.Windows.Forms.RichTextBox();
            this.lbUserList = new System.Windows.Forms.GroupBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.lbUserList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(237, 41);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(75, 23);
            this.btStartServer.TabIndex = 0;
            this.btStartServer.Text = "开启服务器";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Location = new System.Drawing.Point(360, 41);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(75, 23);
            this.btStopServer.TabIndex = 1;
            this.btStopServer.Text = "停止服务器";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.btStopServer_Click);
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(87, 49);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(100, 21);
            this.tbServerPort.TabIndex = 2;
            // 
            // lbOnlineUser
            // 
            this.lbOnlineUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOnlineUser.FormattingEnabled = true;
            this.lbOnlineUser.ItemHeight = 12;
            this.lbOnlineUser.Location = new System.Drawing.Point(3, 17);
            this.lbOnlineUser.Name = "lbOnlineUser";
            this.lbOnlineUser.Size = new System.Drawing.Size(145, 245);
            this.lbOnlineUser.TabIndex = 4;
            this.lbOnlineUser.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器端口";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(97, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslOnlineUserNum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tslOnlineUserNum
            // 
            this.tslOnlineUserNum.Name = "tslOnlineUserNum";
            this.tslOnlineUserNum.Size = new System.Drawing.Size(80, 17);
            this.tslOnlineUserNum.Text = "在线用户人数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbServerPort);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lbUserList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btStartServer);
            this.groupBox1.Controls.Add(this.btStopServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 379);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端监听";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbChatContent);
            this.groupBox3.Location = new System.Drawing.Point(177, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 260);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "聊天内容";
            // 
            // rbChatContent
            // 
            this.rbChatContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbChatContent.Location = new System.Drawing.Point(3, 17);
            this.rbChatContent.Name = "rbChatContent";
            this.rbChatContent.Size = new System.Drawing.Size(252, 240);
            this.rbChatContent.TabIndex = 0;
            this.rbChatContent.Text = "";
            // 
            // lbUserList
            // 
            this.lbUserList.Controls.Add(this.lbOnlineUser);
            this.lbUserList.Location = new System.Drawing.Point(6, 70);
            this.lbUserList.Name = "lbUserList";
            this.lbUserList.Size = new System.Drawing.Size(151, 265);
            this.lbUserList.TabIndex = 0;
            this.lbUserList.TabStop = false;
            this.lbUserList.Text = "在线用户列表";
            // 
            // frmServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 372);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServerMain";
            this.Text = "服务器";
            this.Load += new System.EventHandler(this.frmServerMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.lbUserList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.ListBox lbOnlineUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslOnlineUserNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox lbUserList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rbChatContent;
    }
}

