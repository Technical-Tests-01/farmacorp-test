using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.dtos
{
    public class SaleExpressDto
    {
        public DateTime date { get; set; }
        public string clientName { get; set; }
        public int productExpressId { get; set; }
        public string uniqueCodeProduct { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

    }
}
