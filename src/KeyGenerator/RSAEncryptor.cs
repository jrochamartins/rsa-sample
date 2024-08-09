using System.Security.Cryptography;
using System.Text;

namespace KeyGenerator
{
    internal class RSAEncryptor
    {
        internal static string Encrypt(string plainText, string publicKey)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return Convert.ToBase64String(encryptedData);
        }
    }
}
