using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http;

namespace ViewsBanking.Utilities
{
    
    public class APIUtilities{
        public const string API_ROUTE= "https://localhost:50266/api/";


        public HttpClient GetAuthorizedClient(string token) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        
        public HttpClient GetAnonymousClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<object> Insertar(object obj, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            var result = await client.PostAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8));
            return JsonConvert.DeserializeObject<object>(await result.Content.ReadAsStringAsync());
        }
        public async Task Eliminar(int id, string routePrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            await client.DeleteAsync(API_ROUTE + routePrefix + HttpActionRoute + id);
        }
        public async Task Actualizar(object obj, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            await client.PutAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute, new StringContent(JsonConvert.SerializeObject(obj)));
        }
        public async Task<object> GetById(int id, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            var result = await client.GetStringAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute + id.ToString());
            return JsonConvert.DeserializeObject<object>(result);
        }
        public async Task<IEnumerable<object>> GetAll(string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            var result = await client.GetStringAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute);
            return JsonConvert.DeserializeObject<IEnumerable<object>>(result);
        }

    }
}
