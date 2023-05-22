using EcommerceProject.Server.Data;
using EcommerceProject.Server.Repositories.Interfaces;
using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Server.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<ServiceModel> AddProduct(Product newProduct)
        {
            var response = new ServiceModel();
            if (newProduct != null)
            {
                try
                {
                    appDbContext.Products.Add(newProduct);
                    await appDbContext.SaveChangesAsync();

                    response.SingleProduct = newProduct;
                    response.Success = true;
                    response.Message = "Product added successfully";
                    response.CssClass = "success";
                    return response;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message.ToString();
                    return response;
                }
            } 
            else
            {
                response.Success = false;
                response.Message = "Product is null";
                response.CssClass = "warning";
                return response;
            }
        }

        public async Task<ServiceModel> GetProduct(int productId)
        {
            var response = new ServiceModel();
            if (productId > 0)
            {
                try
                {
                    var product = await appDbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
                    if (product != null)
                    {
                        response.SingleProduct = product;
                        response.Success = true;
                        response.Message = "Product found";
                        response.CssClass= "success";
                        return response;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Product not found";
                        response.CssClass = "info";
                        return response;
                    }
                } 
                catch(Exception ex)
                {
                    response.Success= false;
                    response.Message = ex.Message.ToString();
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid Id";
                response.CssClass = "warning";
                return response;
            }
        }

        public async Task<ServiceModel> GetProducts()
        {
            var response = new ServiceModel();
            try
            {
                var products = await appDbContext.Products.ToListAsync();
                if (products != null)
                {
                    response.ProductList = products;
                    response.Success = true;
                    response.Message = "Products found";
                    response.CssClass = "success";
                    return response;
                } 
                else
                {
                    response.Success = false;
                    response.Message = "No products found";
                    response.CssClass = "info";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
                response.CssClass = "warning";
                return response;
            }
        }
    }
}
