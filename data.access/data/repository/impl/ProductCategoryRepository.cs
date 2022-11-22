using System;
using activate_assurance.Models;
using data.access.data.repository.impl;
using Microsoft.EntityFrameworkCore;
using models.erp.module;

namespace data.access
{
	public class ProductErpRepository : Repository<ProductErp>, IProductErpRepository
    {
        private readonly ApplicationDbContext context;

        public ProductErpRepository(DbContext context) : base(context)
        {
        }
    }
}

