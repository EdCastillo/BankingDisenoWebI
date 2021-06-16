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
    public class TransferenciaManager : APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "transferencia/";



        public async Task<Transferencia> Insertar(Transferencia objInput, string token)
        {
            Transferencia error = JsonConvert.DeserializeObject<Transferencia>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "",token));
            return error;
        }
        public async Task<Transferencia> GetByID(int id, string token)
        {
            Transferencia error = JsonConvert.DeserializeObject<Transferencia>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Transferencia>> GetAll(string token)
        {
            IEnumerable<Transferencia> list = JsonConvert.DeserializeObject<IEnumerable<Transferencia>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Transferencia objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}