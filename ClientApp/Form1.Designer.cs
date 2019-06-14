namespace ClientApp
{
    partial class ClientForm
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
            this.客户端 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btQuit = new System.Windows.Forms.Button();
            this.cbPriChat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUserList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbChatContent = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbSendMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // 客户端
            // 
            this.客户端.AutoSize = true;
            this.客户端.Location = new System.Drawing.Point(14, 37);
            this.客户端.Name = "客户端";
            this.客户端.Size = new System.Drawing.Size(41, 12);
            this.客户端.TabIndex = 1;
            this.客户端.Text = "客户端";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "用户名";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(61, 34);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(100, 21);
            this.tbServer.TabIndex = 2;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(202, 33);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(100, 21);
            this.tbServerPort.TabIndex = 2;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(367, 33);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 2;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(489, 32);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "登陆";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(508, 359);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(62, 23);
            this.btSend.TabIndex = 5;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btQuit
            // 
            this.btQuit.Location = new System.Drawing.Point(621, 359);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(62, 23);
            this.btQuit.TabIndex = 6;
            this.btQuit.Text = "离开";
            this.btQuit.UseVisualStyleBackColor = true;
            this.btQuit.Click += new System.EventHandler(this.btQuit_Click);
            // 
            // cbPriChat
            // 
            this.cbPriChat.AutoSize = true;
            this.cbPriChat.Location = new System.Drawing.Point(227, 362);
            this.cbPriChat.Name = "cbPriChat";
            this.cbPriChat.Size = new System.Drawing.Size(48, 16);
            this.cbPriChat.TabIndex = 9;
            this.cbPriChat.Text = "私聊";
            this.cbPriChat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbUserList);
            this.groupBox1.Location = new System.Drawing.Point(2, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 362);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线用户列表";
            // 
            // lbUserList
            // 
            this.lbUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUserList.FormattingEnabled = true;
            this.lbUserList.ItemHeight = 12;
            this.lbUserList.Location = new System.Drawing.Point(3, 17);
            this.lbUserList.Name = "lbUserList";
            this.lbUserList.Size = new System.Drawing.Size(118, 342);
            this.lbUserList.TabIndex = 4;
            this.lbUserList.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btLogin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbServerPort);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbUserName);
            this.groupBox2.Controls.Add(this.tbServer);
            this.groupBox2.Controls.Add(this.客户端);
            this.groupBox2.Location = new System.Drawing.Point(132, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 81);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录服务器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbChatContent);
            this.groupBox3.Location = new System.Drawing.Point(132, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 101);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "聊天内容";
            // 
            // rbChatContent
            // 
            this.rbChatContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbChatContent.Location = new System.Drawing.Point(3, 17);
            this.rbChatContent.Name = "rbChatContent";
            this.rbChatContent.Size = new System.Drawing.Size(578, 81);
            this.rbChatContent.TabIndex = 0;
            this.rbChatContent.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbSendMsg);
            this.groupBox4.Location = new System.Drawing.Point(145, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(558, 91);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送信息";
            // 
            // rbSendMsg
            // 
            this.rbSendMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSendMsg.Location = new System.Drawing.Point(3, 17);
            this.rbSendMsg.Name = "rbSendMsg";
            this.rbSendMsg.Size = new System.Drawing.Size(552, 71);
            this.rbSendMsg.TabIndex = 1;
            this.rbSendMsg.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 403);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbPriChat);
            this.Controls.Add(this.btQuit);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "客户端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 客户端;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btQuit;
        private System.Windows.Forms.CheckBox cbPriChat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbUserList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rbChatContent;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rbSendMsg;
    }
}

