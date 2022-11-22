using System;
using System.Collections.Generic;
using System.Text;
using data.access;
using data.access.data.repository;

namespace data.access.data.repository.impl
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            // inicializar los repositorios asociados con sus dbcontext respectivamente
            productTypeRepository = new ProductTypeRepository(dbContext);
            productCategoryRepository = new ProductCategoryRepository(dbContext);

        }

        public IProductTypeRepository productTypeRepository { get; private set; }
        public IProductCategoryRepository productCategoryRepository { get; private set; }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        // actualizar este proceso para que sea de tipo función en futuras iteraciones
        public void save()
        {
            dbContext.SaveChanges();
        }
    }
}
