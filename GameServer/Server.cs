using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using Photon.SocketServer;
using Common;
using GameServer.Handlers;

using LogManager = ExitGames.Logging.LogManager;
using System.Reflection;

namespace GameServer
{
    public class Server : ApplicationBase
    {
        private static Server _instance;

        public Server()
        {
            _instance = this;
            RegisteHandlers();
        }

        public static Server _Instance
        {
            get { return _instance; }
        }

        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        public Dictionary<byte, HandlerBase> handlers = new Dictionary<byte, HandlerBase>();


        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new Peer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        protected override void Setup()
        {
            LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            GlobalContext.Properties["LogFileName"] = "MS_" + this.ApplicationName;
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(this.BinaryPath, "log4net.config")));

            log.Debug("GameServer is runing");
        }

        protected override void TearDown()
        {
            log.Debug("GameServer is stop");
        }

        void RegisteHandlers()
        {
            Type[] types = Assembly.GetAssembly(typeof(HandlerBase)).GetTypes();
            foreach (var type in types)
            {
                if (type.FullName.EndsWith("Handler"))
                {
                    Activator.CreateInstance(type);
                }
            }

        }
    }
}
