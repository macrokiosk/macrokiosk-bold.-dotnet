using System;
using System.Security.Cryptography;
using System.Text;

namespace BOLD.Pay.Extensions
{
    public static class HashExtension
    {
        public static string MD5Hash(this string input)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(input);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            string encoded = BitConverter.ToString(hash)
                .Replace("-", string.Empty)
                .ToUpper();

            return encoded;
        }
    }
}