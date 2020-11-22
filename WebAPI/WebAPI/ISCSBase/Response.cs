using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ISCSBase
{
    public class Response
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int ID { get; set; }
    }
}
