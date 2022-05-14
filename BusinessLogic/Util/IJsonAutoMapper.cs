using Aplication.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Aplication.Util
{
    public interface IJsonAutoMapper
    {
        public T ConvertAutoMapperJson<T>(object obj);
        public ActionResultado Resposta(string mensagem, Exception e = null);
        public List<T> ConvertAutoMapperListJson<T>(IEnumerable<object> obj);
    }
}
