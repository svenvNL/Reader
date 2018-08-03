using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = System.IO.File.ReadAllText("feed.xml");

            var opmlParser = new Parser.Opml.Parser(data);
            var feeds = opmlParser.GetFeeds();
            
            var subscription = new Subscription();
            var entries = await subscription.GetEntriesAsync(feeds);

            foreach (var entry in entries.OrderByDescending(entry => entry.PubDate))
            {
                Console.WriteLine(
                    $"{entry.PubDate.ToLocalTime().ToShortDateString()} {entry.PubDate.ToLocalTime().ToShortTimeString()} - {entry.Title} {entry.Link}");
            }
        }
    }
}