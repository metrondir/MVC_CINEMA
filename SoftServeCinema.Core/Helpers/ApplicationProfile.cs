using AutoMapper;
using SoftServeCinema.Core.DTOs.Actors;
using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.DTOs.Genres;
using SoftServeCinema.Core.DTOs.Movies;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Core.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<GenreEntity, GenreDTO>().ReverseMap();
            CreateMap<GenreEntity, GenreWithMoviesDTO>()
                .ForMember(
                    dest => dest.Movies,
                    opt => opt.MapFrom(src => src.Movies)
                );

            CreateMap<TagEntity, TagDTO>().ReverseMap();
            CreateMap<TagEntity, TagWithMoviesDTO>()
                .ForMember(
                    dest => dest.Movies,
                    opt => opt.MapFrom(src => src.Movies)
                );

            CreateMap<ActorEntity, ActorDTO>().ReverseMap();
            CreateMap<ActorEntity, ActorWithMoviesDTO>()
                .ForMember(
                    dest => dest.Movies,
                    opt => opt.MapFrom(src => src.Movies)
                );

            CreateMap<DirectorEntity, DirectorDTO>().ReverseMap();
            CreateMap<DirectorEntity, DirectorWithMoviesDTO>()
                .ForMember(
                    dest => dest.Movies,
                    opt => opt.MapFrom(src => src.Movies)
                );

            CreateMap<MovieEntity, MovieDTO>()
                .ForMember(
                    dest => dest.Genres,
                    opt => opt.MapFrom(src => src.Genres)
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.Tags)
                )
                .ForMember(
                    dest => dest.Directors,
                    opt => opt.MapFrom(src => src.Directors)
                );

            //CreateMap<MovieEntity, MovieFullDTO>().ReverseMap();


            //CreateMap<PhoneDTO, Phone>();

            //CreateMap<Phone, PhoneDTO>()
            //    .ForMember(dest => dest.ColorName, act => act.MapFrom(src => src.Color.Name));

            //CreateMap<Color, ColorDTO>().ReverseMap();
        }
    }
}
