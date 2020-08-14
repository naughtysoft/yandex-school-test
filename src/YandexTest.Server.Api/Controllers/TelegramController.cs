using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using YandexTest.Business.Module;
using YandexTest.Business.Module.Contract;

namespace YandexTest.Server.Api.Controllers
{
    public class TelegramController : BaseController
    {
        private readonly TelegramModule _telegramModule;

        public TelegramController(
            TelegramModule telegramModule)
        {
            _telegramModule = telegramModule;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> ProcessPushWebhook([FromBody]MessageContract contract)
        {
            return await CallWithErrorHandlingAsync(async () => await _telegramModule.ProcessWebhook(contract));
        }
    }
}
