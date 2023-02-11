namespace ChatAPI;

public interface IClient
{
    ILogger logger { get; }
    ClientConnectionInfo thisClientInfo { get; }
    List<ServerConnection> serverConnections { get; }
    void ConnectToServer(ServerConnectionInfo serverConnectionInfo);
    void UpdateOnlineStatus(bool isOnline);
    ClientConnectionInfo[] GetOnlineClients();
    void ConnectToClient(ClientConnectionInfo clientConnectionInfo);
}