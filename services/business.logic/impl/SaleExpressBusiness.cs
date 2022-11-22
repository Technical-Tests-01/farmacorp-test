using System;
using data.access;
using data.access.data.repository;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic.impl
{
    public class SaleExpressBusiness : ISaleExpressBusiness
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IProductErpRepository productErpRepository;

        public SaleExpressBusiness(IProductTypeRepository productTypeRepository, IProductErpRepository productErpRepository)
        {
            this.productTypeRepository = productTypeRepository;
            this.productErpRepository = productErpRepository;
        }

        public Task<BarCode> assignBarCode(ProductBarCodeDto productBarCodeDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> assignProdductCategory(ProductCategoryDto productCategoryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductErp> registerProduct(ProductExpressDto productExpressDto)
        {
            var productTypeFind = await productTypeRepository.getByIdAsync(productExpressDto.productTypeId);

            var productModel = new ProductErp
            {
                uniqueCode = Guid.NewGuid(),
                cost = productExpressDto.cost,
                stock = productExpressDto.stock,

                active = true,
                name = productExpressDto.name,
                observations = productExpressDto.observations,
                productType = productTypeFind,
                price = productExpressDto.cost * 0.5,
            };
            var productResult =  await productErpRepository.addAsync(productModel);

            Console.WriteLine("Register Product from [SaleExpressBusiness]");
            return productResult;
        }

        public Task<SaleExpress> registerSale(SaleExpress model)
        {
            throw new NotImplementedException();
        }
    }
}

