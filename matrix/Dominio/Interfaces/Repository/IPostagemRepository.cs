using matrix.Models.Entidades;

namespace matrix.Dominio.Interfaces.Repository
{
    public interface IPostagemRepository : IRepository<Postagem>
    {
        List<Postagem> ObterPostagensPaginaPrincipal();
        DateTime ObterDate(int idPost);
    }
}
