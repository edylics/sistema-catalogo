﻿using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.applicacionWeb.Controllers
{
    public class PlantillaController : Controller
    {
        public IActionResult EnviarClave( string correo , string clave)
        {


            ViewData["Correo"] = correo;
            ViewData["Clave"] = clave;
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";
            return View();
        }


        public IActionResult ReestablecerClave(string clave)
        {

            ViewData["Clave"] = clave;

            return View();
        }
    }
}
