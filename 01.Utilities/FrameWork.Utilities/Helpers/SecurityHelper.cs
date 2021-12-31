using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FrameWork.Utilities.Helpers
{
    public class SecurityHelper
    {
        public static string SHA256_Hash(string value)
        {
            try
            {
                using (SHA256 hash = SHA256.Create())
                {
                    return string.Concat(hash
                      .ComputeHash(Encoding.UTF8.GetBytes(value))
                      .Select(item => item.ToString("x2")));
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
