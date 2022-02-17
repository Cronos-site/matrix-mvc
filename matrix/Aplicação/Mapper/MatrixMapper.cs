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
                view => view.NomeEquipe,
                entity => entity.MapFrom(src => src.Equipe.NomeEquipe)
                );
                
            CreateMap<ServicoViewModel, Servicos>();

            CreateMap<Postagem, PostagemViewModel>()
                .ForMember(
                view => view.NomePessoa,
                entity => entity.MapFrom(src => src.Pessoa.UserName))
                .ForMember(
                view => view.Date,
                entity => entity.MapFrom(src => src.Date.ToString("dd MMMM yyyy"))
                );

            CreateMap<PostagemViewModel, Postagem>();

            CreateMap<Pessoa, PessoaViewModel>()
                .ForMember(
                view => view.NomePessoa,
                entity => entity.MapFrom(src => src.UserName))
                .ForMember(
                view => view.NomeEquipe,
                entity => entity.MapFrom(src => src.Equipe.NomeEquipe)
                );

            CreateMap<PessoaViewModel, Pessoa>();
        }
    }
}
