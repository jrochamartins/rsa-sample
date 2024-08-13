using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GenerateCertsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var rsa = RSA.Create(4096))
            {
                // Criar a solicitação de certificado X.509
                var req = new CertificateRequest("CN=ExampleCertificate", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                // Auto-assinar o certificado (válido por 1 ano)
                var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));
                
                // Exportar a chave privada em formato PEM
                var privateKeyPem = ExportPrivateKeyToPem(rsa);
                Console.WriteLine("Chave Privada:");
                Console.WriteLine(privateKeyPem);

                // Exportar a chave pública em formato PEM
                var publicKeyPem = ExportPublicKeyToPem(cert);
                Console.WriteLine("Chave Pública:");
                Console.WriteLine(publicKeyPem);

                //// Opcional: salvar as chaves em arquivos
                //System.IO.File.WriteAllText("privateKey.pem", privateKeyPem);
                //System.IO.File.WriteAllText("publicKey.pem", publicKeyPem);
            }
        }

        private static string ExportPrivateKeyToPem(RSA rsa)
        {
            var privateKeyBytes = rsa.ExportPkcs8PrivateKey();
            return ConvertToPem("PRIVATE KEY", privateKeyBytes);
        }

        private static string ExportPublicKeyToPem(X509Certificate2 cert)
        {
            var rsa = cert.GetRSAPublicKey();
            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            return ConvertToPem("PUBLIC KEY", publicKeyBytes);
        }

        private static string ConvertToPem(string label, byte[] data)
        {
            var base64 = Convert.ToBase64String(data);
            var sb = new StringBuilder();
            sb.AppendLine($"-----BEGIN {label}-----");

            for (int i = 0; i < base64.Length; i += 64)
            {
                sb.AppendLine(base64.Substring(i, Math.Min(64, base64.Length - i)));
            }

            sb.AppendLine($"-----END {label}-----");
            return sb.ToString();
        }
    }
}
