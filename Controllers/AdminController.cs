using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domus_Projeto.Controllers
{
    public class AdminController : Controller
    {
        // Dashboard
        public IActionResult Dashboard()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Dashboard";
            return View();
        }

        // Vistorias
        public IActionResult Vistorias()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Vistorias";
            return View();
        }

        // Mensagens
        public IActionResult Mensagens()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Mensagens";
            return View();
        }

        // Configurações
        public IActionResult Configuracoes()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Configuracoes";
            return View();
        }

        // Finanças
        public IActionResult Financas()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Financas";
            return View();
        }

        // Reservas
        public IActionResult Reservas()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Reservas";
            return View();
        }

        // Documentos
        public IActionResult Documentos()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Documentos";
            return View();
        }

        // Manutenção
        public IActionResult Manutencao()
        {
            ViewData["Role"] = "Admin";
            ViewData["Active"] = "Manutencao";
            return View();
        }
    }
}
