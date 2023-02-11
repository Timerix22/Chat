package chat.api;

import jdk.jshell.spi.ExecutionControl;

import java.io.IOException;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;

public class Client {

    private Socket serverConnectionsocket;
    String privateKey;
    String publicKey;
    Socket socket = new Socket();


    public void updateOnlineStatus(boolean isOnline) throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Exception");
    }

    public  ClientConnectionInfo[] clientConnectionInfos() throws Exception {
        throw  new ExecutionControl.NotImplementedException("Exception");
    }

    public void connectToClient(ClientConnectionInfo clientConnectionInfo) throws ExecutionControl.NotImplementedException {
        throw  new ExecutionControl.NotImplementedException("Exception");
    }

    public void connectToServer(ServerInfo serverInfo) throws IOException {
        if (serverConnectionsocket != null && serverConnectionsocket.isConnected()){
            serverConnectionsocket.close();
        }
        serverConnectionsocket = new Socket();

        InetAddress address = InetAddress.getByName(serverInfo.ipOrDomain);
        SocketAddress endpoint = new InetSocketAddress(address,serverInfo.port);
        serverConnectionsocket.connect(endpoint,2000);
    }

    public static void main(String[] args) {
        ServerInfo serverInfo =new ServerInfo("172.16.0.210",100,"Name","");
        Client client = new Client();
        try {
            client.connectToServer(serverInfo);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
