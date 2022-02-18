using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace matrix.Data.Repository
{
    public class ServicoRepository : Repository<Servicos>, IServicoRepository
    {
       
        public ServicoRepository(cronosContext context) : base(context)
        {
        }

        public override List<Servicos> ObterTodos()
        {
            return _context.Servicos.Include(p => p.Equipe).ToList();
        }

        public override Servicos ObterPorId(int id)
        {
            return _context.Servicos
                .Include(p => p.Equipe)
                .Where(s => s.IdServico == id)
                .First();
        }

        public override bool Exists(int id)
        {
            return _context.Servicos.Any(e => e.Equipe.IdEquipe == id);
        }

        public List<Servicos> ObterServicosPaginaInicial()
        {
            return _context.Servicos.Include(p => p.Equipe).Where(s => s.MostraPagInicial == true).ToList();
        }
    }
}
