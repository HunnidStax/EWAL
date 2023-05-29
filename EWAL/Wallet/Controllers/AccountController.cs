using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
