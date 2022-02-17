using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace matrix.Data.Repository
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(cronosContext context) : base(context)
        {
        }

        public override List<Equipe> ObterTodos()
        {
            var result = _context.Equipe.ToList();
            return result;
        }

        public override Equipe ObterPorId(int id)
        {
            return _context.Equipe.Find(id);
        }

        public override bool Exists(int id)
        {
            return _context.Equipe.Any(e => e.IdEquipe == id);
        }
    }
}
