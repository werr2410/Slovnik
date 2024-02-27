using Telegram.Bot;
using Telegram.Bot.Types;

namespace _Slovnik {
    partial class TelegramBot {
        private TelegramBotClient _Client = new(TOKEN);
        private User _Me = new();  

        public async Task Start() {
            await UpdateHandler();
        }
    }
}