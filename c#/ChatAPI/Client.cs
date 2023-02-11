using System;
using System.Net;
using System.Net.Sockets;

namespace ChatAPI
{
    public class ServerInfo
    {
        public string name;
        public string? ip;
        public string? domain;
        public int port;
        public string publicKey;
        public bool isIP;

        public ServerInfo(string ipOrDomain, bool isIP, int port, string name, string publicKey)
        {
            this.isIP = isIP;
            if (isIP) ip = ipOrDomain;
            else domain = ipOrDomain;
            this.port = port;
            this.name = name;
            this.publicKey = publicKey;
        }
    }
    
    public class Client
    {
        private Socket? serverConnection;
        
        public void ConnectToServer(ServerInfo serverInfo)
        {
            if (serverConnection is not null && serverConnection.Connected)
            {
                serverConnection.Close();
            }
            serverConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverIP;
            if (serverInfo.isIP)
                serverIP = IPAddress.Parse(serverInfo.ip!);
            else serverIP = Dns.GetHostAddresses(serverInfo.domain!)[0];
            IPEndPoint serverEndpoint=new IPEndPoint(serverIP, serverInfo.port);
            serverConnection.Connect(serverEndpoint);
        }

        public void UpdateOnlineStatus(bool isOnline)
        {
            throw new NotImplementedException();
        }

        public ClientConnectionInfo[] GetOnlineClients()
        {
            throw new NotImplementedException();
        }

        public void ConnectToClient(ClientConnectionInfo clientInfo)
        {
            throw new NotImplementedException();
        }
    }

    public class ClientConnectionInfo
    {
        public string publicKey;
        public string[] encriprionAlgorithms;
        public string[] hashAlgorithms;

        public ClientConnectionInfo(string publicKey, string[] encriprionAlgorithms, string[] hashAlgorithms)
        {
            this.publicKey = publicKey;
            this.encriprionAlgorithms = encriprionAlgorithms;
            this.hashAlgorithms = hashAlgorithms;
        }
    }
}