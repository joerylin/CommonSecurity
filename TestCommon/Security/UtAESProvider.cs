using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description = "AES 演算法")]
    public class UtAESProvider
    {
        AESProvider aesCrypt;

        [SetUp]
        public void InitialAesInstance()
        {
            aesCrypt = new AESProvider();
        }

        [Test]
        public void AESConstructor_驗證是否產生AES實體並取得KEY_IV()
        {
            //Arrange：初始化

            string key, iv = null;

            //Act：執行方法、行為、操作並取得結果
            key = aesCrypt.Key;
            iv = aesCrypt.IV;

            ConsoleWrite.ConsoleWriteInfo($"AES Key：{key}");
            ConsoleWrite.ConsoleWriteInfo($"AES IV：{iv}");

            //Assert：驗證
            Assert.IsNotNull(aesCrypt);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAESEncode_TestCase))]
        public void Eecrypt_明碼_驗證AES加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化

            string encrtyptText = "";

            //Act：執行方法、行為、操作並取得結果
            encrtyptText = aesCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{aesCrypt.Key}\nIV：{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAES_IVisNull_Encode_TestCase))]
        public void Eecrypt_明碼IVisNULL_驗證AES加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化

            string encrtyptText = "";
            aesCrypt.SetKey(aesCrypt.Key, null);
            //Act：執行方法、行為、操作並取得結果
            encrtyptText = aesCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{aesCrypt.Key}\nIV：{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAESDecode_TestCase))]
        public void Decrypt_密文_驗證AES解密(string encryptText, string expPlainText)
        {
            //Arrange：初始化

            string plainText = "";

            //Act：執行方法、行為、操作並取得結果 
            plainText = aesCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"輸入密文：{encryptText}\nKey：{aesCrypt.Key}\nIV：{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"解密明文：{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"期望明文：{expPlainText}");

            //Assert：驗證
            Assert.AreEqual(expPlainText, plainText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetAES_IVisNull_Decode_TestCase))]
        public void Decrypt_密文IVisNull_驗證AES解密(string encryptText, string expPlainText)
        {
            //Arrange：初始化

            string plainText = "";

            //Act：執行方法、行為、操作並取得結果 
            aesCrypt.SetKey(aesCrypt.Key, null);
            plainText = aesCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"輸入密文：{encryptText}\nKey：{aesCrypt.Key}\nIV：{aesCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"解密明文：{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"期望明文：{expPlainText}");

            //Assert：驗證
            Assert.AreEqual(expPlainText, plainText);
        }
    }
}