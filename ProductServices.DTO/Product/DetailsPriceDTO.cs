using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTO.Product
{
    public class DetailsPriceDTO
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string ColorHex { get; set; }
    }
}
