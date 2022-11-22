using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using models;

namespace activate_assurance.Models
{
    public class ProductType : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productTypeId { get; set; }


        [Column(Order = 1)]
        [StringLength(maximumLength: 300)]
        public string? description { get; set; }

        [InverseProperty(property: "productType")]
        public List<ProductExpress> productExpresses { get; set; }

        public ProductType()
        {
            productExpresses = new List<ProductExpress>();
        }


    }
}
