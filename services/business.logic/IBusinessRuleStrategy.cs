using System;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic
{
	public interface IBusinessRuleStrategy
	{
		Task<ProductErp> registerProduct(ProductExpressDto productExpressDto);
        Task<SaleExpress> registerSale(SaleExpress model);
	}
}

