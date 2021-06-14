using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StocksBot.Items
{
    public class StTrendingObject
    {
        [JsonPropertyName("symbols")]
        public List<SymbolObject> Symbols { get; set; }
    }

    public class SymbolObject
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("watchlist_count")]
        public int WatchCount { get; set; }

    }
}
