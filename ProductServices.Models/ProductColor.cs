using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class ProductColor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("products")]
        public int IdProduct { get; set; }
        [ForeignKey("color")]
        public int IdColor { get; set; }
        public decimal Price { get; set; }
        public Products products { get; set; }
        public Color color { get; set; }
    }
}
