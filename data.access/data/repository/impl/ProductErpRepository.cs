using System;
using Microsoft.EntityFrameworkCore;
using models.erp.module;

namespace data.access.data.repository.impl
{
    public class ProductErpRepository : Repository<ProductErp>, IProductErpRepository
    {
        public ProductErpRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

