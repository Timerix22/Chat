using ChatAPI;
using System.Net;
using System.Net.Sockets;

var config = new ServerConfig("172.16.0.210", 100);
Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
listeningSocket.Bind(
    new IPEndPoint(IPAddress.Parse(config.localAddress), 
        config.port));
listeningSocket.Listen();

while (true)
{
    var clientSocket = listeningSocket.Accept();
    Console.WriteLine("client connected");
}

public class ServerConfig
{
    public string localAddress;
    public int port;

    public ServerConfig(string localAddress, int port)
    {
        this.port = port;
        this.localAddress = localAddress;
    }
}
