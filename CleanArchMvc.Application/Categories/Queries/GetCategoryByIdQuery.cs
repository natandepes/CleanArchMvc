﻿using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; set; }
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
