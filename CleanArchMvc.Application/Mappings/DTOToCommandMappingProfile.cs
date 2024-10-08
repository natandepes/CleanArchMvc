﻿using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();

            CreateMap<CategoryDTO, CategoryCreateCommand>();
            CreateMap<CategoryDTO, CategoryUpdateCommand>();    
        }
    }
}
