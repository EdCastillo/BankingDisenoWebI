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
        public  async Task<Error> GetByID(int id,string token) {
            Error error=JsonConvert.DeserializeObject<Error>(await base.GetByID(id, API_OBJECT_Prefix, "", token));
            return error;
        }
        public  async Task<IEnumerable<Error>> GetAll(string token) {
            IEnumerable<Error> list = JsonConvert.DeserializeObject<IEnumerable<Error>>(await base.GetAll(API_OBJECT_Prefix,"",token));
            return list;
        }
        public  async Task Actualizar(Error error,string token) {
            await base.Actualizar(error, API_OBJECT_Prefix, "", token);
        }
        public  async Task Eliminar(int id, string token) {
            await base.Eliminar(id, API_OBJECT_Prefix, "", token);
        }
    }
}