using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class ProductModelColorPrice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ModelColorPrice")]
        public int IdModelColorPrice { get; set; }
      
        [ForeignKey("Products")]
        public int IdProducts { get; set; }
        public ModelColorPrice  ModelColorPrice { get; set; }
        public Products Products { get; set; }
    }
}
