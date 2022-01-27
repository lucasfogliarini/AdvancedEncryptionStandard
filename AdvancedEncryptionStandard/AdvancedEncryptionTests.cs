using Xunit;
using System.Security.Cryptography;

namespace AdvancedEncryptionStandard
{
    public class AdvancedEncryptionTests
    {
        [Fact]
        public void Decrypt_GivenEncryptedBase64Text_ShouldReturnDecryptedText()
        {
            //arrange
            string plainText = "Encrypt my text!";
            var encryptedBase64Text = AdvancedEncryption.Encrypt(plainText);

            //act
            var decryptedText = AdvancedEncryption.Decrypt(encryptedBase64Text);

            //assert
            Assert.Equal(plainText, decryptedText);
        }
    }
}