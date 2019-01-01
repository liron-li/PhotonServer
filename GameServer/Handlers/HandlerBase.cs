using ExitGames.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;

namespace GameServer.Handlers
{
    public abstract class HandlerBase
    {
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        public HandlerBase()
        {
            Server._Instance.handlers.Add((byte)OpCode, this);
            log.Debug("Hanlder:" + this.GetType().Name + "  is register.");
        }

        public abstract void OnHandlerMessage(OperationRequest request, OperationResponse response, Peer peer, SendParameters sendParameters);
        public abstract OperationCode OpCode { get; }
    }
}
