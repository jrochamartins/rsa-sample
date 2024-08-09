using System.Text;

namespace KeyGenerator
{
    internal class RSAEncryptor(CriptoProviderFactory factory)
    {
        private readonly CriptoProviderFactory factory = factory ?? throw new ArgumentNullException(nameof(factory));

        internal string Encrypt(
            string plainText
            //, string publicKey
            )
        {
            //factory.Instance.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
            var dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            var encryptedData = factory.Instance.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData);
        }
    }
}
