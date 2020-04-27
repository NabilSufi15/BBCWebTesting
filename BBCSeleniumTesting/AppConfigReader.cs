using System.Configuration;

namespace BBCSeleniumTesting
{
    class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["login_url"];
    }
}
