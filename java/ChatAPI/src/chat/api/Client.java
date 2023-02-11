package chat.api;

import chat.api.logging.ILogger;

import java.util.ArrayList;
import java.util.List;

public class Client {
    ILogger logger;
    String privateKey;
    String publicKey;
    public ClientConnectionInfo thisClientInfo;
    public List<ServerConnection> serverConnections=new ArrayList<>();

    public Client(ILogger _logger){
        logger=_logger;
        thisClientInfo = new ClientConnectionInfo(
                (short) 0,
                "",
                new String[]{ },
                new String[]{ });
        logger.logInfo("client initialized");
    }

    public void connectToServer(ServerConnectionInfo serverConnectionInfo, int timeOutMilliseconds) throws Exception {
        var serverConnection=new ServerConnection(logger,serverConnectionInfo,thisClientInfo);
        serverConnection.connect(timeOutMilliseconds);
    }

    public void updateOnlineStatus(boolean isOnline) throws Exception {
        for (var server : serverConnections)
            server.updateOnlineStatus(isOnline);
    }

    public  ClientConnectionInfo[] getOnlineClients() throws Exception {
        List<ClientConnectionInfo> clients = new ArrayList<>();
        for (var connection : serverConnections)
            clients.addAll(connection.getOnlineClients());
        ClientConnectionInfo[] array = new ClientConnectionInfo[clients.size()];
        return clients.toArray(array);
    }

    public void connectToClient(ClientConnectionInfo clientConnectionInfo) throws Exception {
        throw new Exception();
    }
}
