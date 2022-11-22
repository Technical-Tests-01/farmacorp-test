using System;
namespace models.dtos
{
    public class ProductExpressDto
    {
        public string name { get; set; }
        public double cost { get; set; }
        public int stock { get; set; }
        public DateTime expirationDate { get; set; }
        public string observations { get; set; }
        public int productTypeId { get; set; }
    }
}

