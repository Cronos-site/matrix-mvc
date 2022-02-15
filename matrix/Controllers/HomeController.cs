using matrix.Dominio;
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
        private readonly cronosContext _context;

        public HomeController(cronosContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var homeModel = new HomeViewModel();
            var listaServicos = _context.Servicos.Where(servico => servico.MostraPagInicial == true).ToList();
            List<ServicoViewModel> listViewServico = new List<ServicoViewModel>();
            foreach(var item in listaServicos)
            {
                var view = new ServicoViewModel();
                view.Descricao = item.Descricao;
                view.UrlFotoServico = item.UrlFotoServico;
                view.TipoServico = item.TipoServico;

                listViewServico.Add(view);
            }
            var listaPostagem = _context.Postages.Include(p => p.Pessoa).Where(postagem => postagem.mostraPagInicial == true).ToList();
            List<PostagemViewModel> listViewPostagem = new List<PostagemViewModel>();
            foreach(var item in listaPostagem)
            {
                var view = new PostagemViewModel();
                view.Descricao = item.Descricao;
                view.Titulo = item.Titulo;
                view.NomePessoa = item.Pessoa.UserName;
                listViewPostagem.Add(view);
            }

            homeModel.servicos = listViewServico;
            homeModel.Postagens = listViewPostagem;
            return View(homeModel);
        }


    }
}