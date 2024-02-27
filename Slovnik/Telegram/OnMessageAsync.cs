using Telegram.Bot;
using Telegram.Bot.Types;

namespace _Slovnik {
    partial class TelegramBot {
        private async Task OnMessageAsync(ITelegramBotClient client, Update update, CancellationToken cts) {
            if(update.Message is not { } message) return;
            
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "You said: " + message.Text,
                cancellationToken: cts
            );
        }
    }
}