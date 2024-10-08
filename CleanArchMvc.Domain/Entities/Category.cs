﻿using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            Id = id;
            ValidateDomain(name);
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name value. The name can't be empty.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name length. It must have at least 3 characters.");

            Name = name;
        }
    }
}
