package chat.api;

public class ServerConnectionInfo {
    public String name;
    public String ipOrDomain;
    public int port;
    public String publicKey;

    public ServerConnectionInfo(String name, String ipOrDomain, int port, String publicKey) {
        this.name = name;
        this.ipOrDomain = ipOrDomain;
        this.port = port;
        this.publicKey = publicKey;
    }

    @Override
    public String toString(){
        return "\""+name+"\" "+ipOrDomain+':'+port;
    }
}
