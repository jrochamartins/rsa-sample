using System.Text;

namespace KeyGenerator
{
    internal class RSADecryptor(CriptoProviderFactory factory)
    {
        private readonly CriptoProviderFactory factory = factory ?? throw new ArgumentNullException(nameof(factory));

        internal string Decrypt(
            string encryptedText
            //, string privateKey
            )
        {
            //factory.Instance.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
            var dataToDecrypt = Convert.FromBase64String(encryptedText);
            var decryptedData = factory.Instance.Decrypt(dataToDecrypt, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
