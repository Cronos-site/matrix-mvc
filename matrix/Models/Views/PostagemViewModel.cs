using matrix.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace matrix.Models.Views
{
    public class PostagemViewModel
    {
        [Required]
        public string? Descricao { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime Date { get; set; }
        public string NomePessoa { get; set; }
    }
}
