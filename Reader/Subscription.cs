using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reader.Parser.Feed;
using Reader.Parser.Opml;

namespace Reader
{
    public class Subscription
    {
        public async Task<List<Entry>> GetEntriesAsync(List<OpmlSubscription> subscriptions)
        {
            var entries = new List<Entry>();
            foreach (var feed in subscriptions)
            {
                try
                {
                    var client = HttpClient.GetInstance();
                    var feedData = await client.GetAsync(feed.XMlUrl);
                    var body = await feedData.Content.ReadAsStringAsync();

                    var parser = FeedParserFactory.GetParser(feed.Type);
                    parser.Load(body);

                    parser.GetEntries().ForEach(entry => { entries.Add(entry); });
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return entries;
        }
    }
}