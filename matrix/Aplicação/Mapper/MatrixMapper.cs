using AutoMapper;
using matrix.Models.Entidades;
using matrix.Models.Views;

namespace matrix.Aplicação.Mapper
{
    public class MatrixMapper : Profile
    {
        public MatrixMapper()
        {
            CreateMap<Servicos, ServicoViewModel>()
                .ForMember(
                view => view.NomeServico,
                entity => entity.MapFrom(src => src.equipe.NomeEquipe)
                );
                
            CreateMap<ServicoViewModel, Servicos>();
        }
    }
}
