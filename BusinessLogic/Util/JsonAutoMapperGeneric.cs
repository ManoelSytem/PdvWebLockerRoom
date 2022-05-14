using Aplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Aplication.Util
{
    public class JsonAutoMapperGeneric: IJsonAutoMapper
    {

        public T ConvertAutoMapperJson<T>(object obj)
        {
            string Jsonvalor = JsonConvert.SerializeObject(obj);
            T novaEntidade = JsonConvert.DeserializeObject<T>(Jsonvalor);
            return novaEntidade;
        }

        public List<T> ConvertAutoMapperListJson<T>(IEnumerable<object> obj)
        {
            string Jsonvalor = JsonConvert.SerializeObject(obj);
            List<T> novaEntidade = JsonConvert.DeserializeObject<List<T>>(Jsonvalor);
            return novaEntidade;
        }

        public ActionResultado Resposta(string mensagem, Exception e = null)
        {
            ActionResultado actionResult;


            if (e != null)
            {
                actionResult = new ActionResultado
                {
                    Success = "False",
                    Message = e.Message
                };
            }
            else
            {
                actionResult = new ActionResultado
                {
                    Success = "True",
                    Message = mensagem
                };
            }
            
            return actionResult;
        }
    }
}
