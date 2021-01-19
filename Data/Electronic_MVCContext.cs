using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Electronic_MVC.Models;

namespace Electronic_MVC.Data
{
    public class Electronic_MVCContext : DbContext
    {
        public Electronic_MVCContext (DbContextOptions<Electronic_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Electronic_MVC.Models.Brand_Detail> Brand_Detail { get; set; }

        public DbSet<Electronic_MVC.Models.Category_Detail> Category_Detail { get; set; }

        public DbSet<Electronic_MVC.Models.Customer_Detail> Customer_Detail { get; set; }

        public DbSet<Electronic_MVC.Models.Product_Detail> Product_Detail { get; set; }

        public DbSet<Electronic_MVC.Models.Order_Detail> Order_Detail { get; set; }
    }
}
