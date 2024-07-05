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
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Publisher.Block.Name))
                .ForMember(dest => dest.HallNumber, opt => opt.MapFrom(src => src.Publisher.Block.Hall.Id))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.Category.Name)))
                .ReverseMap();

            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.BookCategories, opt => opt.MapFrom(src =>
                src.CategoryIds.Select(id => new BookCategory { CategoryId = id }).ToList()))
                .ReverseMap();

            CreateMap<UsedBookForInsert, UsedBook>().ReverseMap();

            CreateMap<UsedBookDto, UsedBook>().ReverseMap();


            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Block.Name))
                .ReverseMap();

            CreateMap<Publisher, PublisherDtoForInsert>()
                //.ForMember(dest => dest.BlockId, opt => opt.MapFrom(src => src.Block.Id))
                .ReverseMap();


            //here
            CreateMap<Visitors, VisitorsDTO>().ReverseMap();
            CreateMap<Transportation, TransportationDTO>().ReverseMap();
            CreateMap<UsedBook, UsedBookDto>()
                .ForMember(dest => dest.DonorName, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();


            CreateMap<Review, ReviewDTO>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)); // Ensure UserId is mapped correctly if needed

            CreateMap<ReviewDTO, Review>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)); // Ensure UserId is mapped correctly if needed


        }
    }
}
