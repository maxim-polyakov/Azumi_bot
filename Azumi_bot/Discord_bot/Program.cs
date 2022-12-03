using System;
using Discord;
using Discord.WebSocket;

namespace Discord_bot
{
    class Program
    {
        private DiscordSocketClient client = new DiscordSocketClient();

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandHandler;

            var token = "";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
            {
                switch (msg.Content)
                {
                    case "!привет":
                        msg.Channel.SendMessageAsync($"Привет,  {msg.Timestamp}");
                        break;
                }
            }
            return Task.CompletedTask;
        }
    }
}