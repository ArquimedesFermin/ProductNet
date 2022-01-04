﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTO
{
    public class ProductsDTO
    {
        public string Marks { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string descrition { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string TypeProduct { get; set; }
        public DateTime DateManufacture { get; set; } 
    }
}
