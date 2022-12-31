using System;
using Discord;
using Discord.WebSocket;
using Bot_package;

namespace Discord_bot
{
    
    class Discord_bot
    {
        private static MessageMonitorDiscord mmd = new MessageMonitorDiscord();
        private DiscordSocketClient client = new DiscordSocketClient();

        static void Main(string[] args)
            => new Discord_bot().MainAsync().GetAwaiter().GetResult();

        async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandHandler;

            var token = "MTA0ODQ5NTY4MDQ3OTU4MDIzMA.GdNJgV.q5CiytYLSRZAMtp3O0O7UA2u2mnhJ9KQraWD2c";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadLine();
        }


        private Task CommandHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
            {
                msg.Channel.SendMessageAsync(mmd.monitor(msg.Content));
            }
            return Task.CompletedTask;
        }
    }
}