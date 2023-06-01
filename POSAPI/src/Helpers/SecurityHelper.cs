using System.Security.Cryptography;
using System.Text;

namespace POSAPI.Security
{
    public static class SecurityHelper
    {
        public static string GetHash(string str, string salt, int iterations = 2)
        {
            var hashedString = "";
            for(int i = 0; i < iterations; i++)
            {
                hashedString += ComputeSha512Hash(hashedString + str + salt);
            }

            return hashedString;
        }

        private static string ComputeSha512Hash(string rawData)
        {
            using SHA512 sha512Hash = SHA512.Create();

            byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));                                     // ComputeHash - returns byte array  

            StringBuilder builder = new();                                                                              // Convert byte array to a string
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));

            return builder.ToString();
        }
    }
}
