using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;
using matrix.Models.Entidades;

namespace matrix.Data.Repository
{
    public class ServicoRepository : Repository<Servicos>, IPostagemRepository
    {
        protected readonly cronosContext _context;
        public ServicoRepository(cronosContext context) : base(context)
        {
        }
        public void Atualizar(Postagem entidade)
        {
            throw new NotImplementedException();
        }

        public void CriarNovo(Postagem entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Postagem entidade)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public override Servicos ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Servicos> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool Salvar(Postagem entidade)
        {
            throw new NotImplementedException();
        }

        Postagem IRepository<Postagem>.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<Postagem> IRepository<Postagem>.ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
