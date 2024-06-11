using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommon.Security
{
    internal class srcUtSecurityTestData
    {
        public static IEnumerable<TestCaseData> GetMD5_TestCase
        {
            get
            {
                yield return new TestCaseData("JOERYLIN", "56535B73F42BF47FFD1E816FAAF9C175").SetName("驗證MD5加密-01:JOERYLINP");
                yield return new TestCaseData("1qaz2wsx", "1C63129AE9DB9C60C3E8AA94D3E00495").SetName("驗證MD5加密-02:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "D78D0E631A095DCE91E410C92F0898F7").SetName("驗證MD5加密-03:JLin1qaz@WSX");
            }
        }

        public static IEnumerable<TestCaseData> GetBase64Encode_TestCase
        {
            get
            {
                yield return new TestCaseData("JOERYLIN", "Sk9FUllMSU4=").SetName("驗證Base64加密-01:JOERYLINP");
                yield return new TestCaseData("1qaz2wsx", "MXFhejJ3c3g=").SetName("驗證Base64加密-02:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "SkxpbjFxYXpAV1NY").SetName("驗證Base64加密-03:JLin1qaz@WSX");
            }
        }
        public static IEnumerable<TestCaseData> GetBase64Decode_TestCase
        {
            get
            {
                yield return new TestCaseData("Sk9FUllMSU4=", "JOERYLIN").SetName("驗證Base64解密-01:JOERYLINP");
                yield return new TestCaseData("MXFhejJ3c3g=", "1qaz2wsx").SetName("驗證Base64解密-02:1qaz2wsx");
                yield return new TestCaseData("SkxpbjFxYXpAV1NY", "JLin1qaz@WSX").SetName("驗證Base64解密-03:JLin1qaz@WSX");
            }
        }



        #region GetAesTestData
        public static IEnumerable<TestCaseData> GetAESEncode_TestCase
        {
            get
            {                
                yield return new TestCaseData("1qaz2wsx", "4+r/Z85CFx2eoL88EhfO7A==").SetName("驗證AES加密-01:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "9z+L8UuvzuK7lGo9R/XoYw==").SetName("驗證AES加密-02:JLin1qaz@WSX");
                yield return new TestCaseData("JLin1qaz@WSX!@#$", "IKXwJELsfHA5LMTXWQDYUOHcVJt8oif0ddVBAfygUwY=").SetName("驗證AES加密-03:JLin1qaz@WSX!@#$");
            }
        }
        public static IEnumerable<TestCaseData> GetAESDecode_TestCase
        {
            get
            {                
                yield return new TestCaseData("4+r/Z85CFx2eoL88EhfO7A==", "1qaz2wsx").SetName("驗證AES解密-01:1qaz2wsx");
                yield return new TestCaseData("9z+L8UuvzuK7lGo9R/XoYw==", "JLin1qaz@WSX").SetName("驗證AES解密-02:JLin1qaz@WSX");
                yield return new TestCaseData("IKXwJELsfHA5LMTXWQDYUOHcVJt8oif0ddVBAfygUwY=", "JLin1qaz@WSX!@#$").SetName("驗證AES解密-03:JOERYLINP");
            }
        }


        public static IEnumerable<TestCaseData> GetAES_IVisNull_Encode_TestCase
        {
            get
            {                
                yield return new TestCaseData("1qaz2wsx", "BKN6sGkfw2e2S5T7K1mH8g==").SetName("驗證AES加密-01_IVisNull:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "4tctl7MWOyTu2aPEKikB1w==").SetName("驗證AES加密-02_IVisNull:JLin1qaz@WSX");
                yield return new TestCaseData("JLin1qaz@WSX!@#$", "/TyfV6qjTUvKIQog/qXcHa2OjdQB12K8mBUIKvgBmaE=").SetName("驗證AES加密-03_IVisNull:JLin1qaz@WSX!@#$");
            }
        }
        public static IEnumerable<TestCaseData> GetAES_IVisNull_Decode_TestCase
        {
            get
            {                
                yield return new TestCaseData("BKN6sGkfw2e2S5T7K1mH8g==", "1qaz2wsx").SetName("驗證AES解密-01_IVisNull:1qaz2wsx");
                yield return new TestCaseData("4tctl7MWOyTu2aPEKikB1w==", "JLin1qaz@WSX").SetName("驗證AES解密-02_IVisNull:JLin1qaz@WSX");
                yield return new TestCaseData("/TyfV6qjTUvKIQog/qXcHa2OjdQB12K8mBUIKvgBmaE=", "JLin1qaz@WSX!@#$").SetName("驗證AES解密-03_IVisNull:JOERYLINP");
            }
        }
        #endregion


        #region GetDesTestData

        public static IEnumerable<TestCaseData> GetDESEncode_TestCase
        {
            get
            {                
                yield return new TestCaseData("1qaz2wsx", "3D419706E4411D02C48BB38F6166B4D8").SetName("驗證DES加密-01:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "35724F6B9C382039BE566B38FB3628D4").SetName("驗證DES加密-02:JLin1qaz@WSX");
                yield return new TestCaseData("JLin1qaz@WSX!@#$", "35724F6B9C38203933773408EB45261ADBF632297E64848A").SetName("驗證DES加密-03:JLin1qaz@WSX!@#$");
            }
        }
        public static IEnumerable<TestCaseData> GetDESDecode_TestCase
        {
            get
            {                
                yield return new TestCaseData("3D419706E4411D02C48BB38F6166B4D8", "1qaz2wsx").SetName("驗證DES解密-01:1qaz2wsx");
                yield return new TestCaseData("35724F6B9C382039BE566B38FB3628D4", "JLin1qaz@WSX").SetName("驗證DES解密-02:JLin1qaz@WSX");
                yield return new TestCaseData("35724F6B9C38203933773408EB45261ADBF632297E64848A", "JLin1qaz@WSX!@#$").SetName("驗證DES解密-03:JOERYLINP");
            }
        }

        public static IEnumerable<TestCaseData> GetDES_IVisNull_Encode_TestCase
        {
            get
            {                
                yield return new TestCaseData("1qaz2wsx", "DD0F95B6E93DC89BB40C42BC49D4E0EA").SetName("驗證DES加密-01_IVisNull:1qaz2wsx");
                yield return new TestCaseData("JLin1qaz@WSX", "DFF5CF19A1B997D66C1160A8AF62A9D4").SetName("驗證DES加密-02_IVisNull:JLin1qaz@WSX");
                yield return new TestCaseData("JLin1qaz@WSX!@#$", "DFF5CF19A1B997D6FDC108517C2AF82379F457F64FD4D0CB").SetName("驗證DES加密-03_IVisNull:JLin1qaz@WSX!@#$");
            }
        }
        public static IEnumerable<TestCaseData> GetDES_IVisNull_Decode_TestCase
        {
            get
            {
                yield return new TestCaseData("DD0F95B6E93DC89BB40C42BC49D4E0EA", "1qaz2wsx").SetName("驗證DES解密-01_IVisNull:1qaz2wsx");
                yield return new TestCaseData("DFF5CF19A1B997D66C1160A8AF62A9D4", "JLin1qaz@WSX").SetName("驗證DES解密-02_IVisNull:JLin1qaz@WSX");
                yield return new TestCaseData("DFF5CF19A1B997D6FDC108517C2AF82379F457F64FD4D0CB", "JLin1qaz@WSX!@#$").SetName("驗證DES解密-03_IVisNull:JLin1qaz@WSX!@#$");
            }
        }

        #endregion
    }
}
