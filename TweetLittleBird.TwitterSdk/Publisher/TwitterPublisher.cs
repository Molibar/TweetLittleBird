using System.Collections.Generic;
using TweetLittleBird.ApiProxy;
using TweetLittleBird.TwitterSdk.Model;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk.Publisher
{
    public class TwitterPublisher : Twitter
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private string URI;

        public TwitterPublisher(ITwitterApiSettings twitterApiSettings, IHttpClientWrapper httpClientWrapper) : base(twitterApiSettings)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public void Publish(Tweet tweet)
        {
            var headers = new Dictionary<string, string>()
                {
                    {"X-Auth-Service-Provider", "https://api.twitter.com/1/account/verify_credentials.json"},
                    {"X-Verify-Credentials-Authorization", "https://api.twitter.com/1/account/verify_credentials.json"}
                };
            var x = _httpClientWrapper.Post<object, object>(URI, headers, null);
        }
    }
}
