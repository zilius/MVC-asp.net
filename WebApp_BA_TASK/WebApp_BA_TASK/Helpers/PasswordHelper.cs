using System.Security.Cryptography;
using System.Text;

namespace WebApp_BA_TASK.Helpers
{
    public static class PasswordHelper
    {
        public static string HashSha(string plainPassword)
        {

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(plainPassword);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}