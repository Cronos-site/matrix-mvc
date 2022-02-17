using System.ComponentModel.DataAnnotations;

namespace matrix.Models.Entidades
{
    public class Postagem
    {
        [Key]
        public int idPost { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime Date { get; set; }
        public bool mostraPagInicial { get; set; }
        public string Resumo { get; set; }
        public string? LinkImagemPostagem { get; set; }
        public string PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
