using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ViewsBanking.Models;
using ViewsBanking.Utilities;

namespace ViewsBanking.Managers
{
    public class ErrorManager:APIUtilities
    {
        private const string API_OBJECT_Prefix = "error/";

        public async Task<Error> Insertar(Error errorInput,string token) {
            Error error = JsonConvert.DeserializeObject<Error>(await base.Insertar(errorInput, API_OBJECT_Prefix, "", ""));
            return error;
        }
    }
}