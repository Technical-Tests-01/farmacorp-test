using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.data.repository.impl
{
    public class ProductExpressRepository : Repository<ProductExpress>, IProductExpressRepository
    {
        public ProductExpressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
