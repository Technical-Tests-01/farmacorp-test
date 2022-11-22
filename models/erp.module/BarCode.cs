using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using activate_assurance.Models;

namespace models.erp.module
{
	public class BarCode: BaseEntity
	{


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int barCodeId { get; set; }


        public Guid uniqueCode { get; set; }
		public bool active { get; set; } 

		[ForeignKey(name: "productExpressId")]
		public ProductExpress ProductExpress { get; set; }


		public BarCode()
		{
			active = true;
		}
		
	}
}

