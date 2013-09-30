using NUnit.Framework;
using TweetLittleBird.ApiProxy;
using TweetLittleBird.TwitterSdk.Model;
using TweetLittleBird.TwitterSdk.Publisher;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk.Tests.Publisher
{
    [TestFixture]
    public class TwitterPublisherTests
    {
        private TwitterPublisher _twitterPublisher;

        [SetUp]
        public void SetUp()
        {
            _twitterPublisher = new TwitterPublisher(
                TwitterApiSettingsFactory.Create(),
                new HttpClientWrapper()
                );
        }

        [Test]
        public void Should_()
        {
            // Arrange
            var tweet = new Tweet { Text = "My tweet!"};

            // Act
            _twitterPublisher.Publish(tweet);

            // Assert
        }
    }
}
