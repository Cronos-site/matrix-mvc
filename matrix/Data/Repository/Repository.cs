using matrix.Dominio;
using matrix.Dominio.Interfaces.Repository;

namespace matrix.Data.Repository
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly cronosContext _context;
        public Repository(cronosContext context)
        {
            _context = context;
        }
        public void Atualizar(T entidade)
        {
            _context.Update(entidade);
        }

        public void CriarNovo(T entidade)
        {
            _context.Add(entidade);
        }

        public void Deletar(T entidade)
        {
            _context.Remove(entidade);
        }

        public abstract bool Exists(int id);

        public abstract T ObterPorId(int id);

        public abstract List<T> ObterTodos();

        public bool Salvar()
        {
            return _context.SaveChanges() > 0;

        }
    }
}
