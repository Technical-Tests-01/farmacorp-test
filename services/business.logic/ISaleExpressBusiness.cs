using System;
using models;
using models.dtos;
using models.erp.module;

namespace services.business.logic
{
	public interface ISaleExpressBusiness : IBusinessRuleStrategy
    {
        Task<BarCode> assignBarCode(ProductExpressDto productExpressDto);
        Task<ProductCategory> assignProdductCategory(ProductCategoryDto productCategoryDto);
    }
}

