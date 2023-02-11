using ChatAPI;
using System.Net;
using System.Net.Sockets;

var config = new ServerConfig("127.0.0.1", 100);
Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
listeningSocket.Bind(
    new IPEndPoint(IPAddress.Parse(config.localAddress), 
        config.port));
listeningSocket.Listen();

while (true)
{
    var clientSocket = listeningSocket.Accept();
    Console.WriteLine("client connected");
    IPEndPoint clientEndpoint = (IPEndPoint)clientSocket.RemoteEndPoint!;
    Console.WriteLine($"client endpoint: {clientEndpoint.Address}:{clientEndpoint.Port}");
}
