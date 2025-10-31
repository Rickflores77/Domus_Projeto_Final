using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Domus_Projeto.Controllers
{
    public class MoradorController : Controller
    {


  public IActionResult Dashboard()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Dashboard";
        return View();
    }

    public IActionResult Financas()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Financas";
        return View();
    }

    public IActionResult Reservas()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Reservas";
        return View();
    }

    public IActionResult Documentos()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Documentos";
        return View();
    }

    public IActionResult Visitantes()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Visitantes";
        return View();
    }

    public IActionResult Mensagens()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Mensagens";
        return View();
    }

    public IActionResult Configuracoes()
    {
        ViewData["Role"] = "Morador";
        ViewData["Active"] = "Configuracoes";
        return View();
    }

    }
}