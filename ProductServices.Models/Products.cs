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
        public string Description { get; set; }

        //Prop Navegation
        public ProductType  productType { get; set; }
        public Models model { get; set; }
        public  List<ProductModelColorPrice> productModelColorPrices { get; set; }

    }
}
