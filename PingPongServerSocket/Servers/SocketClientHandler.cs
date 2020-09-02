using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace User2Chat
{
    public class SocketClientHandler
    {
        public Socket ClientSocket { get; set; }
        public int Port { get; set ; }

        public SocketClientHandler()
        {
        }

        public void Handler(Socket clientSocket)
        {
            ClientSocket = clientSocket;
            Thread thread = new Thread(Listen);
            thread.Start();
        }


        public void Listen()
        {

            while (true)
            {
    
                byte[] bytes = new Byte[1024];
                string data = null;
                try
                {
                    int numByte = ClientSocket.Receive(bytes);

                    data = Encoding.ASCII.GetString(bytes, 0, numByte);
                    Console.WriteLine($"Recive from client : {data}");

                    if (data == "exit")
                    {
                        CloseSocket();
                        break;
                    }
                    ClientSocket.Send(Encoding.ASCII.GetBytes(data));
                }
                catch (Exception e) 
                {
                    CloseSocket();
                }
            }
            
        }

        public void CloseSocket() 
        {
            ClientSocket.Close();
        }
    }
}
