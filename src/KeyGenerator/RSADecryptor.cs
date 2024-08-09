using System.Security.Cryptography;
using System.Text;

namespace KeyGenerator
{
    internal class RSADecryptor
    {
        internal static string Decrypt(string encryptedText, string privateKey)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
            byte[] decryptedData;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
