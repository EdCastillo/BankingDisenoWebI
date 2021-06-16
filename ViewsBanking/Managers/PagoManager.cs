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
    public class PagoManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "pago/";



        public async Task<Pago> Insertar(Servicio objInput, string token)
        {
            Pago error = JsonConvert.DeserializeObject<Pago>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Pago> GetByID(int id, string token)
        {
            Pago error = JsonConvert.DeserializeObject<Pago>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Pago>> GetAll(string token)
        {
            IEnumerable<Pago> list = JsonConvert.DeserializeObject<IEnumerable<Pago>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Pago objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}