package chat.api;

import chat.api.logging.ILogger;

import java.io.IOException;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.util.Collection;

public class ServerConnection {

    public ServerConnectionInfo serverConnectionInfo;
    ILogger logger;
    private ClientConnectionInfo clientConnectionInfo;
    private Socket serverSocket;

    public ServerConnection(ILogger logger, ServerConnectionInfo serverConnectionInfo, ClientConnectionInfo clientConnectionInfo) throws Exception {
        this.logger = logger;
        this.serverConnectionInfo = serverConnectionInfo;
        this.clientConnectionInfo = clientConnectionInfo;
    }

    public void connect(int timeOutMilliseconds) throws Exception {
        // closes socket if already connected
        disconnect();

        InetAddress address = InetAddress.getByName(serverConnectionInfo.ipOrDomain);
        SocketAddress serverEndpoint = new InetSocketAddress(address, serverConnectionInfo.port);
        serverSocket = new Socket();
        try{
            serverSocket.connect(serverEndpoint, timeOutMilliseconds);
        }
        catch (IOException ioex) {
            disconnect();
            throw new Exception("can't connect to server "+serverConnectionInfo, ioex);
        }
    }

    public void disconnect() throws IOException {
        if (serverSocket == null)
            return;
        serverSocket.close();
    }

    public void updateOnlineStatus(boolean isOnline) throws Exception {
        throw new Exception();
    }

    public Collection<ClientConnectionInfo> getOnlineClients() throws Exception {
        throw new Exception();
    }
}
