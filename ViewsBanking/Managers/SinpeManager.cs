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
    public class SinpeManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "sinpe/";



        public async Task<Sinpe> Insertar(Sinpe objInput, string token)
        {
            Sinpe error = JsonConvert.DeserializeObject<Sinpe>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Sinpe> GetByID(int id, string token)
        {
            Sinpe error = JsonConvert.DeserializeObject<Sinpe>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Sinpe>> GetAll(string token)
        {
            IEnumerable<Sinpe> list = JsonConvert.DeserializeObject<IEnumerable<Sinpe>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Sinpe objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}