using System.Text.Json.Serialization;

namespace StocksBot.Items
{
    public class StockObject
    {
        [JsonPropertyName("c")]
        public float CurrentPrice { get; set; }
        [JsonPropertyName("h")]
        public float HighPrice { get; set; }
        [JsonPropertyName("l")]
        public float LowPrice { get; set; }
        [JsonPropertyName("o")]
        public float OpenPrice { get; set; }
        [JsonPropertyName("pc")]
        public float PrevClose { get; set; }
        [JsonPropertyName("t")]
        public int TotalVolume { get; set; }
    }
}
