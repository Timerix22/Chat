package chat.api;

import chat.api.logging.ILogger;

class ClientTest {
    static Client client;
    static ILogger logger;

    @org.junit.jupiter.api.BeforeAll
    static void init(){
        logger=new ExampleLogger();
        client = new Client(logger);
    }

    @org.junit.jupiter.api.Test
    void connectToServer() {
        ServerConnectionInfo serverConnectionInfo =new ServerConnectionInfo(
                "test",
                "172.16.0.210",
                100,
                "");
        try {
            client.connectToServer(serverConnectionInfo, 2000);
        } catch (Exception e) {
            logger.logError(e);
        }
    }

    @org.junit.jupiter.api.Test
    void updateOnlineStatus() {
        try {
//            client.updateOnlineStatus(true);
//            client.updateOnlineStatus(false);
//            client.updateOnlineStatus(true);
        } catch (Exception e) {
            logger.logError(e);
        }
    }

    @org.junit.jupiter.api.Test
    void getOnlineClients() {
        try {
//            client.getOnlineClients();
        } catch (Exception e) {
            logger.logError(e);
        }
    }

    @org.junit.jupiter.api.Test
    void connectToClient() {
        try {
//            client.connectToClient();
        } catch (Exception e) {
            logger.logError(e);
        }
    }
}