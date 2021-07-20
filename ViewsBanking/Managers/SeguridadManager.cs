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
    public class SeguridadManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "seguridad/";



        public async Task<Seguridad> Insertar(Seguridad objInput, string token)
        {
            Seguridad error = JsonConvert.DeserializeObject<Seguridad>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Seguridad> GetByID(int id, string token)
        {
            Seguridad error = JsonConvert.DeserializeObject<Seguridad>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Seguridad>> GetAll(string token)
        {
            IEnumerable<Seguridad> list = JsonConvert.DeserializeObject<IEnumerable<Seguridad>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Seguridad objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}