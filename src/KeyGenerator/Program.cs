using KeyGenerator;

// Gerar chaves
var (PublicKey, PrivateKey) = RSAKeyGenerator.GenerateKeys();
string publicKey = PublicKey;
string privateKey = PrivateKey;

// Mensagem a ser criptografada
string originalMessage = "Hello, world!";
Console.WriteLine("Original Message: " + originalMessage);

// Criptografar mensagem
string encryptedMessage = RSAEncryptor.Encrypt(originalMessage, publicKey);
Console.WriteLine("Encrypted Message: " + encryptedMessage);

// Descriptografar mensagem
string decryptedMessage = RSADecryptor.Decrypt(encryptedMessage, privateKey);
Console.WriteLine("Decrypted Message: " + decryptedMessage);