using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class Token
    {
        public string authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        
    }
}
