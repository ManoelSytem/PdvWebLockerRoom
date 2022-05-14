using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Util
{
    public class StatusMesa
    {
        public string Value { get; set; }
        private StatusMesa(string value) { Value = value; }

        public static StatusMesa Aberto { get { return new StatusMesa("A"); } }
        public static StatusMesa Fechado { get { return new StatusMesa("F"); } }
    }
}
