using System;
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

        public async Task<ProductErp> testExerciceOne()
        {
            var result = default(ProductErp);
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleExpressBusiness));
            if (!isNull(service))
            {
                var param = new ProductExpressDto
                {
                    name = "Computer Lenovo",
                    cost = 200,
                    observations = "S/O",
                    expirationDate = DateTime.Now,
                    productTypeId = 1,
                    stock = 2
                };
                result = await service.registerProduct(param);
            }
            return result;
            

        }

        public void testExerciceTwo()
        {
            var service = businessRuleStrategies.FirstOrDefault(x => x.GetType() == typeof(SaleGanaMaxBusiness));
            if (!isNull(service))
            {
                service.registerProduct(null);
            }


        }
    }
}

