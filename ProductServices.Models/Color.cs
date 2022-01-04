using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexColor { get; set; }
        public List<MarkColor> productColors { get; set; }

    }
}
