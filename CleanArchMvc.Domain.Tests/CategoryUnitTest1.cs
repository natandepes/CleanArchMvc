using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                Category category = new(1, "Category Name");
            };

            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category with negative id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            {
                Category category = new(-1, "Category Name");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value.");
        }

        [Fact(DisplayName = "Create category with short name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () =>
            {
                Category category = new(1, "Ca");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name length. It must have at least 3 characters.");
        }

        [Fact(DisplayName = "Create category with empty name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () =>
            {
                Category category = new(1, "");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name value. The name can't be empty.");
        }

        [Fact(DisplayName = "Create category with empty name")]
        public void CreateCategory_NullNameValue_DomainExceptionRequiredName()
        {
            Action action = () =>
            {
                Category category = new(1, null);
            };

            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    }
}
