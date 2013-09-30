using NUnit.Framework;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        private Twitter _twitter;

        [SetUp]
        public void SetUp()
        {
            _twitter = new Twitter(
                TwitterApiSettingsFactory.Create()
                );
        }

        [Test]
        public void Should_TwitteriTweet()
        {
            // Arrange


            // Act
            _twitter.GetTweets();

            // Assert

        }
    }
}
