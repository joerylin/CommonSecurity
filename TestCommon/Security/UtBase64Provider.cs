using System.Buffers.Text;
using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture]
    public class UtBase64Provider
    {
        SecurityBase base64 = new Base64Provider(); 

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetBase64Encode_TestCase))]
        public void Base64Encode_明碼_驗證Base64加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化
            string encrtyptText = "";

            //Act：執行方法、行為、操作並取得結果
            encrtyptText = base64.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{base64.Key}\nIV：{base64.IV}");        
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetBase64Decode_TestCase))]
        public void Base64Decode_密文_驗證Base64解密(string encryptText, string expPlainText)
        {
            //Arrange：初始化
            string plainText = "";

            //Act：執行方法、行為、操作並取得結果
            plainText = base64.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"輸入密文：{encryptText}\nKey：{base64.Key}\nIV：{base64.IV}");            
            ConsoleWrite.ConsoleWriteInfo($"解密明文：{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"期望明文：{expPlainText}");

            //Assert：驗證
            Assert.AreEqual(expPlainText, plainText);
        }
    }
}