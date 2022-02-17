using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace matrix.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(cronosContext context):base(context)
        {
        }
        public override List<Pessoa> ObterTodos()
        {
            var equipes = _context.Equipe.Include(p => p.Pessoas);
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach (var item in equipes)
            {
                pessoas.AddRange(item.Pessoas);
            }
            return pessoas;

        }

        public override Pessoa ObterPorId(int id)
        {
            throw new Exception("utilizar identity pra obter pessoa");
        }

        public override bool Exists(int id)
        {
            throw new Exception("utilizar identity pra obter pessoa");
        }
    }
}
