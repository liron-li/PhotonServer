using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;

namespace GameServer
{
    public class Server : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new Peer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        protected override void Setup()
        {

        }

        protected override void TearDown()
        {

        }
    }
}
