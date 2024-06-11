using System.Buffers.Text;
using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description ="UD5 演算法")]
    public class UtMD5Provider
    {
                    SecurityBase md5 = new MD5Provider();

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetMD5_TestCase))]
        public void EncryptMD5_明碼_驗證MD5加密(string plainText, string expEncryptText)
        {
            //Arrange：初始化
            string encrtyptText = "";

            //Act：執行方法、行為、操作並取得結果
            encrtyptText = md5.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"輸入明文：{plainText}\nKey：{md5.Key}\nIV：{md5.IV}");
            ConsoleWrite.ConsoleWriteInfo($"加密密文：{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"期望密文：{expEncryptText}");

            //Assert：驗證
            Assert.AreEqual(expEncryptText, encrtyptText);
        }
    }
}