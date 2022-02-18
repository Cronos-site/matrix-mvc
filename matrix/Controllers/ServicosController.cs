﻿#nullable disable
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicos = _servicoRepository.ObterPorId(id);
            _servicoRepository.Deletar(servicos);
            _servicoRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ListaServicos()
        {
            var listaServicos = _servicoRepository.ObterTodos();
            var listViewServicos = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listViewServicos);
        }
    }
}
