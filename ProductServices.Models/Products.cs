using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
 
        [ForeignKey("productType")]
        public int IdProductType { get; set; }

        [ForeignKey("model")]
        public int IdModel { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Comments { get; set; }
        public DateTime DateManufacture { get; set; }

        //Prop Navegation
        public List<MarkColor> productColors { get; set; }
        public ProductType  productType { get; set; }
        public Models model { get; set; }

    }
}
