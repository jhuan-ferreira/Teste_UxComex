using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_UxComex.Data;
using Teste_UxComex.Models;
using Teste_UxComex.Models.ViewModel;

namespace Teste_UxComex.Controllers
{
    public class EnderecoesController : Controller
    {
        private readonly UxComexContext _context;

        public EnderecoesController(UxComexContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Enderecos.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }


        public IActionResult Create()
        {

            var clientes = _context.Clientes.ToList();

            EnderecoClientesViewModel enderecoClientesViewModel = new EnderecoClientesViewModel { Cliente = clientes };
            
            return View(enderecoClientesViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Logadouro,Numero,Cep,Cidade,Estado,ClienteId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            var clientes = _context.Clientes.ToList();
            EnderecoClientesViewModel enderecoClientesViewModel = new EnderecoClientesViewModel { Cliente = clientes, Endereco = endereco };

            return View(enderecoClientesViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logadouro,Numero,Cep,Cidade,Estado,ClienteId")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return RedirectToRoute(new { Controller = "Clientes", Action = "Edit", Id = endereco.ClienteId.ToString() });
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
