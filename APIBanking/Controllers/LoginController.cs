using APIBanking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace APIBanking.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Usuario user = returnUserOnValidation(login);
            if (user!=null)
            {
                user.TOKEN = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }
        private Usuario returnUserOnValidation(LoginRequest login) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,Username FROM USUARIO WHERE Username=@USERNAME AND Password=@PASSWORD", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@USERNAME", login.Username);
                sqlCommand.Parameters.AddWithValue("@PASSWORD", login.Password);
                sqlConnection.Open();
                Usuario usuario = new Usuario();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    usuario = new Usuario { Codigo = reader.GetInt32(0), Username = reader.GetString(1) };
                }
                sqlConnection.Close();
                return usuario;
            }
        }
    }
}
