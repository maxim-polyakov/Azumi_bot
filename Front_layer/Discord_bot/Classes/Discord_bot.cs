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
using System.Text;
using System;

namespace Discord_bot {
    
    class Discord_bot: IDiscord_bot {
        
        private DiscordSocketClient client = new DiscordSocketClient();

        private IServiceProvider services;
        private CommandService commands;
        private ulong testGuildId;


        private string CommandsTrible(string command, string item1, string item2)
        {
            string outstring = string.Empty;
            Dictionary<string, string> info_dict = new Dictionary<string, string>() {
                {"/weather", "True" }
            };
            info_dict.TryGetValue(command, out outstring);
            return outstring;
        }

        private string CommandsDouble(string command, string item)
        {
            string outstring = string.Empty;
            Dictionary<string, string> info_dict = new Dictionary<string, string>() {
                {"/clean", "True"},
                {"/calculate", "True" },
                {"/join", "True" },
                {"/leave", "True" },
                {"/find", "True" },
                {"/start_recording", "True" },
                {"/stop_recording", "True" },
                {"/play_song", "True" },
                {"/pause", "True"},
                {"/stop", "True" },
                {"/queue", "True" },
                {"/resume", "True" },
                {"/weather", "True" }
            };
            info_dict.TryGetValue(command, out outstring);
            return outstring;
        }

        private string CommandsSingle(string command)
        {
            string outstring = string.Empty;
            Dictionary<string, string> info_dict = new Dictionary<string, string>() {
                {"/join", "True" },
                {"/leave", "True" },
                {"/start_recording", "True" },
                {"/stop_recording", "True" },
                {"/pause", "True"},
                {"/stop", "True" },
                {"/queue", "True" },
                {"/resume", "True" },
            };
            info_dict.TryGetValue(command, out outstring);
            return outstring;
        }

        public static async Task Main(string[] args)
        {   
            await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                DiscordSocketClient _client = new DiscordSocketClient();
                CommandService _commands = new CommandService();

                new Discord_bot(_client,_commands).MainAsync().GetAwaiter().GetResult();
            })
            .RunConsoleAsync();
        }

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();

            client.Ready += ReadyAsync;

            client.MessageReceived += HandleCommandAsync;

            IToken token_maker = new Bot_package.Token();
            var token = token_maker.get_token("select token from assistant_sets.tokens where botname = \'Azumi\' and platformname = \'Discord\'");

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        public Discord_bot(DiscordSocketClient _client, CommandService _commands)
        {
            client = _client;
        }

        public async Task HandleCommandAsync(SocketMessage msg) {
            var message = msg as SocketUserMessage;
            int ArgPos = 0;
            if ((message != null) && (!(message.HasCharPrefix('/', ref ArgPos) || message.HasMentionPrefix(client.CurrentUser, ref ArgPos))))
            {
                if (!message.Author.IsBot)
                {
                    IMonitor mmd = new MessageMonitorDiscord(msg.Content);
                    var output = mmd.monitor();
                    if (output != string.Empty)
                        await message.Channel.SendMessageAsync(output);
                }
            }
            else {
                if (message.HasCharPrefix('/', ref ArgPos)) {

                    var str = message.Content;
                    string[] words = str.Split(' ');

                    var output = CommandsSingle(words[0]);

                    if (words.Length == 2)
                    {
                        output = CommandsDouble(words[0], words[1]);
                    }
                    else if (words.Length == 3)
                    {
                        output = CommandsTrible(words[0], words[1], words[2]);
                    }
                    await message.Channel.SendMessageAsync(output);
                }

            }
        }


        private async Task ReadyAsync()
        {
            var str = "за сервером";
            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.UTF8.GetString(bytes);
            client.SetActivityAsync(new Game(str, ActivityType.Watching));
        }
    }
}
