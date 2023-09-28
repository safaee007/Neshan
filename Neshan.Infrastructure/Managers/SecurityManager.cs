using System.Security.Cryptography;
using System.Text;

namespace Neshan.Infrastructure.Managers
{
    public static class SecurityManager
    {
        // Encrypt Password
        public static string encryptPassword(string password)
        {
            string retVal = md5(password);
            return retVal;
        }

        // MD5
        public static string md5(string text)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            StringBuilder sb = new StringBuilder();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hashBytes = md5.ComputeHash(inputBytes);


            for (int i = 0; i < hashBytes.Length; i++) sb.Append(hashBytes[i].ToString("007"));
            return sb.ToString().ToLower();
        }
    }
}
