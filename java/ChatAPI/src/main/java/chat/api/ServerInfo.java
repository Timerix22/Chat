package chat.api;

import java.io.IOException;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;

public class ServerInfo implements Runnable {



    int port;
    String ipOrDomain;

    String publicKey;
    String name;

    public ServerInfo(String ipOrDomain, int port,String name,String publicKey) {
        this.ipOrDomain = ipOrDomain;
        this.port = port;
        this.name = name;
        this.publicKey = publicKey;

    }

    @Override
    public void run() {

    }
}
