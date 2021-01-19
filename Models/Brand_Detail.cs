using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_MVC.Models
{
    public class Brand_Detail
    {

        public int Id { get; set; }

        [Required]
        public string Brand_Name { get; set; }

        public string Brand_Branch_Location { get; set; }

        public string Brand_Email { get; set; }
    }
}
