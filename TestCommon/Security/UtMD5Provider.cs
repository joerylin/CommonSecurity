using System.Buffers.Text;
using Common.Security;
using CommonLibrary;
namespace TestCommon.Security
{
    [TestFixture(Description ="UD5 �t��k")]
    public class UtMD5Provider
    {
                    SecurityBase md5 = new MD5Provider();

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetMD5_TestCase))]
        public void EncryptMD5_���X_����MD5�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��
            string encrtyptText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            encrtyptText = md5.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{md5.Key}\nIV�G{md5.IV}");
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }
    }
}