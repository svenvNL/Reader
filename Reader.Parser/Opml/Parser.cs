using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Reader.Parser.Feed;

namespace Reader.Parser.Opml
{
    public class Parser
    {
        private readonly XElement _document;

        public Parser(string opml)
        {
            _document = XElement.Parse(opml);
        }

        public List<OpmlSubscription> GetFeeds()
        {
            var elements = _document.Elements();
            var body = elements.Where(node => node.Name == "body");
            var categories = body.Elements().Where(node => node.Name == "outline" && node.HasElements);
            var feeds = categories.Elements()
                .Where(feed => feed.Name == "outline" && (string) feed.Attribute("type") == "rss");

            return feeds.Select(feed => new OpmlSubscription
                {
                    Name = feed.Attribute("title")?.Value,
                    HtmlUrl = feed.Attribute("htmlUrl")?.Value,
                    XMlUrl = feed.Attribute("xmlUrl")?.Value,
                    Type = FeedType.Rss
                })
                .ToList();
        }
    }
}