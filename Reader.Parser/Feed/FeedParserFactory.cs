using Reader.Parser.Feed.Rss;

namespace Reader.Parser.Feed
{
    public static class FeedParserFactory
    {

        public static IFeedParser GetParser(FeedType type)
        {
            switch (type)
            {
                case FeedType.Rss:
                    return new RssParser();
                case FeedType.Atom:
                    return null;
                default:
                    return null;
            }
        }
    }
}