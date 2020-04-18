using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace workio_webapi.Security
{
    public static class EncryptPasswords
    {
        public static string HashPassword(string password)
        {
            string algorithm = "sha256";
            return Hash(Encoding.UTF8.GetBytes(password), algorithm);
        }

        private static string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
            }
        }
    }
}
