using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_MVC.Models
{
    public class Product_Detail
    {
        public int Id { get; set; }

        [Required]
        public string Product_Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        //code to connect the Brand Class with Product Details Class
        public int Brand_DetailId { get; set; }
        public Brand_Detail Brand_Detail { get; set; }

        //code to connect the Category Class with Product Details Class
        public int Category_DetailId { get; set; }
        public Category_Detail Category_Detail { get; set; }
    }
}
