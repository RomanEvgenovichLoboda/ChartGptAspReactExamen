using ChartGptAspReactExamen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChartGptAspReactExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
       Context context = new Context();
        [HttpPost("Registration")]
        public ActionResult Registr(MyData data)
        {
            UserModel? user = context.UserModels.FirstOrDefault((e)=>e.Login == data.Login);
            if (user == null)
            {
                context.UserModels.Add(new UserModel(data));
                context.SaveChanges();
                return Ok("Registrated");
            }
            else
            {
                return Conflict("User Exists!");
            }
            
        }
        [HttpPost("Autorisation")]
        public ActionResult Autoris(MyData data)
        {
            UserModel? user = context.UserModels.FirstOrDefault((e) => e.Login == data.Login && e.Password == data.Password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
