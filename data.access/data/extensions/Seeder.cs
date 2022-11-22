using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using models;
using models.erp.module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.data.extensions
{
    public static class Seeder
    {

        public static void Initialize(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            // Product Type & List of ProductsExpress
            dbContext.ProductTypes.Add(new ProductType
            {
                description = "tecnologia",
                productExpresses = new List<ProductExpress>
                {
                    new ProductErp
                    {
                        name = "Computador ASUS X212",
                        expirationDate = DateTime.Now,
                        observations ="Estado 9/10",
                        price = 1500,

                        stock = 30,
                        uniqueCode = Guid.NewGuid(),
                        cost = 150
                    }
                }
            });


            // Category
            dbContext.Categories.Add(new Category
            {
                description = "Electrodomesticos",
                categories = new List<Category>
                {
                    new Category{description = "Computadores"},
                    new Category{description = "Equipos de video"},
                    new Category{description = "Equipos de audio"},
                }
            });



            dbContext.SaveChanges();

        }
    }
}
