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
    public class TarjetaManager : APIUtilities
    {

        private const string ROUTE_Object_PREFIX = "tarjeta/";



        public async Task<Tarjeta> Insertar(Tarjeta objInput, string token)
        {
            Tarjeta tarjeta = JsonConvert.DeserializeObject<Tarjeta>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return tarjeta;
        }
        public async Task<Tarjeta> GetByID(int id, string token)
        {
            Tarjeta tarjeta = JsonConvert.DeserializeObject<Tarjeta>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return tarjeta;
        }
        public async Task<IEnumerable<Tarjeta>> GetAll(string token)
        {
            IEnumerable<Tarjeta> list = JsonConvert.DeserializeObject<IEnumerable<Tarjeta>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Tarjeta objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}