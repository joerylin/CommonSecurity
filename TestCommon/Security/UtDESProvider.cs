using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description = "DES 演算法")]
    public class UtDESProvider
    {
        private DESProvider desCrypt;

        [SetUp]
        public void InitialDesInstinace()
        {
            desCrypt = new DESProvider();
        }

        [Test]
        public void UtDESProvider_驗證是否產生DES實體並取得KEY_IV()
        {
            //Arrange：初始化
            string key, iv = null;

            //Act：執行方法、行為、操作並取得結果
            key = desCrypt.Key;
            iv = desCrypt.IV;

            ConsoleWrite.ConsoleWriteInfo($"DES Key：{key}");
            ConsoleWrite.ConsoleWriteInfo($"DES IV：{iv}");

            //Assert：驗證
            Assert.IsNotNull(desCrypt);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDESEncode_TestCase))]
        public void Eecrypt_明碼_驗證DES加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化
            string encrtyptText = "";

            //Act：執行方法、行為、操作並取得結果
            encrtyptText = desCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{desCrypt.Key}\nIV：{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDES_IVisNull_Encode_TestCase))]
        public void Eecrypt_明碼IVisNull_驗證DES加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化
            string encrtyptText = "";

            //Act：執行方法、行為、操作並取得結果
            desCrypt.SetKey(desCrypt.Key, null);
            encrtyptText = desCrypt.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{desCrypt.Key}\nIV：{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }



        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDESDecode_TestCase))]
        public void Decrypt_密文_驗證DES解密(string encryptText, string expPlainText)
        {
            //Arrange：初始化
            string plainText = "";

            //Act：執行方法、行為、操作並取得結果
            plainText = desCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"輸入密文：{encryptText}\nKey：{desCrypt.Key}\nIV：{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"解密明文：{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"期望明文：{expPlainText}");

            //Assert：驗證
            Assert.AreEqual(expPlainText, plainText);
        }

        [Test, TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetDES_IVisNull_Decode_TestCase))]
        public void Decrypt_密文IVisNull_驗證DES解密(string encryptText, string expPlainText)
        {
            //Arrange：初始化
            string plainText = "";

            //Act：執行方法、行為、操作並取得結果
            desCrypt.SetKey(desCrypt.Key, null);
            plainText = desCrypt.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"輸入密文：{encryptText}\nKey：{desCrypt.Key}\nIV：{desCrypt.IV}");
            ConsoleWrite.ConsoleWriteInfo($"解密明文：{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"期望明文：{expPlainText}");

            //Assert：驗證
            Assert.AreEqual(expPlainText, plainText);
        }

    }
}