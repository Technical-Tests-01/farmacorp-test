using System;
using models;
using models.dtos;
using models.erp.module;
using services.business.logic;
using services.business.logic.impl;
using static data.access.Utils;

namespace farmacorp_test
{
	public class TestExercises
	{

        private readonly IEnumerable<IBusinessRuleStrategy> businessRuleStrategies;


        public TestExercises(IEnumerable<IBusinessRuleStrategy> businessRuleStrategies)
        {
            this.businessRuleStrategies = businessRuleStrategies;
        }

        public async Task<ProductErp> transactSaleExpressStrategyt01()
        {
            var result = default(ProductErp);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleExpressBusiness));
            if (!isNull(service))
            {

                var concretService = service as ISaleExpressBusiness;
                var param = new ProductExpressDto
                {
                    name = "Computer Lenovo",
                    cost = 200,
                    observations = "S/O",
                    expirationDate = DateTime.UtcNow,
                    productTypeId = 1,
                    stock = 2
                };
                result = await concretService.registerProduct(param);
            }
            return result;
            

        }

        public async Task<BarCode> transactSaleExpressStrategyt02()
        {
            var result = default(BarCode);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleExpressBusiness));
            if (!isNull(service))
            {
                var concretService = service as ISaleExpressBusiness;
                var param = new ProductExpressDto
                {
                    name = "Computer HP",
                    cost = 200,
                    observations = "S/O",
                    expirationDate = DateTime.UtcNow,
                    productTypeId = 1,
                    stock = 32
                };
                result = await concretService.assignBarCode(param);
            }
            return result;

        }

        public async Task<ProductCategory> transactSaleExpressStrategyt03()
        {
            var result = default(ProductCategory);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleExpressBusiness));
            if (!isNull(service))
            {
                var concretService = service as ISaleExpressBusiness;
                var param = new ProductCategoryDto
                {
                    productExpressId = 1,
                    categoryId = 1
                };
                result = await concretService.assignProdductCategory(param);
            }
            return result;
        }
        
        public async Task<SaleExpress> transactSaleExpressStrategyt04()
        {
            var result = default(SaleExpress);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleExpressBusiness));
            if (!isNull(service))
            {
                var concretService = service as ISaleExpressBusiness;
                
                var param = new SaleExpressDto
                {
                    date = DateTime.Now,
                    clientName = "Manuel Saavedra",
                    price = 30,
                    quantity = 10,
                    productExpressId = 1
                };
                result = await concretService.registerSale(param);
            }
            return result;
        }

        public async Task<ProductErp> transactSaleGanaMaxStrategyt01()
        {
            var result = default(ProductErp);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleGanaMaxBusiness));
            if (!isNull(service))
            {

                var concretService = service as ISaleGanaMaxBusiness;
                var param = new ProductExpressDto
                {
                    name = "MacBook",
                    cost = 100,
                    observations = "S/O",
                    expirationDate = DateTime.UtcNow,
                    productTypeId = 1,
                    stock = 20
                };
                result = await concretService.registerProduct(param);
            }
            return result;


        }

        public async Task<SaleExpress> transactSaleGanaMaxStrategyt04()
        {
            var result = default(SaleExpress);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleGanaMaxBusiness));
            if (!isNull(service))
            {
                var concretService = service as ISaleGanaMaxBusiness;

                var param = new SaleExpressDto
                {
                    date = DateTime.Now,
                    clientName = "Manuel Saavedra",
                    price = 50,
                    quantity = 5,
                    productExpressId = 1
                };
                result = await concretService.registerSale(param);
            }
            return result;
        }
    }
}

