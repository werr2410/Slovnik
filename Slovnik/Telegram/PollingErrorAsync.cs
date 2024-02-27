using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace _Slovnik {
    partial class TelegramBot {
        private Task PollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cts) {
            var ErrorMessage = exception switch {
                ApiRequestException apiRequestException 
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}