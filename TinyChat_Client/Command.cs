using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TinyChat_Client
{
    //this class is used to generate a Command object that communicates to the server
    public class Command
    {
        private IPAddress fromIP;
        private IPAddress toIP;
        private type cmdType;
        private string body;
        private string senderName;

        public IPAddress FromIP
        {
            get { return fromIP; }
            set { fromIP = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public type CommandType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        public IPAddress ToIP
        {
            get { return toIP; }
            set { toIP = value; }
        }

        public string Meta
        {
            get { return body; }
            set { body = value; }
        }

        //creates an instance of the command object to send
        public Command(type t, IPAddress target, string meta)
        {
            cmdType = t;
            toIP = target;
            body = meta;
        }

        public Command(type t, IPAddress target)
        {
            cmdType = t;
            toIP = target;
            body = "";
        }
    }
}
