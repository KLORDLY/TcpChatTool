using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientApp
{
    public partial class  ClientForm : Form
    {
        private TcpClient tcpClient;

        private NetworkStream nsStream;

    
        private static string CLOSED = "closed";
        private static string CONNECTED = "connected";
        private string clientState = CLOSED;


        private bool StopFlag;

        public ClientForm()
        {
            InitializeComponent();
            this.tbServer.Text = Properties.Settings.Default.DestIpAddress;
        }


        //连接聊天室服务器
        private void btLogin_Click(object sender, EventArgs e)
        {
            if (clientState == CONNECTED)
            {
                return;
            }

            if (this.tbUserName.Text.Length == 0)
            {
                MessageBox.Show("请输入您的用户名", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tbUserName.Focus();
                return;
            }
            try
            {
                
                tcpClient = new TcpClient();
               
                tcpClient.Connect(IPAddress.Parse(tbServer.Text),
                    Int32.Parse(tbServerPort.Text));
               
                nsStream = tcpClient.GetStream();

               
                Thread newthread = new Thread(new ThreadStart(this.ServerResponse));
                newthread.Start();

               
                string cmd = "CONNECT|" + this.tbUserName.Text + "|";
               
                Byte[] bytes = System.Text.Encoding.Default.GetBytes(
                    cmd.ToCharArray());
                nsStream.Write(bytes, 0, bytes.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void ServerResponse()
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
           
            byte[] buff = new byte[1024];
            string msg;
            int len;
            try
            {
                if (!nsStream.CanRead)
                {
                    return;
                }

                StopFlag = false;
                while (!StopFlag)
                {
                 
                    len = nsStream.Read(buff, 0, buff.Length);

                    if (len < 1)
                    {
                        Thread.Sleep(200);
                        continue;
                    }

                    
                    msg = System.Text.Encoding.Default.GetString(buff, 0, len);
                    msg.Trim();

                    string[] acceptFromServer = msg.Split(new Char[] { '|' });
                 

                    if (acceptFromServer[0].ToUpper() == "OK")
                    {
                        //处理响应
                        Invoke(new addHandler(add), rbChatContent, "命令执行成功");
                    }
                    else if (acceptFromServer[0].ToUpper() == "ERROR")
                    {
                        //命令执行错误
                        Invoke(new addHandler(add), rbChatContent, "命令执行错误" + acceptFromServer[1]);
                    }
                    else if (acceptFromServer[0] == "LIST")
                    {
                        
                        Invoke(new addHandler(add), rbChatContent, "获得用户列表");

                        

                        lbUserList.Items.Clear();
                        for (int i = 1; i < acceptFromServer.Length - 1; i++)
                        {
                            lbUserList.Items.Add(acceptFromServer[i].Trim());
                        }
                    }
                    else if (acceptFromServer[0] == "JOIN")
                    {
                        
                        
                        Invoke(new addHandler(add), rbChatContent, acceptFromServer[1] + " " + "已经进入了聊天室");
                        this.lbUserList.Items.Add(acceptFromServer[1]);
                        if (this.tbUserName.Text == acceptFromServer[1])
                        {
                            this.clientState = CONNECTED;
                        }
                    }
                    else if (acceptFromServer[0] == "QUIT")
                    {
                        if (this.lbUserList.Items.IndexOf(acceptFromServer[1]) > -1)
                        {
                            this.lbUserList.Items.Remove(acceptFromServer[1]);
                        }
                        Invoke(new addHandler(add), rbChatContent, "用户" + acceptFromServer[1] + " 离开聊天室");
                    }
                    else
                    {
                        
                        
                        Invoke(new addHandler(add), rbChatContent, msg);
                    }
                }

                tcpClient.Close();
            }
            catch
            {
            }
        }

        delegate void addHandler(RichTextBox rb, string msg);

     

        private void add(RichTextBox rb, string msg)
        {

            rb.SelectedText = msg + "\n";
        }

        delegate void AddUserHandler(ListBox lb, string user);

        private void AddUser(ListBox lb, string user)
        {

        }

        /// <summary>
        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.cbPriChat.Checked)
                {
                    
                    
                    string message = "CHAT|" + this.tbUserName.Text + ":" +rbSendMsg.Text + "|";
                    rbSendMsg.Text = "";
                    rbSendMsg.Focus();
                    
                    Byte[] bytes = System.Text.Encoding.Default.GetBytes(
                        message.ToCharArray());
                    nsStream.Write(bytes, 0, bytes.Length);

                }
                else
                {
                    if (lbUserList.SelectedIndex == -1)
                    {
                        MessageBox.Show("请在列表中选择一个用户", "提示信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string receiver = lbUserList.SelectedItem.ToString();
                    
                    
                    string message = "PRIV|" + this.tbUserName.Text + "|" + receiver + "|" +
                        rbSendMsg.Text + "|";
                    rbSendMsg.Text = "";
                    rbSendMsg.Focus();
                    
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(
                        message.ToCharArray());
                    nsStream.Write(bytes, 0, bytes.Length);

                }
            }
            catch
            {
                this.rbChatContent.AppendText("网络发生错误或者服务器已经退出");
            }

        }
       /// <summary>

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btQuit_Click(object sender, EventArgs e)
        {
            if (clientState == CONNECTED)
            {
                string message = "EXIT|" + this.tbUserName.Text + "|";
                
                Byte[] bytes = System.Text.Encoding.Default.GetBytes( message.ToCharArray());
                nsStream.Write(bytes, 0, bytes.Length);

                this.clientState = CLOSED;
                this.StopFlag = true;
                this.lbUserList.Items.Clear();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btQuit_Click(sender, e);
        }

        

       

        
    }
}
