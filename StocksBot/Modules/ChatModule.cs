using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace StocksBot.Modules
{
    class ChatModule : BaseCommandModule
    {
        [Command("test")]
        [Description("Check bot status")]
        public async Task GreetCommand(CommandContext context)
        {
            await context.RespondAsync("I'm working");
        }


    }
}
