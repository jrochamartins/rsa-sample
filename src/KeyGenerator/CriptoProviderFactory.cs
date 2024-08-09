using System.Security.Cryptography;

namespace KeyGenerator
{
    internal class CriptoProviderFactory : IDisposable
    {
        public RSACryptoServiceProvider Instance { get; } = new(2048);

        public void Dispose() => Instance.Dispose();
    }
}
