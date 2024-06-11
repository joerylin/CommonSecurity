using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    public class MD5Provider : SecurityBase
    {

        protected string EncryptMD5(string input)
        {
            using(MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2"));     //大寫16進位字元
                return sb.ToString();
            }
        }

        public override string Decrypt(string plainText)
        {
            throw new NotImplementedException("MD5 演算法無法逆向解密！");
        }

        public override string Eecrypt(string plainText)
        {
            return this.EncryptMD5(plainText);
        }

        public byte[] GetMd5Hash(string input)
        {
            using(MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);                
                return hashBytes;
            }
        }

    }
}
