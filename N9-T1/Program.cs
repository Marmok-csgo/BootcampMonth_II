using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

string[] sites = { "Google", "Github", "Telegram", "Wikipedia" };
string[] siteDescriptions =
{
    "Google is a search engine",
    "Github is a git repository hosting",
    "Telegram is a messenger",
    "Wikipedia is an open wiki"
};

var botClient = new TelegramBotClient("6790379954:AAG1zPbDKtnfRhWNAjmTXus2on2AggCwY4g");

using CancellationTokenSource cts = new ();

ReceiverOptions receiverOptions = new ()
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

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Type == UpdateType.InlineQuery)
    {
        await BotOnInlineQueryReceived(botClient, update.InlineQuery!);
    }

    if (update.Type is UpdateType.ChosenInlineResult)
    {
        await BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!);
    }


if (update.Message is not { } message)
        return;
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    // Echo received message text
    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "You said:\n" + messageText,
        cancellationToken: cancellationToken);
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}



async Task BotOnInlineQueryReceived(ITelegramBotClient bot, InlineQuery inlineQuery)
{
    var results = new List<InlineQueryResult>();

    var counter = 0;
    foreach (var site in sites)
    {
        results.Add(new InlineQueryResultArticle(
                $"{counter}", 
                site, 
                new InputTextMessageContent(siteDescriptions[counter]))
        );
        counter++;
    }

    await bot.AnswerInlineQueryAsync(inlineQuery.Id, results);
}

Task BotOnChosenInlineResultReceived(ITelegramBotClient bot, ChosenInlineResult chosenInlineResult)
{
    if (uint.TryParse(chosenInlineResult.ResultId, out var resultId)
        && resultId < sites.Length)
    {
        Console.WriteLine($"User {chosenInlineResult.From} has selected site: {sites[resultId]}");
    }

    return Task.CompletedTask;
}

