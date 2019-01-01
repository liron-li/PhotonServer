using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Peer : PeerBase
    {
        public Peer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer) : base(protocol, unmanagedPeer)
        {

        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>
            {
                {1, "gameServer1"}
            };

            OperationResponse reponse = new OperationResponse(1, dict);
            this.SendOperationResponse(reponse, sendParameters);
        }
    }
}
