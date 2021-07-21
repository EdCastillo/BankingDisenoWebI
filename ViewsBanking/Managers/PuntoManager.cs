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
    public class PuntoManager : APIUtilities 
    {
        private const string ROUTE_Object_PREFIX = "punto/";



        public async Task<Punto> Insertar(Punto objInput, string token)
        {
            Punto error = JsonConvert.DeserializeObject<Punto>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Punto> GetByID(int id, string token)
        {
            Punto error = JsonConvert.DeserializeObject<Punto>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Punto>> GetAll(string token)
        {
            IEnumerable<Punto> list = JsonConvert.DeserializeObject<IEnumerable<Punto>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Punto objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}