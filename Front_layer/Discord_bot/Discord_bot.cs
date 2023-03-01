using Discord;
using Discord.WebSocket;
using Bot_package;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Discord_bot
{

    class Discord_bot
    {

        private DiscordSocketClient client = new DiscordSocketClient();

        static void Main(string[] args)
            => new Discord_bot().MainAsync().GetAwaiter().GetResult();

        async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandHandler;
            IToken token_maker = new Bot_package.Token();
            var token = token_maker.get_token("select token from assistant_sets.tokens where botname = \'Azumi\' and platformname = \'Discord\'");

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadLine();
        }


        private Task CommandHandler(SocketMessage msg)
        {
            if (msg.Content != null)
            {
                IMonitor mmd = new MessageMonitorDiscord(msg.Content);
                if (!msg.Author.IsBot)
                {
                    msg.Channel.SendMessageAsync(mmd.monitor());
                }
            }
            return Task.CompletedTask;
        }
    }
}