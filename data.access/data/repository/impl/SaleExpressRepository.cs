using System;
using Microsoft.EntityFrameworkCore;
using models;

namespace data.access.data.repository.impl
{
    public class SaleExpressRepository : Repository<SaleExpress>, ISaleExpressRepository
    {
        public SaleExpressRepository(DbContext context) : base(context)
        {
        }
    }
}

