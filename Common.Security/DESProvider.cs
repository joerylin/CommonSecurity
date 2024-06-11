using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    public class DESProvider : SecurityBase
    {
        public new string Key => base.Key;
        public new string IV
        {
            get
            {
                if(String.IsNullOrEmpty(base.IV))
                    base.IV = this.Key;  //如果沒指定IV值，取KEY當IV
                return base.IV;
            }
        }
        public DESProvider()
        {
            base.Key = base.config.GetSection("DESSettings")["KEY"];
            base.IV = base.config.GetSection("DESSettings")["IV"]; 
        }


        /// <!--解密字串--> 
        /// <summary> 
        /// 解密字串 - design By Phoenix 2008 - 
        /// </summary> 
        /// <param name="value">解密的字串</param> 
        /// <returns>
        public override string Decrypt(string plainText)
        {
            return Decrypt(plainText, this.Key, this.IV);
        }

        /// <!--加密字串--> 
        /// <summary> 
        /// 加密字串
        /// </summary> 
        /// <param name="value">加密的字串</param> 
        /// <returns>加密過後的字串</returns> 
        public override string Eecrypt(string plainText)
        {
            return this.p_Encrypt(plainText, this.Key, this.IV);
        }


        /// <summary> 
        /// DES 加密法
        /// </summary> 
        /// <param name="pToEncrypt">加密的字串</param> 
        /// <param name="sKey">加密金鑰</param> 
        /// <param name="sIV">初始化向量</param> 
        /// <returns>密文</returns> 
        private string p_Encrypt(string pToEncrypt, string sKey, string sIV)
        {
            StringBuilder ret = new StringBuilder();
            using(DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                //將字元轉換為Byte 
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                //設定加密金鑰(轉為Byte) 
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                //設定初始化向量(轉為Byte) 
                des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

                using(MemoryStream ms = new MemoryStream())
                {
                    using(CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }
                    //輸出資料 
                    foreach(byte b in ms.ToArray())
                        ret.AppendFormat("{0:X2}", b);
                }
            }
            //回傳 
            return ret.ToString();
        }

        /// <!--DES 解密法--> 
        /// <summary> 
        /// DES 解密法
        /// </summary> 
        /// <param name="pToDecrypt">解密的字串</param> 
        /// <param name="sKey">加密金鑰</param> 
        /// <param name="sIV">初始化向量</param> 
        /// <returns>明文</returns> 
        private string Decrypt(string pToDecrypt, string sKey, string sIV)
        {
            using(DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                //反轉 
                for(int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                //設定加密金鑰(轉為Byte) 
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                //設定初始化向量(轉為Byte) 
                des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
                using(MemoryStream ms = new MemoryStream())
                {
                    using(CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        //例外處理 
                        try
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                            //輸出資料 
                            return System.Text.Encoding.Default.GetString(ms.ToArray());
                        }
                        catch(CryptographicException)
                        {
                            //若金鑰或向量錯誤，傳回N/A 
                            return "N/A";
                        }
                    }
                }
            }
        }
    }
}
