using AutoMapper;
using BookStore.Domain.Request;
using BookStore.Domain.Response;
using BookStore.Domain.Response.AuthorResponse;
using BookStore.Domain.Response.BookResponse;
using BookStore.Entities.Models;

namespace BookStore.API.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //~ For Book Operations
            CreateMap<Author, BookAuthorResponseDTO>();
            CreateMap<Genre, BookGenreResponseDTO>();
            //* source => target
            CreateMap<Book, BookResponseDTO>();
                            // .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                            // .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));   

            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();

            //~ For Author Operations

            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<AuthorUpdateDTO, Author>();
            CreateMap<Genre, AuthorGenreResponseDTO>();
            CreateMap<Book, AuthorBookResponseDTO>();
            CreateMap<Author, AuthorResponseDTO>();

            //~ For Genre Operations
        }
    }
}