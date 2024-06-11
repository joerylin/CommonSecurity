using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public class AESProvider : SecurityBase
    {
        private readonly MD5Provider _md5;
        public new string Key => base.Key;
        public new string IV
        {
            get
            {
                if(String.IsNullOrEmpty(base.IV))
                    base.IV = this.Key.Substring(0, 16);  //如果沒指定IV值，取KEY 前16碼當IV
                return base.IV;
            }
        }

        public AESProvider()
        {
            base.Key = base.config.GetSection("AESSettings")["KEY"];
            base.IV = base.config.GetSection("AESSettings")["IV"];
            this._md5 = new MD5Provider();
        }


        public override string Decrypt(string plainText)
        {
            return this.aesDecrypt(plainText);
            //return this.aesRijndaelDecrypt(plainText);
        }

        public override string Eecrypt(string plainText)
        {
            return this.aesEncrypt(plainText);
            // return this.aesRijndaelEncrypt(plainText);
        }

        #region AES 256
        /// <summary>
        /// AES 演算法加密(CBC模式) 將明文加密，加密後進行base64编碼，回傳密文
        /// 沒有 IV 參數，則 IV =  MD5.Hash(SubString(Key,16))
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>加密後base64编碼的密文</returns>
        private string aesEncrypt(string plainText)
        {
            byte[] src = Encoding.UTF8.GetBytes(plainText);
            byte[] dest;
            using(Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 256;
                aes.Key = Encoding.ASCII.GetBytes(this.Key);
                aes.IV = this._md5.GetMd5Hash(this.IV);
                using(ICryptoTransform encrypt = aes.CreateEncryptor(aes.Key, aes.IV))
                    dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                aes.Dispose();
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES演算法解密(ECB模式) 將密文base64解碼進行解密，回傳明文
        /// 沒有 IV 參數，則 IV =  SubString(Key,16)
        /// </summary>
        /// <param name="DecryptStr">密文</param>
        /// <param name="Key">密碼</param>
        /// <returns>明文</returns>
        private string aesDecrypt(string cipherText)
        {
            byte[] src = Convert.FromBase64String(cipherText);
            byte[] dest;
            using(Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 256;
                aes.Key = Encoding.ASCII.GetBytes(this.Key);
                aes.IV = this._md5.GetMd5Hash(this.IV);
                using(ICryptoTransform deCrypt = aes.CreateDecryptor(aes.Key, aes.IV))
                    dest = deCrypt.TransformFinalBlock(src, 0, src.Length);
                aes.Dispose();
                return Encoding.UTF8.GetString(dest);
            }
        }
        #endregion

        #region AES 256 using Rijndael
        /// <summary>
        /// AES  using Rijndael 演算法加密(ECB模式) 將明文加密，加密後進行base64编碼，回傳密文
        /// 沒有 IV 參數則 IV =  PadRight( SubString(Key,16), 32, '=')
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>加密後base64编碼的密文</returns>
        private string aesRijndaelEncrypt(string plainText)
        {
            byte[] src = Encoding.UTF8.GetBytes(plainText);
            byte[] key = Encoding.ASCII.GetBytes(this.Key);
            byte[] iv = Encoding.ASCII.GetBytes(this.IV.PadRight(32, '='));

            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;

            using(ICryptoTransform encrypt = aes.CreateEncryptor(key, iv))
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                encrypt.Dispose();
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES  using Rijndael 演算法解密(ECB模式) 將密文base64解碼進行解密，回傳明文
        /// 沒有 IV 參數，則 IV =  PadRight( SubString(Key,16), 32, '=')
        /// </summary>
        /// <param name="DecryptStr">密文</param>
        /// <param name="Key">密碼</param>
        /// <returns>明文</returns>
        private string aesRijndaelDecrypt(string cipherText)
        {
            byte[] src = Convert.FromBase64String(cipherText);
            byte[] key = Encoding.ASCII.GetBytes(this.Key);
            byte[] iv = Encoding.ASCII.GetBytes(this.IV.PadRight(32, '='));

            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;

            using(ICryptoTransform decrypt = aes.CreateDecryptor(key, null))
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                decrypt.Dispose();
                return Encoding.UTF8.GetString(dest);
            }
        }
        #endregion
    }
}
