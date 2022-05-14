using BackOfficeFoodService.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Util
{
    public class JsonExeptionResult
    {
        public JsonExeptionResult()
        {

        }
        public static ResultApi ApiResult(ApiException ex)
        {
            var jsonToList = JsonConvert.DeserializeObject<ResultApi>(ex.Content.ToString());
            return jsonToList;
        }
    }
}
