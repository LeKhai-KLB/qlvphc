using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}