using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class Marks
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("model")]
        public int IdModel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Prop Navegation
        public Models model { get; set; }

    }
}
