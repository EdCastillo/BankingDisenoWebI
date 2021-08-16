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
    public class AbonoManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "abono/";


        public async Task<Abono> Insertar(Abono objInput, string token)
        {
            Abono error = JsonConvert.DeserializeObject<Abono>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Abono> GetByID(int id, string token)
        {
            Abono error = JsonConvert.DeserializeObject<Abono>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Abono>> GetAll(string token)
        {
            IEnumerable<Abono> list = JsonConvert.DeserializeObject<IEnumerable<Abono>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Abono objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}