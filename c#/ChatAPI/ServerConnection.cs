using System.Net;
using System.Net.Sockets;

namespace ChatAPI;

// handles connection to a server
public class ServerConnection
{
    public ILogger logger { get; }
    private ClientConnectionInfo clientConnectionInfo { get; }
    public ServerConnectionInfo serverConnectionInfo { get; }
    
    private Socket? serverSocket;

    public ServerConnection(ILogger logger, ServerConnectionInfo serverConnectionInfo, ClientConnectionInfo clientConnectionInfo)
    {
        this.logger = logger;
        this.serverConnectionInfo = serverConnectionInfo;
        this.clientConnectionInfo = clientConnectionInfo;
    }

    public void Connect(int timeoutMiliseconds)
    {
        Disconnect();
        DnsEndPoint serverEndpoint = new DnsEndPoint(serverConnectionInfo.ipOrDomain, serverConnectionInfo.port);
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var rezult = serverSocket.BeginConnect(serverEndpoint, null,null);
        rezult.AsyncWaitHandle.WaitOne(timeoutMiliseconds, true);
        if(serverSocket.Connected)
            serverSocket.EndConnect(rezult);
        else
        {
            Disconnect();
            throw new Exception($"can't connect to server {serverConnectionInfo}");
        }
    }

    public void Disconnect()
    {
        if (serverSocket == null) 
            return;
        UpdateOnlineStatus(false);
        serverSocket.Close();
        serverSocket = null;
    }
    
    public void UpdateOnlineStatus(bool isOnline)
    {
        throw new NotImplementedException();
    }

    public ClientConnectionInfo[] GetOnlineClients()
    {
        throw new NotImplementedException();
    }
}
