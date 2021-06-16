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
        private const string ROUTE_Object_PREFIX = "error/";

       
        
        public async Task<Error> Insertar(Error objInput, string token) {
            Error error = JsonConvert.DeserializeObject<Error>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public  async Task<Error> GetByID(int id,string token) {
            Error error=JsonConvert.DeserializeObject<Error>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public  async Task<IEnumerable<Error>> GetAll(string token) {
            IEnumerable<Error> list = JsonConvert.DeserializeObject<IEnumerable<Error>>(await base.GetAll(ROUTE_Object_PREFIX, "",token));
            return list;
        }
        public  async Task Actualizar(Error objInput, string token) {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public  async Task Eliminar(int id, string token) {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}