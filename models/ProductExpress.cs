using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using activate_assurance.Models;

namespace models
{
	public class ProductExpress : BaseEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productExpressId { get; set; }


        [Column(Order = 1)]
        [StringLength(maximumLength:50)]
        public string name { get; set; }

        [Column(Order = 2)]
        public double price { get; set; }

        [Column(Order = 3)]
        public bool active{ get; set; }

        [Column(Order = 4)]
        public DateTime expirationDate { get; set; }

        [Column(Order = 5)]
        [StringLength(maximumLength: 300)]
        public string? observations { get; set; }

        [ForeignKey(name: "productTypeId")]
        public ProductType productType { get; set; }

        [InverseProperty("productExpress")]
        public List<ProductCategory> productCategories { get; set; }

        public ProductExpress()
        {
            productCategories = new List<ProductCategory>();
        }

    }
}

