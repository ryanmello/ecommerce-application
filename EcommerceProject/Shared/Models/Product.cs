using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 6)]
        public string? Name { get; set; }

        [Required, StringLength(1000, MinimumLength = 10)]
        public string? Description { get; set; }

        [Required, DataType(DataType.Currency)]
        public double OriginalPrice { get; set; }

        [DataType(DataType.Currency)]
        public double NewPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string? Image { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
