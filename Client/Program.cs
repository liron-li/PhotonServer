using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Client.Photon;

namespace Client
{
    class GameServerListener : IPhotonPeerListener
    {
        public bool isConnected;

        public void DebugReturn(DebugLevel level, string message)
        {

        }

        public void OnEvent(EventData eventData)
        {

        }

        public void OnOperationResponse(OperationResponse operationResponse)
        {
            Dictionary<byte, object> dict = operationResponse.Parameters;
            object value = null;
            dict.TryGetValue(1, out value);
            Console.WriteLine(value);
        }

        public void OnStatusChanged(StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Connect:
                    this.isConnected = true;
                    Console.WriteLine("connected!");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameServerListener listener = new GameServerListener();

            PhotonPeer peer = new PhotonPeer(listener, ConnectionProtocol.Tcp);
            Console.WriteLine("connecting...");
            peer.Connect("127.0.0.1:4530", "GameServer");
            while (!listener.isConnected)
            {
                peer.Service();
            }

            Dictionary<byte, Object> dict = new Dictionary<byte, object>
            {
                { 1, "username" },
                { 2, "password" }
            };

            peer.OpCustom(1, dict, true);

            while (true)
            {
                peer.Service();
            }
        }
    }
}
