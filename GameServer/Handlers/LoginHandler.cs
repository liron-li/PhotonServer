using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;

namespace GameServer.Handlers
{
    class LoginHandler : HandlerBase
    {
        public override OperationCode OpCode
        {
            get { return OperationCode.Login; }
        }

        public override void OnHandlerMessage(OperationRequest request, OperationResponse response, Peer peer, SendParameters sendParameters)
        {
            
        }
    }
}
