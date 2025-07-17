using System.Text;

namespace MahalliyMarket.CommonUtils
{
    public class Decoder
    {
        public static string DecodeBase64(string base64Encoded)
        {
            byte[] data = Convert.FromBase64String(base64Encoded);

            return Encoding.UTF8.GetString(data);
        }
    }
}
