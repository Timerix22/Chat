namespace ChatAPI;

/// contains all information needed to connect to a client
public class ClientConnectionInfo
{
    /// version of ChatAPI implemented on the client
    public short apiVersion;
    /// client's public RSA encryption key
    public string publicKey;
    /// encryption algorithms implemented on the client
    public string[] encryptionAlgorithms;
    /// hash algorithms implemented on the client
    public string[] hashAlgorithms;

    public ClientConnectionInfo(short apiVersion, string publicKey, string[] encryptionAlgorithms, string[] hashAlgorithms)
    {
        this.apiVersion = apiVersion;
        this.publicKey = publicKey;
        this.encryptionAlgorithms = encryptionAlgorithms;
        this.hashAlgorithms = hashAlgorithms;
    }

    public override string ToString() =>
        new StringBuilder()
            .Append("ClientConnectionInfo: {\n")
            .Append("apiVersion: ").Append(apiVersion)
            .Append(";\npublicKey: ").Append(publicKey)
            .Append(";\nencryptionAlgorithms: ").Append(encryptionAlgorithms.MergeToString(','))
            .Append(";\nhashAlgorithms: ").Append(hashAlgorithms.MergeToString(','))
            .Append("\n}").ToString();
}