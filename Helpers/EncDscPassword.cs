using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace EmployeeWebAPIforJWTtoken.Helpers
{
    public static class EncDscPassword
    {
        public static string secretekey = "@dotnet123secreateKey";
        public static string EncryptPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password))
            {
                return "";
            }
            else
            {
                Password = Password + secretekey;
                var passwordinBytes = Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(passwordinBytes);
            }
        }
        public static string DecryptPassword(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                return "";
            }
            else
            {
                var encodedBytes = Convert.FromBase64String(encryptedPassword);
                var actualPassword = Encoding.UTF8.GetString(encodedBytes);
                actualPassword = actualPassword.Substring(0, actualPassword.Length - secretekey.Length);
                return actualPassword;
            }
        }
    }
}
