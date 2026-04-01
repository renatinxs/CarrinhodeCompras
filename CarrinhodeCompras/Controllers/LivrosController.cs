using Microsoft.AspNetCore.Mvc;

namespace CarrinhodeCompras.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
