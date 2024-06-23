using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Book, BookWithDetails>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Publisher.Block.Name))
                .ForMember(dest => dest.HallNumber, opt => opt.MapFrom(src => src.Publisher.Block.Hall.Id))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.Category.Name)))
                .ReverseMap();

        }
    }
}
