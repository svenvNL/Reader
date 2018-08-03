using Reader.Parser.Feed;

namespace Reader.Parser.Opml
{
    public class OpmlSubscription
    {
        public string Name { get; set; }
        public string XMlUrl { get; set; }
        public string HtmlUrl { get; set; }
        public FeedType Type { get; set; }
    }
}