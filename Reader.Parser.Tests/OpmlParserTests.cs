using System.Collections.Generic;
using Reader.Parser.Opml;
using Xunit;

namespace Reader.Parser.Tests
{
    public class OpmlParserTests
    {
        [Fact]
        public void GetFeeds_ValidInpunt_ReturnAllFeeds()
        {
            // TODO: write proper unit tests
            var parser = new Reader.Parser.Opml.Parser("<rss></rss>");
            
            var expected = new List<OpmlSubscription>();
            var actual = parser.GetFeeds();
            
            Assert.Equal(expected, actual);
        }
    }
}