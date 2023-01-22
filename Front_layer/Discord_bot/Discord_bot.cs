using System;
using Discord;
using Discord.WebSocket;
using Bot_package;

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

            var token = "MTA0ODQ5NTY4MDQ3OTU4MDIzMA.GTwzpX.QC_3z-50mLPgeqrEvtM0lA0gsl_MTlNi-zEPPM";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadLine();
        }


        private Task CommandHandler(SocketMessage msg)
        {
            IMonitor mmd = new MessageMonitorDiscord(msg.Content);
            if (!msg.Author.IsBot)
            {

                msg.Channel.SendMessageAsync(mmd.monitor());
            }
            return Task.CompletedTask;
        }
    }
}