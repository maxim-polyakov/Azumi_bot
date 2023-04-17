using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Bot_package;
using Microsoft.Extensions.Hosting;

namespace TelegramBot
{
    class TelegramBot
    {
        private static IToken token_maker = new Bot_package.Token();

        private static ITelegramBotClient bot = new TelegramBotClient(token_maker.get_token("select token from assistant_sets.tokens where botname = \'Azumi\' and platformname = \'Telegram\'"));

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text != null)
                {
                    IMonitor mmt = new MessageMonitorTelegram(message.Text);
                    await botClient.SendTextMessageAsync(message.Chat, mmt.monitor());
                }
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
             // Add configuration, logging, ...
            .ConfigureServices((hostContext, services) =>
            {
                var cts = new CancellationTokenSource();
                var cancellationToken = cts.Token;
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = { },
                };
                bot.StartReceiving(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    receiverOptions,
                    cancellationToken
                );
            });
            await hostBuilder.RunConsoleAsync();
        }
    }
}