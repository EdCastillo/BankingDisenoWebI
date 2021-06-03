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

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                return BadRequest();
            try
            {
                Usuario user = returnUserOnValidation(login);
                if (user.Codigo!=0)
                {
                    user.Password = null;
                    user.TOKEN = TokenGenerator.GenerateTokenJwt(login.Username);
                    return Ok(user);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        private Usuario returnUserOnValidation(LoginRequest login) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,Username,Email,Estado,Nombre,Identificacion,FechaNacimiento FROM USUARIO WHERE Username=@USERNAME AND Password=@PASSWORD", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@USERNAME", login.Username);
                sqlCommand.Parameters.AddWithValue("@PASSWORD", login.Password);
                sqlConnection.Open();
                Usuario usuario = new Usuario();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    usuario = new Usuario { Codigo = reader.GetInt32(0), Username = reader.GetString(1),Email=reader.GetString(2),Estado=reader.GetString(3),Nombre=reader.GetString(4),Identificacion=reader.GetString(5),FechaNacimiento=reader.GetDateTime(6) };
                }
                sqlConnection.Close();
                return usuario;
            }
        }
        [HttpPost]
        [Route("ingresar")]
        public IHttpActionResult registrar(Usuario usuario) {
            if (usuario == null) {
                return BadRequest();
            }
            try {
                Usuario newUser = privateInsert(usuario);
                if (newUser.Codigo == 0)
                {
                    return InternalServerError();
                }
                else {
                    newUser.TOKEN = TokenGenerator.GenerateTokenJwt(newUser.Username);
                    return Ok(newUser);
                }

            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }


        private Usuario privateInsert(Usuario usuario) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO USUARIO OUTPUT inserted.Codigo VALUES(@Identificacion,@Nombre,@Username,@Password,@Email,@FechaNacimiento,@Estado)",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Identificacion", usuario.Identificacion);
                sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@Username", usuario.Username);
                sqlCommand.Parameters.AddWithValue("@Password", usuario.Password);
                sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
                sqlCommand.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                sqlCommand.Parameters.AddWithValue("@Estado", usuario.Estado);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    usuario.Codigo = reader.GetInt32(0);
                }
                sqlConnection.Close();
                return usuario;
            }
        }

    }
    




}
