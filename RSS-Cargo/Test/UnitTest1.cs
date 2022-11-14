using BCrypt.Net;
using RSS_Cargo.BLL;
namespace Test
{
    public class UnitTest_RssFeed
    {
        private readonly RssFeed _rssFeed;

        public UnitTest_RssFeed()
        {
            _rssFeed = new RssFeed("http://rss.cnn.com/rss/edition_world.rss");
        }

        [Fact]
        public void Test_Title()
        {
            Assert.Equal("CNN.com - RSS Channel - World", _rssFeed.Title);
        }

        [Fact]
        public void Test_Description()
        {
            Assert.Equal("CNN.com delivers up-to-the-minute news and information on the latest top stories, weather, entertainment, politics and more.", _rssFeed.Description);
        }

        [Fact]
        public void Test_Items()
        {
            Assert.Equal(29, _rssFeed.Items.Length);
        }
        [Fact]
        public void Test_ItemTitle()
        {
            string searchElement = "Analysis: Elon Musk's Twitter faces its 'Titanic' moment as executives and advertisers flee while trolls run rampant";
            
            Assert.True(Array.Exists(_rssFeed.Items, element => element.Title == searchElement));
            
        }        
        
        [Fact]
        public void Test_ItemSummary()
        {
            string searchElement = "The world is watching the world's richest man single-handedly destroy one of the world's most powerful and important communication platforms, just weeks after acquiring it for $44 billion. And of course, the world is watching the dramatic spectacle unfold on — where else? — Twitter.";
            Assert.True(Array.Exists(_rssFeed.Items, element => element.Summary == searchElement));            
        }
        [Fact]
        public void Test_ItemPublishDate()
        {
            string searchElement = "10.11.2022 21:01:48 +00:00";
            Assert.True(Array.Exists(_rssFeed.Items, element => element.PublishDate == searchElement));
            
        }



    }
}