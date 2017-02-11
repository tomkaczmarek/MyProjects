using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MyBudget.Common.Cryptography
{
    /// <summary>
    /// Encrypt text using MD5
    /// </summary>
    public class CryptoManager
    {
        
        public static string Encrypt(string text)
        {
            string hash = null;
            using(MD5 md5 = MD5.Create())
            {
                hash = GetMd5Hash(md5, text);
                return hash;
            }
                        
        }
        private static string GetMd5Hash(MD5 md5Hash, string text)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            for(int i = 0; i< data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
         }

        public static bool IsMatch(string pass1, string pass2)
        {
            return pass1.Equals(pass2);
        }
    }
}
