using System;
using activate_assurance.Models;
using data.access.data.repository.impl;
using Microsoft.EntityFrameworkCore;

namespace data.access.data.repository.impl
{
	public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DbContext context) : base(context)
        {
        }
    }
}

