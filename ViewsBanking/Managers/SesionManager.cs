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
    public class SesionManager : APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "sesion/";



        public async Task<Sesion> Insertar(Sesion objInput, string token)
        {
            Sesion error = JsonConvert.DeserializeObject<Sesion>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Sesion> GetByID(int id, string token)
        {
            Sesion error = JsonConvert.DeserializeObject<Sesion>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Sesion>> GetAll(string token)
        {
            IEnumerable<Sesion> list = JsonConvert.DeserializeObject<IEnumerable<Sesion>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Sesion objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}