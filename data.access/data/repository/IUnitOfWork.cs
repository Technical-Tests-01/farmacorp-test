using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using activate_assurance.DataAccess.Data.Repository;

namespace data.access.data.repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductTypeRepository productTypeRepository { get; }
        public IProductCategoryRepository productCategoryRepository { get; }

            
    }
}
