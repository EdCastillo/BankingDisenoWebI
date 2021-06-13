using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewsBanking.Models;
using ViewsBanking.Utilities;

namespace ViewsBanking.Managers
{
    public class UsuarioManager:APIUtilities
    {
        private const string ROUTE_Object_PREFIX = "login/";
        private const string LoginRoute = "authenticate";


        public async Task<Usuario> Login(LoginRequest loginRequest) {
            HttpClient client = new HttpClient();
            string route = API_ROUTE + ROUTE_Object_PREFIX + LoginRoute;
            var result=await client.PostAsync(route,new StringContent(JsonConvert.SerializeObject(loginRequest),Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Usuario>(await result.Content.ReadAsStringAsync());
        }
        public async Task<Usuario> Insertar(Usuario usuario) {
            HttpClient client = GetAnonymousClient();
            var result = await client.PostAsync((API_ROUTE + ROUTE_Object_PREFIX +"ingresar"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8,"application/json"));
            return JsonConvert.DeserializeObject<Usuario>(await result.Content.ReadAsStringAsync());
        }
        
    }
}