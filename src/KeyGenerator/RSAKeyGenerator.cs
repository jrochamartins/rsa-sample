using System.Security.Cryptography;

namespace KeyGenerator
{
    internal class RSAKeyGenerator
    {
        internal static (string PublicKey, string PrivateKey) GenerateKeys()
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            return (publicKey, privateKey);
        }
    }
}
