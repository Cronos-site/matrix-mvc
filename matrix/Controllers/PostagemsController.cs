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
    public class PostagemsController : Controller
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly IMapper _mapper;

        public PostagemsController(IPostagemRepository postagemRepository, IMapper mapper)
        {
            _postagemRepository = postagemRepository;
            _mapper = mapper;

        }

        // GET: Postagems
        public async Task<IActionResult> Index()
        {
            var listaPostagem = _postagemRepository.ObterTodos();
            List<PostagemViewModel> listViewPostagem = _mapper.Map<List<PostagemViewModel>>(listaPostagem);
            return View(listViewPostagem);
        }

        // GET: Postagems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Postagem = _postagemRepository.ObterPorId(id);
            var postagemViewModel = _mapper.Map<PostagemViewModel>(Postagem); 
            return View(postagemViewModel);
        }

        // GET: Postagems/Create
        public IActionResult Create()
        {
            //ViewData["PessoaId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Postagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPost,Descricao,Titulo,Date,mostraPagInicial,PessoaId")] Postagem postagem)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(postagem);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["PessoaId"] = new SelectList(_context.Users, "Id", "Id", postagem.PessoaId);
            return View();
        }

        //// GET: Postagems/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var postagem = await _context.Postages.FindAsync(id);
        //    if (postagem == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["PessoaId"] = new SelectList(_context.Users, "Id", "Id", postagem.PessoaId);
        //    return View(postagem);
        //}

        //// POST: Postagems/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("idPost,Descricao,Titulo,Date,mostraPagInicial,PessoaId")] Postagem postagem)
        //{
        //    if (id != postagem.idPost)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(postagem);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PostagemExists(postagem.idPost))
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
        //    ViewData["PessoaId"] = new SelectList(_context.Users, "Id", "Id", postagem.PessoaId);
        //    return View(postagem);
        //}

        //// GET: Postagems/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var postagem = await _context.Postages
        //        .Include(p => p.Pessoa)
        //        .FirstOrDefaultAsync(m => m.idPost == id);
        //    if (postagem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(postagem);
        //}

        //// POST: Postagems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var postagem = await _context.Postages.FindAsync(id);
        //    _context.Postages.Remove(postagem);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PostagemExists(int id)
        //{
        //    return _context.Postages.Any(e => e.idPost == id);
        //}
    }
}
