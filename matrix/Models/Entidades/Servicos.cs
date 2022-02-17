using System.ComponentModel.DataAnnotations;

namespace matrix.Models.Entidades
{
    public class Servicos
    {
        [Key]
        public int IdServico { get; set; }
        public string Descricao { get; set; }
        public string TipoServico { get; set; }
        public bool MostraPagInicial { get; set; }
        public int EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
