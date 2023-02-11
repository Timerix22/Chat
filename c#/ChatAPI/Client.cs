global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using DTLib.Extensions;
global using DTLib.Filesystem;

namespace ChatAPI
{
    public class Client : IClient
    {
        public ILogger logger { get; }
        public ClientConnectionInfo thisClientInfo { get; }
        public List<ServerConnection> serverConnections { get; } = new();


        public Client(ILogger logger)
        {
            this.logger = logger;
            thisClientInfo = new ClientConnectionInfo(
                0,
                "",
                new string[]{ },
                new string[]{ });
        }

        public void ConnectToServer(ServerConnectionInfo serverConnectionInfo)
        {
            var serverConnection = new ServerConnection(logger, serverConnectionInfo, thisClientInfo);
            serverConnections.Add(serverConnection);
        }

        public void UpdateOnlineStatus(bool isOnline)
        {
            foreach (ServerConnection connection in serverConnections) 
                connection.UpdateOnlineStatus(isOnline);
        }

        public ClientConnectionInfo[] GetOnlineClients()
        {
            List<ClientConnectionInfo> clients=new List<ClientConnectionInfo>();
            foreach (var connection in serverConnections)
            {
                clients.AddRange(connection.GetOnlineClients());
            }
            return clients.ToArray();
        }

        public void ConnectToClient(ClientConnectionInfo clientConnectionInfo)
        {
            throw new NotImplementedException();
        }
    }
}