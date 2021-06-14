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

            var stringTask = client.GetStringAsync($"https://finnhub.io/api/v1/quote?symbol={ticker}&token={stockToken}");
            var msg = await stringTask;

            StockObject stockObject = JsonSerializer.Deserialize<StockObject>(msg);

            StringBuilder response = new StringBuilder($"{ticker}\n");
            response.Append($"Current Price: ${stockObject.CurrentPrice}\n");
            response.Append($"Open Price: ${stockObject.OpenPrice}\n");

            await context.RespondAsync(response.ToString());
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

    }
    
}
