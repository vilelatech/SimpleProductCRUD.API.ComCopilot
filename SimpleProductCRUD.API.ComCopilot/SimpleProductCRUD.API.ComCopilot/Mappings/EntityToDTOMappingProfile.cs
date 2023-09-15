using AutoMapper;
using SimpleProductCRUD.API.ComCopilot.DTOs;
using SimpleProductCRUD.API.ComCopilot.Entities;

namespace SimpleProductCRUD.API.ComCopilot.Mappings;

public class EntityToDTOMappingProfile : Profile
{
    public EntityToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}