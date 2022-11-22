using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using activate_assurance.Models;

namespace models
{
	public class SaleExpress : BaseEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int saleExpressId { get; set; }


		public DateTime date { get; set; }
		public string clientName { get; set; }
		public string productName { get; set; }
		public string uniqueCodeProduct { get; set; }
		public int quantity { get; set; }
		public double price { get; set; }
		public double discount { get; set; }
		public double total { get; set; }

		[ForeignKey(name: "productExpressId")]
        public ProductExpress productExpress { get; set; }


        public SaleExpress()
		{
		}
	}
}

