using AutoMapper;
using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models;
using matrix.Models.Entidades;
using matrix.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace matrix.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IPostagemRepository _postagemRepository;
        private readonly IMapper _mapper;
        public HomeController(IServicoRepository servicoRepository, IPostagemRepository postagemRepository, IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _postagemRepository = postagemRepository;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var homeModel = new HomeViewModel();
            var listaServicos = _servicoRepository.ObterServicosPaginaInicial();
            List<ServicoViewModel> listViewServico = _mapper.Map<List<ServicoViewModel>>(listaServicos);

            var listaPostagem = _postagemRepository.ObterPostagensPaginaPrincipal();
            List<PostagemViewModel> listViewPostagem = _mapper.Map<List<PostagemViewModel>>(listaPostagem);


            homeModel.servicos = listViewServico;
            homeModel.Postagens = listViewPostagem;
            return View(homeModel);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Administrador()
        {
            return View();
        }

    }
}