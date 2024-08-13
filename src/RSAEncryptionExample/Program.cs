using System.Security.Cryptography;
using System.Text;

namespace RSAEncryptionExample
{
    internal class Program
    {
        public static void Main()
        {
            //// Geração de um par de chaves RSA
            //using (var rsa = RSA.Create())
            //{
            //    //Exportar as chaves em formato PEM
            //    var privateKeyPem = ExportPrivateKeyToPem(rsa);
            //    var publicKeyPem = ExportPublicKeyToPem(rsa);
            //    //Mostrar as chaves (opcional)
            //    Console.WriteLine("Chave Privada:");
            //    Console.WriteLine(privateKeyPem);
            //    Console.WriteLine("Chave Pública:");
            //    Console.WriteLine(publicKeyPem);
            //}

            var privateKeyPem = @"MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC0xUQlUMH/Sw0SNkMHjNg+iP7xSGQEWc+nLfEVrZL0ktiomnRLsIQVdIE+ARtXxhwBpSpzBNsUZQDL8hk5eGzF6ozaTkCt7SrPWjXnR947u16uwg8dMB96dE07Jjz/jgyo/z+HPC/y56FMrUcbwXma9eQgMZ8efju3xauaFXTIzPJEE3H6zbzHqG8mJfFazmwmGq03NjOM8hf/8kxAkHW0HwobPqR3szOrVBfpAQWs6LyC67/XgDFhC2mh//WRkPoH7rOgRH1sPA06NlU1FPDjioNmBpJtOwynsE4vREBkMz9mtXIatK+UszRv8IfIzZcwT7FjyECBzYfjjGTBVL6fAgMBAAECggEACJUbDKh+ZWgDSVuRKCEcPS/U5tC4iupWrQnF2fEhOoJkTfDzV4qcYsZiwnZb/XlW6A8W6loPKrM26/flEbDxfR4LLOwtLvTFJQ4T5BSp7O0S7DojbI/V1sMBza6dk8aDPFzN/9YwMpijtFe/ugYgB2boO00P0GtO24VDhe/B2SypXwfgNOw6Tx+wtPs8/5poDtMEDCBqT3TsrsEB87AYe2Wf4HmlYnwuI4V3BFISW0Kz2FB2eECDPgWaCM6kQT3L4+ufuE1BCTotbOUmc0qsCbUhMQ8YF1CJgMAP3EW6ZdyN7vydZ3ZCq+FKd8Lgo+BZ3Pc1H8gn4Y04xELlMyt7qQKBgQDceMPe5Hn2ecUUsM7a3tpprBJul4EkTQ2S1B7dZpSpo2uGLacv3yuVYg4AJXCL9QQqkq50cmo5EsA+xog5ZXDJToXaA4vcsvvlERzhCVAEGpe8gMfKeWSt2RxTk9P91wNLTX3T/TqYHENqwexsSWtiseFazdEOeSHXTcz5PBYvJwKBgQDR5rAwAMbGz2PCEfS6rYgsqj1SpW2w2VuvSBJl3g1j3TAj3QLgp2AInFKDZdhpJ1R/QrH6lS1gteQnaMLjd/A2gb/DMsCpu/1BIAr8bIKK7aEgeliP46jjFQqm8lrvxmnu8/FH92k22NNP/Xc4Bro4VbLoS+UKUaP4iUUJ2qwfyQKBgFNuvCkAa4szv7o5wr4fMaZlwL/rQ6raIfXboiaE6GNd/ZXUdv1txg+NAOFbScEdIst9oNleZwZcKzZWaTzXP5xew9aiGu6VKTAhjr02ifpTmfJzBaiA0fHcRJT4T3QzRwLbO2/a166ym2yuIGtGSYYa7L4xPxjsDDtvLM9wxrBnAoGBAMihCbM4asdJH/82DogIqmqW5jqC6Q/rEpm99+fqkT3tA8Cj1cZJ9Z8FXFFAHdSUxU1GwLvVryQLd+K7XdzynWZcKqE3d7RFfdKsABQ626RTcnmKt/ABGULEsAPXD1i0fDjsbqntMGI+aezBRx0EQSbrszAaqvhsBKDhBF5g57kRAoGAODraPGSK6OQSs5Aro6b75PITiutTRL6+50tcppWILfFReWcDoXWQCqD6zquQ/HMfc6f0ZdqKKt8kT5XU7NEcOHD/pLBEzZsXR8rsk22untpr//6renEvBJvp3ufgJ/z19rmGzuOPqhhXOxE8Y8uUpYJIYRLsp9GEvwVtcJHT564=";
            //var publicKeyPem = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtMVEJVDB/0sNEjZDB4zYPoj+8UhkBFnPpy3xFa2S9JLYqJp0S7CEFXSBPgEbV8YcAaUqcwTbFGUAy/IZOXhsxeqM2k5Are0qz1o150feO7tersIPHTAfenRNOyY8/44MqP8/hzwv8uehTK1HG8F5mvXkIDGfHn47t8WrmhV0yMzyRBNx+s28x6hvJiXxWs5sJhqtNzYzjPIX//JMQJB1tB8KGz6kd7Mzq1QX6QEFrOi8guu/14AxYQtpof/1kZD6B+6zoER9bDwNOjZVNRTw44qDZgaSbTsMp7BOL0RAZDM/ZrVyGrSvlLM0b/CHyM2XME+xY8hAgc2H44xkwVS+nwIDAQAB";

            //Texto a ser criptografado
            //string textToEncrypt = "Teste";

            //Criptografar o texto com a chave pública
            //var encryptedData = Encrypt(textToEncrypt, publicKeyPem);

            //var encryptedText = Convert.ToBase64String(encryptedData);
            var encryptedText = "eXTtHb2ldBAQzRHb/34ccTt/eYeD1eUC9yBFI7sklMqucd3ZX+6aOVl9d15mXgrurOpIqGHZ91WRYEZTWFPOtXCKmxLo26TBZP+uif934kyrHZwAXq+r8ft3P6pLgi+gcLFUAm9Our/RsveMWdKmOGYNUkTyDC3tBA9NwMfqTfu4+AXkfhaG85TpHTxPVGeNpectxbWEDz48H85Akw3//7o7phPZYr/0/SARXb6OIwpTCi4gfOUxotrrvq+grZ6139ZNOMIhzUh6biJ/lWxhCz4Oh6QsxxSjAGiyzTgufH78ljC4CNOVJbuQPkL11zU9jLDAmdgiEZs9tqyOiGU0UQ==";

            // Descriptografar o texto com a chave privada            
            var decryptedText = Decrypt(encryptedText, privateKeyPem);

            //Console.WriteLine("Texto original: " + textToEncrypt);
            Console.WriteLine("Texto criptografado: " + encryptedText);
            Console.WriteLine("Texto descriptografado: " + decryptedText);
        }

        // Função para criptografar dados usando a chave pública
        public static byte[] Encrypt(string data, string publicKeyPem)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyPem);
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);

            using (var rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
                //rsa.ImportFromPem(publicKeyPem);
                return rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
            }
        }

        public static string Decrypt(string encryptedData, string privateKey)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKey);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        // Exportar a chave privada para o formato PEM
        private static string ExportPrivateKeyToPem(RSA rsa)
        {
            var privateKeyBytes = rsa.ExportPkcs8PrivateKey();
            return ConvertToPem("RSA PRIVATE KEY", privateKeyBytes);
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
