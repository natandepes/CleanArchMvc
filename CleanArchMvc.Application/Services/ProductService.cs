using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            ProductCreateCommand command = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(command);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            GetProductByIdQuery query = new((int)id);
            Product product = await _mediator.Send(query);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            GetProductsQuery query = new();
            IEnumerable<Product> products = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task Remove(int? id)
        {
            ProductRemoveCommand command = new((int)id);
            await _mediator.Send(command);
        }

        public async Task Update(ProductDTO productDTO)
        {
            ProductUpdateCommand command = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(command);
        }
    }
}
