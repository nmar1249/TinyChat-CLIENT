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
using System.Runtime.InteropServices;


namespace TinyChat_Client
{
    internal enum FlashMode
    {
        CAPTION = 0x1 ,
        TRAY = 0x2 ,
        ALL = CAPTION | TRAY
    }

    internal struct FlashInfo
    {
        public int cd_size;
        public IntPtr hwnd;
        public int dw_flags;
        public int u_count;
        public int dw_timeout;
    }
    public partial class PrivateChatScreen : Form
    {
        private CommandClient targetClient;
        private IPAddress targetIP;
        private string targetName;
        private bool active;

        public string TargetName
        {
            get { return this.targetName; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                SendMessage();
            if (txtBox_PrivateMsg.Focused && !Utils.IsValidKeyForReadOnlyFields(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public PrivateChatScreen(CommandClient cClient, IPAddress ip, string name, string initMsg)
        {
            InitializeComponent();
            targetClient = cClient;
            targetIP = ip;
            targetName = name;
            Text += " With " + name;
            txtBox_PrivateMsg.Text = targetName + ": " + initMsg + Environment.NewLine;
            targetClient.received += new CommandReceivedEventHandler(privateCommandReceived);
        }
        public PrivateChatScreen(CommandClient cClient, IPAddress ip, string name)
        {
            InitializeComponent();
            targetClient = cClient;
            targetIP = ip;
            targetName = name;
            Text += " With " + name;
            targetClient.received += new CommandReceivedEventHandler(privateCommandReceived);
        }

        private void privateCommandReceived(object sender, CommandEventArgs e)
        {
            switch(e.Command.CommandType)
            {
                case (type.Message):
                    if(!e.Command.ToIP.Equals(IPAddress.Broadcast) && e.Command.FromIP.Equals(targetIP))
                    {
                        txtBox_PrivateMsg.Text += e.Command.SenderName + ": " + e.Command.Meta + Environment.NewLine;
                        if(!active)
                        {
                            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                                Utils.PlaySound(Utils.SoundType.NewMsg);
                            else
                                Utils.PlaySound(Utils.SoundType.NewMsgPow);
                            Flash(Handle, FlashMode.ALL, 3);
                        }
                    }
                    break;
            }
        }

        //DLL stuff
        [DllImport("user32.dll")]
        private static extern int FlashWindowEx(ref FlashInfo fi);
        private void Flash(IntPtr hwnd, FlashMode fm, int times)
        {
            unsafe
            {
                FlashInfo FI = new FlashInfo();
                FI.cd_size = sizeof(FlashInfo);
                FI.dw_flags = (int)fm;
                FI.dw_timeout = 0;
                FI.hwnd = hwnd;
                FI.u_count = times;
                FlashWindowEx(ref FI);
            }
        }

        //send a message to the target client
        private void SendMessage()
        {
            if(targetClient.Connected && txtBox_PrivateMsg.Text.Trim() != "")
            {
                targetClient.SendCommand(new Command(type.Message, targetIP, txtBox_PrivateMsg.Text));
                txtBox_PrivateChat.Text += targetClient.NetName + ": " + txtBox_PrivateMsg.Text.Trim() + Environment.NewLine;
                txtBox_PrivateMsg.Text = "";
                txtBox_PrivateMsg.Focus();
            }
        }
        private void PrivateChatScreen_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - DesktopBounds.Height);
        }
        private void PrivateChatScreen_Activated(object sender, EventArgs e)
        {
            active = true;
        }

        private void PrivateChatScreen_Deactivate(object sender, EventArgs e)
        {
            active = false;
        }

        private void submenu_Exit_Click(object sender, EventArgs e)
        {
            Close();
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
                Utils.SaveAsHTML(dialog.FileName, txtBox_PrivateChat.Lines, Text);
        }

        private void button_PrivateSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
    }
}
