using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class ModelColorPrice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("model")]
        public int IdModel { get; set; }
        [ForeignKey("color")]
        public int IdColor { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Models model { get; set; }
        public Color color { get; set; }
        public List<ProductModelColorPrice> productModelColorPrices { get; set; }

    }
}
