using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.applicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
