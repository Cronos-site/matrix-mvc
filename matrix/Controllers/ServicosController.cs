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
using Microsoft.AspNetCore.Authorization;

namespace matrix.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IEquipeRepository _equipeRepository;
        private readonly UserManager<Pessoa> _userManager;
        private readonly IMapper _mapper;


        public ServicosController(IServicoRepository servicoRepository, IMapper mapper, IEquipeRepository equipeRepository, UserManager<Pessoa> userManager)
        {
            _servicoRepository = servicoRepository;
            _equipeRepository = equipeRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            var listaServicos = _servicoRepository.ObterTodos();
            List<ServicoViewModel> listViewServico = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listViewServico);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_equipeRepository.ObterTodos(), "IdEquipe", "NomeEquipe");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = _servicoRepository.ObterPorId(id);
            var servicoModel = _mapper.Map<ServicoViewModel>(servicos);
            if (servicoModel == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_equipeRepository.ObterTodos(), "IdEquipe", "NomeEquipe", servicoModel.EquipeId);
            return View(servicoModel);
        }


        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.IdServico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var servicoModel = _mapper.Map<Servicos>(servicoViewModel);
                    _servicoRepository.Atualizar(servicoModel);
                    _servicoRepository.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_servicoRepository.Exists(servicoViewModel.IdServico))
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
            //ViewData["EquipeId"] = new SelectList(_equipeRepository.ob, "IdEquipe", "IdEquipe", servicos.EquipeId);
            return View(servicoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicos = _servicoRepository.ObterPorId(id);
            _servicoRepository.Deletar(servicos);
            _servicoRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult ListaServicos()
        {
            var listaServicos = _servicoRepository.ObterTodos();
            var listViewServicos = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listViewServicos);
        }
    }
}
