using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewsBanking.Models;
using ViewsBanking.Utilities;

namespace ViewsBanking.Controllers
{
    public class UtilitiesController : Controller
    {
        // GET: Utilities
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public async Task<ActionResult> GetLink(int amount, string token) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", token);
            var content=await client.PostAsync(APIUtilities.API_ROUTE+"PayPal?amount="+amount,null);
            string result=await content.Content.ReadAsStringAsync();
            return Redirect(result);
        }
    }
}