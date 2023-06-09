using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.applicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
