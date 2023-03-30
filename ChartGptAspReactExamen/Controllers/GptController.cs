using Microsoft.AspNetCore.Mvc;
using OpenAI_API;

namespace ChartGptAspReactExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GptController : Controller
    {
        [HttpGet("SendText")]
        public  ActionResult SendText(string text)
        {
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication("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", "org-qj8lijI31tVoP5tIORKbLvQl"));
            var result = api.Completions.GetCompletion(text).Result;
            return Ok(result);
        }
    }
}
