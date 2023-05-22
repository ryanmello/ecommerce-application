using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;

namespace EcommerceProject.Server.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<ServiceModel> AddProduct(Product newProduct);
        public Task<ServiceModel> GetProducts();
        public Task<ServiceModel> GetProduct(int productId);
    }
}
