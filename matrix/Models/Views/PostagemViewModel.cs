using matrix.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace matrix.Models.Views
{
    public class PostagemViewModel
    {
        public int idPost { get; set; }
        [Required]
        public string? Descricao { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public bool mostraPagInicial { get; set; }
        public string? Date { get; set; }
        public string LinkImagemPostagem { get; set; }
        public string? NomePessoa { get; set; }

    }
}
