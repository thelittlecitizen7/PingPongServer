using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User2Chat.Servers.TCPSocket;

namespace User2Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = int.Parse(args[0]);
            IServer server = new TCPServerSocket(port);
            server.Listen();
        }
    }
}
