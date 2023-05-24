using EcommerceProject.Server.Data;
using EcommerceProject.Server.Repositories.Interfaces;
using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
                response.SingleProduct = null;
                return response;
            }
        }

        public async Task<ServiceModel> DeleteProduct(int productId)
        {
            var response = new ServiceModel();  
            var item = await appDbContext.Products.FindAsync(productId);
            try
            { 
                if (item != null)
                {
                    appDbContext.Products.Remove(item);
                    await appDbContext.SaveChangesAsync();

                    response.Success = true;
                    response.Message = "Product deleted successfully";
                    response.CssClass = "success";
                    return response;
                } 
                else
                {
                    response.Success = false;
                    response.Message = "Please enter a valid id";
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

        public async Task<ServiceModel> UpdateProduct(int productId, Product newProduct)
        {
            var response = new ServiceModel();
            try
            {
                var product = await appDbContext.Products.FindAsync(productId);
                if (product != null)
                {
                    product.Name = newProduct.Name;
                    product.Description = newProduct.Description;
                    product.OriginalPrice = newProduct.OriginalPrice;
                    product.NewPrice = newProduct.NewPrice;
                    product.Image = newProduct.Image;
                    product.Quantity = newProduct.Quantity;
                    await appDbContext.SaveChangesAsync();

                    response.Success = true;
                    response.Message = "Product Updated sucessfully";

                    return response;
                } 
                else
                {
                    response.Success = false;
                    response.Message = "Product with given id is null";

                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
