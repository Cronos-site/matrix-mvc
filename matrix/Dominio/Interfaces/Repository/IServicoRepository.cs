using matrix.Models.Entidades;

namespace matrix.Dominio.Interfaces.Repository
{
    public interface IServicoRepository : IRepository<Servicos>
    {
        List<Servicos> ObterServicosPaginaInicial();
    }
}
