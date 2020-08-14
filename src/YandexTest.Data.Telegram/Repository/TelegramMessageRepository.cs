using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YandexTest.Core.RestBase.Repository;

namespace YandexTest.Data.Telegram.Repository
{
    public class TelegramMessageRepository : RestRepositoryBase
    {
        private readonly string _url = "https://api.telegram.org/bot1303703189:AAF43KsDV0xSBuNMwrq8aeWLHxwj9-h6TCU/";

        public async Task<object> SendMessage(int chatId, string message)
        {
            var r = await Get<object>(_url, $"sendMessage?chat_id={chatId}&text={message}&parse_mode=Markdown", new Dictionary<string, string>());

            return r;
        }

    }
}
