using Bindings;
using System;
using System.Net.Sockets;

namespace Client
{
    class ClientTCP
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] _asycbuffer = new byte[1024];

        public static void ConnectToServer()
        {
            Console.WriteLine("Connect to server");
            _clientSocket.BeginConnect("127.0.0.1", 6666, new AsyncCallback(ConnectCallBack), _clientSocket);
        }

        private static void ConnectCallBack(IAsyncResult ar)
        {
            _clientSocket.EndConnect(ar);
            while (true)
            {
                OnRecieve();
            }
        }

        private static void OnRecieve()
        {
            byte[] _sizeinfo = new byte[4];
            byte[] _recievedbuffer = new byte[1024];

            int totalread = 0, 
                currentread = 0;

            try
            {
                currentread = totalread = _clientSocket.Receive(_sizeinfo);

                if (totalread <= 0)
                {
                    Console.WriteLine("You are not connected to the server  ");
                }
                else
                {
                    while (totalread < _sizeinfo.Length && currentread > 0)
                    {
                        currentread = _clientSocket.Receive(_sizeinfo, totalread, _sizeinfo.Length - totalread, SocketFlags.None);
                        totalread += currentread;
                    }

                    int messagesize = 0;
                    messagesize |= _sizeinfo[0];
                    messagesize |= (_sizeinfo[1] << 8);
                    messagesize |= (_sizeinfo[2] << 16);
                    messagesize |= (_sizeinfo[3] << 24);

                    byte[] data = new byte[messagesize];

                    totalread = 0;
                    currentread = totalread = _clientSocket.Receive(data, totalread, data.Length - totalread, SocketFlags.None);
                    while (totalread < messagesize && currentread > 0)
                    {
                        currentread = _clientSocket.Receive(data, totalread, data.Length - totalread, SocketFlags.None);
                        totalread += currentread;
                    }

                    ClientHandlerNetworkData.HandleNetworkInformation(data);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void SendData(byte[] data)
        {
            _clientSocket.Send(data);
        }

        public static void ThankYouServer()
        {
            PacketBuffer buffer = new PacketBuffer();;
            buffer.WriteInteger((int)ClientPackets.CThankyou);
            buffer.WriteString("Thanks for connecting to server");
            SendData(buffer.ToArray());
            buffer.Dispose();
        }
    }
}
