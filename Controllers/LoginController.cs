using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Domus_Projeto.Controllers
{
    public class LoginController : Controller
    {
         // GET: /Login
        public IActionResult Index()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Index(string email, string senha, string tipo)
        {
            if (tipo == "admin" && email == "admin@condominio.com" && senha == "123")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (tipo == "morador" && email == "morador@email.com" && senha == "123")
            {
                return RedirectToAction("Dashboard", "Morador");
            }

            ViewBag.Error = "Credenciais inválidas";
            return View();
        }
    }
}