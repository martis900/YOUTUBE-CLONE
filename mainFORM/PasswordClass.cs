using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace YouTUBE
{
    class PasswordClass
    {
        public static string GetMD5hash(string text)
        {
            //get
            byte[] inBytes = Encoding.UTF8.GetBytes(text);
            //create coding object
            var md5 = new MD5CryptoServiceProvider();
            //compute hash - encode string
            byte[] outBytes = md5.ComputeHash(inBytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte item in outBytes)
            {
                builder.Append(item.ToString("x2"));

            }
            return builder.ToString();

        }
    }
}
