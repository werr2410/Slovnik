using System.Runtime.CompilerServices;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _Slovnik {
    partial class TelegramBot {
        private async Task UpdateHandler() {
            _Me = await _Client.GetMeAsync();
            Console.WriteLine($"Bot {_Me.FirstName} have started!");
        

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool
            ReceiverOptions receiverOptions = new() {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            _Client.StartReceiving(
                updateHandler: OnMessageAsync,
                pollingErrorHandler: PollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            Console.WriteLine($"Start listening for @{_Me.Username}...");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}