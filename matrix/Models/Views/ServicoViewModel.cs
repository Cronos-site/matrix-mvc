using matrix.Models.Entidades;

namespace matrix.Models.Views
{
    public class ServicoViewModel
    {
        public int IdServico { get; set; }
        public string Descricao { get; set; }
        public string TipoServico { get; set; }
        public string? NomeEquipe { get; set; }
        public bool MostraPagInicial { get; set; }
        public int EquipeId { get; set; }
    }
}
