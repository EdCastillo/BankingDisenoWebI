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
    public class CuentaManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "cuenta/";

        public async Task<Cuenta> Insertar(Cuenta cuentaInput,string token) {
            Cuenta cuenta = JsonConvert.DeserializeObject<Cuenta>(await Insertar(cuentaInput, ROUTE_Object_PREFIX, "", token));
            return cuenta;
        }
        public async Task<Cuenta> GetByID(int id, string token)
        {
            Cuenta error = JsonConvert.DeserializeObject<Cuenta>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Cuenta>> GetAll(string token)
        {
            IEnumerable<Cuenta> list = JsonConvert.DeserializeObject<IEnumerable<Cuenta>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Cuenta error, string token)
        {
            await base.Actualizar(error, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}