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
    public class ServicioManager : APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "servicio/";



        public async Task<Servicio> Insertar(Servicio objInput, string token)
        {
            Servicio error = JsonConvert.DeserializeObject<Servicio>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Servicio> GetByID(int id, string token)
        {
            Servicio error = JsonConvert.DeserializeObject<Servicio>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Servicio>> GetAll(string token)
        {
            IEnumerable<Servicio> list = JsonConvert.DeserializeObject<IEnumerable<Servicio>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Servicio objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}