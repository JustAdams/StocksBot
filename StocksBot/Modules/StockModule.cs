using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using StocksBot.Items;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StocksBot.Modules
{
    class StockModule : BaseCommandModule
    {
        private static readonly HttpClient client = new();

        private readonly string stockToken = System.IO.File.ReadAllLines(@"D:\\ASP_NET\\DiscordBot\\StocksBot\\tokens.txt")[3];

        [Command("price")]
        public async Task TickerCommand(CommandContext context)
        {
            await context.RespondAsync("Enter a stock symbol after the !price command");
        }

        [Command("price")]
        [Description("Get information about today's pricing")]
        public async Task TickerCommand(CommandContext context, string ticker)
        {
            ticker = ticker.ToUpper();

            var res = client.GetStringAsync($"https://finnhub.io/api/v1/quote?symbol={ticker}&token={stockToken}");
            var msg = await res;

            StockObject stockObject = JsonSerializer.Deserialize<StockObject>(msg);

            StringBuilder sb = new StringBuilder($"{ticker}\n");
            sb.Append($"Current Price: ${stockObject.CurrentPrice}\n");
            sb.Append($"Open Price: ${stockObject.OpenPrice}\n");

            await context.RespondAsync(sb.ToString());
        }

        [Command("summary")]
        [Description("Overall information about a stock")]
        public async Task SummaryCommand(CommandContext context)
        {
            await context.RespondAsync("Enter a stock symbol after the !summary command");
        }

        [Command("summary")]
        [Description("Overall information about a stock")]
        public async Task SummaryCommand(CommandContext context, string ticker)
        {
            await context.RespondAsync("Not supported yet");
        }

        [Command("trending")]
        [Description("Top stocks on Stocktwits")]
        public async Task TrendingCommand(CommandContext context, int count = 10)
        {
            var res = client.GetStringAsync($"https://api.stocktwits.com/api/2/trending/symbols.json");
            var msg = await res;

            StTrendingObject trendingObject = JsonSerializer.Deserialize<StTrendingObject>(msg);
            var results = trendingObject.Symbols.Take(count);

            StringBuilder sb = new StringBuilder("ST Trending\n");
            sb.Append("------------");

            foreach (var item in results)
            {
                sb.Append($"\n{item.Symbol}   Watch Count: {item.WatchCount}");
            }
            await context.RespondAsync(sb.ToString());
        }
    }
    
}
