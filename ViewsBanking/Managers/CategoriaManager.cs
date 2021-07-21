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
    public class CategoriaManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "categoria/";



        public async Task<Categoria> Insertar(Categoria objInput, string token)
        {
            Categoria categoria = JsonConvert.DeserializeObject<Categoria>(await base.Insertar(objInput, ROUTE_Object_PREFIX, "", token));
            return categoria;
        }
        public async Task<Categoria> GetByID(int id, string token)
        {
            Categoria categoria = JsonConvert.DeserializeObject<Categoria>(await base.GetByID(id, ROUTE_Object_PREFIX, "", token));
            return categoria;
        }
        public async Task<IEnumerable<Categoria>> GetAll(string token)
        {
            IEnumerable<Categoria> list = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(await base.GetAll(ROUTE_Object_PREFIX, "", token));
            return list;
        }
        public async Task Actualizar(Categoria objInput, string token)
        {
            await base.Actualizar(objInput, ROUTE_Object_PREFIX, "", token);
        }
        public async Task Eliminar(int id, string token)
        {
            await base.Eliminar(id, ROUTE_Object_PREFIX, "", token);
        }
    }
}