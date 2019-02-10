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
    public partial class LoginScreen : Form
    {
        private bool canExit;
        private CommandClient client;

        public CommandClient Client
        {
            get { return client; }
        }
        public LoginScreen(IPAddress ip, int port)
        {
            InitializeComponent();
            canExit = false;
            CheckForIllegalCrossThreadCalls = false;
            client = new CommandClient(ip, port, "none");
            client.received += new CommandReceivedEventHandler(CommandReceived);
            client.successed += new ConnectingSuccessedEventHandler(client_ConnectingSuccess);
            client.c_failed += new ConnectingFailedEventHandler(client_ConnectingFailed);
            
        }
        
        private void client_ConnectingFailed(object sender, EventArgs e)
        {
            MessageBox.Show("Server is not online!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetEnability(true);
        }

        private void client_ConnectingSuccess(object sender, EventArgs e)
        {
            client.SendCommand(new Command(type.IsNameExists, client.ClientIP, client.NetName));
        }

        void CommandReceived(object sender, CommandEventArgs e)
        {
            //check to see if the specific username exists
            if(e.Command.CommandType == type.IsNameExists)
            {
                if(e.Command.Meta.ToLower() == "true")
                {
                    MessageBox.Show("This username is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    canExit = true;
                    Close();
                }
            }
        }

        private void EnterServer()
        {
            if(txtbox_Username.Text.Trim() == "")
            {
                MessageBox.Show("A username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                client.NetName = txtbox_Username.Text.Trim();
                client.Connect();
            }
        }

        private void SetEnability(bool enable)
        {
            button_Enter.Enabled = enable;
            button_Quit.Enabled = enable;
            txtbox_Username.Enabled = enable;
        }
        private void button_Enter_Click(object sender, EventArgs e)
        {
            SetEnability(false);
            EnterServer();
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            canExit = true;
            Close();
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canExit)
                e.Cancel = true;
            else
                client.received -= new CommandReceivedEventHandler(CommandReceived);
        }
    }
}
