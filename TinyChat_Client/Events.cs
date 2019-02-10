using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TinyChat_Client
{
    public delegate void CommandReceivedEventHandler(object sender, CommandEventArgs e);
    public delegate void CommandSentEventHandler(object sender, EventArgs e);
    public delegate void CommandSendingFailedEventHandler(object sender, EventArgs e);
    //server events
    public delegate void ServerDisconnectedEventHandler(object sender, ServerEventArgs e);
    //client events
    public delegate void DisconnectedEventHandler(object sender, EventArgs e);
    public delegate void ConnectingSuccessedEventHandler(object sender, EventArgs e);
    public delegate void ConnectingFailedEventHandler(object sender, EventArgs e);
    public delegate void NetworkDeadEventHandler(object sender, EventArgs e);
    public delegate void NetworkAlivedEventHandler(object sender, EventArgs e);

    //command event args
    public class CommandEventArgs : EventArgs
    {
        private Command c;

        public Command Command
        {
            get { return c; }
        }

        public CommandEventArgs(Command cmd)
        {
            c = cmd;
        }
    }

    //server event args
    public class ServerEventArgs : EventArgs
    {
        private Socket s;

        public IPAddress IP
        {
            get { return ((IPEndPoint)s.RemoteEndPoint).Address; }
        }

        public int Port
        {
            get { return ((IPEndPoint)s.RemoteEndPoint).Port; }
        }

        public ServerEventArgs(Socket cs)
        {
            s = cs;
        }
    }
}
