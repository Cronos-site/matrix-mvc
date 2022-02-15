using matrix.Models.Entidades;

namespace matrix.Models.Views
{
    public class HomeViewModel
    {
        public List<ServicoViewModel> servicos { get; set; }
        public List<PostagemViewModel> Postagens { get; set; }
    }
}
