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
    public class SobreManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "sobre/";



        public async Task<Sobre> Insertar(Sobre objInput, string token)
        {
            Sobre error = JsonConvert.DeserializeObject<Sobre>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<Sobre> GetByID(int id, string token)
        {
            Sobre error = JsonConvert.DeserializeObject<Sobre>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return error;
        }
        public async Task<IEnumerable<Sobre>> GetAll(string token)
        {
            IEnumerable<Sobre> list = JsonConvert.DeserializeObject<IEnumerable<Sobre>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Sobre objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}