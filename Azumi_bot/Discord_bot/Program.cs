using Discord.Gateway;

public class Program
{
    private DiscordSocketClient _client;
    
     public static Task MainAsync()
     {
       _client = new DiscordSocketClient();
       _client.Log += Log;
       var token = "token";
       await _client.LoginAsync(TokenType.Bot, token);
       await _client.StartAsync();
       await Task.Delay(-1);
     }
}