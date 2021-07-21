using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace ViewsBanking.Utilities
{
    
    public class APIUtilities{

        public const string API_ROUTE= "http://eduardoleocr-002-site3.ctempurl.com/api/";

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
        
        protected async Task<string> Insertar(object obj, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            string json = JsonConvert.SerializeObject(obj);
            var result = await client.PostAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute, new StringContent(json, Encoding.UTF8,"application/json"));
            return await result.Content.ReadAsStringAsync();
        }
        protected async Task Eliminar(int id, string routePrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            await client.DeleteAsync(API_ROUTE + routePrefix + HttpActionRoute + id);
        }
        protected async Task Actualizar(object obj, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            await client.PutAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute, new StringContent(JsonConvert.SerializeObject(obj),Encoding.UTF8,"application/json"));
        }
        protected async Task<string> GetByID(int id, string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            var result = await client.GetStringAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute + id.ToString());
            return result;
        }
        protected async Task<string> GetAll(string routeObjectPrefix, string HttpActionRoute, string token)
        {
            HttpClient client = GetAuthorizedClient(token);
            var result = await client.GetStringAsync(API_ROUTE + routeObjectPrefix + HttpActionRoute);
            return result;
        }
    }
}
