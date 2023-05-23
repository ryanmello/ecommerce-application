using EcommerceProject.Client.Services.InterfaceServices;
using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;
using System.Net.Http.Json;

namespace EcommerceProject.Client.Services.ImplementationServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceModel> AddProduct(Product newProduct)
        {
            var product = await httpClient.PostAsJsonAsync("api/product/add-product", newProduct);
            return await product.Content.ReadFromJsonAsync<ServiceModel>();
        }

        public async Task<ServiceModel> GetProduct(int productId)
        {
            var result = await httpClient.GetAsync($"api/product/get-product/(productId)");
            return await result.Content.ReadFromJsonAsync<ServiceModel>();
        }

        public async Task<ServiceModel> GetProducts()
        {
            var result = await httpClient.GetAsync("api/product");
            return await result.Content.ReadFromJsonAsync<ServiceModel>();
        }
    }
}
