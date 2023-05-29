using System.Globalization;

namespace Wallet
{
    public class StartOptions
    {
        public string Values { get; }
        public string LocalUrl { get; }

        public StartOptions(string connectionString, string url)
        {
            Values = connectionString;
            LocalUrl = url;
        }
    }
}
