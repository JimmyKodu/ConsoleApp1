using Microsoft.AspNetCore.DataProtection;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EncryptData("Hello, World!","0"));
            Console.WriteLine(DecryptData("CfDJ8ArU2H3EhX1ChfCQiHUQn2jVt5uWW5r+hog7yb2wCXMYre2cHHEKb1PKJAFHopAOZHaRU4IFXXuAHzrtmIgm2Xri/fFkiSniYTMkNAD/H9UHG//EaWkYx9VtNEHd0ws4uQ==", "0"));
        }
        public static string EncryptData(string data, string key)
        {
            byte[] encryptedBytes;
            var provider = DataProtectionProvider.Create(key);
            var protector = provider.CreateProtector("MyApp.Encryption");
            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            encryptedBytes = protector.Protect(plainBytes);
            return Convert.ToBase64String(encryptedBytes);
        }
        public static string DecryptData(string encryptData, string key)
        {
            byte[] decryptedBytes;
            var provider = DataProtectionProvider.Create(key);
            var protector = provider.CreateProtector("MyApp.Encryption");
            byte[] encryptedBytes = Convert.FromBase64String(encryptData);
            decryptedBytes = protector.Unprotect(encryptedBytes);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
