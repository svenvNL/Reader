using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Reader.Parser.Feed.Rss
{
    public class RssParser : IFeedParser
    {
        private XElement _document;

        public void Load(string feed)
        {
            _document = XElement.Parse(feed);
        }

        public List<Entry> GetEntries()
        {
            var elements = _document.Elements();
            var channel = elements.Where(node => node.Name == "channel");
            var entries = channel.Elements().Where(node => node.Name == "item");
            return entries.Select(entry => new Entry
                {
                    Title = entry.Elements().First(node => node.Name == "title").Value,
                    Description = entry.Elements().First(node => node.Name == "description").Value,
                    Link = entry.Elements().First(node => node.Name == "link").Value,
                    PubDate = Convert.ToDateTime(entry.Elements().First(node => node.Name == "pubDate").Value)
                })
                .ToList();
        }
    }
}