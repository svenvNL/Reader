using System.Collections.Generic;

namespace Reader.Parser.Feed
{
    public interface IFeedParser
    {
        void Load(string feed);

        List<Entry> GetEntries();
    }
}