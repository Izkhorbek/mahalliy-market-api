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

        CreateMap<ProductSales, ProductSalesUserDTO>()
            .ForMember(desc => desc.quantity_sold, act => act.MapFrom(src => src.quantity))
            .ReverseMap();

        CreateMap<DeliveryMethod, DeliveryMethodUserDTO>()
            .ForMember(desc => desc.method_id, act => act.MapFrom(src => src.delivery_method_id))
            .ForMember(desc => desc.is_free, act => act.MapFrom(src => src.is_free_delivery))
            .ReverseMap();
    }
}
