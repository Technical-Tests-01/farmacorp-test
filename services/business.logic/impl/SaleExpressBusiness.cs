using System;
using data.access;
using data.access.data.repository;
using data.access.data.repository.impl;
using Microsoft.VisualBasic;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic.impl
{
    public class SaleExpressBusiness : ISaleExpressBusiness
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IProductErpRepository productErpRepository;
        private readonly IProductExpressRepository productExpressRepository;
        private readonly IBarCodeRepository barCodeRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly ISaleExpressRepository saleExpressRepository;

        public SaleExpressBusiness(IProductTypeRepository productTypeRepository, IProductErpRepository productErpRepository, IBarCodeRepository barCodeRepository, ICategoryRepository categoryRepository, IProductCategoryRepository productCategoryRepository, IProductExpressRepository productExpressRepository, ISaleExpressRepository saleExpressRepository)
        {
            this.productTypeRepository = productTypeRepository;
            this.productErpRepository = productErpRepository;
            this.barCodeRepository = barCodeRepository;
            this.categoryRepository = categoryRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productExpressRepository = productExpressRepository;
            this.saleExpressRepository = saleExpressRepository;
        }

        public async Task<BarCode> assignBarCode(ProductExpressDto productExpressDto)
        {
            var productTypeFind = await productTypeRepository.getByIdAsync(productExpressDto.productTypeId);


            var barCodeModel = new BarCode
            {
                uniqueCode = Guid.NewGuid(),
                ProductExpress = new ProductExpress
                {
                    name = productExpressDto.name,
                    observations = productExpressDto.observations,
                    expirationDate = productExpressDto.expirationDate,
                    productType = productTypeFind,
                    price = productExpressDto.cost * 0.5,
                }
            };
            var productBarCodeResult = await barCodeRepository.addAsync(barCodeModel);

            Console.WriteLine("Register ProductBarCode from [SaleExpressBusiness]");
            return productBarCodeResult;

        }

        public async Task<ProductCategory> assignProdductCategory(ProductCategoryDto productCategoryDto)
        {
            var categoryFind = await categoryRepository.getByIdAsync(productCategoryDto.categoryId);
            var productExpressFind = await productExpressRepository.getByIdAsync(productCategoryDto.productExpressId);

            var productCategoryModel = new ProductCategory
            {
                category = categoryFind,
                productExpress = productExpressFind
            };
            var productCategoryResult = await productCategoryRepository.addAsync(productCategoryModel);
            Console.WriteLine("Register ProductCategory from [SaleExpressBusiness]");
            return productCategoryResult;
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
                price = productExpressDto.cost * 0.5,
            };
            var productResult = await productErpRepository.addAsync(productModel);

            Console.WriteLine("Register Product from [SaleExpressBusiness]");
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
                bool ruleValidation04 = uniqueProductFind.stock - saleExpressDto.quantity >= 0;
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
                    discount = saleExpressDto.price * 0.3
                };

                saleExpressModel.total = saleExpressModel.price - saleExpressModel.discount;


                saleExpressResult = await saleExpressRepository.addAsync(saleExpressModel);

                // refresh stock
                uniqueProductFind.stock -= saleExpressDto.quantity;
                await productErpRepository.updateAsync(uniqueProductFind.productExpressId, uniqueProductFind);
            }

            Console.WriteLine("Register SaleExpress from [SaleExpressBusiness]");

            return saleExpressResult;


        }
    }
}

