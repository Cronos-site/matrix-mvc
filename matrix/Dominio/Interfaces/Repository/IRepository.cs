namespace matrix.Dominio.Interfaces.Repository
{
    public interface IRepository<T> 
    {
        List<T> ObterTodos();
        T ObterPorId(int id);
        void CriarNovo(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);
        bool Salvar(T entidade);
        bool Exists(int id);
    }
}
