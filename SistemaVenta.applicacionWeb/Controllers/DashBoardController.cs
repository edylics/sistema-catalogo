using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.applicacionWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
