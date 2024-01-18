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

    
    //                          Text
    
    // Message sentMessage = await botClient.SendTextMessageAsync(
    //     chatId: chatId,
    //     text: "Hello, World!",
    //     cancellationToken: cancellationToken);

    
    //                          Sticker
    
    // Message sentMessage = await botClient.SendStickerAsync(
    //     chatId: chatId,
    //     sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"),
    //     cancellationToken: cancellationToken);
    
    
    //                          Video
    
    // Message sentMessage = await botClient.SendVideoAsync(
    //     chatId: chatId,
    //     video: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"),
    //     cancellationToken: cancellationToken);

    
    //                          text message with link button
    
    // Message sentMessage = await botClient.SendTextMessageAsync(
    //     chatId: chatId,
    //     text: "Trying *all the parameters* of `sendMessage` method",
    //     parseMode: ParseMode.MarkdownV2,
    //     disableNotification: true,
    //     replyToMessageId: update.Message.MessageId,
    //     replyMarkup: new InlineKeyboardMarkup(
    //         InlineKeyboardButton.WithUrl(
    //             text: "Check sendMessage method",
    //             url: "https://www.youtube.com/")),
    //     cancellationToken: cancellationToken);

    
    //                          Photo and Sticker Messages
    
    // Message sentMessage = await botClient.SendPhotoAsync(
    //     chatId: chatId,
    //     photo: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
    //     caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
    //     parseMode: ParseMode.Html,
    //     cancellationToken: cancellationToken);

    
    //                          Sticker id
    
    // Message message1 = await botClient.SendStickerAsync(
    //     chatId: chatId,
    //     sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"),
    //     cancellationToken: cancellationToken);
    //
    // Message message2 = await botClient.SendStickerAsync(
    //     chatId: chatId,
    //     sticker: InputFile.FromFileId(message1.Sticker!.FileId),
    //     cancellationToken: cancellationToken);

    
    
    //                          Audio
    
    // Message sentMessage = await botClient.SendAudioAsync(
    //     chatId: chatId,
    //     audio: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"),
    //     /*
    //     performer: "Joel Thomas Hunger",
    //     title: "Fun Guitar and Ukulele",
    //     duration: 91, // in seconds
    //     */
    //     cancellationToken: cancellationToken);
    
    
    //                          Video & thumbnail
    
    // Message sentMessage = await botClient.SendVideoAsync(
    //     chatId: chatId,
    //     video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
    //     thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
    //     supportsStreaming: true,
    //     cancellationToken: cancellationToken);

    
    //                          Multi Image
    
    // Message[] messages = await botClient.SendMediaGroupAsync(
    //     chatId: chatId,
    //     media: new IAlbumInputMedia[]
    //     {
    //         new InputMediaPhoto(
    //             InputFile.FromUri("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg")),
    //         new InputMediaPhoto(
    //             InputFile.FromUri("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg")),
    //     },
    //     cancellationToken: cancellationToken);

    
    //                          Doc
    
    // Message sentMessage = await botClient.SendDocumentAsync(
    //     chatId: chatId,
    //     document: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
    //     caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
    //     parseMode: ParseMode.Html,
    //     cancellationToken: cancellationToken);


    //                          Animation
    
    // Message sentMessage = await botClient.SendAnimationAsync(
    //     chatId: chatId,
    //     animation: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-waves.mp4"),
    //     caption: "Waves",
    //     cancellationToken: cancellationToken);

    
    //                          Poll Message
    
    // Message pollMessage = await botClient.SendPollAsync(
    //     chatId: "@channel_name",
    //     question: "Did you ever hear the tragedy of Darth Plagueis The Wise?",
    //     options: new[]
    //     {
    //         "Yes for the hundredth time!",
    //         "No, who`s that?"
    //     },
    //     cancellationToken: cancellationToken);

    
    //                          Contact
    
    // Message sentMessage = await botClient.SendContactAsync(
    //     chatId: chatId,
    //     phoneNumber: "+1234567890",
    //     firstName: "Han",
    //     lastName: "Solo",
    //     cancellationToken: cancellationToken);
    
    
    //                         Location
    
    // Message sentMessage = await botClient.SendVenueAsync(
    //     chatId: chatId,
    //     latitude: 50.0840172f,
    //     longitude: 14.418288f,
    //     title: "Man Hanging out",
    //     address: "Husova, 110 00 Staré Město, Czechia",
    //     cancellationToken: cancellationToken);

    
    //                          Location_2
    
    // Message sentMessage = await botClient.SendLocationAsync(
    //     chatId: chatId,
    //     latitude: 33.747252f,
    //     longitude: -112.633853f,
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