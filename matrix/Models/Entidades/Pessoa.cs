using Microsoft.AspNetCore.Identity;

namespace matrix.Models.Entidades
{
    public class Pessoa : IdentityUser
    {
        public int EquipeId { get; set; }
        public string? linkGitHub { get; set; }
        public string? linkLinkedin { get; set; }
        public virtual Equipe Equipe { get; set; }

    }
}
