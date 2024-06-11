using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public class Base64Provider   : SecurityBase
    {
        #region Base64
        protected  string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        protected string Base64Decode(string base64EncodedText)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedText);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public override string Decrypt(string plainText)
        {
            return this.Base64Decode(plainText);
        }

        public override string Eecrypt(string plainText)
        {
           return this.Base64Encode(plainText);
        }
        #endregion
    }
}
