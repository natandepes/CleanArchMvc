using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Diagnostics;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            };

            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            {
                Product product = new(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () =>
            {
                Product product = new(1, "Pr", "Product Description", 9.99m, 99, "product image");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name length. It must have at least 3 characters.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, "product imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image value. It must be at maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImage_NoNullReferenceException()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, null);
            };

            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithNullImage_NoDomainException()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, null);
            };

            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainExceptionNegativeValue()
        {

            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price. It can't be less than zero.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value) {

            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, value, "product image");
            };

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock. It can't be less than zero.");
        }
    }
}
