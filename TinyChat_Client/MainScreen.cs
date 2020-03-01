using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace TinyChat_Client
{
    public partial class FormMain : Form
    {
        private CommandClient client;
        private List<PrivateChatScreen> chatList;

        public FormMain()
        {
            InitializeComponent();
            chatList = new List<PrivateChatScreen>();
            client = new CommandClient(IPAddress.Parse("0.0.0.0"), 8000, "None");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                SendMessage();
            if (txtBox_Chatroom.Focused && !Utils.IsValidKeyForReadOnlyFields(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool IsPrivateWindowOpened(string remoteName)
        {
            foreach (PrivateChatScreen privateChat in chatList)
                if (privateChat.TargetName == remoteName)
                    return true;
            return false;
        }

        private PrivateChatScreen FindPrivateChat(string remoteName)
        {
            foreach (PrivateChatScreen privateChat in chatList)
                if (privateChat.TargetName == remoteName)
                    return privateChat;
            return null;
        }

        void clientCommandReceived(object sender, CommandEventArgs e)
        {
            switch(e.Command.CommandType)
            {
                case (type.Message):
                    if (e.Command.ToIP.Equals(IPAddress.Broadcast))
                        txtBox_Chatroom.Text += e.Command.SenderName + ": " + e.Command.Meta + Environment.NewLine;
                    else if(!IsPrivateWindowOpened(e.Command.SenderName))
                    {
                        OpenPrivateWindow(e.Command.FromIP, e.Command.SenderName, e.Command.Meta);
                        Utils.PlaySound(Utils.SoundType.NewMsgPow);
                    }
                    break;
                case (type.test):
                    string[] newInfo = e.Command.Meta.Split(new char[] { ':' });
                    AddToList(newInfo[0], newInfo[1]);
                    Utils.PlaySound(Utils.SoundType.NewClient);
                    break;
                case (type.SendClientList):
                    string[] clientInfo = e.Command.Meta.Split(new char[] { ':' });
                    AddToList(clientInfo[0], clientInfo[1]);
                    break;
                case (type.ClientLogoff):
                    RemoveFromList(e.Command.SenderName);
                    break;
            }
        }
        //sends message to the chatroom
        private void SendMessage()
        {
            if(client.Connected && txtBox_MessageToSend.Text.Trim() != "")
            {
                client.SendCommand(new Command(type.Message, IPAddress.Broadcast, txtBox_MessageToSend.Text));
                txtBox_Chatroom.Text += client.NetName + ": " + txtBox_MessageToSend.Text.Trim() + Environment.NewLine;
                txtBox_MessageToSend.Text = "";
                txtBox_MessageToSend.Focus();
            }
        }

        private void AddToList(string ip, string name)
        {
            ListViewItem newItem = listView_Users.Items.Add(name);
            newItem.ImageKey = "Smiley.png";
            newItem.SubItems.Add(name);
        }

        private void RemoveFromList(string name)
        {
            ListViewItem item = listView_Users.FindItemWithText(name);
            if(item.Text != client.ClientIP.ToString())
            {
                listView_Users.Items.Remove(item);
                Utils.PlaySound(Utils.SoundType.Exit);
            }

            //close any private chats that might be upon on clients' screens
            PrivateChatScreen target = FindPrivateChat(name);
            if (target != null)
                target.Close();
        }
        private void OpenPrivateWindow(IPAddress remoteClientIP, string clientName)
        {
            if(client.Connected)
            {
                if(!IsPrivateWindowOpened(clientName))
                {
                    PrivateChatScreen privateWindow = new PrivateChatScreen(client, remoteClientIP, clientName);
                    chatList.Add(privateWindow);
                    privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_formClosed);
                    privateWindow.StartPosition = FormStartPosition.CenterParent;
                    privateWindow.Show(this);
                }
            }
        }

        private void OpenPrivateWindow(IPAddress remoteClientIP, string clientName, string initMsg)
        {
            if (client.Connected)
            {

                PrivateChatScreen privateWindow = new PrivateChatScreen(client, remoteClientIP, clientName, initMsg);
                chatList.Add(privateWindow);
                privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_formClosed);
                privateWindow.Show(this);
            }
        }

        void privateWindow_formClosed(object sender, FormClosedEventArgs e)
        {
            chatList.Remove((PrivateChatScreen)sender);
        }
        private void submenu_Login_Click(object sender, EventArgs e)
        {
            if(submenu_Login.Text == "Login")
            {
                LoginScreen login = new LoginScreen(IPAddress.Parse("127.0.0.1"), 8000);
                login.ShowDialog();
                client = login.Client;

                if(client.Connected)
                {
                    client.received += new CommandReceivedEventHandler(clientCommandReceived);
                    client.SendCommand(new Command(type.test, IPAddress.Broadcast, client.ClientIP + ":" + client.NetName));
                    client.SendCommand(new Command(type.SendClientList, client.serverIP));
                    AddToList(client.ClientIP.ToString(), client.NetName);
                    submenu_Login.Text = "Log Off";
                }
            }
            else
            {
                submenu_Login.Text = "Login";
                chatList.Clear();
                client.Disconnect();
                listView_Users.Items.Clear();
                txtBox_MessageToSend.Clear();
                txtBox_MessageToSend.Focus();
            }
        }

        private void submenu_PrivateChat_Click(object sender, EventArgs e)
        {
            StartPrivateChat();
        }

        private void StartPrivateChat()
        {
            if (listView_Users.SelectedItems.Count != 0)
                OpenPrivateWindow(IPAddress.Parse(listView_Users.SelectedItems[0].Text), listView_Users.SelectedItems[0].SubItems[1].Text);
        }
        private void submenu_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML Files(*.HTML;*.HTM)|*.html;*.htm";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;
            dialog.CheckPathExists = true;
            dialog.OverwritePrompt = true;
            dialog.FileName = Text;

            if (dialog.ShowDialog() == DialogResult.OK)
                Utils.SaveAsHTML(dialog.FileName, txtBox_Chatroom.Lines, Text);
        }

        private void submenu_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void button_PrivateChat_Click(object sender, EventArgs e)
        {
            StartPrivateChat();
        }

        private void txtBox_Chatroom_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView_Users_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
