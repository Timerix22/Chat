using System;
using System.IO;
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
        Connect();
    }

    /// <summary>
    /// Tries connect to server several times
    /// </summary>
    /// <param name="connectionAttemtps">how many times </param>
    private void Connect(int connectionAttemtps=5)
    {
        Disconnect();
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        DnsEndPoint serverEndpoint = new DnsEndPoint(serverConnectionInfo.ipOrDomain, serverConnectionInfo.port);
        while (connectionAttemtps-- > 0 || serverSocket.Connected)
            try
            { 
                serverSocket.Connect(serverEndpoint);
            }
            catch (SocketException se)
            {
                logger.LogWarn(se);
            }

        if (!serverSocket.Connected)
            throw new Exception($"can't connect to server {serverConnectionInfo}");
    }

    public void Disconnect()
    {
        if (serverSocket != null && serverSocket.Connected)
        {
            UpdateOnlineStatus(false);
            serverSocket.Close();
            serverSocket = null;
        }
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
