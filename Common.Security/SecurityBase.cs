using Microsoft.Extensions.Configuration;

namespace Common.Security
{
    public abstract class SecurityBase
    {
        protected readonly IConfiguration config;
        private string _Key;
        private string _IV;     //初始化向量（IV，Initialization Vector）


        /// <summary> 
        /// 加密金鑰
        /// </summary> 
        public string Key
        {
            set
            {
                _Key = value;
            }
            get
            {
                return _Key;
            }
        }
        /// <summary> 
        /// 初始化向量（IV，Initialization Vector）
        /// </summary> 
        public string IV
        {
            set
            {
                _IV = value;
            }
            get
            {
                return _IV;
            }
        }

        public string getSetting() => $"Key={_Key}; IV={_IV}";


        public SecurityBase()
        {
            this.config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Security.json", optional: true, reloadOnChange: true)
            .Build();
        }

        /// <summary>
        /// 加密金鑰KEY(8個字元) ，初始化向量IV(8個字元)
        /// </summary>
        /// <param name="key">加密金鑰KEY(8個字元)</param>
        /// <param name="iv">InitialValue:初始化向量IV(8個字元)</param>
        public void SetKey(string key, string iv)
        {
            this.Key = key;
            this.IV = iv;         
        }

        /// <!--解密字串--> 
        /// <summary> 
        /// 解密字串
        /// </summary> 
        /// <param name="value">解密的字串</param> 
        /// <returns>解密過後的字串</returns> 
        public abstract string Decrypt(string plainText);

        /// <!--加密字串--> 
        /// <summary> 
        /// 加密字串
        /// </summary> 
        /// <param name="value">加密的字串</param> 
        /// <returns>加密過後的字串</returns> 
        public abstract string Eecrypt(string plainText);


    }
}
