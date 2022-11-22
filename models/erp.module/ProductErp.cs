using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.erp.module
{
	public class ProductErp : ProductExpress
	{

		public double cost { get; set; }
		public Guid uniqueCode { get; set; }
		public int stock { get; set; }
			
		
	}
}

