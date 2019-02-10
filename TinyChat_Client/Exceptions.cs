using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat_Client
{
    //exception to throw when the remote server isnt found
    public class ServerNotFoundException : Exception
    {
        public ServerNotFoundException(string message) : base(message) { }

    }
}
