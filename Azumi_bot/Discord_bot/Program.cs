using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

public class Program
{
     static DiscordSocketClient _client;
     static BaseSocketClient _baseSocketClient;
     static Task ditme(LogMessage msg) 
     { 
         Console.WriteLine(msg.ToString());
         return Task.CompletedTask;
     }
    
     public static async  Task Main()
     {
         _baseSocketClient = new DiscordShardedClient();
         _client = new DiscordSocketClient();
         _client.Log += ditme;
         _baseSocketClient.Log += ditme;
         var token = "MTA0ODQ5NTY4MDQ3OTU4MDIzMA.GOH65o.juuA4O3T_O0_fnBJIKUztcxE7FPwLiwy6x3r3c";
         await _client.LoginAsync(TokenType.Bot, token);
         await _client.StartAsync();
         await Task.Delay(-1);
     }
}