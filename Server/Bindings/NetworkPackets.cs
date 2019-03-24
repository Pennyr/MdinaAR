using System;
using System.Collections.Generic;
using System.Text;

namespace Bindings
{
  // get send from servedr to client
  //  client has to listen to serverpackets
   public enum ServerPackets
   {
    SConnectionOk =1,
   }

    // get send from client to server
    // server has to listen to clientpackets
   public enum ClientPackets
   {
        CThankyou =1,
   }
}
