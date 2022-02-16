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

            CreateMap<Postagem, PostagemViewModel>()
                .ForMember(
                view => view.NomePessoa,
                entity => entity.MapFrom(src => src.Pessoa.UserName)
                );

            CreateMap<PostagemViewModel, Postagem>();

            CreateMap<Pessoa, PessoaViewModel>()
                .ForMember(
                view => view.NomePessoa,
                entity => entity.MapFrom(src => src.UserName)
                );

            CreateMap<PessoaViewModel, Pessoa>();
        }
    }
}
