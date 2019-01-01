using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;
using GameServer.Databases.Repositories;
using LitJson;

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

            UserRepository userRepository = new UserRepository();

            response.Parameters = new Dictionary<byte, object>();
            string json = JsonMapper.ToJson(userRepository.All());
            response.Parameters.Add(1, json);
        }
    }
}
