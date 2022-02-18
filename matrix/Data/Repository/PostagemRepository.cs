using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace matrix.Data.Repository
{
    public class PostagemRepository : Repository<Postagem>, IPostagemRepository
    {
        public PostagemRepository(cronosContext context) : base(context)
        {
        }

        public override List<Postagem> ObterTodos()
        {
   
            return _context.Postages.Include(p => p.Pessoa).ToList();
        }

        public override Postagem ObterPorId(int id)
        {
            return _context.Postages
                .Include(p => p.Pessoa)
                .Where(postagem => postagem.idPost == id)
                .First();
        }

        public override bool Exists(int id)
        {
            return _context.Postages.Any(e => e.idPost == id);
        }

        public List<Postagem> ObterPostagensPaginaPrincipal()
        {

            return _context.Postages.Include(p => p.Pessoa).Where(s => s.mostraPagInicial == true).ToList();
        }

        public DateTime ObterDate(int idPost)
        {
            var obj = ObterPorId(idPost);
            return obj.Date;
        }

    }
}
