using System;
using System.Configuration;

namespace TweetLittleBird.Framework.Configuration
{
    public class Config
    {
        public static string Get(string key)
        {
            var fromConfig = ConfigurationManager.AppSettings[key];
            if (String.Equals(fromConfig, "{ENV}", StringComparison.InvariantCultureIgnoreCase))
            {
                return Environment.GetEnvironmentVariable(key);
            }
            return fromConfig;
        }
    }
}