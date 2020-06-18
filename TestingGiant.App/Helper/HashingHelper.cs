using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TestingGiant.App.Helper
{
    public static class HashingHelper
    {
        public static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
