using DSharpPlus;
using DSharpPlus.CommandsNext;
using StocksBot.Modules;
using System;
using System.Threading.Tasks;

namespace StocksBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            
            var client = new DiscordClient(new DiscordConfiguration()
            {
                Token = System.IO.File.ReadAllLines(@"D:\\ASP_NET\\DiscordBot\\StocksBot\\tokens.txt")[1],
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<ChatModule>();
            commands.RegisterCommands<StockModule>();
            commands.RegisterCommands<CryptoModule>();

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
