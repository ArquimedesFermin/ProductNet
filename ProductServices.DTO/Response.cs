using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTO
{
    public class Response
    {
        public int StatusCode { get; set; }
        public bool IsOk { get; set; }
        public object Result { get; set; }
    }
}
