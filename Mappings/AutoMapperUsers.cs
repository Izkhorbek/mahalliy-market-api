using AutoMapper;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;

namespace MahalliyMarket.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //Mappers

        //User
        CreateMap<User, UserResponseDTO>().ReverseMap();

        // Product
        CreateMap<ProductImage, ProductImageUserDTO>().ReverseMap();
        CreateMap<ProductVideo, ProductVideoUserDTO>().ReverseMap();
        CreateMap<ProductFeedback, ProductFeedbackUserDTO>()
            .ForMember(dest => dest.customer_name, act =>
                 act.MapFrom(src => src.customer != null ?
                 (src.customer.first_name + " " + src.customer.last_name) :
                 "unknown"))
            .ReverseMap();

        CreateMap<ProductSales, ProductSalesUserDTO>().ReverseMap();
        CreateMap<DeliveryMethod, DeliveryMethodUserDTO>().ReverseMap();
    }
}
