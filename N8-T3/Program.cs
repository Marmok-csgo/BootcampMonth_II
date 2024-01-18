using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6624883534:AAGyyykJOarywf8n0U4kvplvG1QqIJHrDF8");

using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};
        
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening @{me.Username}");
Console.ReadLine();

cts.Cancel();


async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message)
    {
        return;
    }

    if (message.Text is not { } messageText)
    {
        return;
    }

    var chatId = message.Chat.Id;
    
    Console.WriteLine("Received a '{messageText}' message in chat {chatId}.");

    //                          ReplyKeyboardMarkup
    
    // ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    // {
    //     //          Single-row keyboard markup
    //     new KeyboardButton[] { "Help me", "Call me ☎️" },
    //     //          Multi-row keyboard markup
    //     // new KeyboardButton[] { "Help me" },
    //     // new KeyboardButton[] { "Call me ☎️" },
    //     //          Request information
    //     // KeyboardButton.WithRequestLocation("Share Location"),
    //     // KeyboardButton.WithRequestContact("Share Contact"),
    // })
    // {
    //     ResizeKeyboard = true
    // };
    //
    // Message sentMessage = await botClient.SendTextMessageAsync(
    //     chatId: chatId,
    //     text: "Choose a response",
    //     replyMarkup: replyKeyboardMarkup,
    //     cancellationToken: cancellationToken);
    
    
    //                          InlineKeyboardMarkup

    // InlineKeyboardMarkup inlineKeyboard = new(new[]
    // {
    //     // first row
    //     new []
    //     {
    //         InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
    //         InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
    //     },
    //     // second row
    //     new []
    //     {
    //         InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
    //         InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
    //     },
    // });
    //
    // Message sentMessage = await botClient.SendTextMessageAsync(
    //     chatId: chatId,
    //     text: "A message with an inline keyboard markup",
    //     replyMarkup: inlineKeyboard,
    //     cancellationToken: cancellationToken);

    
    //                      Link buttons
    
    // InlineKeyboardMarkup inlineKeyboard = new(new[]
    // {
    //     InlineKeyboardButton.WithUrl(
    //         text: "Link to the Repository",
    //         url: "https://github.com/TelegramBots/Telegram.Bot")
    // });
    //
    // Message sentMessage = await botClient.SendTextMessageAsync(
    //     chatId: chatId,
    //     text: "A message with an inline keyboard markup",
    //     replyMarkup: inlineKeyboard,
    //     cancellationToken: cancellationToken);

}

Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram Api Error:\n [{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };
    
    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}