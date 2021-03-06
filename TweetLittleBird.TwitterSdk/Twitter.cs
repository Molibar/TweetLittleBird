﻿using System.Collections.Generic;
using TweetLittleBird.TwitterSdk.Model;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk
{
    public interface ITwitter
    {
        List<Tweet> GetTweets();
    }

    public class Twitter : ITwitter
    {
        private readonly ITwitterApiSettings _twitterApiSettings;

        public Twitter(ITwitterApiSettings twitterApiSettings)
        {
            _twitterApiSettings = twitterApiSettings;
        }

        public List<Tweet> GetTweets()
        {
            return new List<Tweet>(new [] {new Tweet()});
        }
    }
}
