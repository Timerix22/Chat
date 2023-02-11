package chat.api;

import java.security.MessageDigest;

public class ClientConnectionInfo {
    short apiVersion;
    String publicKey;
    String[] encryptionAlgorithms;
    String[] hashAlgorithms;

    public ClientConnectionInfo(short apiVersion, String publicKey, String[] encryptionAlgorithms, String[] hashAlgorithms) {
        this.apiVersion=apiVersion;
        this.publicKey=publicKey;
        this.encryptionAlgorithms=encryptionAlgorithms;
        this.hashAlgorithms=hashAlgorithms;
    }

    @Override
    public String toString(){
        var b=new StringBuilder()
                .append("ClientConnectionInfo: {\n")
                .append("apiVersion: ").append(apiVersion)
                .append(";\npublicKey: ").append(publicKey)
                .append(";\nencryptionAlgorithms: ");
        StringBuilderExtended.appendArray(b,encryptionAlgorithms, ',')
                .append(";\nhashAlgorithms: ");
        StringBuilderExtended.appendArray(b,hashAlgorithms, ',')
                .append("\n}");
        return b.toString();
    }
}
