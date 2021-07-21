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
    public class ProveedorManager : APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "proveedor/";



        public async Task<Proveedor> Insertar(Proveedor objInput, string token)
        {
            Proveedor error = JsonConvert.DeserializeObject<Proveedor>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Proveedor> GetByID(int id, string token)
        {
            Proveedor error = JsonConvert.DeserializeObject<Proveedor>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Proveedor>> GetAll(string token)
        {
            IEnumerable<Proveedor> list = JsonConvert.DeserializeObject<IEnumerable<Proveedor>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Proveedor objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}