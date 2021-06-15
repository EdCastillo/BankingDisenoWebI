using APIBanking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIBanking.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/error")]
    public class ErrorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getById(int id) {
            if (id == 0) {
                return BadRequest();
            }
            try
            {
                Error error = new Error();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,FechaHora,Fuente,Descripcion,Vista,Accion from Error where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        error = new Error { Codigo = reader.GetInt32(0), CodigoUsuario = reader.GetInt32(1), FechaHora = reader.GetDateTime(2), Fuente = reader.GetString(3), Descripcion = reader.GetString(4), Vista = reader.GetString(5), Accion = reader.GetString(6) };
                    }
                    sqlConnection.Close();

                    if (error.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(error);
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult getAll()
        {
            try
            {
                List<Error> list = new List<Error>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,FechaHora,Fuente,Descripcion,Vista,Accion from Error", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Error { Codigo = reader.GetInt32(0), CodigoUsuario = reader.GetInt32(1), FechaHora = reader.GetDateTime(2), Fuente = reader.GetString(3), Descripcion = reader.GetString(4), Vista = reader.GetString(5), Accion = reader.GetString(6) });
                    }
                    sqlConnection.Close();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public IHttpActionResult insert(Error error) {
            if (error == null) {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Error(CodigoUsuario,FechaHora,Fuente,Descripcion,Vista,Accion) output inserted.Codigo values(@CodigoUsuario,@FechaHora,@Fuente,@Descripcion,@Vista,@Accion)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", error.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@FechaHora", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@Fuente", error.Fuente);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", error.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Vista", error.Vista);
                    sqlCommand.Parameters.AddWithValue("@Accion", error.Accion);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        error.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(error);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult borrar(int id) {
            if (id == 0)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"delete Error  where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }



        [HttpPut]
        public IHttpActionResult Actualizar(Error error) {
            if (error == null) {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    //Se salta la actualizacion de la fecha 
                    SqlCommand sqlCommand = new SqlCommand(@"update Error set CodigoUsuario=@CodigoUsuario,Fuente=@Fuente,Descripcion=@Descripcion,Vista=@Vista,Accion=@Accion where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo",error.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", error.CodigoUsuario);
                    //Error al actualizar fecha por formato de entrada
                    //sqlCommand.Parameters.AddWithValue("@FechaHora", error.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Fuente", error.Fuente);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", error.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Vista", error.Vista);
                    sqlCommand.Parameters.AddWithValue("@Accion", error.Accion);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0)
                    {
                        return Ok();
                    }
                    return Ok();
                }
            }
            catch (Exception ex) {
                return InternalServerError(ex);    
            }
        }
        

    }
}
