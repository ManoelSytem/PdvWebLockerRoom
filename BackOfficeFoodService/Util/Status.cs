using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Util
{
    public class Status
    {
        public string Value { get; set; }
        private Status(string value) { Value = value; }

        public static Status Aberto { get { return new Status("A"); } }
        public static Status Fechado { get { return new Status("F"); } }
    }
}
