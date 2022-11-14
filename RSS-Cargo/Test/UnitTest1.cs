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
            var item = _rssFeed.Items[0];
            Assert.Equal("Israeli President invites Netanyahu to form government", item.Title);
        }
        [Fact]
        public void Test_ITemLinks()
        {
            var item = _rssFeed.Items[0];
            Assert.Equal("https://www.cnn.com/2022/11/13/middleeast/netanyahu-form-government-israel-intl/index.html", item.Links[0].Item2);
        }
        [Fact]
        public void Test_ItemSummary()
        {
            var item = _rssFeed.Items[0];
            Assert.Equal("Israel's President Isaac Herzog asked Benjamin Netanyahu to form a new government on Sunday, allowing the former prime minister to secure the country's top job for a record sixth time and extend his record as the nation's longest-serving leader.",
                item.Summary);
        }
        [Fact]
        public void Test_ItemPublishDate()
        {
            var item = _rssFeed.Items[0];
            Assert.Equal("13.11.2022 13:57:46 +00:00", item.PublishDate);
        }



    }
}