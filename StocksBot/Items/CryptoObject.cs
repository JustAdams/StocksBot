using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StocksBot.Items
{
    class CryptoObject
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
        [JsonPropertyName("v")]
        public int TotalVolume { get; set; }
    }
}
