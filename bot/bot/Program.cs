using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot
{
    internal class Program
    {
        public static TelegramBotClient Client;
        static void Main(string[] args)
        {
           TelegramBotClient Client = new TelegramBotClient("6613033253:AAFJ754ejKtDCiJgo6zbyiWNK5lTu_TwypA");
            Client.StartReceiving(UpdateHandler, ErrorHandler);
            Console.WriteLine("ok");
            Console.ReadKey();
            //Client.OnMessage += Client_OnMessage;
            //Client.StartReceiving();
            //Thread.Sleep(-1);
        }

        private static Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            string responseMessage = (update.Message.Text == "/hello") ? "Hello word" : "not";
            await client.SendTextMessageAsync(update.Message.Chat.Id, responseMessage);
        }

        //private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        //{
        //   var id=e.Message.Chat.Id;
        //    var text=e.Message.Text;
        //    Client.SendTextMessageAsync(id, $"You said :{text}");
        //}
    }
}
