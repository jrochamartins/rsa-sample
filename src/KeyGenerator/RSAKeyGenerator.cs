namespace KeyGenerator
{
    internal class RSAKeyGenerator(CriptoProviderFactory factory)
    {
        private readonly CriptoProviderFactory factory = factory ?? throw new ArgumentNullException(nameof(factory));

        internal (string PublicKey, string PrivateKey) GenerateKeys()
        {
            var publicKey = Convert.ToBase64String(factory.Instance.ExportRSAPublicKey());
            var privateKey = Convert.ToBase64String(factory.Instance.ExportRSAPrivateKey());
            return (publicKey, privateKey);
        }
    }
}
