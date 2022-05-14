using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServiceApi.Model
{
    public class ClienteModel
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        public string email { get; set; }
        
    }
}
