using Microsoft.AspNetCore.Mvc;

namespace VTC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
