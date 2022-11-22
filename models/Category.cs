using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using activate_assurance.Models;

namespace models
{
	public class Category : BaseEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; }


        [Column(Order = 1)]
        [StringLength(maximumLength: 300)]
        public string description { get; set; }

        [Column(Order = 2)]
        public bool active { get; set; }


        public Category categoryParent { get; set; }

        [Column(Order = 3)]
        public int? categoryParentId { get; set; }


        
        public List<Category> categories { get; }


        [InverseProperty("category")]
        public List<ProductCategory> productCategories { get; set; }


        public Category()
		{
            categories = new List<Category>();
            productCategories = new List<ProductCategory>();
		}
	}
}

