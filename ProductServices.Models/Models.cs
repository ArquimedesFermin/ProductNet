using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class Models
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Mark")]
        public int IdMark { get; set; }
        public string Name { get; set; }
        public Marks Mark { get; set; }
        public List<ModelColorPrice> modelColorPrice { get; set; }

    }
}
