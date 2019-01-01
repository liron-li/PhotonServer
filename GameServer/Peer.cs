using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Handlers;
using ExitGames.Logging;

namespace GameServer
{
    public class Peer : PeerBase
    {
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        public Peer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer) : base(protocol, unmanagedPeer)
        {

        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            HandlerBase handler;
            Server._Instance.handlers.TryGetValue(operationRequest.OperationCode, out handler);

            OperationResponse response = new OperationResponse();
            response.OperationCode = operationRequest.OperationCode;
            response.Parameters = new Dictionary<byte, object>();

            if (handler != null)
            {
                handler.OnHandlerMessage(operationRequest, response, this, sendParameters);
                SendOperationResponse(response, sendParameters);
            } else
            {
                log.Debug("Can't find handler from operation code : " + operationRequest.OperationCode);
            }
        }
    }
}
