global using  DTLib.Filesystem;
using ChatAPI;

namespace ChatCLI;

public static class Program
{
    
    public static Config config = Config.Default;

    public static void Main(string[] args)
    {
        var apiLogger = new Logger("ChatAPI");
        Client client = new Client(apiLogger);
        client.ConnectToServer(new ServerConnectionInfo("127.0.0.1", 100, "localhost", ""));
    }
}