using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StocksBot.Modules
{
    class CryptoModule : BaseCommandModule
    {
        private static readonly HttpClient client = new();

        private readonly string stockToken = System.IO.File.ReadAllLines(@"D:\\ASP_NET\\DiscordBot\\StocksBot\\tokens.txt")[3];


        [Command("exchanges")]
        public async Task ExchangesCommand(CommandContext context)
        {
            var stringTask = client.GetStringAsync($"https://finnhub.io/api/v1/crypto/exchange?token={stockToken}");
            var msg = await stringTask;

            StringBuilder sb = new();
            sb.Append("Available Exchanges\n");
            sb.Append("--------------\n");
            sb.Append(msg);

            await context.RespondAsync(sb.ToString());
        }

        [Command("crypto")]
        [Description("Get the current price of a crypto, default exchange is Binance")]
        public async Task CryptoPriceCommand(CommandContext context, string symbol)
        {
            await context.RespondAsync("Not implemented yet");
        }
    }
}
