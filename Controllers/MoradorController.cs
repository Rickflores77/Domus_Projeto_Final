using Domus_Projeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Domus_Projeto.Models;
namespace Domus_Projeto.Controllers
{
    public class MoradorController : Controller
    {
        private readonly DomusDbContext _context;

        public MoradorController(DomusDbContext context)
        {
            _context = context;
        }

        // ================== DASHBOARD ==================
        public async Task<IActionResult> Dashboard()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Dashboard";

            // Dados resumidos para dashboard
            ViewBag.TotalPendente = await _context.Financas
                                        .Where(f => f.Status == "Pendente")
                                        .SumAsync(f => f.Valor);

            ViewBag.TotalPagoMes = await _context.Financas
                                        .Where(f => f.Data.Month == System.DateTime.Now.Month && f.Status == "Pago")
                                        .SumAsync(f => f.Valor);

            ViewBag.ProximasReservas = await _context.Reservas
                                        .Where(r => r.DataHora >= System.DateTime.Now)
                                        .OrderBy(r => r.DataHora)
                                        .Take(5)
                                        .ToListAsync();

            ViewBag.MensagensRecentes = await _context.Mensagens
                                        .OrderByDescending(m => m.EnviadoEm)
                                        .Take(5)
                                        .ToListAsync();

            return View();
        }

        // ================== FINANÇAS ==================
        public async Task<IActionResult> Financas()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Financas";

            // Buscar todas as contas do morador (simulando MoradorId = 1)
            var contas = await _context.Financas
                                       .Where(f => f.MoradorId == 1)
                                       .ToListAsync();

            return View(contas);
        }

        [HttpPost]
        public async Task<IActionResult> PagarFinanca(int id)
        {
            var financa = await _context.Financas.FindAsync(id);
            if (financa == null) return NotFound();

            financa.Status = "Pago"; // marca como paga
            _context.Update(financa);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = "Pagamento realizado com sucesso!";
            return RedirectToAction(nameof(Financas));
        }

        public IActionResult CriarFinanca() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarFinanca(Financa financa)
        {
            if (ModelState.IsValid)
            {
                financa.Status = "Pendente"; // valor padrão
                _context.Add(financa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Financas));
            }
            return View(financa);
        }

        public async Task<IActionResult> EditarFinanca(int id)
        {
            var financa = await _context.Financas.FindAsync(id);
            if (financa == null) return NotFound();
            return View(financa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarFinanca(int id, Financa financa)
        {
            if (id != financa.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(financa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Financas));
            }
            return View(financa);
        }

        public async Task<IActionResult> DeletarFinanca(int id)
        {
            var financa = await _context.Financas.FindAsync(id);
            if (financa == null) return NotFound();

            _context.Financas.Remove(financa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Financas));
        }

        // ================== RESERVAS ==================
        public async Task<IActionResult> Reservas()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Reservas";

            var areas = await _context.Reservas.OrderBy(r => r.DataHora).ToListAsync();
            return View(areas);
        }

        public IActionResult CriarReserva() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarReserva(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.Status = "Pendente";
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Reservas));
            }
            return View(reserva);
        }

        public async Task<IActionResult> EditarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarReserva(int id, Reserva reserva)
        {
            if (id != reserva.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Reservas));
            }
            return View(reserva);
        }

        public async Task<IActionResult> DeletarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Reservas));
        }

        // ================== MENSAGENS ==================
        public async Task<IActionResult> Mensagens()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Mensagens";

            var mensagens = await _context.Mensagens
                                .OrderByDescending(m => m.EnviadoEm)
                                .ToListAsync();
            return View(mensagens);
        }

        public IActionResult CriarMensagem() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarMensagem(Mensagem msg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mensagens));
            }
            return View(msg);
        }

        public async Task<IActionResult> MarcarLida(int id)
        {
            var msg = await _context.Mensagens.FindAsync(id);
            if (msg == null) return NotFound();

            msg.Lida = true;
            _context.Update(msg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Mensagens));
        }

        public async Task<IActionResult> DeletarMensagem(int id)
        {
            var msg = await _context.Mensagens.FindAsync(id);
            if (msg == null) return NotFound();

            _context.Mensagens.Remove(msg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Mensagens));
        }

        // ================== VISITANTES ==================
        public async Task<IActionResult> Visitantes()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Visitantes";

            var visitantes = await _context.Visitantes
                                .OrderBy(v => v.DataHora)
                                .ToListAsync();
            return View(visitantes);
        }

        public IActionResult CriarVisitante() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarVisitante(Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                visitante.Status = "Agendado";
                _context.Add(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Visitantes));
            }
            return View(visitante);
        }

        public async Task<IActionResult> EditarVisitante(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return NotFound();
            return View(visitante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarVisitante(int id, Visitante visitante)
        {
            if (id != visitante.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Visitantes));
            }
            return View(visitante);
        }

        public async Task<IActionResult> DeletarVisitante(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return NotFound();

            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Visitantes));
        }

        // ================== DOCUMENTOS ==================
        public IActionResult Documentos()
        {
            ViewData["Role"] = "Morador";
            ViewData["Active"] = "Documentos";

            // Pode adicionar lista de documentos do DB futuramente
            return View();
        }
    }
}
