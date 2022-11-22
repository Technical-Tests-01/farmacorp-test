using System;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic.impl
{
    public class SaleGanaMaxBusiness : ISaleGanaMaxBusiness
    {
        public SaleGanaMaxBusiness()
        {
        }

        public Task<ProductErp> registerProduct(ProductExpressDto productExpressDto)
        {
            Console.WriteLine("Register Product from [SaleGanamaxBusiness]");
            return null;
        }

        public Task<SaleExpress> registerSale(SaleExpress model)
        {
            throw new NotImplementedException();
        }
    }
}

