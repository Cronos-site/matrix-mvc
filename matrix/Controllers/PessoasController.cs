using AutoMapper;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace matrix.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public PessoasController(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaPessoas = _pessoaRepository.ObterTodos();
            List<PessoaViewModel> listViewPessoa = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listViewPessoa);
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
