﻿using System;
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

        [ForeignKey("mark")]
        public int IdMark { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Comments { get; set; }
        public DateTime DateManufacture { get; set; }

        //Prop Navegation
        public Marks mark { get; set; }
        public List<ProductColor> productColors { get; set; }

    }
}
