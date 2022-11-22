using System;
using activate_assurance.Models;
using data.access.data.repository.impl;
using Microsoft.EntityFrameworkCore;
using models;
using models.erp.module;

namespace data.access.data.repository.impl
{
	public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        
        public ProductCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}

