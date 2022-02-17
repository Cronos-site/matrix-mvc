using System.ComponentModel.DataAnnotations;

namespace matrix.Models.Entidades
{
    public class Equipe
    {
        [Key]
        public int IdEquipe{ get; set; }
        public string NomeEquipe{ get; private set; }
        public virtual List<Pessoa> Pessoas { get; set; }
        
    }
}
