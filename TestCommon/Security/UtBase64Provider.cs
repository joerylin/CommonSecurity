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
        public void Base64Encode_���X_����Base64�[�K(string plainText, string expEncryptText)
        {
            //Arrange�G��l��
            string encrtyptText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            encrtyptText = base64.Eecrypt(plainText);

            ConsoleWrite.ConsoleWriteInfo($"��J����G{plainText}\nKey�G{base64.Key}\nIV�G{base64.IV}");        
            ConsoleWrite.ConsoleWriteInfo($"�[�K�K��G{encrtyptText}");
            ConsoleWrite.ConsoleWriteInfo($"����K��G{expEncryptText}");

            //Assert�G����
            Assert.AreEqual(expEncryptText, encrtyptText);
        }

        [TestCaseSource(typeof(srcUtSecurityTestData), nameof(srcUtSecurityTestData.GetBase64Decode_TestCase))]
        public void Base64Decode_�K��_����Base64�ѱK(string encryptText, string expPlainText)
        {
            //Arrange�G��l��
            string plainText = "";

            //Act�G�����k�B�欰�B�ާ@�è��o���G
            plainText = base64.Decrypt(encryptText);

            ConsoleWrite.ConsoleWriteInfo($"��J�K��G{encryptText}\nKey�G{base64.Key}\nIV�G{base64.IV}");            
            ConsoleWrite.ConsoleWriteInfo($"�ѱK����G{plainText}");
            ConsoleWrite.ConsoleWriteInfo($"�������G{expPlainText}");

            //Assert�G����
            Assert.AreEqual(expPlainText, plainText);
        }
    }
}