using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description = "AES �t��k")]
    public class UtAESProvider
    {
        AESProvider aesCrypt;

        [SetUp]
        public void InitialAesInstance()
        {
            aesCrypt = new AESProvider();
        }

        [Test]
        public void AESConstructor_���ҬO�_����AES����è��oKEY_IV()
        {
            //Arrange�G��l��

            string key, iv = null;

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            key = aesCrypt.Key;
            iv = aesCrypt.IV;

            ConsoleWrite.ConsoleWriteInfo($"AES Key�G{key}");
            ConsoleWrite.ConsoleWriteInfo($"AES IV�G{iv}");

            //Assert�G����
            Assert.IsNotNull(aesCrypt);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAESEncode_TestCase))]
        public void Eecrypt_���X_����AES�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��

            string encrtyptText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            encrtyptText = aesCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{aesCrypt.Key}\nIV�G{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAES_IVisNull_Encode_TestCase))]
        public void Eecrypt_���XIVisNULL_����AES�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��

            string encrtyptText = "";
            aesCrypt.SetKey(aesCrypt.Key, null);
            //Act�G�����k�B�欰�B�ާ@�è��o���G
            encrtyptText = aesCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{aesCrypt.Key}\nIV�G{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAESDecode_TestCase))]
        public void Decrypt_�K��_����AES�ѱK(string encryptText, string expPlainText)
        {
            //Arrange�G��l��

            string plainText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G 
            plainText = aesCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"��J�K��G{encryptText}\nKey�G{aesCrypt.Key}\nIV�G{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�ѱK����G{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"�������G{expPlainText}");

            //Assert�G����
            Assert.AreEqual(expPlainText, plainText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAES_IVisNull_Decode_TestCase))]
        public void Decrypt_�K��IVisNull_����AES�ѱK(string encryptText, string expPlainText)
        {
            //Arrange�G��l��

            string plainText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G 
            aesCrypt.SetKey(aesCrypt.Key, null);
            plainText = aesCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"��J�K��G{encryptText}\nKey�G{aesCrypt.Key}\nIV�G{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�ѱK����G{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"�������G{expPlainText}");

            //Assert�G����
            Assert.AreEqual(expPlainText, plainText);
        }
    }
}