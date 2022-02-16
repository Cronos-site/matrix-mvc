using AutoMapper;
using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models;
using matrix.Models.Entidades;
using matrix.Models.Views;
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
            var listaServicos = _servicoRepository.ObterTodos();
            List<ServicoViewModel> listViewServico = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            //foreach(var item in listaServicos)
            //{
            //    var view = new ServicoViewModel();
            //    view.Descricao = item.Descricao;
            //    view.UrlFotoServico = item.UrlFotoServico;
            //    view.TipoServico = item.TipoServico;

            //    listViewServico.Add(view);
            //}
            var listaPostagem = _postagemRepository.ObterTodos();
            List<PostagemViewModel> listViewPostagem = _mapper.Map<List<PostagemViewModel>>(listaPostagem);
            //foreach(var item in listaPostagem)
            //{
            //    var view = new PostagemViewModel();
            //    view.Descricao = item.Descricao;
            //    view.Titulo = item.Titulo;
            //    view.NomePessoa = item.Pessoa.UserName;
            //    listViewPostagem.Add(view);
            //}

            homeModel.servicos = listViewServico;
            homeModel.Postagens = listViewPostagem;
            return View(homeModel);
        }


    }
}