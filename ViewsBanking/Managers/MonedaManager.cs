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
    public class MonedaManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "moneda/";



        public async Task<Moneda> Insertar(Moneda errorInput, string token)
        {
            Moneda error = JsonConvert.DeserializeObject<Moneda>(await base.Insertar(errorInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Moneda> GetByID(int id, string token)
        {
            Moneda error = JsonConvert.DeserializeObject<Moneda>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Moneda>> GetAll(string token)
        {
            IEnumerable<Moneda> list = JsonConvert.DeserializeObject<IEnumerable<Moneda>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Moneda error, string token)
        {
            await base.Actualizar(error, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}