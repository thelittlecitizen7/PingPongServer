using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace User2Chat
{
    public class Server : IServer
    {
        public Socket listener { get; set; }

        public IPEndPoint localEndPoint { get; set; }
        public int Port { get ; set ; }

        public Server(int port)
        {
            Port = port;
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddr, Port);

            listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Listen()
        {
            try
            {
                listener.Bind(localEndPoint);

                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");

                    Socket clientSocket = listener.Accept();

                    SocketClientHandler socketClientHandler = new SocketClientHandler();
                    socketClientHandler.Handler(clientSocket);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void Close()
        {
            listener.Close();
        }
    }
}
