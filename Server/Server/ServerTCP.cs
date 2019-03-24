﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Bindings;
using Server;


namespace MdinaARServer
{
    class ServerTCP
    {
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] _buffer = new byte[1024];

        public static Client[] _clients = new Client[Constants.MAX_PLAYERS];

        public static void SetupServer()
        {
            for (int j = 0; j < Constants.MAX_PLAYERS; j++)
            {
                _clients[j] = new Client();
            }
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 6666));
            _serverSocket.Listen(10);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack),null );
        }

        private static void AcceptCallBack(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);

            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                if (_clients[i].socket == null)
                {
                    _clients[i].socket = socket;
                    _clients[i].index = i;
                    _clients[i].ip = socket.RemoteEndPoint.ToString();
                    _clients[i].StartClient();
                    Console.WriteLine("Connection from {0} recieved", _clients[i].ip);
                    SendConnectionOK(i);
                    return;
                }
            }
        }

        public static void SendDataTo(int index, byte[] data)
        {
            byte[] sizeinfo = new byte[4];
            sizeinfo[0] = (byte)data.Length;
            sizeinfo[1] = (byte)(data.Length >> 8);
            sizeinfo[2] = (byte)(data.Length >> 16);
            sizeinfo[3] = (byte)(data.Length >> 24);

            _clients[index].socket.Send(sizeinfo);
            _clients[index].socket.Send(data);

        }

        public static void SendConnectionOK(int index)
        {
            PacketBuffer buffer = new PacketBuffer();;
            buffer.WriteInteger((int)ServerPackets.SConnectionOk);
            buffer.WriteString("You are successfully connected to the server");
            SendDataTo(index, buffer.ToArray());
            buffer.Dispose();
        }
    }

    class Client
    {
        public int index;
        public string ip;
        public Socket socket;
        public bool closing = false;
        private byte[] _buffer = new byte[1024];

        public void StartClient()
        {
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallBack),socket );
            closing = false;
        }

        private void RecieveCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;

            try
            {
                int recieved = socket.EndReceive(ar);
                
                if (recieved <= 0)
                {
                    CloseClient(index);
                }
                else
                {
                    byte[] databuffer = new byte[recieved];
                    Array.Copy(_buffer, databuffer, recieved);

                    ServerHandlerNetworkData.HandleNetworkInformation(index, databuffer);
                    
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallBack), null);

                }
            }
            catch (Exception e)
            {

                CloseClient(index);
            }
        }

        private void CloseClient(int index)
        {
            closing = true;
            Console.WriteLine("Connection from {0} has been termineted.", ip);
            //Player left game
            socket.Close();
        }
    }
}
