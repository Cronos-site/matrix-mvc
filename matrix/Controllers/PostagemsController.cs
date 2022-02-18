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
using Microsoft.AspNetCore.Identity;

namespace matrix.Controllers
{
    public class PostagemsController : Controller
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly UserManager<Pessoa> _userManager;
        private readonly IMapper _mapper;

        public PostagemsController(IPostagemRepository postagemRepository, IMapper mapper, UserManager<Pessoa> userManager)
        {
            _postagemRepository = postagemRepository;
            _userManager = userManager;
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
            ViewBag.idPost = new SelectList(_mapper.Map<List<PostagemViewModel>>(_postagemRepository.ObterTodos()), "PostagemViewModel.NomePessoa");
            return View();
        }

        // POST: Postagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(PostagemViewModel postagemView)
        {
            if (ModelState.IsValid)
            {
                var postagemModel = _mapper.Map<Postagem>(postagemView);
                postagemModel.PessoaId = _userManager.GetUserId(User);
                postagemModel.Date = DateTime.Now;
                _postagemRepository.CriarNovo(postagemModel);
                _postagemRepository.Salvar();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idPost"] = new SelectList(_postagemRepository.ObterTodos(), "idPost", "idPost", postagemView.idPost);
            return View(postagemView);
            
        }

        // GET: Postagems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Postagem = _postagemRepository.ObterPorId(id);
            var postagemViewModel = _mapper.Map<PostagemViewModel>(Postagem);
            if (postagemViewModel == null)
            {
                return NotFound();
            }
            
            
            return View(postagemViewModel);
        }

       
        [HttpPost]
       
        public async Task<IActionResult> Edit(int id, PostagemViewModel postagemView)
        {
            if (id != postagemView.idPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     var postagemModel = _mapper.Map<Postagem>(postagemView);
                     postagemModel.PessoaId = _userManager.GetUserId(User);
                     //postagemModel.Date = _postagemRepository.ObterDate(postagemModel.idPost);
                    _postagemRepository.Atualizar(postagemModel);
                    _postagemRepository.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_postagemRepository.Exists(postagemView.idPost))
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
            return View(postagemView);
        }

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

        // POST: Postagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagem = _postagemRepository.ObterPorId(id);
            _postagemRepository.Deletar(postagem);
            _postagemRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ListaPostagens()
        {
            var postagensModel = _postagemRepository.ObterTodos();
            var postagensView = _mapper.Map<List<PostagemViewModel>>(postagensModel);
            return View(postagensView);
        }

    }
}
