using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DTOs
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public string ResponseText { get; set; }
        public dynamic Data { get; set; }
    }
}
