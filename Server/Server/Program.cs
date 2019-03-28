using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace MdinaARServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerHandlerNetworkData.InitialiseNetworkPackages();
            ServerTCP.SetupServer();
            Console.ReadLine();
        }
    }
}
