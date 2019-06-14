using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ServeApp
{
    public partial class ServerForm : Form
    {
        internal static Hashtable clients = new Hashtable();

        //该服务器默认的监听器
        private TcpListener listener;

        //默认最大支持的客户端连接数
        static int MAXUSER = 100;

        //服务器是否开启的标志
        internal static bool ServerFlag = false;

        //public NetworkStream stream;

        public ServerForm()
        {
            InitializeComponent();
        }
        public delegate void AppendMsgEventHandler(RichTextBox rb, string msg);//定义在线程中操作不同线程创建的控件的委托
        public delegate void AppendUserEventHandler(ListBox lb, string username);

        //开启服务器

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btStartServer_Click(object sender, EventArgs e)  //获取本机IP和指定端口号，启动StartListen进行监听
        {
            int iPort = this.returnValidPort(tbServerPort.Text.Trim());
            if (iPort < 0)
            {
                MessageBox.Show("错误的端口信息", "错误提示");
                return;
            }

            string ip = this.returnIpAddress();

            try
            {
                IPAddress userIP = IPAddress.Parse(ip);

                //创建服务器套接字
                listener = new TcpListener(userIP, iPort);  //端口号不合法时会抛异常
                listener.Start();

                this.rbChatContent.AppendText("服务器已经启动,正在监听" + ip + "端口号：" + tbServerPort.Text + "..........\n");

                ServerForm.ServerFlag = true;

                Thread thread = new Thread(StartListen);
                thread.Start();

                btStartServer.Enabled = false;
                btStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                this.rbChatContent.AppendText(ex.Message + "\n");
            }
        }
        private void StartListen()
        {
            while (ServerForm.ServerFlag)
            {
                try
                {

                    if (listener.Pending())
                    {
                        //Socket newSocket = listener.AcceptSocket();
                        TcpClient client = listener.AcceptTcpClient();
                        if (clients.Count >= MAXUSER)
                        {
                            MessageBox.Show("连接数已经超过允许连接的最大数" + MAXUSER.ToString() + ",拒绝新的连接", "错误提示");
                            this.rbChatContent.AppendText("连接数已经超过允许连接的最大数" + MAXUSER.ToString() + "拒绝新的连接");
                            //newSocket.Close();

                            client.Close();
                        }
                        else
                        {

                            //ChatClient newClient = new ChatClient(this, newSocket);
                            ChatClient newClient = new ChatClient(this, client);
                            Thread ClientThread = new Thread(newClient.ClientService);
                            ClientThread.Start();

                        }
                    }
                    Thread.Sleep(200);
                }
                catch (Exception ex)
                {

                    this.UpdateMsg(ex.Message);
                }
            }
        }
        private int returnValidPort(string strPort)
        {
            int port;

            try
            {
                if (tbServerPort.Text == "")
                {
                    throw new ArgumentException("端口号为空,不能启动服务器");
                }
                else
                {
                    port = Convert.ToInt32(tbServerPort.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                this.rbChatContent.AppendText("无效的端口号：" + ex.Message + "\n");
                return -1;
            }
            return port;
        }

        private string returnIpAddress()
        {
            IPAddress[] AddressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            if (AddressList.Length < 1)
            {
                return "";
            }
            return AddressList[6].ToString();
        }

        public void UpdateMsg(string msg)
        {
            Invoke(new AppendMsgEventHandler(AppendMsgEvent), rbChatContent, msg + "\n");
        }
        /// <summary>
        /// 添加用户更新界面
        /// </summary>
        /// <param name="name"></param>
        public void AddUser(string name)
        {
            string str = name + "已经加入聊天\n";
            Invoke(new AppendMsgEventHandler(AppendMsgEvent), rbChatContent, str);  //AppendMsgEvent(rbChatContent, name +"已经加入聊天\n);
            //将刚加入的用户添加进用户列表

            Invoke(new AppendUserEventHandler(AppendUserEvent), lbOnlineUser, name);

            this.tslOnlineUserNum.Text = Convert.ToString(clients.Count);
        }

        public void AppendMsgEvent(RichTextBox rb, string msg)
        {
            rb.AppendText(msg);
        }
        public void AppendUserEvent(ListBox lb, string username)
        {
            lb.Items.Add(username);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public string GetUserList()
        {
            string userList = "";
            for (int i = 0; i < lbOnlineUser.Items.Count; i++)
            {
                userList = userList + lbOnlineUser.Items[i].ToString() + "|";
            }
            return userList;
        }

        /// <summary>
        /// 移出用户
        /// </summary>
        /// <param name="name"></param>
        public void RemoveUser(string name)
        {
            this.rbChatContent.AppendText(name + " 已经离开聊天室\n");
            //将刚连接的用户名加入到当前在线用户列表中
            this.lbOnlineUser.Items.Remove(name);
            this.tslOnlineUserNum.Text = System.Convert.ToString(clients.Count);
        }

        private void btStopServer_Click(object sender, EventArgs e)
        {
            ServerForm.ServerFlag = false;
            btStartServer.Enabled = true;
            btStopServer.Enabled = false;

            UpdateMsg("服务器已经停止监听\n");

        }
        //关闭窗体
        private void frmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerForm.ServerFlag = false;
        }

        private void tbServerPort_TextChanged(object sender, EventArgs e)
        {
            this.btStartServer.Enabled = (this.tbServerPort.Text != "");
        }

        private void frmServerMain_Load(object sender, EventArgs e)
        {

        }
        public class ChatClient
        {
            private string name;
            //private Socket currentSocket = null;
            private TcpClient currentClient = null;
            private ServerForm server;
            private string ipAddress;

            //保留当前连接的状态
            //CLOSED-->CONNECTED-->CLOSED

            string connState = "closed";

            //public ChatClient(ServerForm server, Socket currentSocket)
            public ChatClient(ServerForm server, TcpClient currentClient)
            {
                this.server = server;
                //this.currentSocket = currentSocket;
                this.currentClient = currentClient;

            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            //public Socket CurrentSocket
            //{
            //    get { return currentSocket; }
            //    set { currentSocket = value; }
            //}
            public TcpClient CurrentClient
            {
                get { return currentClient; }
                set { currentClient = value; }
            }

            public string IpAddress
            {
                get { return ipAddress; }
            }
            //获取远程IP地址
            private string getRemoteIp()
            {
                //return ((IPEndPoint)currentSocket.RemoteEndPoint).Address.ToString();
                return ((IPEndPoint)currentClient.Client.RemoteEndPoint).Address.ToString();  //
            }

            //和客户端进行数据通信包括接收客户端的请求
            //根据同的请求命令执行相应的操作并将操作结果返回给客户端
            public void ClientService()
            {
                string[] acceptStr = null;//保存消息字符
                byte[] buff = new byte[1024];//缓冲区
                bool keepConnected = true;
                NetworkStream stream = currentClient.GetStream();

                //用循环不断地与客户端进行交互,直到其发出EXIT或者QUIT命令
                //将keepConnected设置为false,退出循环关闭当前连接,中止当前线程
                while (keepConnected && ServerForm.ServerFlag)
                {
                    acceptStr = null;
                    try
                    {
                        //if (currentSocket == null || currentSocket.Available < 1)
                        if (currentClient == null || currentClient.Available < 1)
                        {
                            Thread.Sleep(300);
                            continue;
                        }


                        //接收信息存入buff数组中
                        //int length = currentSocket.Receive(buff);
                        int length = stream.Read(buff, 0, 1024);


                        string Command = Encoding.Default.GetString(buff, 0, length);


                        acceptStr = Command.Split(new char[] { '|' });

                        if (acceptStr == null)
                        {
                            Thread.Sleep(200);
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        server.UpdateMsg("程序发生异常,异常信息:" + ex.Message);
                    }
                    if (acceptStr[0] == "CONNECT")
                    {

                        this.name = acceptStr[1];

                        if (ServerForm.clients.Contains(this.name))
                        {
                            SendToClient(this, "ERORR|User" + this.name + "已经存在");
                        }
                        else
                        {
                            Hashtable synClients = Hashtable.Synchronized(ServerForm.clients);
                            synClients.Add(this.name, this);

                            server.AddUser(this.name);


                            IEnumerator myIEnumerator = ServerForm.clients.Values.GetEnumerator();
                            while (myIEnumerator.MoveNext())
                            {
                                ChatClient cClient = (ChatClient)myIEnumerator.Current;
                                SendToClient(cClient, "JOIN|" + this.name + "|");
                                Thread.Sleep(100);
                            }


                            connState = "connected";
                            SendToClient(this, "OK");


                            string msgUsers = "LIST|" + server.GetUserList();
                            SendToClient(this, msgUsers);
                        }
                    }
                    else if (acceptStr[0] == "LIST")
                    {
                        if (connState == "CONNECTED")
                        {

                            string msgUsers = "LIST|" + server.GetUserList();
                            SendToClient(this, msgUsers);
                        }
                        else
                        {
                            SendToClient(this, "ERROR|服务器未连接,请重新登录");
                        }
                    }
                    else if (acceptStr[0] == "CHAT")
                    {
                        if (connState == "connected")
                        {

                            IEnumerator myEnumerator = ServerForm.clients.Values.GetEnumerator();
                            while (myEnumerator.MoveNext())
                            {
                                ChatClient client = (ChatClient)myEnumerator.Current;

                                SendToClient(client, acceptStr[1]);
                            }
                            server.UpdateMsg(acceptStr[1]);
                        }
                        else
                        {

                            SendToClient(this, "ERROR|服务器未连接,请重新登录");
                        }
                    }
                    else if (acceptStr[0] == "PRIV")
                    {
                        if (connState == "connected")
                        {

                            string sender = acceptStr[1];

                            string receiver = acceptStr[2];

                            string content = acceptStr[3];
                            string message = sender + " ---> " + receiver + ":  " + content;


                            if (ServerForm.clients.Contains(sender))
                            {
                                SendToClient(
                                    (ChatClient)ServerForm.clients[sender], message);
                            }
                            if (ServerForm.clients.Contains(receiver))
                            {
                                SendToClient(
                                    (ChatClient)ServerForm.clients[receiver], message);
                            }
                            server.UpdateMsg(message);
                        }
                        else
                        {

                            SendToClient(this, "ERROR|服务器未连接,请重新登录");
                        }
                    }
                    else if (acceptStr[0] == "EXIT")
                    {

                        if (ServerForm.clients.Contains(acceptStr[1]))
                        {
                            ChatClient client = (ChatClient)ServerForm.clients[acceptStr[1]];


                            Hashtable syncClients = Hashtable.Synchronized(
                                ServerForm.clients);
                            syncClients.Remove(client.name);
                            server.RemoveUser(client.name);


                            string message = "QUIT|" + acceptStr[1];

                            System.Collections.IEnumerator myEnumerator =
                                ServerForm.clients.Values.GetEnumerator();
                            while (myEnumerator.MoveNext())
                            {
                                ChatClient newClient = (ChatClient)myEnumerator.Current;
                                SendToClient(newClient, message);
                            }
                            server.UpdateMsg("QUIT");
                        }


                        break;
                    }
                    Thread.Sleep(200);
                }
            }

            private void SendToClient(ChatClient client, string msg)
            {
                Byte[] message = System.Text.Encoding.Default.GetBytes(msg.ToCharArray());
                NetworkStream stream = client.CurrentClient.GetStream();
                //client.CurrentSocket.Send(message, message.Length, 0);
                stream.Write(message, 0, message.Length);

            }

        }
    }
}
