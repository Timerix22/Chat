namespace ChatAPI;

/// contains all information needed to connect to a server
public class ServerConnectionInfo
{
    /// server name
    public string name;
    /// server address
    public string ipOrDomain;
    /// server port
    public int port;
    /// server's public RSA encryption key
    public string publicKey;

    public ServerConnectionInfo(string ipOrDomain, int port, string name, string publicKey)
    {
        this.ipOrDomain = ipOrDomain;
        this.port = port;
        this.name = name;
        this.publicKey = publicKey;
    }

    public override string ToString() => $"\"{name}\" {ipOrDomain}:{port}";
}