using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YandexTest.Business.Module.Contract;

namespace YandexTest.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected async Task<IActionResult> CallWithErrorHandlingAsync<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action();

                return Json(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ExceptionResponse { Message = ex.Message });
            }
        }

        protected IActionResult CallWithErrorHandling<T>(Func<T> action)
        {
            try
            {
                var result = action();

                return Json(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ExceptionResponse { Message = ex.Message });
            }
        }
    }
}
