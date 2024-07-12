using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            CategoryCreateCommand command = _mapper.Map<CategoryCreateCommand>(categoryDTO);
            await _mediator.Send(command);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            GetCategoryByIdQuery query = new((int)id);
            Category category = await _mediator.Send(query);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            GetCategoriesQuery query = new();
            IEnumerable<Category> categories = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task Remove(int? id)
        {
            CategoryRemoveCommand command = new((int)id);
            await _mediator.Send(command);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            CategoryUpdateCommand command = _mapper.Map<CategoryUpdateCommand>(categoryDTO);
            await _mediator.Send(command);
        }
    }
}
