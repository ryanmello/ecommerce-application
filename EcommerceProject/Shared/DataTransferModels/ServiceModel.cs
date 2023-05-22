using EcommerceProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Shared.DataTransferModels
{
    public class ServiceModel
    {
        public List<Product>? ProductList { get; set; } = null;
        public Product? SingleProduct { get; set; } = null;
        public bool Success { get; set; } = true;
        public string? CssClass { get; set; } = "success";
        public string? Message { get; set; } = null;
    }
}
