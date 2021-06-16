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
    public class EstadisticaManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "estadistica/";

        public async Task<Estadistica> Insertar(Estadistica objInput, string token)
        {
            Estadistica error = JsonConvert.DeserializeObject<Estadistica>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Estadistica> GetByID(int id, string token)
        {
            Estadistica error = JsonConvert.DeserializeObject<Estadistica>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Estadistica>> GetAll(string token)
        {
            IEnumerable<Estadistica> list = JsonConvert.DeserializeObject<IEnumerable<Estadistica>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Estadistica objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}