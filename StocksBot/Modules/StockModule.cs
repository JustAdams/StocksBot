using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using StocksBot.Items;
using System.Text;

namespace StocksBot.Modules
{
    class StockModule : BaseCommandModule
    {
        private static readonly HttpClient client = new();

        private readonly string stockToken = System.IO.File.ReadAllLines(@"D:\\ASP_NET\\DiscordBot\\StocksBot\\tokens.txt")[1];

        /// <summary>
        /// Check current and open price
        /// </summary>
        /// <param name="ticker">Stock ticker</param>
        /// <returns></returns>
        [Command("price")]
        public async Task TickerCommand(CommandContext context, string ticker)
        {
            ticker = ticker.ToUpper();

            var stringTask = client.GetStringAsync($"https://finnhub.io/api/v1/quote?symbol={ticker}&token={stockToken}");
            var msg = await stringTask;

            StockObject stockObject = JsonSerializer.Deserialize<StockObject>(msg);

            StringBuilder response = new StringBuilder($"{ticker}\n");
            response.Append($"Current Price: ${stockObject.CurrentPrice}\n");
            response.Append($"Open Price: ${stockObject.OpenPrice}\n");

            await context.RespondAsync(response.ToString());
        }

        /// <summary>
        /// Get an overview of a stock with its current price, volume, and short interest
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ticker"></param>
        /// <returns></returns>
        [Command("summary")]
        public async Task SummaryCommand(CommandContext context, string ticker)
        {
            await context.RespondAsync("Not supported yet");
        }

    }
}
