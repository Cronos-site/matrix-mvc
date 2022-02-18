#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using matrix.Dominio;
using matrix.Models.Entidades;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Views;
using AutoMapper;

namespace matrix.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;


        public ServicosController(IServicoRepository servicoRepository, IMapper mapper, IEquipeRepository equipeRepository)
        {
            _servicoRepository = servicoRepository;
            _equipeRepository = equipeRepository;
            _mapper = mapper;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            var listaServicos = _servicoRepository.ObterTodos();
            List<ServicoViewModel> listViewServico = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listViewServico);
        }

        // GET: Servicos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var servicos = await _context.Servicos
        //        .Include(s => s.Equipe)
        //        .FirstOrDefaultAsync(m => m.IdServico == id);
        //    if (servicos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(servicos);
        //}

        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_equipeRepository.ObterTodos(), "IdEquipe", "NomeEquipe");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicoViewModel servicoView)
        {
            if (ModelState.IsValid)
            {
                var servicoModel = _mapper.Map<Servicos>(servicoView);
                _servicoRepository.CriarNovo(servicoModel);
                _servicoRepository.Salvar();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_servicoRepository.ObterTodos(), "IdEquipe", "IdEquipe", servicoView.EquipeId);
            return View(servicoView);
        }

        //// GET: Servicos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var servicos = await _context.Servicos.FindAsync(id);
        //    if (servicos == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["EquipeId"] = new SelectList(_context.Equipe, "IdEquipe", "IdEquipe", servicos.EquipeId);
        //    return View(servicos);
        //}

        //// POST: Servicos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdServico,Descricao,TipoServico,UrlFotoServico,MostraPagInicial,EquipeId")] Servicos servicos)
        //{
        //    if (id != servicos.IdServico)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(servicos);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ServicosExists(servicos.IdServico))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EquipeId"] = new SelectList(_context.Equipe, "IdEquipe", "IdEquipe", servicos.EquipeId);
        //    return View(servicos);
        //}

        //// GET: Servicos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var servicos = await _context.Servicos
        //        .Include(s => s.Equipe)
        //        .FirstOrDefaultAsync(m => m.IdServico == id);
        //    if (servicos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(servicos);
        //}

        //// POST: Servicos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var servicos = await _context.Servicos.FindAsync(id);
        //    _context.Servicos.Remove(servicos);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ServicosExists(int id)
        //{
        //    return _context.Servicos.Any(e => e.IdServico == id);
        //}

        public IActionResult ListaServicos()
        {
            var listaServicos = _servicoRepository.ObterTodos();
            var listViewServicos = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listViewServicos);
        }
    }
}
