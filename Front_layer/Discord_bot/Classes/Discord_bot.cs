using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Bot_package;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Discord.Commands;
using System.Reflection;
using System.Windows.Input;
using System.Diagnostics;
using System.Xml.Linq;

namespace Discord_bot {
    
    class Discord_bot: IDiscord_bot {
        
        private DiscordSocketClient client = new DiscordSocketClient();

        private CommandService commands;

        private IServiceProvider services;

        private ulong testGuildId;

        public static async Task Main(string[] args)
        {   
            await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {    
                new Discord_bot().MainAsync().GetAwaiter().GetResult();
            })
            .RunConsoleAsync();
        }

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();

            client.Ready += ReadyAsync;

            client.MessageReceived += CommandHandler;

            IToken token_maker = new Bot_package.Token();
            var token = token_maker.get_token("select token from assistant_sets.tokens where botname = \'Azumi\' and platformname = \'Discord\'");

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        public Task CommandHandler(SocketMessage msg)
        {
            if (msg.Content != null)
            {
                IMonitor mmd = new MessageMonitorDiscord(msg.Content);
                if (!msg.Author.IsBot)
                {   
                    var output = mmd.monitor();
                    if(output != string.Empty)
                        msg.Channel.SendMessageAsync(output);
                }
            }
            return Task.CompletedTask;
        }


        private async Task ReadyAsync()
        {
            client.SetActivityAsync(new Game("за сервером", ActivityType.Watching));
        }
    }
}