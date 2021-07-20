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
    public class PrestamoManager : APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "prestamo/";



        public async Task<Prestamo> Insertar(Prestamo objInput, string token)
        {
            Prestamo prestamo = JsonConvert.DeserializeObject<Prestamo>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return prestamo;
        }
        public async Task<Prestamo> GetByID(int id, string token)
        {
            Prestamo prestamo = JsonConvert.DeserializeObject<Prestamo>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return prestamo;
        }
        public async Task<IEnumerable<Prestamo>> GetAll(string token)
        {
            IEnumerable<Prestamo> list = JsonConvert.DeserializeObject<IEnumerable<Prestamo>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Prestamo objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}