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
    public class TipoManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "tipo/";



        public async Task<Tipo> Insertar(Tipo objInput, string token)
        {
            Tipo error = JsonConvert.DeserializeObject<Tipo>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Tipo> GetByID(int id, string token)
        {
            Tipo error = JsonConvert.DeserializeObject<Tipo>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Tipo>> GetAll(string token)
        {
            IEnumerable<Tipo> list = JsonConvert.DeserializeObject<IEnumerable<Tipo>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Tipo objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}