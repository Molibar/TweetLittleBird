using TweetLittleBird.Framework.Configuration;

namespace TweetLittleBird.TwitterSdk.Settings
{
    public interface ITwitterApiSettings
    {
        string TwitterConsumerKey { get; set; }
        string TwitterConsumerSecret { get; set; }
        string TwitterRequestTokenUrl { get; set; }
        string TwitterAuthorizeUrl { get; set; }
        string TwitterAccessTokenUrl { get; set; }
    }

    public class TwitterApiSettings : ITwitterApiSettings
    {
        public string TwitterConsumerKey { get; set; }
        public string TwitterConsumerSecret { get; set; }
        public string TwitterRequestTokenUrl { get; set; }
        public string TwitterAuthorizeUrl { get; set; }
        public string TwitterAccessTokenUrl { get; set; }
    }

    public class TwitterApiSettingsFactory
    {
        public static ITwitterApiSettings Create()
        {
            return new TwitterApiSettings
                {
                    TwitterConsumerKey = Config.Get("TweetLittleBird.TwitterConsumerKey"),
                    TwitterConsumerSecret = Config.Get("TweetLittleBird.TwitterConsumerSecret"),
                    TwitterRequestTokenUrl = Config.Get("TwitterRequestTokenUrl"),
                    TwitterAuthorizeUrl = Config.Get("TwitterAuthorizeUrl"),
                    TwitterAccessTokenUrl = Config.Get("TwitterAccessTokenUrl")
                };
        }
    }
}
