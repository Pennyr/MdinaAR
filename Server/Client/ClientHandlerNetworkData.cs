using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bindings;

namespace Client
{
    class ClientHandlerNetworkData
    {
        
        private delegate void Packet_(byte[]data);
        private static Dictionary<int, Packet_> Packets;

        public static void InitialiseNetworkPackages()
        {
            Console.WriteLine("Initialise network packages");
            Packets = new Dictionary<int, Packet_>
            {
                {(int)ServerPackets.SConnectionOk, HandleConnectionOK}
            };
        }

        public static void HandleNetworkInformation(byte[] data)
        {
            int packetnum; PacketBuffer buffer = new PacketBuffer();
            buffer.WriteBytes(data);
            packetnum = buffer.ReadInteger();
            buffer.Dispose();
            if (Packets.TryGetValue(packetnum, out Packet_ Packet))
            {
                Packet.Invoke(data);
            }
        }
        private static void HandleConnectionOK(byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteBytes(data);
            buffer.ReadInteger();
            string msg = buffer.ReadString();
            buffer.Dispose();

            //CODE HERE
            Console.WriteLine(msg);

            ClientTCP.ThankYouServer();
        }
    }
}
