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

            var token = "MTA0ODQ5NTY4MDQ3OTU4MDIzMA.GhQ3T5.i3cG1U9wOm6etYEfo2VfvNqE9zbl1zqZcQAWEo";

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