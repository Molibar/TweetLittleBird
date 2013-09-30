using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        private ITwitter _twitter;

        [SetUp]
        public void SetUp()
        {
            _twitter = new Twitter(
                TwitterApiSettingsFactory.Create()
                );
        }

        [Test]
        public void Should_()
        {
            // Arrange


            // Act
            _twitter.GetTweets();

            // Assert

        }
    }
}
