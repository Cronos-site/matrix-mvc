using AutoMapper;
using matrix.Models.Entidades;
using matrix.Models.Views;

namespace matrix.Aplicação.Mapper
{
    public class MatrixMapper : Profile
    {
        public MatrixMapper()
        {
            CreateMap<Servicos, ServicoViewModel>();
            CreateMap<ServicoViewModel, Servicos>();
        }
    }
}
