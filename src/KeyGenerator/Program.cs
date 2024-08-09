using KeyGenerator;

using (var factory = new CriptoProviderFactory())
{
    //// Gerar chaves
    //var (PublicKey, PrivateKey) = new RSAKeyGenerator(factory).GenerateKeys();
    //string publicKey = PublicKey;
    //string privateKey = PrivateKey;

    // Mensagem a ser criptografada
    string originalMessage = "Hello, world!";
    Console.WriteLine("Original Message: " + originalMessage);

    // Criptografar mensagem
    string encryptedMessage = new RSAEncryptor(factory)
        .Encrypt(
            originalMessage
        //, publicKey
        );
    Console.WriteLine("Encrypted Message: " + encryptedMessage);

    // Descriptografar mensagem
    string decryptedMessage = new RSADecryptor(factory)
        .Decrypt(
            encryptedMessage
        //, privateKey
        );
    Console.WriteLine("Decrypted Message: " + decryptedMessage);
}