using System.IO;
using System.Text;

namespace System.Security.Cryptography
{
    /// <summary>
    /// Provides a implementation of the Advanced Encryption Standard (AES) symmetric algorithm.
    /// </summary>
    public class AdvancedEncryption
    {
        static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");//must have 32 characteres
        static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");//must have 16 characteres

        /// <summary>
        /// Encrypt a plain text to a base64 text using <see cref="Aes"/>
        /// </summary>
        /// <returns>An encrypted base64 text</returns>
        public static string Encrypt(string plainText)
        {
            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using MemoryStream ms = new();
                using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
                using (StreamWriter sw = new(cs))
                    sw.Write(plainText);
                encrypted = ms.ToArray();
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decrypt a base64 text to a plain text using <see cref="Aes"/>
        /// </summary>
        /// <returns>A decrypted plain text</returns>
        public static string Decrypt(string encryptedBase64)
        {
            var encrypted = Convert.FromBase64String(encryptedBase64);
            string? decryptedPlainText = null;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);

                using MemoryStream ms = new(encrypted);
                using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
                using StreamReader reader = new(cs);
                decryptedPlainText = reader.ReadToEnd();
            }
            return decryptedPlainText;
        }
    }
}
