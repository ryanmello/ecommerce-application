﻿using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;

namespace EcommerceProject.Client.Services.InterfaceServices
{
    public interface IProductService
    {
        public Task<ServiceModel> AddProduct(Product newProduct);
        public Task<ServiceModel> GetProducts();
        public Task<ServiceModel> GetProduct(int productId);
    }
}
