using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using activate_assurance.Models;

namespace models
{
	public class ProductCategory : BaseEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int detailId { get; set; }

		[ForeignKey(name: "categoryId")]
		public Category category { get; set; }

		[ForeignKey(name: "productExpressId")]
		public ProductExpress productExpress { get; set; }

		public ProductCategory()
		{
		}
	}
}

