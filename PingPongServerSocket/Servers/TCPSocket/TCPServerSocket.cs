using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace User2Chat.Servers.TCPSocket
{
    public class TCPServerSocket : IServer
    {
        public TcpListener Listener { get; set; }
        public int Port { get ; set ; }

        public TCPServerSocket(int port)
        {
            Port = port;
            Listener = new TcpListener(Port);
        }

        public void Close()
        {
            Listener.Stop();
        }

        public void Listen()
        {
            try
            {
                Listener.Start();
                Console.WriteLine("Server Start listen");
                while (true)
                {

                    TcpClient client = Listener.AcceptTcpClient();

                    TCPSevrerClientHandler socketHandler = new TCPSevrerClientHandler(client);
                    socketHandler.Handler();
                }
            }
            catch (Exception e) 
            {
                Listener.Stop();
            }
        }
    }
}
