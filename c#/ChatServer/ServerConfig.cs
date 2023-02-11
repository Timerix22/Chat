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