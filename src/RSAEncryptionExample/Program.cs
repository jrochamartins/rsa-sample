using System.Security.Cryptography;
using System.Text;

namespace RSAEncryptionExample
{
    internal class Program
    {
        public static void Main()
        {
            // Geração de um par de chaves RSA
            using (var rsa = RSA.Create(2048))
            {
                // Exportar as chaves em formato PEM
                var privateKeyPem = ExportPrivateKeyToPem(rsa);
                var publicKeyPem = ExportPublicKeyToPem(rsa);

                // Mostrar as chaves (opcional)
                Console.WriteLine("Chave Privada:");
                Console.WriteLine(privateKeyPem);
                Console.WriteLine("Chave Pública:");
                Console.WriteLine(publicKeyPem);

                // Texto a ser criptografado
                string textToEncrypt = "Este é um texto confidencial.";
                Console.WriteLine("Texto original: " + textToEncrypt);

                // Criptografar o texto com a chave pública
                var encryptedData = Encrypt(textToEncrypt, publicKeyPem);
                Console.WriteLine("Texto criptografado: " + Convert.ToBase64String(encryptedData));

                // Descriptografar o texto com a chave privada
                var decryptedText = Decrypt(encryptedData, privateKeyPem);
                Console.WriteLine("Texto descriptografado: " + decryptedText);
            }
        }

        // Função para criptografar dados usando a chave pública
        public static byte[] Encrypt(string data, string publicKeyPem)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(publicKeyPem);
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
                return rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
            }
        }

        // Função para descriptografar dados usando a chave privada
        public static string Decrypt(byte[] data, string privateKeyPem)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(privateKeyPem);
                byte[] decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }

        // Exportar a chave privada para o formato PEM
        private static string ExportPrivateKeyToPem(RSA rsa)
        {
            var privateKeyBytes = rsa.ExportPkcs8PrivateKey();
            return ConvertToPem("PRIVATE KEY", privateKeyBytes);
        }

        // Exportar a chave pública para o formato PEM
        private static string ExportPublicKeyToPem(RSA rsa)
        {
            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            return ConvertToPem("PUBLIC KEY", publicKeyBytes);
        }

        // Converter bytes para o formato PEM
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
