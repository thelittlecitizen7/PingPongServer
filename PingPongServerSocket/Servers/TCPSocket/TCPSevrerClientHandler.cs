using PingPongClientSocket;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace User2Chat.Servers.TCPSocket
{
    public class TCPSevrerClientHandler
    {
        public TcpClient client { get; set; }
        public TCPSevrerClientHandler(TcpClient clientTcp)
        {
            client = clientTcp;
        }


        public void Handler()
        {
            Thread thread = new Thread(Listener);
            thread.Start();
        }

        private void Listener()
        {

            while (true)
            {

                byte[] bytes = new Byte[1024];
                string data = null;
                try
                {
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    ConverterObject converterObject = new ConverterObject();
                    var person = converterObject.FromByteArray(buffer);


                    Console.WriteLine("Received : " + person.ToString()) ;


                    if (data == "exit")
                    {
                        CloseSocket();
                        break;
                    }

                    ConverterObject converterObject2 = new ConverterObject();
                    var sendBytes = converterObject2.ObjectToByteArray(person);

                    nwStream.Write(sendBytes, 0, sendBytes.Length);
                }
                catch (Exception e)
                {
                    CloseSocket();
                }
            }
        }

        private void CloseSocket()
        {
            client.Close();
        }

    }
}
