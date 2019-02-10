/* CommandClient
 *
 * This class handles commands from the client pov
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Windows.Forms;

namespace TinyChat_Client
{
    //this class contains the commands to be utilized by the Client for server communication
    public class CommandClient
    {

        /*variables*/
        private Socket client;
        private NetworkStream netStream;
        private BackgroundWorker receiver;
        private IPEndPoint endpoint;
        private string netName;

        public bool Connected
        {
            get
            {
                if (client != null)
                    return client.Connected;
                else
                    return false;
            }
        }

        public IPAddress serverIP
        {
            get
            {
                if (Connected)
                    return endpoint.Address;
                else
                    return IPAddress.None;
            }
        }

        public int ServerPort
        {
            get
            {
                if (Connected)
                    return endpoint.Port;
                else
                    return -1;
            }
        }

        public IPAddress ClientIP
        {
            get
            {
                if (Connected)
                    return ((IPEndPoint)client.LocalEndPoint).Address;
                else
                    return IPAddress.None;
            }
        }

        public int ClientPort
        {
            get
            {
                if (Connected)
                    return ((IPEndPoint)client.LocalEndPoint).Port;
                else
                    return -1;
            }
        }

        public string NetName
        {
            get { return netName; }
            set { netName = value; }
        }

        /*CONSTRUCTORS*/

        public CommandClient(IPEndPoint server, string name)
        {
            endpoint = server;
            netName = name;
            System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(availabilityChanged);
        }

        public CommandClient(IPAddress ip, int port, string name)
        {
            endpoint = new IPEndPoint(ip, port);
            netName = name;
            System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(availabilityChanged);
        }

        /*private methods*/

        //this method checks to see if the network is still available
        private void availabilityChanged(object sender, System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
        {
            if (!e.IsAvailable)
            {
                OnNetworkAlived(new EventArgs());
                OnDisconnectedFromServer(new EventArgs());
            }
            else
            {
                OnNetworkAlived(new EventArgs());
            }

        }

        private void StartReceive(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                //get command type
                byte[] buffer = new byte[4];
                int readBytes = netStream.Read(buffer, 0, 4);

                if (readBytes == 0)
                    break;

                type cmdType = (type)(BitConverter.ToInt32(buffer, 0));

                //get sender ip size
                buffer = new byte[4];
                readBytes = netStream.Read(buffer, 0, 4);

                if (readBytes == 0)
                    break;

                int senderIPSize = BitConverter.ToInt32(buffer, 0);

                //get sender ip
                buffer = new byte[senderIPSize];
                readBytes = netStream.Read(buffer, 0, senderIPSize);
                if (readBytes == 0)
                    break;
                IPAddress senderIP = IPAddress.Parse(Encoding.ASCII.GetString(buffer));

                //get sender name size
                buffer = new byte[4];
                readBytes = netStream.Read(buffer, 0, 4);

                if (readBytes == 0)
                    break;

                int senderNameSize = BitConverter.ToInt32(buffer, 0);

                //get sender name
                buffer = new byte[senderNameSize];
                readBytes = netStream.Read(buffer, 0, senderNameSize);

                if (readBytes == 0)
                    break;

                string senderName = Encoding.Unicode.GetString(buffer);

                //get target size
                string cmdTarget = "";
                buffer = new byte[4];
                readBytes = netStream.Read(buffer, 0, 4);

                if (readBytes == 0)
                    break;

                int ipSize = BitConverter.ToInt32(buffer, 0);

                //get target
                buffer = new byte[ipSize];
                readBytes = netStream.Read(buffer, 0, ipSize);

                if (readBytes == 0)
                    break;

                cmdTarget = Encoding.ASCII.GetString(buffer);

                //get metadata size
                string cmdMetaData = "";
                buffer = new byte[4];
                readBytes = netStream.Read(buffer, 0, 4);

                if (readBytes == 0)
                    break;

                int metaDataSize = BitConverter.ToInt32(buffer, 0);

                //get metadata
                buffer = new byte[metaDataSize];
                readBytes = netStream.Read(buffer, 0, metaDataSize);

                if (readBytes == 0)
                    break;

                cmdMetaData = Encoding.Unicode.GetString(buffer);

                Command cmd = new Command(cmdType, IPAddress.Parse(cmdTarget), cmdMetaData);
                cmd.ToIP = senderIP;
                cmd.SenderName = senderName;
                OnCommandReceived(new CommandEventArgs(cmd));
            }

            OnServerDisconnected(new ServerEventArgs(client));
            Disconnect();
        }

        private void sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && ((bool)e.Result))
                OnCommandSent(new EventArgs());
            else
                OnCommandFailed(new EventArgs());

            ((BackgroundWorker)sender).Dispose();
            GC.Collect();                               //pick up yer trash
        }

        private void sender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command c = (Command)e.Argument;
            e.Result = SendCommandToServer(c);
        }

        //using a semaphor to stop concurrent thread access
        Semaphore sem = new Semaphore(1, 1);

        private bool SendCommandToServer(Command c)
        {
            try
            {
                sem.WaitOne();
                if (c.Meta == null || c.Meta == "")
                    SetMetaData(c);

                //type
                byte[] buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)c.CommandType);
                netStream.Write(buffer, 0, 4);
                netStream.Flush();

                //target
                byte[] ipBuff = Encoding.ASCII.GetBytes(c.ToIP.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(ipBuff.Length);
                netStream.Write(buffer, 0, 4);
                netStream.Flush();
                netStream.Write(ipBuff, 0, ipBuff.Length);
                netStream.Flush();

                //metadata
                byte[] metaBuff = Encoding.Unicode.GetBytes(c.Meta);
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(metaBuff.Length);
                netStream.Write(buffer, 0, 4);
                netStream.Flush();
                netStream.Write(metaBuff, 0, metaBuff.Length);
                netStream.Flush();

                sem.Release();
                return true;
            }
            catch
            {
                sem.Release();
                return false;
            }
        }

        private void SetMetaData(Command c)
        {
            switch (c.CommandType)
            {
                case (type.ClientLogin):
                    c.Meta = ClientIP.ToString() + ":" + netName;
                    break;
                case (type.PCLockTimer):
                case (type.PCLogOFFTimer):
                case (type.PCRestartTimer):
                case (type.PCShutDownTimer):
                case (type.UserExitTimer):
                    c.Meta = "60000";
                    break;
                default:
                    c.Meta = "\n";
                    break;
            }
        }

        private void connector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!((bool)e.Result))
                OnConnectingFailed(new EventArgs());
            else
                OnConnectingSuccessed(new EventArgs());

            ((BackgroundWorker)sender).Dispose();
        }

        private void connector_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(endpoint);
                e.Result = true;
                netStream = new NetworkStream(client);
                receiver = new BackgroundWorker();
                receiver.WorkerSupportsCancellation = true;
                receiver.DoWork += new DoWorkEventHandler(StartReceive);
                receiver.RunWorkerAsync();

                //send a notification that this client has connnected
                Command massMsg = new Command(type.ClientLogin, IPAddress.Broadcast, ClientIP.ToString() + ":" + netName);
                SendCommand(massMsg);

            }
            catch
            {
                e.Result = false;
            }
        }
        /*******************
         * public methods
         *******************/
        public void Connect()
        {
            BackgroundWorker connector = new BackgroundWorker();
            connector.DoWork += new DoWorkEventHandler(connector_DoWork);
            connector.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connector_RunWorkerCompleted);
            connector.RunWorkerAsync();
        }

        //sends a command to the server if there is a connection
        public void SendCommand(Command c)
        {
            if (client != null && client.Connected)
            {
                BackgroundWorker sender = new BackgroundWorker();
                sender.DoWork += new DoWorkEventHandler(sender_DoWork);
                sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sender_RunWorkerCompleted);
                sender.WorkerSupportsCancellation = true;
                sender.RunWorkerAsync(c);
            }
            else
            {
                OnCommandFailed(new EventArgs());
            }
        }

        //disconnects the client from the server
        public bool Disconnect()
        {
            if (client != null && client.Connected)
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    receiver.CancelAsync();
                    OnDisconnectedFromServer(new EventArgs());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        /*events*/
        public event CommandReceivedEventHandler received;
        public event CommandSentEventHandler sent;
        public event CommandSendingFailedEventHandler failed;
        public event ServerDisconnectedEventHandler disconnected;
        public event DisconnectedEventHandler disconnectedServer;
        public event ConnectingSuccessedEventHandler successed;
        public event ConnectingFailedEventHandler c_failed;
        public event NetworkDeadEventHandler dead;
        public event NetworkAlivedEventHandler alive;

        protected virtual void OnCommandReceived(CommandEventArgs e)
        {
            if (received != null)
            {
                Control target = received.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(received, new object[] { this, e });
                else
                    received(this, e);
            }
        }

        protected virtual void OnCommandSent(EventArgs e)
        {
            if (sent != null)
            {
                Control target = sent.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(sent, new object[] { this, e });
                else
                    sent(this, e);
            }
        }

        protected virtual void OnCommandFailed(EventArgs e)
        {
            if (failed != null)
            {
                Control target = failed.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(failed, new object[] { this, e });
                else
                    failed(this, e);
            }
        }

        protected virtual void OnServerDisconnected(ServerEventArgs e)
        {
            if (disconnected != null)
            {
                Control target = disconnected.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(disconnected, new object[] { this, e });
                else
                    disconnected(this, e);
            }
        }
        protected virtual void OnDisconnectedFromServer(EventArgs e)
        {
            if (disconnectedServer != null)
            {
                Control target = disconnectedServer.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(disconnectedServer, new object[] { this, e });
                else
                    disconnectedServer(this, e);
            }
        }
        protected virtual void OnConnectingSuccessed(EventArgs e)
        {
            if (successed != null)
            {
                Control target = successed.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(successed, new object[] { this, e });
                else
                    successed(this, e);
            }
        }

        protected virtual void OnConnectingFailed(EventArgs e)
        {
            if (c_failed != null)
            {
                Control target = c_failed.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(c_failed, new object[] { this, e });
                else
                    c_failed(this, e);
            }
        }
        protected virtual void OnNetworkDead(EventArgs e)
        {
            if (dead != null)
            {
                Control target = dead.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(dead, new object[] { this, e });
                else
                    dead(this, e);
            }
        }
        protected virtual void OnNetworkAlived(EventArgs e)
        {
            if (alive != null)
            {
                Control target = alive.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(alive, new object[] { this, e });
                else
                    alive(this, e);
            }
        }

    }
}
