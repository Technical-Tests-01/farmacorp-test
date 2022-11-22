using System;
using data.access.data.repository;
using data.access;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic.impl
{
    public class SaleGanaMaxBusiness : ISaleGanaMaxBusiness
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IProductErpRepository productErpRepository;
        private readonly ISaleExpressRepository saleExpressRepository;

        public SaleGanaMaxBusiness(IProductTypeRepository productTypeRepository, IProductErpRepository productErpRepository, ISaleExpressRepository saleExpressRepository)
        {
            this.productTypeRepository = productTypeRepository;
            this.productErpRepository = productErpRepository;
            this.saleExpressRepository = saleExpressRepository;
        }

        public async Task<ProductErp> registerProduct(ProductExpressDto productExpressDto)
        {
            var productTypeFind = await productTypeRepository.getByIdAsync(productExpressDto.productTypeId);

            var productModel = new ProductErp
            {
                uniqueCode = Guid.NewGuid(),
                cost = productExpressDto.cost,
                stock = productExpressDto.stock,

                name = productExpressDto.name,
                expirationDate = productExpressDto.expirationDate,
                observations = productExpressDto.observations,
                productType = productTypeFind,
                price = productExpressDto.cost * 0.8,
            };
            var productResult = await productErpRepository.addAsync(productModel);

            Console.WriteLine("Register Product from [SaleGanaMaxBusiness]");
            return productResult;
        }

        public async Task<SaleExpress> registerSale(SaleExpressDto saleExpressDto)
        {
            var saleExpressResult = default(SaleExpress);
            var productsFind = await productErpRepository.getAllAsync(pr => pr.productExpressId == saleExpressDto.productExpressId, includeProperties: "productCategories");

            if (productsFind.Any())
            {
                var uniqueProductFind = productsFind[0];

                bool ruleValidation01 = productsFind.Count() == 1;
                bool ruleValidation03 = uniqueProductFind.productCategories.Count() == 1;
                bool ruleValidation04 = uniqueProductFind.stock - saleExpressDto.quantity > 10;
                if (!ruleValidation01 || !ruleValidation03 || !ruleValidation04)
                {
                    return default(SaleExpress);
                }
                Guid newBarCode = Guid.Parse(Guid.NewGuid().ToString("X"));

                var saleExpressModel = new SaleExpress
                {
                    date = saleExpressDto.date,
                    clientName = saleExpressDto.clientName,
                    productName = uniqueProductFind.name,
                    productExpress = uniqueProductFind,
                    uniqueCodeProduct = newBarCode.ToString(),
                    quantity = saleExpressDto.quantity,
                    price = saleExpressDto.price,
                    discount = saleExpressDto.price * 0.1
                };

                saleExpressModel.total = saleExpressModel.price - saleExpressModel.discount;


                saleExpressResult = await saleExpressRepository.addAsync(saleExpressModel);

                // refresh stock
                uniqueProductFind.stock -= saleExpressDto.quantity;
                await productErpRepository.updateAsync(uniqueProductFind.productExpressId, uniqueProductFind);
            }

            Console.WriteLine("Register SaleExpress from [SaleGanaMaxBusiness]");

            return saleExpressResult;
        }
    }
}

