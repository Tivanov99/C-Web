﻿namespace SMS.Services
{
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System;
    public class ProductService : IProductService
    {
        private readonly Repository repo;
        public ProductService(Repository repo)
        {
            this.repo = repo;
        }

        public void Create(CreateProductModel createProductModel)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createProductModel.Name,
                Price = createProductModel.Price,
            };
            this.repo.Add<Product>(product);
        }

        public (bool, ErrorViewModel) ValidateProductData(CreateProductModel createProductModel)
        {
            bool isValid = true;
            ErrorViewModel errorViewModel = new();

            if (string.IsNullOrWhiteSpace(createProductModel.Name) ||
                createProductModel.Name.Length < GlobalConstants.productNameMinLength ||
                createProductModel.Name.Length > GlobalConstants.productNameMaxLength)
            {
                errorViewModel.Errors.Add(new ErrorMessage("Invalid product name!"));
                isValid = false;
            }
            if (createProductModel.Price < GlobalConstants.productMinPrice ||
                createProductModel.Price > GlobalConstants.productMaxPrice)
            {
                errorViewModel.Errors.Add(new ErrorMessage("Invalid product price!"));
                isValid = false;
            }
            return (isValid, errorViewModel);
        }

    }
}
