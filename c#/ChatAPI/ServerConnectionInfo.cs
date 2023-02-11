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

    public ServerConnectionInfo(string name, string ipOrDomain, int port, string publicKey)
    {
        this.name = name;
        this.ipOrDomain = ipOrDomain;
        this.port = port;
        this.publicKey = publicKey;
    }

    public override string ToString() => $"\"{name}\" {ipOrDomain}:{port}";
}