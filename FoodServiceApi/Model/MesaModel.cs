using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServiceApi.Model
{
    public class MesaModel
    {
        public int codigo { get; set; }
        public int numero { get; set; }
        public string status { get; set; }
        public string seqAbreMesa { get; set; }
    }
}
