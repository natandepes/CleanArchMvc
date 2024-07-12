using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using AutoMapper;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
