using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description = "DES �t��k")]
    public class UtDESProvider
    {
        private DESProvider desCrypt;

        [SetUp]
        public void InitialDesInstinace()
        {
            desCrypt = new DESProvider();
        }

        [Test]
        public void UtDESProvider_���ҬO�_����DES����è��oKEY_IV()
        {
            //Arrange�G��l��
            string key, iv = null;

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            key = desCrypt.Key;
            iv = desCrypt.IV;

            ConsoleWrite.ConsoleWriteInfo($"DES Key�G{key}");
            ConsoleWrite.ConsoleWriteInfo($"DES IV�G{iv}");

            //Assert�G����
            Assert.IsNotNull(desCrypt);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDESEncode_TestCase))]
        public void Eecrypt_���X_����DES�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��
            string encrtyptText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            encrtyptText = desCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{desCrypt.Key}\nIV�G{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDES_IVisNull_Encode_TestCase))]
        public void Eecrypt_���XIVisNull_����DES�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��
            string encrtyptText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            desCrypt.SetKey(desCrypt.Key, null);
            encrtyptText = desCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{desCrypt.Key}\nIV�G{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }



        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDESDecode_TestCase))]
        public void Decrypt_�K��_����DES�ѱK(string encryptText, string expPlainText)
        {
            //Arrange�G��l��
            string plainText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            plainText = desCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"��J�K��G{encryptText}\nKey�G{desCrypt.Key}\nIV�G{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�ѱK����G{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"�������G{expPlainText}");

            //Assert�G����
            Assert.AreEqual(expPlainText, plainText);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDES_IVisNull_Decode_TestCase))]
        public void Decrypt_�K��IVisNull_����DES�ѱK(string encryptText, string expPlainText)
        {
            //Arrange�G��l��
            string plainText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            desCrypt.SetKey(desCrypt.Key, null);
            plainText = desCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"��J�K��G{encryptText}\nKey�G{desCrypt.Key}\nIV�G{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�ѱK����G{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"�������G{expPlainText}");

            //Assert�G����
            Assert.AreEqual(expPlainText, plainText);
        }

    }
}